function solve(input) {
    input.shift();

    const towns = input.reduce((acc, curr) => {
        let [, town, latitude, longitude] = curr.split('|').map((x) => x.trim());
        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);

        const current = {
            Town: town,
            Latitude: Number(latitude),
            Longitude: Number(longitude),
        };

        acc.push(current);

        return acc;
    }, []);

    return JSON.stringify(towns);
}

console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']));

console.log(solve(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']));