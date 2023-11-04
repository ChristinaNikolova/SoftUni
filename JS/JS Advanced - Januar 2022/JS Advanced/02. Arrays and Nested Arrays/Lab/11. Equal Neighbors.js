function solve(matrix) {
    const matrixLength = matrix.length;
    let pairsCount = 0;

    for (let i = 0; i < matrixLength; i++) {
        const currentRow = matrix[i];

        for (let j = 0; j < currentRow.length - 1; j++) {
            const currentElement = currentRow[j];
            const nextElement = currentRow[j + 1];

            if (currentElement === nextElement) {
                pairsCount++;
            }
        }
    }

    for (let i = 0; i < matrixLength - 1; i++) {
        const currentRow = matrix[i];

        for (let j = 0; j < currentRow.length; j++) {
            const currentElement = currentRow[j];
            const nextElement = matrix[i + 1][j];

            if (currentElement === nextElement) {
                pairsCount++;
            }
        }
    }

    return pairsCount;
}

console.log(solve([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']
]));

console.log(solve([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']
]));