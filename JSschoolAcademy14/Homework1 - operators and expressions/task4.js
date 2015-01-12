function check() {
	var int = document.getElementById("typeNumber").value;
	if (int.length === 4) {
		function digit4() {
			if ((parseInt(int / 100)) % 10 === 7) {
			jsConsole.writeLine("The digit is 7");
			}
			else {
			jsConsole.writeLine("The digit is not 7");
			}
		}
		digit4();
	}
	else {
	    jsConsole.writeLine("Please enter 4 digit number");
	}
}