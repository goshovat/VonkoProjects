var tags = ["cms", "cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css",
    "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC",
    "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript",
    "http", "http", "CMS", "cms", "cms", "cms"
];

var minFontSize = 17,
	maxFontSize = 42; 

var tagsContainer = document.createElement('div');
tagsContainer.style.display = 'inline-block';
tagsContainer.style.padding = '10px 15px';
tagsContainer.style.border = '1px solid black';
tagsContainer.style.borderRadius = '10px';

function generateTagCloud(argTags, argMinFontSize, argMaxFontSize) {
	var tagsCount = {};

	//check how many times each tag is contained in the array
	for (var i = 0; i < tags.length; i++) {
		if (tagsCount[argTags[i]]) {
			tagsCount[tags[i]]++;
		} else {
			tagsCount[argTags[i]] = 1;
		}
	};

	//assign corresponding font-size and other styles to the tags
	for (var i in tagsCount) {
		var currentTag = document.createElement('span');
		currentTag.style.fontFamily = 'Segoe UI';
		currentTag.style.marginRight = '20px';
		currentTag.style.fontSize = tagsCount[i] * 5 + argMinFontSize + 'px';
		if (currentTag.style.fontSize > argMaxFontSize) {
			currentTag.style.fontSize = argMaxFontSize + 'px';
		}
		currentTag.innerHTML = i;

		tagsContainer.appendChild(currentTag);
	};

	document.body.appendChild(tagsContainer);
}

window.onload = function() {
	generateTagCloud(tags, minFontSize, maxFontSize);
}