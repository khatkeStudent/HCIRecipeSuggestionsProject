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
    public class GroceryController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get() {
            //return new string[] { "value1", "value2" };
        //}
        
        // POST api/<controller>
        //public void Post([FromBody]string value) {
        //}

        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody]string value) {
            string[] inputs = value.Split('|');
            int userid = Convert.ToInt32(inputs[0]);
            string ingredient = inputs[1];
            string command = inputs[2];

            switch (command) {
                case "add":
                    using (SqlConnection conn = new SqlConnection()) {
                        try {
                            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MealPlannerConnectionString"].ConnectionString;
                            using (SqlCommand cmd = new SqlCommand()) {
                                cmd.Connection = conn;
                                cmd.CommandText = $"INSERT INTO GroceryItems (UserID, IngredientName) " +
                                    $"VALUES ({userid}, '{ingredient}')";

                                if (conn.State == System.Data.ConnectionState.Closed) {
                                    conn.Open();
                                }

                                cmd.ExecuteNonQuery();
                                return new HttpResponseMessage(HttpStatusCode.OK);
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
                case "delete":
                    using (SqlConnection conn = new SqlConnection()) {
                        try {
                            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MealPlannerConnectionString"].ConnectionString;
                            using (SqlCommand cmd = new SqlCommand()) {
                                cmd.Connection = conn;
                                cmd.CommandText = $"DELETE FROM GroceryItems " +
                                    $"WHERE UserID = {userid} AND IngredientName = '{ingredient}'";

                                if (conn.State == System.Data.ConnectionState.Closed) {
                                    conn.Open();
                                }

                                cmd.ExecuteNonQuery();
                                return new HttpResponseMessage(HttpStatusCode.OK);
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
                default:
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}