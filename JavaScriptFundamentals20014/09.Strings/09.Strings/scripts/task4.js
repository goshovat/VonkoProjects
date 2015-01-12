function execute() {
    var text = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>dont</mixcase> have <lowcase>anything</lowcase> else. We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>dont</mixcase> have <lowcase>anything</lowcase> else';
    var i;

    function setUpper(match) {
        return (match.toUpperCase());
    }

    function setLower(match) {
        return (match.toLowerCase());
    }

    function setMixed(match) {
        var strMatch = match.toString();
        var mixed = '';

        for (var i = 0; i < strMatch.length; i++) {
            if (i % 2 == 0) {
                mixed += strMatch[i].toLowerCase();
            }
            else {
                mixed += strMatch[i].toUpperCase();
            }
        }

        return (mixed);
    }

    var result = text.replace(/<upcase>(.*?)<\/upcase>/g, setUpper);
    result = result.replace(/<lowcase>(.*?)<\/lowcase>/g, setLower);
    result = result.replace(/<mixcase>(.*?)<\/mixcase>/g, setMixed);

    document.getElementById('output').innerHTML = result;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;