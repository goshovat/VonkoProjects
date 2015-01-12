$(window).on('load', function () {

    //template array
    var $itemsArray = [
        {
            value: 1,
            text: 'One'
        }, {
            value: 2,
            text: 'Two'
        }, {
            value: 3,
            text: 'Three'
        }, {
            value: 4,
            text: 'Four'
        }, {
            value: 5,
            text: 'Five'
        }, {
            value: 6,
            text: 'Six'
        }, {
            value: 7,
            text: 'Seven'
        }
    ]

    //prepare template function
    var $templateHTML = $('#post-template').html();

    var $templateFunc = Handlebars.compile($templateHTML);

    var generatedHTML = $templateFunc({
        items: $itemsArray
    });

    $('body').html(generatedHTML);
})
