function execute() {
    var url = document.getElementById('text').innerHTML.trim();
    var output = '';
    var i;
    var obj = {};
    
    function groupInObject(argUrl) {
        var firstArray = url.split('//');
        obj['protocol'] = firstArray[0];
        var middleString = firstArray[1].toString();
        var index = middleString.indexOf('/');
        obj['server'] = middleString.substring(0, index);
        obj['resource'] = middleString.substring(index + 1, middleString.length);
        return ('Protocol: ' + obj.protocol + '<br/>' + 'Server: ' + obj.server + '<br/>' +
                'Resource: ' + obj.resource);
    }

    output = groupInObject(url);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;