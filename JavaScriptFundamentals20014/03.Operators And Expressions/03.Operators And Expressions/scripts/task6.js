function execute() {
    var x = document.getElementById("x").value;
    var y = document.getElementById("y").value;
    var radius = 5;

    if (x != "" || y != "") {

        if (isNaN(x) || isNaN(y)) {
            output = "Please enter a valid number!";
        }
        else {
            var isWithinCircle;

            if (x * x + y * y < radius*radius) {
                output = "The point is inside the circle.";
            }
            else if (x * x + y * y == radius * radius) {
                output = "The point is on the circle";
            }
            else {
                output = "The point is outside the circle";
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