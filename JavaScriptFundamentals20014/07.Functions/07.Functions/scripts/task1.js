function execute() {
    var input0 = document.getElementById('input0').value;

    if (input0 !== '') {
        var output =' ';

        if (isNaN(input0)) {
            return'Please enter a valid number!';
        }
        else {

            var lastDigit = function returnLastDigit() {
                input0 = parseInt(input0);

                var lastDigit = input0 % 10;

                switch (lastDigit) {
                    case 0: return'Zero'; break;
                    case 1: return'One'; break;
                    case 2: return'Two'; break;
                    case 3: return'Three'; break;
                    case 4: return'Four'; break;
                    case 5: return'Five'; break;
                    case 6: return'Six'; break;
                    case 7: return'Seven'; break;
                    case 8: return'Eight'; break;
                    case 9: return'Nine'; break;
                }
            }

            output = lastDigit()

        }
        
        document.getElementById('output').innerHTML = output;
    }
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;