<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MealPlanner.login" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Login</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/login.css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <asp:Label ID="txtError" runat="server" CssClass="alert alert-danger text-center"></asp:Label>
    <form runat="server" method="get" action="login.aspx">
	    <fieldset>
		    <legend>Login</legend>
            <div class="form-group">
		        <label for="txtUsername">Email Address</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
		        <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="form-group">
		        <asp:Button runat="server" id="btnLogin" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </fieldset>
    </form>
    <div>
        New user? <a href="register.aspx">Sign up</a>
    </div>
</asp:Content>