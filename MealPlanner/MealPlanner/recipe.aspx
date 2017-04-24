<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recipe.aspx.cs" Inherits="MealPlanner.recipe" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle"><asp:Literal runat="server" ID="txtTitle" /></asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/recipe.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
    <script>
        function pageloaded() {
            $("#cpBody_datepicker").value = "04/20/2017";
        }

        $(function() {
            $("#cpBody_datepicker").datepicker();
        } );
      </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <div class="row">
    <div class="col-sm-12 col-md-10 col-md-offset-1">
        <div runat="server" id="divError">
            <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger" />
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
                    <form runat="server">
                    <asp:Label runat="server" ID="lblAlert" CssClass="alert alert-success" />
                    <p runat="server" id="divDatePicker">Date: <input runat="server" type="text" id="datepicker" /></p>
                    <asp:Button runat="server" ID="btnAddToPlan" CssClass="btn btn-primary" Text="+ Add" OnClick="btnAddToPlan_Click" />
                    <asp:Button runat="server" ID="btnAddToFavorites" class="btn btn-primary" OnClick="btnAddToFavorites_Click" Text="Add To Favorites" />
				    <asp:Button runat="server" ID="btnAddGroceries" class="btn btn-primary" OnClick="btnAddGroceries_Click" Text="Add Groceries" />
                    </form>
			    </div>
		    </div>
	    </div>
     </div>
    </div>
    <div class="row">
    <div class="col-sm-12 col-md-10 col-md-offset-1">
	<div runat="server" id="divInstructionContainer" class="bodyrow">
        <h2>Instructions</h2>
		<div runat="server" id="divInstructions" class="recipe-Instructions" />
	</div>
     </div>
    </div>
</asp:Content>