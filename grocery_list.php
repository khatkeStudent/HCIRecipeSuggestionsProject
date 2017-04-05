<html>
    <head>
          <title>Grocery List</title>
	<link rel="stylesheet" type="text/css" href="css/site.css" />
	<link rel="stylesheet" type="text/css" href="css/grocery_list.css" />
	<link rel="stylesheet" type="text/css" href="css/index.css"/>
	<link rel="stylesheet" href="css\bootstrap.min.css" />
        <script src="js/jquery-3.1.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
    </head>
    <body>
       <?php include 'includes/header.inc' ?>
       <?php include 'includes/headermenu.inc' ?>
       <div class="container">
           <div class="row">

               <div class="col-md-6 text-center well">
                   <h3>HAVE
		       <button class="add_pantry btn btn-success">+</button>
	           </h3>
		   <div class="col-md-6 text-center">
		       <div class="row well well-sm">Eggs</div>
		       <div class="row well well-sm">Milk</div>
		       <div class="row well well-sm">Flour</div>
		       <div class="row well well-sm">Sugar</div>
		       <div class="row well well-sm">Canned Peaches</div>
		       <div class="row well well-sm">Cheddar Cheese</div>
	           </div>
		   <div class="col-md-6 text-center">
		        <div class="row well well-sm">Tortillas</div>
			<div class="row well well-sm">Baking Soda</div>
			<div class="row well well-sm">Chocolate Chips</div>
			<div class="row well well-sm">Frozen Strawberries</div>
			<div class="row well well-sm">Romaine</div>
			<div class="row well well-sm">Carrots</div>
                   </div>
	       </div>
	       <div class="col-md-6 text-center well">
                  <h3>Need
		      <button class="add_grocery btn btn-success">+</button>
		  </h3>
		  <div class="col-md-6 text-center">
		      <div class="row well well-sm">Pancake Mix</div>
		      <div class="row well well-sm">Graham Crackers</div>
		      <div class="row well well-sm">Lunch Meat</div>
		      <div class="row well well-sm">Flank Steak</div>
		      <div class="row well well-sm">Red Potatoes</div>
		      <div class="row well well-sm">Sweet Potatoes</div>
		  </div>
		      <div class="col-md-6 text-center">
		      <div class="row well well-sm">Chicken Breast</div>
		      <div class="row well well-sm">Cucumbers</div>
		      <div class="row well well-sm">Chili Powder</div>
		      <div class="row well well-sm">Rosemary</div>
		      <div class="row well well-sm">Cooking Wine</div>
		      <div class="row well well-sm">Tomato Sauce</div>
		  </div>
	       </div>
	   </div>
       </div>
    </body>
</html>
