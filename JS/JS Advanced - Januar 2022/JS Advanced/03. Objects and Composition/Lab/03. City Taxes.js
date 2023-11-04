function cityTaxes(name, population, treasury) {
    const town = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes: function () {
            this.treasury += this.population * this.taxRate;
            Math.floor(this.treasury);
        },
        applyGrowth: function (percentage) {
            percentage = percentage / 100;
            this.population += this.population * percentage;
            Math.floor(this.population);
        },
        applyRecession: function (percentage) {
            percentage = percentage / 100;
            this.treasury -= this.treasury * percentage;
            Math.floor(this.treasury);
        },
    };

    return town;
}

const city = cityTaxes('Tortuga', 7000, 15000);
console.log(city);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population); 