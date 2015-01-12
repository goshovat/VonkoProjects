document.getElementById("execute").onclick = function printLast(inp) {
	var inp = document.getElementById("input").value;
	var length = inp.length;

	if (isNaN(inp)) {
		jsConsole.writeLine("Please enter a number");
	}
	else {
		var arr = inp.split("");
		var reversed = arr.reverse();
		var string = reversed.join("");
		jsConsole.writeLine(string);
	}
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.getElementById("input").value = "";
	document.location.reload();
}

