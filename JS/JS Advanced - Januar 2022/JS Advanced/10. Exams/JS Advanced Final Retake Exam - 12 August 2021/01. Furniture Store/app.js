window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.getElementById('add');
    addButtonElement.addEventListener('click', addFurniture);

    function addFurniture(e) {
        e.preventDefault();

        let modelInputElement = document.getElementById('model');
        let yearInputElement = document.getElementById('year');
        let descriptionTextAreaElement = document.getElementById('description');
        let priceInputElement = document.getElementById('price');

        if (!modelInputElement.value ||
            !descriptionTextAreaElement.value ||
            !yearInputElement.value ||
            !priceInputElement.value ||
            Number(yearInputElement.value) < 0 ||
            Number(priceInputElement.value) < 0) {
            return;
        }

        let trParentInfoElement = createHtmlElement('tr', ['info']);
        let tdModelElement = createHtmlElement('td', null, `${modelInputElement.value}`);
        let tdPriceElement = createHtmlElement('td', null, `${Number(priceInputElement.value).toFixed(2)}`);
        let tdParentButtonsElement = createHtmlElement('td');
        let buttonMoreInfoElement = createHtmlElement('button', ['moreBtn'], 'More Info', null, { name: 'click', function: moreInfo });
        let buttonBuyElement = createHtmlElement('button', ['buyBtn'], 'Buy it', null, { name: 'click', function: buyFurniture });

        appendChildren([buttonMoreInfoElement, buttonBuyElement], tdParentButtonsElement);
        appendChildren([tdModelElement, tdPriceElement, tdParentButtonsElement], trParentInfoElement);

        let trParentHideElement = createHtmlElement('tr', ['hide']);
        let tdYearElement = createHtmlElement('td', null, `Year: ${yearInputElement.value}`);
        let tdDescElement = createHtmlElement('td', null, `Description: ${descriptionTextAreaElement.value}`, [{ key: 'colspan', value: 3 }]);

        appendChildren([tdYearElement, tdDescElement], trParentHideElement);

        let furnitureListParentTBodyElement = document.getElementById('furniture-list');
        appendChildren([trParentInfoElement, trParentHideElement], furnitureListParentTBodyElement);

        modelInputElement.value = '';
        yearInputElement.value = '';
        descriptionTextAreaElement.value = '';
        priceInputElement.value = '';
    }

    function moreInfo(e) {
        let targetButton = e.target;
        let targetFurniture = targetButton.parentElement.parentElement;

        if (targetButton.textContent === 'More Info') {
            targetButton.textContent = 'Less Info';
            targetFurniture.nextSibling.style.display = 'contents';
        } else {
            targetButton.textContent = 'More Info';
            targetFurniture.nextSibling.style.display = 'none';
        }
    }

    function buyFurniture(e) {
        let targetFurniture = e.target.parentElement.parentElement;
        let nextElement = targetFurniture.nextSibling;
        const currentPrice = Number(targetFurniture.children[1].textContent);

        targetFurniture.remove();
        nextElement.remove();

        let totalPriceTdElement = document.querySelector('td.total-price');
        let totalPrice = Number(totalPriceTdElement.textContent);
        totalPrice += currentPrice;

        totalPriceTdElement.textContent = totalPrice.toFixed(2);

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
