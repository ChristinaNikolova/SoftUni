export {};

function validateName(minLength: number) {
  return function (
    target: any,
    propName: string,
    descriptor: PropertyDescriptor
  ) {
    const originalSetter = descriptor.set;

    descriptor.set = function (val: string) {
      if (val.length < minLength) {
        throw new Error(
          `Name must have a min length of ${minLength} characters`
        );
      }

      originalSetter?.call(this, val);
    };

    return descriptor;
  };
}

function validateAge(min: number, max: number) {
  return function (
    target: any,
    propName: string,
    descriptor: PropertyDescriptor
  ) {
    const originalSetter = descriptor.set;

    descriptor.set = function (val: number) {
      if (val < min || val > max) {
        throw new Error(`Age must be between ${min} and ${max}`);
      }

      originalSetter?.call(this, val);
    };

    return descriptor;
  };
}

function validatePassword(pattern: RegExp) {
  return function (
    target: any,
    propName: string,
    descriptor: PropertyDescriptor
  ) {
    const originalSetter = descriptor.set;

    descriptor.set = function (val: string) {
      if (!val.match(pattern)) {
        throw new Error(`Password needs to match ${pattern}`);
      }

      originalSetter?.call(this, val);
    };

    return descriptor;
  };
}

class User {
  private _name!: string;
  private _age!: number;
  private _password!: string;

  constructor(name: string, age: number, password: string) {
    this.name = name;
    this.age = age;
    this.password = password;
  }

  get name() {
    return this._name;
  }

  // @validateName(1)
  @validateName(3)
  set name(val: string) {
    this._name = val;
  }

  get age() {
    return this._age;
  }

  // @validateAge(1, 150)
  @validateAge(1, 100)
  set age(val: number) {
    this._age = val;
  }

  // @validatePassword(new RegExp(/^[a-zA-Z0-9!@]+$/g))
  @validatePassword(new RegExp(/^[a-zA-Z0-9]+$/g))
  set password(val: string) {
    this._password = val;
  }
}

// minLength = 1
// min = 1, max = 150
// regex = /^[a-zA-Z0-9!@]+$/g

// minLength = 3
// min = 1, max = 100
// regex = /^[a-zA-Z0-9]+$/g

// let user = new User("John", 130, "hardPassword12");
// let user2 = new User("John", 30, "!test");
// let user3 = new User("John", 25, "@werty");
// let user4 = new User("Jo", 20, "password123");
