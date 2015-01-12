var btn = document.getElementById('execute');

btn.addEventListener('click', function() {
	//create templates of out div and strong elements
	var divTemplate = document.createElement('div');
	divTemplate.style.position = "absolute";

	var strongTemplate = document.createElement('strong');
	strongTemplate.style.position = 'relative';
	strongTemplate.innerHTML = 'div';

	divTemplate.appendChild(strongTemplate);

	var dFrag = document.createDocumentFragment();
	var horizontalPos = ['left', 'right', 'center'];
	var borderStyles = ['solid', 'dashed', 'dotted', 'inset', 'outset'];
	var verticalAllign = ['0', '20%', '50%'];

	//now we will create the div elements
	for (var i = 0; i < 20; i++) {
		//set random styles of every div
		divTemplate.style.width = generateRandomNumber(20, 100) + 'px';
		divTemplate.style.height = generateRandomNumber(20, 100) + 'px';
		divTemplate.style.background = generateRandomColor();
		divTemplate.style.color = generateRandomColor();
		divTemplate.style.textAlign = horizontalPos[generateRandomNumber(0, 3)];
		divTemplate.style.top = generateRandomNumber(150, 600) + 'px';
		divTemplate.style.left = generateRandomNumber(0, 1100) + 'px';
		divTemplate.style.borderRadius = generateRandomNumber(0, 50) + 'px';
		divTemplate.style.borderColor = generateRandomColor();
		divTemplate.style.borderWidth = generateRandomNumber(0, 20) + 'px';
		divTemplate.style.borderStyle = borderStyles[generateRandomNumber(0, 5)];

		strongTemplate.style.top = verticalAllign[generateRandomNumber(0, 3)];

		//append our divs to dFrag
		dFrag.appendChild(divTemplate.cloneNode(true));
	};

	//append all divs to the DOM at once
	document.body.appendChild(dFrag);

	//create a function that generates random number
	function generateRandomNumber(argFrom, argTo) {
		var randomNumber = (Math.random() * (argTo - argFrom) + argFrom) | 0;
		return randomNumber;
	}

	//create a function that generates random color
	function generateRandomColor() {
		var randomColor = 'rgb(';
		for (var i = 0; i < 3; i++) {
			if (i < 2) {
				randomColor += generateRandomNumber(0, 255) + ', ';
			} else {
				randomColor += generateRandomNumber(0, 255);
			}
		};
		randomColor += ')';

		return randomColor;
	}

});