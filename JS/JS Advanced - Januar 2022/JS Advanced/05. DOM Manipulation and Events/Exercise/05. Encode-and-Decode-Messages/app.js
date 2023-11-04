function encodeAndDecodeMessages() {
    let buttonElements = document.getElementsByTagName('button');
    let textareaElements = document.getElementsByTagName('textarea');

    let encodeButtonElement = buttonElements[0];
    encodeButtonElement.addEventListener('click', encode);

    let decodeButtonElement = buttonElements[1];
    decodeButtonElement.addEventListener('click', decode);

    let decodeTextArea = textareaElements[1];

    function encode() {
        let encodeTextArea = textareaElements[0];

        const message = encodeTextArea.value
            .split('')
            .map((x) => x.charCodeAt(0) + 1)
            .map((x) => String.fromCharCode(x))
            .join('');

        encodeTextArea.value = '';
        decodeTextArea.value = message;
    }

    function decode() {
        const message = decodeTextArea.value
            .split('')
            .map((x) => x.charCodeAt(0) - 1)
            .map((x) => String.fromCharCode(x))
            .join('');

        decodeTextArea.value = message;
    }
}