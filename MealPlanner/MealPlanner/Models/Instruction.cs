using MealPlanner.data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlanner.Models
{
    public class Instruction
    {
        public int RecipeID { get; set; }
        public int Sequence { get; set; }
        public string Direction { get; set; }
        
        public void Save()
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;

                        // Check if instruction exists
                        Instruction instruction = Instruction.Get(RecipeID, Sequence);

                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = (instruction == null
                                ?// Create new user
                                "INSERT INTO [dbo].[Instructions] (RecipeID, Sequence, Instruction) " +
                                $" Values ({RecipeID},{Sequence},'{Direction}')"
                                : // Update existing user
                                $"UPDATE [dbo].[Instructions] SET Instruction = '{Direction}' " +
                                $"WHERE RecipeID = {RecipeID} AND Sequence = {Sequence}");

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

                        // If user doesn't exist, nothing to delete.
                        if (Instruction.Get(RecipeID, Sequence) == null)
                        {
                            return;
                        }

                        // Delete user if they exist;
                        DBConnection.OpenConnection(conn);
                        cmd.CommandText = $"DELETE FROM [dbo].[Instructions] WHERE RecipeID = {RecipeID} and Sequence = {Sequence}";
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

        public static Instruction Get(int id, int seq)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection()))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM [dbo].[Instructions] WHERE RecipeID = {id} AND Sequence = {seq}";

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
        
        public static LinkedList<Instruction> Get(int recipeid) {
            LinkedList<Instruction> retval = new LinkedList<Instruction>();
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnection())) {
                try {
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM [dbo].[Instructions] WHERE RecipeID = {recipeid} ORDER BY Sequence";

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

        public static Instruction Parse(SqlDataReader reader)
        {
            Instruction instruction = new Instruction();
            try
            {
                instruction.RecipeID = Convert.ToInt32(reader["RecipeID"]);
                instruction.Sequence = Convert.ToInt32(reader["Sequence"]);
                instruction.Direction = reader["Instruction"].ToString();
                return instruction;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}