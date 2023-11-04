function solve(input) {
    const typeOfInput = typeof input;

    if (typeOfInput !== 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfInput}.`);
        return;
    }

    const radius = Number(input);
    const circleArea = Math.PI * Math.pow(radius, 2);

    console.log(circleArea.toFixed(2));
}

solve(5);
solve('name');