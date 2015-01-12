window.addEventListener('load', function () {
    
    //get the svg namespace
    var svgNS = 'http://www.w3.org/2000/svg';

    //create and append the svg element
    var svg = document.createElementNS(svgNS, 'svg');
    svg.setAttribute('width', 1000);
    svg.setAttribute('height', 900);
    svg.setAttribute('style', 'border:1px solid black');
    document.getElementsByTagName('body')[0].appendChild(svg);

    //define function for creating circles
    function createCircle(argCX, argCY, argR, argFill) {
        var circle = document.createElementNS(svgNS, 'circle');
        circle.setAttribute('cx', argCX);
        circle.setAttribute('cy', argCY);
        circle.setAttribute('r', argR);
        circle.setAttribute('fill', argFill);

        svg.appendChild(circle);

        return circle;
    }

    //define function for creating paths
    function createPath(argD, argFill, argStroke, argStrokeWidth) {
        var path = document.createElementNS(svgNS, 'path');

        path.setAttribute('d', argD);
        path.setAttribute('fill', argFill);

        if (argStroke) {
            path.setAttribute('stroke', argStroke);
        }
        
        if (argStrokeWidth) {
            path.setAttribute('stroke-width', argStrokeWidth);
        }

        svg.appendChild(path);

        return path;
    }

    //define function for creating text
    function createText(argText, argX, argY, argFill, argFontFamily, argFontSize, argFontWeight) {
        var text = document.createElementNS(svgNS, 'text');
        
        text.innerHTML = argText;
        text.setAttribute('x', argX);
        text.setAttribute('y', argY);
        text.setAttribute('fill', argFill);
        text.setAttribute('font-family', argFontFamily);
        text.setAttribute('font-size', argFontSize);

        if (argFontWeight) {
            text.setAttribute('font-weight', argFontWeight);
        }

        svg.appendChild(text);

        return text;
    }

    //create the first circle
    createCircle(700, 200, 150, '#3e3f37');
    createPath("M 700 120 C 635 185 625 280 700 300", "#5eb14a");
    createPath("M 700 120 C 765 185 775 280 700 300", "#449644");

    //create the second circle
    createCircle(700, 370, 150, "#282827");
    createText('express', 575, 392, 'white', 'Arial', 70);

    //create third circle
    createCircle(700, 540, 150, '#e23337');
    createPath("M 700 460 L 785 500 L 765 620 L 700 620", "#b63032");
    createPath("M 700 460 L 615 500 L 635 620 H 765 L 785 500 z", "none", "#b3b3b3", 8);
    createPath("M 700 476 L 645 620 H 665 L 700 520 Z", "#f1f0f0");
    createPath("M 700 476 L 755 620 H 735 L 700 520", "#b3b3b3");

    //fourth circle
    createCircle(700, 710, 150, "#8ec74e");

    //first letter
    createPath("M 580 730 V 690 L 604 676 L 628 690 V 730 L 612 722 V 700 Q 604 690 595 700 V 722 z",
        "#47493f");

    //second letter
    createPath("M 644 690 L 668 676 L 692 690 V 720 L 668 734 L 644 720", "white");

    //third letter
    createPath("M 708 690 L 732 676 L 756 690 V 720 L 732 734 L 708 720", "#47493f");
    createCircle(732, 705, 8, "#8ec74e");
    createPath("M 756 690 V 655 L 740 645 V 695", "#47493f");

    //fourth letter
    createPath("M 772 690 L 796 676 L 820 690 V 720 L 796 734 L 772 720", "#47493f");
    createCircle(796, 705, 8, "#8ec74e");
    createCircle(796, 705, 7, 'white');
    createPath("M 796 712 L 820 726 V 700", "#8ec74e");

    //create the side text
    createText('M', 400, 230, "#3e3f37", 'Arial', 98, 'bold');

    createText('E', 408, 412, "#231f20", 'Arial', 98, 'bold');

    createText('A', 408, 585, "#e23337", 'Arial', 98, 'bold');

    createText('N', 408, 750, "#8ec74e", 'Arial', 98, 'bold');
})