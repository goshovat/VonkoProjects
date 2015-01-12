window.onload = function () {
    var canvas = document.getElementById('the-canvas');
    var ctx = canvas.getContext('2d');

    ctx.fillStyle = 'red';
    ctx.lineWidth = 2;

    var ballRadius = 5;

    //define function that will draw the ball every time
    function drawBall(argX, argY, argRad) {
        ctx.beginPath();
        ctx.arc(argX, argY, argRad, 0, 2 * Math.PI);
        ctx.fill();
        ctx.stroke();
    }

    var currentX = 5;
    var currentY = canvas.height/2;
    var updateX = 4;
    var updateY = 3;

    //define a function that will move the ball and will recursively call itself
    function moveBall() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        drawBall(currentX, currentY, ballRadius);

        currentX += updateX;
        if (currentX >= canvas.width - 5) {
            updateX = -4;
        }
        if (currentX <= 5) {
            updateX = 4;
        }

        currentY += updateY;
        if (currentY >= canvas.height - 5) {
            updateY = -3;
        }
        if (currentY <= 4) {
            updateY = 3;
        }

        requestAnimationFrame(moveBall);
    }

    moveBall();
}