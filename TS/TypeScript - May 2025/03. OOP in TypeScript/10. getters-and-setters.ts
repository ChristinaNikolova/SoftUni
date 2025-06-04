class User {
  private _username!: string;

  constructor(username: string) {
    this.username = username;
  }

  get username() {
    return this._username;
  }

  set username(newValue: string) {
    if (newValue.length < 3) {
      throw new Error("Username should be at least 3 characters long");
    }
    this._username = newValue;
  }
}

const user1 = new User("Martin");
user1.username = "johnDoe";
console.log(user1.username);

// Run time error
// const user2 = new User("jo");

// Run time error
// const user3 = new User("Martin");
// user3.username = "Do";
