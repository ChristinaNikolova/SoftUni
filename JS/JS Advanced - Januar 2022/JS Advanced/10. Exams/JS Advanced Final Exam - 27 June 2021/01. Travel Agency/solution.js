window.addEventListener('load', solution);

function solution() {
  let submitButtonElement = document.getElementById('submitBTN');
  submitButtonElement.addEventListener('click', previewInfo);

  let editButtonElement = document.getElementById('editBTN');
  editButtonElement.addEventListener('click', editInfo);

  let continueButtonElement = document.getElementById('continueBTN');
  continueButtonElement.addEventListener('click', sendInfo);

  let fnameInputElement = document.getElementById('fname');
  let emailInputElement = document.getElementById('email');
  let phoneInputElement = document.getElementById('phone');
  let addressInputElement = document.getElementById('address');
  let codeInputElement = document.getElementById('code');
  let infoPreviewUlParentElement = document.getElementById('infoPreview');

  function previewInfo() {
    if (!fnameInputElement.value || !emailInputElement.value) {
      return;
    }

    let liFNameElement = createHtmlElement('li', null, `Full Name: ${fnameInputElement.value}`);
    let liEmailElement = createHtmlElement('li', null, `Email: ${emailInputElement.value}`);
    let liPhoneElement = createHtmlElement('li', null, `Phone Number: ${phoneInputElement.value}`);
    let liAddressElement = createHtmlElement('li', null, `Address: ${addressInputElement.value}`);
    let liCodeElement = createHtmlElement('li', null, `Postal Code: ${codeInputElement.value}`);

    appendChildren([liFNameElement, liEmailElement, liPhoneElement, liAddressElement, liCodeElement], infoPreviewUlParentElement);

    submitButtonElement.disabled = true;
    editButtonElement.disabled = false;
    continueButtonElement.disabled = false;

    fnameInputElement.value = '';
    emailInputElement.value = '';
    phoneInputElement.value = '';
    addressInputElement.value = '';
    codeInputElement.value = '';
  }

  function editInfo() {
    fnameInputElement.value = infoPreviewUlParentElement.children[0].textContent.split(':').map((x) => x.trim())[1];
    emailInputElement.value = infoPreviewUlParentElement.children[1].textContent.split(':').map((x) => x.trim())[1];
    phoneInputElement.value = infoPreviewUlParentElement.children[2].textContent.split(':').map((x) => x.trim())[1];
    addressInputElement.value = infoPreviewUlParentElement.children[3].textContent.split(':').map((x) => x.trim())[1];
    codeInputElement.value = infoPreviewUlParentElement.children[4].textContent.split(':').map((x) => x.trim())[1];

    infoPreviewUlParentElement.innerHTML = '';

    submitButtonElement.disabled = false;
    editButtonElement.disabled = true;
    continueButtonElement.disabled = true;
  }

  function sendInfo() {
    let blockDivParentElement = document.getElementById('block');
    blockDivParentElement.innerHTML = '';

    let h3Element = createHtmlElement('h3', null, 'Thank you for your reservation!');
    appendChildren([h3Element], blockDivParentElement);
  }

  function createHtmlElement(
    tagName,
    classNames,
    textContent,
    attributes,
    event
  ) {
    let element = document.createElement(tagName);

    if (classNames) {
      element.classList.add(...classNames);
    }

    if (textContent) {
      element.textContent = textContent;
    }

    if (attributes) {
      attributes.forEach((a) => element.setAttribute(a.key, a.value));
    }

    if (event) {
      element.addEventListener(event.name, event.function);
    }

    return element;
  }

  function appendChildren(children, parent) {
    children.forEach((c) => parent.appendChild(c));
    return parent;
  }
}
