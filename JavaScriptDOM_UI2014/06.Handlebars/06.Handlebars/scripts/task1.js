$(window).on('load', function () {

    //template object
    var $lecturesObject = {
        thead: {
            thNumber: 'No',
            thTitle: 'Title',
            thDate1: 'Date #1',
            thDate2: 'Date #2'
        },

        tbody: [
        {
            number: 0,
            title: 'Course Introduction',
            date1: 'Wed 18:00, 28-May-2014',
            date2: 'Thu 14:00, 29-May-2014'
        }, {
            number: 1,
            title: 'Document Object Model',
            date1: 'Wed 18:00, 28-May-2014',
            date2: 'Thu 14:00, 29-May-2014'
        }, {
            number: 2,
            title: 'HTML 5 Canvas',
            date1: 'Thu 18:00, 29-May-2014',
            date2: 'Fri 14:00, 30-May-2014'
        }, {
            number: 3,
            title: 'Kinetic JS Overview',
            date1: 'Thu 18:00, 29-May-2014',
            date2: 'Fri 14:00, 30-May-2014'
        }, {
            number: 4,
            title: 'SVG and RaphaelJS',
            date1: 'Wed 18:00, 04-Jun-2014',
            date2: 'Thu 14:00, 05-Jun-2014'
        }, {
            number: 5,
            title: 'Animation with Canvas and SVG',
            date1: 'Wed 18:00, 04-Jun-2014',
            date2: 'Thu 14:00, 05-Jun-2014'
        }, {
            number: 6,
            title: 'DOM Operations',
            date1: 'Thu 18:00, 05-Jun-2014',
            date2: 'Fri 14:00, 06-Jun-2014'
        }, {
            number: 7,
            title: 'Event Model',
            date1: 'Thu 18:00, 05-Jun-2014',
            date2: 'Fri 14:00, 06-Jun-2014'
        }, {
            number: 8,
            title: 'jQuery Overview',
            date1: 'Wed 18:00, 11-Jun-2014',
            date2: 'Thu 14:00, 12-Jun-2014'
        }, {
            number: 9,
            title: 'HTML 5 Templates',
            date1: 'Wed 18:00, 11-Jun-2014',
            date2: 'Thu 14:00, 12-Jun-2014'
        }, {
            number: 10,
            title: 'Exam preparation',
            date1: 'Thu 18:00, 12-Jun-2014',
            date2: 'Fri 14:00, 13-Jun-2014'
        }, {
            number: 11,
            title: 'Exam',
            date1: 'Tue 10:00, 17-Jun-2014',
            date2: 'Tue 16:30, 17-Jun-2014'
        }, {
            number: 12,
            title: 'Teamwork Defence',
            date1: 'Thu 10:00, 17-Jun-2014',
            date2: 'Thu 10:00, 19-Jun-2014'
        }
        ]
    }

    // prepare the template function
    var $templateHTML = $('#post-template').html();

    var $templateFunc = Handlebars.compile($templateHTML);

    var generatedHTML = $templateFunc({
        $lecturesThead: $lecturesObject.thead,
        $lecturesTbody: $lecturesObject.tbody    
    });

    $('body').html(generatedHTML);
})