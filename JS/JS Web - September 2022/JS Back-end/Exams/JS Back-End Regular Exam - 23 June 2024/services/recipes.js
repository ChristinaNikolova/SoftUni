const Recipe = require("../models/Recipe");

async function getAll(querySearch) {
  let query = {};
  if (querySearch) {
    query.title = new RegExp(querySearch, "i");
  }

  return Recipe.find(query);
}

async function getLastThree() {
  return Recipe.find({}).sort({ createdAt: -1 }).limit(3);
}

async function create(recipe) {
  const existingRecipe = await findByTitle(recipe.title);

  if (existingRecipe) {
    throw new Error("Title is already taken");
  }

  return new Recipe(recipe).save();
}

async function getById(id) {
  return Recipe.findById(id);
}

async function recommend(recipeId, userId) {
  const recipe = await Recipe.findById(recipeId);
  recipe.recommendList.push(userId);
  recipe.recommendCount++;
  return recipe.save();
}

async function deleteById(id) {
  return Recipe.findByIdAndDelete(id);
}

async function edit(id, updatedRecipe) {
  const recipe = await Recipe.findById(id);

  let existing = false;
  if (recipe.title.toLowerCase() !== updatedRecipe.title.toLowerCase()) {
    existing = await findByTitle(updatedRecipe.title);
  }

  if (existing) {
    throw new Error("Title already exist");
  }

  recipe.title = updatedRecipe.title;
  recipe.description = updatedRecipe.description;
  recipe.ingredients = updatedRecipe.ingredients;
  recipe.instructions = updatedRecipe.instructions;
  recipe.image = updatedRecipe.image;

  return recipe.save();
}

async function findByTitle(title) {
  return Recipe.findOne({ title }).collation({
    locale: "en",
    strength: 2,
  });
}

module.exports = {
  getAll,
  getLastThree,
  create,
  getById,
  recommend,
  deleteById,
  edit,
};
