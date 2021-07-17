var idPaciente = 0;
var nombrePacienteExt = "";
var extInt = 0;
var oTabla;
LoadDataTable();
$(document).ready(function () {
    if ($("[rel=tooltip]").length) {
        $("[rel=tooltip]").tooltip();
    }
    var GET = {};


    document.location.search.replace(/\??(?:([^=]+)=([^&]*)&?)/g, function () {
        function decode(s) {
            return decodeURIComponent(s.split("+").join(" "));
        }

        GET[decode(arguments[1])] = decode(arguments[2]);
    });

    if (GET["idPaciente"] != "" && GET["idPaciente"] != null) {
        idPaciente = GET["idPaciente"];
    }

    if (GET["nombrePacienteExt"] != "" && GET["nombrePacienteExt"] != null) {
        nombrePacienteExt = GET["nombrePacienteExt"];
    }

    if (GET["extInt"] != "" && GET["extInt"] != null) {
        extInt = GET["extInt"];
       // alert(extInt);
    }

    traerEstudios();
});

function traerEstudios() {
 var json = JSON.stringify({ "idPaciente": idPaciente, "nombrePacienteExt": nombrePacienteExt, "extInt": extInt });
 $.ajax({
     type: "POST",
     url: "../Json/AnatomiaPatologica/AnatomiaPatologicaTrue.asmx/PAPTraerEstudioViejo",
     data: json,
     contentType: "application/json; charset=utf-8",
     dataType: "json",
     success: cargarLista,
     complete: function () {
         $("#resultados").DataTable();
         $('.sorting').click();
         $(".sorting_asc").click();
         $(".sorting_desc").click();
         $('.dataTables_scrollBody').show();

//         var table = $('#resultados').DataTable();
//         $('#resultados').css('display', 'block');
//         table.columns.adjust().draw();
     },

     error: errores
 });
}

function errores(msg) {
    Impreso = 0;
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}

function cargarLista(resultado) {
    var lista = resultado.d;

    $("#resultados").empty();
    var Encabezado = "";
    var Contenido = "";
    $.each(lista, function (index, item) {

        Contenido = Contenido + "<tr style='height:20px; cursor:default' id='" + item.id + ";overflow:scroll; width:auto'>" +
           "<td style='width:1%;cursor:pointer'>" +
           "<td style='text-aling:center' onclick='seleccionar(" + item.id + ")'>" + item.apellido + "</div></td>" +
           "<td style='text-aling:center' onclick='seleccionar(" + item.id + ")'>" + item.hc + "</div></td>" +
           "<td style='text-aling:center' onclick='seleccionar(" + item.id + ")'>" + item.seccional + "</div></td>" +
           "<td style='text-aling:center' class='txtDesdeSalidaS' onclick='seleccionar(" + item.id + ")'>" + item.protocolo + "</div></td>" +
           "<td style='text-aling:center' class='txtFechaNotificacionDesdeS' onclick='seleccionar(" + item.id + ")'>" + item.medico + "</div></td>" +
           "<td style='text-aling:center' class='txtFechaDiagnosticoDesdeS' onclick='seleccionar(" + item.id + ")'>" + item.fechaCarga + "</div></td>" +
           "<td style='text-aling:center' class='txtDniS' onclick='seleccionar(" + item.id + ")'>" + item.evaluacion + "</div></td>" +
           "<td style='text-aling:center' class='txtNhc' onclick='seleccionar(" + item.id + ")'>" + item.diagnostico + "</div></td>" +
           "<td style='text-aling:center' class='txtSeccionalS' onclick='seleccionar(" + item.id + ")'>" + item.comentario + "</div></td>" +
           "<td style='text-aling:center' class='cboMuestraAdecuacionS' onclick='seleccionar(" + item.id + ")'>" + item.condicionMuestra + "</div></td>" +
           "<td style='text-aling:center' class='cboCategoriaGeneralS' onclick='seleccionar(" + item.id + ")'>" + item.superficiales + "</div></td>" +
           "<td style='text-aling:center' class='cboSalaPerifericaS' onclick='seleccionar(" + item.id + ")'>" + item.intermedias + "</div></td>" +
           "<td style='text-aling:center' class='cboHallazgosS' onclick='seleccionar(" + item.id + ")'>" + item.parabasales + "</div></td>" +
           "<td style='text-aling:center' class='cboMicroorganismosS' onclick='seleccionar(" + item.id + ")'>" + item.otrosElementos + "</div></td>" +
           "<td style='text-aling:center' class='cboCelulasGlandularesS' onclick='seleccionar(" + item.id + ")'>" + item.glandulares + "</div></td>" +
           "<td style='text-aling:center' class='cboValoracionHormonalS' onclick='seleccionar(" + item.id + ")'>" + item.escamosas + "</div></td>";

    });

    var Pie = "</tbody></table>";
    $("#resultados").html(Contenido + Pie);

    //if (lista.lenght > 0) { $("#mensaje").show(); } else { $("#mensaje").hide(); }

}

function LoadDataTable() {
    oTabla = $('#resultados').DataTable({
        "bAutoWidth": true,
        "bPaginate": false,
        "bFilter": false,
        "bInfo": false,
        "sScrollY": "350px",
        "sScrollX": "100%",
        "sScrollXInner": "400%",
        "sScrollYInner": "100%",
        "bScrollCollapse": true,
//                fixedHeader: {
//                    header: true,
//                    footer: false
//                },
        //"columnDefs": [{ "visible": false, "targets": [4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]}],
        "aaSorting": [],
        "language": {
            "zeroRecords": "Sin Resultados"
        }
    });
}