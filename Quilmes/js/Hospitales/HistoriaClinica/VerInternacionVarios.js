var NHC;
var IntId;

var selected = [];

$("#btnEvoPrint").click(function () {
    selected = [];
    $('#TablaResultados input:checked').each(function () {
        selected.push($(this).data("evoid"));
    });

    if (selected.length <= 0) {
        alert("Falta seleccionar alguna impresión.");
        return false;
    }

    Impresion();
});

function Impresion() {

    Pagina = "../Impresiones/At_Int_ImpresionEvolucion_ids.aspx?lineas=0" + "&Ids=" + selected + "&encabezado=1";
    $.fancybox(
		{
		    'autoDimensions': false,
		    'href': Pagina,
		    'width': '100%',
		    'height': '100%',
		    'autoScale': false,
		    'transitionIn': 'none',
		    'transitionOut': 'none',
		    'type': 'iframe',
		    'hideOnOverlayClick': false,
		    'enableEscapeButton': false
		}
	        );

}

$(document).ready(function () {
    var GET = {};
    document.location.search.replace(/\??(?:([^=]+)=([^&]*)&?)/g, function () {
        function decode(s) {
            return decodeURIComponent(s.split("+").join(" "));
        }

        GET[decode(arguments[1])] = decode(arguments[2]);
    });

    if (GET["NHC"] != "" && GET["NHC"] != null) {
        NHC = GET["NHC"];
        CargarPacienteID(NHC);
    }
    if (GET["IntId"] != "" && GET["IntId"] != null) {
        IntId = GET["IntId"];
        CargarDatosInt(IntId);
    }

});

function CargarDatosInt(Id) {
    $.ajax({
        type: "POST",
        url: "../Json/Internaciones/IntSSC.asmx/Egreso_Cargar",
        data: '{Id: "' + Id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var I = Resultado.d;
            var Egreso = I.dia;
            if (I.dia == null) { Egreso = "SIN EGRESO"; }
            $("#titulo1").html("Ingreso: " + I.diaIngreso + " - Egreso: " + Egreso);
        },
        error: errores
    });
}

function CargarPacienteID(ID) {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/CargarPacienteID",
        data: '{ID: "' + ID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Paciente_NHC_Cargado,
        error: errores
    });
}

function Cargar_Paciente_NHC_Cargado(Resultado) {
    var Paciente = Resultado.d;
    var PError = false;

    $.each(Paciente, function (index, paciente) {
        $("#CargadoApellido").html(paciente.Paciente);
        $("#CargadoEdad").html(paciente.Edad_Format);
        $("#CargadoDNI").html(paciente.documento_real);
        $("#CargadoNHC").html(paciente.NHC_UOM);
        $("#CargadoTelefono").html(paciente.Telefono);
        $("#CargadoSeccional").html(paciente.Seccional);

        $("#afiliadoId").val(paciente.documento);

        $("#Cod_OS").val(paciente.OSId);
        if (paciente.Nro_Seccional == 998) {
            $("#cbo_ObraSocial").show();
            $("#cboSeccional").hide();
            $("#Titulo_Seccional_o_OS").html("Ob. Social");
            $("#CargadoSeccionalTitulo").html("Ob. Social");
            $("#CargadoSeccional").html(paciente.ObraSocial);
        }
        else {
            $("#btnVencimiento").show();
        }

        $('#fotopaciente').attr('src', '../img/Pacientes/' + NHC + '.jpg');

    });
}

function imgErrorPaciente(image) {
    image.onerror = "";
    image.src = "../img/silueta.jpg";
    return true;
}

function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}


$(".opciones").click(function () {
    $("#btnEvoPrint").hide();
    if ($("#chkIM").is(":checked")) { CargarIM(); return; } //Indicaciones
    if ($("#chkEvo").is(":checked")) { CargarEvoluciones(); return; } //Evoluciones
    if ($("#chkEpi").is(":checked")) { Imprimir(IntId); $("#TablaResultados").empty(); return; } //Epicrisis
    if ($("#chkAlta").is(":checked")) { Imprimir(IntId); $("#TablaResultados").empty(); return; } //Alta Medica//
    if ($("#chkHojaQuirurgica").is(":checked")) { CargarHojaQuirurgicaUTI(IntId); $("#TablaResultados").empty(); return; } //Parte Quirurgico//
});



function CargarIM() {
    var json = JSON.stringify({"IdInt": IntId})
    $.ajax({
        type: "POST",
        url: "../Json/HistoriaClinica/HistoriaClinica.asmx/BuscarIM_by_Internacion",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: CargarIM_Cargado,
        error: errores
    });
}

