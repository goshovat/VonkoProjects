function Solve(args) {

    // var args = '40';

    var wCars = 4;
    var wTrucks = 10;
    var wTrikes = 3;

    var totalWheels = parseInt(args);

    var maxCars = parseInt(totalWheels / wCars);
    var maxTrucks = 0;
    var maxTrikes = 0;
    var remainder1 = 0;
    var remainder2 = 0;
    var remainder3 = 0;
    var possibleCombinations = 0;

    for (var i = 0; i <= maxCars; i++) {
        remainder1 = totalWheels - i * wCars;

        maxTrucks = parseInt(remainder1 / wTrucks);

        for (var j = 0; j <= maxTrucks; j++) {
            remainder2 = remainder1 - j * wTrucks;
            remainder3 = remainder2 % wTrikes;

            if (remainder3 == 0) {
                possibleCombinations++;
            }
        };
    };

    return possibleCombinations;
    // document.getElementById('output').innerHTML = maxPossibleSum;


    // document.getElementById('execute').onclick = Solve;
}

console.log(Solve());