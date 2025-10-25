window.addEventListener("load", solve);

function solve() {
  const nameInputElement = document.getElementById("gem-name");
  const colorInputElement = document.getElementById("color");
  const caratsInputElement = document.getElementById("carats");
  const priceInputElement = document.getElementById("price");
  const typeSelectElement = document.getElementById("type");
  const addGemButtonElement = document.getElementById("add-btn");

  addGemButtonElement.addEventListener("click", addGem);

  function addGem() {
    if (
      !nameInputElement.value ||
      !colorInputElement.value ||
      !caratsInputElement.value ||
      !priceInputElement.value ||
      !typeSelectElement.value
    ) {
      return;
    }

    const nameH4Element = createHTMLElement("h4", nameInputElement.value);
    const colorPElement = createHTMLElement(
      "p",
      `Color: ${colorInputElement.value}`
    );
    const caratsPElement = createHTMLElement(
      "p",
      `Carats: ${caratsInputElement.value}`
    );
    const pricePElement = createHTMLElement(
      "p",
      `Price: ${priceInputElement.value}$`
    );
    const typePElement = createHTMLElement(
      "p",
      `Type: ${typeSelectElement.value}`
    );
    const saveButtonElement = createHTMLElement(
      "button",
      "Save to Collection",
      ["save-btn"],
      null,
      { name: "click", function: saveToCollection }
    );
    const editButtonElement = createHTMLElement(
      "button",
      "Edit Information",
      ["edit-btn"],
      null,
      { name: "click", function: editGem }
    );
    const cancelButtonElement = createHTMLElement(
      "button",
      "Cancel",
      ["cancel-btn"],
      null,
      { name: "click", function: cancel }
    );

    const articleParentElement = createHTMLElement("article");
    const liParentElement = createHTMLElement("li", "", ["gem-info"]);

    appendChildren(
      articleParentElement,
      nameH4Element,
      colorPElement,
      caratsPElement,
      pricePElement,
      typePElement
    );
    appendChildren(
      liParentElement,
      articleParentElement,
      saveButtonElement,
      editButtonElement,
      cancelButtonElement
    );

    const previewListElement = document.getElementById("preview-list");
    appendChildren(previewListElement, liParentElement);

    nameInputElement.value = "";
    colorInputElement.value = "";
    caratsInputElement.value = "";
    priceInputElement.value = "";
    typeSelectElement.value = "";
    addGemButtonElement.setAttribute("disabled", "disabled");
  }

  function editGem(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];

    nameInputElement.value = targetArticleElement.children[0].textContent;
    colorInputElement.value = splitText(
      targetArticleElement.children[1].textContent
    );
    caratsInputElement.value = splitText(
      targetArticleElement.children[2].textContent
    );
    priceInputElement.value = splitText(
      targetArticleElement.children[3].textContent,
      true
    );
    typeSelectElement.value = splitText(
      targetArticleElement.children[4].textContent
    );

    targetLiElement.remove();
    addGemButtonElement.removeAttribute("disabled");
  }

  function saveToCollection(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];

    const name = targetArticleElement.children[0].textContent;
    const color = targetArticleElement.children[1].textContent;
    const carrats = targetArticleElement.children[2].textContent;
    const price = targetArticleElement.children[3].textContent;
    const type = targetArticleElement.children[4].textContent;

    const textContent = `${name} - ${color}/ ${carrats}/ ${price}/ ${type}`;

    const pElement = createHTMLElement("p", textContent, ["collection-item"]);
    const liParentElement = createHTMLElement("li");
    appendChildren(liParentElement, pElement);

    const collectionListElement = document.getElementById("collection");
    appendChildren(collectionListElement, liParentElement);

    targetLiElement.remove();
    addGemButtonElement.removeAttribute("disabled");
  }

  function cancel(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.remove();
    addGemButtonElement.removeAttribute("disabled");
  }

  function splitText(text, isPrice = false) {
    let textContent = text.split(":").map((x) => x.trim())[1];

    return !isPrice
      ? textContent
      : textContent.slice(0, textContent.length - 1);
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
