document.getElementById("execute").onclick = function Execute() {
	var number = document.getElementById("input").value;
	var arr = document.getElementById("text").value;
	
	var index = arr.indexOf(number);

	if ((index != 0) && (index != arr.length-1)) {
		for (i in arr) {
			if (arr[index] > arr[index + 1] && arr[index] > arr[index - 1]) {
				result = "The number is bigger";
			}
			else {
				result = "The number is not bigger";
			}
		}
	}
	else {
		result = "The number is at the end of the array";
	}

	jsConsole.writeLine(result);

}



document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}