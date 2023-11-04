function solve() {
  let answerPElements = document.querySelectorAll('p.answer-text');
  let sectionElements = document.getElementsByTagName('section');

  Array.from(answerPElements).forEach((p) => {
    p.addEventListener('click', quiz);
  });

  let counterAnswers = 0;
  let counterCorrectAnswers = 0;
  const correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

  function quiz(e) {
    let targetAnswer = e.target;

    const isCorrectAnswer = correctAnswers.includes(targetAnswer.textContent);

    if (isCorrectAnswer) {
      counterCorrectAnswers++;
    }

    sectionElements[counterAnswers].style.display = 'none';
    counterAnswers++;

    if (counterAnswers === 3) {
      const resultMessage = counterCorrectAnswers === correctAnswers.length
        ? 'You are recognized as top JavaScript fan!'
        : `You have ${counterCorrectAnswers} right answers`;

      let resultH1Element = document.querySelector('ul#results h1');
      resultH1Element.textContent = resultMessage;

      let resultUlElement = document.getElementById('results');
      resultUlElement.style.display = 'block';
      return;
    }

    sectionElements[counterAnswers].style.display = 'block';
  }
}
