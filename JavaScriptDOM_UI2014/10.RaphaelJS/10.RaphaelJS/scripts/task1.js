window.addEventListener('load', function () {
    var paper = Raphael(0, 0, 1000, 900);

    //----------------------------------------------------------------------------------------------------------------
    //create the telerik logo

    //container
    var rect = paper.rect(0, 0, 850, 350, 2)
                    .attr({
                        stroke: '#e0ffa3',
                        fill: '#ffffff',
                        'stroke-width': 6,
                        rx: 15,
                        ry: 15
                    });

    var rect = paper.rect(4, 4, 844, 344, 2)
                   .attr({
                       stroke: '#a1a1a1',
                       'stroke-width': 1,
                       rx: 15,
                       ry: 15
                   });

    //the logo
    var path = paper.path('M 40 80 L 80 40 L 125 80 L 170 40 L 210 80 L 200 90 L 170 60 L 130 95 H 120 L 80 60 L 50 90')
                        .attr({
                            fill: '#5ce600',
                            stroke: 'none'
                        })

    paper.setStart();

    var rect = paper.rect(120, 85, 85, 85)
                    .attr({
                        fill: '#5ce600',
                        stroke: 'none'
                    })

    var rect = paper.rect(135, 100, 55, 55)
                    .attr({
                        fill: 'white',
                        stroke: 'none'
                    });

    var set = paper.setFinish();

    set.rotate(45, 125, 90);

    //create the Telerik text

    var teleriktText = paper.text(480, 140, 'Telerik')
                            .attr({
                                'font-size': 158,
                                'font-weight': 'bold'
                            })

    //copyright logo
    var copyrightCircle = paper.circle(750, 125, 10)
                                .attr({
                                    'stroke-width': 2
                                });

    var copyrightText = paper.text(750, 125, 'R')
                             .attr({
                                 'font-size': 16,
                                 'font-weight': 'bold'
                             });

    //develop text
    var developText = paper.text(528, 235, 'Develop experiences')
                           .attr({
                               'font-size': 60,
                               'font-family': 'Segoe UI',
                               'font-weight': 'lighter'
                           });

    //-------------------------------------------------------------------------------------
    //youtube logo

    //container
    var rect = paper.rect(0, 400, 850, 350, 2)
                    .attr({
                        stroke: '#daedf2',
                        fill: '#ffffff',
                        'stroke-width': 6,
                        rx: 15,
                        ry: 15
                    });

    var rect = paper.rect(4, 404, 844, 344, 2)
                   .attr({
                       stroke: '#a1a1a1',
                       'stroke-width': 1,
                       rx: 15,
                       ry: 15
                   });

    //red background
    var rect = paper.rect(370, 425, 400, 260, 70)
                   .attr({
                       fill: '#ec2828',
                       stroke: 'none'
                   });

    //you text
    paper.setStart();

    var youText = paper.text(220, 550, 'You')
                        .attr({
                            fill: '#4b4b4b',
                        });

    //tube text

    var tubeText = paper.text(570, 550, 'Tube')
                        .attr({
                            fill: '#ffffff',
                            stroke: 'none'
                        }).toFront();

    var set = paper.setFinish();

    set.attr({
        'font-size': 238,
        'font-weight': 'bold',
    })
        .scale(0.6, 1);

})