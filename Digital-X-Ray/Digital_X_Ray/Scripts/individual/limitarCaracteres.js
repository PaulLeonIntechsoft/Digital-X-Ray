function mostrarMensaje(cantidad) {
    document.getElementById("mensaje").innerHTML = "Le quedan :" + cantidad + " caracteres";
}

function actualizarMensaje(area, cantidad) {
    total = area.length;
    if (total < 99) {
        document.getElementById("mensaje").innerHTML = "Faltan :" + (cantidad - total) + " caracteres";
    }

    else if (total == 99) {
        document.getElementById("mensaje").innerHTML = "Falta :" + (cantidad - total) + " caracter";
    }

    else {
        document.getElementById("mensaje").innerHTML = "Exedió el máximo de caracteres";
        caja = document.getElementById("txtmensaje");
        caja.readOnly = true;
        if (document.getElementById("checkbox").checked == true) {
            caja.readOnly = false;
        }
    }
}

function validarTecla(evento) {
    tecla = evento.keyCode;
    caja = document.getElementById("txtmensaje");
    if (tecla == 13 || caja.value.length == 100) {
        return false;
    }
}

function validarEdicion() {
    caja = document.getElementById("txtmensaje");
    if (document.getElementById("checkbox").checked == true) {
        caja.readOnly = false;
    }
    else
        caja.readOnly = true;
}