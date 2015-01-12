function Solve(params) {

    //var params = [1, 6, -9, 4, 4, -2, 10, -1];
    var N = parseInt(params[0]);

    var currentSum = parseInt(params[1]);
    var maxSum = parseInt(params[1]);
    var tempStartIndex = 0;
    var startIndex = 0;
    var endIndex = 0;

    for (var i = 2; i < params.length; i++) {
        if (currentSum < 0) {
            currentSum = parseInt(params[i]);
            tempStartIndex = i;
        }
        else {
            currentSum += parseInt(params[i]);
        }

        if (currentSum > maxSum) {
            maxSum = currentSum;
            startIndex = tempStartIndex;
            endIndex = i;
        }
    }


    return (maxSum);
}