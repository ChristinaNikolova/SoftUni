export function decorator1<T extends new (...args: any[]) => {}>(target: T) {
  return class extends target {
    protected _offset: number = 3;
  };
}

export function decorator2(
  target: any,
  methodName: string,
  descriptor: PropertyDescriptor
) {}

export function decorator3(
  target: any,
  methodName: string,
  descriptor: PropertyDescriptor
) {}

export function decorator4<T extends abstract new (...args: any[]) => {}>(
  target: T
) {
  abstract class ExtendedClass extends target {
    public static forbiddenSymbols: string[] = [
      "_",
      ",",
      ".",
      "!",
      "?",
      "-",
      ";",
      " ",
      `"`,
      `'`,
    ];
  }

  return ExtendedClass;
}
