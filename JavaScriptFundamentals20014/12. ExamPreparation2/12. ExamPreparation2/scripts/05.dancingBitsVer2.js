function Solve(params) {

    var numberOfDancingBits = parseInt(params[0]);
    var numberOfIntegers = parseInt(params[1]);

    var i = 0;
    var j = 0;
    var sequence = [];
    //var inputArray = [2, 10, 42, 170];

    for (i = 2; i < (numberOfIntegers + 2) ; i++) {

        numberInBits = (parseInt(params[i])).toString(2);
        sequence += numberInBits;
    }

    //console.log(sequence);

    var currentElement = sequence[0];
    var currentOccurences = 1;
    var sequencesFound = 0;

    for (var i = 1; i < sequence.length; i++) {

        if (sequence[i] == currentElement) {
            currentOccurences++;
        }
        else {

            if (currentOccurences == numberOfDancingBits) {
                sequencesFound++;
            }

            currentElement = sequence[i];
            currentOccurences = 1;
        }
    }

    if (currentOccurences == numberOfDancingBits) {
        sequencesFound++
    }

    return (sequencesFound);
}
//console.log(sequencesFound);