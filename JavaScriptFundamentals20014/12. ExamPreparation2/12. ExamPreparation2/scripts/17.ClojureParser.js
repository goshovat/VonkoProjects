function Solve(args) {

    var finalResult;
    var functions = [];

    for (var i = 0; i < args.length; i++) {
        var currentRow = args[i].trim();

        var parameters = [];
        var nestedParameters = [];
        var operator = '';
        var nestedOperator = '';
        var currentDigit = '';
        var currentFunctionName = '';
        var currentNewFunction = '';

        var inCommand = false;
        var inNestedCommand = false;

        for (var j = 0; j < currentRow.length; j++) {

            var currentSymbol = currentRow[j];

            if (currentSymbol === ' ' || currentSymbol === ')') {

                if (currentFunctionName !== '') {

                    if (functions[currentFunctionName] || functions[currentFunctionName] == 0) {
                        var functionResult = functions[currentFunctionName];

                        if (inNestedCommand) {
                            nestedParameters.push(functionResult);
                        } else {
                            parameters.push(parseInt(functionResult));
                        }
                    } else {
                        currentNewFunction = currentFunctionName;
                    }

                    currentFunctionName = '';
                }

                if (currentDigit !== '') {
                    if (inNestedCommand) {
                        nestedParameters.push(parseInt(currentDigit));
                    } else {
                        parameters.push(parseInt(currentDigit));
                    }
                    currentDigit = '';
                }

                if (currentSymbol === ')' && currentNewFunction !== '') {
                    var result;
                    if (inNestedCommand) {
                        result = calculate(nestedOperator, nestedParameters);
                    } else {
                        result = calculate(operator, parameters);
                    }

                    if (result == 'Error') {
                        return ('Division by zero! At Line:' + (i + 1));
                    }

                    if (currentNewFunction !== 'def') {
                        functions[currentNewFunction] = result;
                    }
                    currentNewFunction = '';
                }

                if (inNestedCommand && currentSymbol === ')') {
                    var nestedResult = calculate(nestedOperator, nestedParameters);

                    parameters.push(parseInt(nestedResult));

                    nestedParameters = [];
                    nestedOperator = '';
                    inNestedCommand = false;
                }
                continue;
            }

            if (currentSymbol === '(') {
                if (inCommand) {
                    inNestedCommand = true;
                } else {
                    inCommand = true;
                }
                continue;
            }

            if (isMathOperator(currentSymbol)) {
                if (currentSymbol === '-' && isNumber(currentRow[j + 1]) && j + 1 < currentRow.length) {
                    currentDigit += currentSymbol;
                } else {
                    if (inNestedCommand) {
                        nestedOperator = currentSymbol;
                    } else {
                        operator = currentSymbol;
                    }
                }
                continue;
            }

            if (isNumber(currentSymbol)) {
                if (currentFunctionName !== '') {
                    currentFunctionName += currentSymbol;
                } else {
                    currentDigit += currentSymbol;
                }

                continue;
            }

            currentFunctionName += currentSymbol;

        }

        finalResult = calculate(operator, parameters);
        // console.log('parameters ' + parameters);
        // console.log('result ' + finalResult);

        if (finalResult == 'Error') {
            return ('Division by zero! At Line:' + (i + 1));
        }

    }

    return finalResult;

    function isMathOperator(argSymbol) {
        if (argSymbol === '+' || argSymbol === '-' || argSymbol === '*' || argSymbol === '/') {
            return true;
        } else {
            return false;
        }
    }

    function isNumber(argSymbol) {
        if (argSymbol == ' ') {
            return false;
        }
        return argSymbol == Number(argSymbol);
    }

    function calculate(argOperator, argParameters) {
        if (argParameters.length === 1) {
            return argParameters[0];
        }

        var result = argParameters[0];
        for (var i = 1; i < argParameters.length; i++) {
            switch (argOperator) {
                case '+':
                    result += argParameters[i];
                    break;
                case '-':
                    result -= argParameters[i];
                    break;
                case '*':
                    result *= argParameters[i];
                    break;
                case '/':
                    if (argParameters[i] == 0) {
                        return 'Error';
                    } else {
                        result /= parseInt(argParameters[i]);
                        result = parseInt(result);
                    }
                    break;
            }
        }

        return result;
    }
}


var zeroTest = [
    '(+   1    2(* 1 1 1 1 ) 7)',
    '(+ 5    2    7 1)',
    '(- 4 2)',
    '(-    4)',
    '(   / 2)',
    '(* 5 7)',
    '(/ 10 3)',
    '(/ 10    3 2)'
]

var firstTest = [
    '(def myFunc 5)',
    '(def myNewFunc (+  myFunc  myFunc 2))',
    '(def MyFunc (* 2  myNewFunc))',
    '(/   MyFunc  myFunc)'
]

var secondTest = [
    '(def func 10)',
    '(def newFunc(+ func 2))',
    '(def sumFunc(+ func func newFunc 0 0 0))',
    '( * sumFunc 2)'
]

var thirdTest = [
    '(def func (+ 5 2))',
    '(def func2 (/  func 5 2 1 0))',
    '(def func3 (/ func 2))',
    '(+ func3 func)',
]

console.log(Solve(secondTest));