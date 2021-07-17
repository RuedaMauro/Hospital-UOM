﻿var Tipo = 1;
var Aceptar = 0;

$("#btn_RangoGenerar").click(function () {
    $("#btn_DyHGenerar").removeClass("active");
    Tipo = 1;
    MostrarPanel(1);
});

$("#btn_DyHGenerar").click(function () {
    $("#btn_RangoGenerar").removeClass("active");
    Tipo = 2;
    MostrarPanel(2);
});

$("#Generar1").click(function () {
    LimpiarError();
    var E = 0;
    if ($("#txtFechaDesde").val() == "") { $("#ControltxtFechaDesde").addClass("error"); E = 1; }
    //if ($("#cbo_Especialidad :selected").val() == "0") { $("#ControlEspecialidad").addClass("error"); $("#ControlMedico").addClass("error");  E = 1; }
    //if ($("#cbo_Medico :selected").val() == "0") { $("#ControlMedico").addClass("error"); E = 1; }    
    if ($("#txtFechaHasta").val() == "") { $("#ControltxtFechaHasta").addClass("error"); E = 1; }
    if (E == 0) { GenerarTurnos(); } else { alert("Revise los campos Marcados"); }
});

$("#Generar2").click(function () {
    LimpiarError();
    var E = 0;
    if ($("#cbo_Especialidad :selected").val() == "0") { $("#ControlEspecialidad").addClass("error"); $("#ControlMedico").addClass("error"); E = 1; }
    if ($("#cbo_Medico :selected").val() == "0") { $("#ControlMedico").addClass("error"); E = 1; }
    if ($("#txtDia").val() == "") { $("#ControltxtDia").addClass("error"); E = 1; }
    if ($("#txtDuracionTurno").val() == "") { $("#ControltxtDuracionTurno").addClass("error"); E = 1; }
    if ($("#txtHoraInicio").val() == "") { $("#ControltxtHoraInicio").addClass("error"); E = 1; }
    if ($("#cbo_Consultorio").val() == "0") { $("#Controlcbo_Consultorio").addClass("error"); E = 1; }
    if (E == 0) { GenerarTurnos(); } else { alert("Revise los campos Marcados"); }
});


function MostrarPanel(p) {

    if (p == 1) {
        $("#pn_Rango").show();
        $("#pn_Dias").hide();
    }
    else {
        $("#pn_Rango").hide();
        $("#pn_Dias").show();
    }
}

function Cargar_Especialidades(Todos, Id, SoloTurnos) {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/Especialidades_Lista",
        data: '{Todas: "' + Todos + '", Id: "' + Id + '", SoloTurnos: "' + SoloTurnos + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Especialidad_Cargadas,
        error: errores
    });
}

function Especialidad_Cargadas(Resultado) {
    var Especialidad = Resultado.d;
    $('#cbo_Especialidad').empty();
    $('#cbo_Especialidad').append('<option value="0">Todas</option>');
    $.each(Especialidad, function (index, especialidades) {

    //con esto no se muestra IMAGENES
        if (especialidades.Id != 339 && especialidades.Id != 340 && especialidades.Id != 341 && especialidades.Id != 342 && especialidades.Id != 343) {
            //con esto no se muestra IMAGENES
            $('#cbo_Especialidad').append(
              $('<option></option>').val(especialidades.Id).html(especialidades.Especialidad)
            );
            //con esto no se muestra IMAGENES
        }
        //con esto no se muestra IMAGENES
    });
}

function LimpiarError() {
    $("#ControlEspecialidad").removeClass("error");
    $("#ControlMedico").removeClass("error");
    $("#ControltxtFechaDesde").removeClass("error");
    $("#ControlEspecialidad").removeClass("error");
    $("#ControlMedico").removeClass("error");
    $("#ControltxtFechaHasta").removeClass("error");
    $("#ControltxtDia").removeClass("error");
    $("#ControltxtDuracionTurno").removeClass("error");
    $("#ControltxtHoraInicio").removeClass("error");
    $("#Controlcbo_Consultorio").removeClass("error");
}

$('#cbo_Especialidad').change(function () {
    LimpiarError();
    $("#TablaTurnos").empty();
    Cargar_Medicos_por_Especialidad($(this).val(), 'A');
});

$('#cbo_Medico').change(function () {
    LimpiarError();
});

function Cargar_Medicos_por_Especialidad(Especialidad,Tipo) {
    var json = JSON.stringify({ "Especialidad": Especialidad, "Tipo": Tipo });
    $.ajax({
        type: "POST",
        //url: "../Json/DarTurnos.asmx/Medico_Lista_por_Especialidad_SoloActivos",
        //data: '{Especialidad: "' + Especialidad + '"}',
        url: "../Json/DarTurnos.asmx/Medico_Lista_por_Especialidad_SoloActivosTipo",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Medicos_por_Especialidad_Cargados,
        error: errores
    });

}

