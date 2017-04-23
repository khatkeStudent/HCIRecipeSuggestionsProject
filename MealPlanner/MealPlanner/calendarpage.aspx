<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendarpage.aspx.cs" Inherits="MealPlanner.calendarpage" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Calendar</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <link href='css/calendar.css' rel='stylesheet' />
	<link href='css/fullcalendar.min.css' rel='stylesheet' />
	<link href='css/fullcalendar.print.min.css' rel='stylesheet' media='print' />
	<script src='js/moment.min.js'></script>
	<script src='js/fullcalendar.min.js'></script>
	<script>
	    function pageloaded() {

	    }

	    $(document).ready(function() {
	        $('#cpBody_calendar').fullCalendar({
			    header: {
			        left: 'prev,today,next',
				    center: 'title',
				    right: 'month,basicWeek'
			    },
			    defaultDate: '2017-04-12',
			    navLinks: true, // can click day/week names to navigate views
			    editable: true,
			    eventLimit: true, // allow "more" link when too many events
			    eventClick: function(calEvent, jsEvent, view) {
			        window.location.href = "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlanner/Recipe.aspx?id=" + calEvent.recipeid;
			    },
			    eventDrop: function(event, delta, revertFunc) {
			        var datastring = "\"" + event.id + "|" + event.start.format() + "\"";

			        if (!confirm("Are you sure about this change? ".concat(datastring))) {
			            revertFunc();
			        } else {
			            $.ajax({
			                url: "http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerApi/api/MealPlan",
			                type: 'POST',
			                contentType: 'text/json',
			                data: datastring,
			                error: function (result) {
			                    alert("Error saving changes to " + event.title);
			                }
			            });
			        }
			    },
	            eventSources: ["http://hcimealplanner.us-west-2.elasticbeanstalk.com/MealPlannerApi/api/MealPlan/".concat(document.getElementById('cpBody_hiddenUserID').value)]
                //events: [{id:1, title:"test", start:"04/10/2017"}]
		    });
		
	    });

    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
    <input type="hidden" runat="server" id="hiddenUserID" />
	<div runat="server" id="calendar" />
</asp:Content>
