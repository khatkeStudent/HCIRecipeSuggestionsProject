<?php
@session_start();

if (isset($_SESSION["firstname"])) {
	header("Location: ../home.php");
} else {
	header("Location: ../login.php");
}
?>