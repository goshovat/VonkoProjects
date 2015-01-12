function check() {
	var x = document.getElementById("typeNumber").value;
	if (x > 100) {
		jsConsole.writeLine("The number is bigger than 100");
	}
	else {
		if (x % 2 === 0 || x % 3 === 0 || x % 7 === 0) {
			jsConsole.writeLine("The number is not prime!")
		}
		else {
			jsConsole.writeLine("The number is prime!")
		}
	}
}

