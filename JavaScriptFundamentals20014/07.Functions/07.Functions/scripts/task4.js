function execute() {

    var numberOfDivs = 0;

    function getNumberOfDivs() {
        
        var numberOfDivs = document.getElementsByTagName('div').length;

        return numberOfDivs;
    }

    document.getElementById('output').innerHTML = getNumberOfDivs();
}


function reset() {
    location.reload();
}

document.getElementById('execute').onclick = execute;
document.getElementById('reset').onclick = reset;