function execute() {
    var width = document.getElementById("width").value;
    var height = document.getElementById("height").value;

    if (width != "" || height != "") {

        if (isNaN(width) || isNaN(height)) {
            output = "Please enter a valid number!"
        }
        else {
            width = parseFloat(width);
            height = parseFloat(height);

            var area = width * height;
            output = area;
        }

        document.getElementById("output").innerHTML = output;
    }
}

function reset() {
    location.reload();
}

document.getElementById("execute").onclick = execute;
document.getElementById("reset").onclick = reset;