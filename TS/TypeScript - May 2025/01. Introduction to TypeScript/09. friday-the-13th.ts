function printFridayThe13th(arr: unknown[]): void {
  enum Months {
    January,
    February,
    March,
    April,
    May,
    June,
    Jule,
    August,
    September,
    October,
    November,
    December,
  }

  arr.forEach((date) => {
    if (date instanceof Date) {
      const day = date.getDate();
      const weekDayNum = date.getDay();

      if (day === 13 && weekDayNum === 5) {
        const month = Months[date.getMonth()];
        const year = date.getFullYear();

        console.log(`${day}-${month}-${year}`);
      }
    }
  });
}

printFridayThe13th([
  {},
  new Date(2025, 4, 13),
  null,
  new Date(2025, 5, 13),
  "13-09-2023",
  new Date(2025, 6, 13),
]);
printFridayThe13th([
  new Date(2024, 0, 13),
  new Date(2024, 1, 13),
  new Date(2024, 2, 13),
  new Date(2024, 3, 13),
  new Date(2024, 4, 13),
  new Date(2024, 5, 13),
  new Date(2024, 6, 13),
  new Date(2024, 7, 13),
  new Date(2024, 8, 13),
  new Date(2024, 9, 13),
  new Date(2024, 10, 13),
  new Date(2024, 11, 13),
]);
