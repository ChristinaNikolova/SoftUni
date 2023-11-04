function solve(fruit, weightGram, pricePerKilo) {
    const weigthKilo = weightGram / 1000;
    const totalSum = pricePerKilo * weigthKilo;

    console.log(`I need $${totalSum.toFixed(2)} to buy ${weigthKilo.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);