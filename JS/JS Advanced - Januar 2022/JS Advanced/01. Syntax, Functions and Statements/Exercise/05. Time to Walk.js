function solve(steps, footprintMeters, speedKmH) {
    const totalLengthMeters = steps * footprintMeters;
    const breaksCount = Math.floor(totalLengthMeters / 500);

    let totalTimeHours = totalLengthMeters / 1000 / speedKmH;
    totalTimeHours += breaksCount / 60;

    const totalSeconds = Math.ceil(totalTimeHours * 3600);

    const date = new Date(null, null, null, null, null, totalSeconds);
    const seconds = date.toTimeString().split(' ')[0];

    console.log(seconds);
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);