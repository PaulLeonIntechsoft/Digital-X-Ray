
var imageLoader = document.getElementById('file-input');
imageLoader.addEventListener('change', subirImagen, false);


$(document).ready(function () {
    resizeForm();
    $(window).resize(resizeForm);
    $("#btnGrabar").click(function () {
        if ($("#btnGrabar").is(':enabled')) {
            subirDatos();
        }
    });

    $("#cambiosAceptados").click(function () {
        window.location.href = "/Home/Index";
    });
});

function resizeForm() {

    // Change container size
    alterClassRemove(992, "#containerPadre", "container");
    alterClassAdd(992, "#containerPadre", "container-fluid");

    // Change col size (whole form container)
    alterClassRemove(767, 829, "#emptyPlace", "col-md-4");
    alterClassAdd(767, 829, "#emptyPlace", "col-md-3");

    alterClassAdd(767, 829, "#formContainer", "col-md-9");
    alterClassRemove(767, 829, "#formContainer", "col-md-8");

};

function subirDatos() {
    var codigoCaso = $("#nroCaso").attr('value');
    var problema = $("#txtProblema").val();
    var trabajo = $("#txtTrabajosRealizados").val();
    var observaciones = $("#txtObservaciones").val();
    var codigoEstado = $("#cboEstado").val();
    var baseImagenes = $("#baseImagenes").text();

    $.ajax({

        url: "/Case/setData",
        data: {
            codigoCaso: codigoCaso,
            problema: problema,
            trabajo: trabajo,
            observaciones: observaciones,
            codigoEstado: codigoEstado,
            imagenes: baseImagenes
        },
        type: 'POST',
        success: function (data) {
            if(data.success == true){
                $("#modalConfirmacion").modal('show');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest);
            alert(textStatus);
            alert(errorThrown);
        }

    });
}

function subirImagen() {
    var texto = $("#baseImagenes").text();

    ////// 100 de |
    //texto += arr[1] + '||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||';
    //$("#baseImagenes").text(texto);

    if (this.files && this.files[0]) {
        var obj = new FileReader();
        obj.onload = function (data) {
            var base64imagen;
            base64imagen = data.target.result;
            var imagenBinaria;
            imagenBinaria = base64imagen.toString();
            var arr;
            arr = imagenBinaria.split("base64,");
            // 100 de |
            texto += arr[1] + '||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||';
            $("#baseImagenes").text(texto);
        }
        obj.readAsDataURL(this.files[0]);
    }
}