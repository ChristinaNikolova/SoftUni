class Product {
  private static productCount = 0;
  readonly id: number;
  private _name!: string;
  private _price!: number;

  constructor(name: string, price: number) {
    Product.productCount++;
    this.id = Product.productCount;
    this.name = name;
    this.price = price;
  }

  get name() {
    return this._name;
  }

  set name(newValue: string) {
    if (newValue.length < 1) {
      throw new Error("Name should be at least 1 character long");
    }
    this._name = newValue;
  }

  get price() {
    return this._price;
  }

  set price(newValue: number) {
    if (newValue <= 0) {
      throw new Error("Price should be a positive number");
    }
    this._price = newValue;
  }

  getDetails(): string {
    return `ID: ${this.id}, Name: ${this.name}, Price: $${this.price}`;
  }
}

class Inventory {
  private products: Product[];

  constructor() {
    this.products = [];
  }

  addProduct(product: Product): void {
    this.products.push(product);
  }

  listProducts(): string {
    return (
      `${this.products.map((x) => x.getDetails()).join("\n")}` +
      "\n" +
      `Total products created: ${this.products.length}`
    );
  }
}

const inventory = new Inventory();
const product1 = new Product("Laptop", 1200);
const product2 = new Product("Phone", 800);
inventory.addProduct(product1);
inventory.addProduct(product2);
console.log(inventory.listProducts());

// Product.productCount = 10; TS error
// const product3 = new Product("", 800); Run time error
// const product4 = new Product("Phone", 0); Run time error
// product3.id = 5; TS error
