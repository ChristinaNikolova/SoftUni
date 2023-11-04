function solve() {
    let addButtonElement = document.getElementById('add');
    addButtonElement.addEventListener('click', addTask);

    let sectionElements = document.getElementsByTagName('section');

    function addTask(e) {
        e.preventDefault();

        let taskInputElement = document.getElementById('task');
        let descriptionTextAreaElement = document.getElementById('description');
        let dateInputElement = document.getElementById('date');

        if (!taskInputElement.value || !descriptionTextAreaElement.value || !dateInputElement.value) {
            return;
        }

        let articleParentElement = createHtmlElement('article');
        let h3Element = createHtmlElement('h3', null, `${taskInputElement.value}`);
        let pDescElement = createHtmlElement('p', null, `Description: ${descriptionTextAreaElement.value}`);
        let pDateElement = createHtmlElement('p', null, `Due Date: ${dateInputElement.value}`);
        let divParentButtonsElement = createHtmlElement('div', ['flex']);
        let buttonStartElement = createHtmlElement('button', ['green'], 'Start', null, { name: 'click', function: startTask });
        let buttonDeleteElement = createHtmlElement('button', ['red'], 'Delete', null, { name: 'click', function: deleteTask });

        appendChildren([buttonStartElement, buttonDeleteElement], divParentButtonsElement);
        appendChildren([h3Element, pDescElement, pDateElement, divParentButtonsElement], articleParentElement);

        let openTasksDivParentElement = sectionElements[1].children[1];
        appendChildren([articleParentElement], openTasksDivParentElement);

        taskInputElement.value = '';
        descriptionTextAreaElement.value = '';
        dateInputElement.value = '';
    }

    function startTask(e) {
        let targetTask = e.target.parentElement.parentElement;
        targetTask.children[3].children[0].remove();

        let buttonFinishElement = createHtmlElement('button', ['orange'], 'Finish', null, { name: 'click', function: finishTask });
        appendChildren([buttonFinishElement], targetTask.children[3]);

        let inProgressParentDivElement = document.getElementById('in-progress');
        appendChildren([targetTask], inProgressParentDivElement);
    }

    function deleteTask(e) {
        let targetTask = e.target.parentElement.parentElement;
        targetTask.remove();
    }

    function finishTask(e) {
        let targetTask = e.target.parentElement.parentElement;
        targetTask.children[3].remove();

        let finishedTasksDivParentElement = sectionElements[3].children[1];
        appendChildren([targetTask], finishedTasksDivParentElement);
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