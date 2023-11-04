const lookupChar = require('./03. Char Lookup');
const assert = require('chai').assert;

describe('lookupChar func tests', () => {
    it('should return correct char when both inputs are valid', () => {
        const actualResult = lookupChar('test', 2);
        const expectedResult = 's';

        assert.equal(actualResult, expectedResult);
    });

    it('should return undefined when first param is not a string but second is a number', () => {
        const actualResult = lookupChar(12, 2);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when first param is a valid string but second is not a number', () => {
        const actualResult = lookupChar('test', 'test');

        assert.isUndefined(actualResult);
    });

    it('should return undefined when first param is a valid string but second is number as string', () => {
        const actualResult = lookupChar('test', '2');

        assert.isUndefined(actualResult);
    });

    it('should return undefined when first param is a valid string but second is not an integet', () => {
        const actualResult = lookupChar('test', 2.2);

        assert.isUndefined(actualResult);
    });

    it('should return incorrect index when string is an empty string', () => {
        const actualResult = lookupChar('', 0);
        const expectedResult = 'Incorrect index';

        assert.equal(actualResult, expectedResult);
    });

    it('should return incorrect index when index is below 0', () => {
        const actualResult = lookupChar('test', -1);
        const expectedResult = 'Incorrect index';

        assert.equal(actualResult, expectedResult);
    });

    it('should return incorrect index when index is above string length', () => {
        const actualResult = lookupChar('test', 5);
        const expectedResult = 'Incorrect index';

        assert.equal(actualResult, expectedResult);
    });

    it('should return incorrect index when index is equal to string length', () => {
        const actualResult = lookupChar('test', 4);
        const expectedResult = 'Incorrect index';

        assert.equal(actualResult, expectedResult);
    });
});
