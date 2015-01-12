function check() {
	var a = parseFloat(document.getElementById("Num1").value);
	var b = parseFloat(document.getElementById("Num2").value);
	var c = parseFloat(document.getElementById("Num3").value);

	if (a > b && a > c) {
		if (b > c) {
			jsConsole.writeLine("The order of the numbers is " + a + "," + b + "," +c);
		}
		else if (b < c) {
			jsConsole.writeLine("The order of the numbers is " + a + "," + c + "," + b);
		}
		else if (b === c) {
			jsConsole.writeLine("The biggest number is " + a + " and " + b + " and " + c + " are smaller and equal");
		}
	}
	else if (a < b && a < c) {
		if (b > c) {
			jsConsole.writeLine("The order of the numbers is " + b + "," + c + "," + a);
		}
		else if (b < c) {
			jsConsole.writeLine("The order of the numbers is " + c + "," + b + "," + a);
		}
		else if ( b === c) {
			jsConsole.writeLine("The numbers " + b + " and " + c + " are equal and bigger and " + a + " is smaller");			
		}
	}
	else if (a > b && a < c) {
		jsConsole.writeLine("The order of the numbers is " + c + "," + a + "," + b);
	}
	else if (a < b && a > c) {
		jsConsole.writeLine("The order of the numbers is " + b + "," + a + "," + c);
	}
	else if (a === b) {
		if (a === c) {
			jsConsole.writeLine("The three numbers are equal");
		}
		else if (b > c) {
			jsConsole.writeLine("The biggest numbers are" + a + " and " + b + " and " + c + " is smaller");
		}
		else if (b < c) {
			jsConsole.writeLine("The biggest is " + c + " and " + a + " and " + b + " are smaller");
		}
	}
	else if (a === c) {
		if (a ===b) {
			jsConsole.writeLine("The three numbers are equal");
		}
		else if (a > b) {
			jsConsole.writeLine("The numbers " + a + " and " + c + " are the biggest and " + b + " is smaller");
		}
		else if (a < b) {
			jsConsole.writeLine("The biggest number is " + b + " and " + a + " and " + c + " are equal and smaller");
		}
	}
}