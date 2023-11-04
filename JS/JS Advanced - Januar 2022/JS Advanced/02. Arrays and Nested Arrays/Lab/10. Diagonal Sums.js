function solve(matrix) {
    const matrixLength = matrix.length;
    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;

    for (let i = 0; i < matrixLength; i++) {
        firstDiagonalSum += matrix[i][i];
        secondDiagonalSum += matrix[i][matrixLength - 1 - i];
    }

    console.log(firstDiagonalSum + ' ' + secondDiagonalSum);
}

solve([
    [20, 40],
    [10, 60]
]);

solve([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]
]);