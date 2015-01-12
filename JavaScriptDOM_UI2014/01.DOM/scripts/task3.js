window.addEventListener('load', onWindowLoad);

//this function will attach event handler to the button as soon as the
//document is loaded
function onWindowLoad() {
	var btn = document.getElementById('execute');
	btn.addEventListener('click', changeBgColor);
}

//this is the function that changes the body color
function changeBgColor() {
	var color = document.getElementById('color-picker').value;
	var body = document.body;
	body.style.background = color;
}