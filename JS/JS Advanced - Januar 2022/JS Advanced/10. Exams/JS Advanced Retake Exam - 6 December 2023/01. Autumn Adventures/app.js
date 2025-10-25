window.addEventListener("load", solve);

function solve() {
  const timeInputElement = document.getElementById("time");
  const dateInputElement = document.getElementById("date");
  const placeInputElement = document.getElementById("place");
  const eventNameInputElement = document.getElementById("event-name");
  const emailInputElement = document.getElementById("email");
  const finishedListElement = document.getElementById("finished-list");
  const addButtonElement = document.getElementById("add-btn");
  const clearButtonElement = document.getElementById("clear");

  addButtonElement.addEventListener("click", addEvent);
  clearButtonElement.addEventListener("click", clearEvent);

  function clearEvent() {
    finishedListElement.innerHTML = "";
  }

  function addEvent() {
    if (
      !timeInputElement.value ||
      !dateInputElement.value ||
      !placeInputElement.value ||
      !eventNameInputElement.value ||
      !emailInputElement.value
    ) {
      return;
    }

    const beginPElement = createHTMLElement(
      "p",
      `Begins: ${dateInputElement.value} at: ${timeInputElement.value}`
    );
    const placePElement = createHTMLElement(
      "p",
      `In: ${placeInputElement.value}`
    );
    const eventPElement = createHTMLElement(
      "p",
      `Event: ${eventNameInputElement.value}`
    );
    const contactPElement = createHTMLElement(
      "p",
      `Contact: ${emailInputElement.value}`
    );
    const editButtonElement = createHTMLElement(
      "button",
      "Edit",
      ["edit-btn"],
      null,
      { name: "click", function: editEvent }
    );
    const continueButtonElement = createHTMLElement(
      "button",
      "Continue",
      ["continue-btn"],
      null,
      { name: "click", function: continueEvent }
    );

    const articleParentElement = createHTMLElement("article");
    const liParentElement = createHTMLElement("li", "", ["event-content"]);

    appendChildren(
      articleParentElement,
      beginPElement,
      placePElement,
      eventPElement,
      contactPElement
    );
    appendChildren(
      liParentElement,
      articleParentElement,
      editButtonElement,
      continueButtonElement
    );

    const checkListElement = document.getElementById("check-list");
    appendChildren(checkListElement, liParentElement);

    timeInputElement.value = "";
    dateInputElement.value = "";
    placeInputElement.value = "";
    eventNameInputElement.value = "";
    emailInputElement.value = "";
    addButtonElement.setAttribute("disabled", "disabled");
  }

  function editEvent(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = e.target.parentElement.children[0];

    const date = splitText(targetArticleElement.children[0].textContent)[0];
    const time = splitText(targetArticleElement.children[0].textContent)[1];
    timeInputElement.value = time;
    dateInputElement.value = date;
    placeInputElement.value = splitText(
      targetArticleElement.children[1].textContent
    );
    eventNameInputElement.value = splitText(
      targetArticleElement.children[2].textContent
    );
    emailInputElement.value = splitText(
      targetArticleElement.children[3].textContent
    );

    targetLiElement.remove();
    addButtonElement.removeAttribute("disabled");
  }

  function continueEvent(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();
    targetLiElement.children[1].remove();

    const finishButtonElement = createHTMLElement(
      "button",
      "Move to Finished",
      ["finished-btn"],
      null,
      { name: "click", function: finishEvent }
    );
    appendChildren(targetLiElement, finishButtonElement);

    const upcomingListElement = document.getElementById("upcoming-list");
    appendChildren(upcomingListElement, targetLiElement);
    addButtonElement.removeAttribute("disabled");
  }

  function finishEvent(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();
    appendChildren(finishedListElement, targetLiElement);
  }

  function splitText(text) {
    const parts = text.split(":");

    if (parts.length > 2) {
      const date = parts[1].trim().split(" ")[0].trim();
      const time = `${parts[2].trim()}:${parts[3].trim()}`;
      return [date, time];
    }

    return parts[1].trim();
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
