$(window).on('load', function() {
	
	//create a table for the grid
    var $sampleTable = $("<table>");
    $($sampleTable).attr('data-header', 'no');
    $($sampleTable).append("<tbody>").html("<tr><td>Table item</td><td>Table item</td><td>Table item</td><td>Table item</td></tr><tr><td>Table item</td><td>Table item</td><td>Grid Sub-View<table><tr><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td></tr><tr><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td></tr><tr><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td></tr></table></td><td>Table item</td></tr><tr><td>Table item</td><td>Table item</td><td>Grid SubView<table><tr><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td></tr><tr><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td></tr><tr><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td><td>SubTableItem1</td></tr></table></td><td>Table item</td></tr>");

    var $sampleHeaderRow = $("<thead>").html("<tr><th>Head Item</th><th>Head Item</th><th>Head Item</th><th>Head Item</th></tr>");
    var $sampleRow = $("<tr>").html("<td>Row Item</td><td>Row Item</td><td>Row Item</td><td>Row Item</td>");
    var $sampleSelectViewLink = $("<a>").attr("href", "#");

    //we append the grid-view selection links
    $("body").append("<p>");
    $("body p").append("<p>");
    $("body p p").addClass("viewLinks").html("Choose a grid-view to display: ");

    var $selectViewLink1 = $sampleSelectViewLink.attr("id", "selectViewLink1").html("1");

    $selectViewLink1.click(function() {
        $("table.selected").removeClass("selected").hide();
        $("body > table:first-of-type").addClass("selected").fadeIn(1000);
        $('p p a').css('border', '');
    	$(this).css('border', '1px solid black');
    })

    $("p.viewLinks").append($selectViewLink1);

    //append the first grid view to the document
    $("body").append($sampleTable.clone().addClass("selected"));
    $('table').hide().fadeIn(1000);

    var i = 1;
    //implement functionality to add different view-grids(tables)
    $("#addGridView").on('click', function() {
    	i++;
    	$('table.selected').removeClass('selected').hide();
    	var $newGridView = $($sampleTable).clone().addClass('selected');

    	var $newSelectViewLink = $($sampleSelectViewLink).clone()
    								.attr('id', 'selectViewLink' + i)
    								.html(i);

    	$($newSelectViewLink).on('click', function() {
    		$('table.selected').removeClass('selected').hide();
    		$($newGridView).addClass('selected').fadeIn(1000);
    		$('p p a').css('border', '');
    		$(this).css('border', '1px solid black');
    	})

    	$($newSelectViewLink).appendTo('p.viewLinks')
    	$($newGridView).appendTo('body').hide().fadeIn(1000);

    })

    //implement functionality to add a header row
    $("#addHeaderRow").on('click', function() {
    	var $currentHeader = ($sampleHeaderRow).clone();
    	var $currentTable = $('table.selected');

    	if ($currentTable.attr('data-header')  == 'no') {
    		$($currentTable).prepend($currentHeader).hide().fadeIn(1000);
    		$($currentTable).attr('data-header', 'yes');
    	}
    });

    //implement functionallity to add table rows
    $("#addRow").on('click', function() {
    	$($sampleRow).clone().appendTo('table.selected > tbody').hide().fadeIn(1000);
    })

    $('body').show();
})