function execute() {

    var output = ' ';
    var i;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    for (i = 0; i < n; i++) {
        array[i] = prompt("Enter element with index: " + i);
    }

    var symbolToRemove = prompt('Enter ONE OF THE SYMBOLS YOU PUT IN THE ARRAY: ');
    var newArray = [];

    //This is the function
    Array.prototype.removeElement = function (argElement) {

        for (i = 0; i < this.length; i++) {

            if (this[i] !== argElement) {
                newArray.push(this[i]);
            }
        }
    }

    array.removeElement(symbolToRemove);

    output = newArray;

    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;