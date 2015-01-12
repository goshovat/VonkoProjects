function execute() {
    var text = document.getElementById('text').innerHTML.trim();
    var output = '';
    var i;
    
    var wordsArr = [1, "Pesho", "Gosho", 'Ivan', 'Pencho'];
    var index = text.indexOf('{');
    var count = 0;
    var newText = text;

    function replace() {

        while (index > -1) {
            count = parseInt(text.substr(index + 1, 1));
            newText = newText.replace(text.substr(index, 3), wordsArr[count]);
            index = text.indexOf('{', index + 2);
        }

        return (newText);
    }

    output = replace();

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;