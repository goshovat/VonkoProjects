function Solve(args) {

    function parseOperation(argOperationStart) {
        var indexOfWhiteSpace = argOperationStart.trim().indexOf(' ');
        var name;
        var func;
        if (indexOfWhiteSpace == -1) {
            name = argOperationStart.trim();
            func = '';
        } else {
            name = argOperationStart.substring(0, indexOfWhiteSpace).trim();
            func = argOperationStart.substring(indexOfWhiteSpace).trim();
        }

        return {
            name: name.trim(),
            func: func.trim()
        }
    }

    function parseValue(argValue) {
        argValue = argValue.trim();
        argValue = argValue.substring(0, argValue.length - 1);
        var parts = argValue.split(',').map(function(item) {
            return item.trim();
            if (isFinite(item)) {
                return parseInt(item);
            } else {
                return item;
            }
        });

        return parts;
    }

    function parseOperations(argLines) {
        var operations = []

        for (var i = 0; i < lines.length; i++) {
            var line = lines[i];
            //parts[0] - > variable + function
            //parts[1] - > values + ];
            var parts = line.split('[');
            var operation = parseOperation(parts[0]);
            var value = parseValue(parts[1]);
            operation.value = value;
            operations.push(operation);
        }

        // return [{
        //     operation: 'sum',
        //     value: '[1,2,3,4]',
        //     name: 'func2'
        // }]

        return operations;
    }

    function estimateValue(argOperation, argValue, argOperator) {

        switch (argOperator) {
            case '':
                break;
            case 'sum':
                var sum = 0;
                for (var i = 0; i < argValue.length; i++) {
                    sum += parseInt(argValue[i]);
                };
                argValue = sum;
                break;
            case 'min':
                argValue = Math.min.apply(null, argValue);
                break;
            case 'max':
                argValue = Math.max.apply(null, argValue);
                break;
            case 'avg':
                var sum = 0;
                for (var i = 0; i < argValue.length; i++) {
                    sum += parseInt(argValue[i]);
                };
                argValue = Math.floor(sum / argValue.length);
                break;
        }

        return (argValue);
    }

    function evaluateOperation(argName, argScope) {
        var operation = argScope[argName];
        var newValue = [];
        for (var i = 0; i < operation.value.length; i++) {
            var item = operation.value[i];

            if (!isFinite(item) && item != '') {
                var variableValue = scope[item].value;
                if (variableValue instanceof Array) {
                    Array.prototype.push.apply(newValue, variableValue);
                } else {
                    newValue.push(variableValue);
                }
            } else {
                newValue.push(item);
            }
        }

        var newValue = estimateValue(operation, newValue, operation.func);

        scope[argName].value = newValue;
    }

    var lines = args.map(function(item) {
        item.trim();
        if (item.indexOf('def') !== 0) {
            return item;
        }
        item = item.substr('def'.length).trim();
        return item;
    });

    var operations = parseOperations(lines);
    var scope = {};

    for (var i = 0; i < operations.length; i++) {
        var currentOperation = operations[i];
        scope[currentOperation.name] = currentOperation;
        evaluateOperation(currentOperation.name, scope);
    };

    var props = Object.keys(scope);
    var last = props[props.length - 1];

    if (scope[last].name == '') {
        return (parseInt(scope[last].value));
    } else {
        var finalValue = estimateValue(scope[last], scope[last].value, scope[last].name);
        return (finalValue);
    }
}

var args = [
    'def    func   sum[5,   3  , 7, 2, 6, 3]',
    'def func2 [5, 3,    7, 2  , 6, 3]',
    'def func3 min[func2]',
    'def   func4 max[5, 3, 7, 2, 6, 3]',
    'def func5    avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6,     func4]'
]

var args1 = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'

]

console.log(Solve(args));
console.log('------------------')
console.log(Solve(args1));