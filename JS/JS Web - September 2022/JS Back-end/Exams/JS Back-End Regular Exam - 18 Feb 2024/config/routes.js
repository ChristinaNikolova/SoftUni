const homeController = require("../controllers/home");
const authController = require("../controllers/auth");
const stonesController = require("../controllers/stones");

module.exports = (app) => {
  app.use("/", homeController);
  app.use("/auth", authController);
  app.use("/stones", stonesController);

  app.get("/{*any}", (req, res) => {
    res.render("404", {
      title: "Page not found",
    });
  });
};
