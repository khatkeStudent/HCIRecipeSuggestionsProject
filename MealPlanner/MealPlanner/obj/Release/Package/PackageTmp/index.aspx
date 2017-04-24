<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MealPlanner.index" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Home</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <asp:Label runat="server" ID="txtMessages" />
    <div class="container">
		<div class="row">
			<div class="maincolumn col-md-4 leftcolumn">
				<h1>Popular Recipes</h1>
                <div runat="server" id="divPopularRecipes" />
			</div>
			<div class="maincolumn col-md-4 middlecolumn">
			    <h1>Tweets</h1>
			    <a class="twitter-timeline" href="https://twitter.com/hcimealplanner">By @hcimealplanner</a>
			</div>
			<div class="maincolumn rightcolumn col-md-4">
				<h1>About Us</h1>
				<p class="divAboutUs">
					We are Team Hufflepuff, and we hope to make this awesome website that many people can use to plan meals and make grocery lists.
				</p>
                <h1>Reviews</h1>
				<div class="subcolumn row">
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
				</div>
				<div class="subcolumn row">
                    <form runat="server">
					    <asp:Button runat="server" ID="btnSignup" OnClick="btnSignup_Click" Text="Sign Up Now!" />
                    </form>
				</div>
			</div>
		</div>
	</div>
</asp:Content>