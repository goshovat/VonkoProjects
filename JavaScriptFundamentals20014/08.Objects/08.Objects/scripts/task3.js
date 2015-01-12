function execute() {

    var primitiveType = 5;
    var array = [1, 2, 'pehso', 'gosho', 7, 8];
    var vonkoObj = {
        firstName: 'Vonko',
        secondName: 'Mihov',
        age:24
    }

    var choice = prompt('Enter the number of the type you choose(1,2,3): ');
    var parameter;

    switch (choice) {
        case '1': parameter = primitiveType; break;
        case '2': parameter = array; break;
        case '3': parameter = vonkoObj; break;
        default: alert('Invalid choice'); return; break;
    }
    
    var i;

    //Now we define the function making a deep copy
    function deepCopy(arg) {
        if (arg == null || !(arg instanceof Object)) {
            return (arg);
        }
       
        if (arg instanceof Array) {
            var copy = [];
            for (i = 0; i < arg.length; i++) {
                copy[i] = arg[i];
            }

            return (copy);
        }

        if (arg instanceof Object) {
            var copy = {};
            var objOutput = '';

            for (prop in arg) {
                copy[prop] = arg[prop];
                objOutput += prop + ' : ' + copy[prop] +',' + '<br/>'
            }
            return (objOutput);
        }
        throw new Error('Invalid data!');
    }

    output = deepCopy(parameter);

    document.getElementById('output').innerHTML = output;
}

function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;