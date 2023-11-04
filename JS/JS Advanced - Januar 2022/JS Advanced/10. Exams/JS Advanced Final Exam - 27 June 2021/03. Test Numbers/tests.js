const testNumbers = require('./testNumbers');
const assert = require('chai').assert;

describe('testNumbers obj tests', () => {
    describe('sumNumbers func tests', () => {
        it('should return correct sum when the two numbers are positive', () => {
            const actualResult = testNumbers.sumNumbers(12, 10.55);
            const expectedResult = 22.55;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct sum when the two numbers are negative', () => {
            const actualResult = testNumbers.sumNumbers(-12, -10.55);
            const expectedResult = -22.55;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct sum when first number is positive but second number is negative', () => {
            const actualResult = testNumbers.sumNumbers(12, -10.55);
            const expectedResult = 1.45;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct sum when numbers are doubles', () => {
            const actualResult = testNumbers.sumNumbers(12.525525, -10.55);
            const expectedResult = 1.98;

            assert.equal(actualResult, expectedResult);
        });

        it('should return undefined when first number is passed as string', () => {
            const actualResult = testNumbers.sumNumbers('12.525525', -10.55);

            assert.isUndefined(actualResult);
        });

        it('should return undefined when second number is passed as string', () => {
            const actualResult = testNumbers.sumNumbers(12.525525, '-10.55');

            assert.isUndefined(actualResult);
        });
    });

    describe('numberChecker func tests', () => {
        it('should return correct result when number is odd', () => {
            const actualResult = testNumbers.numberChecker(1);
            const expectedResult = 'The number is odd!';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when number is even', () => {
            const actualResult = testNumbers.numberChecker(2);
            const expectedResult = 'The number is even!';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when number is passed as string', () => {
            const actualResult = testNumbers.numberChecker('2');
            const expectedResult = 'The number is even!';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when input is not a number', () => {
            assert.throws(() => testNumbers.numberChecker('test'), Error, 'The input is not a number!');
        });
    });

    describe('averageSumArray func tests', () => {
        it('should return correct avg sum', () => {
            const actualResult = testNumbers.averageSumArray([1, 2, 3]);
            const expectedResult = 2;

            assert.equal(actualResult, expectedResult);
        });
    });
});