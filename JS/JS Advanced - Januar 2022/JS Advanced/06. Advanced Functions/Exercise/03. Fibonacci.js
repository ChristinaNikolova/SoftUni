function getFibonator() {
    let [currNum, nextNum] = [0, 1];

    function fib() {
        const sum = currNum + nextNum;
        
        currNum = nextNum;
        nextNum = sum;

        return currNum;
    }

    return fib.bind(this, currNum, nextNum);
}

let fib = getFibonator();
console.log(fib()); // 1 
console.log(fib()); // 1 
console.log(fib()); // 2 
console.log(fib()); // 3 
console.log(fib()); // 5 
console.log(fib()); // 8 
console.log(fib()); // 13 