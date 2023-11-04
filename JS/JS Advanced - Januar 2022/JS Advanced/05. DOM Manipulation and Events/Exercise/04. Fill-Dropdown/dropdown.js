function addItem() {
    let newItemTextInputElement = document.getElementById('newItemText');
    let newItemValueInputElement = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');
    optionElement.textContent = newItemTextInputElement.value;
    optionElement.value = newItemValueInputElement.value;

    let menuSelectElement = document.getElementById('menu');
    menuSelectElement.appendChild(optionElement);

    newItemTextInputElement.value = '';
    newItemValueInputElement.value = '';
}