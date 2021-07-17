var Anio_Actual = 0;
var Mes_Actual = 0;
var Seccion_Actual = 0;
var NHC = 0;
var IntId = 0;
var Consultorio = 0;
var Guardia = 0;
var Lista = 0;
var InterCons = 0;
var Med = 0;
var Esp = 0;
var Ind = 0;
var IdGuardia = 0;
var IDInter = -1;
var PacienteId = 0;
var objBusquedaLista = "";
var Compras = 0;

$("#btnOpciones").click(function () {
    $("#myModalOpciones").modal('show');
});

////OPCIONES////

function AltaComplejidad() {
    //var Pagina = "../Impresiones/EstudioAltaComplejidad.aspx ";
    var Pagina = "../AtConsultorio/EstudiosAltaComplejidad.aspx?ID=" + $("#afiliadoId").val() + "&MedicoId=" + $("#medicoId").val() + " ";
    Pagina = Pagina.slice(0, -1);
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
		    'enableEscapeButton': false,
		    'showCloseButton': true
		}
	        );
}

function CertificadoMedico() {
    var Pagina = "../Impresiones/CertificadoMedicoN.aspx?ID=" + $("#afiliadoId").val() + "&MedicoId=" + $("#medicoId").val() + " ";
    Pagina = Pagina.slice(0, -1);
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
		    'enableEscapeButton': false,
		    'showCloseButton': true
		}
	        );
}


function CargadeEstudios(Id) {
    var Pagina = "../AtConsultorio/CargadeEstudios.aspx?NHC=" + $("#afiliadoId").val() + "&MedicoId=" + $("#medicoId").val() + " ";
    Pagina = Pagina.slice(0, -1);
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
		    'enableEscapeButton': false,
		    'showCloseButton': false
		}
	        );
}

function SolicituddeTraslado() {
    var Pagina = "../AtConsultorio/SolicituddeTraslado.aspx?NHC=" + $("#afiliadoId").val() + "&MedicoId=" + $("#medicoId").val() + " ";
    Pagina = Pagina.slice(0, -1);
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
		    'enableEscapeButton': false,
		    'showCloseButton': false
		}
	        );
}


function Receta() {
    var Pagina = "../AtConsultorio/Receta.aspx?NHC=" + $("#afiliadoId").val() + "&MedicoId=" + $("#medicoId").val() + "&EspId=" + 0 + " ";
    Pagina = Pagina.slice(0, -1);
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
		    'enableEscapeButton': false,
		    'showCloseButton': false
		}
	        );
}



function OrdenesInternacion() {
    var Pagina = "../AtConsultorio/OrdenInternacion.aspx?NHC=" + $("#afiliadoId").val() + "&MedicoId=" + $("#medicoId").val() + " ";
    Pagina = Pagina.slice(0, -1);
    $.fancybox(
		{
		    'autoDimensions': false,
		    'href': Pagina,
		    'showCloseButton': false,
		    'width': '100%',
		    'height': '110%',
		    'autoScale': false,
		    'transitionIn': 'none',
		    'transitionOut': 'none',
		    'type': 'iframe',
		    'hideOnOverlayClick': false,
		    'enableEscapeButton': false
		}
	        );
}


//NHC=337572&MedicoId=80000437&EspecialidadId=191&F=06/05/2015%2018:00
function ConsultaG() {
    var Pagina = "../AtConsultorio/Consulta_General.aspx?NHC=" + $("#afiliadoId").val() + "&MedicoId=" + $("#medicoId").val() + "&EspecialidadId=0&F=" + $("#Fecha_Hora").val() + " ";
    Pagina = Pagina.slice(0, -1);
    $.fancybox({
		    'autoDimensions': false,
		    'href': Pagina,
		    'showCloseButton': false,
		    'width': '100%',
		    'height': '110%',
		    'autoScale': false,
		    'transitionIn': 'none',
		    'transitionOut': 'none',
		    'type': 'iframe',
		    'hideOnOverlayClick': false,
		    'enableEscapeButton': false
		});
}

////OPCIONES////



function InicioSesion() {
    alert("Error: Inicie Sesión Nuevamente.");
    parent.document.location = "../Login.aspx";
}

