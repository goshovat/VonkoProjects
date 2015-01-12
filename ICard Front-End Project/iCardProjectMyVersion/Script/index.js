function ChangeClass(clickedElement) {

    var oldCurrentElement = document.getElementsByClassName("selected")[0];
    oldCurrentElement.classList.remove("selected");

    clickedElement.classList.add("selected");
}

