function execute() {
    var input0 = document.getElementById('input0').value;
    var input1 = document.getElementById('input1').value;
    var input2 = document.getElementById('input2').value;
    var input3 = document.getElementById('input3').value;
    var input4 = document.getElementById('input4').value;
    var input5 = document.getElementById('input5').value;
    var input6 = document.getElementById('input6').value;
    var input7 = document.getElementById('input7').value;

    if (input0 !== '') {
        var output = ' ';

        if (isNaN(input0)) {
            output = 'Please enter a valid number!';
        }
        else {
            //Here starts the logic of the problem
            input0 = parseFloat(input0);
            input1 = parseFloat(input1);
            input2 = parseFloat(input2);
            input3 = parseFloat(input3);
            input4 = parseFloat(input4);
            input5 = parseFloat(input5);
            input6 = parseFloat(input6);
            input7 = parseFloat(input7);

            var arr = [input0, input1, input2, input3, input4, input5, input6, input7];
            var maxNumber = -Number.MAX_VALUE;
            var minNumber = Number.MAX_VALUE;

            for (var i = 0; i < arr.length; i++) {
                if (arr[i] > maxNumber) {
                    maxNumber = arr[i];
                }
                if (arr[i] < minNumber) {
                    minNumber = arr[i];
                }
            }

            output = 'Biggest Number: ' + maxNumber + '\n'
                + 'Smallest Number: ' + minNumber;
        }
        document.getElementById('output').innerHTML = output;
    }
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;