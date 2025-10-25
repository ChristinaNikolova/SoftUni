window.addEventListener("load", solve);

function solve() {
  const typeSelectElement = document.getElementById("type");
  const intensitySelectElement = document.getElementById("intensity");
  const caloriesInputElement = document.getElementById("calories");
  const durationInputElement = document.getElementById("duration");
  const dateInputElement = document.getElementById("date");
  const addActivityButtonElement = document.getElementById("add-activity");

  addActivityButtonElement.addEventListener("click", addActivity);

  function addActivity() {
    addActivityButtonElement.setAttribute("disabled", "disabled");

    if (
      !typeSelectElement.value ||
      !intensitySelectElement.value ||
      !caloriesInputElement.value ||
      !durationInputElement.value ||
      !dateInputElement.value
    ) {
      return;
    }

    const activityPElement = createHTMLElement(
      "p",
      `Activity: ${typeSelectElement.value}`
    );
    const intensityPElement = createHTMLElement(
      "p",
      `Intensity: ${intensitySelectElement.value}`
    );
    const durationPElement = createHTMLElement(
      "p",
      `Duration: ${durationInputElement.value}`
    );
    const datePElement = createHTMLElement(
      "p",
      `Date: ${dateInputElement.value}`
    );
    const caloriesPElement = createHTMLElement(
      "p",
      `Calories: ${caloriesInputElement.value}`
    );
    const editButtonElement = createHTMLElement(
      "button",
      "Edit",
      ["edit-btn"],
      null,
      { name: "click", function: editActivity }
    );
    const nextButtonElement = createHTMLElement(
      "button",
      "Next",
      ["next-btn"],
      null,
      { name: "click", function: nextActivity }
    );

    const articleParentElement = createHTMLElement("article");
    const divParentElement = createHTMLElement("div", "", ["btn-container"]);
    const liParentElement = createHTMLElement("li");

    appendChildren(divParentElement, editButtonElement, nextButtonElement);
    appendChildren(
      articleParentElement,
      activityPElement,
      intensityPElement,
      durationPElement,
      datePElement,
      caloriesPElement
    );
    appendChildren(liParentElement, articleParentElement, divParentElement);

    const previewActivityUlElement =
      document.getElementById("preview-activity");
    appendChildren(previewActivityUlElement, liParentElement);

    typeSelectElement.value = "";
    intensitySelectElement.value = "";
    caloriesInputElement.value = "";
    durationInputElement.value = "";
    dateInputElement.value = "";
  }

  function editActivity(e) {
    addActivityButtonElement.removeAttribute("disabled");
    const targetLiElement = e.target.parentElement.parentElement;
    const targetArticleElement = e.target.parentElement.previousSibling;

    typeSelectElement.value = splitContent(
      targetArticleElement.children[0].textContent
    );
    intensitySelectElement.value = splitContent(
      targetArticleElement.children[1].textContent
    );
    caloriesInputElement.value = splitContent(
      targetArticleElement.children[4].textContent
    );
    durationInputElement.value = splitContent(
      targetArticleElement.children[2].textContent
    );
    dateInputElement.value = splitContent(
      targetArticleElement.children[3].textContent
    );

    targetLiElement.remove();
  }

  function nextActivity(e) {
    addActivityButtonElement.removeAttribute("disabled");
    const targetLiElement = e.target.parentElement.parentElement;
    const targetArticleElement = e.target.parentElement.previousSibling;

    const activityTdElement = createHTMLElement(
      "td",
      splitContent(targetArticleElement.children[0].textContent),
      ["type-cell"]
    );
    const durationTdElement = createHTMLElement(
      "td",
      splitContent(targetArticleElement.children[2].textContent),
      ["duration-cell"]
    );
    const caloiesTdElement = createHTMLElement(
      "td",
      splitContent(targetArticleElement.children[4].textContent),
      ["calories-cell"]
    );
    const dateTdElement = createHTMLElement(
      "td",
      splitContent(targetArticleElement.children[3].textContent),
      ["date-cell"]
    );
    const intensityTdElement = createHTMLElement(
      "td",
      splitContent(targetArticleElement.children[1].textContent),
      ["intensity-cell"]
    );
    const deleteButtonElement = createHTMLElement(
      "button",
      "Delete",
      ["delete-btn"],
      null,
      { name: "click", function: deleteActivity }
    );

    const tdParentElement = createHTMLElement("td", "", ["btn-cell"]);
    const trParentElement = createHTMLElement("tr");

    appendChildren(tdParentElement, deleteButtonElement);
    appendChildren(
      trParentElement,
      activityTdElement,
      durationTdElement,
      caloiesTdElement,
      dateTdElement,
      intensityTdElement,
      tdParentElement
    );

    const activitiesTableElement = document.getElementById("activities-table");
    appendChildren(activitiesTableElement, trParentElement);

    targetLiElement.remove();
  }

  function deleteActivity(e) {
    addActivityButtonElement.removeAttribute("disabled");
    e.target.parentElement.parentElement.remove();
  }

  function splitContent(content) {
    return content.split(":").map((x) => x.trim())[1];
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
