window.addEventListener('load', onWindowLoad);

//we define the function that attaches the event handlers to the buttons
function onWindowLoad() {
	var btn = document.getElementById('execute');
	var btn1 = document.getElementById('execute1');

	btn.addEventListener('click', selectByQuery);
	btn1.addEventListener('click', selectByTagName)
}

//thi sfunction will manipulate the divs selected by querySelectorAll
function selectByQuery() {
	var divsNodeList = document.querySelectorAll('div div');

	for (var i = 0; i < divsNodeList.length; i++) {
		divsNodeList[i].style.background = 'pink';
	};
}

//this function will manipulate the divs selected by getElementsByTagName
function selectByTagName() {
	var allDivs = document.getElementsByTagName('div');

	for (var i = 0, len = allDivs.length; i < len; i++) {
		if (allDivs[i].parentNode.nodeName == 'DIV') {
			allDivs[i].style.background = 'gray';
		}
	};
}