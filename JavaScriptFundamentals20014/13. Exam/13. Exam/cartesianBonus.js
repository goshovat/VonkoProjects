function S(c) {
    return (c[0] > 0 ? c[1] > 0 ? 1 : 3 : c[1] < 0 ? 2 : 0)
}

var test1 = [-1, -2];
console.log(S(test1));