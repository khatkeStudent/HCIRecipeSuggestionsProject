﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class calendarpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] == null) {
                Response.Redirect("login.aspx");
            }

            Models.User user = (Models.User)Session["user"];
            hiddenUserID.Value = user.ID.ToString();
        }
    }
}