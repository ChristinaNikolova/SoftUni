class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length === this.capacity) {
            throw new Error('Not enough space in the collection.');
        }

        let book = {
            bookName,
            bookAuthor,
            payed: false,
        };

        this.books.push(book);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        let book = this.books.find((x) => x.bookName === bookName);

        if (!book) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (book.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }

        book.payed = true;

        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let bookIndex = this.books.findIndex((x) => x.bookName === bookName);

        if (bookIndex === -1) {
            throw new Error('The book, you\'re looking for, is not found.');
        }

        let book = this.books[bookIndex];

        if (!book.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books.splice(bookIndex, 1);

        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let messageToReturn = '';

        if (!bookAuthor) {
            const emptySlots = this.capacity - this.books.length;
            messageToReturn += `The book collection has ${emptySlots} empty spots left.\n`;

            this.books
                .sort((a, b) => a.bookName.localeCompare(b.bookName))
                .forEach((book) => {
                    const isPayedMessage = book.payed ? 'Has Paid' : 'Not Paid';
                    messageToReturn += `${book.bookName} == ${book.bookAuthor} - ${isPayedMessage}.\n`;
                });
        } else {
            let filteredBooks = this.books.filter((x) => x.bookAuthor === bookAuthor);

            if (filteredBooks.length === 0) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            } else {
                filteredBooks
                    .forEach((book) => {
                        const isPayedMessage = book.payed ? 'Has Paid' : 'Not Paid';
                        messageToReturn += `${book.bookName} == ${book.bookAuthor} - ${isPayedMessage}.\n`;
                    });
            }
        }

        return messageToReturn.trimEnd();
    }
}

// const library = new LibraryCollection(2);
// console.log(library.addBook('In Search of Lost Time', 'Marcel Proust'));
// console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
// console.log(library.addBook('Ulysses', 'James Joyce'));

// const library = new LibraryCollection(2);
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// console.log(library.payBook('In Search of Lost Time'));
// console.log(library.payBook('Don Quixote'));

// const library = new LibraryCollection(2);
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// library.addBook('Don Quixote', 'Miguel de Cervantes');
// library.payBook('Don Quixote');
// console.log(library.removeBook('Don Quixote'));
// console.log(library.removeBook('In Search of Lost Time')); 

// const library = new LibraryCollection(2);
// console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
// console.log(library.getStatistics('Miguel de Cervantes'));

// const library = new LibraryCollection(5);
// library.addBook('Don Quixote', 'Miguel de Cervantes');
// library.payBook('Don Quixote');
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// library.addBook('Ulysses', 'James Joyce');
// console.log(library.getStatistics()); 