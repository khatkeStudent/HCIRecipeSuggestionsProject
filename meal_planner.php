<?php 
	@session_start();
	if (!isset($_SESSION["firstname"])) {
		header("Location: login.php");
	}
?>

<html>
    <head>
		<title>Meal Planner</title>
		<?php include 'includes/head.inc' ?>
                <?php include 'includes/components.inc'?>
		<link rel="stylesheet" type="text/css" href="css/meal_planner.css" />
    </head>
    <body>
		<?php include 'includes/header.inc' ?>
		<?php include 'includes/headermenu.inc' ?>
        <div class="row text-center">
            <div class="planner-body">
	        <?php include 'includes/weekview.inc' ?>
	    </div>
	</div>
	<div class="row text-center planner-bottom">
	    <div class="col-md-4 needs">
	        <h3>You Need More ...</h3> 
	        <div class="row"><h4>Protein</h4></div>
		    <?php include 'includes/suggestions.inc'?>
		</div>
		<div class="col-md-4">
		    <?php include 'includes/friendsactivities.inc' ?>
		</div>
		<div class="col-md-4 divPlanMore">
		    <h2>Plan</h2>
                    <div class="row well well-sm">NEXT WEEK</div>
		    <div class="row well well-sm">NEXT MONTH</div>
		</div>
	    </div>
	</div>
    </body>
</html>
