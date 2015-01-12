function check() {
	var arr = new Array(5);
	arr[0] = parseInt(document.getElementById("a").value);
	arr[1] = parseInt(document.getElementById("b").value);
	arr[2] = parseInt(document.getElementById("c").value);
	arr[3] = parseInt(document.getElementById("d").value);
	arr[4] = parseInt(document.getElementById("e").value);
	var theBiggest = arr[0];
	var i;
	if(isNaN(arr[0]) || isNaN(arr[1]) || isNaN(arr[2]) || isNaN(arr[3]) || isNaN(arr[4])){
		jsConsole.writeLine("Please enter only numbers");
	}
	else {
		for (i = 0; i < arr.length; i++) {
			if (arr[i] > theBiggest) {
				theBiggest = arr[i];
			}
		}
		jsConsole.writeLine("The biggest number is " + theBiggest);
	}
}