function ObtenerMedico() {
    $.ajax({
        type: "POST",
        url: "../Json/HistoriaClinica/HistoriaClinica.asmx/MedicoporUsuario",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            if (Resultado.d > 0) { $("#btnOpciones").show(); $("#medicoId").val(Resultado.d); return; }
            if (Resultado.d == 0) { $("#btnOpciones").hide(); return; } //No tiene relacion con ningun medico.
            if (Resultado.d == -1) { $("#btnOpciones").hide(); InicioSesion(); return; } //Perdio Sesion.
        },
        error: errores
    });
}

$(document).ready(function () {

    $('.tree li').each(function () {
        if ($(this).children('ul').length > 0) {
            $(this).addClass('parent');
        }
    });

    $('.tree li.parent > a').click(function () {
        $(this).parent().toggleClass('active');
        $(this).parent().children('ul').slideToggle('fast');
    });


    var GET = {};


    document.location.search.replace(/\??(?:([^=]+)=([^&]*)&?)/g, function () {
        function decode(s) {
            return decodeURIComponent(s.split("+").join(" "));
        }

        GET[decode(arguments[1])] = decode(arguments[2]);
    });

    ObtenerMedico();

    if (GET["NHC"] != "" && GET["NHC"] != null) {
        NHC = GET["NHC"];
        CargarPacienteID(NHC);
    }
    if (GET["IntId"] != "" && GET["IntId"] != null) {
        IntId = GET["IntId"];
        parent.document.getElementById("DondeEstoy").innerHTML = "Internación > Pacientes Internados > <strong>Historia Clínica Detallada</strong>";
    }
    if (GET["Cons"] != "" && GET["Cons"] != null) { //Viene de consultorio
        Consultorio = 1;
        parent.document.getElementById("DondeEstoy").innerHTML = "Consultorio > <strong>Historia Clínica > Detallada</strong>";
    }
    if (GET["Guardia"] != "" && GET["Guardia"] != null) { //Viene de Guardia
        Guardia = 1;
        IdGuardia = GET["Id"];
        parent.document.getElementById("DondeEstoy").innerHTML = "Guardia > <strong>Historia Clínica > Detallada</strong>";
    }

    if (GET["Lista"] != "" && GET["Lista"] != null) { //Viene de Paciente del Dia
        Lista = GET["Lista"];
        Med = GET["Med"];
        Esp = GET["Esp"];
        Ind = GET["Ind"]; //Index del pac selec
        parent.document.getElementById("DondeEstoy").innerHTML = "Consultorio > Pacientes del Día > <strong>Historia Clínica Detallada</strong>";
    }

    if (GET["InterID"] != "" && GET["InterID"] != null) { //Viene de Interconsultas
        InterCons = 1;
        Med = GET["Med"];
        Esp = GET["Esp"];
        IDInter = GET["InterID"];
        parent.document.getElementById("DondeEstoy").innerHTML = "Internación > <strong>Interconsultas solicitadas</strong>";
    }

    if (GET["B"] != "" && GET["B"] != null) { //At Internados, lista Servicios
        objBusquedaLista = GET["B"];
    }


    if (GET["C"] != "" && GET["C"] != null) {
        Compras = GET["C"];
    }

});


function CargarAnio(Anio, Seccion) {    
    Seccion_Actual = Seccion;
    Anio_Actual = Anio;
    CargarConsultaResumen();
    
}


function CargarAnioyMes(Anio, Mes, Seccion) {
    Seccion_Actual = Seccion;
    Anio_Actual = Anio;
    Mes_Actual = Mes;
    CargarConsultaResumen();    
}



