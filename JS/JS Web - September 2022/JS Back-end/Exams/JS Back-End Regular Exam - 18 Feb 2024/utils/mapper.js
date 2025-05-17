function mapErrors(error) {
  if (error.name == "ValidationError") {
    return Object.values(error.errors).map((v) => v.message);
  } else if (Array.isArray(error)) {
    return error.map((x) => x.msg);
  } else {
    return error.message.split("\n");
  }
}

function stoneViewModel(stone) {
  return {
    _id: stone._id,
    name: stone.name,
    category: stone.category,
    color: stone.color,
    image: stone.image,
    location: stone.location,
    formula: stone.formula,
    description: stone.description,
    owner: stone.owner,
    likedList: stone.likedList,
  };
}

module.exports = {
  mapErrors,
  stoneViewModel,
};
