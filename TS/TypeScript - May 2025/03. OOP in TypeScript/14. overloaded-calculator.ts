class Calculator {
  calculate(operation: "power" | "log", num1: number, num2: number): number;

  calculate(
    operation: "add" | "subtract" | "multiply" | "divide",
    num1: number,
    num2: number,
    num3?: number,
    num4?: number
  ): number;

  calculate(
    operation: "power" | "log" | "add" | "subtract" | "multiply" | "divide",
    num1: number,
    num2: number,
    num3?: number,
    num4?: number
  ): number {
    let result;
    const validNumbers = [num1, num2, num3, num4].filter(
      (x) => x !== undefined
    );

    switch (operation) {
      case "power":
        result = Math.pow(num1, num2);
        break;
      case "log":
        result = Math.log(num1) / Math.log(num2);
        break;
      case "add":
        result = validNumbers.reduce((acc, curr) => acc + curr);
        break;
      case "subtract":
        result = validNumbers.reduce((acc, curr) => acc - curr);
        break;
      case "multiply":
        result = validNumbers.reduce((acc, curr) => acc * curr);
        break;
      case "divide":
        result = validNumbers.reduce((acc, curr) => acc / curr);
        break;
    }

    return result;
  }
}

const calc1 = new Calculator();
console.log(calc1.calculate("power", 2, 3));
console.log(calc1.calculate("power", 4, 1 / 2));
console.log(calc1.calculate("log", 8, 2));
console.log(calc1.calculate("add", 10, 5));
console.log(calc1.calculate("add", 10, 5, 3));
console.log(calc1.calculate("subtract", 10, 5));
console.log(calc1.calculate("multiply", 2, 3, 4));
console.log(calc1.calculate("divide", 100, 5, 2, 2));

// TS error
// const calc2 = new Calculator();
// console.log(calc2.calculate("power", 2, 3, 2));
// console.log(calc2.calculate("add", 2));
// console.log(calc2.calculate("log", 2, 3, 4, 5));
// console.log(calc2.calculate("multiply", 2, 3, 4, 5, 6));
