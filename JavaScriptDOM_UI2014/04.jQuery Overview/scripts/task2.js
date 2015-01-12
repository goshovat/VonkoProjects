$(window).on('load', function() {
	var $newP = $('<p>').html("I'm a paragrapha that was dinamically appended");

	//add funtionality to append before
	$('#execute').on('click', function() {
		$('#initial-div').before($newP);
	});

	//add functionality to append after
	$('#execute1').on('click', function() {
		$('#initial-div').after($newP);
	})
})