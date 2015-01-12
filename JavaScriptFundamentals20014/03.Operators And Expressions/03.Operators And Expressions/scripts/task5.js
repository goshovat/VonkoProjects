function execute() {
    var input = document.getElementById("input0").value;

    if (input != "") {
        var output = 0;

        if (isNaN(input)) {
            output = "Please enter a valid number!"
        }
        else {
            input = parseInt(input);
           
            input = input >> 3;

            var thirdBit = input & 1;
            output = thirdBit;
        }

        document.getElementById("output").innerHTML = output;
    }
}

function reset() {
    location.reload();
}

document.getElementById("execute").onclick = execute;
document.getElementById("reset").onclick = reset;