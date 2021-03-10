function validateForm() {
   
    var imagen = document.getElementById("IMAGEN").value;
    if (imagen == "" || imagen == null) {
        document.getElementById("error").innerHTML = "<span class='text-danger'>El campo Carrera es necesario</span>";
        return false
    }
}