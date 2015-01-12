function calculate() {
	var a = document.getElementById("a").value;
	var b = document.getElementById("b").value;
	var c = document.getElementById("c").value;
	var D = b*b - 4*a*c;
	if (isNaN(a) || isNaN(b) || isNaN(c)) {
		jsConsole.writeLine("Please enter three real numbers!")
	}
	else {
		if (a != 0) {
			if (D > 0) {
				var x1 = (-b + Math.sqrt(D))/(2*a);
				var x2 = (-b - Math.sqrt(D))/(2*a);
				jsConsole.writeLine("The roots of the equation are " + x1 + " and " + x2);
			}
			else if (D === 0) {
				var x = (-b)/(2*a);
				jsConsole.writeLine("The root of the equation is " + x);
			}
			else if (D < 0) {
				jsConsole.writeLine("There is no real solution");
			}
		}
		else if (b != 0) {
			var x = (-c)/2;
			jsConsole.writeLine("The solution is " + x);
		}
		else  {
			jsConsole.writeLine("No quadratic equation!")
		}
	}
}