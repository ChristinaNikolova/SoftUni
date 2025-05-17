const { Schema, model, Types } = require("mongoose");

const URL_PATTERN = /^https?:\/\/(.+)$/;

const deviceSchema = new Schema(
  {
    brand: {
      type: String,
      required: [true, "Brand is required"],
      minlength: [2, "Brand should be at least 2 characters long"],
    },
    model: {
      type: String,
      required: [true, "Model is required"],
      minlength: [5, "Model should be at least 5 characters long"],
    },
    hardDisk: {
      type: String,
      required: [true, "Hard disk is required"],
      minlength: [5, "Hard disk should be at least 5 characters long"],
    },
    screenSize: {
      type: String,
      required: [true, "Screen size is required"],
      minlength: [1, "Screen size should be at least 1 characters long"],
    },
    ram: {
      type: String,
      required: [true, "Ram is required"],
      minlength: [2, "Ram should be at least 2 characters long"],
    },
    operatingSystem: {
      type: String,
      required: [true, "Operating system is required"],
      minlength: [5, "Operating system should be at least 5 characters long"],
      maxlength: [20, "Operating system should be maximal 20 characters long"],
    },
    cpu: {
      type: String,
      required: [true, "CPU is required"],
      minlength: [10, "CPU should be at least 10 characters long"],
      maxlength: [50, "CPU should be maximal 50 characters long"],
    },
    gpu: {
      type: String,
      required: [true, "GPU is required"],
      minlength: [10, "GPU should be at least 10 characters long"],
      maxlength: [50, "GPU should be maximal 50 characters long"],
    },
    price: {
      type: Number,
      required: [true, "Price is required"],
      min: [0.01, "Price should be a positive number"],
    },
    color: {
      type: String,
      required: [true, "Color is required"],
      minlength: [2, "Color should be at least 2 characters long"],
      maxlength: [10, "Color should be maximal 10 characters long"],
    },
    weight: {
      type: String,
      required: [true, "Weight  is required"],
      minlength: [1, "Weight should be at least 1 characters long"],
    },
    image: {
      type: String,
      required: [true, "Image  is required"],
      match: [URL_PATTERN, "Image URL should start with http or https"],
    },
    owner: { type: Types.ObjectId, ref: "User", required: true },
    preferredList: { type: [Types.ObjectId], ref: "User", default: [] },
  },
  { timestamps: true }
);

const Device = model("Device", deviceSchema);

module.exports = Device;
