document.getElementById("execute").onclick = function Execute() {
    var persons = [{ firstname: "Vonko", lastname: "Mihov", age: 24 },
    { firstname: "Sameca", lastname: "Dimov", age: 16 }, { firstname: "Marto", lastname: "unknown", age: 26 }];

    function findYoungest(arr) {

        var youngestAge = 99;

        for (i in arr) {
            if (arr[i].age < youngestAge) {
                youngestAge = arr[i].age;
                youngestPos = i;
            }
        }

        jsConsole.writeLine(arr[youngestPos].firstname + " " + arr[youngestPos].lastname);
    }

    findYoungest(persons);
}

document.getElementById("reset").onclick = function Erase() {
    document.getElementById("js-console").innerHTML = "";
    document.location.reload();
}