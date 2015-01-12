document.getElementById("execute").onclick = function Execute() {
	var arr = [1, 2, 3, 4, 5, 4, 2, 4, 5, 5, 5, 4, 4];
	//arr sorted = [1, 2, 2, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5];

	arr.sort();

	len = 1;
	bestLen = 1;
	sequenceArr = [];
	needToPush = true;
	
	for (i = 1; i < arr.length; i++) {
		if (arr[i] != arr[i - 1]) {
			len = 1;
			needToPush = true;
		}
		else {
			len++;
			if (len > bestLen) {
				bestLen = len;
				sequenceArr.length = 0;
				sequenceArr.push(arr[i]);
			}
			else if (len == bestLen) {
				if (needToPush) {
					sequenceArr.push(arr[i]);
					needToPush = false;
				}
			}
		}
	}
	

	jsConsole.write("The longest sequence is of " + bestLen + " elements");

	for (j = 0; j < sequenceArr.length; j++) {
		jsConsole.writeLine();
		for (k = 0; k < bestLen; k++) {
			jsConsole.write(sequenceArr[j] + ",");
		}
	}
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("reset").innerHTML = "";
	document.location.reload();
}