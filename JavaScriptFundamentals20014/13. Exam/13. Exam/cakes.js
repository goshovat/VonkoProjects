function Solve(args) {
    // var args = [110, 19, 29, 39];

    var totalSum = args[0];

    var cake1 = parseInt(args[1]);
    var cake2 = parseInt(args[2]);
    var cake3 = parseInt(args[3]);

    var cakesArr = [cake1, cake2, cake3];

    var c1Max = parseInt(totalSum / cake1);
    var remainder1 = 0;
    var remainder2 = 0;
    var minRemainder = Number.MAX_VALUE;
    var maxPossibleSum = 0;

    for (var i = 0; i <= c1Max; i++) {
        remainder1 = totalSum - i * cake1;

        var c2Max = parseInt(remainder1 / cake2);

        for (var j = 0; j <= c2Max; j++) {
            remainder2 = remainder1 - j * cake2;

            minRemainder = Math.min((remainder2 % cake3), minRemainder);
        };
    };

    maxPossibleSum = totalSum - minRemainder;
    return maxPossibleSum;

    // document.getElementById('output').innerHTML = maxPossibleSum;
}

// document.getElementById('execute').onclick = Solve;

console.log(Solve());