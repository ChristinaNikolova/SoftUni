function editElement(reference, matcher, replacer) {
    while (reference.textContent.includes(matcher)) {
        reference.textContent = reference.textContent.replace(matcher, replacer);
    }
}