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
        public Household Get(int id)
        {
            var dal = new GovtGrantDAL();
            var result = dal.GetHousehold("1");
            return result;
        }
        [Route("Get2/{id:int}")]
        public Household Get2(int id)
        {
            var dal = new GovtGrantDAL();
            var result = dal.GetHousehold("1");
            return result;
        }
        [HttpPost]
        //[Route("InsertHousehold")]
        public int InsertHousehold(int id)
        {
            var dal = new GovtGrantDAL();
            var newHousehold = new Household
            {
                householdId = 97,
                housingType = "Landed"
            };
            var result = dal.InsertHousehold(newHousehold);
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
    }
}