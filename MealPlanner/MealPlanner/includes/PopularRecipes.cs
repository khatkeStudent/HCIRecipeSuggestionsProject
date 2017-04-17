using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.includes
{
    public static class PopularRecipes
    {
        public static string GetRecipes() {
            return 
                "<div class='row'>" +
                    "<div class='divPopRecipe'>" +
                        "<img class='imgRecipe' src='images/pasty.jpg' />" +
                        "<p>Cornish Pasties</p>" +
                    "</div>" +
                "</div>" +
                "<div class='row'>" +
                    "<div class='divPopRecipe'>" +
                        "<img class='imgRecipe' src='images/asparagus.jpg' />" +
                        "<p>Roasted Asparagus</p>" +
                    "</div>" +
                "</div>" +
                "<div class='row'>" +
                    "<div class='divPopRecipe'>" +
                        "<img class='imgRecipe' src='images/seitan.jpg' />" +
                        "<p>Mushrooms and Seitan over pasta</p>" +
                    "</div>" +
                "</div>" +
                "<div class='row'>" +
                    "<div class='divPopRecipe'>" +
                        "<img class='imgRecipe' src='images/sandwich.png' />" +
                        "<p>Summer Sandwich</p>" +
                    "</div>" +
                "</div>";
        }
    }
}