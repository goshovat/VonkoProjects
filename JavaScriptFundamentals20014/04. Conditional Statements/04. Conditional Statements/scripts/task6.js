function execute() {
    var input0 = document.getElementById('input0').value;
    var input1 = document.getElementById('input1').value;
    var input2 = document.getElementById('input2').value;

    if (input1 !== '' || input1 !== '' || input2 !== '') {
        var output = 0;

        if (isNaN(input0) || isNaN(input1) || isNaN(input2)) {
            output = 'Please enter a valid number!';
        }
        else {
            //Here starts the logic of the problem

            var a = parseFloat(input0);
            var b = parseFloat(input1);
            var c = parseFloat(input2);

            var descriminant = b * b - 4 * a * c;
            var x1 = 0;
            var x2 = 0;
            var x = 0;

            if (descriminant > 0) {
                x1 = (-b + Math.sqrt(descriminant)) / (2 * a);
                x2 = (-b - Math.sqrt(descriminant)) / (2 * a);
                output = "The two real root are: " + x1.toFixed(2) +
                         ' and ' + x2.toFixed(2);
            }
            else if (descriminant === 0) {
                x = -b / (2 * a);
                output = 'The only real root is ' + x.toFixed(2);
            }
            else if (descriminant < 0) {
                output = 'There are no real roots';
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