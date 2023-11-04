class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            'picture': 200,
            'photo': 50,
            'item': 250,
        };
        this.listOfArticles = [];
        this.guests = [];
        this.guestPoints = {
            'Vip': 500,
            'Middle': 250,
        };
    }

    addArticle(articleModel, articleName, quantity) {
        quantity = Number(quantity);
        articleModel = articleModel.toLowerCase();

        if (!this.possibleArticles.hasOwnProperty(articleModel)) {
            throw new Error('This article model is not included in this gallery!');
        }

        let article = this.listOfArticles.find((x) => x.articleModel === articleModel && x.articleName === articleName);

        if (!article) {
            article = {
                articleModel,
                articleName,
                quantity,
            };

            this.listOfArticles.push(article);
        } else {
            article.quantity += quantity;
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some((x) => x.guestName === guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }

        let guest = {
            guestName,
            points: 50,
            purchaseArticle: 0,
        };

        if (this.guestPoints.hasOwnProperty(personality)) {
            guest.points = this.guestPoints[personality];
        }

        this.guests.push(guest);

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        let article = this.listOfArticles.find((x) => x.articleModel === articleModel && x.articleName === articleName);

        if (!article) {
            throw new Error('This article is not found.');
        }

        if (article.quantity === 0) {
            return `The ${articleName} is not available.`;
        }

        let guest = this.guests.find((x) => x.guestName === guestName);

        if (!guest) {
            return 'This guest is not invited.';
        }

        const neededPoints = this.possibleArticles[articleModel];

        if (guest.points < neededPoints) {
            return 'You need to more points to purchase the article.';
        }

        guest.points -= neededPoints;
        guest.purchaseArticle++;
        article.quantity--;

        return `${guestName} successfully purchased the article worth ${neededPoints} points.`;
    }

    showGalleryInfo(criteria) {
        let messageToReturn = '';

        if (criteria === 'article') {
            messageToReturn += 'Articles information:\n';
            this.listOfArticles.map((x) => messageToReturn += `${x.articleModel} - ${x.articleName} - ${x.quantity}\n`);
        } else if (criteria === 'guest') {
            messageToReturn += 'Guests information:\n';
            this.guests.map((x) => messageToReturn += `${x.guestName} - ${x.purchaseArticle}\n`);
        }

        return messageToReturn.trimEnd();
    }
}

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.addArticle('picture', 'Mona Liza', 3));
// console.log(artGallery.addArticle('Item', 'Ancient vase', 2));
// console.log(artGallery.addArticle('PICTURE', 'Mona Liza', 1));

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.inviteGuest('John', 'Vip'));
// console.log(artGallery.inviteGuest('Peter', 'Middle'));
// console.log(artGallery.inviteGuest('John', 'Middle'));

// const artGallery = new ArtGallery('Curtis Mayfield');
// artGallery.addArticle('picture', 'Mona Liza', 3);
// artGallery.addArticle('Item', 'Ancient vase', 2);
// artGallery.addArticle('picture', 'Mona Liza', 1);
// artGallery.inviteGuest('John', 'Vip');
// artGallery.inviteGuest('Peter', 'Middle');
// console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
// console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
// console.log(artGallery.buyArticle('item', 'Mona Liza', 'John')); 

const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest')); 