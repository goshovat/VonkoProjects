window.onload = onWindowLoad;

//this function attaches events to the buttons as sonn as the document is loaded
function onWindowLoad() {
	var btn = document.getElementById('execute');
    var btn1 = document.getElementById('execute1');

    btn.onclick = changeBgColorQuery;
    btn1.onclick = changeBgColorQueryAll;
}

//this function changes the background of only one div
function changeBgColorQuery() {
	var selectedEl;

	if (!document.querySelector) {
		selectedEl = shimQuerySelector('#wrapper');
	} else {
		selectedEl = document.querySelector('#wrapper');
	}
	selectedEl.style.background = 'blue';
}

//this function changes the background of multiple divs
function changeBgColorQueryAll() {
	var selectedEls;

	if (!document.querySelectorAll) {
		selectedEls = shimQuerySelectorAll('.innerDiv');
	} else {
		selectedEls = document.querySelectorAll('.innerDiv');
	}

	for (var i = 0, len = selectedEls.length; i < len; i++) {
		selectedEls[i].style.background = 'pink';
	};
}

//this functions shims query selector for older browsers
function shimQuerySelector(selector) {
	//we use char at because string indexator is not supported on older
	//browsers
	var firstChar = selector.charAt(0);
	var selectedEl;

	switch (firstChar) {
		case '.': 
			var clas = selector.substr(1, selector.length - 1);
			selectedEl = document.getElementsByClassName(clas)[0];
			break;
		case '#':
			var id = selector.substr(1,selector.length - 1);
			selectedEl = document.getElementById(id);
			break;
		default:
			selectedEl = document.getElementsByTagName(selector)[0];
		}

	return selectedEl;
}

//this function shims querySelectorAll for older browsers
function shimQuerySelectorAll(selector) {
	var firstChar = selector.charAt(0);
	var selectedEls;

	switch(firstChar) {
		case '.':
			var clas = selector.substr(1, selector.length - 1);
			selectedEls = document.getElementsByClassName(clas);
			break;
		case '#':
			var id = selector.substr(1, selector.length - 1);
			selectedEls = document.getElementById(id);
			break;
		default:
			var selectedEls = document.getElementsByTagName(selector);
			break;
	}

	return selectedEls;
}

//Here we implement the method getElementsByClassName because it is not supported in IE8
document.getElementsByClassName = function(cl) {
    var retnode = [];
    var elem = this.getElementsByTagName('*');
    for (var i = 0; i < elem.length; i++) {
        if ((' ' + elem[i].className + ' ').indexOf(' ' + cl + ' ') > -1) retnode.push(elem[i]);
    }
    return retnode;
};
