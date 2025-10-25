window.addEventListener("load", solve);

function solve() {
  const firstNameInputElement = document.getElementById("first-name");
  const lastNameInputElement = document.getElementById("last-name");
  const peopleCountInputElement = document.getElementById("people-count");
  const fromDateInputElement = document.getElementById("from-date");
  const daysCountInputElement = document.getElementById("days-count");
  const nextButtonElement = document.getElementById("next-btn");

  nextButtonElement.addEventListener("click", buyTickets);

  function buyTickets(e) {
    e.preventDefault();

    if (
      !firstNameInputElement.value ||
      !lastNameInputElement.value ||
      !peopleCountInputElement.value ||
      !fromDateInputElement.value ||
      !daysCountInputElement.value
    ) {
      return;
    }

    const nameH3Element = createHTMLElement(
      "h3",
      `Name: ${firstNameInputElement.value} ${lastNameInputElement.value}`
    );
    const fromDatePElement = createHTMLElement(
      "p",
      `From date: ${fromDateInputElement.value}`
    );
    const forDaysPElement = createHTMLElement(
      "p",
      `For ${daysCountInputElement.value} days`
    );
    const forPeoplePElement = createHTMLElement(
      "p",
      `For ${peopleCountInputElement.value} people`
    );

    const articleParentElement = createHTMLElement("article");
    appendChildren(
      articleParentElement,
      nameH3Element,
      fromDatePElement,
      forDaysPElement,
      forPeoplePElement
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
      { name: "click", function: continueInfo }
    );

    const liParentElement = createHTMLElement("li", "", ["ticket"]);
    appendChildren(
      liParentElement,
      articleParentElement,
      editButtonElement,
      continueButtonElement
    );

    const ticketInfoListElement = document.querySelector("ul.ticket-info-list");
    appendChildren(ticketInfoListElement, liParentElement);

    firstNameInputElement.value = "";
    lastNameInputElement.value = "";
    peopleCountInputElement.value = "";
    fromDateInputElement.value = "";
    daysCountInputElement.value = "";
    nextButtonElement.setAttribute("disabled", "disabled");
  }

  function editInfo(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];

    const [firstName, lastName] = splitText(
      targetArticleElement.children[0].textContent
    );

    firstNameInputElement.value = firstName;
    lastNameInputElement.value = lastName;
    peopleCountInputElement.value = splitText(
      targetArticleElement.children[3].textContent
    );
    fromDateInputElement.value = splitText(
      targetArticleElement.children[1].textContent
    );
    daysCountInputElement.value = splitText(
      targetArticleElement.children[2].textContent
    );

    targetLiElement.remove();
    nextButtonElement.removeAttribute("disabled");
  }

  function continueInfo(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();
    targetLiElement.children[1].remove();

    const confirmButtonElement = createHTMLElement(
      "button",
      "Confirm",
      ["confirm-btn"],
      null,
      { name: "click", function: confirm }
    );
    const cancelButtonElement = createHTMLElement(
      "button",
      "Cancel",
      ["cancel-btn"],
      null,
      { name: "click", function: cancel }
    );

    appendChildren(targetLiElement, confirmButtonElement, cancelButtonElement);

    const ticketInfoListElement = document.querySelector("ul.confirm-ticket");
    appendChildren(ticketInfoListElement, targetLiElement);
  }

  function confirm() {
    const h1Element = createHTMLElement(
      "h1",
      "Thank you, have a nice day!",
      null,
      { id: "thank-you" }
    );
    const buttonElement = createHTMLElement(
      "button",
      "Back",
      null,
      {
        id: "back-btn",
      },
      { name: "click", function: back }
    );

    const bodyElement = document.getElementById("body");
    bodyElement.children[0].remove();

    appendChildren(bodyElement, h1Element, buttonElement);
  }

  function cancel(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.remove();
    nextButtonElement.removeAttribute("disabled");
  }

  function back() {
    location.reload();
  }

  function splitText(text) {
    const parts = text.split(" ").map((x) => x.trim());

    if (parts[0].startsWith("Name:")) {
      return [parts[1], parts[2]];
    }

    if (parts[0].startsWith("From")) {
      return parts[2];
    }

    return parts[1];
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
