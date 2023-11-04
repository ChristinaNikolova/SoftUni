function validate() {
    let submitButtonElement = document.getElementById('submit');
    submitButtonElement.addEventListener('click', validateForm);

    let companyInputElement = document.getElementById('company');
    companyInputElement.addEventListener('change', companyInfo)

    function validateForm(e) {
        e.preventDefault();

        let usernameInputElement = document.getElementById('username');
        const isUsernameValid = checkUsername(usernameInputElement.value);
        isUsernameValid ? usernameInputElement.style.borderColor = 'none' : usernameInputElement.style.borderColor = 'red';

        let emailInputElement = document.getElementById('email');
        const isEmailValid = checkEmail(emailInputElement.value);
        isEmailValid ? emailInputElement.style.borderColor = 'none' : emailInputElement.style.borderColor = 'red';

        let passwordInputElement = document.getElementById('password');
        const isPasswordValid = checkPassword(passwordInputElement.value);
        isPasswordValid ? passwordInputElement.style.borderColor = 'none' : passwordInputElement.style.borderColor = 'red';

        let confirmPasswordInputElement = document.getElementById('confirm-password');
        const isConfirmPasswordValid = checkPassword(confirmPasswordInputElement.value) && confirmPasswordInputElement.value === passwordInputElement.value;
        isConfirmPasswordValid ? confirmPasswordInputElement.style.borderColor = 'none' : confirmPasswordInputElement.style.borderColor = 'red';

        let isCompanyNumberValid = true;

        if (companyInputElement.checked) {
            let companyNumberInputElement = document.getElementById('companyNumber');
            isCompanyNumberValid = checkCompanyNumber(companyNumberInputElement.value);
            isCompanyNumberValid ? companyNumberInputElement.style.borderColor = 'none' : companyNumberInputElement.style.borderColor = 'red';
        }

        let validDivElement = document.getElementById('valid');

        if (isUsernameValid && isEmailValid && isPasswordValid && isConfirmPasswordValid && isCompanyNumberValid) {
            validDivElement.style.display = 'block';
        } else {
            validDivElement.style.display = 'none';
        }
    }

    function companyInfo(e) {
        let companyInfoFieldsetElement = document.getElementById('companyInfo');

        if (e.target.checked) {
            companyInfoFieldsetElement.style.display = 'block';
        } else {
            companyInfoFieldsetElement.style.display = 'none';
        }
    }

    function checkUsername(username) {
        const validUsernameRegex = new RegExp(/^[A-Za-z0-9]{3,20}$/gm);

        return username.match(validUsernameRegex);
    }

    function checkEmail(email) {
        const validEmailRegex = new RegExp(/@(\w)*\./gm);

        return email.match(validEmailRegex);
    }

    function checkPassword(password) {
        const validPasswordRegex = new RegExp(/^[A-Za-z0-9_]{5,15}$/gm);

        return password.match(validPasswordRegex);
    }

    function checkCompanyNumber(companyNumber) {
        return Number(companyNumber) >= 1000 && Number(companyNumber) <= 9999;
    }
}
