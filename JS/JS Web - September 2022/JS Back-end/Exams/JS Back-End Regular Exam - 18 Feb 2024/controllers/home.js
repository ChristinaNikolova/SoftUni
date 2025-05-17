const { getLastThree } = require("../services/stones");
const { stoneViewModel } = require("../utils/mapper");

const homeController = require("express").Router();

homeController.get("/", async (req, res) => {
  const stones = (await getLastThree()).map(stoneViewModel);

  res.render("home", {
    title: "Home",
    stones,
  });
});

module.exports = homeController;
