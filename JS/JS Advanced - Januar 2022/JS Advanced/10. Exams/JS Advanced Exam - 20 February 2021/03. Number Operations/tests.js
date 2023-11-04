const numberOperations = require('./03. Number Operations_Resources');
const assert = require('chai').assert;

describe('numberOperations obj tests', () => {
    describe('powNumber func tests', () => {
        it('should return correct result', () => {
            const actualResult = numberOperations.powNumber(2);
            const expectedResult = 4;

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('numberChecker func tests', () => {
        it('should return correct result when input number is below 100', () => {
            const actualResult = numberOperations.numberChecker(99);
            const expectedResult = 'The number is lower than 100!';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input number is equal to 100', () => {
            const actualResult = numberOperations.numberChecker(100);
            const expectedResult = 'The number is greater or equal to 100!';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input number is above 100', () => {
            const actualResult = numberOperations.numberChecker(101);
            const expectedResult = 'The number is greater or equal to 100!';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input number is passed as string', () => {
            const actualResult = numberOperations.numberChecker('101');
            const expectedResult = 'The number is greater or equal to 100!';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when input is not a number', () => {
            assert.throws(() => numberOperations.numberChecker('test'), Error, 'The input is not a number!');
        });
    });

    describe('sumArrays func tests', () => {
        it('should return correct result when first arr is longer than second arr', () => {
            const firstArr = [1, 2, 3, 4, 5];
            const secondArr = [5, 6];

            const actualResult = numberOperations.sumArrays(firstArr, secondArr);
            const expectedResult = [6, 8, 3, 4, 5];

            assert.deepEqual(actualResult, expectedResult);
        });

        it('should return correct result when second arr is longer than first arr', () => {
            const firstArr = [5, 6];
            const secondArr = [1, 2, 3, 4, 5];

            const actualResult = numberOperations.sumArrays(firstArr, secondArr);
            const expectedResult = [6, 8, 3, 4, 5];

            assert.deepEqual(actualResult, expectedResult);
        });

        it('should return correct result when first arr length is equal to second arr length', () => {
            const firstArr = [5, 6];
            const secondArr = [1, 2];

            const actualResult = numberOperations.sumArrays(firstArr, secondArr);
            const expectedResult = [6, 8];

            assert.deepEqual(actualResult, expectedResult);
        });
    });
});