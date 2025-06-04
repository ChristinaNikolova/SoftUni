class Counter {
  private static count = 0;

  static increment(): void {
    Counter.count++;
  }

  static getCount(): number {
    return Counter.count;
  }
}

Counter.increment();
Counter.increment();
console.log(Counter.getCount());
// TS error
// Counter.count = 10;
