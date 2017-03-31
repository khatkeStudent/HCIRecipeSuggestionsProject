<html>
<head>
	<title>Home - Meal Planner Supreme</title>
    <link rel="stylesheet" type="text/css" href="css/site.css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />
	<link rel="stylesheet" href="css\bootstrap.min.css" />
	
	<script src="js/jquery-3.1.1.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
</head>
<body>
	<?php include 'includes/header.php' ?>
	<div class="container">
		<div class="row">
			<div class="maincolumn col-md-4">
				<h1>Populars Recipes</h1>
				<?php include 'includes/popularrecipes.php' ?>
			</div>
			<div class="maincolumn col-md-4">
			<h1>Twitter Posts</h1>
			</div>
			<div class="maincolumn rightcolumn col-md-4">
				<div class="row">
					<h1>About Us</h1>
					<p class="divAboutUs">
					We are Team Hufflepuff, and we hope to make this awesome website that many people can use to plan meals and make grocery lists.
					</p>
				</div>
				<div class="subcolumn row">
					<h1>Reviews</h1>
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
					<p class="pUserReview">
					This website is great! I can quickly make a weekly meal plan and get on with my life.<br />&emsp;~John
					</p>
				</div>
				<div class="subcolumn row">
					<button id="btnSignUp">Sign Up Now!</button>
				</div>
			</div>
		</div>
	</div>
</body>
</html>
