function check() {
	var a = document.getElementById("digit").value;
	var aString = a.toString();
	if(aString.length === 1) {
		switch(aString) {
			case "0": jsConsole.writeLine("zero");break;
			case "1": jsConsole.writeLine("one");break;
			case "2": jsConsole.writeLine("two");break;
			case "3": jsConsole.writeLine("three");break;
			case "4": jsConsole.writeLine("four");break;
			case "5": jsConsole.writeLine("five");break;
			case "6": jsConsole.writeLine("six"); break;
			case "7": jsConsole.writeLine("seven"); break;
			case "8": jsConsole.writeLine("eight"); break;
			case "9": jsConsole.writeLine("nine");break;
			default: jsConsole.writeLine("Please enter a digit");break;
		}
	}
	else {
		jsConsole.writeLine("Please enter number consisting of 1 digit!");
	}
}