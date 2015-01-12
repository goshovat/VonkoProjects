function Solve(args) {
    // var args = [
    //    '6 7 3',
    //    '0 0',
    //    '2 2',
    //    '-2 2',
    //    '3 -1',
    // ]

    var firstLine = args[0].split(' ');
    var height = parseInt(firstLine[0]);
    var width = parseInt(firstLine[1]);

    var secondLine = args[1].split(' ');
    var startRow = parseInt(secondLine[0]);
    var startCol = parseInt(secondLine[1]);

    var jumpsArray = [];

    for (var i = 2; i < args.length; i++) {
        var currentLine = args[i].split(' ');
        jumpsArray.push(currentLine);
    }


    //now we fill the matrix

    k = 1;
    var matrix = [];

    for (var row = 0;  row < height;  row++) {

        matrix[row] = [];
        for (var col = 0; col < width; col++) {
            matrix[row][col] = k;
            k++;
        }
    }

    var currentRow = startRow;
    var currentCol = startCol;
    var score = parseInt(matrix[currentRow][currentCol]);
    var numberJumps = 1;
    matrix[currentRow][currentCol] = 'v';
    var k = -1;

    while (true) {
        k = (k + 1) % jumpsArray.length;
        currentRow += parseInt(jumpsArray[k][0]);
        currentCol += parseInt(jumpsArray[k][1]);
        numberJumps++;

        if (currentRow < 0 || currentRow >= height || currentCol < 0 || currentCol >= width) {
            return ('escaped ' + score);
        }

        if (matrix[currentRow][currentCol] == 'v') {
            return ('caught ' + numberJumps);
        }
       
        score += parseInt(matrix[currentRow][currentCol]);
        matrix[currentRow][currentCol] = 'v';
    }
   
   // console.log(2);
}
//document.getelementbyid('execute').onclick = solve;
//document.getelementbyid('output').innerhtml = solve();