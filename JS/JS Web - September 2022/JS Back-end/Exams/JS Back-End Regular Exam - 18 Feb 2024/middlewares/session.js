const { verifyToken } = require("../services/users");

module.exports = () => (req, res, next) => {
  const jwt = req.cookies.jwt;

  if (jwt) {
    try {
      const userData = verifyToken(jwt);
      req.user = userData;
      res.locals.email = userData.email;
    } catch (err) {
      res.clearCookie("jwt");
      res.redirect("/auth/login");
      return;
    }
  }

  next();
};
