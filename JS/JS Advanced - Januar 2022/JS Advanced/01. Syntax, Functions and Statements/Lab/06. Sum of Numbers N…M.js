function solve(n, m) {
    const firstNum = Number(n);
    const secondNum = Number(m);
    let sum = 0;

    for (let i = firstNum; i <= secondNum; i++) {
        sum += i;
    }

    console.log(sum);
}

solve('1', '5');
solve('-8', '20');