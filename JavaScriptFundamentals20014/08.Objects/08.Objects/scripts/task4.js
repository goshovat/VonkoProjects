function execute() {

    var i;
    var output = ' ';
    var output1 = ' ';
    var propertyEntered = prompt('Enter one PROPERTY TO CHECK IF THE OBJECT HAS THIS PROPERTY: ');

    var objectVonko = {
        firstName: 'Vonko',
        lastName: 'Mihov',
        age: 25,
        sex: 'sometimes',

        fullName: function () {
            return (this.firstName + ' ' + this.lastName);
        },

        ageAfter10years: function () {
            return (this.age + 10);
        }
    }

    function hasProperty(obj, prop) {

        var hasProp = 'No';

        for (i in obj) {
            
            if (prop == i) {
                hasProp = 'Yes';
            }
        }

        return (hasProp);
    }


    var propertyNames = Object.getOwnPropertyNames(objectVonko);

    output = 'Has the property? ' + hasProperty(objectVonko, propertyEntered);
    output1 = 'Object: ' + '<br/>' +
        propertyNames[0] + ' : ' + objectVonko.firstName + '<br/>' +
        propertyNames[1] + ' : ' + objectVonko.lastName + '<br/>' +
        propertyNames[2] + ' : ' + objectVonko.age + '<br/>' +
        propertyNames[3] + ' : ' + objectVonko.sex + '<br/>' +
        propertyNames[4] + ' : ' + objectVonko.fullName() + '<br/>' +
        propertyNames[5] + ' : ' + objectVonko.ageAfter10years() + '<br/>';

    document.getElementById('output').innerHTML = output + '<br/>' + '</br>' + output1;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;