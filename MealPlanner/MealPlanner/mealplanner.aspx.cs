using MealPlanner.includes;
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
        protected void Page_Load(object sender, EventArgs e) {
            divFavoriteRecipes.InnerHtml = FavoriteRecipes.GetRecipes();
            divFriendsActivities.InnerHtml = FriendsActivities.GetFriendsActivities();
            //divSuggestions.InnerHtml = 
        }
    }
}