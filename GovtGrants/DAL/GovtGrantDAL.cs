using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
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
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var house = new Household
                        {
                            HouseholdId = (int)reader["householdId"],
                            HousingType = reader["housingType"] as string
                        };
                        result.Add(house);
                    }
                    
                }
            }
            return result;
        }
        public int InsertHousehold(Household household)
        {
            var sql = @"INSERT INTO 
                        dbo.Household 
                            (HousingType) 
                        VALUES 
                            (@housingType)";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@housingType", household.HousingType);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int InsertMember(FamilyMember member)
        {
            //todo
            var sql = @"INSERT INTO 
                        dbo.Household 
                            (HousingType) 
                        VALUES 
                            (@housingType)";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@housingType", member.HouseholdId);
                    cmd.Parameters.AddWithValue("@housingType", member.Name);
                    cmd.Parameters.AddWithValue("@housingType", member.Gender);
                    cmd.Parameters.AddWithValue("@housingType", member.MaritalStatus);
                    cmd.Parameters.AddWithValue("@housingType", member.SpouseName);
                    cmd.Parameters.AddWithValue("@housingType", member.OccupationType);
                    cmd.Parameters.AddWithValue("@housingType", member.AnnualIncome);
                    cmd.Parameters.AddWithValue("@housingType", member.DateOfBirth);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public HouseholdWithMember SearchHousehold(int id)
        {
            var result = new HouseholdWithMember();

            var sql = @"SELECT 
                            HouseholdId,
                            HousingType 
                        FROM govt_system.dbo.Household";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.HousingType = reader["HousingType"] as string;
                        var member = new HouseholdMember
                        {
                            Name = reader["name"] as string,
                            Gender = reader["gender"] as string,
                            MaritalStatus = reader["maritalStatus"] as string,
                            OccupationType = reader["occupationType"] as string,
                            AnnualIncome = (decimal) reader["housingType"],
                            DateOfBirth = (DateTime) reader["housingType"]
                        };
                        result.Members.Add(member);
                    }

                }
            }
            return result;
        }
    }
}