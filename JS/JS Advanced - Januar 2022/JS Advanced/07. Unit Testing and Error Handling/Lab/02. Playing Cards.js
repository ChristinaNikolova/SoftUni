function solve(face, suit) {
    const validCardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const validCardSuits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    };

    if (!validCardFaces.includes(face.toUpperCase()) || !validCardSuits.hasOwnProperty(suit.toUpperCase())) {
        throw new Error('Error');
    }

    const card = {
        face,
        suit: validCardSuits[suit],
    };

    function toString() {
        return `${card.face}${card.suit}`;
    }

    return toString();
}

console.log(solve('A', 'S'));
console.log(solve('10', 'H'));
console.log(solve('1', 'C'));