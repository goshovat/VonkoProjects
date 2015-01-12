function execute() {
    //Here starts the logic of the problem
    var output = '';
    var orderDocument = new Array();
    var orderWindow = new Array();
    var orderNavigator = new Array();
    var prop;

    //Document
    for (prop in document) {
        orderDocument.push(prop);
    }

    orderDocument.sort();

    output += 'Document: <br/> The Biggest: ' + orderDocument[0] + '; ' + 
        'The Smallest: ' + orderDocument[orderDocument.length - 1] + '<br/>' + '<br/>';

    //Window
    for (prop in window) {
        orderWindow.push(prop);
    }

    orderWindow.sort();

    output += 'Window: <br/> The Biggest: ' + orderWindow[0] + '; ' +
        'The Smallest: ' + orderWindow[orderWindow.length - 1] + '<br/>' + '<br/>';

    //Navigator
    for (prop in navigator) {
        orderNavigator.push(prop);
    }

    orderNavigator.sort();

    output += 'Navigator: <br/> The Biggest: ' + orderNavigator[0] + '; ' +
        'The Smallest: ' + orderNavigator[orderNavigator.length - 1] + '<br/>' + '<br/>';

    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;