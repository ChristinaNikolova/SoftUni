const ChristmasMovies = require('./02. Christmas Movies_Resources');
const assert = require('chai').assert;

describe('ChristmasMovies class tests', () => {
    let christmasMovies;

    beforeEach(() => {
        christmasMovies = new ChristmasMovies();
    });

    describe('constructor tests', () => {
        it('should be initialize correctly', () => {
            assert.deepEqual(christmasMovies.movieCollection, []);
            assert.deepEqual(christmasMovies.watched, {});
            assert.deepEqual(christmasMovies.actors, []);
        });
    });

    describe('buyMovie method tests', () => {
        it('should return correct result when movie is added', () => {
            let actualResult = christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            let expectedResult = 'You just got Home Alone to your collection in which Macaulay Culkin, Joe Pesci, Daniel Stern are taking part!';

            assert.equal(actualResult, expectedResult);
            assert.equal(christmasMovies.movieCollection.length, 1);

            actualResult = christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            expectedResult = 'You just got Home Alone 2 to your collection in which Macaulay Culkin, Joe Pesci, Daniel Stern are taking part!';

            assert.equal(actualResult, expectedResult);
            assert.equal(christmasMovies.movieCollection.length, 2);
        });

        it('should throw an error when movie is already in the collection', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);

            assert.throws(() => christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']), Error, 'You already own Home Alone in your collection!');
            assert.equal(christmasMovies.movieCollection.length, 1);
        });
    });

    describe('discardMovie method tests', () => {
        it('should return correct result when movie is existing and watched', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.watchMovie('Home Alone');

            const actualResult = christmasMovies.discardMovie('Home Alone');
            const expectedResult = 'You just threw away Home Alone!';

            assert.equal(actualResult, expectedResult);
            assert.equal(christmasMovies.movieCollection.length, 1);
            assert.deepEqual(christmasMovies.watched, {});
        });

        it('should throw an error when movie is existing but does not be watched yet', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);

            assert.throws(() => christmasMovies.discardMovie('Home Alone'), Error, 'Home Alone is not watched!');
            assert.equal(christmasMovies.movieCollection.length, 1);
            assert.deepEqual(christmasMovies.watched, {});
        });

        it('should throw an error when movie is not in the collection', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);

            assert.throws(() => christmasMovies.discardMovie('Home Alone 3'), Error, 'Home Alone 3 is not at your collection!');
            assert.equal(christmasMovies.movieCollection.length, 2);
            assert.deepEqual(christmasMovies.watched, {});
        });
    });

    describe('watchMovie method tests', () => {
        it('should increase watched counter correctly when movie is in the collection', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);

            christmasMovies.watchMovie('Home Alone');
            assert.deepEqual(christmasMovies.watched, { 'Home Alone': 1 });

            christmasMovies.watchMovie('Home Alone');
            assert.deepEqual(christmasMovies.watched, { 'Home Alone': 2 });
        });

        it('should throw an error when movie is not in the collection', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);

            assert.throws(() => christmasMovies.watchMovie('Home Alone 3'), Error, 'No such movie in your collection!');
            assert.deepEqual(christmasMovies.watched, {});
        });
    });

    describe('favouriteMovie method tests', () => {
        it('should return correct result when there are watched movies', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 3', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);

            christmasMovies.watchMovie('Home Alone');
            christmasMovies.watchMovie('Home Alone');
            christmasMovies.watchMovie('Home Alone 2');

            const actualResult = christmasMovies.favouriteMovie();
            const expectedResult = 'Your favourite movie is Home Alone and you have watched it 2 times!';

            assert.equal(actualResult, expectedResult);
            assert.deepEqual(christmasMovies.watched, { 'Home Alone': 2, 'Home Alone 2': 1 });
        });

        it('should throw an error when there are not watched movies yet', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 3', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Daniel Stern']);

            assert.throws(() => christmasMovies.favouriteMovie(), Error, 'You have not watched a movie yet this year!');
            assert.deepEqual(christmasMovies.watched, {});
        });
    });

    describe('mostStarredActor method tests', () => {
        it('should return correct result when there are movies in the collection', () => {
            christmasMovies.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmasMovies.buyMovie('Home Alone 2', ['Macaulay Culkin', 'Joe Pesci']);
            christmasMovies.buyMovie('Home Alone 3', ['Macaulay Culkin']);

            const actualResult = christmasMovies.mostStarredActor();
            const expectedResult = 'The most starred actor is Macaulay Culkin and starred in 3 movies!';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when there are not movies in the collection yet', () => {
            assert.throw(() => christmasMovies.mostStarredActor(), Error, 'You have not watched a movie yet this year!');
        });
    });
});