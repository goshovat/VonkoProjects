document.getElementById("execute").onclick = function Execute() {
	var arr = [3, 4, 5, 6, 7, 34, 54, 78, 88];
	var min = 0;
	var max = arr.length - 1;
	var key = 5;
	var found = false;
	var mid;
	var index;

	while(!found && min <=max) {
		mid = parseInt((min+max)/2);
		if(key == arr[mid]) {
			index = mid;
			found = true;
		}
		else if (key < arr[mid]) {
			max = mid -1;
		}
		else {
			min = mid +1;
		}
	}
	jsConsole.writeLine(index);
}


document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}