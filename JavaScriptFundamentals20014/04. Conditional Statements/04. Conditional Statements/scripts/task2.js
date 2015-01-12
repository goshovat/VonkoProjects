function execute() {
    var input0 = document.getElementById("input0").value;
    var input1 = document.getElementById("input1").value;
    var input2 = document.getElementById("input2").value;

    if (input1 !== "" || input1 !== "" || input2 !== "") {
        var output = 0;

        if (isNaN(input0) || isNaN(input1) || isNaN(input2)) {
            output = "Please enter a valid number!"
        }
        else {
            var inputArray = [input0, input1, input2];
            var negativeCounter = 0;
            var isZero = false;

            for (var i = 0; i < inputArray.length; i++) {
                if(inputArray[i] == 0) {
                    output = "The product is zero";
                    isZero = true;
                }
                else if (inputArray[i] < 0) {
                    negativeCounter++;
                }
            }

            if (isZero === false) {
                if (negativeCounter % 2 === 0) {
                    output = "The product is positive"
                }
                else {
                    output = "The product is negative"
                }
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