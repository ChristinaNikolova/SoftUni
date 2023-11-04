function addItem() {
    let newItemTextInputElement = document.getElementById('newItemText');

    let liElement = document.createElement('li');
    liElement.textContent = newItemTextInputElement.value;

    let itemsUlElement = document.getElementById('items');
    itemsUlElement.appendChild(liElement);

    newItemTextInputElement.value = '';
}