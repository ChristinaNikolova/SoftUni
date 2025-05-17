const { Schema, model, Types } = require("mongoose");

const URL_PATTERN = /^https?:\/\/(.+)$/;

const recipeSchema = new Schema(
  {
    title: {
      type: String,
      required: [true, "Title is required"],
      minlength: [2, "Title should be at least 2 characters long"],
    },
    ingredients: {
      type: String,
      required: [true, "Ingredients are required"],
      minlength: [10, "Ingredients should be at least 10 characters long"],
      maxlength: [200, "Ingredients should be at least 200 characters long"],
    },
    instructions: {
      type: String,
      required: [true, "Instructions are required"],
      minlength: [10, "Instructions should be at least 10 characters long"],
    },
    description: {
      type: String,
      required: [true, "Description is required"],
      minlength: [10, "Description should be at least 10 characters long"],
      maxlength: [100, "Description should be at least 100 characters long"],
    },
    image: {
      type: String,
      required: [true, "Image is required"],
      match: [URL_PATTERN, "Image URL should start with http or https"],
    },
    owner: { type: Types.ObjectId, ref: "User", required: true },
    recommendList: { type: [Types.ObjectId], ref: "User", default: [] },
    recommendCount: { type: Number, default: 0 },
  },
  { timestamps: true }
);

recipeSchema.index(
  { title: 1 },
  {
    collation: {
      locale: "en",
      strength: 2,
    },
  }
);

const Recipe = model("Recipe", recipeSchema);

module.exports = Recipe;
