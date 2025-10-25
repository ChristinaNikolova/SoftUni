window.addEventListener("load", solution);

function solution() {
  const employeeInputElement = document.getElementById("employee");
  const categorySelectElement = document.getElementById("category");
  const urgencySelectElement = document.getElementById("urgency");
  const teamSelectElement = document.getElementById("team");
  const descriptionInputElement = document.getElementById("description");
  const resolvedListElement = document.querySelector("ul.resolved-list");

  const addButtonElement = document.getElementById("add-btn");
  addButtonElement.addEventListener("click", addProblem);

  function addProblem(e) {
    e.preventDefault();

    if (
      !employeeInputElement.value ||
      !categorySelectElement.value ||
      !urgencySelectElement.value ||
      !teamSelectElement.value ||
      !descriptionInputElement.value
    ) {
      return;
    }

    const fromPElement = createHTMLElement(
      "p",
      `From: ${employeeInputElement.value}`
    );
    const categoryPElement = createHTMLElement(
      "p",
      `Category: ${categorySelectElement.value}`
    );
    const urgencyPElement = createHTMLElement(
      "p",
      `Urgency: ${urgencySelectElement.value}`
    );
    const assignedPElement = createHTMLElement(
      "p",
      `Assigned to: ${teamSelectElement.value}`
    );
    const descriptionPElement = createHTMLElement(
      "p",
      `Description: ${descriptionInputElement.value}`
    );
    const editButtonElement = createHTMLElement(
      "button",
      "Edit",
      ["edit-btn"],
      null,
      { name: "click", function: editProblem }
    );
    const continueButtonElement = createHTMLElement(
      "button",
      "Continue",
      ["continue-btn"],
      null,
      { name: "click", function: continuePending }
    );

    const articleParentElement = createHTMLElement("article");
    const liParentElement = createHTMLElement("li", "", ["problem-content"]);

    appendChildren(
      articleParentElement,
      fromPElement,
      categoryPElement,
      urgencyPElement,
      assignedPElement,
      descriptionPElement
    );
    appendChildren(
      liParentElement,
      articleParentElement,
      editButtonElement,
      continueButtonElement
    );

    const previewListElement = document.querySelector("ul.preview-list");
    appendChildren(previewListElement, liParentElement);

    employeeInputElement.value = "";
    categorySelectElement.value = "";
    urgencySelectElement.value = "";
    teamSelectElement.value = "";
    descriptionInputElement.value = "";
    addButtonElement.setAttribute("disabled", "disabled");
  }

  function editProblem(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];

    employeeInputElement.value = splitText(
      targetArticleElement.children[0].textContent
    );
    categorySelectElement.value = splitText(
      targetArticleElement.children[1].textContent
    );
    urgencySelectElement.value = splitText(
      targetArticleElement.children[2].textContent
    );
    teamSelectElement.value = splitText(
      targetArticleElement.children[3].textContent
    );
    descriptionInputElement.value = splitText(
      targetArticleElement.children[4].textContent
    );

    targetLiElement.remove();
    addButtonElement.removeAttribute("disabled");
  }

  function continuePending(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();
    targetLiElement.children[1].remove();

    const resolvedButtonElement = createHTMLElement(
      "button",
      "Resolved",
      ["resolve-btn"],
      null,
      { name: "click", function: resolveProblem }
    );
    appendChildren(targetLiElement, resolvedButtonElement);

    const pendingListElement = document.querySelector("ul.pending-list");
    appendChildren(pendingListElement, targetLiElement);
    addButtonElement.removeAttribute("disabled");
  }

  function resolveProblem(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();

    const clearButtonElement = createHTMLElement(
      "button",
      "Clear",
      ["clear-btn"],
      null,
      { name: "click", function: clearProblem }
    );

    appendChildren(targetLiElement, clearButtonElement);
    appendChildren(resolvedListElement, targetLiElement);
  }

  function clearProblem() {
    resolvedListElement.innerHTML = "";
  }

  function splitText(text) {
    return text.split(":").map((x) => x.trim())[1];
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
