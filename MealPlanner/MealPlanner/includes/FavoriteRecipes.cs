using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.includes
{
    public class FavoriteRecipes
    {
        public static string GetRecipes() {
            return "< div class='divFavoriteRecipes'>" +
                        "<h2>Favorite Recipes</h2>" +
                        "<div>" +
                        "Chicken Pot Pie" +
                        "</div>" +
                        "< div>" +
                        "Chicken Pot Pie" +
                        "</div>" +
                        "< div>" +
                        "Chicken Pot Pie" +
                        "</div>" +
                        "< div>" +
                        "Chicken Pot Pie" +
                        "</div>" +
                        "< div>" +
                        "Chicken Pot Pie" +
                        "</div>" +
                        "</div>";
        }
    }
}