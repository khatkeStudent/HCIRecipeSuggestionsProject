<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mealplanner.aspx.cs" Inherits="MealPlanner.mealplanner" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Meal Planner</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/meal_planner.css" />
	<script src="js/meal_planner.js"></script>
    <script>
        function pageloaded() {

        }
    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <div class="row bodyrow">
		<div class="col-sm-12 col-md-6 plannersection">
			<div runat="server" id="divWeekView" />
		</div>
		<div class="col-sm-12 col-md-6 plannersection">
			<div runat="server" id="divFavoriteRecipes" />
		</div>
	</div>
	<div class="row bodyrow">
		<div class="col-sm-12 col-md-6 planneresection">
			<div runat="server" id="divFriendsActivities" />
		</div>
		<div class="col-sm-12 col-md-6 plannersection">
			<div runat="server" id="divSuggestions" />
		</div>
	</div>
</asp:Content>