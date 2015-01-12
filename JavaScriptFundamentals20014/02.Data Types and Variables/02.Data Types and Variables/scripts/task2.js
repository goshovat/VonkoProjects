function execute() {
    var quote = "'How are you doing?' John said."
    document.getElementById("output").innerHTML = quote;
}

function reset() {
    location.reload();
}

document.getElementById("reset").onclick = reset;
document.getElementById("execute").onclick = execute;