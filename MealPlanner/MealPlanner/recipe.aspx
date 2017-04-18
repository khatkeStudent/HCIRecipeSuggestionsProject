<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recipe.aspx.cs" Inherits="MealPlanner.recipe" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle"><asp:Literal runat="server" ID="txtTitle" /></asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/recipe.css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <div class="bodyrow">
		<h1 runat="server" id="txtRecipeName" />
		<div class="recipe">
			<img runat="server" id="imgRecipe" class="recipe-img" />
            <div class="divIngredientSection">
                <h2>Ingredients</h2>
			    <div runat="server" id="divIngredients" class="recipe-body" />
			</div>
			<div class="recipe-actions">
                <form runat="server">
				    <asp:Button runat="server" ID="btnAddToPlan" class="btn btn-success" OnClick="btnAddToPlan_Click" Text="+ Add"  />
				    <asp:Button runat="server" ID="Button1" class="btn btn-info" OnClick="btnAddToPlan_Click" Text="Share" />
				    <asp:Button runat="server" ID="Button2" class="btn btn-warning" OnClick="btnAddToPlan_Click" Text="Add Groceries" />
                </form>
			</div>
		</div>
	</div>
	<div class="bodyrow">
        <h2>Instructions</h2>
		<div runat="server" id="divInstructions" class="recipe-Instructions" />
	</div>
</asp:Content>