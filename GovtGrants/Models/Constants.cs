using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public static class Constants
    {
        //Housing Types
        public const string HousingType_Landed = "Landed";
        public const string HousingType_Condo = "Condominium";
        public const string HousingType_HDB = "HDB";
        public const string HousingType_EC = "Executive Condominium";
        public static IEnumerable<string> HousingType = new List<string>
        {
            HousingType_Landed,
            HousingType_Condo,
            HousingType_HDB,
            HousingType_EC
        };

        #region Family Member values
        //Gender
        public const string Gender_M = "M";
        public const string Gender_F = "F";
        public static IEnumerable<string> Gender = new List<string>
        {
            Gender_M,
            Gender_F
        };

        //Marital Status
        public const string MaritalStatus_Single = "Single";
        public const string MaritalStatus_Married = "Married";
        public static IEnumerable<string> MaritalStatus = new List<string>
        {
            MaritalStatus_Single,
            MaritalStatus_Married
        };

        //Occupation Type
        public const string Occupation_Unemployed = "Unemployed";
        public const string Occupation_Student = "Student";
        public const string Occupation_Employed = "Employed";
        public static IEnumerable<string> OccupationType = new List<string>
        {
            Occupation_Unemployed,
            Occupation_Student,
            Occupation_Employed
        };
        #endregion

        public const string Scheme_SEB = "SEB";
        public const string Scheme_FTS = "FTS";
        public const string Scheme_EB = "EB";
        public const string Scheme_BSG = "BSG";
        public const string Scheme_YGG = "YGG";
        public static IEnumerable<string> Schemes = new List<string>
        {
            Scheme_SEB,
            Scheme_FTS,
            Scheme_EB,
            Scheme_BSG,
            Scheme_YGG
        };

    }
}