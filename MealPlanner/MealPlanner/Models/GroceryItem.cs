using MealPlanner.data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class GroceryItem
    {
        public int UserID { get; set; }
        public string IngredientName { get; set; }

        public static GroceryItem Parse(SqlDataReader reader) {
            GroceryItem item = new GroceryItem();
            try {
                item.UserID = Convert.ToInt32(reader["UserID"]);
                item.IngredientName = reader["IngredientName"].ToString();
                return item;
            } catch (Exception ex) {
                return null;
            }
        }
        
        public void Save() {
            if (Get(UserID,IngredientName) != null) {
                return;
            }

            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        
                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = "INSERT INTO [dbo].[GroceryItems] (UserID, IngredientName)" +
                                $" Values ({UserID},'{IngredientName}')";
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
                        
                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = "DELETE FROM [dbo].[GroceryItems] WHERE UserID = {UserID} AND IngredientName = '{IngredientName}'";
                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                } finally {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static List<GroceryItem> GetList(int userid) {
            List<GroceryItem> groceries = new List<GroceryItem>();
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM GroceryItems WHERE UserID = {userid}";

                        DBConnection.OpenConnection(conn);

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                GroceryItem item = Parse(reader);
                                if (item != null) {
                                    groceries.Add(item);
                                }
                            }
                        }

                        return groceries;
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                    return null;
                } finally {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static GroceryItem Get(int userid, string name) {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM GroceryItems WHERE UserID = {userid} AND IngredientName = '{name}'";

                        DBConnection.OpenConnection(conn);

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                GroceryItem item = Parse(reader);
                                if (item != null) {
                                    return item;
                                }
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
    }
}