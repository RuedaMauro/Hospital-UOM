$(document).ready(function () {
    $("#txtFechaInicio").datepicker();
    $("#txtFechaFin").datepicker();
    Cargar_Especialidades(true, 0, true);
    var currentDt = new Date();
    var mm = currentDt.getMonth() + 1;
    mm = (mm < 10) ? '0' + mm : mm;
    var yyyy = currentDt.getFullYear();
    var dia = currentDt.getDate() > 9 ? currentDt.getDate() : '0' + currentDt.getDate();
    var d = '01' + '/' + mm + '/' + yyyy;
    $("#txtFechaInicio").val(d);
    $("#txtFechaFin").val(fecha_ultimo_dia_mes(mm, yyyy));

});

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
        $('#cbo_Especialidad').append(
              $('<option></option>').val(especialidades.Id).html(especialidades.Especialidad)
            );
    });
}

$("#btn_Imprimir").click(function () {
    Imprimir("../Impresiones/Listados_Pacientes_Atendidos_Quilmes.aspx?Desde=" + $("#txtFechaInicio").val() + "&Hasta=" + $("#txtFechaFin").val() + "&Quilmes=" + $("#rdQuilmes").is(":checked") + "&EspId=" + $("#cbo_Especialidad :selected").val());
});

function Imprimir(Pagina) {
    $.fancybox(
		{
		    'autoDimensions': false,
		    'href': Pagina,
		    'width': '75%',
		    'height': '75%',
		    'autoScale': false,
		    'transitionIn': 'none',
		    'transitionOut': 'none',
		    'type': 'iframe',
		    'hideOnOverlayClick': false,
		    'enableEscapeButton': false,
		    'preload': true,
		    'onComplete': function f() {
		        jQuery.fancybox.showActivity();
		        jQuery('#fancybox-frame').load(function () {
		            jQuery.fancybox.hideActivity();
		        });
		    }

		}
	        );
}

function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}

$("#btn_Turnos").click(function () {
        var Pagina = "../Impresiones/ImpresionTurno.aspx?MedicoId=" + objUltimo.medicoid + "&EspecialidadId=" + objUltimo.especialidadid + "&Fecha=" + objUltimo.fecha + " " + objUltimo.hora + "&Ids=" + objTurnos;
        Imprimir(Pagina);
});

