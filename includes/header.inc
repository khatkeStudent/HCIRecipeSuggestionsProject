<?php
@session_start();

echo "<div class='header container'>";
echo "	<div class='row'>";
echo "		<div class='col-md-12'>";
echo "			<img src='images/Logo.png' />"
echo "			<div class='ahrefLoginHeader'>";

if ($_SESSION["firstname"] == null) {
	echo "			<a href='./login.php'>Login</a>";
	echo "			<a>Sign up</a>";
} else {
	echo "			<span id='txtName'>" . $_SESSION["firstname"] . "</span>";
}

echo "			</div>";
echo "		</div>";
echo "	</div>";
echo "</div>";
?>