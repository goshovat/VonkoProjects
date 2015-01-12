(function ($) {
    $.fn.tabs = function () {
        var $tabControl = $(this);

        //add this class so the stylesheet will work
        $($tabControl).addClass('tabs-container');

        //first make visible only the first-tab content
        $($tabControl).find('div.tab-item-content').hide();

        $($tabControl).find('.tab-item:first-of-type .tab-item-content').show();
        $($tabControl).find('.tab-item:first-of-type').addClass('current');     

        //attach onclick event on the tab titles to show their content

        $tabControl.on('click', '.tab-item-title', function () {
            var $currentShownDiv = $($tabControl).find('.tab-item-content').css('display', 'block');

            $($currentShownDiv).hide();
            $($tabControl).find('.current').removeClass('current');
            
            $(this).next().show();
            $(this).parent().addClass('current');
        })
    }
}(jQuery))