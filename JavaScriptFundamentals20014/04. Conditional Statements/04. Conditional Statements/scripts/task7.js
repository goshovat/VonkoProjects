function execute() {
    var input0 = document.getElementById('input0').value;
    var input1 = document.getElementById('input1').value;
    var input2 = document.getElementById('input2').value;
    var input3 = document.getElementById('input3').value;
    var input4 = document.getElementById('input4').value;

    if (input1 !== '' || input1 !== '' || input2 !== '' ||
        input3 !== '' || input4 !== '') {
        var output = 0;

        if (isNaN(input0) || isNaN(input1) || isNaN(input2)
            || isNaN(input3) || isNaN(input4)) {
            output = 'Please enter a valid number!';
        }
        else {
            //Here starts the logic of the problem
            input0 = parseFloat(input0);
            input1 = parseFloat(input1);
            input2 = parseFloat(input2);
            input3 = parseFloat(input3);
            input4 = parseFloat(input4);

            var array = [input0, input1, input2, input3, input4];

            var biggest = parseFloat(Number.MAX_VALUE * (-1));

            for (var i = 0; i < array.length; i++) {
                if (array[i] > biggest) {
                    biggest = array[i];
                }
            }

            output = biggest;
        }
        document.getElementById('output').innerHTML = output;
    }
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;