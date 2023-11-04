function deleteByEmail() {
    let emailInputElement = document.querySelector('input[name="email"]');
    let trTbodyElements = document.querySelectorAll('tbody tr');
    let isFound = false;

    Array.from(trTbodyElements).forEach((tr) => {
        let tdChildren = Array.from(tr.children);

        if (tdChildren.some((x) => x.textContent === emailInputElement.value)) {
            tr.remove();
            isFound = true;
        }
    });

    const result = isFound ? 'Deleted.' : 'Not found.';

    let resultDivElement = document.getElementById('result');
    resultDivElement.textContent = result;

    emailInputElement.value = '';
}