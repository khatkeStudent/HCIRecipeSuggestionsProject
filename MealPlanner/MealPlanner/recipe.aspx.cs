using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class recipe : System.Web.UI.Page
    {
        private Recipe mRecipe;
        protected void Page_Load(object sender, EventArgs e) {
            try {
                int recipeid = 0;
                string tempint = Request.QueryString.Get("id");
                if (int.TryParse(tempint, out recipeid)) {
                    mRecipe = Recipe.Get(recipeid);
                }

                if (recipeid <= 0) {
                    displayError();
                    return;
                }
            } catch (Exception ex) {
                displayError();
                return;
            }

            txtTitle.Text = mRecipe.Name;
            imgRecipe.Src = mRecipe.Image;
            divIngredients.InnerHtml = formatIngredients();
            divInstructions.InnerHtml = formatInstructions();
        }

        protected void btnAddToPlan_Click(object sender, EventArgs e) {

        }

        #region Helper Methods
        private string formatIngredients() {
            string retval = "<ul>";
            LinkedList<Ingredient> ingredients = Ingredient.Get(mRecipe.ID);
            
            foreach (Ingredient ingredient in ingredients) {
                retval += $"<li>{ingredient.MeasureAmount} {ingredient.Name}";
            }
            retval += "</ul>";
            return retval;
        }

        private string formatInstructions() {
            string retval = "<ol>";
            LinkedList<Instruction> Instructions = Instruction.Get(mRecipe.ID);

            foreach (Instruction instruction in Instructions) {
                string[] steps = instruction.Direction.Replace("\r\n", "|").Split('|');

                foreach (string step in steps) {
                    retval += $"<li>{step}.";
                }
            }

            retval += "</ol>";
            return retval;
        }

        private void displayError() {

        }
        #endregion
    }
}