const { Repository } = require("./solution.js");
const assert = require('chai').assert;

describe('Repository class tests', () => {
    let repository;
    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };
    let firstEntity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    let secondEntity = {
        name: 'Gosho',
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    let missingPropEntity = {
        name: 'Stamat',
        birthday: new Date(1998, 0, 7)
    };
    let incorrectPropTypeEntity = {
        name: 'Stamat',
        age: '22',
        birthday: new Date(1998, 0, 7)
    };
    let updateEntity = {
        name: 'Stamat',
        age: 29,
        birthday: new Date(1991, 0, 21)
    };

    beforeEach(() => {
        repository = new Repository(properties);
    });

    describe('constructor tests', () => {
        it('should be initialize correctly', () => {
            assert.deepEqual(repository.props, properties);
            assert.deepEqual(repository.data, new Map());
            assert.equal(repository.count, 0);
        });
    });

    describe('add method tests', () => {
        it('should return correct id when input is valid', () => {
            let actualResult = repository.add(firstEntity);
            let expectedResult = 0;
            let map = new Map();
            map.set(0, firstEntity);

            assert.equal(actualResult, expectedResult);
            assert.equal(repository.count, 1);
            assert.deepEqual(repository.data, map);

            actualResult = repository.add(secondEntity);
            expectedResult = 1;
            map.set(1, secondEntity);

            assert.equal(actualResult, expectedResult);
            assert.equal(repository.count, 2);
            assert.deepEqual(repository.data, map);
        });

        it('should throw an error when input prop is missing', () => {
            assert.throws(() => repository.add(missingPropEntity), Error, 'Property age is missing from the entity!');
            assert.equal(repository.count, 0);
            assert.deepEqual(repository.data, new Map());
        });

        it('should throw an error when input prop is not in the correct data type', () => {
            assert.throws(() => repository.add(incorrectPropTypeEntity), Error, 'Property age is not of correct type!');
            assert.equal(repository.count, 0);
            assert.deepEqual(repository.data, new Map());
        });
    });

    describe('getId method tests', () => {
        it('should return correct entity when id is existing', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            const actualResult = repository.getId(0);
            const expectedResult = firstEntity;

            assert.deepEqual(actualResult, expectedResult);
        });

        it('should throw an error when id is not existing', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            assert.throws(() => repository.getId(10), Error, 'Entity with id: 10 does not exist!');
        });
    });

    describe('update method tests', () => {
        it('should update entity successfully when input is valid', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            repository.update(1, updateEntity);

            let map = new Map();
            map.set(0, firstEntity);
            map.set(1, updateEntity);

            assert.deepEqual(repository.getId(1), updateEntity);
            assert.equal(repository.count, 2);
            assert.deepEqual(repository.data, map);
        });

        it('should throw an error when id is not existing', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            let map = new Map();
            map.set(0, firstEntity);
            map.set(1, secondEntity);

            assert.throws(() => repository.update(10, updateEntity), Error, 'Entity with id: 10 does not exist!');
            assert.equal(repository.count, 2);
            assert.deepEqual(repository.data, map);
        });

        it('should throw an error when update entity input is not valid because of missing prop', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            let map = new Map();
            map.set(0, firstEntity);
            map.set(1, secondEntity);

            assert.throws(() => repository.update(1, missingPropEntity), Error, 'Property age is missing from the entity!');
            assert.deepEqual(repository.getId(1), secondEntity);
            assert.equal(repository.count, 2);
            assert.deepEqual(repository.data, map);
        });

        it('should throw an error when update entity input is not valid because of invalid type of prop', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            let map = new Map();
            map.set(0, firstEntity);
            map.set(1, secondEntity);

            assert.throws(() => repository.update(1, incorrectPropTypeEntity), Error, 'Property age is not of correct type!');
            assert.deepEqual(repository.getId(1), secondEntity);
            assert.equal(repository.count, 2);
            assert.deepEqual(repository.data, map);
        });
    });

    describe('del method tests', () => {
        it('should delete successfully when input data is valid', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            repository.del(1);
            repository.del(0);

            assert.equal(repository.count, 0);
            assert.deepEqual(repository.data, new Map());
        });

        it('should throw an error when id is not existing', () => {
            repository.add(firstEntity);
            repository.add(secondEntity);

            assert.throws(() => repository.del(10), Error, 'Entity with id: 10 does not exist!');
            assert.equal(repository.count, 2);
        });
    });
});
