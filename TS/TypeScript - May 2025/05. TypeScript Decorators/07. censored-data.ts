export {};

class MockCensorService<T extends { [key: string]: any }> {
  constructor(private censoredProperties: string[]) {}

  censorProperties(items: T[]) {
    let censoredItems = items.slice();

    censoredItems.forEach((i) => {
      this.censoredProperties.forEach((prop) => {
        delete i[prop];
      });
    });

    return censoredItems;
  }
}

// let userCensorService = new MockCensorService<User>(["creditCardNumber"]);
// let employeeCensorService = new MockCensorService<Employee>([
//   "birthday",
//   "salary",
// ]);

let userCensorService = new MockCensorService<User>(["age"]);
let employeeCensorService = new MockCensorService<Employee>(["salary"]);

function log(target: any, methodName: string, descriptor: PropertyDescriptor) {
  const originalMethod = descriptor.value;

  descriptor.value = function () {
    console.log(`Method ${methodName} called successfully `);

    return originalMethod.call(this);
  };

  return descriptor;
}

function createdOnExtension<T extends new (...args: any[]) => {}>(target: T) {
  return class extends target {
    createdOn = new Date();
  };
}

function getLatest(seconds: number) {
  return function (
    target: any,
    methodName: string,
    descriptor: PropertyDescriptor
  ) {
    const originalMethod = descriptor.value;

    descriptor.value = function () {
      return originalMethod
        .call(this)
        .filter(
          (x: any) =>
            new Date().getTime() - x.createdOn.getTime() <= seconds * 1000
        );
    };

    return descriptor;
  };
}

function getCensoredProps<T extends { [key: string]: any }>(
  service: MockCensorService<T>
) {
  return function (
    target: any,
    methodName: string,
    descriptor: PropertyDescriptor
  ) {
    const originalMethod = descriptor.value;

    descriptor.value = function () {
      const items = originalMethod.call(this);
      const result = service.censorProperties(items);

      return result;
    };

    return descriptor;
  };
}

@createdOnExtension
class User {
  constructor(
    public name: string,
    public age: number,
    public creditCardNumber: string
  ) {}

  getInfo() {
    return `${this.name}, Age: ${this.age} CreditCardNumber: ${this.creditCardNumber}`;
  }
}

@createdOnExtension
class Employee {
  constructor(
    public name: string,
    public birthday: Date,
    public salary: number
  ) {}

  getInfo() {
    return `${
      this.name
    }, Birthday: ${this.birthday?.toLocaleDateString()} Salary: ${this.salary}`;
  }
}

class UsersService {
  private _users: User[];
  private _employees: Employee[];

  constructor(users: User[], employees: Employee[]) {
    this._users = users;
    this._employees = employees;
  }

  addUser(user: User) {
    this._users.push(user);
  }

  addEmployee(employee: Employee) {
    this._employees.push(employee);
  }

  @getLatest(5)
  @getCensoredProps(userCensorService)
  getUsers() {
    return this._users;
  }

  @log
  @getLatest(10)
  @getCensoredProps(employeeCensorService)
  getEmployees() {
    return this._employees;
  }
}

const user1 = new User("John Does", 30, "ABCD-1234");
const user2 = new User("Benny Tres", 23, "EFGH-5678");
const emp1 = new Employee("Sarah Connor", new Date(1964, 4, 15), 2500);
const emp2 = new Employee("Arnold Schwarzenegger", new Date(1947, 6, 30), 3500);
let usersService = new UsersService([user1, user2], [emp1, emp2]);
let users = usersService.getUsers();
console.log(users.map((x) => x.getInfo()));
let employees = usersService.getEmployees();
console.log(employees.map((x) => x.getInfo()));

//7 seconds later
setTimeout(() => {
  const user3 = new User("Jimmy Quatro", 27, "IJKL-9012");
  const emp3 = new Employee("Kyle Reese", new Date(2004, 0, 1), 2000);
  usersService.addUser(user3);
  usersService.addEmployee(emp3);
  let users = usersService.getUsers();
  console.log(users.map((x) => x.getInfo()));
  let employees = usersService.getEmployees();
  console.log(employees.map((x) => x.getInfo()));
}, 7000);

//15 seconds later
setTimeout(() => {
  let users = usersService.getUsers();
  console.log(users.map((x) => x.getInfo()));
  let employees = usersService.getEmployees();
  console.log(employees.map((x) => x.getInfo()));
}, 15000);
