function validate() {
    let emailInputElement = document.getElementById('email');
    emailInputElement.addEventListener('change', check);

    function check() {
        const validateEmailRegex = new RegExp(/^[a-z]+[@][a-z]+[.][a-z]+$/);

        if (!emailInputElement.value.match(validateEmailRegex)) {
            emailInputElement.classList.add('error');
        } else {
            emailInputElement.classList.remove('error');
        }
    }
}