function execute() {

    var input0 = document.getElementById('input0').value;
    var input1 = document.getElementById('input1').value;
    var input2 = document.getElementById('input2').value;
    var input3 = document.getElementById('input3').value;
    var input4 = document.getElementById('input4').value;
    var input5 = document.getElementById('input5').value;
    var input6 = document.getElementById('input6').value;
    var input7 = document.getElementById('input7').value;
    var input8 = document.getElementById('input8').value;
    var input9 = document.getElementById('input9').value;
    var input10 = document.getElementById('input10').value;
    var input11 = document.getElementById('input11').value;

    if (input0 && input1 && input2 && input3 && input4 && input5 &&
        input6 && input7 && input8 && input9 && input10 && input11) {
        var output = ' ';

        if (isNaN(input0) || isNaN(input1) || isNaN(input2) || isNaN(input3) || isNaN(input4)
            || isNaN(input5) || isNaN(input6) || isNaN(input7) || isNaN(input8)
            || isNaN(input9) || isNaN(input10) || isNaN(input11)) {

            output = 'Please enter valid numbers!';
        }
        else {

            var lineConstructor = function lineConstructor(arg0, arg1, arg2, arg3) {

                return {
                    point1: {
                        x: arg0,
                        y: arg1
                    },

                    point2: {
                        x: arg2,
                        y: arg3
                    },

                    calculateLine: function () {
                        return (Math.sqrt(Math.abs(this.point1.x - this.point2.x) * Math.abs(this.point1.x - this.point2.x) +
                                          Math.abs(this.point1.y - this.point2.y) * Math.abs(this.point1.y - this.point2.y)));
                    }
                }

            }

            var line1 = lineConstructor(parseFloat(input0), parseFloat(input1), parseFloat(input2), parseFloat(input3));
            var line2 = lineConstructor(parseFloat(input4), parseFloat(input5), parseFloat(input6), parseFloat(input7));
            var line3 = lineConstructor(parseFloat(input8), parseFloat(input9), parseFloat(input10), parseFloat(input11));

            var line1Length = (line1.calculateLine());
            var line2Length = (line2.calculateLine());
            var line3Length = (line3.calculateLine());

            var canFormTriangle;

            if ((line1Length < line2Length + line3Length) && 
                (line2Length < line1Length + line3Length) && 
                (line3Length < line1Length + line2Length)) {

                canFormTriangle = true;
            }
            else {
                canFormTriangle = false;
            }

            output = 'Line 1: ' + line1Length.toFixed(2) + '<br/>' +
                     'Line 2: ' + line2Length.toFixed(2) + '<br/>' +
                     'Line 3: ' + line3Length.toFixed(2) + '<br/>' +
                     'They can form triangle: ' + canFormTriangle;

        }

        document.getElementById('output').innerHTML = output;
    }

}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;