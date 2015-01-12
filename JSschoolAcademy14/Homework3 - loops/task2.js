function Print() {
	var n = document.getElementById("inputNumber").value;
	if(isNaN(n)) {
		jsConsole.writeLine("Please enter a number, bitch!")
	}
	else {
		for (i = 1; i <= n; i++) {
			if((i % 3 != 0) || (i % 7 != 0)) {
				jsConsole.writeLine(i);
			}
			else if ((i % 3 == 0) && (i % 7 == 0)) {
				jsConsole.writeLine("This number is divisible by 3 and 7 ");
			}
		}
	}
}