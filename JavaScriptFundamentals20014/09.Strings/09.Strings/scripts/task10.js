function execute() {
    var text = document.getElementById('input0').value;
    var output = '';
    var i;

    function extractPalindromes(argText) {
        var words = argText.replace("[^a-zA-Z ]", "").split(" ");
        var palindromes = [];

        for (i in words) {
            var currentWord = words[i];
            var wordInArr = currentWord.split('');
            var wordReversed = wordInArr.reverse().join('');
            wordReversed = wordReversed.toString();

            if (currentWord == wordReversed) {
                palindromes.push(currentWord);
            }
        }

        return (palindromes);
    }

    output = extractPalindromes(text);

    document.getElementById('output').innerHTML = output;

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;