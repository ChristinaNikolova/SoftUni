function addItem() {
    let newItemTextInputElement = document.getElementById('newItemText');

    let liElement = document.createElement('li');
    liElement.textContent = newItemTextInputElement.value;

    let aElement = document.createElement('a');
    aElement.href = '#';
    aElement.textContent = '[Delete]';
    aElement.addEventListener('click', deleteElement);

    liElement.appendChild(aElement);

    let itemsUlElement = document.getElementById('items');
    itemsUlElement.appendChild(liElement);

    newItemTextInputElement.value = '';

    function deleteElement(e) {
        let targetElement = e.target.parentElement;
        targetElement.remove();
    }
}