<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recipe.aspx.cs" Inherits="MealPlanner.recipe" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle"><asp:Literal runat="server" ID="txtTitle" /></asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/recipe.css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <form runat="server">
    <div class="bodyrow">
        <div runat="server" id="divError">
            <asp:Label ID="txtError" runat="server" />
        </div>
        <div runat="server" id="divRecipe">
		    <h1 runat="server" id="txtRecipeName" />
		    <div class="recipe">
			    <img runat="server" id="imgRecipe" class="recipe-img" />
                <div class="divIngredientSection">
                    <h2>Ingredients</h2>
			        <div runat="server" id="divIngredients" class="recipe-body" />
			    </div>
			    <div class="recipe-actions">
				    <asp:Button runat="server" ID="btnAddToPlan" class="btn btn-success" OnClick="btnAddToPlan_Click" Text="+ Add"  />
				    <asp:Button runat="server" ID="btnShare" class="btn btn-info" OnClick="btnShare_Click" Text="Share" />
				    <asp:Button runat="server" ID="btnAddGroceries" class="btn btn-warning" OnClick="btnAddGroceries_Click" Text="Add Groceries" />
			    </div>
		    </div>
	    </div>
    </div>
	<div runat="server" id="divInstructionContainer" class="bodyrow">
        <h2>Instructions</h2>
		<div runat="server" id="divInstructions" class="recipe-Instructions" />
	</div>
    </form>
</asp:Content>