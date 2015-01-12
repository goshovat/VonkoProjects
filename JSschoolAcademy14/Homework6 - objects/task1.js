document.getElementById("execute").onclick = function Execute() {

    function getPoint(x, y) {
        return { x: x, y: y };
    }


    function getLine(point1, point2) {
        return { pointA: point1, pointB: point2 };
    }

    function calculateDistance(point1, point2) {
        return parseInt(Math.abs(point1.x - point2.x) * Math.abs(point1.x - point2.x)
        + Math.abs(point1.y - point2.y) * Math.abs(point1.y - point2.y));
    }

    function IsPossibleFormingATriangle(line1, line2, line3) {
        var a = calculateDistance(line1.pointA, line1.pointB);
        var b = calculateDistance(line2.pointA, line2.pointB);
        var c = calculateDistance(line3.pointA, line3.pointB);
        if (a + b > c && a + c > b && b + c > a) {
            jsConsole.writeLine("true");
        } else {
            jsConsole.writeLine("false");
        }
    }

    var p1 = getPoint(1, 2);
    var p2 = getPoint(2, 2);
    var p3 = getPoint(3, 1);

    var l1 = getLine(p1, p2);
    var l2 = getLine(p2, p3);
    var l3 = getLine(p1, p3);

    var n = calculateDistance(p3, p2);
    jsConsole.writeLine(n);


    IsPossibleFormingATriangle(l1, l2, l3);
}

document.getElementById("reset").onclick = function Erase() {
    document.getElementById("js-console").innerHTML = "";
    document.location.reload();
}