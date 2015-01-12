function execute() {
    var input = document.getElementById("input0").value;

    if (input != "") {
        var output = 0;

        if (isNaN(input)) {
            output = "Please enter a valid number!"
        }
        else {
            var divider = 2;
            var maxDivider = Math.sqrt(input);
            var isPrime = true;

            for (var i = divider; i <= maxDivider; i++) {
                if (input % i == 0) {
                    isPrime = false;
                    break;
                }
            }

            output = isPrime;
        }
        document.getElementById("output").innerHTML = output;
    }   
}

function reset() {
    location.reload();
}

document.getElementById("execute").onclick = execute;
document.getElementById("reset").onclick = reset;