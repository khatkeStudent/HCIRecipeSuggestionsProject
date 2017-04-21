using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class DatabaseDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            try {
                WebRequest request = HttpWebRequest.Create("http://www.themealdb.com/api/json/v1/1/randomselection.php");
                request.Method = "GET";
                var response = request.GetResponse();

                JavaScriptSerializer oJS = new JavaScriptSerializer();
                Rootobject root = new Rootobject();
                using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    root = oJS.Deserialize<Rootobject>(reader.ReadToEnd());
                }

                foreach (Meal meal in root.meals) {
                    if (Recipe.Get(meal.strMeal) == null) {
                        // Save Recipe
                        Recipe recipe = new Recipe();
                        recipe.Name = meal.strMeal;
                        recipe.Description = $"{meal.strArea} {meal.strCategory}";
                        recipe.Category = meal.strCategory;
                        recipe.Image = meal.strMealThumb;
                        recipe.Save();

                        divResults.InnerHtml += $"Added: {recipe.Name}<br />";
                        recipe = Recipe.Get(meal.strMeal);

                        // Save instructions
                        Instruction instruction = new Instruction();
                        instruction.RecipeID = recipe.ID;
                        instruction.Sequence = 1;
                        instruction.Direction = meal.strInstructions.Replace("'", "''");
                        instruction.Save();

                        // Save ingredients
                        if (!string.IsNullOrEmpty(meal.strIngredient1)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient1.Replace("'","''");
                            ingredient.MeasureAmount = meal.strMeasure1.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient2)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient2.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure2.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient3)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient3.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure3.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient4)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient4.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure4.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient5)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient5.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure5.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient6)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient6.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure6.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient7)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient7.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure7.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient8)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient8.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure8.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient9)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient9.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure9.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient10)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient10.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure10.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient11)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient11.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure11.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient12)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient12.Replace("'", "''");
                            ingredient.MeasureAmount = meal.strMeasure12.Replace("'", "''");
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient13)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient13;
                            ingredient.MeasureAmount = meal.strMeasure13;
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient14)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient14;
                            ingredient.MeasureAmount = meal.strMeasure14;
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient15)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient15;
                            ingredient.MeasureAmount = meal.strMeasure15;
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient16)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient16;
                            ingredient.MeasureAmount = meal.strMeasure16;
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient17)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient17;
                            ingredient.MeasureAmount = meal.strMeasure17;
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient18)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient18;
                            ingredient.MeasureAmount = meal.strMeasure18;
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient19)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient19;
                            ingredient.MeasureAmount = meal.strMeasure19;
                            ingredient.Save();
                        }

                        if (!string.IsNullOrEmpty(meal.strIngredient20)) {
                            Ingredient ingredient = new Ingredient();
                            ingredient.RecipeID = recipe.ID;
                            ingredient.Name = meal.strIngredient20;
                            ingredient.MeasureAmount = meal.strMeasure20;
                            ingredient.Save();
                        }
                    }
                }
            } catch (Exception ex) {
                divResults.InnerHtml += $"Error: {ex.Message}<br />";
            }
        }
    }
}