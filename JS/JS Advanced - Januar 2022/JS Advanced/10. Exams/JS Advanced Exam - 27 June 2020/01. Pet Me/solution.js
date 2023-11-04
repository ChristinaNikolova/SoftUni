function solve() {
    let addButtonElement = document.querySelector('div#container button');
    addButtonElement.addEventListener('click', addPet);

    function addPet(e) {
        e.preventDefault();

        let nameInputElement = document.querySelector('input[placeholder="Name"]');
        let ageInputElement = document.querySelector('input[placeholder="Age"]');
        let kindInputElement = document.querySelector('input[placeholder="Kind"]');
        let currentOwnerInputElement = document.querySelector('input[placeholder="Current Owner"]');

        if (!nameInputElement.value ||
            !ageInputElement.value ||
            !kindInputElement.value ||
            !currentOwnerInputElement.value ||
            isNaN(Number(ageInputElement.value))) {
            return;
        }

        let liParentElement = createHtmlElement('li');
        let pElement = createHtmlElement('p');
        let spanElement = createHtmlElement('span', null, `Owner: ${currentOwnerInputElement.value}`);
        let buttonElement = createHtmlElement('button', null, 'Contact with owner', null, { name: 'click', function: contactOwner });

        pElement.innerHTML = `<strong>${nameInputElement.value}</strong> is a <strong>${ageInputElement.value}</strong> year old <strong>${kindInputElement.value}</strong>`;

        appendChildren([pElement, spanElement, buttonElement], liParentElement);

        let adoptionPetsParentUlElement = document.querySelector('section#adoption ul');
        appendChildren([liParentElement], adoptionPetsParentUlElement);

        nameInputElement.value = '';
        ageInputElement.value = '';
        kindInputElement.value = '';
        currentOwnerInputElement.value = '';
    }

    function contactOwner(e) {
        let targetPet = e.target.parentElement;
        targetPet.children[2].remove();

        let divParentElement = createHtmlElement('div');
        let inputElement = createHtmlElement('input', null, '', [{ key: 'placeholder', value: 'Enter your names' }]);
        let buttonElement = createHtmlElement('button', null, 'Yes! I take it!', null, { name: 'click', function: adoptPet });

        appendChildren([inputElement, buttonElement], divParentElement);
        appendChildren([divParentElement], targetPet);
    }

    function adoptPet(e) {
        let newOwnerInputElement = e.target.previousSibling;

        if (!newOwnerInputElement.value) {
            return;
        }

        let targetPet = e.target.parentElement.parentElement;
        targetPet.children[1].textContent = `New Owner: ${newOwnerInputElement.value}`;
        targetPet.children[2].remove();

        let buttonElement = createHtmlElement('button', null, 'Checked', null, { name: 'click', function: deletePet });
        appendChildren([buttonElement], targetPet);

        let adoptedPetsParentUlElement = document.querySelector('section#adopted ul');
        appendChildren([targetPet], adoptedPetsParentUlElement);
    }

    function deletePet(e) {
        let targetPet = e.target.parentElement;
        targetPet.remove();
    }

    function createHtmlElement(
        tagName,
        classNames,
        textContent,
        attributes,
        event
    ) {
        let element = document.createElement(tagName);

        if (classNames) {
            element.classList.add(...classNames);
        }

        if (textContent) {
            element.textContent = textContent;
        }

        if (attributes) {
            attributes.forEach((a) => element.setAttribute(a.key, a.value));
        }

        if (event) {
            element.addEventListener(event.name, event.function);
        }

        return element;
    }

    function appendChildren(children, parent) {
        children.forEach((c) => parent.appendChild(c));
        return parent;
    }
}

