class WineSelection {
  constructor(space) {
    this.space = space;
    this.wines = [];
    this.bill = 0;
  }

  reserveABottle(wineName, wineType, price) {
    if (this.wines.length === this.space) {
      throw new Error("Not enough space in the cellar.");
    }

    this.wines.push({ wineName, wineType, price, paid: false });

    return `You reserved a bottle of ${wineName} ${wineType} wine.`;
  }

  payWineBottle(wineName, price) {
    const targetWine = this.wines.find((x) => x.wineName === wineName);

    if (!targetWine) {
      throw new Error(`${wineName} is not in the cellar.`);
    }

    if (targetWine.paid) {
      throw new Error(`${wineName} has already been paid.`);
    }

    targetWine.paid = true;
    this.bill += price;

    return `You bought a ${wineName} for a ${price}$.`;
  }

  openBottle(wineName) {
    const targetWine = this.wines.find((x) => x.wineName === wineName);

    if (!targetWine) {
      throw new Error("The wine, you're looking for, is not found.");
    }

    if (!targetWine.paid) {
      throw new Error(`${wineName} need to be paid before open the bottle.`);
    }

    this.wines = this.wines.filter((x) => x.wineName !== wineName);

    return `You drank a bottle of ${wineName}.`;
  }

  cellarRevision(wineType) {
    if (!wineType) {
      const result = this.wines
        .sort((a, b) => a.wineName.localeCompare(b.wineName))
        .map(
          (x) =>
            `${x.wineName} > ${x.wineType} - ${
              x.paid ? "Has Paid" : "Not Paid"
            }.`
        )
        .join("\n");

      return `You have space for ${
        this.space - this.wines.length
      } bottles more.\nYou paid ${this.bill}$ for the wine.\n${result}`;
    }

    if (!this.wines.some((x) => x.wineType === wineType)) {
      throw new Error(`There is no ${wineType} in the cellar.`);
    }

    return this.wines
      .map(
        (x) =>
          `${x.wineName} > ${x.wineType} - ${x.paid ? "Has Paid" : "Not Paid"}.`
      )
      .join("\n");
  }
}

// const selection = new WineSelection(2);
// console.log(
//   selection.reserveABottle("Sauvignon Blanc Marlborough", "White", 50)
// );
// console.log(
//   selection.reserveABottle("Cabernet Sauvignon Napa Valley", "Red", 120)
// );
// console.log(selection.reserveABottle("Bodegas Godelia Mencía", "Rose", 144));

// const selection = new WineSelection(2);
// selection.reserveABottle("Sauvignon Blanc Marlborough", "White", 50);
// console.log(selection.payWineBottle("Sauvignon Blanc Marlborough", 120));
// console.log(selection.payWineBottle("Sauvignon Blanc Marlborough", 120));
// console.log(selection.payWineBottle("Bodegas Godelia Mencía", 144));

// const selection = new WineSelection(2);
// selection.reserveABottle("Sauvignon Blanc Marlborough", "White", 50);
// selection.reserveABottle("Cabernet Sauvignon Napa Valley", "Red", 120);
// selection.payWineBottle("Sauvignon Blanc Marlborough", 50);
// console.log(selection.openBottle("Sauvignon Blanc Marlborough"));
// console.log(selection.openBottle("Cabernet Sauvignon Napa Valley"));
// console.log(selection.openBottle("Test"));

// const selection = new WineSelection(2);
// console.log(selection.reserveABottle("Bodegas Godelia Mencía", "Rose", 144));
// console.log(selection.cellarRevision("Rose"));

const selection = new WineSelection(5);
selection.reserveABottle("Bodegas Godelia Mencía", "Rose", 144);
selection.payWineBottle("Bodegas Godelia Mencía", 144);
selection.reserveABottle("Sauvignon Blanc Marlborough", "White", 50);
selection.reserveABottle("Cabernet Sauvignon Napa Valley", "Red", 120);
console.log(selection.cellarRevision());
