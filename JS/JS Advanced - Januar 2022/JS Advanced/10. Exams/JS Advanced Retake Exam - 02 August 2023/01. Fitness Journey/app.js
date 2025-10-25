window.addEventListener("load", solve);

function solve() {
  const nameInputElement = document.getElementById("name");
  const emailInputElement = document.getElementById("email");
  const contactNumberInputElement = document.getElementById("contact-number");
  const classTypeSelectElement = document.getElementById("class-type");
  const classTimeSelectElement = document.getElementById("class-time");
  const nextButtonElement = document.getElementById("next-btn");

  nextButtonElement.addEventListener("click", pickClass);

  function pickClass(e) {
    e.preventDefault();

    if (
      !nameInputElement.value ||
      !emailInputElement.value ||
      !contactNumberInputElement.value ||
      !classTypeSelectElement.value ||
      !classTimeSelectElement.value
    ) {
      return;
    }

    const namePElement = createHTMLElement("p", nameInputElement.value);
    const emailPElement = createHTMLElement("p", emailInputElement.value);
    const contactNumberPElement = createHTMLElement(
      "p",
      contactNumberInputElement.value
    );
    const classTypePElement = createHTMLElement(
      "p",
      classTypeSelectElement.value
    );
    const classTimePElement = createHTMLElement(
      "p",
      classTimeSelectElement.value
    );
    const editButtonElement = createHTMLElement(
      "button",
      "Edit",
      ["edit-btn"],
      null,
      { name: "click", function: editInfo }
    );
    const continueButtonElement = createHTMLElement(
      "button",
      "Continue",
      ["continue-btn"],
      null,
      { name: "click", function: continuePick }
    );

    const articleParentElement = createHTMLElement("article", "", [
      "personal-info",
    ]);
    const liParentElement = createHTMLElement("li", "", ["info-item"]);

    appendChildren(
      articleParentElement,
      namePElement,
      emailPElement,
      contactNumberPElement,
      classTypePElement,
      classTimePElement
    );
    appendChildren(
      liParentElement,
      articleParentElement,
      editButtonElement,
      continueButtonElement
    );

    const classInfoListElement = document.querySelector("ul.class-info");
    appendChildren(classInfoListElement, liParentElement);

    nameInputElement.value = "";
    emailInputElement.value = "";
    contactNumberInputElement.value = "";
    classTypeSelectElement.value = "";
    classTimeSelectElement.value = "";
    nextButtonElement.setAttribute("disabled", "disabled");
  }

  function editInfo(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];

    nameInputElement.value = targetArticleElement.children[0].textContent;
    emailInputElement.value = targetArticleElement.children[1].textContent;
    contactNumberInputElement.value =
      targetArticleElement.children[2].textContent;
    classTypeSelectElement.value = targetArticleElement.children[3].textContent;
    classTimeSelectElement.value = targetArticleElement.children[4].textContent;

    targetLiElement.remove();
    nextButtonElement.removeAttribute("disabled");
  }

  function continuePick(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();
    targetLiElement.children[1].remove();

    const cancelButtonElement = createHTMLElement(
      "button",
      "Cancel",
      ["cancel-btn"],
      null,
      { name: "click", function: cancelPick }
    );
    const confirmButtonElement = createHTMLElement(
      "button",
      "Confirm",
      ["confirm-btn"],
      null,
      { name: "click", function: confirmPick }
    );

    appendChildren(targetLiElement, cancelButtonElement, confirmButtonElement);

    const confirmClassListElement = document.querySelector("ul.confirm-class");
    appendChildren(confirmClassListElement, targetLiElement);
  }

  function cancelPick(e) {
    e.target.parentElement.remove();
    nextButtonElement.removeAttribute("disabled");
  }

  function confirmPick() {
    document.getElementById("main").remove();
    const h1Element = createHTMLElement(
      "h1",
      "Thank you for scheduling your appointment, we look forward to seeing you!",
      null,
      { id: "thank-you" }
    );
    const doneButtonElement = createHTMLElement(
      "button",
      "Done",
      null,
      {
        id: "done-btn",
      },
      { name: "click", function: donePick }
    );

    const bodyElement = document.getElementById("body");
    appendChildren(bodyElement, h1Element, doneButtonElement);
  }

  function donePick() {
    location.reload();
  }

  function createHTMLElement(tagName, textContent, classes, attrs, event) {
    const element = document.createElement(tagName);

    if (textContent) {
      element.textContent = textContent;
    }

    if (classes && classes.length) {
      element.classList.add(...classes);
    }

    if (attrs) {
      Object.keys(attrs).forEach((key) => {
        element.setAttribute(key, attrs[key]);
      });
    }

    if (event) {
      element.addEventListener(event.name, event.function);
    }

    return element;
  }

  function appendChildren(parent, ...children) {
    children.forEach((child) => {
      parent.appendChild(child);
    });
  }
}
