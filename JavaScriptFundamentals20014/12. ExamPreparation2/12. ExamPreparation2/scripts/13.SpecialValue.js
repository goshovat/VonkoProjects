function Solve(args) {

//    args = [
//'2',
//'0, -3, 0, 3',
//    '0, 3, 0, 2, 0'


//    ];

    var numberRows = args[0];

    var rowsArr = [];
    for (var i = 1; i < args.length; i++) {
        var newArr = args[i].split(',');

        for (var j = 0; j < newArr.length; j++) {
            newArr[j] = parseInt(newArr[j]);
        }

        rowsArr.push(newArr);
    }

    var copyRowsArr = rowsArr.slice();

    var currentSpecialValue = 1;
    var maxSpecialValue = 0;
    var currentRow = 0;
    var currentIndex = 0;

    for (var i = 0; i < rowsArr[0].length; i++) {
        if (rowsArr[0][i] < 0) {
            currentSpecialValue += Math.abs(rowsArr[0][i]);
        }
        else {
            currentIndex = rowsArr[0][i];
            currentRow = 0;

            while (true) {               
                currentRow = (currentRow + 1) % rowsArr.length;
                currentSpecialValue++;

                if (rowsArr[currentRow][currentIndex] == 'v') {
                    currentSpecialValue = 0;
                    break;
                }
                if (rowsArr[currentRow][currentIndex] < 0) {
                    currentSpecialValue += Math.abs(rowsArr[currentRow][currentIndex]);
                    break;
                }

                currentIndex = rowsArr[currentRow][currentIndex];
                rowsArr[currentRow][currentIndex] = 'v';
            }          
        }

        if (currentSpecialValue > maxSpecialValue) {
            maxSpecialValue = currentSpecialValue;
        }

        currentSpecialValue = 1;
        rowsArr = copyRowsArr.slice();
    }

    return maxSpecialValue;

    //var output = maxSpecialValue;

    //document.getElementById('output').innerHTML = output;
}

//document.getElementById('execute').onclick = Solve;