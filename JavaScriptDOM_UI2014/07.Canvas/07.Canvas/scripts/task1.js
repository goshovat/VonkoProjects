window.onload = function () {
    var canvas = document.getElementById('the-canvas');

    var ctx = canvas.getContext('2d');

    //draw the man with the hat

    //draw the face
    ctx.fillStyle = '#90cad7';
    ctx.strokeStyle = '#337d8f';
    ctx.save();

    ctx.scale(1, 0.9);

    ctx.beginPath();
    ctx.arc(150, 270, 85, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();


    //draw the eyes

    ctx.scale(1, 0.7);
    ctx.lineWidth = 3;

    ctx.beginPath();
    ctx.arc(95, 360, 13, 0, 2 * Math.PI);
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(165, 360, 13, 0, 2 * Math.PI);
    ctx.stroke();

    ctx.restore();
    ctx.save();

    //draw the eyeballs
    ctx.scale(0.6, 1);
    ctx.fillStyle = '#337d8f';

    ctx.beginPath();
    ctx.arc(153, 227, 8, 0, 2 * Math.PI);
    ctx.fill();

    ctx.beginPath();
    ctx.arc(270, 227, 6, 0, 2 * Math.PI);
    ctx.fill();

    ctx.restore();
    ctx.save();

    //draw the nose
    ctx.lineWidth = 3;
    ctx.moveTo(129, 230);
    ctx.lineTo(110, 270);
    ctx.lineTo(129, 270);
    ctx.stroke();

    //draw the mouth

    ctx.lineWidth = 4;

    ctx.beginPath();
    ctx.rotate(6 * Math.PI / 180);
    ctx.scale(1, 0.30);
    ctx.arc(160, 915, 30, 0, 2 * Math.PI);
    ctx.stroke();

    //draw the hat
    ctx.restore();
    ctx.fillStyle = '#396693';
    ctx.strokeStyle = 'black';
    ctx.save();

    //draw the bottom of the hat
    ctx.scale(1, 0.2);
    ctx.lineWidth = 2;

    ctx.beginPath();
    ctx.arc(140, 920, 100, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.restore();
    ctx.save();

    //draw the top of the hat
    ctx.scale(1, 0.4)

    ctx.beginPath();
    ctx.arc(150, 120, 60, 0, 2 * Math.PI);
    ctx.fill();
    ctx.moveTo(210, 120);
    ctx.lineTo(210, 420);
    ctx.lineTo(90, 420);
    ctx.lineTo(90, 120);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(150, 420, 60, 0, 2 * Math.PI);
    ctx.fill();

    ctx.beginPath();
    ctx.arc(150, 420, 60, 0, Math.PI);
    ctx.stroke();

    //........................................................................................................
    //........................................................................................................
    //draw the bicycle

    ctx.restore();

    ctx.fillStyle = '#90cad7';
    ctx.strokeStyle = '#337d8f';

    ctx.save();
    ctx.lineWidth = 2;

    //draw the wheels
    ctx.beginPath();
    ctx.arc(250, 750, 100, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(650, 750, 100, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    //draw the pedals
    ctx.beginPath();
    ctx.arc(425, 750, 23, 0, 2 * Math.PI);
    ctx.moveTo(410, 732);
    ctx.lineTo(395, 710);
    ctx.moveTo(436, 770);
    ctx.lineTo(451, 792)
    ctx.stroke();

    //draw the frame
    ctx.beginPath();
    ctx.moveTo(425, 750);
    ctx.lineTo(250, 750);
    ctx.lineTo(380, 600);
    ctx.lineTo(620, 600);
    ctx.closePath();
    ctx.lineTo(363, 560);

    //draw the seat
    ctx.lineTo(320, 560);
    ctx.lineTo(409, 560);
    ctx.stroke();

    //draw the control wheel
    ctx.moveTo(650, 750);
    ctx.lineTo(609, 533);
    ctx.lineTo(539, 558);
    ctx.moveTo(609, 533);
    ctx.lineTo(669, 493);
    ctx.stroke();

    //...............................................................................................................
    //...............................................................................................................
    //draw the house

    ctx.lineWidth = 3;
    ctx.save();

    //draw the frame and the roof
    ctx.strokeStyle = 'black';
    ctx.fillStyle = '#975b5b';

    ctx.save();

    ctx.beginPath();
    ctx.rect(1050, 400, 500, 400);
    ctx.lineTo(1300, 100);
    ctx.lineTo(1550, 400);
    ctx.fill();
    ctx.stroke();

    //draw the chimney

    ctx.beginPath();
    ctx.moveTo(1410, 182);
    ctx.lineTo(1410, 330);

    ctx.lineTo(1460, 330);
    ctx.lineTo(1460, 182);
    ctx.fill();
    ctx.stroke();

    ctx.lineWidth = 5;

    ctx.beginPath();
    ctx.scale(1, 0.3);
    ctx.arc(1435, 610, 25, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.restore();
    ctx.save();

    ctx.beginPath();

    ctx.lineWidth = 6;

    ctx.moveTo(1462, 330);
    ctx.strokeStyle = '#975b5b';
    ctx.lineTo(1408, 330);
    ctx.stroke();

    //draw the windows
    ctx.lineWidth = 5;
    ctx.fillStyle = 'black';

    ctx.beginPath();
    ctx.rect(1080, 430, 180, 130);
    ctx.moveTo(1170, 430);
    ctx.lineTo(1170, 560);
    ctx.moveTo(1080, 495);
    ctx.lineTo(1360, 495);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.rect(1330, 430, 180, 130);
    ctx.moveTo(1420, 430);
    ctx.lineTo(1420, 560);
    ctx.moveTo(1330, 495);
    ctx.lineTo(1510, 495);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.rect(1330, 600, 180, 130);
    ctx.moveTo(1420, 500);
    ctx.lineTo(1420, 730);
    ctx.moveTo(1330, 665);
    ctx.lineTo(1510, 665);
    ctx.fill();
    ctx.stroke();

    //draw the door
    
    ctx.strokeStyle = 'black';
    ctx.fillStyle = '#975b5b';
    ctx.lineWidth = 4;
    ctx.lineJoin = 'round';

    ctx.beginPath();   
    ctx.moveTo(1100, 800);
    ctx.lineTo(1100, 640);
    ctx.bezierCurveTo(1130, 600, 1210, 600, 1240, 640);
    ctx.lineTo(1240, 800);
    ctx.stroke();

    ctx.beginPath();
    ctx.moveTo(1170, 800);
    ctx.lineTo(1170, 610);
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(1150, 735, 7, 0, 2 * Math.PI);
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(1190, 735, 7, 0, 2 * Math.PI);
    ctx.stroke();
}