window.onload = function() {

	var sampleList = $('<ul>');

	//create the top ul
	var topList = $(sampleList).clone();

	//make templates for all the elements
	$(topList).attr('id','top-list');
	var sampleLI = $('<li>');
			  
    var sampleA = $('<a>');
    $(sampleA).attr('data-show', 'collapsed');
   	var sampleArrowSpan = $('<span>');
   	var sampleTextSpan = $('<span>');
   	sampleTextSpan.css('font-family', 'Segoe UI');
   	$(sampleArrowSpan).addClass('arrow');
   	$(sampleArrowSpan).html('&#10148;');
   	$(sampleArrowSpan).appendTo(sampleA);

   	//this function will render the tree-view structure
   	function createLists() {
   		//prepare the top-list items
		for (var i = 0; i < 5; i++) {
			var currentTopLi = $(sampleLI).clone()
			var currentTopA = $(sampleA).clone();
			var currentTopTextSpan = $(sampleTextSpan).clone();
			$(currentTopTextSpan).html('List Item ' + (i + 1))
							  .appendTo(currentTopA);

			//prepare the sub list and its items
			var currentSubList = $(sampleList).clone();
			$(currentSubList).css('display', 'none');

			for (var j = 0; j < 5; j++) {
				var currentSubLI = $(sampleLI).clone();
				var currentSubA = $(sampleA).clone();
				var currentSubTextSpan = $(sampleTextSpan).clone();
				$(currentSubTextSpan).html('Sub List Item ' + (j + 1))
									 .appendTo(currentSubA);

				//prepare the sub-sub list and it's items
				var currentSubSubList = $(sampleList).clone();
				$(currentSubSubList).css('display', 'none');

				for (var k = 0; k < 5; k++) {
					var currentSubSubLI = $(sampleLI).clone();
					var currentSubSubA = $(sampleA).clone();
					var currentSubSubTextSpan = $(sampleTextSpan).clone();
					$(currentSubSubTextSpan).html('Sub Sub List Item ' + (k + 1))
											.appendTo(currentSubSubA);

					$(currentSubSubA).appendTo(currentSubSubLI);
					$(currentSubSubLI).appendTo(currentSubSubList);
				};
				
				$(currentSubA).click(onClick);
				$(currentSubA).appendTo(currentSubLI);
				$(currentSubSubList).appendTo(currentSubLI);
				$(currentSubLI).appendTo(currentSubList);
			};
		
			$(currentTopA).click(onClick);
			$(currentTopA).appendTo(currentTopLi);
			$(currentSubList).appendTo(currentTopLi);			
			$(currentTopLi).appendTo(topList);
		};

		$(topList).appendTo('body');
	}
	createLists();

	function onClick() {
		if ($(this).attr('data-show') == 'collapsed') {
			$(this).attr('data-show', 'expanded');

			//make the item visible on click
			$(this).next()
						.css('display', '');

		} else if ($(this).attr('data-show') == 'expanded') {
			$(this).attr('data-show', 'collapsed');

			//make the item invisible on second click
			$(this).next()
						.css('display', 'none');
		}
	}
}