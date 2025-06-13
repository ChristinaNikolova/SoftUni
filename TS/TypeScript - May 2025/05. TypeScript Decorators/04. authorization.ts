export {};

class MockAuthrizationService {
  constructor(
    private userRole: "Guest" | "PersonalDataAdministrator" | "Admin"
  ) {}

  canViewData(property: string) {
    switch (this.userRole) {
      case "Admin":
        return true;

      case "PersonalDataAdministrator":
        return ["name", "age"].includes(property);

      default:
        return false;
    }
  }
}

// let mockAuthorizationService = new MockAuthrizationService("Admin");
// let mockAuthorizationService = new MockAuthrizationService(
//   "PersonalDataAdministrator"
// );
let mockAuthorizationService = new MockAuthrizationService("Guest");

function isAuthorized(service: MockAuthrizationService) {
  return function (
    target: any,
    propName: string,
    descriptor: PropertyDescriptor
  ) {
    const originalGetter = descriptor.get;

    descriptor.get = function () {
      const hasAccess = service.canViewData(propName);

      if (!hasAccess) {
        throw new Error("You are not authorized to view this information");
      }

      return originalGetter?.call(this);
    };

    return descriptor;
  };
}

class User {
  private _name: string;
  private _age: number;
  private _creditCardNumber: string;

  constructor(name: string, age: number, creditCardNumber: string) {
    this._name = name;
    this._age = age;
    this._creditCardNumber = creditCardNumber;
  }

  @isAuthorized(mockAuthorizationService)
  get name() {
    return this._name;
  }

  @isAuthorized(mockAuthorizationService)
  get age() {
    return this._age;
  }

  @isAuthorized(mockAuthorizationService)
  get creditCardNumber() {
    return this._creditCardNumber;
  }
}

const user1 = new User("John Doe", 30, "ABCD-1234");
console.log(user1.name);
console.log(user1.age);
console.log(user1.creditCardNumber);
