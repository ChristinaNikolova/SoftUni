function convertArray(arr: string[]): [string, number] {
  const text = arr.join("");
  return [text, text.length];
}

console.log(convertArray(["How", "are", "you?"]));
console.log(
  convertArray(["Today", " is", " a ", "nice", " ", "day for ", "TypeScript"])
);
