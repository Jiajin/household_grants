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
                          hh.HouseholdId
                          ,hh.HousingType
                          ,fm.Name
                          ,fm.Gender
                          ,fm.MaritalStatus
                          ,fm.SpouseName
                          ,fm.OccupationType
                          ,fm.AnnualIncome
                          ,fm.DateOfBirth
                      FROM   dbo.Household hh
                      INNER JOIN dbo.FamilyMember fm on hh.HouseholdId = fm.HouseholdId 
                      WHERE hh.HouseholdId in  (
					      SELECT householdId from (
						      SELECT
						      householdId
						      ,sum(annualIncome) as TotalIncome
						      ,min((CONVERT(int,CONVERT(char(8),current_timestamp,112))-CONVERT(char(8),[DateOfBirth],112))/10000)  as MinAge
						    FROM govt_system.dbo.FamilyMember
						    GROUP BY householdId
						    ) as HouseholdData where MinAge < 16 and TotalIncome < 150000
                    )";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql).ToList();
            }
        }
        public List<HouseholdSearchResult> SearchFTSHousehold()
        {
            var sql = @"SELECT 
                          hh.HouseholdId
                          ,hh.HousingType
                          ,fm.Name
                          ,fm.Gender
                          ,fm.MaritalStatus
                          ,fm.SpouseName
                          ,fm.OccupationType
                          ,fm.AnnualIncome
                          ,fm.DateOfBirth
                      FROM dbo.Household hh
                      INNER JOIN dbo.FamilyMember fm on hh.HouseholdId = fm.HouseholdId 
                      WHERE hh.HouseholdId in  (
					          select householdId from (
						          select
						          householdId
						          ,min((CONVERT(int,CONVERT(char(8),current_timestamp,112))-CONVERT(char(8),[DateOfBirth],112))/10000)  as MinAge
						        FROM govt_system.dbo.FamilyMember
						        group by householdId
						        ) as HouseholdData where MinAge < 18 )
						AND hh.householdId in(
                              select 
                               distinct householdId
                                FROM govt_system.dbo.FamilyMember fm1
	                            where maritalstatus = 'Married' and EXISTS(select fm2.familymemberid from familymember fm2 where fm1.spousename = fm2.name)
                            )";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql).ToList();
            }
        }
        public List<HouseholdSearchResult> SearchEBHousehold()
        {
            var sql = @"SELECT 
                          hh.HouseholdId
                          ,hh.HousingType
                          ,fm.Name
                          ,fm.Gender
                          ,fm.MaritalStatus
                          ,fm.SpouseName
                          ,fm.OccupationType
                          ,fm.AnnualIncome
                          ,fm.DateOfBirth
                      FROM   dbo.Household hh
                      INNER JOIN dbo.FamilyMember fm on hh.HouseholdId = fm.HouseholdId 
                      WHERE hh.HouseholdId in  (
					      SELECT householdId from (
						      SELECT
						      householdId
						      ,max((CONVERT(int,CONVERT(char(8),current_timestamp,112))-CONVERT(char(8),[DateOfBirth],112))/10000) as MaxAge
						    FROM govt_system.dbo.FamilyMember
						    GROUP BY householdId
						    ) as HouseholdData where MaxAge > 50
                    )";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql).ToList();
            }
        }
        public List<HouseholdSearchResult> SearchBSGHousehold()
        {
            var sql = @"SELECT 
                          hh.HouseholdId
                          ,hh.HousingType
                          ,fm.Name
                          ,fm.Gender
                          ,fm.MaritalStatus
                          ,fm.SpouseName
                          ,fm.OccupationType
                          ,fm.AnnualIncome
                          ,fm.DateOfBirth
                      FROM   dbo.Household hh
                      INNER JOIN dbo.FamilyMember fm on hh.HouseholdId = fm.HouseholdId 
                      WHERE hh.HouseholdId in  (
					      SELECT householdId from (
						      SELECT
						      householdId
						      ,min((CONVERT(int,CONVERT(char(8),current_timestamp,112))-CONVERT(char(8),[DateOfBirth],112))/10000) as MinAge
						    FROM govt_system.dbo.FamilyMember
						    GROUP BY householdId
						    ) as HouseholdData where MinAge < 5
                    )";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql).ToList();
            }
        }
        public List<HouseholdSearchResult> SearchYGGHousehold()
        {
            var sql = @"SELECT 
                          hh.HouseholdId
                          ,hh.HousingType
                          ,fm.Name
                          ,fm.Gender
                          ,fm.MaritalStatus
                          ,fm.SpouseName
                          ,fm.OccupationType
                          ,fm.AnnualIncome
                          ,fm.DateOfBirth
                      FROM   dbo.Household hh
                      INNER JOIN dbo.FamilyMember fm on hh.HouseholdId = fm.HouseholdId 
                      WHERE hh.HouseholdId in  (
					      SELECT householdId from (
						      SELECT
						      householdId
						      ,sum(annualIncome) as TotalIncome
						    FROM govt_system.dbo.FamilyMember
						    GROUP BY householdId
						    ) as HouseholdData where TotalIncome < 100000
                    )";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<HouseholdSearchResult>(sql).ToList();
            }
        }
    }
}