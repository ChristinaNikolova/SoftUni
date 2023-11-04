function solve(arr, num) {
    const rotationsCount = num % arr.length;

    for (let i = 0; i < rotationsCount; i++) {
        const currentElement = arr.pop();
        arr.unshift(currentElement);
    }

    return arr.join(' ');
}

console.log(solve(['1', '2', '3', '4'], 2));
console.log(solve(['Banana', 'Orange', 'Coconut', 'Apple'], 15));