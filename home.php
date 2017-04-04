<html>
<head>
	<title>Home - Meal Planner Supreme</title>
	<?php include 'includes/head.inc' ?>
	<link rel="stylesheet" href="css\home.css" />
	<link rel="stylesheet" href="css\components.css" />
	
	<script>
	function loaded() {
		adjustWeekSize();
	}
	
	function screenresized() {
		adjustWeekSize();
	}
	
	function adjustWeekSize() {
		var weekview = document.getElementById("divWeekview")
		var days = document.getElementsByClassName("weekviewday");
		var daynames = document.getElementsByClassName("weekviewdayname");
		var pagewidth = document.body.clientWidth;
		var w = (weekview.offsetWidth / 7);
		
		console.log("Page width: " + pagewidth);
		
		for (var i=0; i<days.length; i++) {
			days[i].style.width= w;
		}
		
		if (w < 95) {
			for (var i=0;i<daynames.length;i++) {
				if (daynames[i].innerHTML == "Sunday") {
					daynames[i].innerHTML = "Sun";
				} else if (daynames[i].innerHTML == "Monday") {
					daynames[i].innerHTML = "Mon";
				} else if (daynames[i].innerHTML == "Tuesday") {
					daynames[i].innerHTML = "Tues";
				} else if (daynames[i].innerHTML == "Wednesday") {
					daynames[i].innerHTML = "Wed";
				} else if (daynames[i].innerHTML == "Thursday") {
					daynames[i].innerHTML = "Thur";
				} else if (daynames[i].innerHTML == "Friday") {
					daynames[i].innerHTML = "Fri";
				} else if (daynames[i].innerHTML == "Saturday") {
					daynames[i].innerHTML = "Sat";
				}
			}
		} else {
			for (var i=0;i<daynames.length;i++) {
				if (daynames[i].innerHTML == "Sun") {
					daynames[i].innerHTML = "Sunday";
				} else if (daynames[i].innerHTML == "Mon") {
					daynames[i].innerHTML = "Monday";
				} else if (daynames[i].innerHTML == "Tues") {
					daynames[i].innerHTML = "Tuesday";
				} else if (daynames[i].innerHTML == "Wed") {
					daynames[i].innerHTML = "Wednesday";
				} else if (daynames[i].innerHTML == "Thur") {
					daynames[i].innerHTML = "Thursday";
				} else if (daynames[i].innerHTML == "Fri") {
					daynames[i].innerHTML = "Friday";
				} else if (daynames[i].innerHTML == "Sat") {
					daynames[i].innerHTML = "Saturday";
				}
			}
		}
	}
	</script>
</head>
<body onload="loaded()" onresize="screenresized()">
	<?php include 'includes/header.inc' ?>
	<?php include 'includes/headermenu.inc' ?>
	<div class="row bodyrow">
		<div class="col-sm-12 col-md-6 homesection">
			<?php include 'includes/weekview.inc' ?>
		</div>
		<div class="col-sm-12 col-md-6 homesection">
			<?php include 'includes/favoriterecipes.inc' ?>
		</div>
	</div>
	<div class="row bodyrow">
		<div class="col-sm-12 col-md-6 homesection">
			<?php include 'includes/friendsactivities.inc' ?>
		</div>
		<div class="col-sm-12 col-md-6 homesection">
			<?php include 'includes/suggestions.inc' ?>
		</div>
	</div>
</body>
</html>
