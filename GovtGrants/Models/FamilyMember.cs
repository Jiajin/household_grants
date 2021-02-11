using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class FamilyMember
    {
        public int familyMemberId { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public int spouseId { get; set; }
        public string occupationType { get; set; }
        public decimal annualIncome { get; set; }
        public DateTime dateOfBirth { get; set; }
    }
}