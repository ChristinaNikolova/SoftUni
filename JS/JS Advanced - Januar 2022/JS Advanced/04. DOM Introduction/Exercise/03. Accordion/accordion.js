function toggle() {
    let toogleSpanElement = document.querySelector('span.button');
    let extraDivElement = document.getElementById('extra');

    if (toogleSpanElement.textContent === 'More') {
        toogleSpanElement.textContent = 'Less';
        extraDivElement.style.display = 'block';
    } else {
        toogleSpanElement.textContent = 'More';
        extraDivElement.style.display = 'none';
    }
}