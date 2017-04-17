<?php
@session_start();
$_SESSION["firstname"] = "Kenny Hatke";

header("Location: home_handler.php");
?>