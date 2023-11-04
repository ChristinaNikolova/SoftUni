const cinema = require('./cinema');
const assert = require('chai').assert;

describe('cinema obj tests', () => {
    describe('showMovies func tests', () => {
        it('should return correct result when there are movies', () => {
            const movies = ['King Kong', 'The Tomorrow War', 'Joker'];

            const actualResult = cinema.showMovies(movies);
            const expectedResult = movies.join(', ');

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when there are not movies', () => {
            const actualResult = cinema.showMovies([]);
            const expectedResult = 'There are currently no movies to show.';

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('ticketPrice func tests', () => {
        it('should return correct price when projection type is Premiere', () => {
            const actualResult = cinema.ticketPrice('Premiere');
            const expectedResult = 12.00;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when projection type is Normal', () => {
            const actualResult = cinema.ticketPrice('Normal');
            const expectedResult = 7.50;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when projection type is Discount', () => {
            const actualResult = cinema.ticketPrice('Discount');
            const expectedResult = 5.50;

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when projection type is not existing', () => {
            assert.throws(() => cinema.ticketPrice('Test'), Error, 'Invalid projection type.');
        });
    });

    describe('swapSeatsInHall func tests', () => {
        it('should return correct message when seats are swapped successfully', () => {
            const actualResult = cinema.swapSeatsInHall(1, 20);
            const expectedResult = 'Successful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when input params are missing', () => {
            const actualResult = cinema.swapSeatsInHall();
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when one input param is missing', () => {
            const actualResult = cinema.swapSeatsInHall(1);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when first input param is string', () => {
            const actualResult = cinema.swapSeatsInHall('1', 20);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when second param is string', () => {
            const actualResult = cinema.swapSeatsInHall(1, '20');
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when first param is not an integer', () => {
            const actualResult = cinema.swapSeatsInHall(1.5, 20);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when second param is not an integer', () => {
            const actualResult = cinema.swapSeatsInHall(1, 19.5);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when first param is below 0', () => {
            const actualResult = cinema.swapSeatsInHall(-1, 20);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when second param is below 0', () => {
            const actualResult = cinema.swapSeatsInHall(1, -1);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when first param is equal to 0', () => {
            const actualResult = cinema.swapSeatsInHall(0, 20);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when second param is equal to 0', () => {
            const actualResult = cinema.swapSeatsInHall(1, 0);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when first param is above 20', () => {
            const actualResult = cinema.swapSeatsInHall(21, 20);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when second param is above 20', () => {
            const actualResult = cinema.swapSeatsInHall(1, 21);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });


        it('should return correct message when input params are equal', () => {
            const actualResult = cinema.swapSeatsInHall(1, 1);
            const expectedResult = 'Unsuccessful change of seats in the hall.';

            assert.equal(actualResult, expectedResult);
        });
    });
});