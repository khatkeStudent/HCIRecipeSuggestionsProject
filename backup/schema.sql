DROP TABLE IF EXISTS recipes CASCADE;
CREATE TABLE recipes (
    recipe_id serial PRIMARY KEY, 
    title text, 
    instructions text, 
    image text);

DROP TABLE IF EXISTS ingredients CASCADE;
CREATE TABLE ingredients (
    recipe_id integer REFERENCES recipes, 
    index integer, 
    quantity text,
    item text,
    UNIQUE (recipe_id, index)
);
CREATE INDEX ingredient_recipe_idx ON ingredients (recipe_id);