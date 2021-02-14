using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class HouseholdWithMember
    {
        public int HouseholdId { get; set; }
        public string HousingType { get; set; }
        public List<HouseholdMember> Members { get; set; }
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
    public class HouseholdMember
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string OccupationType { get; set; }
        public decimal? AnnualIncome { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}