function solve() {
    let onScreenButtonElement = document.querySelector('div#container button');
    onScreenButtonElement.addEventListener('click', onScreen);

    let clearButtonElement = document.querySelector('section#archive button');
    clearButtonElement.addEventListener('click', clear);

    let archiveParentUlElement = document.querySelector('section#archive ul');

    function onScreen(e) {
        e.preventDefault();

        let nameInputElement = document.querySelector('input[placeholder="Name"]');
        let hallInputElement = document.querySelector('input[placeholder="Hall"]');
        let ticketPriceInputElement = document.querySelector('input[placeholder="Ticket Price"]');

        if (!nameInputElement.value ||
            !hallInputElement.value ||
            !ticketPriceInputElement.value ||
            isNaN(Number(ticketPriceInputElement.value))) {
            return;
        }

        let liParentElement = createHtmlElement('li');
        let spanNameElement = createHtmlElement('span', null, `${nameInputElement.value}`);
        let strongHallElement = createHtmlElement('strong', null, `Hall: ${hallInputElement.value}`);
        let divParentElement = createHtmlElement('div');
        let strongPriceElement = createHtmlElement('strong', null, `${Number(ticketPriceInputElement.value).toFixed(2)}`);
        let inputElement = createHtmlElement('input', null, null, [{ key: 'placeholder', value: 'Tickets Sold' }]);
        let buttonElement = createHtmlElement('button', null, 'Archive', null, { name: 'click', function: archive });

        appendChildren([strongPriceElement, inputElement, buttonElement], divParentElement);
        appendChildren([spanNameElement, strongHallElement, divParentElement], liParentElement);

        let moviesParentUlElement = document.querySelector('section#movies ul');
        appendChildren([liParentElement], moviesParentUlElement);

        nameInputElement.value = '';
        hallInputElement.value = '';
        ticketPriceInputElement.value = '';
    }

    function archive(e) {
        let targetMovie = e.target.parentElement.parentElement;
        let inputElement = targetMovie.children[2].children[1];

        if (isNaN(Number(inputElement.value)) || inputElement.value === '') {
            return;
        }

        const ticketsSold = Number(inputElement.value);
        const pricePerTicket = Number(targetMovie.children[2].children[0].textContent);
        const totalSum = ticketsSold * pricePerTicket;

        targetMovie.children[1].textContent = `Total amount: ${totalSum.toFixed(2)}`;
        targetMovie.children[2].remove();

        let buttonElement = createHtmlElement('button', null, 'Delete', null, { name: 'click', function: deleteMovie });
        appendChildren([buttonElement], targetMovie);
        appendChildren([targetMovie], archiveParentUlElement);
    }

    function deleteMovie(e) {
        let targetMovie = e.target.parentElement;
        targetMovie.remove();
    }

    function clear() {
        archiveParentUlElement.innerHTML = '';
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