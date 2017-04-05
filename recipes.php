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
	<link rel="stylesheet" type="text/css" href="css/recipes.css" />
</script>
</head>
<body onload="loaded()" onresize="screenresized()">
	<?php include 'includes/header.inc' ?>
	<?php include 'includes/headermenu.inc' ?>
	<div class="searchBar">
		<p>Search Recipes</p>
		<form method="post" action="recipes.php" id="searchForm">
			<input type="text" name="searchName">
			<input type="submit" name="search" value="Search">
		</form>
	</div>
	<div class="row bodyrow">
		<div class="col-sm-12 col-md-6 homesection">
			<?php include 'includes/suggestions.inc' ?>
		</div>
	</div>
</body>
</html>
