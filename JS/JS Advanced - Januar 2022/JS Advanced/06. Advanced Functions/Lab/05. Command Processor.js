function solution() {
    let result = '';

    const obj = {
        append: function (str) {
            result += str;
        },
        removeStart: function (n) {
            result = result.slice(n);
        },
        removeEnd: function (n) {
            result = result.slice(0, result.length - n);
        },
        print: function () {
            console.log(result);
        }
    };

    return obj;
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();

let secondZeroTest = solution();
secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print(); 