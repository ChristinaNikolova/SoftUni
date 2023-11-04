class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        this._firstName = value;
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        this._lastName = value;
    }

    get fullName() {
        return this._firstName + ' ' + this._lastName;
    }

    set fullName(value) {
        const [newFirstName, newLastName] = value.split(' ').map((x) => x.trim());

        if (!newFirstName || !newLastName) {
            return;
            // throw new Error('Invalid parameter!');
        }

        this._firstName = newFirstName;
        this._lastName = newLastName;
    }
}

// let person = new Person("Peter", "Ivanov");
// console.log(person.fullName); //Peter Ivanov 
// person.firstName = "George";
// console.log(person.fullName); //George Ivanov 
// person.lastName = "Peterson";
// console.log(person.fullName); //George Peterson 
// person.fullName = "Nikola Tesla";
// console.log(person.firstName); //Nikola 
// console.log(person.lastName); //Tesla 

let person = new Person("Albert", "Simpson");
console.log(person.fullName); //Albert Simpson 
person.firstName = "Simon";
console.log(person.fullName); //Simon Simpson 
person.fullName = "Peter";
console.log(person.firstName);  // Simon 
console.log(person.lastName);  // Simpson 