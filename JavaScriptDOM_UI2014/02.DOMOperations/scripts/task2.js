//first we create our function to create the divs
var horizontalPos = [105, 235, 365, 305, 165];
var verticalPos = [300, 160, 300, 450, 450];
var divsCount = 5;

function createDivs() {
    var divTemplate = document.createElement('div');
    divTemplate.classList.add('divsToRotate');
    divTemplate.style.display = 'ínline-block';
    divTemplate.style.position = 'absolute';
    divTemplate.style.fontSize = '24px';
    divTemplate.style.fontFamily = 'Segoe UI';
    divTemplate.style.padding = "10px 15px";
    divTemplate.style.borderRadius = '10px';

    var dFrag = document.createDocumentFragment();

    for (var i = 0; i < divsCount; i++) {
        divTemplate.innerHTML = 'div ' + (i + 1);
        divTemplate.style.left = horizontalPos[i] + 'px';
        divTemplate.style.top = verticalPos[i] + 'px';
        divTemplate.style.color = generateRandomColor();
        divTemplate.style.border = "1px inset " + generateRandomColor();
        divTemplate.style.background = generateRandomColor();
        dFrag.appendChild(divTemplate.cloneNode(true));
    };

    document.body.appendChild(dFrag);
}

//create a function that generates random number

function generateRandomNumber(argFrom, argTo) {
    var randomNumber = (Math.random() * (argTo - argFrom) + argFrom) | 0;
    return randomNumber;
}

//create a function that generates random color

function generateRandomColor() {
    var randomColor = 'rgb(';
    for (var i = 0; i < 3; i++) {
        if (i < 2) {
            randomColor += generateRandomNumber(0, 255) + ', ';
        } else {
            randomColor += generateRandomNumber(0, 255);
        }
    };
    randomColor += ')';
    return randomColor;
}

window.onload = function() {
    //call the function to create the divs
    createDivs();

    var isRunning = true;

    var startBtn = document.getElementById('execute');
    var stopBtn = document.getElementById('stop');

    //attach event to start the rotation
    startBtn.addEventListener('click', function() {
        isRunning = true;
        var j = 0;
        var divs = document.getElementsByClassName('divsToRotate');

        function rotateDivs() {
            j = (j + 1) % divsCount;

            for (var i = 0; i < divsCount; i++) {
                divs[i].style.top = verticalPos[(i + j) % divsCount] + 'px';
                divs[i].style.left = horizontalPos[(i + j) % divsCount] + 'px';
            };

            if (isRunning) {
                window.setTimeout(rotateDivs, 200);
            }

        }
        rotateDivs();
    });

    //attach event to stop the rotation
    stopBtn.addEventListener('click', function() {
        isRunning = false;
    })
}
