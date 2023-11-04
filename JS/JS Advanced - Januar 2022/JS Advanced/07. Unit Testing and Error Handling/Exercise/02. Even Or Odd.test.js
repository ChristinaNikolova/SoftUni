const isOddOrEven = require('./02. Even Or Odd');
const assert = require('chai').assert;

describe('isOddOrEven func tests', () => {
    it('should return correct result when input is valid string with even length', () => {
        const actualResult = isOddOrEven('test');
        const expectedResult = 'even';

        assert.equal(actualResult, expectedResult);
    });

    it('should return correct result when input is valid string with odd length', () => {
        const actualResult = isOddOrEven('tes');
        const expectedResult = 'odd';

        assert.equal(actualResult, expectedResult);
    });

    it('should return correct result when input is valid string but empty', () => {
        const actualResult = isOddOrEven('');
        const expectedResult = 'even';

        assert.equal(actualResult, expectedResult);
    });

    it('should return undefined when input is not a string', () => {
        const actualResult = isOddOrEven(21222);

        assert.isUndefined(actualResult);
    });
});