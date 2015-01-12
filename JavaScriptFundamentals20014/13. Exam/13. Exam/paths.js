function Solve(args) {

    // args = [
    //     '3 5',
    //     'dr dl dl ur ul',
    //     'dr dr ul ul ur',
    //     'dl dr ur dl ur'
    // ]


    var firstLine = args[0].split(' ');
    var height = parseInt(firstLine[0]);
    var width = parseInt(firstLine[1]);

    var field = [];

    for (var i = 1; i < args.length; i++) {
        field.push(args[i].split(' '));
    };

    var currentRow = 0;
    var currentCol = 0;

    var sum = 0;
    var steps = 0;

    while (true) {
        if (currentRow < 0 || currentRow > height - 1 ||
            currentCol < 0 || currentCol > width - 1) {
            return ('successed with ' + sum);
        }
        if (field[currentRow][currentCol] == 'v') {
            return ('failed at ' + '(' + currentRow + ', ' + currentCol + ')');
        }

        sum += Math.pow(2, currentRow) + currentCol;
        var direction = field[currentRow][currentCol];
        field[currentRow][currentCol] = 'v';

        switch (direction) {
            case 'dr':
                currentRow++;
                currentCol++;
                break;
            case 'ur':
                currentRow--;
                currentCol++;
                break;
            case 'ul':
                currentRow--;
                currentCol--;
                break;
            case 'dl':
                currentRow++;
                currentCol--;
                break;
        }


    }

    // document.getElementById('output').innerHTML = maxPossibleSum;

}

// document.getElementById('execute').onclick = Solve;

console.log(Solve());