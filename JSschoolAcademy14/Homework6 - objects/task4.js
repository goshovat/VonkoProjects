document.getElementById("execute").onclick = function Execute() {
    var Vonko = {
        name: "Ivan Mihov",
        age: 25,
        sexualOrientation: "maniac"
    }

    for (i in Vonko) {
        if (Vonko.hasOwnProperty("sexualOrientation")) {
            result = "The property is there"
        }

        else {
            result = "The property is not there";
        }
    }

    jsConsole.writeLine(result);
}


document.getElementById("reset").onclick = function Erase() {
    document.getElementById("js-console").innerHTML = "";
    document.location.reload();
}