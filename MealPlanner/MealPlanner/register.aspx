<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="MealPlanner.register" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Register</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
    <link rel="stylesheet" type="text/css" href="css/register.css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <div runat="server" ID="txtError" class="container" />
    <div class="container">
    <form runat="server" id="frmCreateAccount" action="register.aspx" class=" formcontainer col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
	    <fieldset>
		    <legend>Create User</legend>
            <div class="text-center"><i>All fields are required.</i></div>
            <div class="form-group">
                <label for="txtFirstName">First Name</label>
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtLastName">Last Name</label>
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" TextMode="Email" AutoCompleteType="Email"  />
            </div>
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="form-group">
                <label for="txtConfirmPassword">Confirm Password</label>
                <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnCreateUser" CssClass="btn btn-primary" 
                    Text="Create Account" OnClick="btnCreateUser_Click" />
            </div>
        </fieldset>
    </form>
    </div>
    <div class="container">
        <p class="text-center">
            By creating an account, you agree to the Terms of Service for this website.
        </p>
    </div>
</asp:Content>