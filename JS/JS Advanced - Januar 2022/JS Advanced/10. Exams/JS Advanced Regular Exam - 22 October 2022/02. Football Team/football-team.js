class footballTeam {
  constructor(clubName, country) {
    this.clubName = clubName;
    this.country = country;
    this.invitedPlayers = [];
  }

  newAdditions(footballPlayers) {
    const result = footballPlayers.reduce((acc, curr) => {
      let [name, age, playerValue] = curr.split("/").map((x) => x.trim());
      age = Number(age);
      playerValue = Number(playerValue);

      const targetPlayer = this.findPlayer(name);

      if (!targetPlayer) {
        this.invitedPlayers.push({ name, age, playerValue });
        acc.push(name);
      } else if (targetPlayer.playerValue < playerValue) {
        targetPlayer.playerValue = playerValue;
      }

      return acc;
    }, []);

    return `You successfully invite ${result.join(", ")}.`;
  }

  signContract(selectedPlayer) {
    const [name, playerOffer] = selectedPlayer.split("/").map((x) => x.trim());
    const targetPlayer = this.findPlayer(name);

    if (!targetPlayer) {
      throw new Error(`${name} is not invited to the selection list!`);
    }

    if (targetPlayer.playerValue > playerOffer) {
      throw new Error(
        `The manager's offer is not enough to sign a contract with ${name}, ${
          targetPlayer.playerValue - playerOffer
        } million more are needed to sign the contract!`
      );
    }

    targetPlayer.playerValue = "Bought";

    return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
  }

  ageLimit(name, age) {
    const targetPlayer = this.findPlayer(name);

    if (!targetPlayer) {
      throw new Error(`${name} is not invited to the selection list!`);
    }

    if (targetPlayer.age < age) {
      if (age - targetPlayer.age < 5) {
        return `${name} will sign a contract for ${
          age - targetPlayer.age
        } years with ${this.clubName} in ${this.country}!`;
      }

      return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
    }

    return `${name} is above age limit!`;
  }

  transferWindowResult() {
    const players = this.invitedPlayers
      .sort((a, b) => a.name.localeCompare(b.name))
      .map((x) => `Player ${x.name}-${x.playerValue}`)
      .join("\n");

    return `Players list:\n${players}`;
  }

  findPlayer(name) {
    return this.invitedPlayers.find((x) => x.name === name);
  }
}

// let fTeam = new FootballTeam("Barcelona", "Spain");
// console.log(
//   fTeam.newAdditions([
//     "Kylian Mbappé/23/160",
//     "Lionel Messi/35/50",
//     "Pau Torres/25/52",
//     "Pau Torres/25/52",
//   ])
// );

// let fTeam = new FootballTeam("Barcelona", "Spain");
// console.log(
//   fTeam.newAdditions([
//     "Kylian Mbappé/23/160",
//     "Lionel Messi/35/50",
//     "Pau Torres/25/52",
//   ])
// );
// console.log(fTeam.signContract("Lionel Messi/60"));
// console.log(fTeam.signContract("Kylian Mbappé/240"));
// console.log(fTeam.signContract("Barbukov/10"));

// let fTeam = new FootballTeam("Barcelona", "Spain");
// console.log(
//   fTeam.newAdditions([
//     "Kylian Mbappé/23/160",
//     "Lionel Messi/35/50",
//     "Pau Torres/25/52",
//   ])
// );
// console.log(fTeam.ageLimit("Lionel Messi", 33));
// console.log(fTeam.ageLimit("Kylian Mbappé", 30));
// console.log(fTeam.ageLimit("Pau Torres", 26));
// console.log(fTeam.signContract("Kylian Mbappé/240"));

let fTeam = new FootballTeam("Barcelona", "Spain");
console.log(
  fTeam.newAdditions([
    "Kylian Mbappé/23/160",
    "Lionel Messi/35/50",
    "Pau Torres/25/52",
  ])
);
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());
