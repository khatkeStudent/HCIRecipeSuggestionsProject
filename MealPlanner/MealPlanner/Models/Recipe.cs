﻿using MealPlanner.data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public void Save() {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;

                        // Check if recipe exists
                        Recipe recipe = Recipe.Get(ID);

                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = (recipe == null
                                ?// Create new recipe
                                "INSERT INTO [dbo].[Recipes] (Name, Description, Category, Image)" +
                                $" Values ('{Name}','{Description}','{Category}','{Image}')"
                                : // Update existing recipe
                                $"UPDATE [dbo].[Recipes] SET Name = '{Name}', Description = '{Description}', " +
                                $"Category = '{Category}',Image = '{Image}' " +
                                $"WHERE ID = {ID}");


                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                } finally {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public void Delete() {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;

                        // If recipe doesn't exist, nothing to delete.
                        if (Recipe.Get(ID) == null) {
                            return;
                        }

                        // Delete recipe if they exist;
                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = $"DELETE FROM [dbo].[Recipes] WHERE ID = {ID}";
                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                } finally {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static Recipe Get(int id) {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Recipes WHERE ID = {id}";

                        DBConnection.OpenConnection(conn);

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
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static Recipe Get(string name) {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Recipes WHERE Name = '{name}'";

                        DBConnection.OpenConnection(conn);

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
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static LinkedList<Recipe> GetRandom() {
            LinkedList<Recipe> recipes = new LinkedList<Recipe>();
            LinkedList<int> usednumbers = new LinkedList<int>();

            Random random = new Random();
            while (recipes.Count < 10) {
                int number = random.Next(0, 50);

                Recipe recipe = Get(number);
                if (recipe != null && !usednumbers.Contains(number)) {
                    recipes.AddLast(recipe);
                    usednumbers.AddLast(number);
                }
            }

            return recipes;
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