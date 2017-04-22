using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlannerAPI.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        
        public static Recipe Get(int id) {
            using (SqlConnection conn = new SqlConnection()) {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MealPlannerConnectionString"].ConnectionString;
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Recipes WHERE ID = {id}";

                        if (conn.State == System.Data.ConnectionState.Closed) {
                            conn.Open();
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                return Recipe.Parse(reader);
                            }
                        }

                        return null;
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                    return null;
                } finally {
                    if (conn.State == System.Data.ConnectionState.Open) {
                        conn.Close();
                    }
                }
            }
        }

        public static Recipe Parse(SqlDataReader reader) {
            Recipe recipe = new Recipe();
            try {
                recipe.ID = Convert.ToInt32(reader["ID"]);
                recipe.Name = reader["Name"].ToString();
                recipe.Description = reader["Description"].ToString();
                recipe.Category = reader["Category"].ToString();
                recipe.Image = reader["Image"].ToString();
                return recipe;
            } catch (Exception ex) {
                return null;
            }
        }
    }
}