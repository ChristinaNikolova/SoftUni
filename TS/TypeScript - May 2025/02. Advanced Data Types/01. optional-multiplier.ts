function optionalMultiplier(
  first?: string | number,
  second?: string | number,
  third?: string | number
): number {
  const num1 = first ? Number(first) : 1;
  const num2 = second ? Number(second) : 1;
  const num3 = third ? Number(third) : 1;

  return num1 * num2 * num3;
}

console.log(optionalMultiplier("3", 5, "10"));
console.log(optionalMultiplier("2", "2"));
console.log(optionalMultiplier(undefined, 2, 3));
console.log(optionalMultiplier(7, undefined, "2"));
console.log(optionalMultiplier());
