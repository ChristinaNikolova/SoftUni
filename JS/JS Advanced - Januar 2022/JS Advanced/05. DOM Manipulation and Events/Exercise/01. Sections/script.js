function create(words) {
   words.forEach((word) => {
      let pElement = document.createElement('p');
      pElement.textContent = word;
      pElement.style.display = 'none';

      let divElement = document.createElement('div');
      divElement.addEventListener('click', showText);
      divElement.appendChild(pElement);

      let contentDivElement = document.getElementById('content');
      contentDivElement.appendChild(divElement);
   });

   function showText(e) {
      let targetElement = e.target.children[0];
      targetElement.style.display = 'block';
   }
}