function Solve(args) {
//    var args = [
//'5',
//'20',
//'We happy few        we band',
//'of brothers for he who sheds',
//'his blood',
//'with',
//'me shall be my brother'
//    ]

    var numberLines = args[0];
    var symbolsPerRow = args[1];
    var currentRow = [];
    var rowsArr = [];
    var finalResult = '';

    for (var i = 2; i < args.length; i++) {
       currentRow = args[i].split(' ');
       currentRow = currentRow.filter(function (element) {
           if (element != ' ') {
               return element;
           }
       })

       rowsArr.push(currentRow);
    }

    function allWordsToArray(argMatrix) {
        var arrayToReturn = [];
        
        for (var i = 0; i < argMatrix.length; i++) {
            
            for (var j = 0; j < argMatrix[i].length; j++) {
                arrayToReturn.push(argMatrix[i][j]);
            }
        }

        return arrayToReturn;
    }

    function justifyRow(row) {
        if (row.length == 1) {
            return row;
        }

        var rowWidth = 0;
        var word = "";
        var currentWord = 1;

        for (var i = 0; i < row.length - 1; i++) {
            rowWidth += row[i].length + 1;
        }
        rowWidth += row[row.length - 1].length;

        while (rowWidth < symbolsPerRow) {
            word = row[currentWord];

            row.splice(currentWord, 1, " " + word);

            currentWord++;
            if (currentWord == row.length) {
                currentWord = 1;
            }

            rowWidth++;
        }

        return row;
    }

    var allWords = allWordsToArray(rowsArr);
    var k = 0;
    var currentRowLen = 0;

    while (true) {
        if (k == allWords.length) {
            break;
        }

        currentRowLen = 0;
        currentRow = [];
        
        while (currentRowLen < symbolsPerRow) {
            currentRow.push(allWords[k]);
            currentRowLen += allWords[k].length + 1;
            k++;

            if (k == allWords.length) {
                break;
            }
        }

        if (currentRowLen > symbolsPerRow) {
            k--;
            currentRow.pop();
           
        }


        cureentRow = justifyRow(currentRow);

        currentRowToString = currentRow.join(" ") + "\r";
        finalResult += currentRowToString;

    }

    return finalResult;

//    document.getElementById('output').innerHTML = output;
}

//document.getElementById('execute').onclick = Solve;