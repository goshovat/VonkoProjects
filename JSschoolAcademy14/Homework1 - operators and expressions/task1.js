function check() {
 	var number = document.getElementById("typeNumber").value;
 	if (isNaN(number) || number === "" || number === null ) {
 		jsConsole.writeLine("Write a number!");
 	}
	else {
	 	if (number % 2 === 0) {
	 		jsConsole.writeLine("The number is even");
	 	}
	 	else {
	 		jsConsole.writeLine("The number is odd");
	 	}
        if (number)
 	}
 }
 
