function solve(firstNum, secondNum) {
    while (firstNum !== secondNum) {
        if (firstNum > secondNum) {
            firstNum -= secondNum;
        } else {
            secondNum -= firstNum;
        }
    }

    console.log(firstNum);
}

solve(15, 5);
solve(2154, 458);