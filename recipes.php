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
	<div class="row bodyrow">
		<div class="col-sm-12 col-md-6 homesection">
			<?php include 'includes/suggestions.inc ?>
		</div>
	</div>
</body>
</html>
