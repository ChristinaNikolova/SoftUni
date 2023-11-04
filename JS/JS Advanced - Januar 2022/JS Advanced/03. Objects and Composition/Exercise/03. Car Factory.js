function solve(order) {
    let engine = {};

    if (order.power <= 90) {
        engine.power = 90;
        engine.volume = 1800;
    } else if (order.power <= 120) {
        engine.power = 120;
        engine.volume = 2400;
    } else {
        engine.power = 200;
        engine.volume = 3500;
    }

    const carriage = {
        type: order.carriage,
        color: order.color,
    };

    const wheelsize = order.wheelsize % 2 === 1 ? order.wheelsize : order.wheelsize - 1;

    const car = {
        model: order.model,
        engine,
        carriage,
        wheels: [wheelsize, wheelsize, wheelsize, wheelsize],
    };

    return car;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));