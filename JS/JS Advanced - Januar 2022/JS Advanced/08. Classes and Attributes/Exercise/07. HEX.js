class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return '0x' + this.value.toString(16).toUpperCase();
    }

    plus(input) {
        const num = this.getNumber(input);
        return new Hex(this.value + num);
    }

    minus(input) {
        const num = this.getNumber(input);
        return new Hex(this.value - num);
    }

    parse(str) {
        return this.getNumber(str);
    }

    getNumber(input) {
        return typeof input === 'number' ? input : parseInt(input, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');
console.log(FF.parse('AAA')); 