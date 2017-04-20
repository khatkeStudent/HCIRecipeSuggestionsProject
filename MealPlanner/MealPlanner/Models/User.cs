using MealPlanner.data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class User
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public void Save() {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;

                        // Check if user exists
                        User user = User.Get(ID);

                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = (user == null
                                ?// Create new user
                                "INSERT INTO [dbo].[Users] (FirstName, LastName, Email, Password)" +
                                $" Values ('{FirstName}','{LastName}','{Email}','{Password}')"
                                : // Update existing user
                                $"UPDATE [dbo].[Users] SET FirstName = '{FirstName}', LastName = '{LastName}', " +
                                $"Email = '{Email}', Password = '{Password}' " +
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

                        // If user doesn't exist, nothing to delete.
                        if (User.Get(ID) == null) {
                            return;
                        }

                        // Delete user if they exist;
                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = $"DELETE FROM [dbo].[Users] WHERE ID = {ID}";
                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    String e = ex.Message;
                } finally {
                    DBConnection.CloseConnection(conn);
                }
            }
        }

        public static User Get(int id) {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Users WHERE ID = {id}";

                        DBConnection.OpenConnection(conn);

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                return User.Parse(reader);
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

        public static User Get(string email)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Users WHERE Email = '{email}'";

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

        public static User Get(string email, string password) {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM Users WHERE Email = '{email}' and Password = '{password}'";

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

        public static User Parse(SqlDataReader reader) {
            User user = new User();
            try {
                user.ID = Convert.ToInt32(reader["ID"]);
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
                user.Email = reader["Email"].ToString();
                user.Password = reader["Password"].ToString();
                return user;
            } catch (Exception ex) {
                return null;
            }
        }
    }
}