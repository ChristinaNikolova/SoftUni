function solve(arr) {
    const firstNum = Number(arr[0]);
    const lastNum = Number(arr[arr.length - 1]);
    const sum = firstNum + lastNum;

    return sum;
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));