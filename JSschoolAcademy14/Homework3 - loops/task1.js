function Print() {
	var n = document.getElementById("inputNumber").value;
	var counter = 1;
	if(isNaN(n)) {
		jsConsole.writeLine("Please enter a number, bitch!")
	}
	else {
		while (counter <= n) {
			jsConsole.write(counter + " ");
			counter++;
		}
	}
}