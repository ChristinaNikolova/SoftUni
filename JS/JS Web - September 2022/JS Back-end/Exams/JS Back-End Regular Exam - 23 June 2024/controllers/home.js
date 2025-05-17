const homeController = require("express").Router();
const { getLastThree } = require("../services/recipes");
const { recipeViewModel } = require("../utils/mapper");

homeController.get("/", async (req, res) => {
  const recipes = (await getLastThree()).map(recipeViewModel);

  res.render("home", {
    title: "Home",
    recipes,
  });
});

module.exports = homeController;
