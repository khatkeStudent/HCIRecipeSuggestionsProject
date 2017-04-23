<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mealplanner.aspx.cs" Inherits="MealPlanner.mealplanner" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Meal Planner</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
	<link rel="stylesheet" href="css/meal_planner.css" />
	<link href='css/fullcalendar.min.css' rel='stylesheet' />
	<link href='css/fullcalendar.print.min.css' rel='stylesheet' media='print' />
	<script src='js/moment.min.js'></script>
	<script src='js/fullcalendar.min.js'></script>
	<script src="js/meal_planner.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	<script>
	    function pageloaded() {

	    }

	    $(document).ready(function () {
	        var date = new Date();
	        var nowstring = date.getFullYear() + "-0" + (date.getMonth() +1) + "-" + date.getDate();

	        $('#cpBody_calendar').fullCalendar({
			    header: {
				    left: 'prev,today,next',
				    center: 'title',
				    right: 'none'
			    },
			    defaultDate: nowstring,
			    defaultView: 'basicWeek',
			    height: 266,
			    navLinks: true, // can click day/week names to navigate views
			    editable: true,
			    eventReceive: function(event) {
			        var datastring = "\"" + $("#cpBody_hiddenUserID").attr("value") + "|" +
                        event.recipeid + "|" +
                        event.start.format() + "\"";

			        //if (confirm("Add Meal? ".concat(datastring))) {
			        $.ajax({
			            url: "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerApi/api/MealPlan",
			            type: 'PUT',
			            contentType: 'text/json',
			            data: datastring,
			            success: function (data, status, xhr) {
			                //alert("Received id: " + JSON.stringify(data).replace("{", "").replace("}", "").replace("\"", "").replace("\"", ""));
			                event.id = JSON.stringify(data).replace("{", "").replace("}", "").replace("\"", "").replace("\"", "");
			            },
			            error: function (result) {
			                alert("Error saving the meal: " + result);
			            }
			        });
			        //}
			    },
			    droppable: true,
			    eventLimit: true, // allow "more" link when too many events
			    eventClick: function(calEvent, jsEvent, view) {
			        window.location.href = "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlanner/Recipe.aspx?id=" + calEvent.recipeid;
			    },
			    eventDrop: function(event, delta, revertFunc) {
			        var datastring = "\"" + event.id + "|" + event.start.format() + "\"";
			        if (!confirm("Move " + event.title + "?")) {
			            revertFunc();
			        } else {
			            $.ajax({
			                url: "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerAPI/api/MealPlan",
			                type: 'POST',
			                contentType: 'text/json',
			                data: datastring,
			                success: function (result) {
			                    //alert("Saved changes to " + event.title);
			                },
			                error: function (result) {
			                    alert("Error saving changes to " + event.title);
			                }
			            });
			        }
			    },
			    eventDragStop: function (event, jsEvent) {
			        var trashE1 = $("#divTrash");
			        var ofs = trashE1.offset();

			        var x1 = ofs.left;
			        var x2 = ofs.left + $("#divTrash").outerWidth(true);
			        var y1 = ofs.top - 30;
			        var y2 = y1 + 60 + $("#imgTrash").height();

			        if (jsEvent.pageX >= x1 && jsEvent.pageX <= x2 &&
                        jsEvent.pageY >= y1 && jsEvent.pageY <= y2) {
			            
			            if (confirm("Remove Meal? ")) {
			                $.ajax({
			                    url: "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerApi/api/MealPlan/" + event.id,
			                    type: 'DELETE',
			                    success: function (result) {
			                        //alert("deleted: " + event.id);
			                        $('#cpBody_calendar').fullCalendar('removeEvents', event._id);
			                    },
			                    error: function (result) {
			                        alert("Error saving changes to " + event.title);
			                    }
			                });
			            }
			        }
			    },
	            eventSources: ["http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerApi/api/MealPlan/".concat(document.getElementById('cpBody_hiddenUserID').value)]
                //events: [{id:1, title:"test", start:"04/10/2017"}]
		    });
		
	        $('.event_draggable').draggable({
	            revert: true,      // immediately snap back to original position
	            revertDuration: 0  //
	        });

	        $(function () {
	            $("#selectable").selectable();
	        });

	        $(".deletegrocery").click(function (b) {
	            if ($(this).attr("value") == "X") {
	                var actionstring = "\"" + $(this).attr('removeaction') + "|delete\"";

	                $.ajax({
	                    url: "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerApi/api/Grocery",
	                    type: 'PUT',
	                    contentType: 'text/json',
	                    data: actionstring,
	                    success: function (result) {
	                        //alert("Saved changes to " + actionstring);
	                    },
	                    error: function (result) {
	                        alert("Error saving changes to " + actionstring);
	                    }
	                });
	                $(this).attr("value", "✔");
	                $(this).attr("class", "btn btn-success deletegrocery")
	            } else {
	                var actionstring = "\"" + $(this).attr('removeaction') + "|add\"";
	                $.ajax({
	                    url: "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerApi/api/Grocery",
	                    type: 'PUT',
	                    contentType: 'text/json',
	                    data: actionstring,
	                    success: function (result) {
	                        //alert("Saved changes to " + actionstring);
	                    },
	                    error: function (result) {
	                        alert("Error saving changes to " + actionstring);
	                    }
	                });
	                $(this).attr("value", "X");
	                $(this).attr("class", "btn btn-danger deletegrocery")
	            }
	        });
	    });
    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <form runat="server">
    <input type="hidden" runat="server" id="hiddenUserID" />
    <div class="row bodyrow">
		<div class="col-sm-12 col-md-5 col-md-offset-1">
            <div id="calendarheader">
                <div id="divMealPlanTitle">
                    <h2>Meal Plan</h2>
                </div>
                <div id="divTrash">
                    <img id="imgTrash" src="images/trash.png" />
                </div>
            </div>
			<div runat="server" id="calendar" />
		</div>
		<div class="col-sm-12 col-md-5">
            <h2>Favorite Recipes</h2>
			<asp:ListView runat="server" ID="listFavorites" DataSourceID="FavoriteDatasource">
                <LayoutTemplate>
                    <asp:Literal runat="server" ID="lblHiddenUserID" />
                    <table runat="server" id="Table1">
                      <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                    <asp:DataPager runat="server" ID="DataPager" PageSize="3">
                        <Fields>
                          <asp:NumericPagerField ButtonCount="10"
                               PreviousPageText="<--"
                               NextPageText="-->" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server" class="ui-widget-content event_draggable listItemCell" style="vertical-align:top;padding-top:.5em">
                        <div class="main ui-widget-content event_draggable listItemCell" 
                                data-event='<%#"{\"title\":\"" + Eval("Name") + "\",\"recipeid\":" + Eval("ID") + "}" %>'
                                data-title='<%#Eval("Name") %>'
                                data-recipeid='<%#Eval("ID") %>'">
                            <div class="sidebar">
                                <asp:HyperLink runat="server" NavigateUrl='<%#"~/recipe.aspx?id=" + Eval("ID") %>'>
                                    <asp:Image runat="server" CssClass="imgRecipeListItem" ImageUrl='<%#Eval("Image") %>' />
                                </asp:HyperLink>
                            </div>
                            <div class="page-wrap">
                                <div>
                                    <asp:Literal runat="server" Text='<%#Eval("Name") %>' />
                                </div>
                                <div>
                                    <asp:Literal runat="server" Text='<%#Eval("Description") %>' />
                                </div>
                            </div>
                        </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
		    <asp:SqlDataSource ID="FavoriteDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:MealPlannerConnectionString %>" SelectCommand="SELECT r.ID as ID, r.Name as Name, r.Description as Description, r.Category as Category, r.Image as Image FROM Recipes r left outer join FavoriteRecipes fr ON r.ID = fr.RecipeID WHERE fr.UserID = @UserID">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="UserID" SessionField="userid" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
		</div>
	</div>
	<div class="row bodyrow">
		<div class="col-sm-12 col-md-5 col-md-offset-1">
			<h2>Suggested Recipes</h2>
            <asp:Literal runat="server" ID="lblSuggestion" />
            <asp:ListView runat="server" ID="listSuggestions" DataSourceID="SuggestionsDatasource">
                <LayoutTemplate>
                    <asp:Literal runat="server" ID="lblHiddenUserID" />
                    <table runat="server" id="tblSuggestions">
                      <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                    <asp:DataPager runat="server" ID="DataPager" PageSize="3">
                        <Fields>
                          <asp:NumericPagerField ButtonCount="10"
                               PreviousPageText="<--"
                               NextPageText="-->" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td runat="server" class="ui-widget-content event_draggable listItemCell" style="vertical-align:top;padding-top:.5em">
                        <div class="main ui-widget-content event_draggable listItemCell" 
                                data-event='<%#"{\"title\":\"" + Eval("Name") + "\",\"recipeid\":" + Eval("ID") + "}" %>'
                                data-title='<%#Eval("Name") %>'
                                data-recipeid='<%#Eval("ID") %>'">
                            <div class="sidebar">
                                <asp:HyperLink runat="server" NavigateUrl='<%#"~/recipe.aspx?id=" + Eval("ID") %>'>
                                    <asp:Image runat="server" CssClass="imgRecipeListItem" ImageUrl='<%#Eval("Image") %>' />
                                </asp:HyperLink>
                            </div>
                            <div class="page-wrap">
                                <div>
                                    <asp:Literal runat="server" Text='<%#Eval("Name") %>' />
                                </div>
                                <div>
                                    <asp:Literal runat="server" Text='<%#Eval("Description") %>' />
                                </div>
                            </div>
                        </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
		    <asp:SqlDataSource ID="SuggestionsDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:MealPlannerConnectionString %>" SelectCommand="SELECT r.ID as ID, r.Name as Name, r.Description as Description, r.Category as Category, r.Image as Image FROM Recipes r left outer join FavoriteRecipes fr ON r.ID = fr.RecipeID WHERE fr.UserID IS NULL OR NOT fr.UserID = @UserID">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="UserID" SessionField="userid" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
		</div>
		<div class="col-sm-12 col-md-5">
			<h2>Grocery List</h2>
            <span runat="server" id="spanGroceryList" />
        </div>
	</div>
    </form>
</asp:Content>