function solve() {
  let textInputElement = document.getElementById('text');
  let namingConventionInputElement = document.getElementById('naming-convention');

  const namingConvention = namingConventionInputElement.value.toLowerCase();

  let resultSpanElement = document.getElementById('result');

  if (namingConvention !== 'camel case' && namingConvention !== 'pascal case') {
    resultSpanElement.textContent = 'Error!';
    clearInputs(textInputElement, namingConventionInputElement);
    return;
  }

  let words = textInputElement.value.split(' ').map((x) => x.trim());
  let result = '';

  if (namingConvention === 'camel case') {
    const firstWord = words.shift();
    result += firstWord.toLowerCase();
  }

  words = words
    .map((x) => x[0].toUpperCase() + x.slice(1).toLowerCase())
    .join('');

  result += words;
  resultSpanElement.textContent = result;

  clearInputs(textInputElement, namingConventionInputElement);

  function clearInputs(textInputElement, namingConventionInputElement) {
    textInputElement.value = '';
    namingConventionInputElement.value = '';
  }
}