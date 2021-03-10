function showInp() {
    getSelectValue = document.getElementById("rol").value;
    if (getSelectValue == "ADM") {
        document.getElementById("userName").style.display = "inline-block";
        document.getElementById("userPass").style.display = "inline-block";
        document.getElementById("name").style.display = "inline-block";
        document.getElementById("lastName").style.display = "inline-block";
        document.getElementById("career").style.display = "none";
        //document.getElementById("cv").style.display = "none";
        document.getElementById("submit").style.display = "inline-block";
        document.getElementById("title").innerText = "Usuario";
        document.getElementById("pass").placeholder = "";
        document.getElementById("boton").style.display = "none";

    } else if (getSelectValue == "EST") {
        document.getElementById("userName").style.display = "inline-block";
        document.getElementById("userPass").style.display = "inline-block";
        document.getElementById("name").style.display = "inline-block";
        document.getElementById("lastName").style.display = "inline-block";
        document.getElementById("career").style.display = "inline-block";
        //document.getElementById("cv").style.display = "inline-block";
        document.getElementById("submit").style.display = "inline-block";
        document.getElementById("title").innerText = "Matricula";
        document.getElementById("pass").placeholder = "Digitar Matricula";
        document.getElementById("boton").style.display = "none";

    } else if (getSelectValue == "") {
        document.getElementById("userName").style.display = "none";
        document.getElementById("userPass").style.display = "none";
        document.getElementById("name").style.display = "none";
        document.getElementById("lastName").style.display = "none";
        document.getElementById("career").style.display = "none";
        document.getElementById("cv").style.display = "none";
        document.getElementById("submit").style.display = "none";
        document.getElementById("boton").style.display = "inline-block";
    }

    
}

function validateForm() {
    getSelectValue = document.getElementById("rol").value;
    if (getSelectValue == "EST") {
        var carrera = document.getElementById("carrera").value;
        if (carrera == "" || carrera == null) {
            document.getElementById("error").innerHTML = "<span class='text-danger'>El campo Carrera es necesario</span>"
            return false
        }
            
    }
    
}


