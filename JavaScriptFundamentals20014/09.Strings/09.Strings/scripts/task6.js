function execute() {
    var markup = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
    var i;

    function removeTags(argString) {

        var regex = /(<([^>]+)>)/ig;
        var text = argString.replace(regex, '');
        return (text);
    }

    output = removeTags(markup);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;