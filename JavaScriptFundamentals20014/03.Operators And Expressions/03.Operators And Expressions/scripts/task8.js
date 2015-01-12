function execute() {
    var base1 = document.getElementById("base1").value;
    var base2 = document.getElementById("base2").value;
    var height = document.getElementById("height").value;

    if (base1 != "" || base2 != "" || height != "") {

        if (isNaN(base1) || isNaN(base2) || isNaN(height)) {
            output = "Please enter valid numbers!"
        }
        else {
            base1 = parseFloat(base1);
            base2 = parseFloat(base2);
            height = parseFloat(height);

            var area = (base1 + base2)*height/2;
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