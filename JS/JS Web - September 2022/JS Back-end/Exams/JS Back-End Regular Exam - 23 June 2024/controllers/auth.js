const authController = require("express").Router();
const { login, register } = require("../services/users");
const { isGuest, isUser } = require("../middlewares/guards");
const { mapErrors } = require("../utils/mapper");

authController.get("/login", isGuest(), (req, res) => {
  res.render("login", {
    title: "Login",
  });
});

authController.post("/login", isGuest(), async (req, res) => {
  try {
    const jwt = await login(req.body.email, req.body.password);
    res.cookie("jwt", jwt);
    res.redirect("/");
  } catch (error) {
    const errors = mapErrors(error);
    res.render("login", {
      title: "Login",
      errors,
      body: {
        email: req.body.email,
      },
    });
  }
});

authController.get("/register", isGuest(), (req, res) => {
  res.render("register", {
    title: "Register",
  });
});

authController.post("/register", isGuest(), async (req, res) => {
  try {
    if (req.body.password.length < 4) {
      throw new Error("Password should be at least 4 characters long");
    }
    if (req.body.password !== req.body.repass) {
      throw new Error("Passwords don't match");
    }

    const jwt = await register(
      req.body.name,
      req.body.email,
      req.body.password
    );
    res.cookie("jwt", jwt);
    res.redirect("/");
  } catch (error) {
    const errors = mapErrors(error);
    res.render("register", {
      title: "Register",
      errors,
      body: {
        name: req.body.name,
        email: req.body.email,
      },
    });
  }
});

authController.get("/logout", isUser(), (req, res) => {
  res.clearCookie("jwt");
  res.redirect("/");
});

module.exports = authController;
