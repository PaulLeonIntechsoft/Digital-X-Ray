$(document).ready(function () {
    ventanaResponsive();
    $(window).resize(ventanaResponsive);
});

function ventanaResponsive() {
    var anchoVentana = $(window).width();
    if (anchoVentana > 380) {
        $("#cont1").removeClass("col-0");
        $("#cont1").addClass("col-1");
        $("#cont2").removeClass("col-12");
        $("#cont2").addClass("col-10");
    } else {
        $("#cont1").removeClass("col-1");
        $("#cont1").addClass("col-0");
        $("#cont2").removeClass("col-10");
        $("#cont2").addClass("col-12");
    }
}