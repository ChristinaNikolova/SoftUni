const rgbToHexColor = require('./06. RGB to Hex');
const assert = require('chai').assert;

describe('rgbToHexColor func tests', () => {
    it('should return correct color white when input is valid', () => {
        const actualResult = rgbToHexColor(0, 0, 0);
        const expectedResult = '#000000';

        assert.equal(actualResult, expectedResult);
    });

    it('should return correct color black when input is valid', () => {
        const actualResult = rgbToHexColor(255, 255, 255);
        const expectedResult = '#FFFFFF';

        assert.equal(actualResult, expectedResult);
    });

    // red
    it('should return undefined when red color is not an integer', () => {
        const actualResult = rgbToHexColor(10.5, 255, 255);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when red color is not a number', () => {
        const actualResult = rgbToHexColor('10', 255, 255);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when red color is below 0', () => {
        const actualResult = rgbToHexColor(-1, 255, 255);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when red color is alove 255', () => {
        const actualResult = rgbToHexColor(256, 255, 255);

        assert.isUndefined(actualResult);
    });

    // green
    it('should return undefined when green color is not an integer', () => {
        const actualResult = rgbToHexColor(255, 10.5, 255);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when green color is not a number', () => {
        const actualResult = rgbToHexColor(255, '10', 255);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when green color is below 0', () => {
        const actualResult = rgbToHexColor(255, -1, 255);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when green color is alove 255', () => {
        const actualResult = rgbToHexColor(255, 256, 255);

        assert.isUndefined(actualResult);
    });

    // blue
    it('should return undefined when blue color is not an integer', () => {
        const actualResult = rgbToHexColor(255, 255, 10.5);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when blue color is not a number', () => {
        const actualResult = rgbToHexColor(255, 255, '10');

        assert.isUndefined(actualResult);
    });

    it('should return undefined when blue color is below 0', () => {
        const actualResult = rgbToHexColor(255, 255, -1);

        assert.isUndefined(actualResult);
    });

    it('should return undefined when blue color is alove 255', () => {
        const actualResult = rgbToHexColor(255, 255, 256);

        assert.isUndefined(actualResult);
    });
});
