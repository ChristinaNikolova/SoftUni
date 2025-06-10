type InputType<T> = T extends number
  ? number
  : T extends string
  ? string
  : never;

function conditionalNumber<T>(input: InputType<T>): void {
  console.log(typeof input === "number" ? input.toFixed(2) : input);
}

conditionalNumber<number>(20.3555);
conditionalNumber<string>("wow");
// TS error
// conditionalNumber<boolean>("a string");
// conditionalNumber<boolean>(30);
// conditionalNumber<number>("test");
