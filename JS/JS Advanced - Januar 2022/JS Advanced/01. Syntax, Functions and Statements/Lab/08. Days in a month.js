function solve(month, year) {
    const date = new Date(year, month, 0);
    const daysInMonth = date.getDate();

    console.log(daysInMonth);
}

solve(1, 2012);
solve(2, 2021);