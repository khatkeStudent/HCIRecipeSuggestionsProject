<?php 
	@session_start();
	if (!isset($_SESSION["firstname"])) {
		header("Location: login.php");
	}
?>

<html>
<head>
	<title>Your Network - Meal Planner Supreme</title>
	<?php include 'includes/head.inc' ?>
	<link rel="stylesheet" type="text/css" href="css/network.css" />
</script>
</head>
<body onload="loaded()" onresize="screenresized()">
	<?php include 'includes/header.inc' ?>
	<?php include 'includes/headermenu.inc' ?>
</body>
</html>
