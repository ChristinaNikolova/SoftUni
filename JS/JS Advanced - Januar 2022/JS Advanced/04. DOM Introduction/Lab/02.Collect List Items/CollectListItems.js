function extractText() {
    let liElements = document.querySelectorAll('ul#items li');
    let resultTextAreaElement = document.getElementById('result');

    Array.from(liElements).forEach((li) => {
        resultTextAreaElement.textContent += li.textContent + '\n';
    });

    resultTextAreaElement.textContent = resultTextAreaElement.textContent.trimEnd();
}