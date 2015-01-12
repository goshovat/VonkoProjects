function execute() {
    var text = document.getElementById('text').innerHTML;
    var output = '';
    var i;

    function extractEmails(argText) {
        var emails = argText.trim().match(/(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))/g);
        var emailsArr = emails.join(' | ');
        return (emailsArr);
    }

    output = extractEmails(text);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;