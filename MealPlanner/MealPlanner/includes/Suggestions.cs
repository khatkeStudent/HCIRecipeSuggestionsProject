using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.includes
{
    public class Suggestions
    {
        public static string GetSuggestions() {
            string retval = string.Empty;
            int count = 0;
            LinkedList<Recipe> recipes = new LinkedList<Recipe>();

            while (count < 3) {
                Random random = new Random();

                printImage("images/clamchowder.jpg");
            }
            return "<div class='divSuggestions'>" +
                         "<h2>Suggestions</h2>" +
                     "</div>";
        }

        private static string printImage(string image) {
            return "<div class='divRecipeSummary'>" +
                        "<div class='divRecipeSumImg'>" +
                        $"<img src='{image}' />" +
                        "</div>";
        }

        private static string printTitle(int id, string name) {
            return "<div>" +
                        "<div class='divRecipeSumName'>" +
                            $"<a href='recipe.php?id={id}'>{name}</a>" +
                        "</div>";
        }

        private static string printSummary(string description) {
            return $"<div class='divRecipeSumDesc'>{description}</div></div></div>";
        }
    }
}