function Medicos_por_Especialidad_Cargados(Resultado) {
    var Medicos = Resultado.d;
    $('#cbo_Medico').empty();
    $('#cbo_Medico').append('<option value="0">Todos</option>');
    $.each(Medicos, function (index, medicos) {
        $('#cbo_Medico').append(
              $('<option></option>').val(medicos.Id).html(medicos.Medico)
            );
    });
}

$(document).ready(function () {
    Cargar_Especialidades(true, 0, true);
    CargarConsultorios();
    $("#txtFechaDesde").datepicker();
    $("#txtFechaHasta").datepicker();
    $("#txtDia").datepicker();

    $("#txtFechaDesde").mask("99/99/9999", { placeholder: "-" });
    $("#txtFechaHasta").mask("99/99/9999", { placeholder: "-" });
    $("#txtDia").mask("99/99/9999", { placeholder: "-" });

    $("#txtDuracionTurno").mask("9?99");

    $("#txtHoraInicio").mask("99:99", { placeholder: "-" });
    $("#txtHoraFin").mask("99:99", { placeholder: "-" });

    var currentDt = new Date();
    var mm = currentDt.getMonth() + 1;
    mm = (mm < 10) ? '0' + mm : mm;
    var yyyy = currentDt.getFullYear();
    var dia = currentDt.getDate() > 9 ? currentDt.getDate() : '0' + currentDt.getDate();
    var d = dia + '/' + mm + '/' + yyyy;
    var p = '01' + '/' + mm + '/' + yyyy;
    $("#txtFechaDesde").val(d);
    $("#txtFechaHasta").val(fecha_ultimo_dia_mes(mm, yyyy));
    $("#txtDia").val(d);
});


$('#txtHoraInicio').change(function () {
    VerificarHora("txtHoraInicio");
});

$('#txtHoraFin').change(function () {
    VerificarHora("txtHoraFin");
});


function VerificarHora(objTexto) {
    ErrorHora = false;
    var hora = $('#' + objTexto).val();
    if ($('#' + objTexto).val().length == 5) {

        var h1 = hora.charAt(0);
        var h2 = hora.charAt(1);
        var dp = hora.charAt(2);
        var m1 = hora.charAt(3);

        if ((h1 == 2 && h2 > 3) || (h1 > 2)) { ErrorHora = true; }
        if (m1 > 5) { ErrorHora = true; }
        if (dp != ":") { ErrorHora = true; }
        if (ErrorHora) {
            $('#' + objTexto).val("");
        }
    }
}

function CargarConsultorios() {
    $.ajax({
        type: "POST",
        url: "../Json/Turnos/Consultorios.asmx/Consultorio_Lista_DA",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: CargarConsultorios_Cargados,
        error: errores
    });
}


function CargarConsultorios_Cargados(Resultado) {

    var Consultorios = Resultado.d;
    $('#cbo_Consultorio').empty();
    $('#cbo_Consultorio').append('<option value="0">Seleccione un Consultorio</option>');
    $.each(Consultorios, function (index, consultorios) {
        $('#cbo_Consultorio').append(
              $('<option></option>').val(consultorios.ConsultorioID).html(consultorios.Consultorio)
            );
    });
}

function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}

function GenerarTurnos() {

    var json = JSON.stringify({
        "medicoId": $("#cbo_Medico :selected").val(),
        "EspecialidadId": $("#cbo_Especialidad :selected").val(),
        "FechaDesde": $("#txtDia").val(),
        "FechaHasta": "",
        "HoraInicio": $("#txtHoraInicio").val(),
        "HoraFin": $("#txtHoraFin").val(),
        "Duracion": $("#txtDuracionTurno").val(),
        "ConsultorioId": $("#cbo_Consultorio :selected").val(),
        "Tipo": 2 //Tipo Dia y Hora Especifico
    });
    $.ajax({
        type: "POST",
        url: "../Json/Turnos/GenerarTurnos.asmx/Guardar_Dias_Atencion",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Guardado,
        error: errores,
        beforeSend: function () {
            $("#Generar1").attr("disabled", true);
            $("#div_generar").hide();
            $("#cargando").show();
        },
        complete: function () {
            $("#Generar1").removeAttr("disabled");
            $("#div_generar").show();
            $("#cargando").hide();
        }
    });
}

function Guardado(Resultado) {
    alert(Resultado.d);
    document.location = "Generacion_Turno_DiayHora.aspx";
}


