function attachGradientEvents() {
    let gradientDivElement = document.getElementById('gradient');
    gradientDivElement.addEventListener('mousemove', calculate);
    gradientDivElement.addEventListener('mouseout', remove);

    let resultDivElement = document.getElementById('result');

    function calculate(e) {
        let result = Math.floor(e.offsetX / e.target.clientWidth * 100);
        resultDivElement.innerHTML = `${result}%`;
    }

    function remove() {
        resultDivElement.innerHTML = '';
    }
}