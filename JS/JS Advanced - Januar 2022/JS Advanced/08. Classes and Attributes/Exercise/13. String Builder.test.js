const StringBuilder = require('./13. String Builder');
const assert = require('chai').assert;

describe("StringBuilder class behavior", () => {
    let actualResult;
    let expectedResult;
    let sb;

    beforeEach(() => {
        actualResult = null;
        expectedResult = null;
        sb = new StringBuilder("test");
    });

    describe("constructor behavior", () => {
        it("check if instance have all methods", () => {
            assert.isTrue(Object.getPrototypeOf(sb).hasOwnProperty("append"));
            assert.isTrue(Object.getPrototypeOf(sb).hasOwnProperty("prepend"));
            assert.isTrue(Object.getPrototypeOf(sb).hasOwnProperty("insertAt"));
            assert.isTrue(Object.getPrototypeOf(sb).hasOwnProperty("remove"));
            assert.isTrue(Object.getPrototypeOf(sb).hasOwnProperty("toString"));
        });

        it("check instance with valid string - not empty", () => {
            actualResult = sb._stringArray;
            expectedResult = ["t", "e", "s", "t"];

            assert.deepEqual(actualResult, expectedResult);
        });

        it("check instance with valid string - empty", () => {
            let secondSb = new StringBuilder();

            actualResult = secondSb._stringArray;
            expectedResult = [];

            assert.deepEqual(actualResult, expectedResult);
        });

        it("check instance with invalid string", () => {
            actualResult = () => new StringBuilder(1223);
            expectedResult = "Argument must be string";

            assert.throw(actualResult, expectedResult);
        });
    });

    describe("append() behavior", () => {
        it("check with invalid input - not a string", () => {
            actualResult = () => sb.append(123);
            expectedResult = "Argument must be string";

            assert.throw(actualResult, expectedResult);
        });

        it("check with valid string input", () => {
            sb.append("one");

            actualResult = sb._stringArray;
            expectedResult = ["t", "e", "s", "t", "o", "n", "e"];

            assert.deepEqual(actualResult, expectedResult);
        });
    });

    describe("prepend() behavior", () => {
        it("check with invalid input - not a string", () => {
            actualResult = () => sb.prepend(123);
            expectedResult = "Argument must be string";

            assert.throw(actualResult, expectedResult);
        });

        it("check with valid string input", () => {
            sb.prepend("one");

            actualResult = sb._stringArray;
            expectedResult = ["o", "n", "e", "t", "e", "s", "t"];

            assert.deepEqual(actualResult, expectedResult);
        });
    });

    describe("insertAt() behavior", () => {
        it("check with invalid input - not a string", () => {
            actualResult = () => sb.insertAt(12, 12);
            expectedResult = "Argument must be string";

            assert.throw(actualResult, expectedResult);
        });

        it("check with valid string input", () => {
            sb.insertAt("one", 2);

            actualResult = sb._stringArray;
            expectedResult = ["t", "e", "o", "n", "e", "s", "t"];

            assert.deepEqual(actualResult, expectedResult);
        });
    });

    describe("remove() behavior", () => {
        it("check with valid arguments", () => {
            sb.remove(1, 2);

            actualResult = sb._stringArray;
            expectedResult = ["t", "t"];

            assert.deepEqual(actualResult, expectedResult);
        });
    });

    describe("toString() behavior", () => {
        it("check with valid arguments", () => {
            actualResult = sb.toString();
            expectedResult = "test";

            assert.equal(actualResult, expectedResult);
        });
    });
});