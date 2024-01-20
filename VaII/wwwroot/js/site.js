// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setJano() {

    var value = localStorage.getItem("night");
    if (value == 2) {
        localStorage.setItem("night", 1);
        document.body.classList.remove("dark-theme");
    
        localStorage.setItem("tma", "svetlo");
        document.getElementById("night_button").innerHTML = "Night mode";
        document.getElementById("night_button").className = "btn btn-dark";
        
    } else if (value == 1) {
        localStorage.setItem("night", 2);
        localStorage.setItem("tma", "tma");
        document.getElementById("night_button").className = "btn btn-light";
        document.getElementById("night_button").innerHTML = "Light mode";
        document.body.classList.add("dark-theme");
    
    } else {
        localStorage.setItem("night", 2);
        localStorage.setItem("tma", "tma");
        document.body.classList.add("dark-theme");
       
        document.getElementById("night_button").className = "btn btn-light";
        document.getElementById("night_button").innerHTML = "Night mode";
    }
}

function setJano2() {
      var value = localStorage.getItem("tma");
    if (value == "svetlo") {
        document.body.classList.remove("dark-theme");
        
        document.getElementById("night_button").className = "btn btn-dark";
        document.getElementById("night_button").innerHTML = "Night mode";

    } else if (value == "tma") {
        document.body.classList.add("dark-theme");
       
        ddocument.getElementById("night_button").className = "btn btn-light";
        document.getElementById("night_button").innerHTML = "Light mode";
    } else {
    document.body.classList.remove("dark-theme");
     
    document.getElementById("night_button").className = "btn btn-dark";
    document.getElementById("night_button").innerHTML = "Night mode";
    }
}


const prefersDarkScheme = window.matchMedia("(prefers-color-scheme: dark)");

if (prefersDarkScheme.matches) {
    document.body.classList.add("dark-theme");
    document.getElementById("night_button").className = "btn btn-light";
    document.getElementById("night_button").innerHTML = "Light mode";
} else {
    document.body.classList.remove("dark-theme");
    document.getElementById("night_button").innerHTML = "Night mode";
    document.getElementById("night_button").className = "btn btn-dark";
}


