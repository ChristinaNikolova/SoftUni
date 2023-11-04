function solve(flavors, startFlavor, endFlavor) {
    const startIndex = flavors.indexOf(startFlavor);
    const endIndex = flavors.indexOf(endFlavor) + 1;

    const result = flavors
        .slice(startIndex, endIndex);

    return result;
}

console.log(solve(
    ['Pumpkin Pie', 'Key Lime Pie', 'Cherry Pie', 'Lemon Meringue Pie', 'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'));

console.log(solve(
    ['Apple Crisp', 'Mississippi Mud Pie', 'Pot Pie', 'Steak and Cheese Pie', 'Butter Chicken Pie', 'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'));