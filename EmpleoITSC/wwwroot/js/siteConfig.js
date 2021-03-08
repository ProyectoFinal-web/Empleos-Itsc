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

    } else if (getSelectValue == "EST") {
        document.getElementById("userName").style.display = "inline-block";
        document.getElementById("userPass").style.display = "inline-block";
        document.getElementById("name").style.display = "inline-block";
        document.getElementById("lastName").style.display = "inline-block";
        document.getElementById("career").style.display = "inline-block";
        //document.getElementById("cv").style.display = "inline-block";
        document.getElementById("submit").style.display = "inline-block";
        document.getElementById("title").innerText = "Matricula";
        document.getElementById("pass").placeholder = "Digita la matricula";
    } else if (getSelectValue == "") {
        document.getElementById("userName").style.display = "none";
        document.getElementById("userPass").style.display = "none";
        document.getElementById("name").style.display = "none";
        document.getElementById("lastName").style.display = "none";
        document.getElementById("career").style.display = "none";
        document.getElementById("cv").style.display = "none";
        document.getElementById("submit").style.display = "none";
    }
}

//$(function () {
//    var $res = $('#resultado'),
//        $select = $('#rol');
//    function mostrarOpcionSeleccionada() {
//        var $option = $select.find('option:selected');
//        showInp();

//        $('#resultado').text($option.text() + ' (' + $option.val() + ')');
//    }
//    getSelectValue = document.getElementById("rol").value;
//    debugger;

//    $select.on('change', mostrarOpcionSeleccionada);

//    $select.trigger('change');
//});