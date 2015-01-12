	function Solve(args) {
	    // args = [
	    //     '3 5',
	    //     '54361',
	    //     '43326',
	    //     '52888',
	    // ];

	    var firstLine = args[0].split(' ');

	    var height = parseInt(firstLine[0]);
	    var width = parseInt(firstLine[1]);

	    var directionsField = [];

	    for (var i = 1; i < args.length; i++) {
	        directionsField.push(args[i].split(''));
	    };

	    var currentRow = height - 1;
	    var currentCol = width - 1;
	    var numberSteps = 0;
	    var currentSum = 0;

	    while (true) {
	        if (currentRow < 0 || currentRow >= height || currentCol < 0 || currentCol >= width) {
	            return ('Go go Horsy! Collected ' + currentSum + ' weeds');
	        }
	        if (directionsField[currentRow][currentCol] == 'v') {
	            return ('Sadly the horse is doomed in ' + numberSteps + ' jumps')
	        }

	        numberSteps += 1;
	        currentSum += Math.pow(2, currentRow) - currentCol;
	        var direction = directionsField[currentRow][currentCol];
	        directionsField[currentRow][currentCol] = 'v';

	        switch (direction) {
	            case '1':
	                currentRow -= 2;
	                currentCol += 1;
	                break;
	            case '2':
	                currentRow -= 1;
	                currentCol += 2;
	                break;
	            case '3':
	                currentRow += 1;
	                currentCol += 2;
	                break;
	            case '4':
	                currentRow += 2;
	                currentCol += 1;
	                break;
	            case '5':
	                currentRow += 2;
	                currentCol -= 1;
	                break;
	            case '6':
	                currentRow += 1;
	                currentCol -= 2;
	                break;
	            case '7':
	                currentRow -= 1;
	                currentCol -= 2;
	                break;
	            case '8':
	                currentRow -= 2;
	                currentCol -= 1;
	                break;
	        }
	    }

	    /*document.getElementById('output').innerHTML = currentSum;*/
	}

	/*document.getElementById('execute').onclick = Solve;*/

	 // console.log(Solve());