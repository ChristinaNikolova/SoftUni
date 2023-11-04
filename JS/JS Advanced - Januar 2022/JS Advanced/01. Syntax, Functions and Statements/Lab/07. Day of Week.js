function solve(weekDayName) {
    const weekDays = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    const indexOfDay = weekDays.indexOf(weekDayName) + 1;

    if (indexOfDay === 0) {
        console.log('error');
        return;
    }

    console.log(indexOfDay);
}

solve('Monday');
solve('Friday');
solve('Invalid');