document.getElementById("execute").onclick =function Find(isSensitive) {
    var text = document.getElementById("text").value;
    var word = document.getElementById("input").value;
    var isCaseSensitive = false;


    CountOccurenceWord(text, word, true);

    function CountOccurenceWord(text, word, isCaseSensitive) {
        isCaseSensitive = isCaseSensitive || false;
        var count = 0;
            var index = text.indexOf(word);//indexOf is case-sensitive

            while (index >= 0) {
                count++;
                index = text.indexOf(word, index + 1);
            }
            jsConsole.writeLine("The count of word '" + word + "' (case-sensitive search) is: " + count)
    }

}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}