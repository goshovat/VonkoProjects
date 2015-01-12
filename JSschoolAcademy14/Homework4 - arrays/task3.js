document.getElementById("execute").onclick = function writeSequence() {

	var arr = [1, 1, 2, 2, 5, 5, 5, 5, 3, 3, 3, 3];
	len = 1;//declare the length of the current sequence
	bestLen = 1;//max length of the equal elements
	sequenceArr = [];//counts the maximal sequence of equal elements
	needToPush = true;

	for (i = 1; i < arr.length; i++) {
		if (arr[i] != arr[i - 1]) {
			//Start new sequence
			len = 1; //Reset length to 1
			needToPush = true;
		} else {
			//Continue current sequence
			len++;
			if (len > bestLen) {
				bestLen = len;
				sequenceArr.length = 0; //Reset the index of the array
				sequenceArr.push(arr[i]);
			}
			else if(len == bestLen) {
				if (needToPush) {
					sequenceArr.push(arr[i]);
					needToPush = false;
				}
			}
		}
	}
	//Print the results
	jsConsole.write("Maximal sequence of equal elements is " + bestLen);
	for (j = 0; j < sequenceArr.length; j++) {
		jsConsole.writeLine();
		for (k = 0; k < bestLen; k++) {
			jsConsole.write(sequenceArr[j] + "- ");
		}
	}
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}