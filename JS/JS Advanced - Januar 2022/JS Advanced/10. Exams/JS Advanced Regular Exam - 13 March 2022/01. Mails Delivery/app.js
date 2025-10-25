function solve() {
  const listUlElement = document.getElementById("list");
  const sendListUlElement = document.querySelector("ul.sent-list");
  const deletedListUlElement = document.querySelector("ul.delete-list");

  const recipientNameInputElement = document.getElementById("recipientName");
  const titleInputElement = document.getElementById("title");
  const messageTextareaElement = document.getElementById("message");

  document.getElementById("reset").addEventListener("click", resetForm);
  document.getElementById("add").addEventListener("click", addInfo);

  function sendInfo(e) {
    const targetElement = e.target.parentElement.parentElement;

    const toSpanElement = createHTMLElement(
      "span",
      `To: ${targetElement.children[1].textContent.split(": ")[1]}`
    );
    const titleSpanElement = createHTMLElement(
      "span",
      targetElement.children[0].textContent
    );
    const buttonElement = createHTMLElement(
      "button",
      "Delete",
      ["delete"],
      {
        type: "submit",
      },
      { name: "click", function: deleteInfo }
    );
    const divParentElement = createHTMLElement("div", "", ["btn"]);
    const liParentElement = createHTMLElement("li");

    appendChildren(divParentElement, buttonElement);
    appendChildren(
      liParentElement,
      toSpanElement,
      titleSpanElement,
      divParentElement
    );
    appendChildren(sendListUlElement, liParentElement);
    targetElement.remove();
  }

  function addInfo(e) {
    e.preventDefault();

    if (
      !recipientNameInputElement.value ||
      !titleInputElement.value ||
      !messageTextareaElement.value
    ) {
      return;
    }

    const titleH4Element = createHTMLElement(
      "h4",
      `Title: ${titleInputElement.value}`
    );
    const recipientH4Element = createHTMLElement(
      "h4",
      `Recipient Name: ${recipientNameInputElement.value}`
    );
    const spanElement = createHTMLElement("span", messageTextareaElement.value);
    const sendButtonElement = createHTMLElement(
      "button",
      "Send",
      null,
      {
        type: "submit",
        id: "send",
      },
      { name: "click", function: sendInfo }
    );
    const deleteButtonElement = createHTMLElement(
      "button",
      "Delete",
      null,
      {
        type: "submit",
        id: "delete",
      },
      { name: "click", function: deleteInfo }
    );
    const divParentElement = createHTMLElement("div", "", null, {
      id: "list-action",
    });
    const liParentElement = createHTMLElement("li");

    appendChildren(divParentElement, sendButtonElement, deleteButtonElement);
    appendChildren(
      liParentElement,
      titleH4Element,
      recipientH4Element,
      spanElement,
      divParentElement
    );

    appendChildren(listUlElement, liParentElement);
    resetForm(e);
  }

  function resetForm(e) {
    e.preventDefault();
    recipientNameInputElement.value = "";
    titleInputElement.value = "";
    messageTextareaElement.value = "";
  }

  function deleteInfo(e) {
    const targetElement = e.target.parentElement.parentElement;

    const toSpanElement = createHTMLElement(
      "span",
      `To: ${targetElement.children[1].textContent.split(": ")[1]}`
    );
    const titleSpanElement = createHTMLElement(
      "span",
      targetElement.children[0].textContent
    );
    const liParentElement = createHTMLElement("li");

    appendChildren(liParentElement, toSpanElement, titleSpanElement);
    appendChildren(deletedListUlElement, liParentElement);
    targetElement.remove();
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

solve();
