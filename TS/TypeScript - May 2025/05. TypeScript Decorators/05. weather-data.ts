function cacheData(
  target: any,
  methodName: string,
  descriptor: PropertyDescriptor
) {
  let cachedData: string[] = [];
  let lastRead: Date | null = null;

  const originalMethod = descriptor.value;

  descriptor.value = function () {
    if (!lastRead || new Date().getTime() - lastRead.getTime() > 5000) {
      const realData = originalMethod.call(this);
      cachedData = realData.slice();
      lastRead = new Date();

      return realData;
    }

    console.log("Returned from cache");

    return cachedData;
  };

  return descriptor;
}

class MockWeatherDataService {
  private weatherData: string[] = [
    "Sunny 8° to 20°",
    "Partially Cloudy 7° to 19°",
    "Sunny 5° to 18°",
  ];

  addWeatherData(data: string) {
    this.weatherData.push(data);
  }

  @cacheData
  getWeatherData() {
    return this.weatherData;
  }
}

let service = new MockWeatherDataService();
console.log(service.getWeatherData());
console.log(service.getWeatherData());
service.addWeatherData("Partially Cloudy 5° to 11°");
console.log(service.getWeatherData());

//7 seconds later
setTimeout(() => console.log(service.getWeatherData()), 7000);
