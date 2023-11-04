window.addEventListener('load', solve);

function solve() {
    let sendButtonElement = document.querySelector('div#right button');
    sendButtonElement.addEventListener('click', sendInfo);

    let clearButtonElement = document.querySelector('button.clear-btn');
    clearButtonElement.addEventListener('click', clearAllRepairs);

    let completedOrdersSectionParentElement = document.getElementById('completed-orders');

    function sendInfo(e) {
        e.preventDefault();

        let typeProductSelectElement = document.getElementById('type-product');
        let descriptionTextAreaElement = document.getElementById('description');
        let clientNameInputElement = document.getElementById('client-name');
        let clientPhoneInputElement = document.getElementById('client-phone');

        if (!descriptionTextAreaElement.value ||
            !clientNameInputElement.value ||
            !clientPhoneInputElement.value) {
            return;
        }

        let divParentElement = createHtmlElement('div', ['container']);
        let h2Element = createHtmlElement('h2', null, `Product type for repair: ${typeProductSelectElement.value}`);
        let h3Element = createHtmlElement('h3', null, `Client information: ${clientNameInputElement.value}, ${clientPhoneInputElement.value}`);
        let h4Element = createHtmlElement('h4', null, `Description of the problem: ${descriptionTextAreaElement.value}`);
        let buttonStartElement = createHtmlElement('button', ['start-btn'], 'Start repair', null, { name: 'click', function: startRepair });
        let buttonFinishElement = createHtmlElement('button', ['finish-btn'], 'Finish repair', [{ key: 'disabled', value: true }], { name: 'click', function: finishRepair });

        appendChildren([h2Element, h3Element, h4Element, buttonStartElement, buttonFinishElement], divParentElement);

        let receivedOrdersParentSectionElement = document.getElementById('received-orders');
        appendChildren([divParentElement], receivedOrdersParentSectionElement);

        typeProductSelectElement.value = 'Computer';
        descriptionTextAreaElement.value = '';
        clientNameInputElement.value = '';
        clientPhoneInputElement.value = '';
    }

    function startRepair(e) {
        let startButtonElement = e.target;
        let finishButtonElement = startButtonElement.nextSibling;

        startButtonElement.disabled = true;
        finishButtonElement.disabled = false;
    }

    function finishRepair(e) {
        let targetRepair = e.target.parentElement;
        targetRepair.children[3].remove();
        targetRepair.children[3].remove();

        appendChildren([targetRepair], completedOrdersSectionParentElement);
    }

    function clearAllRepairs() {
        while (Array.from(completedOrdersSectionParentElement.children).length > 3) {
            completedOrdersSectionParentElement.children[3].remove();
        }
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