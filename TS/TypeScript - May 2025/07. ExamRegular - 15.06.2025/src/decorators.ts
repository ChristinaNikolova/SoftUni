export function decorator1<T extends new (...args: any[]) => {}>(target: T) {}

export function decorator2(
  target: any,
  propName: string,
  descriptor: PropertyDescriptor
) {
  const originalGetter = descriptor.get;

  descriptor.get = function () {
    return originalGetter?.call(this) * 1.2;
  };

  return descriptor;
}

export function decorator3(
  target: any,
  propName: string,
  descriptor: PropertyDescriptor
) {
  const originalGetter = descriptor.get;

  descriptor.get = function () {
    return originalGetter?.call(this) * 1.2;
  };

  return descriptor;
}

export function decorator4(
  target: any,
  methodName: string,
  paramIndex: number
) {}

export function decorator5<T extends abstract new (...args: any[]) => {}>(
  target: T
) {
  abstract class ExtendedClass extends target {
    public static readonly MotelName = "Monthly Motel";
  }

  return ExtendedClass;
}
