using MealPlanner.includes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            divPopularRecipes.InnerHtml = PopularRecipes.GetRecipes(5);

            if (Session["message"] != null) {
                txtMessages.Text = Session["message"].ToString();
                txtMessages.Visible = true;
                Session.Remove("message");
            } else {
                txtMessages.Visible = false;
            }

            if (Session["user"] != null) {
                btnSignup.Visible = false;
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e) {
            Response.Redirect("register.aspx");
        }
    }
}