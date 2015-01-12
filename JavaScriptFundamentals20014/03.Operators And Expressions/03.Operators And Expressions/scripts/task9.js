function execute() {
    var x = document.getElementById("x").value;
    var y = document.getElementById("y").value;
    var radius = 3;

    if (x != "" || y != "") {

        if (isNaN(x) || isNaN(y)) {
            output = "Please enter a valid number!";
        }
        else {
            var isWithinCircle = false;
            var isWithinRectang = false;

            if ((x-1) * (x-1) + (y-1) * (y-1) <= radius * radius) {
                isWithinCircle = true;
            }
           
            if (x >= -1 && x <= 5 && y <= 1 && y >= -1) {
                isWithinRectang = true;
            }

            if (isWithinCircle == true && isWithinRectang == false) {
                output = "Yes";
            }
            else {
                output = "No";
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