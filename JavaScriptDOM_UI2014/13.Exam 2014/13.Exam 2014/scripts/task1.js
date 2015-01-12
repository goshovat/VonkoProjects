function createImagesPreviewer(argSelector, argDataObject) {

    //store the container in a variable
    var container = document.querySelectorAll(argSelector)[0];
    container.style.clear = 'both';
    container.style.padding = '0 40px 0 40px';
    container.style.width = '1800px';
  
    //create and append the filter box
    var filterBoxContainer = document.createElement('div');
    filterBoxContainer.style.float = 'right';
    filterBoxContainer.style.position = 'relative';
    filterBoxContainer.style.right = '20px';
    filterBoxContainer.style.width = '16%';
    filterBoxContainer.style.textAlign = 'center';

    var filterBoxLabel = document.createElement('label');
    filterBoxLabel.innerHTML = 'Filter';
    filterBoxLabel.style.fontSize = '35px';
    filterBoxLabel.setAttribute('for', 'filter-box');

    var filterBox = document.createElement('input');
    filterBox.setAttribute('type', 'text');
    filterBox.setAttribute('id', 'filter-box');
    filterBox.style.width = '100%';
    filterBox.style.fontSize = '25px';
    filterBox.style.padding = '5px 10px';

    filterBoxContainer.appendChild(filterBoxLabel);
    filterBoxContainer.appendChild(filterBox);

    container.appendChild(filterBoxContainer);

    //create the right-sided list
    var sideList = document.createElement('ul');
    sideList.style.float = 'right';
    sideList.style.clear = 'both';
    sideList.style.width = '17%';
    sideList.style.listStyleType = 'none';

    //create a template for the right-sided images
    var sideLITemplate = document.createElement('li');
    sideLITemplate.setAttribute('class', 'side-image');
    sideLITemplate.style.marginBottom = '30px';
    sideLITemplate.style.padding = '0 20px 20px 20px';
    sideLITemplate.style.borderRadius = '10px';
    sideLITemplate.style.cursor = 'pointer';

    var imageTitleTemplate = document.createElement('h1');
    imageTitleTemplate.style.textAlign = 'center';
    imageTitleTemplate.style.margin = '0';

    var imageTemplate = document.createElement('img');
    imageTemplate.style.display = 'block';
    imageTemplate.style.width = '100%';
    imageTemplate.style.height = '200px';
    imageTemplate.style.borderRadius = '15px';
    
    sideLITemplate.appendChild(imageTitleTemplate);
    sideLITemplate.appendChild(imageTemplate);

    //the div that we'll show the selected picture in
    var selectedContainer = document.createElement('div');
    selectedContainer.setAttribute('id', 'selected-container');
    selectedContainer.style.textAlign = 'center';
    selectedContainer.style.float = 'left';
    selectedContainer.style.width = '70%';

    //define function to clears the selectedContainer every time when new picture selected
    function removeChildren(argContainer) {
        var child = argContainer.firstChild;

        while (child) {
            argContainer.removeChild(child);
            child = argContainer.firstChild;
        }
    }

    //define function that changes the selected picture
    function showSelectedPicture(argImgLI) {
        removeChildren(selectedContainer);

        argImgLI.classList.add('selected');

        var selectedTitle = argImgLI.firstChild.cloneNode(true);
        selectedTitle.style.fontSize = '60px';
        selectedTitle.style.marginTop = '50px';

        var selectedImage = argImgLI.lastChild.cloneNode(true);
        selectedImage.style.display = 'inline';
        selectedImage.style.width = '60%';
        selectedImage.style.height = '520px';
        selectedImage.style.marginTop = '50px';
        selectedImage.style.borderRadius = '30px';

        selectedContainer.appendChild(selectedTitle);
        selectedContainer.appendChild(selectedImage);

        container.appendChild(selectedContainer);

        return selectedImage;
    }

    //create dynamically the side list using the data from the object

    for (var imgNum = 0; imgNum < argDataObject.length; imgNum++) {
        var currentLI = sideLITemplate.cloneNode(true);

        currentLI.firstChild.innerHTML = animals[imgNum].title;

        currentLI.lastChild.setAttribute('src', animals[imgNum].url);

        //attach event for hover
        currentLI.addEventListener('mouseover', function () {
            this.style.background = 'gray';
        });

        currentLI.addEventListener('mouseout', function () {
            this.style.background = '';
        });

        //attach event to change selected image
        currentLI.addEventListener('click', function () {
            showSelectedPicture(this);
        });

        sideList.appendChild(currentLI);
    }

    //append the side-list to the DOM
    container.appendChild(sideList);

    //initially make the first picture selected
    showSelectedPicture(document.querySelectorAll('.side-image')[0]);

    //add event to filter the iamges on filter-box input
    filterBox.addEventListener('input', function () {
        var sideImages = document.querySelectorAll(argSelector + ' .side-image');

        var subString = this.value.toLowerCase();

        for (var i = 0, len = sideImages.length; i < len; i++) {
            sideImages[i].style.display = 'none';
            if (sideImages[i].firstChild.innerHTML.toLowerCase().indexOf(subString) > -1) {
                sideImages[i].style.display = '';
            }
        }
    })

    //clear the container from collapsing

    //this hack creates some stylesheet linked to the document
    var addRule = (function (style) {
        var sheet = document.head.appendChild(style).sheet;
        return function (selector, css) {
            var propText = Object.keys(css).map(function (p) {
                return p + ":" + css[p]
            }).join(";");
            sheet.insertRule(selector + "{" + propText + "}", sheet.cssRules.length);
        }
    })(document.createElement("style"));

    addRule("#container", {
        display: "block",
    });

    //give the clearfix styles
    document.styleSheets[0].insertRule('#container:after { display: block; height: 0; clear: both; content: ""; }', 0);

}