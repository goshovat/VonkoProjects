window.addEventListener('load', function () {

    var stage = new Kinetic.Stage({
        container: 'kinetic-container',
        width: 2500,
        height: 950
    });

    var layer = new Kinetic.Layer();

    var marioImg = new Image();

    marioImg.addEventListener('load', function () {
        var mario = new Kinetic.Sprite({
            x: 200,
            y: 590,
            image: marioImg,
            animation: 'idle',
            animations: {
                idle: [
                    688, 155, 88, 119
                ],
                move: [
                     // x, y, width, height
                     10, 290, 75, 120,
                     85, 290, 75, 120,
                     175, 290, 75, 120,
                     255, 290, 75, 120,
                     335, 290, 75, 120,
                     405, 290, 75, 120,
                     480, 290, 75, 120,
                     570, 290, 75, 120,
                     665, 290, 75, 120,
                     745, 290, 75, 120
                ]
            },
            frameRate: 8,
            frameIndex: 0
        });

        layer.add(mario);
        stage.add(layer);
        mario.start();

        var frameCount = 0;

        mario.on('frameIndexChange', function (event) {
            if (mario.animation() == 'move' && ++frameCount > 8) {
                mario.animation('idle');
                mario.scaleX(1);
                frameCount = 0;
            }
        });

        window.addEventListener('keydown', onKeyDown);
        window.addEventListener('keyup', onKeyUp);

        function moveLeft() {
            mario.setX(mario.attrs.x -= 10);
            mario.scaleX(-1);
            mario.attrs.animation = 'move';
        }

        function moveRight() {
            mario.setX(mario.attrs.x += 10);
            mario.scaleX(1);
            mario.attrs.animation = 'move';
        }

        function stop(pos) {
            mario.setX(mario.attrs.x = pos);
            mario.attrs.animation = 'idle';
            mario.scaleX(1);
        }

        var left = 37;
        var right = 39;

        function onKeyDown(event) {
            switch (event.keyCode) {
                case left:
                    if (mario.attrs.x > 50) {
                        moveLeft();
                    } else {
                        stop(30);
                    }
                    break;

                case right:
                    if (mario.attrs.x < 2430) {
                        moveRight();
                    } else {
                        stop(2430);
                    }
                    break;
            }
        };

        function onKeyUp(event) {
            if (event.keyCode == left) {
                mario.setX(mario.attrs.x -= 40);
                mario.scaleX(1);
                mario.attrs.animation = 'idle';
            }
        };

    });
   
    marioImg.src = 'imgs/SuperMarioRight.png';

    //define functions that move mario

   

   
});