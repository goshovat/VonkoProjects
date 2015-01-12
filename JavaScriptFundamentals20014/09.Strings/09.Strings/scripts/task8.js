function execute() {
    var markup = '&lt;p&gtPlease visit <a href="pesho">Gosho</a> to choose a training course. Also visit <a href="www.devbg.org>tour forum</a> to discuss the courses.&lt;/p&gt';
    var output = '';
    var i;

    function replaceAnchorTags(argMarkup) {
        var newMarkup = argMarkup.trim().replace(/<a href="/gi, '[URL=');
        newMarkup = newMarkup.replace(/">/gi, ']');
        newMarkup = newMarkup.replace(/<\/a>/gi, '[/URL]');
        return (newMarkup);
    }

    output = replaceAnchorTags(markup);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;