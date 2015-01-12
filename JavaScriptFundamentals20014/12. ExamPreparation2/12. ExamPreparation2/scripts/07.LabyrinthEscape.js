function Solve(args) {

 //   var args = [
 //"3 4",
 //"1 3",
 //"lrrd",
 //"dlll",
 //"rddd"]


    var sizes = args[0];
    var sizesArr = sizes.split(' ');
    var height = parseInt(sizesArr[0]);
    var width = parseInt(sizesArr[1]);

    var startPos = args[1];
    var startPosArr = startPos.split(' ');


    var startRow = parseInt(startPosArr[0]);
    var startCol = parseInt(startPosArr[1]);

    var matrix = [];
    var output = '';

    for (var i = 2; i < height + 2; i++) {
        var currentRow = args[i];
        var currentRowArr = currentRow.split('');
        var rowArray = [];

        for (var j = 0; j < width; j++) {
            var currentCell = currentRowArr[j];
            rowArray.push(currentCell);
        }

        matrix[i] = rowArray;
    }


    //now we start walking in the labirinth

    var row = startRow + 2;
    var col = startCol;
    var sum = 0;
    var numberCells = 0;
    var direction = matrix[row][col];
    var win = 'out';
    var moving = true;

    while (moving == true) {
        direction = matrix[row][col];

        switch (direction) {
            case 'l':
                if (col > 0) {
                    matrix[row][col] = 'v';
                    sum += parseInt(col+1 + width * (row-2));
                    numberCells++;
                    col--;

                    if (matrix[row][col] == 'r') {
                        numberCells++;
                        win = 'lost';
                        moving = false;
                    }
                }
                else if(col == 0) {
                    sum += parseInt(col + 1 + width * (row - 2));
                    win = 'out';
                    moving = false;
                }
                break;

            case 'r':
                if (col < width - 1) {
                    matrix[row][col] = 'v';
                    sum += parseInt(col + 1 + width * (row - 2));
                    numberCells++;
                    col++;

                    if (matrix[row][col] == 'l') {
                        numberCells++;
                        win = 'lost';
                        moving = false;
                    }
                }
                else if(col == width-1) {
                    sum += parseInt(col + 1 + width * (row - 2));
                    win = 'out';
                    moving = false;
                }
                break;

            case 'u':
                if (row > 0) {
                    matrix[row][col] = 'v';
                    sum += parseInt(col + 1 + width * (row - 2));
                    numberCells++;
                    row--;

                    if (matrix[row][col] == 'd') {
                        numberCells++;
                        win = 'lost';
                        moving = false;
                    }
                }
                else if(row == 0) {
                    sum += parseInt(col + 1 + width * (row - 2));
                    win = 'out';
                    moving = false;
                }
                break;

            case 'd':
                if (row < height + 2 - 1) {
                    matrix[row][col] = 'v';
                    sum += parseInt(col + 1 + width * (row - 2));
                    numberCells++;
                    row++;

                    if (matrix[row][col] == 'u') {
                        numberCells++;
                        win = 'lost';
                        moving = false;
                    }
                }
                else if(row == height+2-1) {
                    sum += parseInt(col + 1 + width * (row - 2));
                    win = 'out';
                    moving = false;
                }
                break;

            case 'v':
                win = 'lost';
                moving = false;
                break;
        }
    }

    if (win == 'out') {
       return(win + ' ' + sum);
    }
    else {
        return(win + ' ' + numberCells);
    }

    //document.getElementById('output').innerHTML = output;
}

//document.getElementById('execute').onclick = Solve;