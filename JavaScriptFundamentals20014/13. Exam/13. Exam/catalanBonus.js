function S(n) {
    n -= 0;
    r = .5;
    for (i = 2; i <= n; i++) {
        r *= i + n;
        r /= i
    }
    return r
};