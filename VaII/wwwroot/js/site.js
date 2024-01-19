// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




//window.onload = setJano2;

function setJano() {
    var element = document.body;
    var value = localStorage.getItem("night");
    if (value == 2) {
        localStorage.setItem("night", 1);
        element.classList.toggle("light-mode");

    } else if (value == 1) {
        localStorage.setItem("night", 2);
        element.classList.toggle("dark-mode");
    } else {
        localStorage.setItem("night", 2);
        element.classList.toggle("dark-mode");
    }
}
function setJano2() {
    var element = document.body;
    var value = localStorage.getItem("night");
    if (value == 2) {
        element.classList.toggle("dark-mode");
    } else if (value == 1) {
        element.classList.toggle("light-mode");
    } else {
        element.classList.toggle("light-mode");
    }
}



