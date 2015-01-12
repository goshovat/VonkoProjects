document.getElementById("execute").onclick = function printLast(inp) {
	var inp = document.getElementById("input").value;
	var length = inp.length;

	if (isNaN(inp)) {
		jsConsole.writeLine("Please enter a number");
	}
	else {
		for (i in inp) {
			if (i == inp.length -1)
				switch (inp[i]) {
					case "1": jsConsole.writeLine("one"); break;
					case "2": jsConsole.writeLine("two"); break;
					case "3": jsConsole.writeLine("three"); break;
					case "4": jsConsole.writeLine("four"); break;
					case "5": jsConsole.writeLine("five"); break;
					case "6": jsConsole.writeLine("six"); break;
					case "7": jsConsole.writeLine("seven"); break;
					case "8": jsConsole.writeLine("eight"); break;
					case "9": jsConsole.writeLine("nine"); break;
					case "0": jsConsole.writeLine("zero"); break;
				}
		}
	}
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.getElementById("input").value = "";
	document.location.reload();
}


