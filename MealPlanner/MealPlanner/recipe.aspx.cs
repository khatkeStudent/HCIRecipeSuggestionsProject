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
        private User mUser;
        private bool mIsFavorite = false;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (!loadRecipeFromUrl()) {
                    return;
                }
                datepicker.Value = DateTime.Now.ToString("MM/dd/yyyy");
            } else {
                if (Session["recipe"] == null) {
                    if (!loadRecipeFromUrl()) {
                        return;
                    }
                } else {
                    mRecipe = (Recipe)Session["recipe"];
                }
            }

            if (Session["alert"] == null) {
                lblAlert.Visible = false;
            } else {
                lblAlert.Visible = true;
                lblAlert.Text = Session["alert"].ToString();
                Session.Remove("alert");
            }

            if (Session["error"] == null) {
                lblError.Visible = false;
            } else {
                lblError.Visible = true;
                lblError.Text = Session["error"].ToString();
                Session.Remove("error");
            }

            if (Session["user"] == null) {
                btnAddGroceries.Visible = false;
                btnAddToPlan.Visible = false;
                btnAddToFavorites.Visible = false;
                divDatePicker.Visible = false;
            } else {
                mUser = (User)Session["user"];
                mIsFavorite = Recipe.CheckFavorite(mUser.ID, mRecipe.ID);
            }

            txtTitle.Text = mRecipe.Name;
            imgRecipe.Src = mRecipe.Image;

            if (mIsFavorite) {
                setFavorite();
            }

            divIngredients.InnerHtml = formatIngredients();
            divInstructions.InnerHtml = formatInstructions();
            txtRecipeName.InnerText = mRecipe.Name;
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
                    if (step.EndsWith(".")) {
                        retval += $"<li>{step}";
                    } else {
                        retval += $"<li>{step}.";
                    }
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
            lblError.Text = "Unable to find the recipe you were looking for. We suggest searching the <a href='recipes.aspx'>recipes page</a> for the recipe you were looking for.";
            txtTitle.Text = "Error";
            divError.Visible = true;
            divInstructionContainer.Visible = false;
            divRecipe.Visible = false;
        }

        private void setFavorite() {
            if (mIsFavorite) {
                btnAddToFavorites.CssClass = "btn btn-success btn-action";
                btnAddToFavorites.Text = "✔ Favorite";
            } else {
                btnAddToFavorites.CssClass = "btn btn-primary";
                btnAddToFavorites.Text = "Add To Favorites";
            }
        }
        #endregion

        protected void btnAddToPlan_Click(object sender, EventArgs e) {
            DateTime date = DateTime.Now;
            try {
                date = DateTime.Parse(datepicker.Value);
            } catch (Exception ex) {
                if (Session["error"] != null) {
                    Session.Remove("error");
                }

                Session.Add("error", "Invalid Date.");
                return;
            }

            MealPlan meal = new MealPlan();
            meal.UserID = mUser.ID;
            meal.PlanDate = date.ToString("MM/dd/yyyy");
            meal.RecipeID = mRecipe.ID;
            meal.Save();

            lblAlert.Visible = true;
            lblAlert.Text = $"Recipe added successfully for {date.ToString("MM/dd/yyyy")}";
        }

        protected void btnAddToFavorites_Click(object sender, EventArgs e) {
            if (mIsFavorite) {
                mIsFavorite = !mIsFavorite;
                mRecipe.DeleteFavorite(mUser.ID);
                setFavorite();
            } else {
                mIsFavorite = !mIsFavorite;
                mRecipe.SaveFavorite(mUser.ID);
                setFavorite();
            }
        }

        protected void btnAddGroceries_Click(object sender, EventArgs e) {
            foreach (Ingredient ingredient in Ingredient.Get(mRecipe.ID)) {
                GroceryItem item = new GroceryItem();
                item.UserID = mUser.ID;
                item.IngredientName = ingredient.Name;
                item.Save();
            }

            lblAlert.Visible = true;
            lblAlert.Text = $"Groceries have been added to your list.";
        }
    }
}