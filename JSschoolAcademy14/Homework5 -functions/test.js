document.getElementById("execute").onclick = function Find(isSensitive) {
    var text = "123ivan";
    var wordToSearch = "123";
    var isCaseSensitive = false;

    CountOccurenceWord(text, wordToSearch);
    CountOccurenceWord(text, wordToSearch, true);

    function CountOccurenceWord(text, wordToSearch, isCaseSensitive) {
        isCaseSensitive = isCaseSensitive || false;
        var countSearchedWord = 0;

        if (isCaseSensitive === false) {
            var strArr = text.split(wordToSearch); //split is case-insensitive

            for (var str in strArr) {
                countSearchedWord++;
            }
            jsConsole.writeLine("The count of word '" + wordToSearch + "' (case-insensitive search) is: " + countSearchedWord)
        }
        else {
            var index = text.indexOf(wordToSearch);//indexOf is case-sensitive

            while (index >= 0) {
                countSearchedWord++;
                index = text.indexOf(wordToSearch, index + 1);
            }
            jsConsole.writeLine("The count of word '" + wordToSearch + "' (case-sensitive search) is: " + countSearchedWord)
        }
    }
}