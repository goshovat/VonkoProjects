document.getElementById("execute").onclick = function Display() {
	var arr = new Array(20);
	for (i = 0; i < arr.length; i++) {
		arr[i] = i * 5;
		jsConsole.writeLine(arr[i]);
	}
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	window.location.reload();
}