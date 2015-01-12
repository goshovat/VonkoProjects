function execute() {
    var output = ' ';
    var i, j;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    for (i = 0; i < n; i++) {
        array[i] = prompt("Enter element with index: " + i);
    }

    var currentSequenceLength = 1;
    var maxElement = array[0];
    var maxSequenceLength = 1;
    var tempStartIndex = 0;
    var startIndex = 0;
    var endIndex = 0;

    var arrayStartIndexes = new Array(0);

    for (var i = 1; i < array.length; i++) {

        if (array[i] <= array[i - 1]) {
            currentSequenceLength = 1;
            tempStartIndex = i;
        } else if (array[i] > array[i - 1]) {
            currentSequenceLength++;
        }

        if (currentSequenceLength > maxSequenceLength) {
            maxSequenceLength = currentSequenceLength;
            startIndex = tempStartIndex;
            arrayStartIndexes = [];
            arrayStartIndexes.push(startIndex);
            endIndex = i;
        }
        if (currentSequenceLength == maxSequenceLength && tempStartIndex != startIndex) {
            arrayStartIndexes.push(tempStartIndex);
        }
    }

    var hasIncreasing = false;

    for (var i = 0; i < array.length - 1; i++) {
        if (array[i] < array[i + 1]) {
            hasIncreasing = true;
        }
    };


    if (hasIncreasing) {
        for (i = 0; i < arrayStartIndexes.length; i++) {

            for (j = arrayStartIndexes[i]; j < maxSequenceLength + arrayStartIndexes[i]; j++) {
                output += array[j] + ' ';
            }

            output += '<br/>';
        }
    } else {
        output = 'No increasing sequences';
    }


    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;