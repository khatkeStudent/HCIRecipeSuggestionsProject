using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlannerAPI.Models
{
    public class MealPlan
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RecipeID { get; set; }
        public string PlanDate { get; set; }
        
        public static MealPlan Parse(SqlDataReader reader) {
            MealPlan mealplan = new MealPlan();
            try {
                mealplan.ID = Convert.ToInt32(reader["ID"]);
                mealplan.UserID = Convert.ToInt32(reader["UserID"]);
                mealplan.RecipeID = Convert.ToInt32(reader["RecipeID"]);
                mealplan.PlanDate = reader["PlanDate"].ToString();
                return mealplan;
            } catch (Exception ex) {
                return null;
            }
        }
    }
}