const stonesController = require("express").Router();
const {
  getAll,
  getLastThree,
  create,
  getById,
  like,
  deleteById,
  edit,
} = require("../services/stones");
const { mapErrors, stoneViewModel } = require("../utils/mapper");
const { isUser } = require("../middlewares/guards");

stonesController.get("/", async (req, res) => {
  try {
    const stones = (await getAll()).map(stoneViewModel);

    res.render("dashboard", {
      title: "Dashboard",
      stones,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const stones = (await getLastThree()).map(stoneViewModel);
    res.render("home", { title: "Home", stones, errors });
  }
});

stonesController.get("/create", isUser(), async (req, res) => {
  res.render("create", {
    title: "Create Stone",
  });
});

stonesController.post("/create", isUser(), async (req, res) => {
  try {
    const userId = req.user._id;

    const stone = {
      name: req.body.name,
      category: req.body.category,
      color: req.body.color,
      image: req.body.image,
      location: req.body.location,
      formula: req.body.formula,
      description: req.body.description,
      owner: userId,
    };

    await create(stone);
    res.redirect("/stones");
  } catch (err) {
    const errors = mapErrors(err);
    res.render("create", {
      title: "Create Stone",
      body: req.body,
      errors,
    });
  }
});

stonesController.get("/details/:id", async (req, res) => {
  try {
    const stoneId = req.params.id;
    const userId = req.user?._id;
    const stone = stoneViewModel(await getById(stoneId));

    let isOwner = false;
    let isLiked = false;

    if (userId === stone.owner.toString()) {
      isOwner = true;
    } else {
      isLiked = stone.likedList.map((x) => x._id.toString()).includes(userId);
    }

    res.render("details", {
      title: stone.name,
      stone,
      isOwner,
      isLiked,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const stones = (await getLastThree()).map(stoneViewModel);
    res.render("home", { title: "Home", stones, errors });
  }
});

stonesController.get("/like/:id", isUser(), async (req, res) => {
  try {
    const stoneId = req.params.id;
    const userId = req.user._id;
    const stone = stoneViewModel(await getById(stoneId));

    if (userId === stone.owner.toString()) {
      throw new Error("Owner cannot like this stone");
    }

    if (stone.likedList.map((x) => x._id.toString()).includes(userId)) {
      throw new Error("You already liked this stone");
    }

    await like(stoneId, userId);
    res.redirect("/stones/details/" + stoneId);
  } catch (err) {
    const errors = mapErrors(err);
    const stones = (await getLastThree()).map(stoneViewModel);
    res.render("home", { title: "Home", stones, errors });
  }
});

stonesController.get("/delete/:id", isUser(), async (req, res) => {
  try {
    const stoneId = req.params.id;
    const userId = req.user._id;
    const stone = stoneViewModel(await getById(stoneId));

    if (userId !== stone.owner.toString()) {
      throw new Error("Only the owner can delete this stone");
    }

    await deleteById(stoneId);
    res.redirect("/stones");
  } catch (err) {
    const errors = mapErrors(err);
    const stones = (await getLastThree()).map(stoneViewModel);
    res.render("home", { title: "Home", stones, errors });
  }
});

stonesController.get("/edit/:id", isUser(), async (req, res) => {
  try {
    const stoneId = req.params.id;
    const userId = req.user._id;
    const stone = stoneViewModel(await getById(stoneId));

    if (userId !== stone.owner.toString()) {
      throw new Error("Only the owner can edit this stone");
    }

    res.render("edit", {
      title: "Edit Stone",
      stone,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const stones = (await getLastThree()).map(stoneViewModel);
    res.render("home", { title: "Home", stones, errors });
  }
});

stonesController.post("/edit/:id", isUser(), async (req, res) => {
  try {
    const stoneId = req.params.id;
    const userId = req.user._id;
    const stone = stoneViewModel(await getById(stoneId));

    if (userId !== stone.owner.toString()) {
      throw new Error("Only the owner can edit this stone");
    }

    const updatedStone = {
      name: req.body.name,
      category: req.body.category,
      color: req.body.color,
      image: req.body.image,
      location: req.body.location,
      formula: req.body.formula,
      description: req.body.description,
    };

    await edit(stoneId, updatedStone);
    res.redirect("/stones/details/" + stoneId);
  } catch (err) {
    const errors = mapErrors(err);
    const stone = Object.assign(
      {
        _id: req.params.id,
      },
      req.body
    );
    res.render("edit", {
      title: "Edit Stone",
      stone,
      errors,
    });
  }
});

stonesController.get("/search", async (req, res) => {
  try {
    const querySearch = req.query.search;

    const stones = (await getAll(querySearch)).map(stoneViewModel);
    res.render("search", {
      title: "Search Stone",
      stones,
      search: querySearch,
    });
  } catch (err) {
    const errors = mapErrors(err);
    const stones = (await getLastThree()).map(stoneViewModel);
    res.render("home", { title: "Home", stones, errors });
  }
});

module.exports = stonesController;
