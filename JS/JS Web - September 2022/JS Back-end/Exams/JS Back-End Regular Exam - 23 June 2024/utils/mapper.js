function mapErrors(error) {
  if (error.name == "ValidationError") {
    return Object.values(error.errors).map((v) => v.message);
  } else if (Array.isArray(error)) {
    return error.map((x) => x.msg);
  } else {
    return error.message.split("\n");
  }
}

function recipeViewModel(recipe) {
  return {
    _id: recipe._id,
    title: recipe.title,
    ingredients: recipe.ingredients,
    instructions: recipe.instructions,
    description: recipe.description,
    image: recipe.image,
    owner: recipe.owner,
    recommendList: recipe.recommendList,
    recommendCount: recipe.recommendCount,
  };
}

module.exports = {
  mapErrors,
  recipeViewModel,
};
