document.getElementById("execute").onclick = function Execute() {
    var string = document.getElementById("input1").value;
    var arr = string.split(" ");
    var number = document.getElementById("input2").value;

    Array.prototype.remove = function remove() {
        for (i = 0; i < arr.length; i++) {
            if (arr[i] == number) {
                arr.splice(i, 1);
                remove();
            }
        }
        
    }

    var finalArr = arr.remove(number);
    jsConsole.writeLine(arr);
    

}

document.getElementById("reset").onclick = function Erase() {
    document.getElementById("js-console").innerHTML = "";
    document.location.reload();
}