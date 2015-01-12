$(window).on('load', function() {

    //set some cool background for the page
    $('body').css('background', 'url(imgs/background.jpg)');

    //create the different slides
    var $slideContainer = $("<div>").addClass('slide');
    var $sampleHeading = $("<h1>");

    //slide1
    var $heading1 = $sampleHeading.clone().html("Heading 1");
    var $paragraph1 = $("<p>").html("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. ");
    var $firstSlide = $($slideContainer).clone().append($heading1).append($paragraph1);

    //slide2
    var $heading2 = $sampleHeading.clone().html("Heading 2");
    var $ul2 = $("<ul>").html("<li>List item1</li><li>List item2</li><li>List item3</li><li>List item4</li>");
    var $secondSlide = $($slideContainer).clone().append($heading2).append($ul2);

    //slide3
    var $heading3 = $sampleHeading.clone().html("Heading 3");
    var $img3 = $("<img>").attr("src", "http://1.bp.blogspot.com/-El1TUf1TTFE/T7h7sLg-i7I/AAAAAAAAQMI/EfOfvBqoD1Y/s1600/funny+Cute+Kittens+(12).jpg");
    var $thirdSlide = $($slideContainer).clone().append($heading3).append($img3);

    //slide4
    var $heading4 = $sampleHeading.clone().html("Heading 4");
    var $form3 = $("<form>").attr("name", "vonkoForm").attr("method", "get");
    var $label = $("<label>").attr("for", "name").html("Write your name, bitch: ")
    var $inputText = $("<input>").attr("type", "text").attr("id", "name");
    $form3.append($label).append($inputText);
    var $fourthSlide = $($slideContainer).clone().append($heading4).append($form3);

    //arange the slides in array

    var $slidesArray = [$firstSlide, $secondSlide, $thirdSlide, $fourthSlide];

    //append all the slides to our page
    var $dFrag = $(document.createDocumentFragment());

    for (var i = 0; i < $slidesArray.length; i++) {
        $slidesArray[i].hide().appendTo($dFrag);
    }

    $('#container').append($dFrag);

    //show the first slide and set the atuomatic slide change

    $($firstSlide).show();
    var currentI = 0;

    function $changeSlides() {
            $('.slide').hide();
            currentI = (currentI + 1) % $slidesArray.length;
            $($slidesArray[currentI]).fadeIn(1000);
    }

   	var Timer = setInterval($changeSlides, 4000);

    //implement onclich slide-change functionality
    $('#next').on('click', function() {
    	clearInterval(Timer);

    	$('.slide').hide();
        currentI = (currentI + 1) % $slidesArray.length;
        $($slidesArray[currentI]).fadeIn(1000);

        window.setTimeout(Timer = window.setInterval($changeSlides, 4000));
    });

    $('#prev').on('click', function() {
    	clearInterval(Timer);

    	$('.slide').hide();
        currentI = currentI -1;
        if (currentI < 0) {
        	currentI = 3;
        }

        $($slidesArray[currentI]).fadeIn(1000);

        window.setTimeout(Timer = window.setInterval($changeSlides, 4000));
    })
})
