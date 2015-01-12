function check() {
	var number = document.getElementById("typeNumber").value;
	if (number % 5 === 0 && number % 7 === 0) {
		jsConsole.writeLine("Yes it can!")
	}
	else {
		jsConsole.writeLine("No, it cannot!")
	}
}