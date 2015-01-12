function check() {
	var a = document.getElementById("a").value;
	var b = document.getElementById("b").value;
	var c = document.getElementById("c").value;
	var countNegativeNumbers = 0;
	if (a < 0) {
		countNegativeNumbers++;
	}
	if (b < 0) {
		countNegativeNumbers++;
	}
	if (c < 0) {
		countNegativeNumbers++;
	}
	if (countNegativeNumbers % 2 === 0) {
		jsConsole.writeLine("The sum will be positive");
	}
	else {
		jsConsole.writeLine("The sum will be negative");
	}
}