using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string OccupationType { get; set; }
        public decimal? AnnualIncome { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> IsValid ()
        {
            var errorList = new List<string>();

            if(String.IsNullOrEmpty(this.Name))
            {
                errorList.Add("Name should not be empty");
            }

            if(this.HouseholdId <0)
            {
                errorList.Add("Invalid Household ID");
            }

            if (!Constants.Gender.Contains(this.Gender))
            {
                errorList.Add("Gender is invalid");
            }

            if (!Constants.MaritalStatus.Contains(this.MaritalStatus))
            {
                errorList.Add("Marital Status is invalid");
            }else if(this.MaritalStatus == Constants.MaritalStatus_Married && String.IsNullOrEmpty(this.SpouseName))
            {
                errorList.Add("Spouse Name is required for married family members");
            }

            if (!Constants.OccupationType.Contains(this.OccupationType))
            {
                errorList.Add("Occupation Type is invalid");
            }

            if (this.OccupationType == Constants.Occupation_Employed && !AnnualIncome.HasValue)
            {
                errorList.Add("Annual Income should be provided for Employed members");
            }

            if (this.DateOfBirth == DateTime.MinValue)
            {
                errorList.Add("Date of birth should not be empty");
            }

            return errorList;
        }
    }
}