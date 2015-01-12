$(window).on('load', function() {
    //create the color picker with the relevant plugin

    $('#picker').colpick({
        flat: true,
        layout: 'hex',
        submit: 0,
        onChange: function(hsb, hex) {
    		$('body').css('background', '#' + hex);
    	}
    });

})
