function Solve(args) {

    function jump(startPos) {
        var maxJumpStep = field.length;

        for (var j = 1; j <= maxJumpStep; j++) {

            var currentPos = startPos;
            var currentJumpsCount = 1;

            while (true) {
                var oldValue = field[currentPos];

                currentPos += j;

                if (currentPos >= field.length) {
                    currentPos -= field.length;
                }

                if (field[currentPos] <= oldValue) {
                    break;
                }

                currentJumpsCount++;
            }

            if (currentJumpsCount > maxJumpsCount) {
                maxJumpsCount = currentJumpsCount;
            }
        }

    }

    var field = args[0].split(',');

    field = field.map(Number);

    var maxJumpsCount = 0;

    for (var i = 0; i < field.length; i++) {
        jump(i);
    }

    return maxJumpsCount;
}