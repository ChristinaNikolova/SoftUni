function solve(numAsString, ...commands) {
    const chop = (x) => x / 2;
    const dice = (x) => Math.sqrt(x);
    const spice = (x) => x + 1;
    const bake = (x) => x * 3;
    const fillet = (x) => x * 0.80;

    let num = Number(numAsString);

    commands.forEach((command) => {
        switch (command) {
            case 'chop':
                num = chop(num);
                break;
            case 'dice':
                num = dice(num);
                break;
            case 'spice':
                num = spice(num);
                break;
            case 'bake':
                num = bake(num);
                break;
            case 'fillet':
                num = fillet(num);
                break;
        }

        console.log(num);
    });
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');