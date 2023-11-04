function solve() {
   let createButtonElement = document.querySelector('button.btn.create');
   createButtonElement.addEventListener('click', createArticle);

   function createArticle(e) {
      e.preventDefault();

      let creatorInputElement = document.getElementById('creator');
      let titleInputElement = document.getElementById('title');
      let categoryInputElement = document.getElementById('category');
      let contentTextAreaElement = document.getElementById('content');

      let articleParentElement = createHtmlElement('article');
      let h1Element = createHtmlElement('h1', null, `${titleInputElement.value}`);
      let pCategoryElement = createHtmlElement('p', null, 'Category:');
      let strongCategoryElement = createHtmlElement('strong', null, `${categoryInputElement.value}`);
      let pCreatorElement = createHtmlElement('p', null, 'Creator:');
      let strongCreatorElement = createHtmlElement('strong', null, `${creatorInputElement.value}`);
      let pDescElement = createHtmlElement('p', null, `${contentTextAreaElement.value}`);
      let divParentButtonsElement = createHtmlElement('div', ['buttons']);
      let buttonDeleteElement = createHtmlElement('button', ['btn', 'delete'], 'Delete', null, { name: 'click', function: deleteArticle });
      let buttonArchiveElement = createHtmlElement('button', ['btn', 'archive'], 'Archive', null, { name: 'click', function: archiveArticle });

      appendChildren([strongCategoryElement], pCategoryElement);
      appendChildren([strongCreatorElement], pCreatorElement);
      appendChildren([buttonDeleteElement, buttonArchiveElement], divParentButtonsElement);
      appendChildren([h1Element, pCategoryElement, pCreatorElement, pDescElement, divParentButtonsElement], articleParentElement)

      let postsParentSectionElement = document.querySelector('main section');
      appendChildren([articleParentElement], postsParentSectionElement);

      creatorInputElement.value = '';
      titleInputElement.value = '';
      categoryInputElement.value = '';
      contentTextAreaElement.value = '';
   }

   function archiveArticle(e) {
      let targetArticle = e.target.parentElement.parentElement;
      const title = targetArticle.children[0].textContent;
      targetArticle.remove();

      let liElement = createHtmlElement('li', null, `${title}`);

      let archiveOlParentElement = document.querySelector('section.archive-section ol');
      appendChildren([liElement], archiveOlParentElement);

      let liChildren = Array.from(archiveOlParentElement.children);

      liChildren.forEach((li) => {
         archiveOlParentElement.removeChild(li);
      });

      liChildren = liChildren
         .sort((a, b) => a.textContent.localeCompare(b.textContent));

      liChildren.forEach((li) => {
         archiveOlParentElement.appendChild(li);
      });
   }

   function deleteArticle(e) {
      let targetArticle = e.target.parentElement.parentElement;
      targetArticle.remove();
   }

   function createHtmlElement(
      tagName,
      classNames,
      textContent,
      attributes,
      event
   ) {
      let element = document.createElement(tagName);

      if (classNames) {
         element.classList.add(...classNames);
      }

      if (textContent) {
         element.textContent = textContent;
      }

      if (attributes) {
         attributes.forEach((a) => element.setAttribute(a.key, a.value));
      }

      if (event) {
         element.addEventListener(event.name, event.function);
      }

      return element;
   }

   function appendChildren(children, parent) {
      children.forEach((c) => parent.appendChild(c));
      return parent;
   }
}
