window.addEventListener('load', function () {

    var paper = Raphael(0, 0, 1000, 800);

    //draw the trajectory
    var angle, x, y;
    var positionsArr = [];

    for (var i = 0; i < 1801; i += 1) {
        angle = 0.02 * i;
        y = 400 - (4 + i / 5 + angle) * Math.cos(angle);
        x = 400 - (4 + i / 5 + angle) * Math.sin(angle);

        positionsArr.push({ x: x, y: y });

        paper.circle(positionsArr[i].x, positionsArr[i].y, 1)
                     .attr({
                         fill: 'black',
                         stroke: 'none'
                     });
    }

    x = 0; y = 0; angle = 0; i = 0;

    //animation
    var innerTimer, outterTimer, update = 3;

    var movingCircle = paper.circle(positionsArr[i].x, positionsArr[i].y, 5)
                 .attr({
                    fill: 'red'
                 });

    function animation() {
        i += update;

        if (i >= 1800) {
            update = -3;
        }
        if (i <= 0) {
            update = 3;
        }

        movingCircle.attr({
            cx: positionsArr[i].x,
            cy: positionsArr[i].y
        })

        requestAnimationFrame(animation);
    };
    animation();
})