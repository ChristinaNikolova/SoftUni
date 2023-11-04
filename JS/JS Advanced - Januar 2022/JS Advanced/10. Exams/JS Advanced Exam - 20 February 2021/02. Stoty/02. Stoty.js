class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        const likesCount = this._likes.length;

        if (likesCount === 0) {
            return `${this.title} has 0 likes`;
        }

        const firstUser = this._likes[0];

        if (likesCount === 1) {
            return `${firstUser} likes this story!`;
        }

        return `${firstUser} and ${likesCount - 1} others like this story!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error('You can\'t like the same story twice!');
        }

        if (username === this.creator) {
            throw new Error('You can\'t like your own story!');
        }

        this._likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        const usernameIndex = this._likes.indexOf(username);

        if (usernameIndex === -1) {
            throw new Error('You can\'t dislike this story!');
        }

        this._likes.splice(usernameIndex, 1);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let comment;

        if (!id || !this._comments.some((x) => x.id === id)) {
            comment = {
                id: this._comments.length + 1,
                username,
                content,
                replies: [],
            };

            this._comments.push(comment);

            return `${username} commented on ${this.title}`;
        }

        comment = this._comments.find((x) => x.id === id);

        let reply = {
            id: `${comment.id}.${comment.replies.length + 1}`,
            username,
            content,
        };

        comment.replies.push(reply);

        return 'You replied successfully';
    }

    toString(sortingType) {
        let messageToReturn = `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n`;

        if (this._comments.length > 0) {
            if (sortingType === 'asc') {
                this._comments
                    .sort((a, b) => a.id - b.id)
                    .forEach((comment) => {
                        messageToReturn += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`;

                        if (comment.replies.length > 0) {
                            comment.replies
                                .sort((a, b) => a.id - b.id)
                                .forEach((reply) => {
                                    messageToReturn += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                                });
                        }
                    });
            } else if (sortingType === 'desc') {
                this._comments
                    .sort((a, b) => b.id - a.id)
                    .forEach((comment) => {
                        messageToReturn += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`;

                        if (comment.replies.length > 0) {
                            comment.replies
                                .sort((a, b) => b.id - a.id)
                                .forEach((reply) => {
                                    messageToReturn += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                                });
                        }
                    });
            } else if (sortingType === 'username') {
                this._comments
                    .sort((a, b) => a.username.localeCompare(b.username))
                    .forEach((comment) => {
                        messageToReturn += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`;

                        if (comment.replies.length > 0) {
                            comment.replies
                                .sort((a, b) => a.username.localeCompare(b.username))
                                .forEach((reply) => {
                                    messageToReturn += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
                                });
                        }
                    });
            }
        }

        return messageToReturn.trimEnd();
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username')); 
console.log() 
art.like("Zane"); 
console.log(art.toString('desc')); 