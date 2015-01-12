document.getElementById("execute").onclick = function Execute() {
    arr = [9, 4, 1, 3, 7, 8];
    move = true;

	    while (move) {
	        move = false;
	        for (i = 0; i < arr.length; i++) {
	            if (arr[i] > arr[i + 1]) {
	                k = arr[i];
	                arr[i] = arr[i + 1];
	                arr[i + 1] = k;
	                move = true;
	            }
	        }
	    }

	jsConsole.writeLine(arr)
}

document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}