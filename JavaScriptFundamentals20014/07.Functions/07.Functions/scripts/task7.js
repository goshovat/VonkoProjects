function execute() {

    var i;
    var n = prompt("Enter the length of the array: ");
    var array = new Array(n);
    for (i = 0; i < n; i++) {
        array[i] = prompt("Enter element with index: " + i);
    }


    function check() {

        for (index = 0; index < array.length; index++) {

            if (parseInt(array[index - 1]) && parseInt(array[index + 1]) &&
            parseInt(array[index]) > parseInt(array[index - 1]) &&
            parseInt(array[index]) > parseInt(array[index + 1])) {

                return (index);
            }
        }

        return (-1);
    }

    document.getElementById('output').innerHTML = check();
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;