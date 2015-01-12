function Solve(params) {

    //var params = [9,1,8,8,7,6,5,7,7,6];
    var N = parseInt(params[0]);

    var currentMaxElement = parseInt(params[1]);
    var subsequences = 1;
    var currentEndIndex = 1;
    
    for (var i = 2; i < params.length; i++) {
        if (params[i] < currentMaxElement) {
            subsequences++;
            currentMaxElement = parseInt(params[i]);
            currentEndIndex = i;
        }
        else {
            if (params[i] > currentMaxElement) {
                currentMaxElement = parseInt(params[i]);
            }
        }
        
    }

    //console.log(maxSubsequences);
    return (subsequences);
}