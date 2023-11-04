window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.getElementById('add-btn');
    addButtonElement.addEventListener('click', addSong);

    function addSong(e) {
        e.preventDefault();

        let genreInputElement = document.getElementById('genre');
        let nameInputElement = document.getElementById('name');
        let authorInputElement = document.getElementById('author');
        let dateInputElement = document.getElementById('date');

        if (!genreInputElement.value || !nameInputElement.value || !authorInputElement.value || !dateInputElement.value) {
            return;
        }

        let divParentElement = createHtmlElement('div', ['hits-info']);
        let imgElement = createHtmlElement('img', null, '', [{ key: 'src', value: './static/img/img.png' }]);
        let h2GenreElement = createHtmlElement('h2', null, `Genre: ${genreInputElement.value}`);
        let h2NameElement = createHtmlElement('h2', null, `Name: ${nameInputElement.value}`);
        let h2AuthorElement = createHtmlElement('h2', null, `Author: ${authorInputElement.value}`);
        let h3Element = createHtmlElement('h3', null, `Date: ${dateInputElement.value}`);
        let buttonSaveElement = createHtmlElement('button', ['save-btn'], 'Save song', null, { name: 'click', function: saveSong });
        let buttonLikeElement = createHtmlElement('button', ['like-btn'], 'Like song', null, { name: 'click', function: likeSong });
        let buttonDeleteElement = createHtmlElement('button', ['delete-btn'], 'Delete', null, { name: 'click', function: deleteSong });

        appendChildren([imgElement, h2GenreElement, h2NameElement, h2AuthorElement, h3Element, buttonSaveElement, buttonLikeElement, buttonDeleteElement], divParentElement);

        let allHitsParentDivElement = document.querySelector('div.all-hits-container');
        appendChildren([divParentElement], allHitsParentDivElement);

        genreInputElement.value = '';
        nameInputElement.value = '';
        authorInputElement.value = '';
        dateInputElement.value = '';
    }

    function likeSong(e) {
        let targetLikeButton = e.target;
        targetLikeButton.disabled = true;

        let totalLikesPElement = document.querySelector('section#total-likes p');
        let likes = Number(totalLikesPElement.textContent.split(': ').map((x) => x.trim())[1]);
        likes++;

        totalLikesPElement.textContent = `Total Likes: ${likes}`;
    }

    function saveSong(e) {
        let targetSong = e.target.parentElement;
        targetSong.children[5].remove();
        targetSong.children[5].remove();

        let savedContainerDivParentElement = document.querySelector('div.saved-container');
        appendChildren([targetSong], savedContainerDivParentElement);
    }

    function deleteSong(e) {
        let targetSong = e.target.parentElement;
        targetSong.remove();
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