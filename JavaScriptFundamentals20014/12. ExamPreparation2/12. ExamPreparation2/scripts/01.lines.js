function Solve(params){
    var input = params[i];
    var matrix = [];

    for (var i = 0; i < 8; i++) {
        var input = 2;
        matrix[i] = new Array;

        for (var j = 7; j >= 0; j--) {

            var bit = (input >> j) & 1;
            matrix[i][7 - j] = bit;
        }
    }

    var counter = 0;
    var maxCounter = 0;
    var numberLongest = 0;

    //first we check horizontally

    for (var i = 0; i < 8; i++) {
        counter = 0;

        for (var j = 0; j < 8; j++) {

            if (matrix[i][j] == 1) {
                counter++;

                if (counter > maxCounter) {
                    maxCounter = counter;
                    numberLongest = 1;
                }
                else if (counter == maxCounter) {
                    numberLongest++;
                }
            }
            else if (matrix[i][j] == 0) {
                counter = 0;
            }
        }
    }

    counter = 0;

    //Now we check vertically
    for (var j = 0; j < 8; j++) {
        counter = 0;

        for (var i = 0; i < 8; i++) {

            if (matrix[i][j] == 1) {
                counter++;

                if (counter > maxCounter) {
                    maxCounter = counter;
                    numberLongest = 1;
                }
                else if (counter == maxCounter) {
                    numberLongest++;
                }
            }
            else if (matrix[i][j] == 0) {
                counter = 0;
            }
        }
    }

    if (maxCounter == 1) {
        numberLongest /= 2;
    }

    return (maxCounter + '\n' + numberLongest);
}



