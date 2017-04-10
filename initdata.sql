INSERT INTO recipes (title, instructions, image) 
VALUES ('Default Title', 'Make stuff', 'example.png');

INSERT INTO ingredients (recipe_id, index, quantity, item)
VALUES (1, 1, '1 Cup', 'Stuff');
INSERT INTO ingredients (recipe_id, index, quantity, item)
VALUES (1, 2, '1 Pinch', 'Other stuff');
INSERT INTO ingredients (recipe_id, index, quantity, item)
VALUES (1, 3, '1 Dash', 'Moar stuff');