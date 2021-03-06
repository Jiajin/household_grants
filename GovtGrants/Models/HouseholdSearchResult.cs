﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class HouseholdSearchResult
    {
        public int HouseholdId { get; set; }
        public string HousingType { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Spouse { get; set; }
        public string OccupationType { get; set; }
        public decimal? AnnualIncome { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}