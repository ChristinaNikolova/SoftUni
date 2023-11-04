function solution() {
    let addButtonElement = document.querySelector('button');
    addButtonElement.addEventListener('click', addGift);

    let sectionElements = document.getElementsByTagName('section');

    function addGift() {
        let nameInputElement = document.querySelector('input[placeholder="Gift name"]');

        let liParentElement = createHtmlElement('li', ['gift'], `${nameInputElement.value}`);
        let buttonSendElement = createHtmlElement('button', null, 'Send', [{ key: 'id', value: 'sendButton' }], { name: 'click', function: moveGift });
        let buttonDiscardElement = createHtmlElement('button', null, 'Discard', [{ key: 'id', value: 'discardButton' }], { name: 'click', function: moveGift });

        appendChildren([buttonSendElement, buttonDiscardElement], liParentElement);

        let listOfGiftsUlParentElement = sectionElements[1].children[1];
        appendChildren([liParentElement], listOfGiftsUlParentElement);

        let liChildren = Array.from(listOfGiftsUlParentElement.children);

        liChildren.forEach((li) => {
            listOfGiftsUlParentElement.removeChild(li);
        });

        liChildren = liChildren.sort((a, b) => a.textContent.localeCompare(b.textContent));

        liChildren.forEach((li) => {
            listOfGiftsUlParentElement.appendChild(li);
        });

        nameInputElement.value = '';
    }

    function moveGift(e) {
        let tragetButton = e.target.textContent;

        let targetGift = e.target.parentElement;
        targetGift.children[0].remove();
        targetGift.children[0].remove();

        let targetParent;

        if (tragetButton === 'Send') {
            targetParent = sectionElements[2].children[1];
        } else if (tragetButton === 'Discard') {
            targetParent = sectionElements[3].children[1];
        }

        appendChildren([targetGift], targetParent);
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