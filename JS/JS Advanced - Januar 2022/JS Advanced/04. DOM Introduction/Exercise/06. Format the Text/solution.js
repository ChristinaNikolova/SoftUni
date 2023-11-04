function solve() {
  let inputTextAreaElement = document.getElementById('input');

  const sentences = inputTextAreaElement.value
    .split('.')
    .map((x) => x.trim())
    .filter((x) => x !== '')
    .map((x) => x + '.');

  let currentSentences = [];
  let result = '';

  for (let i = 0; i < sentences.length; i++) {
    const currentSentence = sentences[i];

    if (i === 0) {
      currentSentences.push(currentSentence);
      continue;
    }

    if (currentSentences.length === 3) {
      result += `<p>${currentSentences.join('')}</p>`;
      currentSentences = [];
    }

    currentSentences.push(currentSentence);
  }

  if (currentSentences.length > 0) {
    result += `<p>${currentSentences.join('')}</p>`;
  }

  let outputDivElement = document.getElementById('output');
  outputDivElement.innerHTML = result;

  inputTextAreaElement.value = '';

  // second solution
  // let inputTextAreaElement = document.getElementById('input');
  // console.log(inputTextAreaElement.value);

  // let sentences = inputTextAreaElement.value
  //   .split('.')
  //   .map((x) => x.trim())
  //   .filter((x) => x !== '')
  //   .map((x) => x + '.');

  // let result = '';

  // while (sentences.length > 0) {
  //   const currentGroupSentences = sentences.splice(0, 3);
  //   result += `<p>${currentGroupSentences.join('')}</p>`
  // }

  // let outputDivElement = document.getElementById('output');
  // outputDivElement.innerHTML = result;

  // inputTextAreaElement.value = '';
}