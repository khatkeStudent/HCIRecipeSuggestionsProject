<?php 
	@session_start();
	if (!isset($_SESSION["firstname"])) {
		header("Location: login.php");
	}
?>

<html>
<head>
	<title>Home - Meal Planner Supreme</title>
	<?php include 'includes/head.inc' ?>
	<?php include 'includes/components.inc' ?>
	<link rel="stylesheet" href="css/home.css" />
	<script src="js/home.js"></script>

<script>
/*
function profilemove() {
	var tooltipSpan = document.getElementById('tooltipspan');

	window.onmousemove = function (e) {
		var x = e.clientX,
			y = e.clientY;
		tooltipSpan.style.top = (y + 20) + 'px';
		tooltipSpan.style.left = (x + 20) + 'px';
	};
}
*/
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
