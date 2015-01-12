function execute() {
    var intType = 6;
    var floatType = 7.8;
    var stringType = 'Vanko';
    var boolType = true;
    var nullType = null;
    var objectType = { firstName: 'John', 'lastName': 'Mihov', age: 34 };
    var arrayType = ["Mimi", "Penka", "Cveti"];
    var undefinedTYpe = undefined;

    document.getElementById("output").innerHTML = 'Examples of different variable types: <br/><br/>' +
        'int: ' + intType + '<br/>' + 'float: ' + floatType + '<br/>' + 'string: ' + stringType + '<br/>' +
        'bool: ' + boolType + '<br/>' + 'null: ' + nullType + '<br/>' +
        "object's name: " + objectType.firstName + '<br/>' + "array's third member: " + arrayType[2] + '<br/>' +
        'undefined: ' + undefinedTYpe;
}

function reset() {
    location.reload();
}

document.getElementById("reset").onclick = reset;
document.getElementById("execute").onclick = execute;