function CargarIM_Cargado(Resultado) {
    var Lista = Resultado.d;
    $("#TablaResultados").empty();
    var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th>Fecha</th><th>Servicio</th><th>Sala</th><th>Cama</th><th>Médico</th></tr></thead><tbody>";
    var Contenido = "";
    $.each(Lista, function (i, IM) {
        Contenido = Contenido + "<tr onclick=Imprimir('" + IM.IM_Id + "')><td> " + IM.Fecha + " </td><td>" + IM.Servicio + "</td><td>" + IM.Sala + "</td><td> " + IM.Cama + " </td><td> " + IM.Medico + " </td></tr>";
    });
    var Pie = "</tbody></table>";
    $("#TablaResultados").html(Encabezado + Contenido + Pie);
}


function CargarHojaQuirurgicaUTI() {
    var json = JSON.stringify({ "Id": 0, "PacienteId": NHC, "InternacionId": IntId });

    $.ajax({
        type: "POST",
        url: "../Json/AtInternados/ListaPacientesInternados.asmx/AtInternados_Hoja_Quirurgica_Listar",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {


            var HojasCargadas = Resultado.d;
            $("#TablaResultados").empty();
            var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th>Fecha</th><th>Practica</th></tr></thead><tbody>";
            var Contenido = "";
            $.each(HojasCargadas, function (index, hoja) {
                Contenido = Contenido + "<tr onclick=Imprimir('" + hoja.PRQ_ID + "')><td>" + hoja.PRQ_FECHA + "</td><td> " + hoja.PRACTICA_DESCRIPCION + " </td></tr>";
            });
            var Pie = "</tbody></table>";
            $("#TablaResultados").html(Encabezado + Contenido + Pie);
            
        },
        error: errores
    });
}




function CargarEvoluciones() {
    $("#btnEvoPrint").show();
    var json = JSON.stringify({
        "Id": 0,
        "Internacion": IntId,
        "MedicoId" : 0
    });

    $.ajax({
        type: "POST",
        data: json,
        url: "../Json/AtInternados/ListaPacientesInternados.asmx/BuscarEvolucion",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: CargarEvoluciones_Cargados,
        error: errores
    });
}

function CargarEvoluciones_Cargados(Resultado) {
    var Evoluciones = Resultado.d;
    $("#TablaResultados").empty();
    var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%; font-size:11px;'><thead><tr><th></th><th>Fecha</th><th>Sala</th><th>Cama</th><th>Especialidad</th><th>Médico</th><th>Evolución</th></tr></thead><tbody>";
    var Contenido = "";
    $.each(Evoluciones, function (index, IM) {
        Contenido = Contenido + "<tr><td>" + "<input class='checks_Evo' type='checkbox' id='evo_id_" + IM.EId + "' data-evoid='" + IM.EId + "'/></td>"+ "<td>" + IM.fecha + " </td><td>" + IM.sala + "</td><td> " + IM.cama + " </td><td> " + IM.especialidad + " </td><td> " + IM.medico + " </td><td><div style='white-space:pre-wrap;'> " + IM.evoluciones + " </div></td></tr>";
    });
    var Pie = "</tbody></table>";
    $("#TablaResultados").html(Encabezado + Contenido + Pie);
}


function Imprimir(Id) {
    var Pagina = "";
    if ($("#chkIM").is(":checked")) Pagina = "../Impresiones/Print_Indicacion.aspx?Id=" + Id;
    if ($("#chkEpi").is(":checked")) {
        if ($("#esLegales").val() == "NO")
            Pagina = "../Impresiones/ImpresionEpicrisis.aspx?Id=" + Id;
        else {
            window.location = "../AtInternados/Epicrisis.aspx?IntId=" + Id + "&NHC=" + NHC + "&MedicoId=90001766";
            
        }
    }
    if ($("#chkAlta").is(":checked")) Pagina = "../Impresiones/Impresion_Alta_Medica.aspx?Id_Internacion=" + Id; // Alta Medica//
    if ($("#chkHojaQuirurgica").is(":checked")) Pagina = "../Impresiones/At_Int_Impresion_HojaQuirurgica.aspx?PRQ_ID=" + Id; // Hoja Quirurgica//
    $.fancybox({
		    'autoDimensions': false,
		    'href': Pagina,
		    'width': '100%',
		    'height': '100%',
		    'autoScale': false,
		    'transitionIn': 'none',
		    'transitionOut': 'none',
		    'type': 'iframe',
		    'hideOnOverlayClick': false,
		    'enableEscapeButton': false
    });
}
