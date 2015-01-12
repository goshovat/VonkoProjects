function execute() {
    var input0 = document.getElementById("input0").value;
    var input1 = document.getElementById("input1").value;

    if (input1 != "" || input1 != "") {
        var output = 0;
        
        if (isNaN(input0) || isNaN(input1)) {
            output = "Please enter a valid number!"
        }
        else {
            input0 = parseInt(input0);
            input1 = parseInt(input1);

            if (input0 > input1) {
                var temp = input0;
                input0 = input1;
                input1 = temp;
            }

            output = "First Variable: " + input0 + "<br/>" + "Second Variable: " + input1;
        }

        document.getElementById("output").innerHTML = output;
    }
}

function reset() {
    location.reload();
}

document.getElementById("execute").onclick = execute;
document.getElementById("reset").onclick = reset;