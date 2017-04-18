using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.includes
{
    public static class PopularRecipes
    {
        public static string GetRecipes() {
            string retval = string.Empty;
            LinkedList<Recipe> recipes = Recipe.GetRandom();

            foreach (Recipe recipe in recipes) {
                retval += $"<div class='row'><a href='recipe.aspx?id={recipe.ID}'><div class='divPopRecipe'>" +
                    $"<img class='imgRecipe' src='{recipe.Image}' /><p>{recipe.Name}</p></div></a></div>";
            }

            return retval;
        }
    }
}