window.addEventListener("load", solve);

function solve() {
  const colorSelectElement = document.getElementById("colors");
  const motorcycleSelectElement = document.getElementById("motorcycles");
  const datetimeInputElement = document.getElementById("datetime");
  const fullNameInputElement = document.getElementById("full-name");
  const emailInputElement = document.getElementById("email");
  const completeListElement = document.getElementById("complete-list");
  const addRideButtonElement = document.getElementById("test-ride-btn");

  addRideButtonElement.addEventListener("click", addRide);

  function addRide() {
    if (
      !colorSelectElement.value ||
      !motorcycleSelectElement.value ||
      !datetimeInputElement.value ||
      !fullNameInputElement.value ||
      !emailInputElement.value
    ) {
      return;
    }

    const colorPElement = createHTMLElement(
      "p",
      `Color: ${colorSelectElement.value}`
    );
    const modelPElement = createHTMLElement(
      "p",
      `Model: ${motorcycleSelectElement.value}`
    );
    const forPElement = createHTMLElement(
      "p",
      `For: ${fullNameInputElement.value}`
    );
    const emailPElement = createHTMLElement(
      "p",
      `Contact: ${emailInputElement.value}`
    );
    const datePElement = createHTMLElement(
      "p",
      `Test Ride On: ${datetimeInputElement.value}`
    );
    const editButtonElement = createHTMLElement(
      "button",
      "Edit",
      ["edit-btn"],
      null,
      { name: "click", function: editRide }
    );
    const nextButtonElement = createHTMLElement(
      "button",
      "Next",
      ["next-btn"],
      null,
      { name: "click", function: nextRide }
    );

    const articleParentElement = createHTMLElement("article");
    const divParentElement = createHTMLElement("div", "", ["btn-container"]);
    const liParentElement = createHTMLElement("li");

    appendChildren(divParentElement, editButtonElement, nextButtonElement);
    appendChildren(
      articleParentElement,
      colorPElement,
      modelPElement,
      forPElement,
      emailPElement,
      datePElement
    );
    appendChildren(liParentElement, articleParentElement, divParentElement);

    const previewListElement = document.getElementById("preview-list");
    appendChildren(previewListElement, liParentElement);

    colorSelectElement.value = "";
    motorcycleSelectElement.value = "";
    datetimeInputElement.value = "";
    fullNameInputElement.value = "";
    emailInputElement.value = "";

    addRideButtonElement.setAttribute("disabled", "disabled");
  }

  function editRide(e) {
    const targetLiElement = e.target.parentElement.parentElement;
    const targetArticleElement = e.target.parentElement.previousSibling;
    colorSelectElement.value = splitText(
      targetArticleElement.children[0].textContent
    );
    motorcycleSelectElement.value = splitText(
      targetArticleElement.children[1].textContent
    );
    datetimeInputElement.value = splitText(
      targetArticleElement.children[4].textContent
    );
    fullNameInputElement.value = splitText(
      targetArticleElement.children[2].textContent
    );
    emailInputElement.value = splitText(
      targetArticleElement.children[3].textContent
    );

    targetLiElement.remove();
    addRideButtonElement.removeAttribute("disabled");
  }

  function nextRide(e) {
    const targetElement = e.target.parentElement.parentElement;
    targetElement.children[1].remove();
    const complateButtonElement = createHTMLElement(
      "button",
      "Complete",
      ["complete-btn"],
      null,
      { name: "click", function: completeRide }
    );

    appendChildren(targetElement.children[0], complateButtonElement);
    appendChildren(completeListElement, targetElement);
  }

  function completeRide(e) {
    e.target.parentElement.parentElement.remove();
    const confirmButtonElement = createHTMLElement(
      "button",
      "Your Test Ride is Confirmed",
      ["confirm-btn"],
      null,
      { name: "click", function: reloadPage }
    );
    const completeDivElement = document.querySelector("div.data-view");
    appendChildren(completeDivElement, confirmButtonElement);
  }

  function reloadPage() {
    location.reload();
  }

  function splitText(text) {
    const parts = text.split(":");
    return parts.length > 2 ? parts.slice(1).join(":").trim() : parts[1].trim();
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
