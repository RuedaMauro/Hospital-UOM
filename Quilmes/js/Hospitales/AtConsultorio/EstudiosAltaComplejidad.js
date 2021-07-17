﻿
var MedicoId = 0;
var NHC = 0;
var Protocolo = 0;
var IntId = 0;

$("#btnCerrar").click(function () {
    parent.$.fancybox.close();
});

function CargarPacienteID(ID) {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/CargarPacienteID",
        data: '{ID: "' + ID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Paciente_Cargado,
        error: errores
    });
}

$("#btnBuscar").click(function () {
    self.location = "BuscarEstudiosAltaComplejidad.aspx?MedicoId=" + MedicoId + "&NHC=" + NHC + "&UOMID=" + $("#CargadoNHC").html();
}); 


function Cargar_Paciente_Cargado(Resultado) {
    var Paciente = Resultado.d;
    var PError = false;

    $.each(Paciente, function (index, paciente) {


        $("#btnCargar").show();
        $("#txt_dni").prop("readonly", true);
        $("#txtNHC").prop("readonly", true);

        $("#txt_dni").attr('value', paciente.documento_real);
        $("#txtNHC").attr('value', paciente.NHC_UOM);
        $("#afiliadoId").val(paciente.documento);

        if (paciente.Paciente.length > 20) $("#CargadoApellido").html(paciente.Paciente.substring(0, 19) + "...");
        else $("#CargadoApellido").html(paciente.Paciente);

        $("#CargadoEdad").html(paciente.Edad_Format);
        $("#CargadoDNI").html(paciente.documento_real);
        $("#CargadoNHC").html(paciente.NHC_UOM);
        $("#CargadoTelefono").html(paciente.Telefono);

        $("#CargadoLocalidad").html(paciente.localidad.substring(0, 15));


        if (paciente.Nro_Seccional != "999") {
            $("#CargadoSeccional").html(paciente.Seccional);
        }
        else {
            $("#CargadoSeccional").html("Sin Seccionalizar");
        }

        //$('#fotopaciente').attr('src', '../img/Pacientes/' + paciente.documento + '.jpg');
        $('#fotopaciente').attr('src', '../img/Pacientes' + paciente.Foto);

        if (PError) {
            $("#desdeaqui").hide();
        }
        else {
            $("#desdeaqui").show();
        }

        if (NHC != '' && NHC != null) {
            $("#btnCargar").click();
        }

    });
}

function MedicoDetalle(Id) {
    $.ajax({
        type: "POST",
        url: "../Json/Medicos.asmx/MedicoBuscar_Nombre",
        data: '{Id: "' + Id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            if (Resultado.d.Medico.trim().length > 0) {
                $("#lbl_Medico").html("Médico: " + Resultado.d.Medico);
                $("#lbl_Medico").css("margin-left","75px");
            }
        },
        error: errores
    });
}

function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}


$(document).ready(function () {

    var GET = {};

    document.location.search.replace(/\??(?:([^=]+)=([^&]*)&?)/g, function () {
        function decode(s) {
            return decodeURIComponent(s.split("+").join(" "));
        }

        GET[decode(arguments[1])] = decode(arguments[2]);
    });


    if (GET["ID"] != "" && GET["ID"] != null) {
        NHC = GET["ID"];
        CargarPacienteID(NHC);
    }

    if (GET["MedicoId"] != "" && GET["MedicoId"] != null) {
        MedicoId = GET["MedicoId"];
        MedicoDetalle(MedicoId);
    }

    if (GET["EstId"] != "" && GET["EstId"] != null) {
        Protocolo = GET["EstId"];
        CargarEstudio();
    }
    $(".Int").hide();

    if (GET["IntId"] != "" && GET["IntId"] != null) {
        IntId = GET["IntId"];
        $(".Int").show();
        CargarDatosInternacion(IntId);
    }

    $("#txt_Fecha").mask("99/99/9999", { placeholder: "-" });
    $("#txt_Fecha").datepicker();
    $("#txt_Fecha").val(FechaActual());

});

function CargarDatosInternacion(ID) {
    $.ajax({
        type: "POST",
        data: '{IntId: "' + ID + '"}',
        url: "../Json/Internaciones/IntSSC.asmx/InternacionResumen",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var inter = Resultado.d;
            $("#CargadoCama").html(inter.cama);
            $("#CargadoSala").html(inter.sala);
        },
        error: errores
    });
}

function CargarEstudio() {
    var json = JSON.stringify({"Protocolo":  Protocolo});
    $.ajax({
        type: "POST",
        url: "../Json/AtConsultorio/AtConsultorio.asmx/AltaComplejidad_byId",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var obj = Resultado.d;
            $("#txt_Fecha").val(obj.Fecha);
            $("#txt_Practicas").val(obj.Practica_Estudios);
            $("#txt_Estado").val(obj.Resumen_HC);
            $("#txt_Algoritmo").val(obj.Relacion_Algoritmo);
            $("#txt_Resultados").val(obj.Resultados);
            CargarPacienteID(obj.nhc);
            DesactivarControles();
        },
        error: errores
    });
}

function DesactivarControles() {
    $("#txt_Fecha").attr("disabled", true);
    $("#txt_Practicas").attr("disabled", true);
    $("#txt_Estado").attr("disabled", true);
    $("#txt_Algoritmo").attr("disabled", true);
    $("#txt_Resultados").attr("disabled", true);
    $("#btnGuardar").hide();
}

$('#fotopaciente').error(function () {
    $(this).attr('src', '../img/silueta.jpg');
});

$("#btnImprimir").click(function () {
    self.location = "../Impresiones/ImpresionOrdenesEstudios.aspx?Protocolo=" + Protocolo;
    parent.$("#fancybox-close").show();
});

function CargarData() { //Carga de datos para grabar en BD
    var obj = {};
    obj.id = Protocolo; // = 0 nuevo estudio, != 0 modificacion
    obj.nhc = NHC;
    obj.medicoid = MedicoId;
    obj.Fecha = $("#txt_Fecha").val().trim();
    obj.Practica_Estudios = $("#txt_Practicas").val().trim().toUpperCase();
    obj.Resumen_HC = $("#txt_Estado").val().trim().toUpperCase();
    obj.Relacion_Algoritmo = $("#txt_Algoritmo").val().trim().toUpperCase();
    obj.Resultados = $("#txt_Resultados").val().trim().toUpperCase();
    return obj;
}

function Validar() {
    if (NHC <= 0) { alert("Error en Paciente."); return false; }
    if (MedicoId <= 0) { alert("Error en Médico."); return false; }
    if ($("#txt_Fecha").val().trim().length == 0) { alert("Ingrese Fecha."); return false; }
    return true;
}

$("#btnGuardar").click(function () {

    if (!Validar()) return false;

    var obj = CargarData();
    var json = JSON.stringify({ "obj": obj });

    $.ajax({
        type: "POST",
        url: "../Json/AtConsultorio/AtConsultorio.asmx/At_Consultorio_AltaComplejidad_Guardar",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OrdenesEstudiosGuardados,
        error: errores
    });


});

function OrdenesEstudiosGuardados(Resultado) {
    var Id = Resultado.d;
    self.location = "../Impresiones/EstudioAltaComplejidad.aspx?Id=" + Id + "&IntId=" + IntId;
    parent.$("#fancybox-close").show();
}

