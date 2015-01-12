function execute() {
    var input = document.getElementById("input0").value;

    if (input != "") {
        var output = 0;

        if (isNaN(input)) {
            output = "Please enter a valid number!"
        }
        else {
            input = parseInt(input);

            if (input % 5 == 0 && input % 7 == 0) {
                output = "Yes, it can."
            }
            else {
                output = "No, it cannot."
            }
        }

        document.getElementById("output").innerHTML = output;
    }
}

function reset() {
    location.reload();
}

document.getElementById("execute").onclick = execute;
document.getElementById("reset").onclick = reset;