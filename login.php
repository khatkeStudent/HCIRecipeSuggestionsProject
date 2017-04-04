<?php
@session_start();

$_SESSION["firstname"] = "Kenny Hatke";

header("Location: handlers/home_handler.php");
?>