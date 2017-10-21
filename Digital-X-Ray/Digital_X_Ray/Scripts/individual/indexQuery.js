$(document).ready(function () {

    fechaPorDefecto();

    $('input[type="date"]').change(function () {
        var inputDate = new Date(this.value);
        var seleccionado = inputDate.getDay();
        cargarEventos(this.value, seleccionado);
    });

});

function redirectToDetail(codigo) {
    var code = $(codigo).attr('id');
    window.location.href = "/Case/Detail/" + code;
}


function fechaPorDefecto() {
    var now = new Date();

    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);

    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    $('#miFecha').val(today);

    cargarEventos(today, now.getDay() - 1);
}

function cargarEventos(fecha, dia) {
    var eventos = [];
    var v = "";

    $("#cuerpoTabla").empty();

    $.get("getDates", { fechaElegida: fecha, diaElegido : dia }, function (data) {
        $.each(data, function (i, v1) {
            eventos.push({
                "id": v1.chrNroCaso,
                "fecha" : v1.dtmfecProg,
                "descripcion": v1.chrCliAdic,
                "turno": v1.bytHoraIni,
                "codEstado": v1.chrEstCaso,
                "descEstado": v1.chrDesEsp,
                "dInicio" : v1.difrInicio ,
                "dFin": v1.difrFin
            });
        });

        //Vertical
        for (var i = 0; i < 7; i++) {
            v += "<tr>";
            //Horizontal
            for (var j = 0; j < 6; j++) {
                v += "<th ";
                if(j == dia){
                    v += "style = \"background-color:rgba(150,170,255,0.46)\"";
                }
                v += ">";
                for (var k = 0; k < eventos.length; k++) {
                    if (j == eventos[k].dInicio) {
                        if (i == eventos[k].turno) {
                            v += "<a ";
                            v += " id = \"" + eventos[k].id + "\" ";
                            v += " onclick=\"redirectToDetail(this)\" ";
                            v += " class=\"btn ";
                            if(eventos[k].codEstado == "30"){
                                v += " btn-primary ";
                            } else if (eventos[k].codEstado == "31") {
                                v += " btn-success ";
                            } else if (eventos[k].codEstado == "32") {
                                v += " btn-secondary ";
                            } else if (eventos[k].codEstado == "33") {
                                v += " btn-warning ";
                            } else if (eventos[k].codEstado == "34") {
                                v += " btn-danger ";
                            } 
                            v += " event-selected\">";
                            v += "" + eventos[k].id + "<br>";
                            if (eventos[k].descripcion.length < 20) {
                                v += "" + eventos[k].descripcion + "<br>";
                            } else {
                                v += "" + eventos[k].descripcion.substring(0,20) + "<br>";
                            }
                            v += "" + eventos[k].fecha + " - ";
                            if (eventos[k].turno == "0") {
                                v += " 9 a.m <br>";
                            } else if (eventos[k].turno == "1") {
                                v += " 10 a.m <br>";
                            } else if (eventos[k].turno == "2") {
                                v += " 11 p.m <br>";
                            } else if (eventos[k].turno == "3") {
                                v += " 12 a.m <br>";
                            } else if (eventos[k].turno == "4") {
                                v += " 1 p.m <br>";
                            } else if (eventos[k].turno == "5") {
                                v += " 2 p.m <br>";
                            } else if (eventos[k].turno == "6") {
                                v += " 3 p.m <br>";
                            } else if (eventos[k].turno == "7") {
                                v += " 4 p.m <br>";
                            } else if (eventos[k].turno == "8") {
                                v += " 5 p.m <br>";
                            }
                            v += "" + eventos[k].descEstado;
                            v += "<a>";
                        }
                    }
                }
                v += "</th>";
            }
            v += "</tr>";
            
        }

        $("#cuerpoTabla").html(v);

    });
}