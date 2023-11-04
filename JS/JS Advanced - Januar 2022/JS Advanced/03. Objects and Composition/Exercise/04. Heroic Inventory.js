function solve(input) {
    const heroes = input.reduce((acc, curr) => {
        let [name, level, items] = curr.split('/').map((x) => x.trim());
        items = items ? items.split(',').map((x) => x.trim()) : [];
        level = Number(level);

        const hero = {
            name,
            level,
            items,
        };

        acc.push(hero);

        return acc;
    }, []);

    return JSON.stringify(heroes);
}

console.log(solve(['Isacc / 25 /Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']));

console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));