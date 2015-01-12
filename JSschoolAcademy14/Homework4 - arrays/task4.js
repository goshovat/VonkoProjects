document.getElementById("execute").onclick = function Execute() {

	var arr = [1, 2, 4, 5, 7, 8, 0, 1, 2, 1, 1, 4, 2, 5, 1, 2, 3, 4, 5, 6];
	
	var arrMax = [arr[0]];
	var arrNext = [arr[0]];
	count = 1;

	for (i = 0; i < arr.length - 1; i++) {
		if (arr[i] < arr[i + 1]) {
			arrNext.splice(arrNext.length, 0, arr[i+1]);
			count++;
			if (arrMax.length < count) {
				arrMax = arrNext;
			}
		}
		else {
			arrNext = [arr[i + 1]];
			count = 1;
		}
	}

	jsConsole.writeLine("Maximal increasing sequence is = " + arrMax.join("|"));
}

document.getElementById("erase").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}