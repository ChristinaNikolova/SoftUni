function solve(input) {
    let result = [];

    const obj = {
        add: function (str) {
            result.push(str);
        },
        remove: function (str) {
            while (result.find((x) => x === str)) {
                const index = result.indexOf(str);
                result.splice(index, 1);
            }
        },
        print: function () {
            console.log(result.join(','));
        },
    };

    input.forEach((curr) => {
        const [command, str] = curr.split(' ').map((x) => x.trim());
        obj[command](str);
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);