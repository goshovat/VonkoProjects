function check() {
	var a = parseInt(document.getElementById("Num1").value);
	var b = parseInt(document.getElementById("Num2").value);
	var c = parseInt(document.getElementById("Num3").value);
	if (a > b && a > c) {
		jsConsole.writeLine("The biggest number is " + a);
	}
	else if (a < b && a < c) {
		if (b > c) {
			jsConsole.writeLine("The biggest number is " + b);
		}
		else if(b < c) {
			jsConsole.writeLine("The biggest number is " + c);
		}
		else {
			jsConsole.writeLine("Numbers " + b + " and " + c + " are the biggest");
		}
	}
	else if (a < b && a > c) {
		jsConsole.writeLine("The biggest number is " + b);
	}
	else if ( a > b && a < c) {
		jsConsole.writeLine("The biggest number is " + c);
	}
	else if (a === b) {
		if (b > c) {
			jsConsole.writeLine("Numbers " + a + " and " + b + " are the biggest");
		}
		else if (b < c) {
			jsConsole.writeLine("The biggest number is " + c);
		}
		else if (b === c) {
			jsConsole.writeLine("The three numbers are equal");
		}
	}
	else if (a === c) {
		if (a > b) {
			jsConsole.writeLine("The biggest numbers are " + a + " and " + c);
		}
		else if (a < b) {
			jsConsole.writeLine("The biggest number is " + b);
		}
		else if (a === b) {
			jsConsole.writeLine("The three numbers are equal");
		}
	}
}