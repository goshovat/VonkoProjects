function execute() {
    var input0 = document.getElementById('input0').value;
    var input1 = document.getElementById('input1').value;
    var input2 = document.getElementById('input2').value;

    if (input1 !== '' || input1 !== '' || input2 !== '') {
        var output = 0;

        if (isNaN(input0) || isNaN(input1) || isNaN(input2)) {
            output = 'Please enter a valid number!'
        }
        else {
            //Here starts the logic of the problem

            input0 = parseFloat(input0);
            input1 = parseFloat(input1);
            input2 = parseFloat(input2);

            if (input0 >= input1 && input0 >= input2) {
                if (input0 === input1 && input0 === input2) {
                    output = 'The tree numbers are equal';
                }
                else {
                    if (input0 > input1 && input0 === input2) {
                        output = 'The numbers in descending order are ' + input0 +
                            ' , ' + input2 + ' , ' + input1;
                    }
                    else if (input0 > input2 && input0 === input1) {
                        output = 'The numbers in descending order are ' + input0 +
                            ' , ' + input1 + ' , ' + input2;
                    }
                    else if (input0 > input1 && input0 > input2) {
                        if (input1 === input2) {
                            output = 'The numbers in descending order are ' + input0 +
                                ' , ' + input1 + ' , ' + input2;
                        }
                        else if (input1 < input2) {
                            output = 'The numbers in descending order are ' + input0 +
                                ' , ' + input2 + ' , ' + input1;
                        }
                        else if (input1 > input2) {
                            output = 'The numbers in descending order are ' + input0 +
                              ' , ' + input1 + ' , ' + input2;
                        }
                    }
                }
            }
            else if (input0 >= input1 && input0 <= input2) {
                if (input0 >= input1 && input0 < input2) {
                    output = 'The numbers in descending order are ' + input2 +
                             ' , ' + input0 + ' , ' + input1;
                }
            }
            else if (input0 >= input2 && input0 <= input1) {
                if (input0 >= input2 && input0 < input1) {
                    output = 'The numbers in descending order are ' + input1 +
                             ' , ' + input0 + ' , ' + input2;
                }
            }
            else if (input0 <= input1 && input0 <= input2) {
                if (input0 < input1 && input0 < input2) {
                    if (input1 === input2) {
                        output = 'The numbers in descending order are ' + input2 +
                            ' , ' + input1 + ' , ' + input0;
                    }
                    else if (input1 > input2) {
                        output = 'The numbers in descending order are ' + input1 +
                            ' , ' + input2 + ' , ' + input0;
                    }
                    else if (input2 > input1) {
                        output = 'The numbers in descending order are ' + input2 +
                            ' , ' + input1 + ' , ' + input0;
                    }
                }
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