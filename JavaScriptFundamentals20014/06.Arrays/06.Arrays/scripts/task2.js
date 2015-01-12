function execute() {
    var output = ' ';
    var i;
    var n1 = prompt("Enter the length of the first array: ");
    var arr1 = new Array(n1);
    for (i = 0; i < n1; i++) {
        arr1[i] = prompt("Enter element with index: " + i);
    }

    var n2 = prompt("Enter the length of the second array: ");
    var arr2 = new Array(n2);
    for (i = 0; i < n2; i++) {
        arr2[i] = prompt("Enter element with index: " + i);
    }
    
    var length1 = arr1.length;
    var length2 = arr2.length;
    var equal = true;

    if (length1 === length2) {

        for (i = 0; i < length1; i++) {
            if (arr1[i] != arr2[i]) {
                equal = false;
            }
        }

        if (equal === true) {
            output = "The arrays are equal";
        }
        else {
            output = "The arrays are different";
        }
    }
    else {

        output = "The arrays have different length";
    }

    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;