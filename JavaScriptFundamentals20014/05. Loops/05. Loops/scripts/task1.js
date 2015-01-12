function execute() {
    var input0 = document.getElementById('input0').value;

    if (input0 !== '') {
        var output = ' ';

        if (isNaN(input0)) {
            output = 'Please enter a valid number!';
        }
        else {
            //Here starts the logic of the problem
            input0 = parseInt(input0);

            for (var i = 1; i < input0; i++) {
                
                output += i + ', ';
            }

            //One more check so we print nothing if the input is 0
            if (input0 > 0) {
                output += input0;
            }

        }
        document.getElementById('output').innerHTML = output;
    }
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;