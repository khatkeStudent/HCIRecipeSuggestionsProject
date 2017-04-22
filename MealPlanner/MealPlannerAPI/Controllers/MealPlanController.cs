using MealPlannerAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MealPlannerAPI.Controllers
{
    public class MealPlanController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<MealPlanEvent> Get(int id) {
            List<MealPlanEvent> events = new List<MealPlanEvent>();

            using (SqlConnection conn = new SqlConnection()) {
                try {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["MealPlannerConnectionString"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"SELECT * FROM MealPlan where UserID = {id}";

                        if (conn.State == System.Data.ConnectionState.Closed) {
                            conn.Open();
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                MealPlan meal = MealPlan.Parse(reader);
                                events.Add(new MealPlanEvent() {
                                    id = meal.ID,
                                    title = Recipe.Get(meal.RecipeID).Name,
                                    start = meal.PlanDate,
                                    recipeid = meal.RecipeID
                                });
                            }
                        }
                    }
                } catch (Exception ex) {
                    string error = ex.Message;
                } finally {
                    if (conn.State == System.Data.ConnectionState.Open) {
                        conn.Close();
                    }
                }
            }

            return events;
        }


        // Put api/values
        public HttpResponseMessage Put([FromBody]string value) {
            string[] values = value.Split('|');
            DateTime date = DateTime.Parse(values[1].Replace('T', ' '));
            using (SqlConnection conn = new SqlConnection()) {
                try {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["MealPlannerConnectionString"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"UPDATE MealPlan SET PlanDate = '{date.ToString("MM/dd/yyyy")}' WHERE ID = {values[0]}";

                        if (conn.State == System.Data.ConnectionState.Closed) {
                            conn.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    string error = ex.Message;
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                } finally {
                    if (conn.State == System.Data.ConnectionState.Open) {
                        conn.Close();
                    }
                }
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // POST api/values
        public void Post([FromBody]string value) {
            value = Request.Content.ReadAsStringAsync().Result;

            string[] values = value.Split('|');
            DateTime date = DateTime.Parse(values[1].Replace('T', ' '));
            using (SqlConnection conn = new SqlConnection()) {
                try {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["MealPlannerConnectionString"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"UPDATE MealPlan SET PlanDate = '{date.ToString("MM/dd/yyyy")}' WHERE ID = {values[0]}";

                        if (conn.State == System.Data.ConnectionState.Closed) {
                            conn.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    string error = ex.Message;
                } finally {
                    if (conn.State == System.Data.ConnectionState.Open) {
                        conn.Close();
                    }
                }
            }
        }

        // DELETE api/values/5
        public void Delete(int id) {
            using (SqlConnection conn = new SqlConnection()) {
                try {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["MealPlannerConnectionString"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand()) {
                        cmd.Connection = conn;
                        cmd.CommandText = $"DELETE FROM MealPlan where ID = {id}";

                        if (conn.State == System.Data.ConnectionState.Closed) {
                            conn.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) {
                    string error = ex.Message;
                } finally {
                    if (conn.State == System.Data.ConnectionState.Open) {
                        conn.Close();
                    }
                }
            }
        }
    }
}