function CargarConsultaResumen() {

    var json = "";
    var laUrl = "";

    if (Seccion_Actual == 1) {
        json = JSON.stringify({"nhc": NHC,"anio": Anio_Actual});
        laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Internacion_Datos";
        $("#TablaAmbulatorio").hide();
        $("#TablaCirugia").hide();
        $("#TablaInternacion").show();
        $("#TablaRecetas").hide();
        $("#TablaLaboratorio").hide();
        $("#TablaInterconsultas").hide();
        $("#TablaImagenes").hide();
        $("#TablaAnatomiaPatologica").hide();
        $("#TablaEndoscopia").hide();
        $(".DatoHistoriaClinica").html("Registro de Internaciones - " + Anio_Actual);
    }
    
    
    if (Seccion_Actual == 2) { 
            json = JSON.stringify({"nhc": NHC,"anio": Anio_Actual});
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Cirugia_Datos";
            $("#TablaAmbulatorio").hide();
            $("#TablaInternacion").hide();
            $("#TablaCirugia").show();
            $("#TablaRecetas").hide();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Cirugias - " + Anio_Actual);
            }

        if (Seccion_Actual == 3) { 
            json = JSON.stringify({"nhc": NHC,"anio": Anio_Actual, "mes": Mes_Actual});
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Ambulatorio_Datos";
            $("#TablaInternacion").hide();
            $("#TablaCirugia").hide();
            $("#TablaAmbulatorio").show();
            $("#TablaRecetas").hide();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Antecedentes Ambulatorios - " + ObtenerMes(Mes_Actual) + " de " + Anio_Actual);
        }

        if (Seccion_Actual == 4) { //Recetas
            json = JSON.stringify({ "nhc": NHC, "anio": Anio_Actual });
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Recetas_Datos";
            $("#TablaInternacion").hide();
            $("#TablaCirugia").hide();
            $("#TablaAmbulatorio").hide();
            $("#TablaRecetas").show();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Recetas de Medicamentos - " + Anio_Actual);
        }

        if (Seccion_Actual == 5) { //Guardia
            json = JSON.stringify({ "nhc": NHC, "anio": Anio_Actual });
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Guardia_Datos";
            $("#TablaInternacion").hide();
            $("#TablaCirugia").hide();
            $("#TablaAmbulatorio").hide();
            $("#TablaRecetas").show();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Atención en Guardia - " + Anio_Actual);
        }

        if (Seccion_Actual == 6) { //Labo
            json = JSON.stringify({ "nhc": NHC, "anio": Anio_Actual }); //Mando el afiliadoID para buscar los protocolos de ese pac y de ese año
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Labo_Datos";
            $("#TablaInternacion").hide();
            $("#TablaCirugia").hide();
            $("#TablaAmbulatorio").hide();
            $("#TablaRecetas").hide();
            $("#TablaLaboratorio").show();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Protocolos de Laborotorio - " + Anio_Actual);
        }

        if (Seccion_Actual == 7) { //Interconsultas
            json = JSON.stringify({ "nhc": NHC, "anio": Anio_Actual });
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Interconsultas_Datos";
            $("#TablaInternacion").hide();
            $("#TablaCirugia").hide();
            $("#TablaAmbulatorio").hide();
            $("#TablaRecetas").hide();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").show();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Interconsultas - " + Anio_Actual);
        }


        if (Seccion_Actual == 8) { //IMAGENES
            //PacienteId
            //json = JSON.stringify({ "nhc": NHC, "anio": Anio_Actual });
            json = JSON.stringify({ "nhc": PacienteId, "anio": Anio_Actual, "PacienteId": $("#afiliadoId").val() });
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Imagenes_Datos";
            $("#TablaInternacion").hide();
            $("#TablaCirugia").hide();
            $("#TablaAmbulatorio").hide();
            $("#TablaRecetas").hide();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").show();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Diagnóstico por Imágenes - " + Anio_Actual);
        }

        if (Seccion_Actual == 9) { //ANATOMIA PATOLOGICA
            //PacienteId
            //json = JSON.stringify({ "nhc": NHC, "anio": Anio_Actual });
 
            json = JSON.stringify({ "nhc": PacienteId, "anio": Anio_Actual });
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/AnatomiaPatologica_Datos";
            $("#TablaInternacion").hide();
            $("#TablaCirugia").hide();
            $("#TablaAmbulatorio").hide();
            $("#TablaRecetas").hide();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").show();
            $("#TablaEndoscopia").hide();
            $(".DatoHistoriaClinica").html("Anatomía Patológica - " + Anio_Actual);
        }

        //ENDOSCOPIA
        if (Seccion_Actual == 10) {
            json = JSON.stringify({ "nhc": NHC, "anio": Anio_Actual });
            laUrl = "../Json/HistoriaClinica/HistoriaClinica.asmx/Endoscopia_Datos";
            $("#TablaAmbulatorio").hide();
            $("#TablaCirugia").hide();
            $("#TablaInternacion").hide();
            $("#TablaRecetas").hide();
            $("#TablaLaboratorio").hide();
            $("#TablaInterconsultas").hide();
            $("#TablaImagenes").hide();
            $("#TablaAnatomiaPatologica").hide();
            $("#TablaEndoscopia").show();
            $(".DatoHistoriaClinica").html("Registro de Endoscopias - " + Anio_Actual);
        }

        $.ajax({
            type: "POST",
            data: json,
            url: laUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                $("#cargando").show();
                $(".contenido").hide();
            },
            complete: function () {
                $("#cargando").hide();
                $(".contenido").show();
            },
            success: CargarConsultaResumen_Cargadas,
            error: errores
        });
}

