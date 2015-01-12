(function($) {
    $.fn.dropdown = function() {
        //create and append the container

        var $containerDiv = $('<div class="dropdown-list-container">')
            .append('<ul class="dropdown-list-options">');

        $('body').append($containerDiv);

        var $this = $(this);

        var $options = $this.children('option');

        for (var i in $options) {
            //check if we loop through elements
            if ($($options[i]).is('option')) {
                //create li to represent the corresponding option
                var $newLi = $('<li>');

                //get the html of every option to set it on the li
                var $curHTML = $($options[i]).html();

                $($newLi).addClass('dropdown-list-option')
                    .attr('data-value', ($options[i].value))
                    .html($curHTML);

                // var $selected = $('#drowpdown:selected');
                var $selected = $('#dropdown').find('option').attr('selected', 'selected')

                //attach functionality to select option via its corresponding list-item
                $($newLi).on('click', function() {

                    $($options).removeAttr('selected');
                    $('li.dropdown-list-option').removeAttr('selected');

                    $($this).children('option[value="' + $(this).data('value') + '"]').attr('selected', '');
                    $(this).attr('selected', '');

                    //test the $('#dropdown:selected') selector

                    $selected = $('#dropdown :selected');
                    console.log($($selected).html());

                    $('option').removeAttr('style');
                    $($selected).css('color', 'red');
                });

                $('ul.dropdown-list-options').append($newLi);
            } else {
                break;
            }

            
        };

        return $('ul.dropdown-list-options');
    }
}(jQuery));

