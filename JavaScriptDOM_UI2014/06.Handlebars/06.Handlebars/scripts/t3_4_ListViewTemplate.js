(function ($) {
    $.fn.listView = function (argCollection) {
        var $this = $(this);

        //get the data-template of our object so to find the script template with the same id
        var $thisDataTemplate = $($this).attr('data-template');

        var $templateScriptHTML;

        if ($thisDataTemplate) {
            $templateScriptHTML = $('#' + $thisDataTemplate).html();
        } else {
            $templateScriptHTML = $this.html();
        }

        //create this object with one property to use in the template function
        var argCollectionObj = {
            argCollectionProp: argCollection
        }

        //get the name of the property in the above created object
        var propName;

        var keyNames = Object.keys(argCollectionObj);
        for (var prop in keyNames) {
            propName = keyNames[prop];
        }

        //add block expression to our template so the template is compiled fo every object in the collection
        var $newtemplateScriptHTML = '{{#' + propName + '}}' +
                                        $templateScriptHTML + '{{/' + propName + '}}';

        var $templateFunc = Handlebars.compile($newtemplateScriptHTML);

        var compiledHTML = $templateFunc(argCollectionObj);

        $this.html(compiledHTML);
       
        return $this;
    }
}(jQuery));