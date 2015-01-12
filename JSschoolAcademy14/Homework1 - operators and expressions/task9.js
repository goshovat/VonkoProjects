function check() {
	var X = document.getElementById("X").value;
	var Y = document.getElementById("Y").value;
	var Xc=1;
	var Yc=1;
	var R =3;
	var Xl=1;
	var Yl =-1;
	var width = 3;
	var height = 6;
	var Xr = Xl + width;
	var Yr = Yl - height;
	if ((X - Xc)*(X-Xc)+(Y-Yc)*(Y-Yc) < R*R) {
		var inCircle = true;
	}
	else {
		var inCircle = false;
	}
	if (((X > Xl) && (X < Xr)) && ((Y < Yl) && (Y > Yr))) {
			var inRec = true;
		}
		else {
			var inRec = false;
	}
	if (inCircle === true && inRec === false) {
		jsConsole.writeLine("The condition the point to be in the circle and out of the rectangle is met");
	}
	else {
		jsConsole.writeLine("The condition the point to be in the circle and out of the rectangle is NOT met")
	}
}
