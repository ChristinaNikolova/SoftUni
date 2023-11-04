function solve(numbers) {
    const result = numbers.reduce((acc, curr) => {
        if (curr < 0) {
            acc.unshift(curr);
        } else {
            acc.push(curr);
        }

        return acc;
    }, []);

    console.log(result.join('\n'));
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);