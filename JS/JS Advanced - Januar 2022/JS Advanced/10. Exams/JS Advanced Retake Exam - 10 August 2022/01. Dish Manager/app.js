window.addEventListener("load", solve);

function solve() {
  const firstNameInputElement = document.getElementById("first-name");
  const lastNameInputElement = document.getElementById("last-name");
  const ageInputElement = document.getElementById("age");
  const genderSelectElement = document.getElementById("genderSelect");
  const dishDescriptionTextareaElement = document.getElementById("task");
  const progressCountSpanElement = document.getElementById("progress-count");
  const finishedListElement = document.getElementById("finished");

  document.getElementById("form-btn").addEventListener("click", submitForm);
  document.getElementById("clear-btn").addEventListener("click", clearTasks);

  function submitForm() {
    if (
      !firstNameInputElement.value ||
      !lastNameInputElement.value ||
      !ageInputElement.value ||
      !dishDescriptionTextareaElement.value ||
      !genderSelectElement.value
    ) {
      return;
    }

    const nameH4Element = createHTMLElement(
      "h4",
      `${firstNameInputElement.value} ${lastNameInputElement.value}`
    );
    const infoPElement = createHTMLElement(
      "p",
      `${genderSelectElement.value}, ${ageInputElement.value}`
    );
    const descPElement = createHTMLElement(
      "p",
      `Dish description: ${dishDescriptionTextareaElement.value}`
    );
    const articleParentElement = createHTMLElement("article");

    appendChildren(
      articleParentElement,
      nameH4Element,
      infoPElement,
      descPElement
    );

    const editButonElement = createHTMLElement(
      "button",
      "Edit",
      ["edit-btn"],
      null,
      { name: "click", function: editInfo }
    );
    const completeButonElement = createHTMLElement(
      "button",
      "Mark as complete",
      ["complete-btn"],
      null,
      { name: "click", function: completeTask }
    );
    const liParentElement = createHTMLElement("li", "", ["each-line"]);

    appendChildren(
      liParentElement,
      articleParentElement,
      editButonElement,
      completeButonElement
    );

    const inProgressListElement = document.getElementById("in-progress");

    appendChildren(inProgressListElement, liParentElement);

    firstNameInputElement.value = "";
    lastNameInputElement.value = "";
    ageInputElement.value = "";
    genderSelectElement.value = "";
    dishDescriptionTextareaElement.value = "";

    progressCountSpanElement.textContent = Number(
      ++progressCountSpanElement.textContent
    );
  }

  function completeTask(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();
    targetLiElement.children[1].remove();

    appendChildren(finishedListElement, targetLiElement);
    progressCountSpanElement.textContent = Number(
      --progressCountSpanElement.textContent
    );
  }

  function clearTasks() {
    finishedListElement.innerHTML = "";
  }

  function editInfo(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];

    const [firstName, lastName] = splitText(
      targetArticleElement.children[0].textContent,
      " "
    );
    const [gender, age] = splitText(
      targetArticleElement.children[1].textContent,
      ","
    );

    firstNameInputElement.value = firstName;
    lastNameInputElement.value = lastName;
    ageInputElement.value = age;
    genderSelectElement.value = gender;
    dishDescriptionTextareaElement.value = splitText(
      targetArticleElement.children[2].textContent,
      ":"
    );

    targetLiElement.remove();
    progressCountSpanElement.textContent = Number(
      --progressCountSpanElement.textContent
    );
  }

  function splitText(text, separator) {
    const parts = text.split(separator).map((x) => x.trim());

    if (separator === ":") {
      const targetIndex = text.indexOf(":");
      return text.substring(targetIndex + 2);
    }

    return ([first, second] = [parts[0], parts[1]]);
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
