<?php
@session_start();
?>

<html>
<head>
	<title>Login - Meal Planner Supreme</title>
	<?php include 'includes/head.inc' ?>
	<?php include 'includes/components.inc' ?>
	<link rel="stylesheet" href="css/login.css" />
	<script src="js/home.js"></script>
</head>
<body>	
	<?php include 'includes/header.inc' ?>
	<?php include 'includes/headermenu.inc' ?>
    <form action="handlers/login_handler.php" method="post">
	<fieldset>
		<legend>Login</legend>
		<h3>Username</h3>
		<input name="txtUsername" type="Text" value="<?php if (isset($_SESSION["tempusername"])) { echo htmlentities($_SESSION["tempusername"]); unset($_SESSION["tempusername"]); } ?>" />
		<h3>Password</h3>
		<input name="txtPassword" type="Password" />
		<input class="btnLogin" name="btnSubmit" type="Submit" value="Login" />
	</fieldset>
    </form>
    <div>
        New user? <a href="createaccount.php">create account</a>
    </div>
	</div>
</body>
</html>