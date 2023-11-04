function solve() {
    let onScreenButtonElement = document.querySelector('div#container button');
    onScreenButtonElement.addEventListener('click', onScreenMovie);

    let clearButtonElement = document.querySelector('section#archive button');
    clearButtonElement.addEventListener('click', deleteAllMovies);

    let archiveMoviesParentUlElement = document.querySelector('section#archive ul');

    function onScreenMovie(e) {
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
        let spanElement = createHtmlElement('span', null, `${nameInputElement.value}`);
        let strongHallElement = createHtmlElement('strong', null, `Hall: ${hallInputElement.value}`);
        let divParentElement = createHtmlElement('div');
        let strongPriceElement = createHtmlElement('strong', null, `${Number(ticketPriceInputElement.value).toFixed(2)}`);
        let inputElement = createHtmlElement('input', null, '', [{ key: 'placeholder', value: 'Tickets Sold' }]);
        let buttonElement = createHtmlElement('button', null, 'Archive', null, { name: 'click', function: archiveMovie });

        appendChildren([strongPriceElement, inputElement, buttonElement], divParentElement);
        appendChildren([spanElement, strongHallElement, divParentElement], liParentElement);

        let moviesUlParentElement = document.querySelector('section#movies ul');
        appendChildren([liParentElement], moviesUlParentElement);

        nameInputElement.value = '';
        hallInputElement.value = '';
        ticketPriceInputElement.value = '';
    }

    function archiveMovie(e) {
        let ticketsSoldInputElement = e.target.previousSibling;

        if (!ticketsSoldInputElement.value || isNaN(Number(ticketsSoldInputElement.value))) {
            return;
        }

        let targetMovie = e.target.parentElement.parentElement;
        const pricePerTicket = Number(targetMovie.children[2].children[0].textContent);
        const totalSoldTickets = Number(ticketsSoldInputElement.value);
        let totalProfit = pricePerTicket * totalSoldTickets;

        targetMovie.children[1].textContent = `Total amount: ${totalProfit.toFixed(2)}`;
        targetMovie.children[2].remove();

        let buttonElement = createHtmlElement('button', null, 'Delete', null, { name: 'click', function: deleteMovie });
        appendChildren([buttonElement], targetMovie);
        appendChildren([targetMovie], archiveMoviesParentUlElement);
    }

    function deleteMovie(e) {
        let targetMovie = e.target.parentElement;
        targetMovie.remove();
    }

    function deleteAllMovies() {
        archiveMoviesParentUlElement.innerHTML = '';
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