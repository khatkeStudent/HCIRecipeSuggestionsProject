using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MealPlanner
{
    public partial class TestSuite : System.Web.UI.Page
    {
        private string mResult = string.Empty;
        private int mSuccess = 0;
        private int mFailure = 0;

        protected void Page_Load(object sender, EventArgs e) {
            UserCreateTest();
            RecipeCreateTest();
            IngredientCreateTest();
            InstructionCreateTest();
            MealPlanCreateTest();
            printResults();
        }

        private void UserCreateTest()
        {
            User user = new User();
            user.FirstName = "Kenny";
            user.LastName = "Hatke";
            user.Email = "kennethhatke@u.boisestate.edu";
            user.Password = "HciRocks";

            user.Save();

            User saveduser = Models.User.Get(user.Email);
            if (saveduser == null) {
                testFailed("UserCreateTest");
                return;
            } else if (saveduser.Email.Equals(user.Email)) {
                testPassed("UserCreateTest");
            } else {
                testFailed("UserCreateTest");
            }

            saveduser.Delete();
        }

        private void RecipeCreateTest() {
            Recipe recipe = new Recipe();
            recipe.Name = "New Recipe";
            recipe.Description = "Testing Recipes";
            recipe.Category = "Testing Notes";
            recipe.Save();

            Recipe savedrecipe = Recipe.Get(recipe.Name);
            if (savedrecipe == null) {
                testFailed("RecipeCreateTest");
                return;
            } else if (savedrecipe.Name.Equals(recipe.Name) &&
                savedrecipe.Description.Equals(recipe.Description) &&
                savedrecipe.Category.Equals(recipe.Category)) {
                testPassed("RecipeCreateTest");
            } else {
                testFailed("RecipeCreateTest");
            }

            savedrecipe.Delete();
        }

        private void IngredientCreateTest() {
            Ingredient ingredient = new Ingredient();
            ingredient.RecipeID = -1;
            ingredient.Name = "eggs";
            ingredient.MeasureAmount = "2";
            //ingredient.MeasureType = "each";
            ingredient.Save();

            Ingredient savedingredient = Ingredient.Get(-1, ingredient.Name);
            if (savedingredient == null) {
                testFailed("IngredientCreateTest");
                return;
            } else if (savedingredient.Name.Equals(ingredient.Name) &&
                    savedingredient.MeasureAmount.Equals(ingredient.MeasureAmount) //&&
                    //savedingredient.MeasureType.Equals(ingredient.MeasureType)
                    ) {
                testPassed("IngredientCreateTest");
            } else {
                testFailed("IngredientCreateTest");
            }

            ingredient.Delete();
        }

        private void InstructionCreateTest() {
            Instruction instruction = new Instruction();
            instruction.RecipeID = -1;
            instruction.Sequence = -1;
            instruction.Direction = "Test Direction";
            instruction.Save();

            Instruction savedinstruction = Instruction.Get(-1, -1);
            if (savedinstruction == null) {
                testFailed("InstructionCreateTest");
                return;
            } else if (savedinstruction.RecipeID.Equals(instruction.RecipeID) &&
                    savedinstruction.Sequence.Equals(instruction.Sequence) &&
                    savedinstruction.Direction.Equals(instruction.Direction)) {
                testPassed("InstructionCreateTest");
            } else {
                testFailed("InstructionCreateTest");
            }

            instruction.Delete();
        }

        private void MealPlanCreateTest() {
            MealPlan meal = new MealPlan();
            meal.UserID = -1;
            meal.RecipeID = -1;
            meal.PlanDate = "01/01/2016";
            meal.Save();

            MealPlan savedmeal = MealPlan.Get(-1, -1, meal.PlanDate);
            if (savedmeal == null) {
                testFailed("MealPlanCreateTest");
                return;
            } else if (savedmeal.UserID.Equals(meal.UserID) &&
                    savedmeal.RecipeID.Equals(meal.RecipeID) &&
                    savedmeal.PlanDate.Equals(meal.PlanDate)) {
                testPassed("MealPlanCreateTest");
            } else {
                testFailed("MealPlanCreateTest");
            }

            savedmeal.Delete();
        }

        private void testPassed(string testname) {
            mResult += $"<div><div class='testname'>{testname}</div><div class='testresult successful'>Success</div></div>";
            mSuccess++;
        }

        private void testFailed(string testname) {
            mResult += $"<div><div class='testname'>{testname}</div><div class='testresult failure'>Failed</div></div>";
            mFailure++;
        }

        private void printResults()
        {
            divStats.InnerHtml = $"<div class='stats'>Total: {mFailure + mSuccess} Passed: {mSuccess} Failed: {mFailure}</div>";
            divResults.InnerHtml = mResult;
        }
    }
}