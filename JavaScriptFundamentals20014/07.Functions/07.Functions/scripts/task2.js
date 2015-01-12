function execute() {

    var input0 = document.getElementById('input0').value;

    if (input0 !== '') {
        var output = ' ';

        if (isNaN(input0)) {
            output = 'Please enter a valid number!';
        }
        else {

            var reverseDigits = function reverseDigits() {
                var number = parseInt(input0);
                var array = (number + '').split('');

                array = array.reverse();
                array = array.join(' ');

               return array;
            }

            output = reverseDigits();

        }

        document.getElementById('output').innerHTML = output;
    }

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;