const devicesController = require("express").Router();
const { isUser } = require("../middlewares/guards");
const {
  create,
  getAll,
  getById,
  prefer,
  deleteById,
  edit,
} = require("../services/devices");
const { mapErrors, deviceViewModel } = require("../utils/mapper");

devicesController.get("/", async (req, res) => {
  try {
    const devices = (await getAll()).map(deviceViewModel);

    res.render("catalog", {
      title: "Catalog",
      devices,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const devices = (await getAll()).map(deviceViewModel);
    res.render("home", { title: "Home", devices, errors });
  }
});

devicesController.get("/details/:id", async (req, res) => {
  try {
    const deviceId = req.params.id;
    const userId = req.user?._id;
    const device = deviceViewModel(await getById(deviceId));

    let isOwner = false;
    let isPreferred = false;
    if (userId === device.owner.toString()) {
      isOwner = true;
    } else {
      isPreferred = device.preferredList
        .map((x) => x._id.toString())
        .includes(userId);
    }

    res.render("details", {
      title: device.brand + " " + device.model,
      device,
      isOwner,
      isPreferred,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const devices = (await getAll()).map(deviceViewModel);
    res.render("catalog", { title: "Catalog", devices, errors });
  }
});

devicesController.get("/prefer/:id", isUser(), async (req, res) => {
  try {
    const deviceId = req.params.id;
    const userId = req.user._id;
    const device = deviceViewModel(await getById(deviceId));

    if (userId === device.owner.toString()) {
      throw new Error("Owner cannot prefer the device");
    }

    if (device.preferredList.map((x) => x._id.toString()).includes(userId)) {
      throw new Error("You already preferred this device");
    }

    await prefer(deviceId, userId);
    res.redirect("/devices/details/" + deviceId);
  } catch (err) {
    const errors = mapErrors(err);
    const devices = (await getAll()).map(deviceViewModel);
    res.render("catalog", { title: "Catalog", devices, errors });
  }
});

devicesController.get("/create", isUser(), (req, res) => {
  res.render("create", { title: "Create Device" });
});

devicesController.post("/create", isUser(), async (req, res) => {
  try {
    const userId = req.user._id;
    const device = {
      brand: req.body.brand,
      model: req.body.model,
      hardDisk: req.body.hardDisk,
      screenSize: req.body.screenSize,
      ram: req.body.ram,
      operatingSystem: req.body.operatingSystem,
      cpu: req.body.cpu,
      gpu: req.body.gpu,
      price: Number(req.body.price),
      color: req.body.color,
      weight: req.body.weight,
      image: req.body.image,
      owner: userId,
    };

    await create(device);
    res.redirect("/devices");
  } catch (err) {
    const errors = mapErrors(err);
    res.render("create", {
      title: "Create Device",
      body: req.body,
      errors,
    });
  }
});

devicesController.get("/delete/:id", isUser(), async (req, res) => {
  try {
    const deviceId = req.params.id;
    const device = deviceViewModel(await getById(deviceId));
    const userId = req.user._id;

    if (userId !== device.owner._id.toString()) {
      throw new Error("Only the owner can delete this device");
    }

    await deleteById(deviceId);
    res.redirect("/devices");
  } catch (err) {
    const errors = mapErrors(err);
    const devices = (await getAll()).map(deviceViewModel);
    res.render("catalog", { title: "Catalog", devices, errors });
  }
});

devicesController.get("/edit/:id", isUser(), async (req, res) => {
  try {
    const deviceId = req.params.id;
    const device = deviceViewModel(await getById(deviceId));
    const userId = req.user._id;

    if (userId !== device.owner._id.toString()) {
      throw new Error("Only the owner can edit this device");
    }

    res.render("edit", { title: "Edit Device", device });
  } catch (err) {
    const errors = mapErrors(err);
    const devices = (await getAll()).map(deviceViewModel);
    res.render("catalog", { title: "Catalog", devices, errors });
  }
});

devicesController.post("/edit/:id", isUser(), async (req, res) => {
  const deviceId = req.params.id;
  const dbDevice = deviceViewModel(await getById(deviceId));
  const userId = req.user._id;

  let device = {
    _id: dbDevice._id,
    brand: req.body.brand,
    model: req.body.model,
    hardDisk: req.body.hardDisk,
    screenSize: req.body.screenSize,
    ram: req.body.ram,
    operatingSystem: req.body.operatingSystem,
    cpu: req.body.cpu,
    gpu: req.body.gpu,
    price: Number(req.body.price),
    color: req.body.color,
    weight: req.body.weight,
    image: req.body.image,
  };

  try {
    if (userId !== dbDevice.owner._id.toString()) {
      throw new Error("Only the owner can edit this device");
    }

    await edit(deviceId, device);
    res.redirect("/devices/details/" + deviceId);
  } catch (err) {
    const errors = mapErrors(err);
    device = Object.assign(
      {
        _id: dbDevice._id,
      },
      req.body
    );
    res.render("edit", { title: "Edit Device", device, errors });
  }
});

module.exports = devicesController;
