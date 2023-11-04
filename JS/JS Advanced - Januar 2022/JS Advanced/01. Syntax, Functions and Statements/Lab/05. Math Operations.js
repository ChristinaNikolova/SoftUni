function solve(firstNum, secondNum, operator) {
    const sum = (x, y) => x + y;
    const substract = (x, y) => x - y;
    const multiply = (x, y) => x * y;
    const division = (x, y) => x / y;
    const remainder = (x, y) => x % y;
    const exponentiation = (x, y) => x ** y;

    let result = 0;

    switch (operator) {
        case '+':
            result = sum(firstNum, secondNum);
            break;
        case '-':
            result = substract(firstNum, secondNum);
            break;
        case '*':
            result = multiply(firstNum, secondNum);
            break;
        case '/':
            result = division(firstNum, secondNum);
            break;
        case '%':
            result = remainder(firstNum, secondNum);
            break;
        case '**':
            result = exponentiation(firstNum, secondNum);
            break;
    }

    console.log(result);
}

solve(5, 6, '+');
solve(3, 5.5, '*');