function printDeckOfCards(input) {

    function createCard(face, suit) {
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

    let areValid = true;

    const cards = input.reduce((acc, curr) => {
        const face = curr.slice(0, curr.length - 1);
        const suit = curr.slice(curr.length - 1);

        try {
            const card = createCard(face, suit);
            acc.push(card);
        } catch {
            console.log(`Invalid card: ${curr}`);
            areValid = false;
            return;
        }

        return acc;
    }, []);

    if (areValid) {
        console.log(cards.join(' '));
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);