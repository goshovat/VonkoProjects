function execute() {

    var i;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    for (i = 0; i < n; i++) {
        array[i] = prompt("Enter element with index: " + i);
    }

    var number = prompt("Enter ONE OF THE NUMBERS IN THE ARRAY: ")
    var counts;

    function countOccurences(argumentArray, argumentNumber) {
        counts = 0;

        if (argumentNumber != 0) {
            for (i = 0; i < argumentArray.length; i++) {
                if (argumentNumber == argumentArray[i]) {
                    counts++;
                }
            }
            return (counts);
        }
    }

    function test() {

        var testArray = [1, 1, 1, 2, 3, 4];

        var testValue = countOccurences(testArray, 1);

        if (testValue == 3) {
            return ('Test succesful');
        }
        else {
            return ('Test failure');
        }
    }

    document.getElementById('output').innerHTML = countOccurences(array, number) + '<br/>'
                                                    + test();
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;