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
        //1. Create Household
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
        //2. Add  family member to household
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
        //3. List all households
        public List<HouseholdSearchResult> ListHousehold()
        {
            var result = new List<Household>();

            var sql = @" SELECT 
						  hh.HouseholdId
                          ,hh.HousingType
                          ,fm.Name
                          ,fm.Gender
                          ,fm.MaritalStatus
                          ,fm.SpouseName
                          ,fm.OccupationType
                          ,fm.AnnualIncome
                          ,fm.DateOfBirth
                      FROM 
                      dbo.Household hh
                      inner join dbo.FamilyMember fm on hh.HouseholdId = fm.HouseholdId ";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql).ToList();
            }
        }
        //4. Show (one) household
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
        //5. Schemes for households (5 methods)
        public List<HouseholdSearchResult> SearchSEBHousehold()
        {
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
                      where hh.HouseholdId in  (
					  select householdId from (
						  select
						  householdId
						  ,sum(annualIncome) as TotalIncome
						  
						  ,min((CONVERT(int,CONVERT(char(8),current_timestamp,112))-CONVERT(char(8),[DateOfBirth],112))/10000)  as MinAge
						  
						  ,max((CONVERT(int,CONVERT(char(8),current_timestamp,112))-CONVERT(char(8),[DateOfBirth],112))/10000) as MaxAge


						FROM [govt_system].[dbo].[FamilyMember]
						group by householdId
						) as HouseholdData where MinAge < 16 and TotalIncome < 150000)";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql).ToList();
            }
        }
    }
}