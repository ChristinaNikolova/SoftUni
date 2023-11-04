const createCalculator = require('./07. AddSubtract');
const assert = require('chai').assert;

describe('createCalculator func tests', () => {
    let calculator = {};

    beforeEach(() => {
        calculator = createCalculator();
    });

    it('should add correctly to value when input is valid', () => {
        calculator.add(3);
        calculator.add(-8);
        calculator.add(3.3);
        calculator.add('1');

        const actualResult = calculator.get();
        const expectedResult = -0.7000000000000002;

        assert.equal(actualResult, expectedResult);
    });

    it('should subtract correctly to value when input is valid number', () => {
        calculator.subtract(3);
        calculator.subtract(-2);
        calculator.subtract(3.3);
        calculator.subtract('1');

        const actualResult = calculator.get();
        const expectedResult = -5.3;

        assert.equal(actualResult, expectedResult);
    });

    it('should add and subtract correctly to value when input is valid number', () => {
        calculator.add(3);
        calculator.subtract(-2);
        calculator.add(3);
        calculator.subtract('1');

        const actualResult = calculator.get();
        const expectedResult = 7;

        assert.equal(actualResult, expectedResult);
    });
});
