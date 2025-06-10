enum TravelVacation {
  Abroad = "Abroad",
  InCountry = "InCountry",
}

enum MountainVacation {
  Ski = "Ski",
  Hiking = "Hiking",
}

enum BeachVacation {
  Pool = "Pool",
  Sea = "Sea",
  ScubaDiving = "ScubaDiving",
}

interface Holiday {
  set start(val: Date);
  set end(val: Date);
  getInfo(): string;
}

interface VacationManager<T, V> {
  reserveVacation(holiday: T, vacationType: V): void;
  listReservations(): string;
}

class PlannedHoliday implements Holiday {
  private _start!: Date;
  private _end!: Date;

  constructor(start: Date, end: Date) {
    this.start = start;
    this.end = end;
  }

  set start(val: Date) {
    if (val > this._end) {
      throw new Error("Start date cannot be after end date");
    }
    this._start = val;
  }

  set end(val: Date) {
    if (val < this._start) {
      throw new Error("End date cannot be before start date");
    }
    this._end = val;
  }

  getInfo(): string {
    return `Holiday: ${this._start.getDate()}/${
      this._start.getMonth() + 1
    }/${this._start.getFullYear()} - ${this._end.getDate()}/${
      this._end.getMonth() + 1
    }/${this._end.getFullYear()}`;
  }
}

class HolidayManager<
  T extends Holiday,
  V extends TravelVacation | MountainVacation | BeachVacation
> implements VacationManager<T, V>
{
  private vacantions: Map<T, V>;

  constructor() {
    this.vacantions = new Map<T, V>();
  }

  reserveVacation(holiday: T, vacationType: V): void {
    this.vacantions.set(holiday, vacationType);
  }

  listReservations(): string {
    return Array.from(this.vacantions)
      .map((x) => `${x[0].getInfo()} => ${x[1]}`)
      .join("\n");
  }
}

let holiday1 = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
let holiday2 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2025, 3, 17));
let holidayManager1 = new HolidayManager<Holiday, TravelVacation>();
holidayManager1.reserveVacation(holiday1, TravelVacation.Abroad);
holidayManager1.reserveVacation(holiday2, TravelVacation.InCountry);
console.log(holidayManager1.listReservations());

let holiday3 = new PlannedHoliday(
  new Date(2022, 10, 11),
  new Date(2022, 10, 18)
);
let holiday4 = new PlannedHoliday(new Date(2024, 5, 18), new Date(2024, 5, 22));
let holidayManager2 = new HolidayManager<Holiday, BeachVacation>();
holidayManager2.reserveVacation(holiday3, BeachVacation.ScubaDiving);
holidayManager2.reserveVacation(holiday4, BeachVacation.Sea);
console.log(holidayManager2.listReservations());

// Run time error
// let holiday5 = new PlannedHoliday(new Date(2021, 3, 14), new Date(2020, 3, 17));
// let holiday6 = new PlannedHoliday(new Date(2024, 2, 1), new Date(2024, 1, 4));

let holiday7 = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
// Run time error
// let holiday8 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2024, 3, 17));
let holidayManager3 = new HolidayManager<Holiday, MountainVacation>();
// TS error
// holidayManager3.reserveVacation(holiday7, BeachVacation.ScubaDiving);
// holidayManager3.reserveVacation(holiday8, TravelVacation.InCountry);
console.log(holidayManager3.listReservations());
