const homeController = require("../controllers/home");
const authController = require("../controllers/auth");
const devicesController = require("../controllers/devices");

module.exports = (app) => {
  app.use("/", homeController);
  app.use("/auth", authController);
  app.use("/devices", devicesController);

  app.get("/{*any}", (req, res) => {
    res.render("404", {
      title: "Page not found",
    });
  });
};
