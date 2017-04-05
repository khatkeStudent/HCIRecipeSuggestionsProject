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
	<link rel="stylesheet" type="text/css" href="css/recipes.css" />
</script>
</head>
<body>
	<?php include 'includes/header.inc' ?>
	<?php include 'includes/headermenu.inc' ?>
	<div class="searchBar">
		<form method="post" action="recipe.php" id="searchForm">
			<input type="text" name="searchName">
			<input type="submit" name="search" value="Search">
		</form>
	</div>
	<div class="row bodyrow">
		<div class="col-sm-12 col-md-6 homesection">
<?php 
include_once 'includes/recipesummary.inc';
$count = 0;
$usedrecipes = array();

while ($count < 3) {
	$recipeid = rand(0,3);
	if (in_array($recipeid,$usedrecipes)) {
		continue;
	}
	console.log($recipeid);
	array_push($usedrecipes,$recipeid);
	
	if ($recipeid == 0) {
		printimage("images/clamchowder.jpg");
		printtitle($recipeid, 'Clam Chowder');
		printsummary("  A delicious, traditional, cream based chowder, this recipe calls for the standard chowder ingredients: onion, celery, potatoes, diced carrots, clams, and cream. A little red wine vinegar is added before serving for extra flavor.");
	} else if ($recipeid == 1) {
		printimage("images/buffalowings.jpg");
		printtitle($recipeid, 'Buffalo Wings');
		printsummary("  No false promises here – these are SERIOUSLY CRISPY Oven Baked Buffalo Wings! ... Crispy wings, spicy buttery Buffalo Sauce, the earthy creamy blue cheese dip and fresh crunchy celery is a magical combination.");
	} else if ($recipeid == 2) {
		printimage("images/reubensandwich.jpg");
		printtitle($recipeid, 'Reuben Sandwich');
		printsummary("  A good ole' fashioned Corned Beef Reuben Sandwich. ... Butter one side of each slice of rye bread and place one slice of the bread buttered side down on a flat surface. Add ingredients in the following order: 2 tbsp of Thousand Island Dressing, corned beef, and sauerkraut.");
	} else if ($recipeid == 3) {
		printimage("images/pizza.jpg");
		printtitle($recipeid, 'Garbage Pizza');
		printsummary("  Classic homemade pizza recipe, including pizza dough and toppings, step-by-step instructions with photos. Make perfect pizza at home!");
	}
	$count++;
}
?>
		</div>
	</div>
</body>
</html>
