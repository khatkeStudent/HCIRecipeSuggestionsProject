<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendar.aspx.cs" Inherits="MealPlanner.calendar" MasterPageFile="~/HCIMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cpTitle">Calendar</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpHead">
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <link href='css/calendar.css' rel='stylesheet' />
	<link href='css/fullcalendar.min.css' rel='stylesheet' />
	<link href='css/fullcalendar.print.min.css' rel='stylesheet' media='print' />
	<script src='js/moment.min.js'></script>
	<script src='js/fullcalendar.min.js'></script>
	<script>
	    $(document).ready(function() {
		
		    $('#calendar').fullCalendar({
			    header: {
				    left: 'prev,next today',
				    center: 'title',
				    right: 'month,agendaWeek,agendaDay,listWeek'
			    },
			    defaultDate: '2017-04-12',
			    navLinks: true, // can click day/week names to navigate views
			    editable: true,
			    eventLimit: true, // allow "more" link when too many events
			    events: [/*
				    {
					    title: 'All Day Event',
					    start: '2017-04-01'
				    },
				    {
					    title: 'Long Event',
					    start: '2017-04-07',
					    end: '2017-04-10'
				    },
				    {
					    id: 999,
					    title: 'Repeating Event',
					    start: '2017-04-09T16:00:00'
				    },
				    {
					    id: 999,
					    title: 'Repeating Event',
					    start: '2017-04-16T16:00:00'
				    },
				    {
					    title: 'Conference',
					    start: '2017-04-11',
					    end: '2017-04-13'
				    },
				    {
					    title: 'Meeting',
					    start: '2017-04-12T10:30:00',
					    end: '2017-04-12T12:30:00'
				    },
				    {
					    title: 'Lunch',
					    start: '2017-04-12T12:00:00'
				    },
				    {
					    title: 'Meeting',
					    start: '2017-04-12T14:30:00'
				    },
				    {
					    title: 'Happy Hour',
					    start: '2017-04-12T17:30:00'
				    },
				    {
					    title: 'Dinner',
					    start: '2017-04-12T20:00:00'
				    },
				    {
					    title: 'Birthday Party',
					    start: '2017-04-13T07:00:00'
				    },
				    {
					    title: 'Click for Google',
					    url: 'http://google.com/',
					    start: '2017-04-28'
				    }
			    */]
		    });
		
	    });

    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cpBody">
	<div id='calendar' />
</asp:Content>
