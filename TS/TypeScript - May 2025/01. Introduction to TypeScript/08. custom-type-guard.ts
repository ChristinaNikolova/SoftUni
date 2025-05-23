function isNonEmptyStringArray(input: unknown): input is string[] {
  return (
    input != undefined &&
    Array.isArray(input) &&
    input.length > 0 &&
    input.every((x) => typeof x === "string")
  );
}

const arr = [
  {},
  { test: "one" },
  [],
  undefined,
  null,
  [12, 13],
  ["test", 123],
  ["a", "b", "c"],
];

arr.forEach((el) => {
  if (isNonEmptyStringArray(el)) {
    console.log(el);
    console.log(el.length);
  }
});
