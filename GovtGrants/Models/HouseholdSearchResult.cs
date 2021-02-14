using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class HouseholdSearchResult : HouseholdMember
    {
        public int HouseholdId { get; set; }
        public string HousingType { get; set; }
        //Member  fields already in base class HouseholdWithMember
    }
}