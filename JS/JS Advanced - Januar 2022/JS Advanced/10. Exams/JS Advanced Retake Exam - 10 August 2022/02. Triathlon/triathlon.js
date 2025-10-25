class Triathlon {
  constructor(competitionName) {
    this.competitionName = competitionName;
    this.participants = {};
    this.listOfFinalists = [];
  }

  addParticipant(participantName, participantGender) {
    if (this.participants.hasOwnProperty(participantName)) {
      return `${participantName} has already been added to the list`;
    }

    this.participants[participantName] = participantGender;

    return `A new participant has been added - ${participantName}`;
  }

  completeness(participantName, condition) {
    if (!this.participants.hasOwnProperty(participantName)) {
      throw new Error`${participantName} is not in the current participants list`();
    }

    if (condition < 30) {
      throw new Error(
        `${participantName} is not well prepared and cannot finish any discipline`
      );
    }

    const completedCount = Math.floor(condition / 30);

    if (completedCount === 1 || completedCount === 2) {
      return `${participantName} could only complete ${completedCount} of the disciplines`;
    }

    this.listOfFinalists.push({
      participantName,
      participantGender: this.participants[participantName],
    });
    delete this.participants[participantName];

    return `Congratulations, ${participantName} finished the whole competition`;
  }

  rewarding(participantName) {
    if (
      !this.listOfFinalists.some((x) => x.participantName === participantName)
    ) {
      return `${participantName} is not in the current finalists list`;
    }

    return `${participantName} was rewarded with a trophy for his performance`;
  }

  showRecord(criteria) {
    if (!this.listOfFinalists.length) {
      return "There are no finalists in this competition";
    }

    if (
      (criteria === "male" &&
        !this.listOfFinalists.some((x) => x.participantGender === criteria)) ||
      (criteria === "female" &&
        !this.listOfFinalists.some((x) => x.participantGender === criteria))
    ) {
      return `There are no ${criteria}'s that finished the competition`;
    }

    if (criteria === "male" || criteria === "female") {
      const firstAdded = this.listOfFinalists.filter(
        (x) => x.participantGender === criteria
      )[0];
      return `${firstAdded.participantName} is the first ${criteria} that finished the ${this.competitionName} triathlon`;
    }

    const sortedFinalists = this.listOfFinalists
      .sort((a, b) => a.participantName.localeCompare(b.participantName))
      .map((x) => `${x.participantName}`)
      .join("\n");

    return `List of all ${this.competitionName} finalists:\n${sortedFinalists}`;
  }
}

// const contest = new Triathlon("Dynamos");
// console.log(contest.addParticipant("Peter", "male"));
// console.log(contest.addParticipant("Sasha", "female"));
// console.log(contest.addParticipant("Peter", "male"));

// const contest = new Triathlon("Dynamos");
// console.log(contest.addParticipant("Peter", "male"));
// console.log(contest.addParticipant("Sasha", "female"));
// console.log(contest.addParticipant("George", "male"));
// console.log(contest.completeness("Peter", 100));
// console.log(contest.completeness("Sasha", 70));
// console.log(contest.completeness("George", 20));

// const contest = new Triathlon("Dynamos");
// console.log(contest.addParticipant("Peter", "male"));
// console.log(contest.addParticipant("Sasha", "female"));
// console.log(contest.completeness("Peter", 100));
// console.log(contest.completeness("Sasha", 70));
// console.log(contest.rewarding("Peter"));
// console.log(contest.rewarding("Sasha"));

// const contest = new Triathlon("Dynamos");
// console.log(contest.showRecord("all"));

const contest = new Triathlon("Dynamos");
console.log(contest.addParticipant("Peter", "male"));
console.log(contest.addParticipant("Sasha", "female"));
console.log(contest.addParticipant("Mimi", "female"));
// console.log(contest.completeness("Peter", 100));
console.log(contest.completeness("Sasha", 90));
console.log(contest.completeness("Mimi", 90));
// console.log(contest.rewarding("Peter"));
console.log(contest.rewarding("Sasha"));
console.log(contest.rewarding("Mimi"));
console.log(contest.showRecord("male"));
