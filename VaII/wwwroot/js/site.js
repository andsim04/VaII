// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function darkMode(boolean) {
    if (boolean) {
        element.classList.toggle("dark-mode");
    } else {
        element.classList.toggle("light-mode");
     }
   
} 

function setTheme() {
    íf(localStorage.getItem("night") == true) {
        darkMode(true);
        document.getElementById("flexSwitchCheckDefault").checked = true;
    } else {
        darkMode(false);
        document.getElementById("flexSwitchCheckDefault").checked = false;
    }
}


function setJano() {
    var checkbox = document.getElementById("flexSwitchCheckDefault").checked;
    if (checkbox) {
        localStorage.setItem("night", true);

    } else {
        localStorage.setItem("night", false);
    }
}

