function isInCircle() {
	var x = document.getElementById("x").value;
	var y = document.getElementById("y").value;
	var r = 5;
	if ((x*x + y*y) < (r*r)) {
		jsConsole.writeLine("The point is in the circle");
	}
	else {
		jsConsole.writeLine("The point is not in the circle");
	}
}