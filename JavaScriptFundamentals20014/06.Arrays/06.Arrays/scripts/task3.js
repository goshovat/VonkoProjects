function execute() {
    var output = ' ';
    var i;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    for (i = 0; i < n; i++) {
        array[i] = prompt("Enter element with index: " + i);
    }
    var currentElement = array[0];
    var currentSequenceLength = 1;
    var maxElement = array[0];
    var maxSequenceLength = 1;
    var tempStartIndex = 0;
    var startIndex = 0;
    var endIndex = 0;

    var equalsArray = new Array;

    for (var i = 1; i < array.length; i++) {

        if (array[i] != currentElement) {
            currentElement = array[i];
            currentSequenceLength = 1;
            tempStartIndex = i;
        } else if (array[i] == currentElement) {
            currentSequenceLength++;
        }

        if (currentSequenceLength > maxSequenceLength) {
            maxElement = currentElement;
            equalsArray = [];
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

    var hasEqualElements = false;

    for (var i = 0; i < array.length; i++) {
        for (var j = i + 1; j < array.length; j++) {
            if (array[i] == array[j]) {
                hasEqualElements = true;
            }
        };
    };

    for (i = 0; i < equalsArray.length; i++) {

        for (j = 0; j < maxSequenceLength; j++) {
            output += equalsArray[i] + ' ';
        }

        output += '<br/>'
    }

    if (hasEqualElements == true) {
        document.getElementById('output').innerHTML = output;
    } else {
        document.getElementById('output').innerHTML = 'No equal elements in the array';
    }
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;