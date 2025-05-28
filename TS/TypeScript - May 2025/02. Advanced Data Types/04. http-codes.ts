function startHttpCodes(): void {
  type httpResponse = {
    code: 200 | 201 | 301;
    text: string;
  };

  type httpResponseExtended = {
    code: 400 | 404 | 500;
    text: string;
    printChars?: number;
  };

  function printResponseText(res: httpResponse | httpResponseExtended): void {
    console.log(
      "printChars" in res ? res.text.slice(0, res.printChars) : res.text
    );
  }

  printResponseText({ code: 200, text: "OK" });
  printResponseText({ code: 201, text: "Created" });
  printResponseText({ code: 400, text: "Bad Request", printChars: 4 });
  printResponseText({ code: 404, text: "Not Found" });
  printResponseText({ code: 404, text: "Not Found", printChars: 3 });
  printResponseText({
    code: 500,
    text: "Internal Server Error",
    printChars: 1,
  });
}

startHttpCodes();
