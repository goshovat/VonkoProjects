document.getElementById("click").onclick = function Execute() {
	//here we cycle through the properties of document
	var order = new Array();
	var prop;

	for (prop in document) {
		order.push(prop);
	}
	//here we arrange the array in alphabetic order
	order.sort();

	var output1 = "Smallest: " + order[0] + "\nLargest: " + order[order.length-1];
	document.getElementById("output1").innerHTML = output1;
	//here we cycle trough the properties of window
	var order1 = new Array();
	var prop1;

	for (prop1 in window) {
		order1.push(prop1);
	}
	//here we arrange the array in alphabetic order
	order1.sort();

	var output1 = "Smallest: " + order1[0] + "\nLargest: " + order1[order1.length-1];
	document.getElementById("output2").innerHTML = output1;
	//here we cycle through the properties of navigator
	var order2 = new Array;
	var prop2;

	for (prop2 in navigator) {
		order2.push(prop2);
	}
	//here we arrange the array in alphabetic order
	order2.sort();
	var output2 = "Smallest: " + order2[0] + "\nLargest: " + order2[order2.length -1];
	document.getElementById("output3").innerHTML = output2;
} 

document.getElementById("check").onclick = function Show() {
	if (document.getElementById("check").checked) {
		document.getElementById("condition").style.display = "block";
	}
	else {
		document.getElementById("condition").style.display = "none";
	}

}

document.getElementById("condition").style.display = "none";