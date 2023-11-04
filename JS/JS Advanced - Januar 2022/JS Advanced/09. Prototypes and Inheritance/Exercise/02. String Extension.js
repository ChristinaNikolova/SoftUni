(() => {
    String.prototype.ensureStart = function (str) {
        return this.startsWith(str) ? this.toString() : str.concat(this);
    };
    String.prototype.ensureEnd = function (str) {
        return this.endsWith(str) ? this.toString() : this.concat(str);
    };
    String.prototype.isEmpty = function () {
        return this.length === 0;
    };
    String.prototype.truncate = function (n) {
        if (n < 4) {
            return '.'.repeat(n);
        }

        if (this.length <= n) {
            return this.toString();
        }

        const lastSpaceIndex = this.slice(0, n - 1).lastIndexOf(' ')

        if (lastSpaceIndex === -1) {
            return this.slice(0, n - 3) + '...';
        }

        return this.slice(0, lastSpaceIndex) + '...'
    };
    String.format = function (str, ...params) {
        for (let i = 0; i < params.length; i++) {
            str = str.replace(`{${i}}`, params[i]);
        }

        return str;
    };
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox', 'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}', 'dog');
console.log(str);