<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recipes.aspx.cs" Inherits="MealPlanner.recipes" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle"><asp:Literal runat="server" ID="txtTitle" /></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
    <link rel="stylesheet" href="css/recipes.css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <form runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-11 col-md-offset-1">
        <asp:ListView runat="server" DataSourceID="THMsql">
            <LayoutTemplate>
                <table runat="server" id="Table1">
                  <tr runat="server" id="itemPlaceholder"></tr>
                </table>
                <asp:DataPager runat="server" ID="DataPager" PageSize="5">
                    <Fields>
                      <asp:NumericPagerField ButtonCount="10"
                           PreviousPageText="<--"
                           NextPageText="-->" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td runat="server" class="listItemCell">
                        <asp:HyperLink runat="server" NavigateUrl='<%#"~/recipe.aspx?id=" + Eval("ID") %>'>
                            <asp:Image runat="server" CssClass="imgRecipeListItem" ImageUrl='<%#Eval("Image") %>' />
                        </asp:HyperLink>
                    </td>
                    <td runat="server" class="listItemCell" style="vertical-align:top;padding-top:.5em">
                        <div class="container">
                            <asp:Literal runat="server" Text='<%#Eval("Name") %>' />
                        </div>
                        <div class="container">
                            <asp:Literal runat="server" Text='<%#Eval("Description") %>' />
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
                </div>
            </div>
        </div>
        <asp:SqlDataSource ID="THMsql" runat="server" ConnectionString="<%$ ConnectionStrings:MealPlannerConnectionString %>" SelectCommand="SELECT * FROM [Recipes] ORDER BY [Name]"></asp:SqlDataSource>
    </form>
</asp:Content>