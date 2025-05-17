const homeController = require("express").Router();
const { isUser } = require("../middlewares/guards");
const {
  getLastThree,
  getUserDevices,
  getUserPreferredDevices,
  getAll,
} = require("../services/devices");
const { deviceViewModel, mapErrors } = require("../utils/mapper");

homeController.get("/", async (req, res) => {
  const devices = (await getLastThree()).map(deviceViewModel);

  res.render("home", {
    title: "Home",
    devices,
  });
});

homeController.get("/about", (req, res) => {
  res.render("about", {
    title: "About",
  });
});

homeController.get("/profile", isUser(), async (req, res) => {
  const userId = req.user._id;
  try {
    const createdDevices = (await getUserDevices(userId)).map(deviceViewModel);
    const preferredDevices = (await getUserPreferredDevices(userId)).map(
      deviceViewModel
    );

    res.render("profile", {
      title: "Profile",
      createdDevices,
      preferredDevices,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const devices = (await getAll()).map(deviceViewModel);
    res.render("catalog", { title: "Catalog", devices, errors });
  }
});

module.exports = homeController;
