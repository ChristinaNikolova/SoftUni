function validate() {
    let emailInputElement = document.getElementById('email');
    emailInputElement.addEventListener('change', checkEmail);

    function checkEmail() {
        const validEmailRegex = new RegExp(/^[a-z]+[@][a-z]+[.][a-z]+$/gm);

        if (!emailInputElement.value.match(validEmailRegex)) {
            emailInputElement.classList.add('error');
        } else {
            emailInputElement.classList.remove('error');
        }
    }
}