function ObtenerMes(Mes) {
    if (Mes != 0) {
        var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
        return meses[Mes - 1];
    }
    else {
        return "";
    }
}

function CargarConsultaResumen_Cargadas(Resultado) {

    var Practicas = Resultado.d;
    $('#TInternacion').empty();
    $('#TCirugia').empty();
    $('#TAmbulatorio').empty();
    $('#TRecetas').empty();
    $('#TLabo').empty();

    var Datos = "";
    if (Seccion_Actual == 1) {
        $.each(Practicas, function (index, p) {
            var ioe = 2;
            if (p.egreso == null || p.egreso == '')
            {
                ioe = 1;
            }
            Datos = Datos + "<tr onclick='javascript:Imprimir(1," + p.id + "," + ioe + ");' class='mano'><td>" + p.ingreso + "</td><td>" + p.egreso + "</td><td>" + p.servicio + "</td><td>" + p.motivoingreso + "</td><td>" + p.motivoegreso + "</td><td>" + p.especialidad + "</td><td>" + p.medico + "</td></tr>";
        });
        $('#TInternacion').html(Datos);
    }

    if (Seccion_Actual == 2) {
        $.each(Practicas, function (index, p) {
            Datos = Datos + "<tr onclick='javascript:Imprimir(2," + p.id + ",0);' class='mano'><td>" + p.fecha + "</td><td>" + p.cirugia + "</td><td>" + p.medico + "</td><td>" + p.diagnostico + "</td><td>" + p.especialidad + "</td></tr>";
        });
        $('#TCirugia').html(Datos);
    }

    if (Seccion_Actual == 3) {
        $.each(Practicas, function (index, p) {
            var T = 1;
            if (p.tipo == "D") { T = 2; }
            if (p.tipo == "GU") { T = 4; }
            if (p.tipo == "NEO") { T = 5; }
            Datos = Datos + "<tr onclick='javascript:ImprimirAmb(" + p.id + "," + T + ");' class='mano'><td>" + p.fecha + "</td><td>" + p.especialidad + "</td><td>" + p.medico + "</td><td>" + p.diagnostico + "</td></tr>";
        });
        $('#TAmbulatorio').html(Datos);
    }

    if (Seccion_Actual == 4) {
        $.each(Practicas, function (index, p) {
            Datos = Datos + "<tr onclick='javascript:Imprimir(4," + p.id + ",0);' class='mano'><td>" + p.fecha + "</td><td>" + p.especialidad + "</td><td>" + p.medico + "</td><td>" + p.diagnostico + "</td></tr>";
        });
        $('#TRecetas').html(Datos);
    }

    if (Seccion_Actual == 5) {
        $.each(Practicas, function (index, p) {
            Datos = Datos + "<tr onclick='javascript:Imprimir(5," + p.id + ",0);' class='mano'><td>" + p.fecha + "</td><td>" + p.especialidad + "</td><td>" + p.medico + "</td><td>" + p.diagnostico + "</td></tr>";
        });
        $('#TRecetas').html(Datos);
    }

    if (Seccion_Actual == 6) {
        $.each(Practicas, function (index, p) {
            Datos = Datos + "<tr onclick='javascript:Imprimir(6," + index + ",0);' class='mano'><td>"+p.protocolo+"</td><td>" + p.fecha + "</td><td style='display:none;' id='proto" + index + "'>" + p.ruta + "</td></tr>";
        });
        $('#TLabo').html(Datos);
    }

    if (Seccion_Actual == 7) { //Interconsultas
        $.each(Practicas, function (index, p) {
            Datos = Datos + "<tr onclick='javascript:Imprimir(7," + p.id + ",0);' class='mano'><td>" + p.fecha + "</td><td>" + p.medsol + "</td><td>" + p.espinter + "</td><td>" + p.medinter + "</td><td>" + p.motivo + "</td></tr>";
        });
        $('#TInter').html(Datos);
    }


    if (Seccion_Actual == 8) { //Imagenes
        $.each(Practicas, function (index, p) {            
            if (p.IMG_PATH.indexOf(".DOC") > -1) {
                Datos = Datos + "<tr onclick='javascript:Word(this)'; data-word='" + p.IMG_PATH + "'; class='mano'><td>" + p.IMG_FECHA_INICIO + "</td><td>" + p.TIMG_DESCRIPCION + "</td></tr>";
            }
            else {
                //Datos = Datos + "<tr onclick='javascript:Imprimir(8, " + p.IMG_PATH + ", " + p.IMG_NUMERO + ")'; class='mano'><td>" + p.IMG_FECHA_INICIO + "</td><td>" + p.TIMG_DESCRIPCION + "</td></tr>";
                //com.pixeon.launch://10.84.3.7:80/arya?login=prueba&password=prueba&PatientId=40492519&AccessionNumber=
                //Datos = Datos + "<tr onclick='javascript:Imprimir(8, " + p.IMG_PATH + ", " + p.IMG_NUMERO + ")'; class='mano'><td>" + p.IMG_FECHA_INICIO + "</td><td>" + p.TIMG_DESCRIPCION + "</td></tr>";

                var IMAGEN_LINK = "";
                if (p.WORK_LIST_NUMERO != "") {
                    IMAGEN_LINK = "<a href='com.pixeon.launch://10.10.8.169:80/arya?login=rayos&password=rayos&PatientId=&AccessionNumber=" + p.WORK_LIST_NUMERO + "' class='mano'>Imagen</a>";
                }

                Datos = Datos + "<tr><td><a onclick='javascript:Imprimir(8, " + p.IMG_PATH + ", " + p.IMG_NUMERO + ")'; class='mano'>Informe</a> " + IMAGEN_LINK + "</td><td>" + p.IMG_FECHA_INICIO + "</td><td>" + p.TIMG_DESCRIPCION + "</td></tr>";
            }
        });
        $('#TImg').html(Datos);
    }

    if (Seccion_Actual == 9) { //Anatomia Patologica
        $.each(Practicas, function (index, p) {
            Datos = Datos + "<tr onclick='javascript:Imprimir(9," + p.PAT_NUMERO + ",0);' class='mano'><td>" + p.PAT_FECHA_INICIO + "</td><td>" + p.PMAT_DESCRIPCION + "</td><td>" + p.MED_APELLIDO_NOMBRE + "</td></tr>";
        });
        $('#TAnaPato').html(Datos);
    }

    if (Seccion_Actual == 10) {
        $.each(Practicas, function (index, p) {
            Datos = Datos + "<tr onclick='javascript:Imprimir(10," + p.id + ",0);' class='mano'><td>" + p.fecha + "</td><td>" + p.cirugia + "</td><td>" + p.medico + "</td><td>" + p.diagnostico + "</td><td>" + p.especialidad + "</td></tr>";
        });
        $('#TEndo').html(Datos);
    }
}


