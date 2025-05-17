const homeController = require("../controllers/home");
const authController = require("../controllers/auth");
const recipesController = require("../controllers/recipes");

module.exports = (app) => {
  app.use("/", homeController);
  app.use("/auth", authController);
  app.use("/recipes", recipesController);

  app.get("/{*any}", (req, res) => {
    res.render("404", {
      title: "Page not found",
    });
  });
};
