document.getElementById("execute").onclick = function Execute() {
	var arr = ["a", "b", "c", "d", "g", "k", "l"];
	var arr1 = ["m", "n", "a", "c", "g", "h", "z", "q", "gosho" ];

	if (arr.length <= arr1.length) {
		for (i in arr) {
			if (arr[i] > arr1[i]) {
				jsConsole.writeLine(arr[i]);
			}
			else if (arr[i] == arr1[i]) {
				jsConsole.writeLine("The two elements are equal");
			}
			else {
				jsConsole.writeLine(arr1[i]);
			}
		}
	}

	else {
		for (i in arr1) {
			if (arr1[i] > arr[i]) {
				jsConsole.writeLine(arr1[i]);
			}
			else if (arr1[i] == arr[i]) {
				jsConsole.writeLine("The two elements are equal");
			}
			else {
				jsConsole.writeLine(arr[i]);
			}
		}
	}
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}