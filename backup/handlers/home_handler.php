<?php
@session_start();

if (isset($_SESSION["firstname"])) {
	header("Location: ../index.php");
} else {
	header("Location: ../login.php");
}
?>
