function Solve(params) {

    //var firstTeam = [240, 0, 240, 0, 96, 0, 0, 0];
    //var secondTeam = [0, 0, 0, 6, 0, 15, 0, 15];

    var field = [];

    //First we setup the players

    for (var row = 0; row < 8; row++) {
        field[row] = new Array;

        for (var col = 0; col < 8; col++) {
            bit = (parseInt(params[row]) >> 7 - col) & 1;

            if (bit === 1) {
                field[row][col] = 'T';
            }
            else {
                field[row][col] = 0;
            }

        }

    }

    for (var row = 0; row < 8; row++) {

        for (var col = 0; col < 8; col++) {
            bit = (parseInt(params[row + 8]) >> 7 - col) & 1;

            if (bit === 1 && field[row][col] === 'T') {
                field[row][col] = 0;
            }
            else if (bit === 1 && field[row][col] === 0) {
                field[row][col] = 'B';
            }

            //process.stdout.write(field[row][col] + ' ');
        }
        //console.log();
    }

    //Now we play the game

    var firstTeamScore = 0;
    var secondTeamScore = 0;

    for (var row = 0; row < 8; row++) {

        for (var col = 0; col < 8; col++) {

            if (field[row][col] == 'T') {

                for (i = row; i <= 7; i++) {

                    if (i < 7) {

                        if (field[i + 1][col] == 'B') {
                            break;
                        }
                        else if (field[i + 1][col] == 'T') {
                            break;
                        }
                    }
                    if (i == 7) {
                        firstTeamScore++;
                        //console.log('row: ' + i + 'col: ' + col);
                        break;
                    }
                }
            }

            else if (field[row][col] == 'B') {

                for (var i = row; i >= 0; i--) {

                    if (i > 0) {

                        if (field[i - 1][col] == 'T') {
                            break;
                        }
                        else if (field[i - 1][col] == 'B') {
                            break;
                        }
                    }
                    if (i == 0) {
                        secondTeamScore++;
                        //console.log('row: ' + i + 'col: ' + col);
                        break;
                    }
                }
            }
        }
    }

    //console.log(firstTeamScore);
    //console.log(secondTeamScore);

    return (firstTeamScore + ':' + secondTeamScore);
}