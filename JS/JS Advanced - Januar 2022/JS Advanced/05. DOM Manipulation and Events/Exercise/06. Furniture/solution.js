function solve() {
  let buttonElements = document.getElementsByTagName('button');
  let textareaElements = document.getElementsByTagName('textarea');
  let parentTBodyElement = document.getElementsByTagName('tbody')[0];

  let generateButtonElement = buttonElements[0];
  generateButtonElement.addEventListener('click', generate);

  let buyButtonElement = buttonElements[1];
  buyButtonElement.addEventListener('click', buy);

  function generate() {
    let generateTextAreaElement = textareaElements[0];
    let exampleTrElement = document.querySelector('tbody tr');

    JSON.parse(generateTextAreaElement.value).forEach((curr) => {
      let clonedTrElement = exampleTrElement.cloneNode(true);

      clonedTrElement.children[0].children[0].src = curr.img;
      clonedTrElement.children[1].children[0].textContent = curr.name;
      clonedTrElement.children[2].children[0].textContent = curr.price;
      clonedTrElement.children[3].children[0].textContent = curr.decFactor;
      clonedTrElement.children[4].children[0].removeAttribute('disabled');

      // for Judge
      // clonedTrElement.children[0].innerHTML = `<img src=${curr.img}>`;
      // clonedTrElement.children[1].innerHTML = `<p>${curr.name}</p>`;
      // clonedTrElement.children[2].innerHTML = `<p>${curr.price}</p>`;
      // clonedTrElement.children[3].innerHTML = `<p>${curr.decFactor}</p>`;
      // clonedTrElement.children[4].innerHTML = `<input type="checkbox"/>`;

      parentTBodyElement.appendChild(clonedTrElement);
    });

    generateTextAreaElement.value = '';
  }

  function buy() {
    let boughtFurniture = [];
    let totalPrice = 0;
    let sumlDecFactor = 0;

    Array.from(parentTBodyElement.children).forEach((tr) => {
      const isChecked = tr.children[4].children[0].checked;

      if (isChecked) {
        const name = tr.children[1].children[0].textContent;
        boughtFurniture.push(name);

        const price = Number(tr.children[2].children[0].textContent);
        totalPrice += price;

        const decFactor = Number(tr.children[3].children[0].textContent);
        sumlDecFactor += decFactor;
      }
    });

    const avgDecFactor = sumlDecFactor / boughtFurniture.length;
    const resultMessage = `Bought furniture: ${boughtFurniture.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgDecFactor}`;

    let buyTextAreaElement = textareaElements[1];
    buyTextAreaElement.value = resultMessage;
  }
}