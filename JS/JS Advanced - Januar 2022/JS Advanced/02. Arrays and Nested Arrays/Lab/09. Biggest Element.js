function solve(matrix) {
    const matrixLength = matrix.length;
    let maxNumber = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < matrixLength; i++) {
        const currentRow = matrix[i];
        const currentMaxNum = Math.max(...currentRow);

        if (maxNumber < currentMaxNum) {
            maxNumber = currentMaxNum;
        }
    }

    return maxNumber;
}

console.log(solve([
    [20, 50, 10],
    [8, 33, 145]
]));

console.log(solve([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]
]));