function solve() {
    let addWorkerButtonElement = document.getElementById('add-worker');
    addWorkerButtonElement.addEventListener('click', addWorker);

    let fnameInputElement = document.getElementById('fname');
    let lnameInputElement = document.getElementById('lname');
    let emailInputElement = document.getElementById('email');
    let birthInputElement = document.getElementById('birth');
    let positionInputElement = document.getElementById('position');
    let salaryInputElement = document.getElementById('salary');

    let sumSpanElement = document.getElementById('sum');

    function addWorker(e) {
        e.preventDefault();

        if (!fnameInputElement.value ||
            !lnameInputElement.value ||
            !emailInputElement.value ||
            !birthInputElement.value ||
            !positionInputElement.value ||
            !salaryInputElement.value) {
            return;
        }

        let trParentElement = createHtmlElement('tr');
        let tdFirstNameElement = createHtmlElement('td', null, `${fnameInputElement.value}`);
        let tdLastNameElement = createHtmlElement('td', null, `${lnameInputElement.value}`);
        let tdEmailElement = createHtmlElement('td', null, `${emailInputElement.value}`);
        let tdBirthElement = createHtmlElement('td', null, `${birthInputElement.value}`);
        let tdPositionElement = createHtmlElement('td', null, `${positionInputElement.value}`);
        let tdSalaryElement = createHtmlElement('td', null, `${salaryInputElement.value}`);
        let tdParentButtonsElement = createHtmlElement('td');
        let buttonFiredElement = createHtmlElement('button', ['fired'], 'Fired', null, { name: 'click', function: firedWorker });
        let buttonEditElement = createHtmlElement('button', ['edit'], 'Edit', null, { name: 'click', function: editWorker });

        appendChildren([buttonFiredElement, buttonEditElement], tdParentButtonsElement);
        appendChildren([tdFirstNameElement, tdLastNameElement, tdEmailElement, tdBirthElement, tdPositionElement, tdSalaryElement, tdParentButtonsElement], trParentElement);

        let tbodyParentElement = document.getElementById('tbody');
        appendChildren([trParentElement], tbodyParentElement);

        let totalSum = Number(sumSpanElement.textContent);
        let salary = Number(salaryInputElement.value);

        sumSpanElement.textContent = (totalSum + salary).toFixed(2);

        fnameInputElement.value = '';
        lnameInputElement.value = '';
        emailInputElement.value = '';
        birthInputElement.value = '';
        positionInputElement.value = '';
        salaryInputElement.value = '';
    }

    function editWorker(e) {
        let targetEmployee = e.target.parentElement.parentElement;
        let targetSalary = Number(targetEmployee.children[5].textContent);

        let totalSum = Number(sumSpanElement.textContent);
        sumSpanElement.textContent = (totalSum - targetSalary).toFixed(2);

        fnameInputElement.value = targetEmployee.children[0].textContent;
        lnameInputElement.value = targetEmployee.children[1].textContent;
        emailInputElement.value = targetEmployee.children[2].textContent;
        birthInputElement.value = targetEmployee.children[3].textContent;
        positionInputElement.value = targetEmployee.children[4].textContent;
        salaryInputElement.value = targetEmployee.children[5].textContent;

        targetEmployee.remove();
    }

    function firedWorker(e) {
        let targetEmployee = e.target.parentElement.parentElement;
        let targetSalary = Number(targetEmployee.children[5].textContent);

        let totalSum = Number(sumSpanElement.textContent);
        sumSpanElement.textContent = (totalSum - targetSalary).toFixed(2);

        targetEmployee.remove();
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

solve()