const mongoose = require("mongoose");

const dbName = "home-cooking-recipes";
const connectionString = `mongodb://localhost:27017/${dbName}`;

module.exports = async (app) => {
  try {
    await mongoose.connect(connectionString);
    console.log("Database connected");
  } catch (err) {
    console.error("Error connecting to database " + err);
    process.exit(1);
  }
};
