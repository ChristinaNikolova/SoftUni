interface CountableSet<T> {
  add(item: T): void;
  remove(item: T): void;
  contains(item: T): boolean;
  getNumberOfCopies(item: T): number;
}

class CountedSet<T> implements CountableSet<T> {
  private list: Map<T, number>;

  constructor() {
    this.list = new Map<T, number>();
  }

  add(item: T): void {
    const currentCount = this.getCurrentCount(item);
    this.list.set(item, currentCount + 1);
  }

  remove(item: T): void {
    const currentCount = this.getCurrentCount(item);
    if (currentCount) {
      this.list.set(item, currentCount - 1);
    }
  }

  contains(item: T): boolean {
    return !!this.getCurrentCount(item);
  }

  getNumberOfCopies(item: T): number {
    return this.getCurrentCount(item);
  }

  private getCurrentCount(item: T): number {
    return this.list.get(item) ?? 0;
  }
}

let countedSet = new CountedSet<string>();
countedSet.add("test");
countedSet.add("test");
console.log(countedSet.contains("test"));
console.log(countedSet.getNumberOfCopies("test"));
countedSet.remove("test");
countedSet.remove("test");
countedSet.remove("test");
console.log(countedSet.getNumberOfCopies("test"));
console.log(countedSet.contains("test"));

let codesCounterSet = new CountedSet<200 | 301 | 404 | 500>();
codesCounterSet.add(404);
codesCounterSet.add(200);
console.log(codesCounterSet.contains(404));
console.log(codesCounterSet.getNumberOfCopies(200));
// TS error
// codesCounterSet.add(205);
// codesCounterSet.getNumberOfCopies(350);
