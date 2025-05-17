const recipesController = require("express").Router();
const { isUser } = require("../middlewares/guards");
const {
  getAll,
  getLastThree,
  create,
  getById,
  recommend,
  deleteById,
  edit,
} = require("../services/recipes");
const { mapErrors, recipeViewModel } = require("../utils/mapper");

recipesController.get("/", async (req, res) => {
  try {
    const recipes = (await getAll()).map(recipeViewModel);

    res.render("catalog", {
      title: "Catalog",
      recipes,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const recipes = (await getLastThree()).map(recipeViewModel);
    res.render("home", { title: "Home", recipes, errors });
  }
});

recipesController.get("/create", isUser(), (req, res) => {
  res.render("create", {
    title: "Create Recipe",
  });
});

recipesController.post("/create", isUser(), async (req, res) => {
  try {
    const userId = req.user._id;
    const recipe = {
      title: req.body.title,
      description: req.body.description,
      ingredients: req.body.ingredients,
      instructions: req.body.instructions,
      image: req.body.image,
      owner: userId,
    };

    await create(recipe);
    res.redirect("/recipes");
  } catch (err) {
    const errors = mapErrors(err);
    res.render("create", {
      title: "Create Recipe",
      body: req.body,
      errors,
    });
  }
});

recipesController.get("/details/:id", async (req, res) => {
  try {
    const recipeId = req.params.id;
    const recipe = recipeViewModel(await getById(recipeId));
    const userId = req.user?._id;

    let isOwner = false;
    let isRecommended = false;
    if (userId === recipe.owner.toString()) {
      isOwner = true;
    } else {
      isRecommended = recipe.recommendList
        .map((x) => x._id.toString())
        .includes(userId);
    }

    res.render("details", {
      title: recipe.title,
      recipe,
      isOwner,
      isRecommended,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const recipes = (await getLastThree()).map(recipeViewModel);
    res.render("home", { title: "Home", recipes, errors });
  }
});

recipesController.get("/recommend/:id", isUser(), async (req, res) => {
  try {
    const recipeId = req.params.id;
    const recipe = recipeViewModel(await getById(recipeId));
    const userId = req.user._id;

    if (userId === recipe.owner.toString()) {
      throw new Error("Owner cannot recommend the recipe");
    }

    if (recipe.recommendList.map((x) => x._id.toString()).includes(userId)) {
      throw new Error("You already recommended this recipe");
    }

    await recommend(recipeId, userId);
    res.redirect("/recipes/details/" + recipeId);
  } catch (err) {
    const errors = mapErrors(err);
    const recipes = (await getLastThree()).map(recipeViewModel);
    res.render("home", { title: "Home", recipes, errors });
  }
});

recipesController.get("/delete/:id", isUser(), async (req, res) => {
  try {
    const recipeId = req.params.id;
    const recipe = recipeViewModel(await getById(recipeId));
    const userId = req.user._id;

    if (userId !== recipe.owner.toString()) {
      throw new Error("Only the owner can delete the recipe");
    }

    await deleteById(recipeId);
    res.redirect("/recipes");
  } catch (err) {
    const errors = mapErrors(err);
    const recipes = (await getLastThree()).map(recipeViewModel);
    res.render("home", { title: "Home", recipes, errors });
  }
});

recipesController.get("/edit/:id", isUser(), async (req, res) => {
  try {
    const recipeId = req.params.id;
    const recipe = recipeViewModel(await getById(recipeId));
    const userId = req.user._id;

    if (userId !== recipe.owner.toString()) {
      throw new Error("Only the owner can edit the recipe");
    }

    res.render("edit", {
      title: "Edit Recipe",
      recipe,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const recipes = (await getLastThree()).map(recipeViewModel);
    res.render("home", { title: "Home", recipes, errors });
  }
});

recipesController.post("/edit/:id", isUser(), async (req, res) => {
  let updatedRecipe = {};

  try {
    const recipeId = req.params.id;
    const recipe = recipeViewModel(await getById(recipeId));
    const userId = req.user._id;

    if (userId !== recipe.owner.toString()) {
      throw new Error("Only the owner can edit the recipe");
    }

    updatedRecipe = {
      _id: recipeId,
      title: req.body.title,
      description: req.body.description,
      ingredients: req.body.ingredients,
      instructions: req.body.instructions,
      image: req.body.image,
    };

    await edit(recipeId, updatedRecipe);
    res.redirect("/recipes/details/" + recipeId);
  } catch (err) {
    const errors = mapErrors(err);
    res.render("edit", {
      title: "Edit Recipe",
      recipe: updatedRecipe,
      errors,
    });
  }
});

recipesController.get("/search", async (req, res) => {
  const querySearch = req.query.search;

  const recipes = (await getAll(querySearch)).map(recipeViewModel);
  res.render("search", {
    title: "Search Recipe",
    recipes,
    search: querySearch,
  });
});

module.exports = recipesController;
