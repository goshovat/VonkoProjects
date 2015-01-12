function Solve(args) {

    //var args = [
    //'1, 3, -6, 7, 4, 1, 12',
    //'3',
    //'1, 2, -3',
    //'1, 3, -2',
    //'1, -1'
    //]


    var valley = args[0];
    valley = valley.toString().split(',');
    var copyValley = valley.slice();

    //console.log(valley);

    var numberPatterns = parseInt(args[1]);

    var patterns = [];
    for (var i = 2; i < args.length; i++) {
        patterns.push(args[i]);
    }

    var maxPoints = -999999;

    for (var i = 0; i < patterns.length; i++) {
        var currentPattern = patterns[i].split(',');
        var currentPos = 0;
        var currentPoints = parseInt(valley[currentPos]);
        valley[currentPos] = 'v';
        var moving = true;

        while (moving) {
            for (var j = 0; j < currentPattern.length; j++) {
                currentPos += parseInt(currentPattern[j]);

                if (currentPos < 0 || currentPos >= valley.length) {
                    moving = false;
                    break;
                }

                if (valley[currentPos] == 'v') {
                    moving = false;
                    break;
                }

                currentPoints += parseInt(valley[currentPos]);
                valley[currentPos] = 'v';


                if (moving == false) {
                    break;
                }
            }
        }

        if (currentPoints > maxPoints) {
            maxPoints = currentPoints;
        }

        valley = copyValley.slice();
    }

    return (maxPoints);
    //document.getElementById('output').innerHTML = output;
}

//document.getElementById('execute').onclick = Solve;