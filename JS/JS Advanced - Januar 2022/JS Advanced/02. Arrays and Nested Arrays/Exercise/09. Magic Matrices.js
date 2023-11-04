function solve(matrix) {
    const matrixLength = matrix.length;
    const targetSum = calculateSum(matrix, 1);
    let isMagical = true;

    for (let i = 1; i < matrixLength; i++) {
        const currentSum = calculateSum(matrix, i);

        if (targetSum !== currentSum) {
            isMagical = false;
            break;
        }
    }

    if (isMagical) {
        for (let i = 0; i < matrixLength; i++) {
            let currentSum = 0;

            for (let j = 0; j < matrixLength; j++) {
                currentSum += matrix[j][i];
            }

            if (targetSum !== currentSum) {
                isMagical = false;
                break;
            }
        }
    }

    return isMagical;

    function calculateSum(matrix, index) {
        const sum = matrix[index].reduce((acc, curr) => {
            return acc + curr;
        }, 0);

        return sum;
    }
}

console.log(solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));

console.log(solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]));

console.log(solve([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]));