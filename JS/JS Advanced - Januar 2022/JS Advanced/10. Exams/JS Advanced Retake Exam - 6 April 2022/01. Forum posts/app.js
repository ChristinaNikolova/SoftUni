window.addEventListener("load", solve);

function solve() {
  const titleInputElement = document.getElementById("post-title");
  const categoryInputElement = document.getElementById("post-category");
  const contentTextareaElement = document.getElementById("post-content");
  const publishedListElement = document.getElementById("published-list");

  document.getElementById("publish-btn").addEventListener("click", publishPost);
  document.getElementById("clear-btn").addEventListener("click", clearPosts);

  function publishPost() {
    if (
      !titleInputElement.value ||
      !categoryInputElement.value ||
      !contentTextareaElement.value
    ) {
      return;
    }

    const titleH4Element = createHTMLElement("h4", titleInputElement.value);
    const categoryPElement = createHTMLElement(
      "p",
      `Category: ${categoryInputElement.value}`
    );
    const contentPElement = createHTMLElement(
      "p",
      `Content: ${contentTextareaElement.value}`
    );

    const articleParentElement = createHTMLElement("article");
    appendChildren(
      articleParentElement,
      titleH4Element,
      categoryPElement,
      contentPElement
    );

    const editButtonElement = createHTMLElement(
      "button",
      "Edit",
      ["action-btn", "edit"],
      null,
      { name: "click", function: editPost }
    );
    const approveButtonElement = createHTMLElement(
      "button",
      "Approve",
      ["action-btn", "approve"],
      null,
      { name: "click", function: approvePost }
    );

    const liParentElement = createHTMLElement("li", "", ["rpost"]);
    appendChildren(
      liParentElement,
      articleParentElement,
      editButtonElement,
      approveButtonElement
    );

    const reviewListElement = document.getElementById("review-list");
    appendChildren(reviewListElement, liParentElement);

    titleInputElement.value = "";
    categoryInputElement.value = "";
    contentTextareaElement.value = "";
  }

  function editPost(e) {
    const targetLiElement = e.target.parentElement;
    const targetArticleElement = targetLiElement.children[0];

    titleInputElement.value = targetArticleElement.children[0].textContent;
    categoryInputElement.value = splitText(
      targetArticleElement.children[1].textContent
    );
    contentTextareaElement.value = splitText(
      targetArticleElement.children[2].textContent
    );

    targetLiElement.remove();
  }

  function approvePost(e) {
    const targetLiElement = e.target.parentElement;
    targetLiElement.children[1].remove();
    targetLiElement.children[1].remove();
    appendChildren(publishedListElement, targetLiElement);
  }

  function clearPosts() {
    publishedListElement.innerHTML = "";
  }

  function splitText(text) {
    const separatorIndex = text.indexOf(":");
    return text.substring(separatorIndex + 2);
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
