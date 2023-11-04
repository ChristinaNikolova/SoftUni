function solve() {
   let addButtonElements = document.querySelectorAll('button.add-product');
   let textareaElement = document.getElementsByTagName('textarea')[0];
   let checkoutButtonElement = document.querySelector('button.checkout');

   checkoutButtonElement.addEventListener('click', checkout);

   Array.from(addButtonElements).forEach((button) => {
      button.addEventListener('click', addToBasket);
   });

   let totalPrice = 0;
   let bougthProducts = [];

   function addToBasket(e) {
      let targetProduct = e.target.parentElement.parentElement;

      const productName = targetProduct.children[1].children[0].textContent;

      if (!bougthProducts.some((x) => x === productName)) {
         bougthProducts.push(productName);
      }

      let productPrice = Number(targetProduct.children[3].textContent);
      totalPrice += productPrice;

      textareaElement.value += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
   }

   function checkout() {
      textareaElement.value += `You bought ${bougthProducts.join(', ')} for ${totalPrice.toFixed(2)}.`;

      checkoutButtonElement.setAttribute('disabled', true);

      Array.from(addButtonElements).forEach((button) => {
         button.setAttribute('disabled', true);
      });
   }
}