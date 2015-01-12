function execute() {

    var input0 = document.getElementById('input0').value;
    var input1 = document.getElementById('input1').value;
    var input2 = document.getElementById('input2').value;

    if (input0 && input1) {
        var output = ' ';

        if (!isNaN(input0)) {
            output = 'Please enter a valid string!';
        } else {
            var wordArray = [];
            var textArray = '';

            var countOccurences = function countOccurences() {

                if (input2 == 'no') {
                    input0 = input0.toUpperCase();
                    input1 = input1.toUpperCase();
                } else if (input2 == 'yes') {
                    input0;
                    input1;
                } else {
                    return ('Enter a valid option!');
                }

                textArray = ' ' + input1 + ' ';

                var i, j;
                var temporaryCount = 0;
                var finalCount = 0;
                input0 = ' ' + input0 + ' ';

                for (i = 0; i < input0.length; i++) {
                    wordArray[i] = input0[i];
                }

                for (i = 0; i < input1.length; i++) {

                    if (textArray[i] == wordArray[0]) {

                        for (j = 0; j < wordArray.length; j++) {
                            if (textArray[i + j] == wordArray[j]) {
                                temporaryCount++;
                            }

                            if (temporaryCount == wordArray.length) {
                                finalCount++;
                                temporaryCount = 0;
                            }
                        }


                    }
                }

                return finalCount;
            }

            output = countOccurences();

        }

        document.getElementById('output').innerHTML = output;
    }

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;