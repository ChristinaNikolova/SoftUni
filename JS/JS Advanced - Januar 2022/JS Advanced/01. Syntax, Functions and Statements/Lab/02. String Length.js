function solve(first, second, third) {
    const sumLengths = first.length + second.length + third.length;
    const averageLength = Math.floor(sumLengths / 3);

    console.log(sumLengths);
    console.log(averageLength);
}

solve('chocolate', 'ice cream', 'cake');
solve('pasta', '5', '22.3');