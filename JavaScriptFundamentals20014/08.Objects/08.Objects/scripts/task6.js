function execute() {

    var inputProperty = document.getElementById('input0').value;

    var output = ' ';
    var output1 = ' ';

    function PersonConstructor(argFirstName, argLastName, argAge) {
        this.firstName = argFirstName,
        this.lastName = argLastName,
        this.age = argAge
    }

    var vonko = new PersonConstructor('Vonko', 'Mihov', 25);
    var gosho = new PersonConstructor('Goshko', 'Radev', 25);
    var sameca = new PersonConstructor('Sameca', 'Dimov', 28);
    var doktora = new PersonConstructor('Vesko', 'Doktora', 36);

    var persons = [vonko, gosho, sameca, doktora];

    function groupByProp(persons, argProp) {
        var groupedArray = {};

        output += 'By ' + argProp + ':' + '<br/>';

        for (i in persons) {
            var result = persons[i][argProp];
            groupedArray[result] = groupedArray[result] || [];
            groupedArray[result].push(persons[i]);
            output += result + " : " + "<br/>"
                + " First Name: " + persons[i].firstName + "; Last Name: "
                + persons[i].lastName + "; Age: " + persons[i].age + "<br/>" + "<br/>";
        }      
    }

    groupByProp(persons, inputProperty);
    
    document.getElementById('output').innerHTML = output;
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;