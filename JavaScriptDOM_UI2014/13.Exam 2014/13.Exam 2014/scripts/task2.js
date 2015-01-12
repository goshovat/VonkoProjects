(function ($) {
    $.fn.gallery = function ($argColumns) {
        $('#root').css('text-align', 'center');

        var selectedDivHidden = false;

        //if not parameter is passed set default value
        $argColumns = $argColumns || 4;

        $('.gallery-list').css('width', $argColumns * 263);

        var $gallery = $(this);

        $($gallery).find('.selected').find('div').css('cursor', 'pointer');

        //add the appropriate class to the container so the css rules are applied
        $($gallery).addClass('gallery');

        //blur the gallery if we have selected pictures
        if (!selectedDivHidden) {
            $($gallery).find('.gallery-list').addClass('blurred');
        };

        //attach event to show enlarged pictures if they are not shown

        $($gallery).find('.image-container').on('click', function () {

            if (selectedDivHidden) {
                //remove the pointer from the blurred images
                $($gallery).find('.gallery-list .image-container')
                           .css('cursor', '');

                //make the appropriate image 'previous-image'
                var $newPrevEl = $(this).prev().clone();
                
                if (!$newPrevEl.html()) {
                    $newPrevEl = $($gallery).find('.image-container:last-of-type').clone();
                };

                $newPrevEl.removeClass('image-container');
                $newPrevEl.addClass('previous-image').css('cursor', 'pointer');

                //make the appropriate 'current-image'
                var $newCurrentEl = $(this).clone();

                $newCurrentEl.removeClass('image-container');
                $newCurrentEl.addClass('current-image').css('cursor', 'pointer');

                //make the appropriate image 'next-image'
                var $newNextEl = $(this).next().clone();

                if (!$newNextEl.html()) {
                    $newNextEl = $($gallery).find('.image-container:first-of-type').clone();
                };

                $newNextEl.removeClass('image-container');
                $newNextEl.addClass('next-image').css('cursor', 'pointer');

                //append the new elements to class selected
                $('.selected').empty();

                $($newPrevEl).appendTo('.selected').hide().fadeIn(500);
                $($newCurrentEl).appendTo('.selected').hide().fadeIn(550);
                $($newNextEl).appendTo('.selected').hide().fadeIn(600);

                $('.selected').show();

                //blur the images on the background
                $($gallery).find('.gallery-list').addClass('blurred');

                //after the images are changed, attach again the events
                $($gallery).find('.selected .previous-image').on('click', onPreviousImageClick);
                $($gallery).find('.selected .current-image').on('click', onCurrentImageClick);
                $($gallery).find('.selected .next-image').on('click', onNextImageClick);               
            }
        })

        //define function when previous image clicked
        function onPreviousImageClick() {

            //store the old current and next images
            var $currentImage = $('.current-image');
            var $nextImage = $('.next-image');

            //remove the events from the pictures
            $(this).unbind('click');
            $($currentImage).unbind('click');

            //use the src of the clicked picture to find the one before it in the gallery
            var $thisSrc = $(this).find('img').attr('src');

            var $newPrevEl = $('.gallery-list').find('img[src="' + $thisSrc + '"]').parent().prev().clone();

            //if there is no picture before select the last from the galley
            if (!$newPrevEl.html()) {
                $newPrevEl = $('.gallery-list > div:last-of-type').clone();
            }

            //set the new 'previous picture'
            $($newPrevEl).removeClass('image-container');
            $($newPrevEl).addClass('previous-image').css('cursor', 'pointer').hide().fadeIn(600);
            $('.selected').prepend($newPrevEl);

            //remove the old 'next-picture'
            $nextImage.removeClass('next-image');
            $nextImage.remove();

            //set the new 'next picture'
            $($currentImage).removeClass('current-image')
                            .css('cursor', 'pointer')
                            .addClass('next-image').hide().fadeIn(500);

            $($currentImage).find('img').attr('id', 'next-image');

            //set the new current image
            $(this).removeClass('previous-image');
            $(this).addClass('current-image').css('cursor', 'pointer')
                                             .hide().fadeIn(550);

            $(this).find('img').attr('id', 'current-image');

            //after the images are changed, attach again the events
            $($gallery).find('.selected .previous-image').on('click', onPreviousImageClick);
            $($gallery).find('.selected .current-image').on('click', onCurrentImageClick);
            $($gallery).find('.selected .next-image').on('click', onNextImageClick);
        }

        //define function when next image clicked
        function onNextImageClick() {
            var $currentImage = $('.current-image');
            var $prevImage = $('.previous-image');

            $(this).unbind('click');
            $($currentImage).unbind('click');

            var $thisSrc = $(this).find('img').attr('src');

            var $newNextEl = $('.gallery-list').find('img[src="' + $thisSrc + '"]').parent().next().clone();

            if (!$newNextEl.html()) {
                $newNextEl = $('.gallery-list > div:first-of-type').clone();
            };

            $($newNextEl).removeClass('image-container');
            $($newNextEl).addClass('next-image').css('cursor', 'pointer')
                                                .hide().fadeIn(600);

            $('.selected').append($newNextEl);

            $prevImage.removeClass('previous-image');
            $prevImage.remove();

            $($currentImage).removeClass('current-image').css('cursor', 'pointer')
                                                         .addClass('previous-image')
                                                         .hide().fadeIn(500);

            $($currentImage).find('img').attr('id', 'previuos-image');

            $(this).removeClass('next-image');
            $(this).addClass('current-image').css('cursor', 'pointer')
                                             .hide().fadeIn(550);

            $(this).find('img').attr('id', 'current-image');

            $($gallery).find('.selected .previous-image').on('click', onPreviousImageClick);
            $($gallery).find('.selected .current-image').on('click', onCurrentImageClick);
            $($gallery).find('.selected .next-image').on('click', onNextImageClick);
        };

        //define function when current image clicked
        function onCurrentImageClick() {

            //fade out the container of the selected pictures
            $('.selected').fadeOut(600);
            selectedDivHidden = true;

            clearTimeout(timeout);

            //with appropriate timing remove the container of selected images and
            //unblur the gallery on the background
            var timeout = setTimeout(function () {
                $('.selected').hide();
                $($gallery).find('.gallery-list').removeClass('blurred')
                $($gallery).find('.gallery-list .image-container')
                           .css('cursor', 'pointer');
            }, 600);
            
        }

        //attach onclick event on previous-image
        $($gallery).find('.selected .previous-image').on('click', onPreviousImageClick);

        //attach onclick event on current-image 
        $($gallery).find('.selected .current-image').on('click', onCurrentImageClick);

        //attach onclick event on next-image
        $($gallery).find('.selected .next-image').on('click', onNextImageClick);
    }

}(jQuery))