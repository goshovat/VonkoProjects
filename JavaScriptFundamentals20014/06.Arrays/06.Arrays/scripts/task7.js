function execute() {
    var i, j, k;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    var output = '';
    var isNan = false;

    for (i = 0; i < n; i++) {
        array[i] = parseInt(prompt("Enter element with index: " + i));

        if (isNaN(array[i])) {
            isNan = true;
            break;
        }
    }

    function orderBy(a, b) {
        return ((a == b) ? 0 : (a > b) ? 1 : -1);
    }

    var element = parseInt(prompt("Write ONE OF THE ELEMENTS YOU ALREADY ENTERED:"));
    var currentIndex;
    var minIndex = 0;
    var maxIndex = array.length - 1;
    var arrayIndexes = '';

    array.sort(orderBy);

    if (!isNan) {
        while (minIndex <= maxIndex) {
            currentIndex = parseInt((minIndex + maxIndex) / 2);

            if (array[currentIndex] < element) {
                minIndex++;
            } else if (array[currentIndex] > element) {
                maxIndex--;
            } else if (array[currentIndex] == element) {
                arrayIndexes += currentIndex + " ";
                var increasingIndex = currentIndex;
                var decreasingIndex = currentIndex;

                if (array[increasingIndex + 1] == element) {
                    increasingIndex++;

                    while (array[increasingIndex] == element) {
                        arrayIndexes += increasingIndex + " ";
                        increasingIndex++;
                    }
                }
                if (array[currentIndex - 1] == element) {
                    decreasingIndex--;

                    while (array[decreasingIndex] == element) {
                        arrayIndexes += decreasingIndex + " ";
                        decreasingIndex--;
                    }
                }

                break;
            }

        }
    }

    arrayIndexes = arrayIndexes.split(' ');
    arrayIndexes.sort(orderBy);

    for (i = 0; i < arrayIndexes.length; i++) {
        output += arrayIndexes[i] + ' ';
    }

    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;