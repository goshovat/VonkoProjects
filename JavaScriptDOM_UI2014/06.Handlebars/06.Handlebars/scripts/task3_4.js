$(window).on('load', function () {
    var books = [
    {
        id: 1,
        title: 'JavaScript: The Good Parts'
    }, {
        id: 2,
        title: 'Secrets of the JavaScript Ninja'
    }, {
        id: 3,
        title: 'Core HTML5 Canvas'
    }, {
        id: 4,
        title: 'JavaScript patterns'
    }
    ]

    var students = [
        {
            number: 1,
            name: 'Peter Petrov',
            mark: 5.5
        }, {
            number: 2,
            name: 'Stamat Georgiev',
            mark: 4.7
        }, {
            number: 3,
            name: 'Maria Todorova',
            mark: 6
        }, {
            number: 4,
            name: 'Georgi Geshov',
            mark: 3.7
        }
    ]

    $('#books-list').listView(books);
    $('#students-table').listView(students);
    $('#students-table-nodata').listView(students);
})
