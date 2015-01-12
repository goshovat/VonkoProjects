document.getElementById("execute").onclick = function Execute() {
	var arr = document.getElementsByTagName("div");
	jsConsole.writeLine(arr.length);
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}