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
        public Household GetHousehold(string id)
        {
            //string connString = @"server=(local);initial     catalog=MyDatabase;Integrated Security=SSPI;";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT HouseholdId,HousingType FROM govt_system.dbo.Household", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var result = new Household
                        {
                            householdId = (int)reader["householdId"],
                            housingType = reader["housingType"] as string
                        };
                        return result;
                    }
                    
                }
            }
            return null;
        }
        public int InsertHousehold(Household household)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Household (HousingType) VALUES (@housingType)", conn))
                {
                    cmd.Parameters.AddWithValue("@housingType", household.housingType);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}