const Device = require("../models/Device");

async function getLastThree() {
  return Device.find({}).sort({ createdAt: -1 }).limit(3);
}

async function getAll() {
  return Device.find({});
}

async function getById(id) {
  return Device.findById(id);
}

async function create(device) {
  return new Device(device).save();
}

async function prefer(deviceId, userId) {
  const device = await Device.findById(deviceId);
  device.preferredList.push(userId);
  return device.save();
}

async function deleteById(id) {
  return Device.findByIdAndDelete(id);
}

async function edit(id, updatedDevice) {
  const device = await Device.findById(id);

  device.brand = updatedDevice.brand;
  device.model = updatedDevice.model;
  device.hardDisk = updatedDevice.hardDisk;
  device.screenSize = updatedDevice.screenSize;
  device.ram = updatedDevice.ram;
  device.operatingSystem = updatedDevice.operatingSystem;
  device.cpu = updatedDevice.cpu;
  device.gpu = updatedDevice.gpu;
  device.price = updatedDevice.price;
  device.color = updatedDevice.color;
  device.weight = updatedDevice.weight;
  device.image = updatedDevice.image;

  return device.save();
}

async function getUserDevices(userId) {
  return Device.find({ owner: userId });
}

async function getUserPreferredDevices(userId) {
  return Device.find({ preferredList: userId });
}

module.exports = {
  getAll,
  create,
  getById,
  prefer,
  getLastThree,
  deleteById,
  edit,
  getUserDevices,
  getUserPreferredDevices,
};
