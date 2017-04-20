using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) {
                divLoggedIn.Visible = false;
            } else {
                divNotLoggedIn.Visible = false;
                Models.User user = (Models.User)Session["user"];
                txtUserName.Text = $"{user.FirstName} {user.LastName}";
            }
        }
    }
}