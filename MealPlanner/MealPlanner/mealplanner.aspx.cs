using MealPlanner.includes;
using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class mealplanner : System.Web.UI.Page
    {
        private string[] mSuggestions = { "Protein", "Calcium", "Iron", "Fun!" };
        private const string GROCERYITEM = "<li class='ui-widget-content groceryli'>{1}<input type='button' class='btn btn-danger deletegrocery' removeaction='{0}|{1}' value='X' />";
        private User mUser;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] == null) {
                Session["prevurl"] = "mealplanner.aspx";
                Response.Redirect("login.aspx");
            } else {
                mUser = (Models.User)Session["user"];
            }

            if (!IsPostBack) {
                if (Session["userid"] != null) {
                    Session.Remove("userid");
                }

                Session.Add("userid", mUser.ID);
                hiddenUserID.Value = mUser.ID.ToString();
                List<Recipe> recipes = Recipe.GetFavorites(mUser.ID);

                lblSuggestion.Text = mSuggestions[(new Random()).Next(0, 3)];
            }

            populateGroceries();
        }

        private void populateGroceries() {
            spanGroceryList.InnerHtml = "<ul id='selectable'>";

            foreach (GroceryItem item in GroceryItem.GetList(mUser.ID)) {
                spanGroceryList.InnerHtml += string.Format(GROCERYITEM, item.UserID, item.IngredientName);
            }
             /*   "<li class='ui-widget-content groceryli'>Item 2 <input type='button' class='btn btn-danger deletegrocery' removeaction='2' value='X' />" +
                "<li class='ui-widget-content groceryli'>Item 3 <input type='button' class='btn btn-danger deletegrocery' recipeid='3' value='X' />" +
                "<li class='ui-widget-content groceryli'>Item 4 <input type='button' class='btn btn-danger deletegrocery' recipeid='4' value='X' />" +
                "<li class='ui-widget-content groceryli'>Item 5 <input type='button' class='btn btn-danger deletegrocery' recipeid='5' value='X' />" +
                "<li class='ui-widget-content groceryli'>Item 6 <input type='button' class='btn btn-danger deletegrocery' recipeid='6' value='X' />" +
                "<li class='ui-widget-content groceryli'>Item 7 <input type='button' class='btn btn-danger deletegrocery' recipeid='7' value='X' />" +
                */
            
            spanGroceryList.InnerHtml += "</ul>";
        }

        protected void btnRemoveGrocery_Click(object sender, EventArgs e) {
            Button item = (Button)sender;
        }
    }
}