using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using GovtGrants.DAL;
using GovtGrants.Models;

namespace GovtGrants.Controllers
{
    [RoutePrefix("api/GovtGrant")]
    public class GovtGrantController : ApiController
    {
        // GET api/GovtGrant
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/GovtGrant/5
        public int Get(int id)
        {
            return 0;
        }
        //[Route("Get2/{id:int}")]
        //public Household Get2(int id)
        //{
        //    var dal = new GovtGrantDAL();
        //    var result = dal.GetHousehold("1");
        //    return result;
        //}
        [HttpPost]
        [Route("CreateHousehold")]
        public ResponseObj CreateHousehold(string housingType)
        {
            if (housingType is null)
            {
                return PrepareResponse(false, "Params/Post data is missing");
            }

            var dal = new GovtGrantDAL();
            var newHousehold = new Household
            {
                HousingType = housingType
            };

            //Validation
            var errors = newHousehold.IsValid();
            if (errors.Count > 0)
            {
                return PrepareResponse(false, String.Join("\n",errors));
            }
            else
            {
                try
                {
                    var result = dal.InsertHousehold(newHousehold);
                    return PrepareResponse(true, newHousehold);
                }
                catch (Exception ex)
                {
                    //Log exception message
                    //By right should return generic messsage to accessor
                    return PrepareResponse(false, ex.Message);
                }
            }
        }

        [HttpPost]
        [Route("AddMember")]
        public ResponseObj AddMember([FromBody]FamilyMember member)
        {
            if (member is null)
            {
                return PrepareResponse(false, "Params/Post data is missing");
            }

            var dal = new GovtGrantDAL();

            //Validation
            var errors = member.IsValid();
            
            if (errors.Count > 0)
            {
                return PrepareResponse(false, String.Join("\n", errors));
            }
            else
            {
                try
                {
                    var result = dal.InsertMember(member);
                    return PrepareResponse(true, result);
                }
                catch (Exception ex)
                {
                    //Log exception message
                    //By right should return generic messsage to accessor
                    return PrepareResponse(false, ex.Message);
                }                    
            }

        }

        [HttpPost]
        [Route("ListHousehold")]
        public ResponseObj ListHousehold()
        {
            var result = new List<ListHouseholdReturn>();
            var dal = new GovtGrantDAL();

            var members = dal.ListHousehold();

            //To nicely arrange Household with nested list of members
            if (members.Count >0)
            {
                //Do per household
                var membersDict = members.GroupBy(x => x.HouseholdId).ToDictionary(x => x.Key, x => x.ToList());
                var householdList = members.GroupBy(x => x.HouseholdId).Select(x => x.FirstOrDefault()).ToList();

                foreach (var hh in householdList)
                {
                    var oneHousehold = new ListHouseholdReturn();
                    oneHousehold.Members = new List<HouseholdMemberWSpouse>();
                    oneHousehold.HouseholdId = hh.HouseholdId;
                    oneHousehold.HousingType = hh.HousingType;

                    var memberList = membersDict[hh.HouseholdId];
                    foreach(var member in memberList)
                    {
                        var newHhMember = new HouseholdMemberWSpouse
                        {
                            Name = member.Name,
                            Gender = member.Gender,
                            MaritalStatus = member.MaritalStatus,
                            Spouse = member.Spouse,
                            OccupationType = member.OccupationType,
                            AnnualIncome = member.AnnualIncome,
                            DateOfBirth = member.DateOfBirth
                        };
                        oneHousehold.Members.Add(newHhMember);
                    }
                    result.Add(oneHousehold);
                }
            }

            return PrepareResponse(true, result);
        }

        [HttpPost]
        [Route("ShowHousehold")]
        public ResponseObj ShowHousehold(int id)
        {
            var result = new ShowHouseholdReturn();

            var dal = new GovtGrantDAL();
            var members = dal.SearchHousehold(id);

            if (members.Count >0 )
            {
                //initialize empty list
                result.Members = new List<HouseholdMember>();
                result.HousingType = members[0].HousingType;
                foreach(var member in members)
                {
                    var newHhMember = new HouseholdMember
                    {
                        Name = member.Name,
                        Gender = member.Gender,
                        MaritalStatus = member.MaritalStatus,
                        OccupationType = member.OccupationType,
                        AnnualIncome = member.AnnualIncome,
                        DateOfBirth = member.DateOfBirth
                    };
                    result.Members.Add(newHhMember);
                }
            }
            return PrepareResponse(true, result);
        }

        [HttpPost]
        [Route("SearchQualifyingHousehold")]
        public ResponseObj SearchQualifyingHousehold(string schemeType)
        {
            //Check valid schemetype
            if (!Constants.Schemes.Contains(schemeType))
            {
                return PrepareResponse(false, "Invalid SchemeCode. it should be SEB/FTS/EB/BSG/YGG");
            }
            else
            {
                var result = new List<ListHouseholdReturn>();
                var members = new List<HouseholdSearchResult>();
                var dal = new GovtGrantDAL();
                switch (schemeType)
                {
                    case Constants.Scheme_SEB:
                        members = dal.SearchSEBHousehold();
                        break;
                    case Constants.Scheme_FTS:
                        members = dal.SearchFTSHousehold();
                        break;
                    case Constants.Scheme_EB:
                        members = dal.SearchEBHousehold();
                        break;
                    case Constants.Scheme_BSG:
                        members = dal.SearchBSGHousehold();
                        break;
                    case Constants.Scheme_YGG:
                        members = dal.SearchYGGHousehold();
                        break;
                    default:
                        return PrepareResponse(false, "Invalid SchemeCode. it should be SEB/FTS/EB/BSG/YGG");
                }

                //To nicely arrange Household with nested list of members
                if (members.Count > 0)
                {
                    //Do per household
                    var membersDict = members.GroupBy(x => x.HouseholdId).ToDictionary(x => x.Key, x => x.ToList());
                    var householdList = members.GroupBy(x => x.HouseholdId).Select(x => x.FirstOrDefault()).ToList();

                    foreach (var hh in householdList)
                    {
                        var oneHousehold = new ListHouseholdReturn();
                        oneHousehold.Members = new List<HouseholdMemberWSpouse>();
                        oneHousehold.HouseholdId = hh.HouseholdId;
                        oneHousehold.HousingType = hh.HousingType;

                        var memberList = membersDict[hh.HouseholdId];
                        foreach (var member in memberList)
                        {
                            var newHhMember = new HouseholdMemberWSpouse
                            {
                                Name = member.Name,
                                Gender = member.Gender,
                                MaritalStatus = member.MaritalStatus,
                                Spouse = member.Spouse,
                                OccupationType = member.OccupationType,
                                AnnualIncome = member.AnnualIncome,
                                DateOfBirth = member.DateOfBirth
                            };
                            oneHousehold.Members.Add(newHhMember);
                        }
                        result.Add(oneHousehold);
                    }
                }
                return PrepareResponse(true, result);
            }
        }

        private ResponseObj PrepareResponse(bool status, object response)
        {
            var newResponse = new ResponseObj
            {
                IsSuccess = status,
                Timestamp = DateTime.Now,
                Message = response
            };
            return newResponse;
        }
    }
}