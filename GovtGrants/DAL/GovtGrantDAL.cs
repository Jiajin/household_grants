using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using GovtGrants.Models;

namespace GovtGrants.DAL
{
    public class GovtGrantDAL
    {

        protected static string ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public FamilyMember GetFamilyMember (string id)
        {
            return null;
        }
        public List<Household> ListHousehold()
        {
            var result = new List<Household>();

            var sql = @"SELECT 
                            HouseholdId,
                            HousingType 
                        FROM govt_system.dbo.Household";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<Household>(sql).ToList();
            }
        }
        public int InsertHousehold(Household household)
        {
            var sql = @"INSERT INTO  dbo.Household 
                            (HousingType) 
                        VALUES 
                            (@housingType)";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Execute(sql, household);
            }
        }

        public int InsertMember(FamilyMember member)
        {
            //todo
            var sql = @"INSERT INTO dbo.FamilyMember
                           (HouseholdId
                           ,Name
                           ,Gender
                           ,MaritalStatus
                           ,SpouseName
                           ,OccupationType
                           ,AnnualIncome
                           ,DateOfBirth)
                     VALUES
                           (@householdId
                           ,@name
                           ,@gender
                           ,@maritalStatus 
                           ,@spouseName
                           ,@occupationType
                           ,@annualIncome
                           ,@dateOfBirth)";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Execute(sql, member);
            }
        }

        public List<HouseholdSearchResult> SearchHousehold(int id)
        {
            var searchId = new HouseholdSearchResult
            {
                HouseholdId = id
            };

            var sql = @"SELECT 
                          hh.HousingType
                          ,fm.Name
                          ,fm.Gender
                          ,fm.MaritalStatus
                          ,fm.SpouseName
                          ,fm.OccupationType
                          ,fm.AnnualIncome
                          ,fm.DateOfBirth
                      FROM 
                      dbo.Household hh
                      inner join dbo.FamilyMember fm on hh.HouseholdId = fm.HouseholdId 
                      where hh.HouseholdId = @HouseholdId";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql, searchId).ToList();
            }
        }
    }
}