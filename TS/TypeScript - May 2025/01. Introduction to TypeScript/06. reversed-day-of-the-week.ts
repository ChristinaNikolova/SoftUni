function printReversedWeekDay(weekDay: string): void {
  enum Days {
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
  }

  console.log(Days[weekDay as keyof typeof Days] || "error");
}

printReversedWeekDay("Monday");
printReversedWeekDay("Friday");
printReversedWeekDay("Invalid");
