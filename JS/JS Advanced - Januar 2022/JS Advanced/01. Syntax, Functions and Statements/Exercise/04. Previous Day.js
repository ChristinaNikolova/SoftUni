function solve(year, month, day) {
    const format = `${year}-${month}-${day}`;
    const inputDate = new Date(format);

    const prevDate = new Date(inputDate.setDate(inputDate.getDate() - 1));
    const formatDate = `${prevDate.getFullYear()}-${prevDate.getMonth() + 1}-${prevDate.getDate()}`;

    return formatDate;
}

console.log(solve(2016, 9, 30));
console.log(solve(2016, 10, 1));