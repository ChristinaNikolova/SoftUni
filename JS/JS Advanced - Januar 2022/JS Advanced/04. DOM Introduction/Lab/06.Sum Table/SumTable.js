function sumTable() {
    let tdElements = document.querySelectorAll('tr td');
    let tdElementsAsArray = Array.from(tdElements);

    let sumTdElement = tdElementsAsArray.pop();
    let sum = 0;

    tdElementsAsArray.forEach((td, i) => {
        if (i % 2 === 1) {
            sum += Number(td.textContent);
        }
    });

    sumTdElement.textContent = sum;
}