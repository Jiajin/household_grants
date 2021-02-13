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
        public string spouseName { get; set; }
        public string occupationType { get; set; }
        public decimal? annualIncome { get; set; }
        public DateTime dateOfBirth { get; set; }
        public List<string> IsValid (FamilyMember familyMember)
        {
            var errorList = new List<string>();

            if(String.IsNullOrEmpty(familyMember.name))
            {
                errorList.Add("Name should not be empty");
            }

            if (!Constants.Gender.Contains(familyMember.gender))
            {
                errorList.Add("Gender is invalid");
            }

            if (!Constants.MaritalStatus.Contains(familyMember.maritalStatus))
            {
                errorList.Add("Marital Status is invalid");
            }else if(familyMember.maritalStatus == Constants.MaritalStatus_Married && String.IsNullOrEmpty(familyMember.spouseName))
            {
                errorList.Add("Spouse Name is required for married family members");
            }

            if (!Constants.OccupationType.Contains(familyMember.occupationType))
            {
                errorList.Add("Occupation Type is invalid");
            }

            if (familyMember.occupationType == Constants.Occupation_Employed && !annualIncome.HasValue)
            {
                errorList.Add("Annual Income should be provided for Employed members");
            }

            if(familyMember.dateOfBirth == DateTime.MinValue)
            {
                errorList.Add("Date of birth should not be empty");
            }

            return errorList;
        }
    }
}