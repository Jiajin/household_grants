﻿using System;
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
            var dal = new GovtGrantDAL();
            var newHousehold = new Household
            {
                HousingType = housingType
            };

            //Validation
            var errors = newHousehold.IsValid();
            if (errors.Count > 0)
            {
                //error todo

                return PrepareResponse(false, "");
            }
            else
            {
                var result = dal.InsertHousehold(newHousehold);

                return PrepareResponse(true, newHousehold);
            }

        }

        [HttpPost]
        [Route("ListHousehold")]
        public List<Household> ListHousehold()
        {
            var dal = new GovtGrantDAL();
            var result = dal.ListHousehold();
            return result;
        }

        // POST api/GovtGrant
        public void Post([FromBody] string value)
        {
        }

        // PUT api/GovtGrant/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/GovtGrant/5
        public void Delete(int id)
        {
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