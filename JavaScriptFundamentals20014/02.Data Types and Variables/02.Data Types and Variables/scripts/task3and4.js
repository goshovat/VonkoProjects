function execute() {
    var intType = 6;
    var floatType = 7.8;
    var stringType = 'Vanko';
    var boolType = true;
    var nullType = null;
    var objectType = { firstName: 'John', 'lastName': 'Mihov', age: 34 };
    var arrayType = ["Mimi", "Penka", "Cveti"];
    var undefinedTYpe = undefined;

    var typeOfInt = typeof (intType);
    var typeOfFloat = typeof (floatType);
    var typeOfString = typeof (stringType);
    var typeOfBool = typeof (boolType);
    var typeOfNull = typeof (nullType);
    var typeOfObject = typeof (objectType);
    var typeOfArray = typeof (arrayType);
    var typeOfUndefined = typeof (undefinedTYpe);

    document.getElementById("output").innerHTML = "Result of using 'typeof' on the variables from Task1: <br/><br/>" +
        'int: ' + typeOfInt + '<br/>' + 'float: ' + typeOfFloat + '<br/>' + 'string: ' + typeOfString + '<br/>' +
        'bool: ' + typeOfBool + '<br/>' + 'null: ' + typeOfNull + '<br/>' +
        "object: " + typeOfObject + '<br/>' + "array: " + typeOfArray + '<br/>' +
        'undefined: ' + typeOfUndefined;
}

function reset() {
    location.reload();
}

document.getElementById("execute").onclick = execute;
document.getElementById("reset").onclick = reset;