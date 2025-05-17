const { Schema, model } = require("mongoose");

const userSchema = new Schema({
  name: {
    type: String,
    required: [true, "Name is required"],
    minlength: [2, "Name should be at least 2 characters long"],
    maxlength: [20, "Name should be maximal 20 characters long"],
  },
  email: {
    type: String,
    required: [true, "Email is required"],
    minlength: [10, "Email should be at least 10 characters long"],
  },
  hashedPassword: { type: String, required: true },
});

userSchema.index(
  { email: 1 },
  {
    collation: {
      locale: "en",
      strength: 2,
    },
  }
);

const User = model("User", userSchema);

module.exports = User;
