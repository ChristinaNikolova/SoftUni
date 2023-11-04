const isSymmetric = require('./05. Check for Symmetry');
const assert = require('chai').assert;

describe('isSymmetric func tests', () => {
    it('should return true when input is symmetric and has even length', () => {
        const actualResult = isSymmetric([1, 2, 2, 1]);

        assert.isTrue(actualResult);
    });

    it('should return true when input is symmetric and has odd length', () => {
        const actualResult = isSymmetric([1, 2, 1]);

        assert.isTrue(actualResult);
    });

    it('should return true when input is symmetric and has only one element', () => {
        const actualResult = isSymmetric([1]);

        assert.isTrue(actualResult);
    });

    it('should return false when input is not symmetric', () => {
        const actualResult = isSymmetric([1, 2, 2]);

        assert.isFalse(actualResult);
    });

    it('should return false when input is symmetric but diff data types', () => {
        const actualResult = isSymmetric([1, 2, '1']);

        assert.isFalse(actualResult);
    });

    it('should return false when input is not an array', () => {
        const actualResult = isSymmetric(1);

        assert.isFalse(actualResult);
    });
});