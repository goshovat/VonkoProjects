document.getElementById("execute").onclick = function Execute() {
    function countNum() {
        var textArr = document.getElementById("text").value;
        number = document.getElementById("input").value;
        count = 0;
        for (i = 0; i < textArr.length; i++) {
            if (textArr[i] == number) {
                count++;
            }
        }
    }

    if (typeof (countNum) == 'function') {
        countNum();
            if (isNaN(number)) {
                jsConsole.writeLine("Please enter a number!");
            }
            else if (number.length != 1) {
                jsConsole.writeLine("Please enter one digit number!");
            }
            else {
                jsConsole.writeLine("The number " + number + " is met " + count + " times in the array.");
            }
        }
        else {
            jsConsole.writeLine("An error has occured!");
        }
}



document.getElementById("reset").onclick = function Erase() {
    document.getElementById("js-console").innerHTML = "";
    document.location.reload();
}