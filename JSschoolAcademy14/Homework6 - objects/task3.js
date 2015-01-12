document.getElementById("execute").onclick = function Execute() {
    var a = {
        a: 5,
        b: 6,
        c: "f"
    }

    var b = Object.create(a);
    for (i in b) {
        jsConsole.writeLine(b[i]);
    }

    function Clone(obj) {
        if (obj == null || obj != typeof Object) {
            return obj;
        }

        if (obj instanceof Array) {
            var copy = [];
            for (i = 0; i < obj.length; i++) {
                copy[i] = Clone(obj[i]);
            }
            return copy
        }

        if (obj instanceof Object) {
            var copy = {};
            for (attr in obj) {
                if (obj.hasOwnProperty(attr)) {
                    copy[attr] = clone(obj[attr]);
                }
            }
            return copy;
        }
        throw new Error("Unable copy format!")
    }
    jsConsole.writeLine("</br>");

    var c = Clone(a);

    for (i in c) {
        jsConsole.writeLine(c[i]);
    }
}

document.getElementById("reset").onclick = function Erase() {
    document.getElementById("js-console").innerHTML = "";
    document.location.reload();
}
