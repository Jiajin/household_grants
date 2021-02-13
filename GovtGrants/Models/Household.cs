using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class Household
    {
        public int householdId { get; set; }
        public string housingType { get; set; }
        public List<string> IsValid (Household household)
        {
            var errorList = new List<string>();

            if (!Constants.HousingType.Contains(household.housingType))
            {
                errorList.Add("Housing Type is invalid");
            }
            return errorList;
        }
    }
}