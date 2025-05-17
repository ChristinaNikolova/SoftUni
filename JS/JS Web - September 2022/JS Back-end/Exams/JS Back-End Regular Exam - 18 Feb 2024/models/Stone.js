const { Schema, model, Types } = require("mongoose");

const URL_PATTERN = /^https?:\/\/(.+)$/;

const stoneSchema = new Schema(
  {
    name: {
      type: String,
      required: [true, "Name is required"],
      minlength: [2, "Name should be at least 2 characters long"],
    },
    category: {
      type: String,
      required: [true, "Category is required"],
      minlength: [3, "Category should be at least 3 characters long"],
    },
    color: {
      type: String,
      required: [true, "Color is required"],
      minlength: [2, "Color should be at least 2 characters long"],
    },
    image: {
      type: String,
      required: [true, "Image is required"],
      match: [URL_PATTERN, "Image URL should start with http or https"],
    },
    location: {
      type: String,
      required: [true, "Location is required"],
      minlength: [5, "Location should be at least 5 characters long"],
      maxlength: [15, "Location should be maximal 15 characters long"],
    },
    formula: {
      type: String,
      required: [true, "Formula is required"],
      minlength: [3, "Formula should be at least 3 characters long"],
      maxlength: [30, "Formula should be maximal 30 characters long"],
    },
    description: {
      type: String,
      required: [true, "Description is required"],
      minlength: [10, "Description should be at least 10 characters long"],
    },
    owner: { type: Types.ObjectId, ref: "User", required: true },
    likedList: { type: [Types.ObjectId], ref: "User", default: [] },
  },
  { timestamps: true }
);

stoneSchema.index(
  { name: 1 },
  {
    collation: {
      locale: "en",
      strength: 2,
    },
  }
);

const Stone = model("Stone", stoneSchema);

module.exports = Stone;
