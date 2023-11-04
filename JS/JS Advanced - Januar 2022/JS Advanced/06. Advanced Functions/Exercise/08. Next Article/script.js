function getArticleGenerator(articles) {
    function showNext() {
        if (articles.length === 0) {
            return;
        }

        let articleElement = document.createElement('article');
        articleElement.textContent = articles.shift();

        let contentDivElement = document.getElementById('content');
        contentDivElement.appendChild(articleElement);
    }

    return showNext.bind(this, articles);
}