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

        protected void Page_Load(object sender, EventArgs e)
        {
            UserCreateTest();
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

            if (saveduser.Email.Equals(user.Email)) {
                mResult += $"<div><div class='testname'>UserCreateTest</div><div class='testresult successful'>Success</div></div>";
                mSuccess++;
                user.Delete();
            } else {
                mResult += $"<div><div class='testname'>UserCreateTest</div><div class='testresult failure'>Failed</div></div>";
                mFailure++;
            }
        }

        private void printResults()
        {
            divStats.InnerHtml = $"<div class='stats'>Total: {mFailure + mSuccess} Passed: {mSuccess} Failed: {mFailure}</div>";
            divResults.InnerHtml = mResult;
        }
    }
}