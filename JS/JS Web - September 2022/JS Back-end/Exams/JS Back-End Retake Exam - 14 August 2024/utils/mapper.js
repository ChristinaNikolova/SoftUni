function mapErrors(error) {
  if (error.name == "ValidationError") {
    return Object.values(error.errors).map((v) => v.message);
  } else if (Array.isArray(error)) {
    return error.map((x) => x.msg);
  } else {
    return error.message.split("\n");
  }
}

function deviceViewModel(device) {
  return {
    _id: device._id,
    brand: device.brand,
    model: device.model,
    screenSize: device.screenSize,
    hardDisk: device.hardDisk,
    ram: device.ram,
    operatingSystem: device.operatingSystem,
    cpu: device.cpu,
    gpu: device.gpu,
    price: device.price,
    color: device.color,
    weight: device.weight,
    image: device.image,
    owner: device.owner,
    preferredList: device.preferredList,
  };
}

module.exports = {
  mapErrors,
  deviceViewModel,
};
