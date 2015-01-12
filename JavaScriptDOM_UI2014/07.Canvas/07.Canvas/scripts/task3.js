var lives = 5;
var score = 0;

window.onload = function startGame() {
    var pause = false;

    //first we prepare the canvas element
    var canvas = document.createElement("canvas");
    var body = document.getElementsByTagName("body")[0];

    canvas.width = 1000;
    canvas.height = 600;
    canvas.style.border = "1px solid black";

    //now we prepare the score div
    var dataDiv = document.createElement("div");
    dataDiv.style.textAlign = "center";
    dataDiv.style.fontSize = "18 + px";
    dataDiv.style.fontFamily = "Segoe UI";
    dataDiv.style.width = "1000 + spx";
    dataDiv.innerHTML = "lives: " + lives +"&nbsp;&nbsp;&nbsp;score: " + score;

    //remove the 'Snake Crashed' Element before the game is restarted

    function removeChildren() {
        var child = body.firstChild;
        while (child) {
            body.removeChild(child);
            child = body.firstChild;
        }
    }
    removeChildren();

    //now we append the canvas and dataDiv to the body
    body.appendChild(canvas);
    body.appendChild(dataDiv);

    var ctx = canvas.getContext("2d");

    //we calculate a random start position for the snake
    var tailX = (Math.random() * 650 + 196) | 0;
    if (tailX % 4 != 0) {

        for (var i = 0; i < 3; i++) {
            tailX++;

            if (tailX % 4 == 0) {
                break;
            }
        };
    } 
   
    var tailY = (Math.random() * 596) | 0;
    if (tailY % 4 != 0) {
        
        for (var i = 0; i < 3; i++) {
            tailY++;

            if (tailY %  4 == 0) {
                tailY++;
                break;
            }
        };
    }

    var oldDirection = "right";
    var newDirection = "right";

    //we implement function to change snake's direction by keypress
    window.onkeydown = function(event) {
        var pressedKey = event.keyCode;

        var leftArrow = 37;
        var upArrow = 38;
        var rightArrow = 39;
        var downArrow = 40;

        oldDirection = newDirection;

        if (pressedKey === leftArrow) {
            newDirection = "left";
        } else if (pressedKey == upArrow) {
            newDirection = "up";
        } else if (pressedKey === rightArrow) {
            newDirection = "right";
        } else if (pressedKey == downArrow) {
            newDirection = "down";
        }
    }

    var positionsArr = [{x : tailX, y : tailY}];
    var snakeLength = 50;

    //this function will draw the snnake initially and throughoout the game
    function drawSnake(argPositionsArr) {
        for (var i = 0; i < argPositionsArr.length; i++) {
            ctx.fillStyle = "black";

            ctx.beginPath();
            ctx.arc(argPositionsArr[i].x, argPositionsArr[i].y, 2, 0, 2 * Math.PI);
            ctx.fill();
        };
    }

    //this function will initially draw our snake
    function initialDrawSnake() {
        for (var i = 1; i < snakeLength; i++) {
            positionsArr.push({x: tailX + i, y: tailY})
        };

        drawSnake(positionsArr);
    };
    initialDrawSnake();

    var currentColorNumber;
    var currentColor;
    var currentFoodX;
    var currentFoodY;

    //this function calculates the position and color of the new piece of food
    function generateFoodProps() {
        var colorsArr = ["", "blue", "red", "green", "brown", "gray"];
        currentColorNumber = (Math.random() * 5) | 0;
        currentColor = colorsArr[currentColorNumber];

        currentFoodX = (Math.random() * 996) | 0;
        currentFoodY = (Math.random() * 596) | 0;
    }
    generateFoodProps();

    function crash() {
        pause = true;

        removeChildren();

        var newDiv = document.createElement("div");
        newDiv.style.textAlign = "center";
        newDiv.style.fontSize = "48px";
        newDiv.style.fontFamily = "Segoe UI";
        newDiv.style.position = "relative";
        newDiv.style.top = "300px";
        newDiv.innerHTML = "Your snake crashed!";      

        if (lives > 0) {
            body.appendChild(newDiv);
            lives--;
            setTimeout(startGame, 2000);
        } else {
            newDiv.innerHTML = "Game Over!";
            body.appendChild(newDiv);
        }
    }

    //now we twist the snake
    function moveSnake(argOldDirection, argNewDirection) {
        var headX = positionsArr[positionsArr.length - 1].x;
        var headY = positionsArr[positionsArr.length - 1].y;

        if (headX > 2 && headX <= 997 && headY > 0 && headY <= 598) {

            if (argNewDirection == "left") {

                if (oldDirection != "right") {
                    positionsArr.shift()
                    positionsArr.push({x: headX - 1, y: headY});
                } else {
                    newDirection = "right";
                    positionsArr.shift();
                    positionsArr.push({x: headX + 1, y: headY});
                }

            } else if (argNewDirection == "up") {

                if (argOldDirection != "down") {
                    positionsArr.shift();
                    positionsArr.push({x : headX, y : headY - 1});
                } else {
                    newDirection = "down";
                    positionsArr.shift();
                    positionsArr.push({x : headX, y : headY + 1});
                }

            } else if (argNewDirection == "right") {

                if (argOldDirection != "left") {
                    positionsArr.shift();
                    positionsArr.push({x : headX + 1, y : headY});
                } else {
                    newDirection = "left";
                    positionsArr.shift();
                    positionsArr.push({x : headX - 1, y : headY});
                }

            } else if (argNewDirection == "down") {

                if (argOldDirection != "up") {
                    positionsArr.shift();
                    positionsArr.push({x : headX, y : headY + 1});
                } else {
                    newDirection = "up";
                    positionsArr.shift();
                    positionsArr.push({x : headX, y : headY - 1});
                }

            };

            
            drawSnake(positionsArr);

            //
            ctx.fillStyle = currentColor;
            ctx.beginPath();
            ctx.arc(currentFoodX, currentFoodY, 2, 0, 2*Math.PI);
            ctx.fill();

            //here we make the snake longer when it eats some food
            if (currentFoodX - 2 < headX + 2 && currentFoodX+2 > headX - 2 &&
                currentFoodY - 2 < headY + 2 && currentFoodY+2 > headY - 2) {

                if (argNewDirection == "left") {
                    for (var i = 0; i <7; i++) {
                        positionsArr.push({x : headX - 1, y : headY});
                    };
                } else if (argNewDirection == "up") {
                     for (var i = 0; i <7; i++) {
                        positionsArr.push({x : headX, y : headY - 1});
                    };
                  
                } else if (argNewDirection == "right") {
                    for (var i = 0; i <7; i++) {
                        positionsArr.push({x : headX + 1, y : headY});
                    };    
                } else if (argNewDirection == "down") {
                     for (var i = 0; i <7; i++) {
                        positionsArr.push({x : headX, y : headY + 1});
                    }; 
                }

                score += 5;
                generateFoodProps();
                dataDiv.innerHTML = "lives: " + lives + "&nbsp;&nbsp;&nbsp;score: " + score;
                body.removeChild(dataDiv);
                body.appendChild(dataDiv);
            }

            
        //here we will implement the snake to crash if it eats itself
        for (var i = 0; i < snakeLength-4; i++ ) {
            var currentSnakeX = positionsArr[i].x;
            var currentSnakeY = positionsArr[i].y;

            if (currentSnakeX == headX && headY == currentSnakeY) {
                crash();
            }
        };

        } else {
            crash();
        }
    }

    //this function runs the game animation
    function gamePlay() {
        ctx.clearRect(0, 0, 1000, 600);

        moveSnake(oldDirection, newDirection);

        if (!pause) {
            requestAnimationFrame(gamePlay);
        }
    }

    gamePlay();
}
