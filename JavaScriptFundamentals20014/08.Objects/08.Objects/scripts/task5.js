function execute() {

    var i;
    var output = ' ';
    var output1 = ' ';

    var objectsArray = [
        { firstName: 'Vonko', lastName: 'Mihov', age: 25 },
        { firstName: 'Mitko', lastName: 'Mihov', age: 21 },
        { firstName: 'Sameca', lastName: 'Dimov', age: 27 },
        { firstName: 'Tavarisha', lastName: 'Stoyanov', age: 28 },
        { firstName: 'Vesko', lastName: 'Doktora', age: 36 },
        ]

    function youngestPerson(arr) {
        var youngest = 99;
        var youngestIndex = '';

        for (i in objectsArray) {

            if (objectsArray[i].age < youngest) {
                youngest = objectsArray[i].age;
                youngestIndex = i;
            }
        }

        return (objectsArray[youngestIndex].firstName + ' ' +
            objectsArray[youngestIndex].lastName);
    }


    var propertyNames = Object.getOwnPropertyNames(objectsArray);

    output = 'Youngest person: ' + youngestPerson(objectsArray);
    output1 = 'Persons: ' + '<br/>' +
        'First Name: ' + objectsArray[0].firstName + '; ' + 'Last Name: ' + objectsArray[0].lastName + 
        ' ;' + 'Age: ' + objectsArray[0].age + '<br/>' +
       'First Name: ' + objectsArray[1].firstName + '; ' + 'Last Name: ' + objectsArray[1].lastName +
        ' ;' + 'Age: ' + objectsArray[1].age + '<br/>' +
        'First Name: ' + objectsArray[2].firstName + '; ' + 'Last Name: ' + objectsArray[2].lastName +
        ' ;' + 'Age: ' + objectsArray[2].age + '<br/>' +
       'First Name: ' + objectsArray[3].firstName + '; ' + 'Last Name: ' + objectsArray[3].lastName +
        ' ;' + 'Age: ' + objectsArray[3].age + '<br/>' +
        'First Name: ' + objectsArray[4].firstName + '; ' + 'Last Name: ' + objectsArray[4].lastName +
        ' ;' + 'Age: ' + objectsArray[4].age + '<br/>';

    document.getElementById('output').innerHTML = output + '<br/>' + '</br>' + output1;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;