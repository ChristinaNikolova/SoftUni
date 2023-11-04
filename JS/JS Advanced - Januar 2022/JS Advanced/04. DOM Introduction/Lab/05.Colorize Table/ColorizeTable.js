function colorize() {
    //let tdOddElements = document.querySelectorAll('tr:nth-child(2n) td');
    //
    // Array.from(tdOddElements).forEach((td) => {
    //     td.style.backgroundColor = 'teal';
    // });

    let trElements = document.getElementsByTagName('tr');

    Array.from(trElements).forEach((tr, i) => {
        if (i % 2 === 1) {
            tr.style.backgroundColor = 'teal';
        }
    });
}