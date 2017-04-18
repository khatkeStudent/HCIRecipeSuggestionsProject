<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MealPlanner.login" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Login</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/login.css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <form method="get" action="login.aspx">
	    <fieldset>
		    <legend>Login</legend>
		    <h3>Username</h3>
		    <input runat="server" id="txtUsername" name="txtUsername" type="Text" />
		    <h3>Password</h3>
		    <input runat="server" id="txtPassword" name="txtPassword" type="Password" />
		    <input class="btnLogin" name="btnSubmit" type="submit" value="Login" />
	    </fieldset>
    </form>
    <div>
        New user? <a href="createaccount.aspx">create account</a>
    </div>
</asp:Content>