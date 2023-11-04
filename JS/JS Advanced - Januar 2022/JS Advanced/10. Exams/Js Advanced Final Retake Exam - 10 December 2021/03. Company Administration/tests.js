const companyAdministration = require('./companyAdministration');
const assert = require('chai').assert;

describe('companyAdministration obj tests', () => {
    describe('hiringEmployee func tests', () => {
        it('should return correct result when input is valid and years of experience is below 3', () => {
            const actualResult = companyAdministration.hiringEmployee('Pesho', 'Programmer', 2);
            const expectedResult = 'Pesho is not approved for this position.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input is valid and years of experience is equal to 3', () => {
            const actualResult = companyAdministration.hiringEmployee('Pesho', 'Programmer', 3);
            const expectedResult = 'Pesho was successfully hired for the position Programmer.';

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct result when input is valid and years of experience is above 3', () => {
            const actualResult = companyAdministration.hiringEmployee('Pesho', 'Programmer', 4);
            const expectedResult = 'Pesho was successfully hired for the position Programmer.';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when position is not equal to Programmer', () => {
            assert.throws(() => companyAdministration.hiringEmployee('Pesho', 'Junior', 4), Error, 'We are not looking for workers for this position.');
        });
    });

    describe('calculateSalary func tests', () => {
        it('should return correct salary when working hours are below 160', () => {
            const actualResult = companyAdministration.calculateSalary(159);
            const expectedResult = 2385;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct salary when working hours are equal to 160', () => {
            const actualResult = companyAdministration.calculateSalary(160);
            const expectedResult = 2400;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct salary when working hours are above 160', () => {
            const actualResult = companyAdministration.calculateSalary(161);
            const expectedResult = 3415;

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when hours are not a number', () => {
            assert.throws(() => companyAdministration.calculateSalary('161'), Error, 'Invalid hours');
        });

        it('should throw an error when hours are a negative number', () => {
            assert.throws(() => companyAdministration.calculateSalary(-1), Error, 'Invalid hours');
        });
    });

    describe('firedEmployee func tests', () => {
        it('should return correct result when input is valid', () => {
            const actualResult = companyAdministration.firedEmployee(['Petar', 'Ivan', 'George'], 1);
            const expectedResult = 'Petar, George';

            assert.equal(actualResult, expectedResult);
        });

        it('should throw an error when input param employee is not an array', () => {
            assert.throws(() => companyAdministration.firedEmployee('Petar, Ivan, George', 1), Error, 'Invalid input');
        });

        it('should throw an error when input param index is not an integer', () => {
            assert.throws(() => companyAdministration.firedEmployee(['Petar', 'Ivan', 'George'], 1.2), Error, 'Invalid input');
        });

        it('should throw an error when input param index is a string', () => {
            assert.throws(() => companyAdministration.firedEmployee(['Petar', 'Ivan', 'George'], '1'), Error, 'Invalid input');
        });

        it('should throw an error when input param index is below 0', () => {
            assert.throws(() => companyAdministration.firedEmployee(['Petar', 'Ivan', 'George'], -1), Error, 'Invalid input');
        });

        it('should throw an error when input param index is equal to arrays length', () => {
            assert.throws(() => companyAdministration.firedEmployee(['Petar', 'Ivan', 'George'], 3), Error, 'Invalid input');
        });

        it('should throw an error when input param index is above arrays length', () => {
            assert.throws(() => companyAdministration.firedEmployee(['Petar', 'Ivan', 'George'], 3), Error, 'Invalid input');
        });
    });
});