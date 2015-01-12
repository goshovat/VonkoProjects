function execute() {
    var string = document.getElementById('input0').value;
    var i;

    function validateBrackets(argString) {
        var count = 0;

        for (i = 0; i < string.length; i++) {
            if (string[i] == '(') {
                count++;
            }
            else if (string[i] == ')' && count == 0) {
                return('No!')
            }
            else if (string[i] == ')' && count > 0) {
                count--;
            }
        }

        if (count == 0 && string != '') {
            return ("Yes!");
        }
        else {
            return ("No!");
        }    
    }

    output = validateBrackets(string);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;