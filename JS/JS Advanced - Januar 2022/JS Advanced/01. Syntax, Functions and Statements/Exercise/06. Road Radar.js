function solve(speed, area) {
    const limitSpeeds = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20,
    };

    const currentLimit = limitSpeeds[area];

    let messageToPrint = getMessageToPrint(currentLimit, speed);
    console.log(messageToPrint);

    function getStatus(speedDiff) {
        let message = '';

        if (speedDiff <= 20) {
            message = 'speeding';
        } else if (speedDiff <= 40) {
            message = 'excessive speeding';
        } else {
            message = 'reckless driving';
        }

        return message;
    }

    function getMessageToPrint(currentLimit, speed) {
        let messageToPrint = '';

        if (currentLimit >= speed) {
            messageToPrint = `Driving ${speed} km/h in a ${currentLimit} zone`;
        } else {
            const speedDiff = speed - currentLimit;
            const status = getStatus(speedDiff);

            messageToPrint = `The speed is ${speedDiff} km/h faster than the allowed speed of ${currentLimit} - ${status}`;
        }

        return messageToPrint;
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');