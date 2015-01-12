$(window).on('load', function() {
	var $studentsArr = [ {firstName: 'Vonko', lastName:'Mihov', grade: 23},
					{firstName: 'Somko', lastName:'Dimov', grade: 16},
					{firstName: 'Sashko', lastName:'Sashkov', grade: 25},
					{firstName: 'Tsonko', lastName:'Tsonkov', grade: 10},
				];


	//create the table on-click
	$('#execute').on('click', function() {
    //append the table

	    $('<table>')
	        .append('<thead>')
	        .appendTo('body');

	    $('thead').append('<tr>');
	    $('tr').append('<th>First Name</th><th>Last Name</th><th> Grade</th>');

	    //fill the table
	    for (var i = 0; i < $studentsArr.length; i++) {
	        $('table').append('<tr>');

	        for (var prop in $studentsArr[i]) {
	            $('<td>').html($studentsArr[i][prop]).appendTo('tbody tr:last-of-type');
	        };
	    };

	})

})