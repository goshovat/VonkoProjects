function check() {
	var x = document.getElementById("typeNumber").value;
	var p = 3;
    var mask = 1 << p;
    var result = x & mask;
    var bit = result >> p;
	jsConsole.writeLine("The third bit of number " + x.toString(2) + " is " + bit);
}