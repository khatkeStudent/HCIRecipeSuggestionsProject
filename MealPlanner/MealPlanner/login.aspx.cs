using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["prevurl"] == null) {
                Session.Add("prevurl", "index.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            String email =  txtUsername.Text;
            String password = txtPassword.Text;

            var user = Models.User.Get(email, password);

            if (user == null) {
                txtError.Text = "Invalid email address or password.";
                txtError.Visible = true;
            } else {
                if (Session["user"] != null) {
                    Session.Remove("user");
                }
                Session.Add("user", user);

                string nexturl = Session["prevurl"].ToString();
                Session.Remove("prevurl");

                Response.Redirect(nexturl);
            }
        }
    }
}