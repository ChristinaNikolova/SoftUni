function solve(num) {
    const numAsString = num.toString();
    let areSame = true;
    let sumDigits = Number(numAsString[0]);

    for (let i = 1; i < numAsString.length; i++) {
        const currentNum = numAsString[i];
        const prevNum = numAsString[i - 1];

        if (currentNum !== prevNum) {
            areSame = false;
        }

        sumDigits += Number(currentNum);
    }

    console.log(areSame);
    console.log(sumDigits);
}

solve(2222222);
solve(1234);