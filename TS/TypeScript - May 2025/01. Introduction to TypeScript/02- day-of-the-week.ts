function printWeekDay(weekDayNum: number): void {
  enum Days {
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
  }

  console.log(Days[weekDayNum] || "error");
}

printWeekDay(1);
printWeekDay(5);
printWeekDay(-1);
