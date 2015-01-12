function Solve(params) {
    var matrix = [];

    for (var rows = 0; rows < 8; rows++) {
        var input = parseInt(params[rows]);
        matrix[rows] = new Array;

        for (var cols = 7; cols >= 0; cols--) {
            var bit = (input >> cols) & 1;

            matrix[rows][7 - cols] = bit;
        }
    }

    ////printr the matrix
    //for (var i = 0; i < 8; i++)
    //{
    //    for (var j = 0; j < 8; j++)
    //    {
    //        Console.Write(matrix[i,j]);
    //    }
    //    Console.WriteLine();
    //}

    var suchPillarsExist = false;
    var counter1 = 0;
    var counter2 = 0;
    var rotation = 0;

    for (rotation = 0; rotation <= 7; rotation++) {
        counter1 = 0;
        counter2 = 0;

        for (var colLeft = 0; colLeft <= rotation - 1 ; colLeft++) {
            for (var row = 0; row <= 7; row++) {

                if (matrix[row][colLeft] == 1) {
                    counter1++;
                }
            }
        }

        for (var colRight = rotation + 1; colRight <= 7; colRight++) {
            for (var row = 0; row <= 7; row++) {
                if (matrix[row][colRight] == 1) {
                    counter2++;
                }
            }
        }

        if (counter1 == counter2) {
            suchPillarsExist = true;
            break;
        }
    }

    if (suchPillarsExist) {
        return(7 - rotation + '\n' + counter1);
    }
    else {
        return("No");
    }
}
