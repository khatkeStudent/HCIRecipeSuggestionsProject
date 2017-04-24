<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MealPlanner.login" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Login</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/login.css" />
    <script>
        function pageloaded() {

        }
    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <div class="divError">
        <asp:Label ID="txtError" Visible="false" runat="server" 
            CssClass="alert alert-danger"></asp:Label>
    </div>
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
            <div class="form-group divLoginButton">
		        <asp:Button runat="server"  ID="btnLogin" CssClass="btn btn-primary btnlogin" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <div class="form-group divRegister">
                New user? <a href="register.aspx">Sign up</a>
            </div>
        </fieldset>
    </form>
</asp:Content>