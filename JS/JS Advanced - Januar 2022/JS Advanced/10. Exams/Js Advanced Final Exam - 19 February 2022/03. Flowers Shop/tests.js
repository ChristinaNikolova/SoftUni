const flowerShop = require('./flowerShop');
const assert = require('chai').assert;

describe('flowerShop obj tests', () => {
    describe('calcPriceOfFlowers func tests', () => {
        it('should return correct price when input is valid', () => {
            const actualResult = flowerShop.calcPriceOfFlowers('roses', 2, 3);
            const expectedResult = 'You need $6.00 to buy roses!';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when input flower is not a string', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers(true, 2, 3), Error, 'Invalid input!');
        });

        it('should throw an error when input price is passed as string', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('roses', '2', 3), Error, 'Invalid input!');
        });

        it('should throw an error when input price is passed as double', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('roses', 2.5, 3), Error, 'Invalid input!');
        });

        it('should throw an error when input quantity is passed as string', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('roses', 2, '3'), Error, 'Invalid input!');
        });

        it('should throw an error when input quantity is passed as double', () => {
            assert.throws(() => flowerShop.calcPriceOfFlowers('roses', 2, 3.3), Error, 'Invalid input!');
        });
    });

    describe('checkFlowersAvailable func tests', () => {
        it('should return correct result when flower is available', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            const actualResult = flowerShop.checkFlowersAvailable('Lily', flowersArray);
            const expectedResult = 'The Lily are available!';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when flower is not available', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            const actualResult = flowerShop.checkFlowersAvailable('Daisy', flowersArray);
            const expectedResult = 'The Daisy are sold! You need to purchase more!';

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('sellFlowers func tests', () => {
        it('should return correct result when input is valid', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            const actualResult = flowerShop.sellFlowers(flowersArray, 1);
            const expectedResult = 'Rose / Orchid';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when input flowersArray is not array', () => {
            assert.throws(() => flowerShop.sellFlowers('Rose', 1), Error, 'Invalid input!');
        });

        it('should throw an error when input space is passed as string', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            assert.throws(() => flowerShop.sellFlowers(flowersArray, '1'), Error, 'Invalid input!');
        });

        it('should throw an error when input space is passed as double', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            assert.throws(() => flowerShop.sellFlowers(flowersArray, 1.5), Error, 'Invalid input!');
        });

        it('should throw an error when input space is below 0', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            assert.throws(() => flowerShop.sellFlowers(flowersArray, -1), Error, 'Invalid input!');
        });

        it('should throw an error when input space is equal to flowersArray length', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            assert.throws(() => flowerShop.sellFlowers(flowersArray, 3), Error, 'Invalid input!');
        });

        it('should throw an error when input space is above flowersArray length', () => {
            const flowersArray = ['Rose', 'Lily', 'Orchid'];

            assert.throws(() => flowerShop.sellFlowers(flowersArray, 4), Error, 'Invalid input!');
        });
    });
});