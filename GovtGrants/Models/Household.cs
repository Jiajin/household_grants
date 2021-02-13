using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class Household
    {
        public int HouseholdId { get; set; }
        public string HousingType { get; set; }
        public List<string> IsValid ()
        {
            var errorList = new List<string>();

            if (!Constants.HousingType.Contains(this.HousingType))
            {
                errorList.Add("Housing Type is invalid");
            }
            return errorList;
        }
    }
}