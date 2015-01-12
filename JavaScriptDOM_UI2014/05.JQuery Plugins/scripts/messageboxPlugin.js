(function($) {
	$.fn.messageBox = function() {
		var $this = $(this);
		var $originalHTML = $($this).html();
		$this.hide();

		//define a function that will create the message boxes for both error and success
		function setMessageDiv(argColor, argHTML) {
			
			$this.css('display', 'inline-block')
			.css('position', 'absolute')
			.css('top', '200px')
			.css('left', '100px')
			.css('font-size', '28px')
			.css('padding', '20px 40px')
			.css('color', 'white')
			.css('background', argColor)
			.html(argHTML + $originalHTML)
			.css('border-radius', '10px')

			return $this;
		}

		var $currentMessage,
		$disappear;

		//define functions that will be returned by our plugin function and can be called on the object the plugin is called upon
		return {
			success: function (argHTML) {

				$currentMessage = setMessageDiv('green', argHTML)
				.hide()
				.fadeIn(1000)

				clearTimeout($disappear);
				$disappear = setTimeout(function() {$currentMessage.fadeOut(1000)}, 3000); 
				return $this;
			},

			error: function (argHTML) {

				$currentMessage = setMessageDiv('red', argHTML)
				.hide()
				.fadeIn(1000);

				clearTimeout($disappear);
				$disappear = setTimeout(function() {$currentMessage.fadeOut(1000)}, 3000); 
				return $this;
			}
		}

	}
}(jQuery))