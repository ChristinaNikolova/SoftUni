function add(number) {
    let sum = 0;

    function add(num) {
        sum += num;

        return add;
    }

    add.toString = () => {
        return sum;
    }

    return add(number);
}

console.log(add(1));
console.log(add(1)(6)(-3));