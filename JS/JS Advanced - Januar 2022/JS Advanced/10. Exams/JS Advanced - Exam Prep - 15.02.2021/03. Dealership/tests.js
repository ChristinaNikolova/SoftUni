const dealership = require('./03. Dealership');
const assert = require('chai').assert;

describe('dealership obj tests', () => {
    describe('newCarCost func tests', () => {
        it('should return correct price when returning auto is existing und model is Audi A4 B8', () => {
            const actualResult = dealership.newCarCost('Audi A4 B8', 30000);
            const expectedResult = 15000;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when returning auto is existing und model is Audi A6 4K', () => {
            const actualResult = dealership.newCarCost('Audi A6 4K', 30000);
            const expectedResult = 10000;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when returning auto is existing und model is Audi A8 D5', () => {
            const actualResult = dealership.newCarCost('Audi A8 D5', 30000);
            const expectedResult = 5000;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when returning auto is existing und model is Audi TT 8J', () => {
            const actualResult = dealership.newCarCost('Audi TT 8J', 30000);
            const expectedResult = 16000;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when returning auto is not existing', () => {
            const actualResult = dealership.newCarCost('Audi', 30000);
            const expectedResult = 30000;

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('carEquipment func tests', () => {
        it('should return correct result', () => {
            const actualResult = dealership.carEquipment(['heated seats', 'sliding roof', 'sport rims', 'navigation'], [0, 2]);
            const expectedResult = ['heated seats', 'sport rims'];

            assert.deepEqual(actualResult, expectedResult);
        });
    });

    describe('euroCategory func tests', () => {
        it('should return correct message when number is below 4', () => {
            const actualResult = dealership.euroCategory(3);
            const expectedResult = 'Your euro category is low, so there is no discount from the final price!';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when number is equal to 4', () => {
            const actualResult = dealership.euroCategory(4);
            const expectedResult = 'We have added 5% discount to the final price: 14250.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when number is above 4', () => {
            const actualResult = dealership.euroCategory(5);
            const expectedResult = 'We have added 5% discount to the final price: 14250.';

            assert.equal(actualResult, expectedResult);
        });
    });
});