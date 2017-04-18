using MealPlanner.data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class Ingredient
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string MeasureAmount { get; set; }
        //public string MeasureType { get; set; }
        
        public void Save()
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        // Check if user exists
                        Ingredient user = Ingredient.Get(RecipeID, Name);

                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = (user == null
                                ?// Create new user
                                "INSERT INTO [dbo].[Ingredients] (RecipeID, Name, MeasureAmount) " + //, MeasureType) " +
                                $" Values ('{RecipeID}','{Name}','{MeasureAmount}')"//,'{MeasureType}')"
                                : // Update existing user
                                $"UPDATE [dbo].[Ingredients] SET MeasureAmount = '{MeasureAmount}' " +
                                //$", MeasureType = '{MeasureType}' " +
                                $"WHERE RecipeID = {RecipeID} AND Name = '{Name}");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    String e = ex.Message;
                }
                finally
                {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public void Delete()
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        // If ingredient doesn't exist, nothing to delete.
                        if(Get(RecipeID, Name) == null) {
                            return;
                        }

                        // Delete ingredient if they exist;
                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = "DELETE FROM [dbo].[Ingredients] " +
                            $"WHERE RecipeID = {RecipeID} AND Name = '{Name}'";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    String e = ex.Message;
                }
                finally
                {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static Ingredient Get(int id, string name)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM [dbo].[Ingredients] WHERE RecipeID = {id} AND Name = '{name}'";

                        DBConnection.OpenConnection(conn);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return Parse(reader);
                            }
                        }

                        return null;
                    }
                }
                catch (Exception ex)
                {
                    String e = ex.Message;
                    return null;
                }
                finally
                {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static LinkedList<Ingredient> Get(int recipeid) {
            LinkedList<Ingredient> retval = new LinkedList<Ingredient>();
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM [dbo].[Ingredients] WHERE RecipeID = {recipeid}";

                        DBConnection.OpenConnection(conn);

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                retval.AddLast(Parse(reader));
                            }
                        }

                        return retval;
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                    return null;
                } finally {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static Ingredient Parse(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();
            try
            {
                ingredient.RecipeID = Convert.ToInt32(reader["RecipeID"]);
                ingredient.Name = reader["Name"].ToString();
                ingredient.MeasureAmount = reader["MeasureAmount"].ToString();
                //ingredient.MeasureType = reader["MeasureType"].ToString();
                return ingredient;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}