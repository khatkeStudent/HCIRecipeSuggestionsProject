<?php
@session_start();

echo "<div class='header container'>";
echo "	<div class='row'>";
echo "		<div class='col-md-12'>";
echo "			<a href='home.php'><img src='images/Logo.png' /></a>";
echo "			<div class='ahrefLoginHeader'>";

if (!isset($_SESSION["firstname"])) {
	echo "<a href='./login.php'>Login</a>";
	echo "<a>Sign up</a>";
} else {
	echo "<a href='home.php'>" . $_SESSION["firstname"] . "<span id='tooltipspan'><a href='handlers/logout_handler.php'>Logout</a></span></a>";
	/*
	echo "<a class='tooltip' href='home.php' onmousemove='profilemove()'>" . $_SESSION["firstname"];
	echo "<span id='tooltipspan'>";
	echo "	<a href='handlers/logout_handler.php'>Logout</a>";
	echo "</span></a>";
	*/
}

echo "			</div>";
echo "		</div>";
echo "	</div>";
echo "</div>";
?>