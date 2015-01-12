function execute() {
    var input0 = document.getElementById('input0').value;

    function reverseString(argString) {

        var arr = argString.split('');
        arr.reverse();
        var newArr = arr.join('');
    
        return (newArr);
    }

    output = reverseString(input0);

    document.getElementById('output').innerHTML = output;
    
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;