document.getElementById("execute").onclick = function Execute() {
	var arr = document.getElementById("text").value;


	for (i = 0; i < arr.length; i++) {

		if (arr[i] > arr[i+1] && arr[i] > arr[i-1]) {
			result = i;
			break;
			}

			else {
				result = "-1";
			}
		}
	

	jsConsole.writeLine(result);

}



document.getElementById("reset").onclick = function Erase() {
	document.getElementById("js-console").innerHTML = "";
	document.location.reload();
}