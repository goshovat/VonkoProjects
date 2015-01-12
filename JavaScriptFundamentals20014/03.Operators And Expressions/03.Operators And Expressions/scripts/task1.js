﻿function execute() {
    var input = document.getElementById("input0").value;

    if (input != "") {
        var output = 0;
        
        if (isNaN(input)) {
            output = "Please enter a valid number!"
        }
        else {
            input = parseInt(input);
            if (input % 2 == 0) {
                output = "The number is even."
            }
            else if (input % 2 != 0) {
                output = "The number is odd."
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