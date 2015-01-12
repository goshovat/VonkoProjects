function execute() {
    var text = document.getElementById('text').innerHTML;
    var i;

    function replaceSpaces(argString) {

        var array = text.trim().split('');
        var newStr = '';

        for (i = 0; i < array.length; i++) {
            if (array[i] == ' ') {
                array[i] = '&nbsp';
            }

            newStr += '' + array[i];
        }

        return (newStr);
    }

    output = replaceSpaces(text);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;