document.getElementById("execute").onclick = function Execute() {
	var arr = [1, 2, -9, -8, -2, 5, 6, 7];
	var tempVar;

	for (i = 0; i <= arr.length-1; i++) {
		for (j = i + 1; j <= arr.length; j++) {
			if (arr[j] < arr[i]) {
				tempVar =arr[i];
				arr[i] = arr[j];
				arr[j] = tempVar;
			}
		}
	}

	jsConsole.write("The arranged array is " + arr);
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}