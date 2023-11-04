const sum = require('./04. Sum of Numbers');
const assert = require('chai').assert;

describe('sum func tests', () => {
    it('should return sum when input array is number array', () => {
        const actualResult = sum([1, 2.2, -3]);
        const expectedResult = 0.20000000000000018;

        assert.equal(actualResult, expectedResult);
    });

    it('should return sum when input array is string array', () => {
        const actualResult = sum(['1', '2', '3']);
        const expectedResult = 6;

        assert.equal(actualResult, expectedResult);
    });

    it('should return sum when input array is mix strings and numbers array', () => {
        const actualResult = sum(['1', 2, '3']);
        const expectedResult = 6;

        assert.equal(actualResult, expectedResult);
    });
});