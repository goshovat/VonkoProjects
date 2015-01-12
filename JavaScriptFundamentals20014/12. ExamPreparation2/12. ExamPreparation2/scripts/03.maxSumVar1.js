function Solve(params) {

    //var arr = [-9, -8, -8, -7, -6, - 5, -1, -7, -6];
    var N = parseInt(params[0]);

    var currentSum = 0;
    var maxSum = -Number.MAX_VALUE;

    for (var i = 1; i <= params.length; i++) {
        currentSum = 0;

        for (var j = i; j <= params.length; j++) {
            currentSum += parseInt(params[j]);

            if (currentSum >= maxSum) {
                maxSum = currentSum;
            }

        }
    }

    return (maxSum);
    //console.log(maxSum);
}