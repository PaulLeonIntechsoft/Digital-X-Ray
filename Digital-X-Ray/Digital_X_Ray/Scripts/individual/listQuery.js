$(document).ready(function () {
    tableProperties();
    tableStyles();
    ocultarFiltro();
});

function tableProperties() {
    $('#example').DataTable({
        "scrollY": 507,
        "scrollX": true
    });
}

function tableStyles() {
    $("#example_filter > label").css("width","100%");
    $("#example_length > label").css("width", "100%");
}

function ocultarFiltro() {
    $("#example-wrapper div.row:first-child div:first-child").remove();
    $("#example_length").remove();
}