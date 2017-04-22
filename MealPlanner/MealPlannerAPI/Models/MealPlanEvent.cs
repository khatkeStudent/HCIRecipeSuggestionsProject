using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlannerAPI.Models
{
    public class MealPlanEvent
    {
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public int recipeid { get; set; }
        public string allDay { get { return "true"; } }
    }
}