using MealPlanner.data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class MealPlan
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RecipeID { get; set; }
        public string PlanDate { get; set; }

        public void Save()
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        // Check if mealplan exists
                        MealPlan mealplan = MealPlan.Get(ID);

                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = (mealplan == null
                                ?// Create new mealplan
                                "INSERT INTO [dbo].[MealPlan] (UserID, RecipeID, PlanDate) " +
                                $" Values ({UserID}, {RecipeID},'{PlanDate}')"
                                : // Update existing mealplan
                                $"UPDATE [dbo].[MealPlan] SET UserID = {UserID}, " +
                                $"RecipeID = {RecipeID}, PlanDate = '{PlanDate}' " + 
                                $"WHERE ID = {ID}");

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

                        // If mealplan doesn't exist, nothing to delete.
                        if (MealPlan.Get(ID) == null)
                        {
                            return;
                        }

                        // Delete mealplan if they exist;
                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = $"DELETE FROM [dbo].[MealPlan] WHERE ID = {ID}";
                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                } finally {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static MealPlan Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM [dbo].[MealPlan] WHERE ID = {id}";

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

        public static MealPlan Get(int userid, int recipeid, string date) {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM [dbo].[MealPlan] WHERE UserID = {userid} AND " +
                            $"RecipeID = {recipeid} AND PlanDate = '{date}'";

                        DBConnection.OpenConnection(conn);

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                return Parse(reader);
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

        public static MealPlan Parse(SqlDataReader reader)
        {
            MealPlan mealplan = new MealPlan();
            try
            {
                mealplan.ID = Convert.ToInt32(reader["ID"]);
                mealplan.UserID = Convert.ToInt32(reader["UserID"]);
                mealplan.RecipeID = Convert.ToInt32(reader["RecipeID"]);
                mealplan.PlanDate = reader["PlanDate"].ToString();
                return mealplan;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}