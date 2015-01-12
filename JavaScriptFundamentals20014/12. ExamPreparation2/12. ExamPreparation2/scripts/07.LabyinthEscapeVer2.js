function Solve(args) {

    // test = [
    //     "3 4",
    //     "1 3",
    //     "lrrd",
    //     "dlll",
    //     "rddd"
    // ]

    // test2 = [
    //     "5 8",
    //     "0 0",
    //     "rrrrrrrd",
    //     "rludulrd",
    //     "durlddud",
    //     "urrrldud",
    //     "ulllllll"
    // ]

    // args = [
    //     "5 8",
    //     "0 0",
    //     "rrrrrrrd",
    //     "rludulrd",
    //     "lurlddud",
    //     "urrrldud",
    //     "ulllllll"
    // ]

    var firstLLine = args[0].split(' ');
    var height = parseInt(firstLLine[0]);
    var width = parseInt(firstLLine[1]);
    var secondLine = args[1].split(' ');
    var startRow = parseInt(secondLine[0]);
    var startCol = parseInt(secondLine[1]);

    var field = [];

    for (var i = 2; i < args.length; i++) {
        field.push(args[i].split(''));
    };

    // console.log(field);

    //now we start walking

    var currentRow = startRow;
    var currentCol = startCol;
    var numberOfSteps = 0;
    var points = 0;
    var moving = true;
    var direction;

    while (true) {
        if (currentRow < 0 || currentRow > height - 1 ||
            currentCol < 0 || currentCol > width - 1) {
            return ('out ' + points);
        }
        if (field[currentRow][currentCol] == 'v') {
            return ('lost ' + numberOfSteps);
        }

        points += currentCol + 1 + currentRow * width;
        direction = field[currentRow][currentCol];
        field[currentRow][currentCol] = 'v';
        numberOfSteps++;;

        switch (direction) {
            case 'l':
                currentCol--;
                break;
            case 'r':
                currentCol++;
                break;
            case 'u':
                currentRow--;
                break;
            case 'd':
                currentRow++;
                break;
        }
    }

    //     document.getElementById('output').innerHTML = output;
}

// document.getElementById('execute').onclick = Solve;


// console.log(Solve());