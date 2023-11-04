function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchFieldInputElement = document.getElementById('searchField');
      let trTBodyElements = document.querySelectorAll('tbody tr');

      Array.from(trTBodyElements).forEach((tr) => {
         let tdChildrenElements = Array.from(tr.children);

         if (tdChildrenElements.some((x) => x.textContent.toLowerCase().includes(searchFieldInputElement.value.toLowerCase()))) {
            tr.classList.add('select');
         } else {
            tr.classList.remove('select');
         }
      });

      searchFieldInputElement.value = '';
   }
}