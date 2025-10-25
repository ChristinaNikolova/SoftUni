window.addEventListener("load", solve);

function solve() {
  const firstNameInputElement = document.getElementById("first-name");
  const lastNameInputElement = document.getElementById("last-name");
  const ageInputElement = document.getElementById("age");
  const storyTitleInputElement = document.getElementById("story-title");
  const genreSelectElement = document.getElementById("genre");
  const storyTextAreaElement = document.getElementById("story");
  const publishButtonElement = document.getElementById("form-btn");

  publishButtonElement.addEventListener("click", publishStory);

  function publishStory() {
    if (
      !firstNameInputElement.value ||
      !lastNameInputElement.value ||
      !ageInputElement.value ||
      !storyTitleInputElement.value ||
      !storyTextAreaElement.value
    ) {
      return;
    }

    const nameH4Element = createHTMLElement(
      "h4",
      `Name: ${firstNameInputElement.value} ${lastNameInputElement.value}`
    );
    const agePElement = createHTMLElement("p", `Age: ${ageInputElement.value}`);
    const titlePElement = createHTMLElement(
      "p",
      `Title: ${storyTitleInputElement.value}`
    );
    const genrePElement = createHTMLElement(
      "p",
      `Genre: ${genreSelectElement.value}`
    );
    const textPElement = createHTMLElement("p", storyTextAreaElement.value);
    const articleParentElement = createHTMLElement("article");

    appendChildren(
      articleParentElement,
      nameH4Element,
      agePElement,
      titlePElement,
      genrePElement,
      textPElement
    );

    const saveButtonElement = createHTMLElement(
      "button",
      "Save Story",
      ["save-btn"],
      null,
      { name: "click", function: saveStory }
    );
    const editButtonElement = createHTMLElement(
      "button",
      "Edit Story",
      ["edit-btn"],
      null,
      { name: "click", function: editStory }
    );
    const deleteButtonElement = createHTMLElement(
      "button",
      "Delete Story",
      ["delete-btn"],
      null,
      { name: "click", function: deleteStory }
    );
    const liParentElement = createHTMLElement("li", "", ["story-info"]);

    appendChildren(
      liParentElement,
      articleParentElement,
      saveButtonElement,
      editButtonElement,
      deleteButtonElement
    );

    const previewListElement = document.getElementById("preview-list");
    appendChildren(previewListElement, liParentElement);

    firstNameInputElement.value = "";
    lastNameInputElement.value = "";
    ageInputElement.value = "";
    storyTitleInputElement.value = "";
    genreSelectElement.value = "Disturbing";
    storyTextAreaElement.value = "";
    publishButtonElement.setAttribute("disabled", "disabled");
  }

  function editStory(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];
    const [firstName, lastName] = splitText(
      targetArticleElement.children[0].textContent
    );

    firstNameInputElement.value = firstName;
    lastNameInputElement.value = lastName;
    ageInputElement.value = splitText(
      targetArticleElement.children[1].textContent
    );
    storyTitleInputElement.value = splitText(
      targetArticleElement.children[2].textContent
    );
    genreSelectElement.value = splitText(
      targetArticleElement.children[3].textContent
    );
    storyTextAreaElement.value = targetArticleElement.children[4].textContent;

    targetLiElement.remove();
    publishButtonElement.removeAttribute("disabled");
  }

  function saveStory() {
    const mainDivElement = document.getElementById("main");
    mainDivElement.innerHTML = "";

    const h1Element = createHTMLElement("h1", "Your scary story is saved!");
    appendChildren(mainDivElement, h1Element);
  }

  function deleteStory(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.remove();
    publishButtonElement.removeAttribute("disabled");
  }

  function splitText(text) {
    const parts = text.split(":").map((x) => x.trim());

    if (parts[0].startsWith("Name")) {
      return ([firstName, lastName] = parts[1].split(" ").map((x) => x.trim()));
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
