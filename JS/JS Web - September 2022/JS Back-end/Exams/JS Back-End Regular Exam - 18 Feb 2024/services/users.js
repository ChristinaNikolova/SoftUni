const bcrypt = require("bcrypt");
const jsonwebtoken = require("jsonwebtoken");
const User = require("../models/User");

const jwt_secret = "my very very secret string";

async function login(email, password) {
  const user = await findByEmail(email);

  if (!user) {
    throw new Error("Incorect email or password");
  }

  const isMatch = await bcrypt.compare(password, user.hashedPassword);

  if (!isMatch) {
    throw new Error("Incorect email or password");
  }

  return createSession(user);
}

async function register(email, password) {
  const isUser = await findByEmail(email);

  if (isUser) {
    throw new Error("Email is already taken");
  }

  const hashedPassword = await bcrypt.hash(password, 10);
  const user = await User.create({
    email,
    hashedPassword,
  });

  return createSession(user);
}

async function findByEmail(email) {
  return User.findOne({ email }).collation({
    locale: "en",
    strength: 2,
  });
}

function createSession({ _id, email }) {
  const payload = {
    _id,
    email,
  };

  return jsonwebtoken.sign(payload, jwt_secret);
}

function verifyToken(token) {
  return jsonwebtoken.verify(token, jwt_secret);
}

module.exports = {
  login,
  register,
  verifyToken,
};
