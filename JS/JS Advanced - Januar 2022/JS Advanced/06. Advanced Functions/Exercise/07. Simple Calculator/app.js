function calculator() {
    let firstNumberElement;
    let secondNumberElement;
    let resultElement;

    const obj = {
        init: function (selector1, selector2, resultSelector) {
            firstNumberElement = document.querySelector(selector1);
            secondNumberElement = document.querySelector(selector2);
            resultElement = document.querySelector(resultSelector);
        },
        add: function () {
            resultElement.value = Number(firstNumberElement.value) + Number(secondNumberElement.value);
        },
        subtract: function () {
            resultElement.value = Number(firstNumberElement.value) - Number(secondNumberElement.value);
        },
    };

    return obj;
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');
