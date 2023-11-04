class List {
    constructor() {
        this.numbers = [];
        this.size = this.numbers.length;
    }

    add(element) {
        this.numbers.push(element);
        this.size++;
        this.sortNumbers();
    }

    remove(index) {
        this.isIndexValid(index);
        this.numbers.splice(index, 1);
        this.size--;
    }

    get(index) {
        this.isIndexValid(index);
        return this.numbers[index];
    }

    sortNumbers() {
        this.numbers.sort((a, b) => a - b);
    }

    isIndexValid(index) {
        if (index < 0 || index >= this.size) {
            throw new Error('Invalid Index');
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1)); 