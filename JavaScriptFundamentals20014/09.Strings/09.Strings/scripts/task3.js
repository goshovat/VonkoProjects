function execute() {
    var input0 = document.getElementById('input0').value.toLocaleLowerCase();
    var text = document.getElementById('text').innerHTML.trim().toLocaleLowerCase();

    function howManyTimes(argString) {
        var rgxp = new RegExp(argString, 'g');
        var count = text.match(rgxp).length;

        return count;
    }

    output = howManyTimes(input0);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;