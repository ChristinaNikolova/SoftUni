const library = require('./library');
const assert = require('chai').assert;

describe('library obj tests', () => {
    describe('calcPriceOfBook func tests', () => {
        it('should return correct price when year is before 1980', () => {
            const actualResult = library.calcPriceOfBook('Test', 1979);
            const expectedResult = 'Price of Test is 10.00';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when year is equal to 1980', () => {
            const actualResult = library.calcPriceOfBook('Test', 1980);
            const expectedResult = 'Price of Test is 10.00';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct price when year is after 1980', () => {
            const actualResult = library.calcPriceOfBook('Test', 1981);
            const expectedResult = 'Price of Test is 20.00';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when name of book is not a string', () => {
            assert.throws(() => library.calcPriceOfBook(1890, 1981), Error, 'Invalid input');
        });

        it('should throw an error when year is number as string', () => {
            assert.throws(() => library.calcPriceOfBook('Test', '1981'), Error, 'Invalid input');
        });

        it('should throw an error when year is number is not an integer', () => {
            assert.throws(() => library.calcPriceOfBook('Test', 1980.5), Error, 'Invalid input');
        });
    });

    describe('findBook func tests', () => {
        it('should return correct message when book is found', () => {
            const books = ['Troy', 'Life Style', 'Torronto'];

            const actualResult = library.findBook(books, 'Life Style');
            const expectedResult = 'We found the book you want.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when book is not found', () => {
            const books = ['Troy', 'Life Style', 'Torronto'];

            const actualResult = library.findBook(books, 'Life Style 2');
            const expectedResult = 'The book you are looking for is not here!';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when array of books is empty', () => {
            assert.throws(() => library.findBook([], 'Life Style 2'), Error, 'No books currently available');
        });
    });

    describe('arrangeTheBooks func tests', () => {
        it('should return correct message when books are arranged und there is more free space', () => {
            const actualResult = library.arrangeTheBooks(39);
            const expectedResult = 'Great job, the books are arranged.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when books are arranged und there is no more free space', () => {
            const actualResult = library.arrangeTheBooks(40);
            const expectedResult = 'Great job, the books are arranged.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when books are not arranged', () => {
            const actualResult = library.arrangeTheBooks(41);
            const expectedResult = 'Insufficient space, more shelves need to be purchased.';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when input is not a number but string', () => {
            assert.throws(() => library.arrangeTheBooks('40'), Error, 'Invalid input');
        });

        it('should throw an error when input is a double', () => {
            assert.throws(() => library.arrangeTheBooks(1.5), Error, 'Invalid input');
        });

        it('should throw an error when input is a negative number', () => {
            assert.throws(() => library.arrangeTheBooks(-1), Error, 'Invalid input');
        });
    });
});