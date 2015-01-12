//PLEASE NOTE: for easier testing I put the value inside a div, not in the console
window.addEventListener('load', onWindowLoad);

//this function attaches event to the button as soon as the document is loaded
function onWindowLoad() {
	var btn = document.getElementById('execute');
	btn.addEventListener('click', printValue);
}

//this is the function that will print the value in the output div
function printValue() {
	var input = document.getElementById('textfield');
	var value = textfield.value.trim();

	var output = document.getElementById('output');

	output.innerHTML = value;
}