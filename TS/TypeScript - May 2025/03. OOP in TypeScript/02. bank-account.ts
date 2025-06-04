class BankAccount {
  private balance: number;

  constructor(balance: number) {
    this.balance = balance;
  }

  deposit(amount: number): void {
    this.balance += amount;
  }

  withdraw(amount: number): void {
    if (this.balance >= amount) {
      this.balance -= amount;
    }
  }

  getBalance(): number {
    return this.balance;
  }
}

const account1 = new BankAccount(100);
account1.deposit(50);
account1.withdraw(30);
console.log(account1.getBalance());

const account2 = new BankAccount(20);
account2.withdraw(30);
console.log(account2.getBalance());
