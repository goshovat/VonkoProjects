function execute() {
    var input = document.getElementById("input0").value;

    if (input !== "") {
        var output = 0;

        if (isNaN(input) || parseInt(input) < 0 || parseInt(input) > 999) {
            output = "Please enter a valid number!"
        }
        else {
            input = parseInt(input);
            input = String(input);
            var n2 = parseInt(input % 100) % 10;
            var n1 = parseInt(input / 10) % 10;
            var n0 = parseInt(input / 100) % 10;

            var ones = ['', 'One', 'Two', 'Three', 'Four', 'Five', 'Six',
                        'Seven', 'Eight', 'Nine'];
            var tens = ['', '', 'Twenty', 'Thirty', 'Fourty', 'Fifty',
                        'Sixty', 'Seventy', 'Eighty', 'Ninety'];
            var specialNumbers = ['Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen',
                                 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'];

            var length = input.length;

            if (length === 1) {
                if (n2 === 0) {
                    output = 'Zero';
                }
                else {
                    output = ones[n2];
                }
            }

            else if (length === 2) {
                if (n1 === 1) {
                    output = specialNumbers[n2];
                }
                if (n1 !== 1) {

                    output = tens[n1] + ' ' + ones[n2];
                }               
            }

            else if (length == 3) {
                if (n1 === 1) {
                    output = ones[n0] + ' Hundred and ' + specialNumbers[n2];
                }
                else {
                    if (n1 !== 0 || n2 !== 0) {
                        output = ones[n0] + ' Hundred and ' + tens[n1] + ' ' + ones[n2];
                    }
                    else {
                        output = ones[n0] + ' Hundred';
                    }
                }
            }
        }

        document.getElementById("output").innerHTML = output;
    }
}


function reset() {
    location.reload();
}

document.getElementById("execute").onclick = execute;
document.getElementById("reset").onclick = reset;