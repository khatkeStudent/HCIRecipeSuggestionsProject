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
				    left: 'prev,next today',
				    center: 'title',
				    right: 'month,agendaWeek,agendaDay,listWeek'
			    },
			    defaultDate: '2017-04-12',
			    navLinks: true, // can click day/week names to navigate views
			    editable: true,
			    eventLimit: true, // allow "more" link when too many events
			    eventSources: ["http://localhost:59760/api/MealPlan"]
		    });
		
	    });

    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
	<div runat="server" id="calendar" />
</asp:Content>
