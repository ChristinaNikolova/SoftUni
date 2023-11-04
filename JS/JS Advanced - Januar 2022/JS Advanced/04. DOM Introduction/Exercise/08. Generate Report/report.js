function generateReport() {
    let trTHeadElements = document.querySelector('thead tr');
    let tdChildrenTrTHeadAsArray = Array.from(trTHeadElements.children);

    let selectedIndexArray = [];

    tdChildrenTrTHeadAsArray.forEach((td, i) => {
        if (td.children[0].checked) {
            selectedIndexArray.push(i);
        }
    });

    let trTBodyElements = document.querySelectorAll('tbody tr');
    let result = [];

    Array.from(trTBodyElements).forEach((tr) => {
        let currentResult = {};

        Array.from(tr.children).forEach((td, i) => {
            if (selectedIndexArray.includes(i)) {
                const colName = tdChildrenTrTHeadAsArray[i].textContent.toLowerCase().trim();
                currentResult[colName] = td.textContent;
            }
        });

        result.push(currentResult);
    });

    result = JSON.stringify(result, null, 4);

    let outputTextAreaElement = document.getElementById('output');
    outputTextAreaElement.value = result;
}