const PaymentPackage = require('./12. Payment Package');
const assert = require('chai').assert;

describe('PaymentPackage class tests', () => {
    let paymentPackage;

    beforeEach(() => {
        paymentPackage = new PaymentPackage('test', 10);
    });

    describe('constructor tests', () => {
        it('should be initialize correctly', () => {
            assert.equal(paymentPackage.name, 'test');
            assert.equal(paymentPackage.value, 10);
            assert.equal(paymentPackage.VAT, 20);
            assert.isTrue(paymentPackage.active);
        });
    });

    describe('prop name tests', () => {
        it('should be changed successfully when new name is valid', () => {
            const newName = 'Pesho'
            paymentPackage.name = newName;

            assert.equal(paymentPackage.name, newName);
        });

        it('should throw error when new name is not a string', () => {
            const newName = 123

            assert.throws(() => paymentPackage.name = newName, 'Name must be a non-empty string');
        });

        it('should throw error when new name is an empty string', () => {
            const newName = '';

            assert.throws(() => paymentPackage.name = newName, 'Name must be a non-empty string');
        });
    });

    describe('prop value tests', () => {
        it('should be changed successfully when new value is valid', () => {
            const newValue = 0;
            paymentPackage.value = newValue;

            assert.equal(paymentPackage.value, newValue);
        });

        it('should throw error when new value is not a number', () => {
            const newValue = '123'

            assert.throws(() => paymentPackage.value = newValue, 'Value must be a non-negative number');
        });

        it('should throw error when new value is a negative number', () => {
            const newValue = -1;

            assert.throws(() => paymentPackage.value = newValue, 'Value must be a non-negative number');
        });
    });

    describe('prop VAT tests', () => {
        it('should be changed successfully when new VAT is valid', () => {
            const newVAT = 0;
            paymentPackage.VAT = newVAT;

            assert.equal(paymentPackage.VAT, newVAT);
        });

        it('should throw error when new VAT is not a number', () => {
            const newVAT = '123'

            assert.throws(() => paymentPackage.VAT = newVAT, 'VAT must be a non-negative number');
        });

        it('should throw error when new VAT is a negative number', () => {
            const newVAT = -1;

            assert.throws(() => paymentPackage.VAT = newVAT, 'VAT must be a non-negative number');
        });
    });

    describe('prop active tests', () => {
        it('should be changed successfully when new active is valid', () => {
            paymentPackage.active = false;

            assert.isFalse(paymentPackage.active);
        });

        it('should throw error when new active is not a boolean', () => {
            const newActive = '123'

            assert.throws(() => paymentPackage.active = newActive, 'Active status must be a boolean');
        });
    });

    describe('toString func tests', () => {
        it('should return correct message when active is true', () => {
            const actualResult = paymentPackage.toString();
            const expectedResult = `Package: test\n- Value (excl. VAT): 10\n- Value (VAT 20%): 12`;

            assert.equal(actualResult, expectedResult);
        });

        it('should return correct message when active is false', () => {
            paymentPackage.active = false;
            const actualResult = paymentPackage.toString();
            const expectedResult = `Package: test (inactive)\n- Value (excl. VAT): 10\n- Value (VAT 20%): 12`;

            assert.equal(actualResult, expectedResult);
        });
    });
});