<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recipes.aspx.cs" Inherits="MealPlanner.recipes" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle"><asp:Literal runat="server" ID="txtTitle" /></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/recipes.css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <form runat="server">
        <asp:ListView runat="server">
            
        </asp:ListView>
    </form>
</asp:Content>