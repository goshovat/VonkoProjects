function execute() {
    var output = ' ';
    var i;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    for (i = 0; i < n; i++) {
        array[i] = prompt("Enter element with index: " + i);
    }

    array.sort();

    var currentElement = array[0];
    var currentSequenceLength = 1;
    var maxElement = array[0];
    var maxSequenceLength = 1;
    var tempStartIndex = 0;
    var startIndex = 0;
    var endIndex = 0;

    var equalsArray = [];

    for (var i = 1; i < array.length; i++) {

        if (array[i] != currentElement) {
            currentElement = array[i];
            currentSequenceLength = 1;
            tempStartIndex = i;
        }
        else if (array[i] == currentElement) {
            currentSequenceLength++;
        }

        if (currentSequenceLength > maxSequenceLength) {
            maxElement = currentElement;
            equalsArray.pop();
            equalsArray.pop();
            equalsArray.push(maxElement);
            maxSequenceLength = currentSequenceLength;
            startIndex = tempStartIndex;
            endIndex = i;
        }
        if (currentSequenceLength == maxSequenceLength &&
            currentElement != maxElement) {
            equalsArray.push(currentElement);
        }
    }

    if (n > 1) {
        output = "Elements: " + equalsArray + " " + "Occurences: " + maxSequenceLength;

    }
    else if (n == 1){
        output = "Elements: " + array + " " + "Occurences: " + maxSequenceLength;
    }
    else {
        output = '';
    }

    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;