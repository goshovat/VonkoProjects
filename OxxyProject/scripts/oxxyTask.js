window.addEventListener("load", function() {

    /*store our body in one variable so it is easier to 
    append elements later*/
    var bodyEl = document.getElementsByTagName("body")[0];

    /*create this container div in order to put the dinamically 
    generated buttons and textfields inside it*/
    var containerDiv = document.createElement("div");
    containerDiv.style.display = "block";
    containerDiv.style.boxShadow = "none";

    //create the toolbar object
    var toolbarObj = document.createElement("div");

    var toolbarButton1 = document.createElement("button");
    toolbarButton1.innerHTML = "Create Button";

    //this is the function that will render the button
    toolbarButton1.addEventListener('click', function() {
        var newButton = new ButtonTemplate();
        containerDiv.appendChild(newButton);
    })

    var toolbarButton2 = document.createElement("button");
    toolbarButton2.innerHTML = "Create Textfield";

    //this is the function that will render the text-field
    toolbarButton2.addEventListener('click', function() {
        var newTextField = new TextFieldTemplate();
        containerDiv.appendChild(newTextField);
    })

    toolbarObj.appendChild(toolbarButton1);
    toolbarObj.appendChild(toolbarButton2);

    //make the toolbar draggable
    $(function() {
        $(toolbarObj).draggable();
    });

    bodyEl.appendChild(toolbarObj);
    bodyEl.appendChild(containerDiv);

    //we create our color-picker object
    var colorPicker = document.createElement("input");
    colorPicker.type = "color";

    //create color picker div in order to make the color-picker draggable
    var colorPickerDiv = document.createElement("div");
    colorPickerDiv.style.border = "1px solid blue";
    colorPickerDiv.style.padding = "5px 10px";
    colorPickerDiv.id = "colorPickerDiv";

    //make the color-picker draggable
    $(function() {
        $(colorPickerDiv).draggable();
    });

    //imitate class to create the button
    var ButtonTemplate = function ButtonTemplate() {

        //create the component elements of our button class
        var link = document.createElement("a");
        link.innerHTML = "Element Button";
        var bgDiv = document.createElement("div");

        /*in this variable is stored the initial background of our button div*/
        var bgColor = getRandomColor();
        bgDiv.style.background = bgColor;

        //set the initial value of our color picker
        colorPicker.value = bgColor;

        //add double click event to show the color picker
        link.addEventListener('dblclick', function() {
            var parrentDiv = this.parentElement;
            parrentDiv.classList.add("current");

            var currentBgColor = parrentDiv.style.background;

            //we convert this value to hex so the input will accept it
            currentBgColor = rgbToHex(currentBgColor);

            colorPicker.value = currentBgColor;

            /*we attach the function that will change the background of our div
            when a new color is picked*/
            colorPicker.addEventListener('input', changeBgColor);

            colorPickerDiv.appendChild(colorPicker);
            bodyEl.appendChild(colorPickerDiv);
        });

        bgDiv.classList.add("button-background");

        bgDiv.appendChild(link);

        var buttonClass = bgDiv;

        $(function() {
            $(buttonClass).draggable();
        });

        return buttonClass;
    }


    //immitate class tho create text-field
    var TextFieldTemplate = function ТextFieldTemplate() {

        var textFieldClass = document.createElement("div");
        textFieldClass.classList.add("textfield");

        var bgColor = getRandomColor();
        textFieldClass.style.background = bgColor;
        textFieldClass.innerHTML = "I'm a dinamically created textfield and I can change my background color :)";

        textFieldClass.addEventListener('dblclick', function() {
            this.classList.add("current");

            var currentBgColor = textFieldClass.style.background;

            currentBgColor = rgbToHex(currentBgColor);

            colorPicker.value = currentBgColor;

            colorPicker.addEventListener("input", changeBgColor);

            colorPickerDiv.appendChild(colorPicker);
            bodyEl.appendChild(colorPickerDiv);
        });

        //make the textfield draggable
        $(function() {
            $(textFieldClass).draggable();
        });

        return textFieldClass;
    }


    /*this function changes the background of our element when we pick new color
        from the color picker*/

        function changeBgColor() {
            bgColor = this.value;
            var selectedEl = document.getElementsByClassName("current")[0];
            selectedEl.style.background = bgColor;
            bodyEl.removeChild(colorPickerDiv);
            selectedEl.classList.remove("current");

            return bgColor;
        }

        //we add this function to generate random initial color for our buttons and textfields

        function getRandomColor() {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            for (var i = 0; i < 6; i++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
            return color;
        }

        //we add this function to convert rgba to hex colors

        function rgbToHex(color) {
            if (color.substr(0, 1) === "#") {
                return color;
            }
            var nums = /(.*?)rgb\((\d+),\s*(\d+),\s*(\d+)\)/i.exec(color),
                r = parseInt(nums[2], 10).toString(16),
                g = parseInt(nums[3], 10).toString(16),
                b = parseInt(nums[4], 10).toString(16);
            return "#" + (
                (r.length == 1 ? "0" + r : r) +
                (g.length == 1 ? "0" + g : g) +
                (b.length == 1 ? "0" + b : b)
            );
        }
});
