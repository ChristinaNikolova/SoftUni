function extract(content) {
    let contentElement = document.getElementById(content);

    const regex = new RegExp(/\(([^)]+)\)/, 'gm');
    const matches = contentElement.textContent
        .match(regex)
        .map((x) => x.slice(1, x.length - 1));

    return matches.join('; ');
}