<?php
function printimage($img) {
	echo "<div class='divRecipeSummary'>";
	echo "	<div class='divRecipeSumImg'>";
	echo "	  <img src='" . $img . "' />";
	echo "	</div>";
}

function printtitle($id, $title) {
	echo "<div>";
	echo "  <div class='divRecipeSumName'>";
	echo "    <a href='recipe.php?id=" . $id . "'>";
	echo $title;
	echo "</a></div>";
}

function printsummary($summary) {
	echo "<div class='divRecipeSumDesc'>";
	echo $summary;
	echo "</div></div></div>";
}	
?>