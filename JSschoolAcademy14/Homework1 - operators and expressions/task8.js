function area() {
	var a = parseFloat(document.getElementById("a").value);
	var b = parseFloat(document.getElementById("b").value);
	var h = parseFloat(document.getElementById("h").value);
	var result = (1/2)*(a+b)*h;
	jsConsole.writeLine(result);
}