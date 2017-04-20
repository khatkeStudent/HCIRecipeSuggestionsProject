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
            if (!IsPostBack) {
                if (!loadRecipeFromUrl()) {
                    return;
                }
            } else {
                if (Session["recipe"] == null) {
                    if (!loadRecipeFromUrl()) {
                        return;
                    }
                }
            }

            txtTitle.Text = mRecipe.Name;
            imgRecipe.Src = mRecipe.Image;
            divIngredients.InnerHtml = formatIngredients();
            divInstructions.InnerHtml = formatInstructions();
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

        private bool loadRecipeFromUrl() {
            try {
                int recipeid = 0;
                string tempint = Request.QueryString.Get("id");
                if (int.TryParse(tempint, out recipeid)) {
                    mRecipe = Recipe.Get(recipeid);

                    if (Session["recipe"] != null) {
                        Session.Remove("recipe");
                    }

                    Session.Add("recipe", mRecipe);
                }

                if (recipeid <= 0) {
                    displayError();
                    return false;
                }
            } catch (Exception ex) {
                displayError();
                return false;
            }

            return true;
        }

        private void displayError() {
            txtError.Text = "Unable to find the recipe you were looking for. We suggest searching the <a href='recipes.aspx'>recipes page</a> for the recipe you were looking for.";
            txtTitle.Text = "Error";
            divError.Visible = true;
            divInstructionContainer.Visible = false;
            divRecipe.Visible = false;
        }
        #endregion

        protected void btnAddToPlan_Click(object sender, EventArgs e) {

        }

        protected void btnShare_Click(object sender, EventArgs e) {

        }

        protected void btnAddGroceries_Click(object sender, EventArgs e) {

        }
    }
}