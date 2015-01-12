function check() {
	var bigger = document.getElementById("bigNum").value;
	var smaller = document.getElementById("smallNum").value;
	if (bigger === smaller) {
		jsConsole.writeLine("The numbers are equal");
	}
	else {
		if (bigger > smaller) {
			jsConsole.writeLine("The bigger number is " + bigger);
		}
		else {
			bigger = smaller;
			jsConsole.writeLine("The bigger number is " + bigger);
		}
	}
}