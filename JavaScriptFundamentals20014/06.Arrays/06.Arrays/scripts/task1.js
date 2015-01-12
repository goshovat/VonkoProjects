function execute() {   
        var output = ' ';
        var i;

        var array = new Array(20);

        for (i = 0; i < array.length; i++) {
            array[i] = i*5;
        }

        output = array.join(", ");
     
        document.getElementById('output').innerHTML = output;
    
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;