function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}


function Word(cual) {

    var Pagina = "http://" + $(cual).data("word");
    //Imagenes                
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

function Imprimir(seccion, Id, ioe) {
    var Pagina = "";
    if (seccion == '1') {
        //Internacion
        Pagina = "../HistoriaClinica/VerInternacionVarios.aspx?IntId=" + Id + "&NHC=" + $("#afiliadoId").val() + " "; //Para ver IM, Epicrisis, Evolucion.

    }

    if (seccion == '2') {
        //Ciru
        Pagina = "../Impresiones/Quirofano_Protocolo.aspx?Cirugia_Id=" + Id + "&Id=" + Id + " ";
    }

    //Recetas
    if (seccion == '4') Pagina = "../Impresiones/Recetario.aspx?Protocolo=" + Id + " ";

    if (seccion == '5') Pagina = "../Impresiones/GuardiaAtencionPrint.aspx?Id=" + Id + " ";

    if (seccion == '6') {

        Pagina = $("#proto" + Id).html();
    }

    if (seccion == '7') {

        Pagina = "../Impresiones/ImpresionInterconsulta.aspx?Id=" + Id + " ";
    }

    if (seccion == '8') {
        if (ioe >= 6) {
            Pagina = "../Impresiones/Impresiones_IMG/IMG_Informe.aspx?TurnoId=" + Id + " ";
        }
        else {
            alert("El estudio no ha sido informado.");
            return;
        }
    }


    if (seccion == '9') {

        Pagina = "../Impresiones/Anatomia_Patologica/AP_HC.aspx?Protocolo=" + Id + " "; ;
    }

    if (seccion == '10') {
        //Endoscopia
        Pagina = "../HistoriaClinica/VerEndoscopiaVarios.aspx?IntId=" + Id + "&NHC=" + $("#afiliadoId").val() + " "; //Para ver IM, Epicrisis, Evolucion.

    }

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




function ImprimirAmb(Id, Tipo) {
    var Pagina = "";

    if (Tipo == 2) {
        Pagina = "../Impresiones/CDDiabetes.aspx?Protocolo=" + Id + " ";
    }

    if (Tipo == 1) {
        Pagina = "../Impresiones/CDGeneral.aspx?Protocolo=" + Id + " ";
    }

    if (Tipo == 3) {
        Pagina = "../Impresiones/Guardia.aspx?Protocolo=" + Id + " ";
    }

    if (Tipo == 4) {
        Pagina = "../Impresiones/GuardiaAtencionPrint.aspx?Id=" + Id + " ";
    }

    if (Tipo == 5) {
        Pagina = "../Impresiones/Impresion_Neo.aspx?Protocolo=" + Id + " ";
    }

    Pagina = Pagina.slice(0, -1);
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


function Cargar_Paciente_NHC(NHC) {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/CargarPacienteNHC_UOM",
        data: '{NHC: "' + NHC + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Paciente_NHC_Cargado,
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
        complete: function () {
            $("#mostrarantecedentes").click();
        },
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
        $("#cbo_TipoDOC").val(paciente.TipoDoc);

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

        //$('#fotopaciente').attr('src', '../img/Pacientes/' + NHC + '.jpg');
        $('#fotopaciente').attr('src', '../img/Pacientes' + paciente.Foto);
        //PacienteId = paciente.Soc_Id;
        PacienteId = paciente.documento;
    });
}

function imgErrorPaciente(image) {
    image.onerror = "";
    image.src = "../img/silueta.jpg";
    return true;
}


$('#mostrarantecedentes').click(function () {
    $('.MenuHistoriaClinica').fadeIn(1000);
    $('.MenuHistoriaClinica').animate({ 'margin-left': '0' });
});


$('#cerrarantecedentes').click(function () {
    $('.MenuHistoriaClinica').fadeOut(1000);
    $('.MenuHistoriaClinica').animate({ 'margin-left': '-250' });
});


$("#btnVolver").click(function () {
    if (Lista == 1) { document.location = "../AtConsultorio/PacientesDelDia.aspx?Esp=" + Esp + "&Med=" + Med + "&Ind=" + Ind + "&NHC=" + NHC; return; }
    if (Guardia == 1) { document.location = "../Guardia/Listado.aspx?Id=" + IdGuardia; return; }
    if (InterCons == 1) { document.location = "../AtInternados/InterconsultaMedico.aspx?IDInter=" + IDInter + "&Esp=" + Esp + "&Med=" + Med; return; }
    if (Consultorio == 0) document.location = "../AtInternados/ListaPacientesInternados.aspx?V=1&Int=" + IntId + "&B=" + objBusquedaLista;
    if (Compras == 1) document.location = "../Compras/Compras_Auditar_Pedidos.aspx";
    else document.location = "../HistoriaClinica/BuscarPacienteHC.aspx";
});