const Stone = require("../models/Stone");

async function getAll(querySearch) {
  let query = {};

  if (querySearch) {
    query.name = new RegExp(querySearch, "i");
  }

  return Stone.find(query);
}

async function getLastThree() {
  return Stone.find({}).sort({ createdAt: -1 }).limit(3);
}

async function create(stone) {
  const existingName = await findByName(stone.name);

  if (existingName) {
    throw new Error("Name is already taken");
  }

  return new Stone(stone).save();
}

async function getById(id) {
  return Stone.findById(id);
}

async function like(stoneId, userId) {
  const stone = await Stone.findById(stoneId);
  stone.likedList.push(userId);
  return stone.save();
}

async function deleteById(id) {
  return Stone.findByIdAndDelete(id);
}

async function edit(id, updatedStone) {
  const stone = await Stone.findById(id);

  let existingName = false;
  if (stone.name.toLowerCase() !== updatedStone.name.toLowerCase()) {
    existingName = await findByName(updatedStone.name);
  }

  if (existingName) {
    throw new Error("Name is already taken");
  }

  stone.name = updatedStone.name;
  stone.category = updatedStone.category;
  stone.color = updatedStone.color;
  stone.image = updatedStone.image;
  stone.location = updatedStone.location;
  stone.formula = updatedStone.formula;
  stone.description = updatedStone.description;

  return stone.save();
}

async function findByName(name) {
  return Stone.findOne({ name }).collation({
    locale: "en",
    strength: 2,
  });
}

module.exports = {
  getAll,
  getLastThree,
  create,
  getById,
  like,
  deleteById,
  edit,
};
