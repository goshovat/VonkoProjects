function Solve(args) {
    var output = '';

   // args = [
   //' 0',
   // '4',
   // '20',
   // '1337',
   // '2147483648',
   // '4000000000'
   // ]

    var digitToCheck = args[0];
    var numberOfNumbers = args[1];
    var numbersArray = [];

    for (var i = 2; i < args.length; i++) {
        numbersArray.push(parseInt(args[i]));
    }

    var matrix = [];

    for (var rows = 0; rows < numbersArray.length; rows++) {
        matrix[rows] = [];

        for (var cols = 0; cols < 32 ; cols++) {

            var bit = (numbersArray[rows] >> (31 - cols)) & 1;
            matrix[rows][cols] = parseInt(bit);

            //process.stdout.write(matrix[rows][cols] + " ");
        }
        //console.log();
    }

    var countsArr = [];
    var currentCount = 0;
    
    for (var rows = 0; rows < matrix.length; rows++) {
        currentCount = 0;
        var canCount = false;

        for (var cols = 0; cols < matrix[rows].length; cols++) {

            if (matrix[rows][cols] == 1) {
                canCount = true;
            }

            if (matrix[rows][cols] == digitToCheck && canCount) {
                currentCount++;
            }
        }

        countsArr.push(currentCount);
    }
   
    for (var i = 0; i < countsArr.length; i++) {

        if (i < countsArr.length - 1) {
            output += countsArr[i] + '\r';
        }
        else {
            output += countsArr[i];
        }
    }
    

    console.log(output);
//    document.getElementById('output').innerHTML = output;
}

//document.getElementById('execute').onclick = Solve;