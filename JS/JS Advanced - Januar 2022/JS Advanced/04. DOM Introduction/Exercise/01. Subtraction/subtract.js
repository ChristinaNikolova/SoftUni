function subtract() {
    let firstNumberInputElement = document.getElementById('firstNumber');
    let secondNumberInputElement = document.getElementById('secondNumber');

    const result = Number(firstNumberInputElement.value) - Number(secondNumberInputElement.value);

    let resultDivElement = document.getElementById('result');
    resultDivElement.textContent = result;
}