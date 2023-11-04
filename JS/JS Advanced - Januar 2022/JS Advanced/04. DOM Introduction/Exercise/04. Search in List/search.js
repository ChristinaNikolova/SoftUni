function search() {
   let searchTextInputElement = document.getElementById('searchText');
   let townsLiElements = document.querySelectorAll('ul#towns li');

   let counterMatches = 0;

   Array.from(townsLiElements).forEach((li) => {
      if (li.textContent.toLowerCase().includes(searchTextInputElement.value.toLowerCase())) {
         li.style.textDecoration = 'underline';
         li.style.fontWeight = 'bold';
         counterMatches++;
      } else {
         li.style.textDecoration = 'none';
         li.style.fontWeight = 'normal';
      }
   });

   let resultDivElement = document.getElementById('result');
   resultDivElement.textContent = `${counterMatches} matches found`;

   searchTextInputElement.value = '';
}
