using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class register : System.Web.UI.Page
    {
        private string mError = string.Empty;
        private Models.User mUser; 

        protected void Page_Load(object sender, EventArgs e) {
            mUser = new Models.User();
        }

        protected void btnCreateUser_Click(object sender, EventArgs e) {
            if (ValidateSubmission()) {
                mUser.Save();

                if (Session["message"] != null) {
                    Session.Remove("message");
                }

                Session.Add("message", $"Welcome {mUser.FirstName} {mUser.LastName}");

                String email = txtEmailAddress.Text;
                String password = txtPassword.Text;

                var user = Models.User.Get(email, password);

                if (Session["user"] != null) {
                    Session.Remove("user");
                }
                Session.Add("user", user);
                Response.Redirect("index.aspx");
            } else {
                txtError.InnerHtml = mError;
            }
        }

        private bool ValidateSubmission() {
            mError = string.Empty;

            if (string.IsNullOrEmpty(txtConfirmPassword.Text)) {
                txtConfirmPassword.Focus();
                mError = $"You must confirm the password.<br />{mError}";
            }
            
            if (string.IsNullOrEmpty(txtPassword.Text)) {
                txtPassword.Focus();
                mError = $"Please enter a password.<br />{mError}";
            }

            if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text)) {
                if (!txtPassword.Text.Equals(txtConfirmPassword.Text)) {
                    mError = $"Passwords do not match.<br />{mError}";
                } else {
                    mUser.Password = txtPassword.Text.Trim();
                }
            }

            if (string.IsNullOrEmpty(txtEmailAddress.Text)) {
                txtEmailAddress.Focus();
                mError = $"Please enter your email address.<br />{mError}";
            } else {
                mUser.Email = txtEmailAddress.Text.Trim();
            }

            if (string.IsNullOrEmpty(txtLastName.Text)) {
                txtLastName.Focus();
                mError = $"Please enter your last name.<br />{mError}";
            } else {
                mUser.LastName = txtLastName.Text.Trim();
            }

            if (string.IsNullOrEmpty(txtFirstName.Text)) {
                txtFirstName.Focus();
                mError = $"Please enter your first name.<br />{mError}";
            } else {
                mUser.FirstName = txtFirstName.Text.Trim();
            }


            if (string.IsNullOrEmpty(mError) &&
                Models.User.Get(txtEmailAddress.Text) != null) {
                mError = $"An account already exists for {mUser.Email}";
            }

            return string.IsNullOrEmpty(mError);
        }
    }
}