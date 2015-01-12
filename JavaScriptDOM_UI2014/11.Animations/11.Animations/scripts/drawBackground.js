window.addEventListener('load', function () {

    var paper = Raphael(0, 0, 2500, 950);

    //draw the ground
    paper.rect(0, 700, paper.width, 250)
               .attr({
                   fill: '#997e03'
               })

    //the green block
    paper.rect(200, 100, 400, 600)
              .attr({
                  fill: '#47bf2e'
              });

    //the orange block

    paper.rect(400, 300, 450, 400)
               .attr({
                   fill: '#f0ae62'
               });

    //the bushes

    paper.setStart();

    paper.path('M 5 700 V 450 C 20 430 40 430 60 450 C 80 390 120 390 160 410 C 200 270 270 370 280 420 C 310 400 360 400 390 430 S 450 550 450 700');

    paper.path('M 80 700 C 100 550 180 530 230 700 ');

    paper.path('M 187 605 C 220 480 280 480 330 700');

    //the black curves on top of the bushes

    paper.path('M 20 450 Q 15 460 20 490 M 40 450 Q 35 460 40 490');
    paper.path('M 100 410 Q 95 420 100 450 M 120 410 Q 115 420 120 450');
    paper.path('M 200 360 Q 205 370 200 400 M 220 360 Q 225 370 220 400');
    paper.path('M 320 420 Q 325 430 320 460 M 340 420 Q 345 430 340 460');

    paper.path('M 130 590 Q 125 600 130 630 M 150 590 Q 145 600 150 630');

    paper.path('M 230 530 Q 225 540 230 570 M 250 530 Q 245 530 250 570');

    var bushSet = paper.setFinish();

    bushSet.attr({
        stroke: 'black',
        'stroke-width': 2,
        fill: '#72ff62'
    });

    //the jump platform with question marks
    paper.setStart();

    paper.rect(1250, 360, 100, 100);
    paper.rect(1350, 360, 100, 100);

    var jumpSet = paper.setFinish();

    jumpSet.attr({
        fill: '#e75712',
        'stroke-width': 3
    });

    //the cloud

    paper.path('M 1300 150 C 1330 110 1390 110 1410 150 C 1460 70 1520 70 1570 120 C 1700 120 1700 200 1600 250 C 1560 270 1500 270 1470 250 C 1430 280 1330 280 1300 240 C 1250 220 1250 160 1300 150')
               .attr({
                   stroke: 'none',
                   fill: 'white'
               })

    //the question marks
    paper.path('M 1280 390 C 1280 370 1310 370 1320 390 S 1290 410 1300 430')
               .attr({
                   stroke: 'white',
                   'stroke-width': 3
               });

    paper.circle(1300, 445, 4)
                .attr({
                    stroke: 'none',
                    fill: 'white'
                })

    paper.path('M 1380 390 C 1380 370 1410 370 1420 390 S 1390 410 1400 430')
               .attr({
                   stroke: 'white',
                   'stroke-width': 3
               });

    paper.circle(1400, 445, 4)
                .attr({
                    stroke: 'none',
                    fill: 'white'
                })

    //draw the pink block
    paper.rect(1800, 400, 600, 300)
               .attr({
                   fill: '#e279cf'
               })

    paper.setStart();

    paper.circle(1830, 430, 10);
    paper.circle(2370, 430, 10);
    paper.circle(1830, 670, 10);
    paper.circle(2370, 670, 10);

    var pinkBlockSet = paper.setFinish();

    pinkBlockSet.attr({
        fill: '#938891'
    })
})