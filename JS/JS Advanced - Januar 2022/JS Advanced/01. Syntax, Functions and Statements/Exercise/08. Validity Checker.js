function solve(x1, y1, x2, y2) {
    const firstCheckNum = getValidityNumber(x1, y1, 0, 0);
    const secondCheckNum = getValidityNumber(x2, y2, 0, 0);
    const thirdCheckNum = getValidityNumber(x1, y1, x2, y2);

    printValidity(firstCheckNum, x1, y1, 0, 0);
    printValidity(secondCheckNum, x2, y2, 0, 0);
    printValidity(thirdCheckNum, x1, y1, x2, y2);

    function getValidityNumber(first, second, third, fourt) {
        const number = Math.sqrt(Math.pow(third - first, 2) + Math.pow(fourt - second, 2));
        return number;
    }

    function printValidity(number, x1, y1, x2, y2) {
        let messageToPrint = `{${x1}, ${y1}} to {${x2}, ${y2}} is `;
        messageToPrint += Number.isInteger(number) ? 'valid' : 'invalid';

        console.log(messageToPrint);
    }
}

solve(3, 0, 0, 4);
solve(2, 1, 1, 1);