function calc() {
    let num1InputElement = document.getElementById('num1');
    let num2InputElement = document.getElementById('num2');

    let sum = Number(num1InputElement.value) + Number(num2InputElement.value);

    let sumInputElement = document.getElementById('sum');
    sumInputElement.value = sum;
}
