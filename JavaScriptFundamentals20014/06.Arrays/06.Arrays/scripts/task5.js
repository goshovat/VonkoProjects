function execute() {
    var output = ' ';
    var i, j;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    for (i = 0; i < n; i++) {
        array[i] = prompt("Enter element with index: " + i);
    }

    var smallest;
    var temp;
    var smallestIndex;

    for (i = 0; i < array.length; i++) {

        smallest = array[i];

        for (j = i; j < array.length; j++) {

            if (parseInt(array[j]) < parseInt(smallest)) {
                smallest = array[j];
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }

    output = array;

    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;