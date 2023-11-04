const mathEnforcer = require('./04. Math Enforcer');
const assert = require('chai').assert;

describe('mathEnforcer object tests', () => {
    describe('addFive func tests', () => {
        it('should return correct result when input number is a valid integer number', () => {
            const actualResult = mathEnforcer.addFive(5);
            const expectedResult = 10;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input number is a valid double number', () => {
            const actualResult = mathEnforcer.addFive(5.5);
            const expectedResult = 10.5;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input number is a valid negative number', () => {
            const actualResult = mathEnforcer.addFive(-5);
            const expectedResult = 0;

            assert.equal(actualResult, expectedResult);
        });

        it('should return undefined when input number is not a number', () => {
            const actualResult = mathEnforcer.addFive('5');

            assert.isUndefined(actualResult);
        });
    });

    describe('subtractTen func tests', () => {
        it('should return correct result when input number is a valid integer number', () => {
            const actualResult = mathEnforcer.subtractTen(5);
            const expectedResult = -5;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input number is a valid double number', () => {
            const actualResult = mathEnforcer.subtractTen(5.5);
            const expectedResult = -4.5;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input number is a valid negative number', () => {
            const actualResult = mathEnforcer.subtractTen(-5);
            const expectedResult = -15;

            assert.equal(actualResult, expectedResult);
        });

        it('should return undefined when input number is not a number', () => {
            const actualResult = mathEnforcer.subtractTen('5');

            assert.isUndefined(actualResult);
        });
    });
    
    describe('sum func tests', () => {
        it('should return correct result by valid numbers negative integer inputs', () => {
            const result = mathEnforcer.sum(-10, -5);

            assert.equal(result, -15);
        });

        it('should return correct result by valid numbers double inputs', () => {
            const result = mathEnforcer.sum(-12.5, 5.5);

            assert.equal(result, -7);
        });

        it('should return undefined when first number is not a number', () => {
            const actualResult = mathEnforcer.sum('12.5', -3);

            assert.isUndefined(actualResult);
        });

        it('should return undefined when second number is not a number', () => {
            const actualResult = mathEnforcer.sum(12.5, '-3');

            assert.isUndefined(actualResult);
        });

        it('should return undefined when both numbers are not numbers', () => {
            const actualResult = mathEnforcer.sum('12.5', '-3');

            assert.isUndefined(actualResult);
        });
    });
});
