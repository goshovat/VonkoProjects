function createCalendar(argSelector, argDataObject) {

    var container = document.querySelectorAll(argSelector)[0];
    container.style.paddingLeft = '30px';

    var countDays = 30;

    //prepare sample elements that we will clone

    var sampleUl = document.createElement('ul');
    sampleUl.style.margin = '0';
    sampleUl.style.padding = '0';
    sampleUl.style.clear = 'both';
    sampleUl.style.listStyleType = 'none';

    var sampleDay = document.createElement('li');
    sampleDay.dataset.selected = 'no';
    sampleDay.style.float = 'left';
    sampleDay.style.padding = '0';
    sampleDay.style.margin = '0';
    sampleDay.style.border = '1px solid black';

    var dateTitle = document.createElement('h1');
    dateTitle.style.padding = '5px 0';
    dateTitle.style.textAlign = 'center';
    dateTitle.style.background = '#cccccc';
    dateTitle.style.borderBottom = '1px solid black';
    dateTitle.style.margin = '0';
    dateTitle.style.fontSize = '18px';
    dateTitle.style.minWidth = '200px';

    var eventsDiv = document.createElement('div');
    eventsDiv.style.padding = '5px 10px';
    eventsDiv.style.minHeight = '100px';

    sampleDay.appendChild(dateTitle);
    sampleDay.appendChild(eventsDiv);

    var currentWeek;

    var dFrag = document.createDocumentFragment();
    var numberWeeks = (countDays / 7) | 0;

    //add dynamically all the days
    var totalDays = 0;

    var daysNames = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    function createDays() {
        for (var week = 0; week < numberWeeks + 1; week++) {

            for (var day = 0; day < 7; day++) {
                totalDays++;

                var currentDay = sampleDay.cloneNode(true);

                if (day == 0) {
                    if (currentWeek) {
                        dFrag.appendChild(currentWeek);
                    }

                    currentWeek = sampleUl.cloneNode(true);

                }

                currentDay.firstChild.innerHTML = daysNames[(totalDays - 1) % daysNames.length] + ' ' + totalDays + ' June 2014';

                //add the events

                currentDay.addEventListener('mouseover', function () {
                    this.style.background = '#fcd0cd';
                    this.style.cursor = 'pointer';
                });

                currentDay.addEventListener('mouseout', function () {
                    this.style.background = '';
                    this.style.cursor = '';
                });

                currentDay.addEventListener('click', function () {
                    var days = document.querySelectorAll('li');

                    for (var i = 0; i < countDays; i++) {
                        if (days[i].dataset.selected == 'yes') {
                            days[i].dataset.selected = 'no';
                            days[i].firstChild.style.background = '#cccccc';
                            days[i].firstChild.style.color = 'black';
                        }
                    }

                    this.dataset.selected = 'yes';
                    this.firstChild.style.background = '#686868';
                    this.firstChild.style.color = '#ffffff';

                });

                //append the li to the currentWeek

                currentWeek.appendChild(currentDay);

                if (totalDays == countDays) {
                    dFrag.appendChild(currentWeek);
                    return;
                }

            }
            dFrag.appendChild(currentWeek);
        }
    }
    createDays();

    container.appendChild(dFrag);

    //add the data from the object if the same day

    for (var i = 0; i < argDataObject.length; i++) {
        var eventDay = document.querySelectorAll('li')[argDataObject[i].date - 1];
        eventDay.querySelector('div').innerHTML = 'hour: ' + argDataObject[i].hour +
                                        '<br/>title: ' + argDataObject[i].title +
                                        '<br/>duration: ' + argDataObject[i].duration;
    }
};