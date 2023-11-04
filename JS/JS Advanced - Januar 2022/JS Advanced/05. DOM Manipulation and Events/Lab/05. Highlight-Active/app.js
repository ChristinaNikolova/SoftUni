function focused() {
    let inputElements = document.querySelectorAll('input[type="text"]');

    Array.from(inputElements).forEach((input) => {
        input.addEventListener('focus', focus);
        input.addEventListener('blur', focus);
    });

    function focus(e) {
        let targetElement = e.target.parentElement;

        if (targetElement.classList.contains('focused')) {
            targetElement.classList.remove('focused');

        } else {
            targetElement.classList.add('focused');
        }
    }
}