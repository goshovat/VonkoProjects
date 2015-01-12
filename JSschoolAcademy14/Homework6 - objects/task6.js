document.getElementById("execute").onclick = function Execute() {
    var persons = [{ firstname: "Vonko", lastname: "Mihov", age: 24 },
    { firstname: "Sameca", lastname: "Dimov", age: 16 }, { firstname: "Marto", lastname: "unknown", age: 26 }];

}

document.getElementById("reset").onclick = function Erase() {
    document.getElementById("js-console").innerHTML = "";
    document.location.reload();
}