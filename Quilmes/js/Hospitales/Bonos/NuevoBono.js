var Practicas = new Array();
var Total = -1;
var i = 0;
var Editando = 0;
var EditandoPos = 0;
var Actual = "";
var Hora = "";
var MedicoID = "";
var EspecialidadId = "";
var Fecha = "";
var TurnoTelefonico = false;
var CUIL = "";
var MedicoId = 0;
var objPracticas = new Array();
var Moneda = /^(-)?\d+(\.\d\d)?$/;
var TurnoAutorizanteId = "0";
var TurnoPrimeraVez = false;
var TurnoEmiteBono = false;
var TurnoEmiteComprobante = false;
var Recepcionaturno = false;
var FechaTurno = "";
var EsAtencionSinTurno = false;
var Cod_OS = 0;
var Impreso = 0;
var CertificadoMostrado = false;
var Internado = 0;
var Ultimo_OK = 0;
var nopaga = false;
var Observaciones = "";
var EsMonotributo = false;

$(".numero").on('keydown', function (e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

Cargar_Seccionales_Lista();
Cargar_Especialidades(false, 0, false);
var modal_ver = 0;

function ExisteTurno(AfiliadoId) { //Verifico que el paciente tenga un turno sin usar en el dia de la fecha.
    var json = JSON.stringify({ "AfiliadoId": AfiliadoId });
    $.ajax({
        type: "POST",
        url: "../Json/Bonos/Bonos.asmx/Existe_Turno",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var Turnos = Resultado.d;
            if (modal_ver == 1) return false;
            if (Turnos.length > 0) {
                if (confirm("El paciente tiene turnos para el dia de hoy.\nDesea visualizarlos?")) {
                    $("#ModalTurnos").modal('show');
                    CargarGrilla(Turnos);
                }
                modal_ver = 1;
            }
        }
    });
}




function CargarGrilla(lista) {
    var Tabla_Titulo = "";
    var Tabla_Datos = "";
    var Tabla_Fin = "";
    if (lista != null) {
        Tabla_Titulo = "<table id='ListaTurnos' class='table table-hover table-condensed'><thead><tr><th>Fecha</th><th>Hora</th><th>Médico</th><th>Especialidad</th></tr></thead><tbody>";
        $.each(lista, function (index, turnos) {
            Tabla_Datos = Tabla_Datos + "<tr onclick='CargarDatosTurno(" + index + ")'; title='Click para cargar datos'";
            Tabla_Datos = Tabla_Datos + "><td id='tdFecha" + index + "'>" + turnos.fecha + "</td><td>" + turnos.hora + "</td><td>" + turnos.medico + "</td><td>" + turnos.especialidad + "</td><td id='tdMedId" + index + "' style='display:none;'>" + turnos.medicoid + "</td><td id='tdEspId" + index + "' style='display:none;'>" + turnos.especialidadid + "</td></tr>";
        });
        Tabla_Fin = "</tbody></table>";
        $("#ListaTurnos").html(Tabla_Titulo + Tabla_Datos + Tabla_Fin);
    }
    else $("#ListaTurnos").empty();
}

function CargarDatosTurno(index) { //Cargo datos del turno para sacar el bono.
    $("#cbo_Especialidad").val($("#tdEspId"+index).html());
    Cargar_Medicos_por_Especialidad($("#tdEspId" + index).html(), $("#tdMedId" + index).html());
    Cargar_Practicas_by_Especialidad($("#tdEspId" + index).html());
    $("#desdeaqui").click();
    $("#ModalTurnos").modal('hide');
}

function UltimoAporte_OK() {
    if (Ultimo_OK == 1) { return false; }
    var json = JSON.stringify({ "Documento": $("#txt_dni").val() });
    $.ajax({
        type: "POST",
        url: "../Json/Gente.asmx/UltimoAporte_OK",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            if (Ultimo_OK == 1) { return false; }
            Ultimo_OK = 1;
            var ok = Resultado.d;
            if (!ok) alert("No se registran aportes en los últimos 3 meses. Regularizar situación en AFILIACIONES.\nVerificar con SSS.");
            else { $("#btnVencimiento").click(); }
        }
    });
}

function PatologiabyId(Id) {
    if (Id <= 1) { $('#span_Discapacidad').html("PATOLOGÍA: NO"); $("#discapacidad_paga").val('S'); $("#span_Discapacidad").css("color","white"); return; }
    var json = JSON.stringify({ "Id": Id });
    $.ajax({
        type: "POST",
        data: json,
        url: "../Json/AtConsultorio/Patologia.asmx/Patologia_Lista",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var lista = Resultado.d;
            $.each(lista, function (index, item) {
                $('#span_Discapacidad').html("PATOLOGÍA: " + item.patologias);
                $("#span_Discapacidad").blink();
                $("#discapacidad_paga").val(item.pagobono);
            });
        },
        error: errores
    });
}

function ListTipoDoc() {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/ListTipoDoc",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var lista = Resultado.d;
            $.each(lista, function (index, Tipo) {
                $('#cbo_TipoDOC').append($('<option></option>').val(Tipo.Id).html(Tipo.Descripcion));
            });

        },
        error: errores
    });
}


function Cargar_Seccionales_Lista() {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/Seccionales_Listas",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Seccionales_Listas_Cargadas,
        error: errores
    });

}

function Seccionales_Listas_Cargadas(Resultado) {
    var Seccionales = Resultado.d;
    $('#cboSeccional').empty();
    $.each(Seccionales, function (index, seccionales) {
        $('#cboSeccional').append(
              $('<option></option>').val(seccionales.Nro).html(seccionales.Seccional)
            );
    });
}

function VerificarPMI(PacienteID) {
    $.ajax({
        type: "POST",
        url: "../Json/Gente/ActualizarGente.asmx/VerificarPMI",
        data: '{PacienteId: "' + PacienteID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            $("#verificarPMI").val(Resultado.d);
        },
        error: errores
    });
}

function CertificadoVencido(DNI) {
    $.ajax({
        type: "POST",
        url: "../Json/Discapacidad/Discapacidad.asmx/VerificarFechaCertificado",
        data: '{DNI: "' + DNI + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: errores
    });
}


$("#cbo_Especialidad").change(function () {
    Cargar_Practicas_by_Especialidad($("#cbo_Especialidad :selected").val());
});

function Practicas_Id_Codigo(Id) {
    $.ajax({
        type: "POST",
        url: "../Json/Practicas/Practicas.asmx/Practicas_Id_Codigo",
        data: '{Id: "' + Id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Id_Codigo,
        error: errores
    });
}


function Cargar_Id_Codigo(Resultado) {
    var Codigo = Resultado.d;
    $("#txtCodigo").val(Codigo);
    ValorPractica();
    $("#txtImporte").focus();
}

function Cargar_Practicas_by_Especialidad(EspecialidadId) {
    var json = JSON.stringify({ "EspecialidadId": EspecialidadId });
    $.ajax({
        type: "POST",
        url: "../Json/ConfirmarTurnos.asmx/Lista_Practicas_by_Esp",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Pracias_Cargadas,
        complete: function () {
            if ($("#cbo_Practicas option[value='420101']").val() == undefined) {
                $("#cbo_Practicas :nth(1)").attr("selected", "selected");
                $("#txtCodigo").val($("#cbo_Practicas :selected").val());
                ValorPractica();
            }
            else {
                $("#cbo_Practicas").val("420101");
                $("#txtCodigo").val("420101");
                ValorPractica();
            }
        },
        error: errores
    });
}

function Cargar_Practicas() {
    $.ajax({
        type: "POST",
        url: "../Json/ConfirmarTurnos.asmx/Practicas_Listas_Total",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Pracias_Cargadas,
        error: errores
    });
}

function Cargar_Practicas_Guardia() {
    $.ajax({
        type: "POST",
        url: "../Json/ConfirmarTurnos.asmx/Practica_Listar_Guardia",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Pracias_Cargadas,
        error: errores
    });
}

function Practica_Codigo_ID(Codigo) {
    $.ajax({
        type: "POST",
        url: "../Json/ConfirmarTurnos.asmx/Practicas_Codigo_ID",
        data: '{Codigo: "' + Codigo + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Practica_Codigo_ID_Cargadas,
        error: errores
    });
}

function Practica_Codigo_ID_Cargadas(Resultado) {
    var Id = Resultado.d;
    if (Id != 0) {
        $("#cbo_Practicas option[value=" + Id + "]").attr("selected", true);
        $("#txtImporte").focus();
        ValorPractica();
    }
    else {
        $("#cbo_Practicas option[value=0]").attr("selected", true);
        $("#ControltxtCodigo").addClass("error");
        $("#txtCodigo").val('');
        $("#txtCodigo").focus();
    }
}

function ValorPractica() {
    if ($("#CargadoNHC").html() == '4' || $("#CargadoNHC").html() == '5' || $("#CargadoNHC").html() == '6') { $("#txtImporte").val('0'); $("#txtImporteReal").val('0'); return false; } //Apertura HC, Prest. Docu, Cambio de Turno.
    if ($("#chkVIP").is(":checked")) { $("#txtImporte").val('0'); $("#txtImporteReal").val('0'); return false; } //Es VIP, no paga bono.(Req. Auto)
    if (nopaga) { $("#txtImporte").val('0'); $("#txtImporteReal").val('0'); return false; }

    var Seccional_Id = $("#cboSeccional :selected").val();
    var json = JSON.stringify({ "Seccional": Seccional_Id, "EspecialidadId": $("#cbo_Especialidad :selected").val(), "PracticaId": $("#cbo_Practicas :selected").val(),"NomencladorId": 0 });
    $.ajax({
        type: "POST",
        url: "../Json/Facturacion/Facturacion.asmx/ValorPracticaporConvenio",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: ValorPractica_Cargado,
        error: errores
    });
}

$('#cboNoPagaAutoriza').hover(function () {
    $(this).attr('size', 1);
});

$("#chkVIP").click(function () {
    $("#cboNoPagaAutoriza").val("0");
    $("#cboObservacionesNP").val("0");
    if ($(this).is(":checked")) {
        $("#cboNoPagaAutoriza").show();
        $("#cboObservacionesNP").show();
        $("#txtObsNP").show();
        $("#txtImporte").val('0.00');
        $("#txtImporteReal").val('0.00');
        $('#cboNoPagaAutoriza').attr('size', 2);
        //$("#txtImporte").removeAttr("disabled");
    }
    else {
        $("#cboNoPagaAutoriza").hide();
        $("#cboObservacionesNP").hide();
        $("#txtObsNP").hide();
        //$("#txtImporte").attr("disabled", true);
    }
});

function ValorPractica_Cargado(Resultado) {
    var Valor = Resultado.d;
    if (Valor != null) {
        var val = parseFloat(Valor.ValorBono).toFixed(2);

        if (EsMonotributo) val = parseFloat(Valor.ValorACA).toFixed(2); //Valor Monotrib

        if ($("#discapacidad_paga").val() == 'N') { $("#txtImporte").val('0'); return; }
        if ($("#verificarPMI").val() == 1) { $("#txtImporte").val('0'); return; } //CUBRE PMI
        if (val == '0.00') { $("#txtImporte").val('0'); return; }
        $("#txtImporte").val(val);
        $("#txtImporteReal").val(val);
    } else {
        $("#txtImporte").val('0');
        $("#txtImporteReal").val('0');
    }
}

$("#txtCodigo").change(function () {
    var Numeros = /^([0-9])*$/;
    if (Numeros.test($("#txtCodigo").val())) {
        $("#ControltxtCodigo").removeClass("error");
        if ($("#txtCodigo").val() == "") {            
            //$("#btnConfirmarNuevoBono").focus();
        }
        else {
            Practica_Codigo_ID($("#txtCodigo").val());
            $("#txtImporte").focus();
        }
    } else {
        $("#ControltxtCodigo").addClass("error");
        $("#txtCodigo").focus();
    }
});

$("#txtCodigo").keypress(function (event) {
    var Numeros = /^([0-9])*$/;
    if (event.which == 13 || event.keyCode == 9) {
        event.preventDefault();
        if (Numeros.test($("#txtCodigo").val())) {            
            if ($("#txtCodigo").val() == "") {
                //$("#btnConfirmarNuevoBono").focus();
            }
            else {
                Practica_Codigo_ID($("#txtCodigo").val());
            }
        }
        else {
            $("#ControltxtCodigo").addClass("error");
        }
    }

});



function Pracias_Cargadas(Resultado) {
    var Practicas = Resultado.d;
    $('#cbo_Practicas').empty();
    $('#cbo_Practicas').append('<option value="0">Seleccione una Práctica</option>');
    $.each(Practicas, function (index, practicas) {
        $('#cbo_Practicas').append(
              $('<option></option>').val(practicas.Id).html(practicas.Practica) ///***Ver
            );
    });
}


$("#btnAgregarPractica").click(function () {
    if ($("#txtImporte").val().trim().length == 0 || $("#txtImporte").val() == undefined) { $("#txtImporte").val("0"); $("#txtImporteReal").val("0"); }
    if ($("#cbo_Practicas :selected").val() == "0") { alert("Seleccione una práctica."); return false; }

    if ($("#txtCodigo").val() == '') {
        $("#ControltxtCodigo").addClass("error");
        $("#txtCodigo").focus();
    }
    else {

        if ($("#ControltxtImporte").hasClass("error")) {
            $("#txtImporte").focus();
            return false;
        }
        else {
            if ($("#ControltxtImporteReal").hasClass("error")) {
                $("#txtImporteReal").focus();
                return false;
            }
            else {

                //if (!Existe($("#txtCodigo").val())) {

                Nombre = $("#cbo_Practicas :selected").text();
                //Codigo = $('#cbo_Practicas option:selected').val();  //$("#txtCodigo").val();
                Codigo = $("#txtCodigo").val();
                Precio = $("#txtImporte").val().replace(".", ",");
                PrecioReal = $("#txtImporteReal").val().replace(".", ",");
                ComentarioPractica = $("#txtPracticaComentario").val();
                PracticaId = $("#cbo_Practicas").val();
                Estado = 1;
                var Cual = Total;
                if (Editando == 1) {
                    Cual = EditandoPos;
                }
                else {
                    Total = Total + 1;
                    Cual = Total;
                }

                var objPractica = {};
                objPractica.Codigo = Codigo;
                objPractica.Precio = Precio;
                objPractica.PrecioReal = PrecioReal;
                objPractica.Estado = Estado;
                objPractica.ComentarioPractica = ComentarioPractica;
                objPractica.Nombre = Nombre;
                objPractica.PracticaId = PracticaId;
                objPracticas[Cual] = objPractica;

                //Practicas[Cual] = [Codigo, Nombre, Precio, PrecioReal, Estado, ComentarioPractica, PracticaId];           
                RenderizarTabla();
                Editando = 0;
                EditandoPos = -1;

                LimpiarCampos();
                $("#txtCodigo").focus();

                //}
            }
        }
    }

});

    function formatoMoneda(num) {
        var p = num.toFixed(2).split(".");
        var chars = p[0].split("").reverse();
        var newstr = '';
        var count = 0;
        for (x in chars) {
            count++;
            if (count % 3 == 1 && count != 1) {
                newstr = chars[x] + ',' + newstr;
            } else {
                newstr = chars[x] + newstr;
            }
        }
        return newstr + "." + p[1];
    }

function RenderizarTabla() {
    var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th></th><th>Código</th><th>Práctica</th><th>Importe</th><th>Importe Real</th></tr></thead><tbody>";
    var Contenido = "";
    $("#totalBono").val("0");
    for (var i = 0; i <= Total; i++) {
        //Estado = 0 es Borrado
        if (objPracticas[i].Estado == 1) {
            Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' rel='tooltip' title='Editar Práctica'><i class='icon-edit'></i></a><a id='Elminar" + i + "'onclick='Eliminar(" + i + ");' class='btn btn-mini btn-danger' rel='tooltip' title='Quitar Práctica'><i class='icon-remove-circle icon-white'></i></a></td><td> " + objPracticas[i].Codigo + " </td><td> " + objPracticas[i].Nombre.substring(0, 20) + " </td><td> $ " + objPracticas[i].Precio + " </td><td> $ " + objPracticas[i].PrecioReal + " </td></tr>";
            $("#totalBono").val(parseFloat($("#totalBono").val()) + parseFloat(objPracticas[i].Precio.replace(',','.')));
        }
        if (objPracticas.length - 1 == Total) $("#Total").html("TOTAL A PAGAR: $" + formatoMoneda(parseFloat($("#totalBono").val()))); 
    }

    var Pie = "</tbody></table>";
    $("#TablaPracticas").html(Encabezado + Contenido + Pie);

    if ($("[rel=tooltip]").length) {
        $("[rel=tooltip]").tooltip();
    }



}

function Editar(Nro) {
    Editando = 1;
    EditandoPos = Nro;
    $("#txtCodigo").val(objPracticas[Nro].Codigo);
    $("#txtImporte").val(objPracticas[Nro].Precio);
    $("#txtImporteReal").val(objPracticas[Nro].PrecioReal);
    $("#txtPracticaComentario").val(objPracticas[Nro].ComentarioPractica);
    $("#cbo_Practicas option[value=" + objPracticas[Nro].PracticaId + "]").attr("selected", true);
    $("#btnAgregarPractica").html("<i class='icon-plus-sign icon-white'></i> Aceptar Cambio");
    $("#btnCancelarPractica").html("<i class='icon-remove-circle icon-white'></i> Cancelar Cambio");

}

function Eliminar(Nro) {
    objPracticas[Nro].Estado = 0;
    RenderizarTabla();
}


function Existe(Algo) {

    for (var i = 0; i <= Total; i++) {
        if (objPracticas[i].Codigo == Algo && objPracticas[i].Estado == 1 && Editando != 1 ) {
            alert("Ya ha cargado la práctica Nro: " + Algo);
            LimpiarCampos();
            $("#txtCodigo").focus();
            return true;
        }
    }
    return false;
}


$("#cbo_Practicas").change(function () {
    Practicas_Id_Codigo($('#cbo_Practicas option:selected').val());
});





function imgErrorMedico(image) {
    image.onerror = "";
    image.src = "../img/silueta.jpg";
    return true;
}

function imgErrorPaciente(image) {
    image.onerror = "";
    image.src = "../img/silueta.jpg";
    return true;
}

$("#txtImporte").keypress(function (event) {

    if (event.keyCode == 9) {
        event.preventDefault();

        if (Moneda.test($("#txtImporte").val())) {
            $("#txtImporteReal").val($("#txtImporte").val());
            $("#ControltxtImporte").removeClass("error");
            $("#ControltxtImporteReal").removeClass("error");
            $("#btnAgregarPractica").focus();

        }
        else {
            if ($("#txtImporte").val() == '') {
                $("#txtImporte").val('0');
                $("#txtImporteReal").val('0');
                $("#ControltxtImporte").removeClass("error");
                $("#ControltxtImporteReal").removeClass("error");
                $("#btnAgregarPractica").focus();
            }
            else {
                $("#ControltxtImporte").addClass("error");
            }
        }
    }

    if (event.which == 13) {

        if (Moneda.test($("#txtImporte").val())) {

            $("#txtImporteReal").val($("#txtImporte").val());
            if ($("#txtImporte").val() == '') { $("#txtImporte").val('0'); $("#txtImporteReal").val('0'); }

            $("#ControltxtImporte").removeClass("error");
            $("#btnAgregarPractica").focus();
        }
        else {
            if ($("#txtImporte").val() == '') {
                $("#txtImporte").val('0');
                $("#txtImporteReal").val('0');
                $("#ControltxtImporte").removeClass("error");
                $("#ControltxtImporteReal").removeClass("error");
                $("#btnAgregarPractica").focus();
            }
            else {
                $("#ControltxtImporte").addClass("error");
            }
        }
    }
});

$("#txtImporte").blur(function () {

    if (Moneda.test($("#txtImporte").val())) {
        $("#ControltxtImporte").removeClass("error");
        $("#btnAgregarPractica").focus();
        $("#txtImporteReal").val($("#txtImporte").val());
    }
    else {
        if ($("#txtImporte").val() == '') {
            $("#txtImporte").val('0');
            $("#txtImporteReal").val('0');
            $("#ControltxtImporte").removeClass("error");
            $("#txtImporteReal").focus();
        }
        else {
            $("#ControltxtImporte").addClass("error");
        }
    }

});

$("#btnCancelarPractica").click(function () {
    Editando = 0;
    EditandoPos = -1;
    $("#btnAgregarPractica").html("<i class='icon-plus-sign icon-white'></i> Agregar");
    $("#btnCancelarPractica").html("<i class='icon-remove-circle icon-white'></i> Cancelar");

    $("#ControltxtCodigo").removeClass("error");
    $("#ControltxtImporteReal").removeClass("error");
    $("#ControltxtImporte").removeClass("error");

    LimpiarCampos();
});

function LimpiarCampos() {
    $("#txtCodigo").val("");
    $("#txtImporte").val("");
    $("#txtImporteReal").val("");
    $("#txtPracticaComentario").val("");
    $("#cbo_Practicas option[value=0]").attr("selected", true);
    $("#btnAgregarPractica").html("<i class='icon-plus-sign icon-white'></i> Agregar");
    $("#btnCancelarPractica").html("<i class='icon-remove-circle icon-white'></i> Cancelar");
}



$("#CerrarError").click(function () {
    window.location.href = "DarTurnos.aspx?NHC=" + CUIL;
});

function MostrarError(Mensaje) {
    Impreso = 0;
    $("#DialogoError").html(Mensaje);
    $('#ModalError').modal({
        keyboard: false,
        backdrop: 'static'
    });
}


function errores(msg) {
    Impreso = 0;
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}


$(document).ready(function () {
    ListTipoDoc();
    if ($("[rel=tooltip]").length) {
        $("[rel=tooltip]").tooltip();
    }
    Cargar_Practicas();
    $("#txtNHC").focus();
    var GET = {};
    var NHC = "";
    var Documento = "";
    $("#txtTelefono").mask("99999999?99999", { placeholder: "-" });

    document.location.search.replace(/\??(?:([^=]+)=([^&]*)&?)/g, function () {
        function decode(s) {
            return decodeURIComponent(s.split("+").join(" "));
        }

        GET[decode(arguments[1])] = decode(arguments[2]);
    });


    if (GET["NHC"] != "" && GET["NHC"] != null) {
        NHC = GET["NHC"];
        Cargar_Paciente_NHC(NHC);
    }

    if (GET["Documento"] != "" && GET["Documento"] != null) {
        Documento = GET["Documento"];
        Cargar_Paciente_Documento(Documento);
        $("#txt_dni").val(Documento);
    }


    if (GET["ID"] != "" && GET["ID"] != null) {
        $("#afiliadoId").val(GET["ID"]);
        CargarPacienteID(GET["ID"]);
    }

    Cargar_Autorizantes(0);
    Cargar_AutorizantesBono();
    Cargar_MotivoAutorizantesBono();
});

function CargarPacienteID(ID) {
    if (Internado == 1) { return false; }
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

$('#fotopaciente').error(function () {
    $(this).attr('src', '../img/silueta.jpg');
});

$("#btnReservaTurnoAhora").click(function () {
    if (!$("#btnReservaTurnoAhora").is(':checked')) {
        $("#NroTurnoAhora").hide();
    } else {
        $("#NroTurnoAhora").show();

        $.ajax({
            type: "POST",
            url: "../Json/Bonos/NuevoBonos.asmx/Ultimo_Nro_ReservaAhora",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: ActualizarNroTurno,
            error: errores
        });
    }
});

function ActualizarNroTurno_() {
    $.ajax({
        type: "POST",
        url: "../Json/Bonos/NuevoBonos.asmx/Ultimo_Nro_ReservaAhora",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: ActualizarNroTurno,
        error: errores
    });
}


function ActualizarNroTurno(Resultado) {
    $("#NroTurnoAhora").html('');
    $("#NroTurnoAhora").html(Resultado.d);
}

////function VerificarImporte() { //Si el afiliado tiene alguna discapacidad, debe ser total en 0
////    var t = 0;
////    $(objPracticas).each(function () {
////        if (this.Estado == 1) t += parseFloat(this.Precio);
////    });
////    return (t > 0) ? true:false;
////}

function VerImporteCero() {
    if ($("#chkVIP").is(":checked")) return true; //Es VIP no paga bono.
    if (nopaga) return true; //no paga tiene PMI, no paga menor de 1 año o discapacitado..
    if ($("#CargadoNHC").html() == '4' || $("#CargadoNHC").html() == '5' || $("#CargadoNHC").html() == '6') return true; //Es apertura HC,Cambio Turno, Prest. Docu.

    var t = 0;
    $(objPracticas).each(function () {
        if (this.Estado == 1) t += parseFloat(this.Precio);
    });
    return (t == 0) ? false : true; //Importe mayor a cero, el paciente no es VIP ni DISC, debe pagar bono.
}

$("#btnConfirmarNuevoBono").click(function () {
    if (!$.isNumeric($("#afiliadoId").val()) || $("#afiliadoId").val() <= 0) { alert("Paciente no válido."); $("#btnConfirmarNuevoBono").hide(); return false; }

    //if (VerificarImporte()) { alert("Paciente discapacitado. No se debe cobrar bono."); return false; }
    if ($("#chkVIP").is(":checked") && $("#cboNoPagaAutoriza :selected").val() == "0") { alert("Seleccione Autorizante."); return false; }
    if ($("#chkVIP").is(":checked") && $("#cboObservacionesNP :selected").val() == "0") { alert("Seleccione Motivo."); return false; }

    if (!VerImporteCero()) { alert("NO SE PUEDE EMITIR BONO EN CERO.\nEL PACIENTE NO ESTA AUTORIZADO."); return false; }

    if (Impreso == 0) {
        Impreso = 1;

        if ($('#cbo_Medico option:selected').val() == "0" || $('#cbo_Medico option:selected').val() == '' || $('#cbo_Medico option:selected').val() == null) { $("#Controlcbo_Medico").addClass("error"); Impreso = 0; return false; }
        if ($('#cbo_Especialidad option:selected').val() == "0" || $('#cbo_Especialidad option:selected').val() == '' || $('#cbo_Especialidad option:selected').val() == null) { $("#Controlcbo_Especialidad").addClass("error"); Impreso = 0; return false; }

        TurnoAutorizanteId = $('#cboAutorizante option:selected').val();
        TurnoPrimeraVez = false;
        TurnoEmiteComprobante = false;
        Recepcionaturno = false;

        if ($("#btnEmitecoprobante").is(":checked")) {
            TurnoEmiteComprobante = true;
        }
        else {
            TurnoEmiteComprobante = true;
        }

        if ($("#btnRecepcionaturno").is(":checked")) {
            Recepcionaturno = true;
        }
        else {
            Recepcionaturno = false;
        }

        if ($("#btnReservaTurnoAhora").is(":checked")) {
            ReservaTurnoAhora = true;
        }
        else {
            ReservaTurnoAhora = false;
        }

        if ($("#btnAtencionSinTurno").is(":checked")) {
            EsAtencionSinTurno = true;
        }
        else {
            EsAtencionSinTurno = false;
        }



        var TurnoVerificado = null;
        var Comentario = $("#txtComentario").val();

        var json = JSON.stringify({ "objPracticas": objPracticas, "Documento": $("#afiliadoId").val(), "EsPrimeraVez": false, "Verificado": '',
            "EmiteComprobante": TurnoEmiteComprobante, "AutorizanteId": $('#cboAutorizante option:selected').val(), "MedicoId": $('#cbo_Medico option:selected').val(),
            "EspecialidadId": $('#cbo_Especialidad option:selected').val(), "EsAtencionSinTurno": EsAtencionSinTurno, "EsUrgencia": false, "ReservaTurnoAhora": ReservaTurnoAhora,
            "FechaTurno": FechaTurno, "Recepcionaturno": Recepcionaturno, "AutorizaBono": $("#cboNoPagaAutoriza :selected").val(), "MotivoAutorizaBono": $("#cboObservacionesNP :selected").val(),
            "Observaciones": $("#txtObsNP").val().trim().toUpperCase()
        });
        $.ajax({
            type: "POST",
            url: "../Json/Bonos/NuevoBonos.asmx/GuardarPracticasBono",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: BonoGuardado,
            error: errores
        });
    }
});



$("#cbo_Medico").change(function () {
    var str = $('#cbo_Medico option:selected').html();
    if (str.length > 20) $("#CargadoMedico").html(str.substring(0, 19) + "...");
    else $("#CargadoMedico").html(str);
    //FotoMedico();
});

function FotoMedico() {
    $("#fotomedico").attr('src', '../img/medicos/' + $('#cbo_Medico option:selected').val() + '.jpg');
}

$('#fotomedico').error(function () {
    $(this).attr('src', '../img/silueta.jpg');
});

function BonoGuardado(Resultado) {
    var url = '../Impresiones/ImpresionBono.aspx?' + Resultado.d;
    if (EsMonotributo) url = '../Impresiones/ImpresionBono_Mono.aspx?' + Resultado.d;
    $.fancybox(
		{
		    'autoDimensions': false,
		    'href': url,
		    'width': '75%',
		    'height': '75%',
		    'autoScale': false,
		    'transitionIn': 'none',
		    'transitionOut': 'none',
		    'type': 'iframe',
		    'hideOnOverlayClick': false,
		    'enableEscapeButton': false,		    
		    'onClosed': function () {
		        window.location.href = "NuevoBono.aspx";
		    }
		});
}

function Especialidad_Cargadas(Resultado) {
    var Especialidad = Resultado.d;
    $('#cbo_Especialidad').empty();
    $('#cbo_Especialidad').append('<option value="0">Especialidad</option>');
    $.each(Especialidad, function (index, especialidades) {
        $('#cbo_Especialidad').append(
              $('<option></option>').val(especialidades.Id).html(especialidades.Especialidad)
            );
    });
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


$('#cbo_Especialidad').change(function () {
    if ($('#cbo_Especialidad option:selected').html().length > 13) {
        $("#CargadoEspecialidad").html($('#cbo_Especialidad option:selected').html().substring(0, 13)+"...");
    } else {
        $("#CargadoEspecialidad").html($('#cbo_Especialidad option:selected').html());
    }
    Cargar_Medicos_por_EspecialidadporTipo($(this).val(), 'A');
});



function Cargar_Medicos_por_EspecialidadporTipo(Especialidad, Tipo) {
    var json = JSON.stringify({ "Especialidad": Especialidad, "Tipo": Tipo });
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/Medico_Lista_por_Especialidad_SoloActivosTipo",
        data: json,
        //url: "../Json/DarTurnos.asmx/Medico_Lista_por_Especialidad_SoloActivos",
        //data: '{Especialidad: "' + Especialidad + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {

            var Medicos = Resultado.d;
            $('#cbo_Medico').empty();
            $.each(Medicos, function (index, medicos) {
                $('#cbo_Medico').append(
              $('<option></option>').val(medicos.Id).html(medicos.Medico)
            );
            });
            if (Resultado.d != null && Resultado.d != '') {
                $("#CargadoMedico").html($('#cbo_Medico option:selected').html());
            } else {
                $("#CargadoMedico").html('');
            }

            if (MedicoId != '0' || MedicoId != '') {
                $("#cbo_Medico option[value=" + MedicoId + "]").attr("selected", true);
                $("#CargadoMedico").html($('#cbo_Medico option:selected').html());
            }
            //FotoMedico();

        },
        error: errores
    });

}


function Cargar_Medicos_por_Especialidad(Especialidad, MedicoId) {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/Medico_Lista_por_Especialidad_SoloActivos",
        data: '{Especialidad: "' + Especialidad + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {

            var Medicos = Resultado.d;
            $('#cbo_Medico').empty();
            $.each(Medicos, function (index, medicos) {
                $('#cbo_Medico').append(
              $('<option></option>').val(medicos.Id).html(medicos.Medico)
            );
            });
            if (Resultado.d != null && Resultado.d != '') {
                $("#CargadoMedico").html($('#cbo_Medico option:selected').html());
            } else {
                $("#CargadoMedico").html('');
            }

            if (MedicoId != '0' || MedicoId != '') {
                $("#cbo_Medico option[value=" + MedicoId + "]").attr("selected", true);
                $("#CargadoMedico").html($('#cbo_Medico option:selected').html());
            }
            //FotoMedico();

        },
        error: errores
    });

}


function Cargar_Paciente_Documento(Documento) {
    if (Internado == 1) { return false; }
    var json = JSON.stringify({ "Documento": Documento, "T_Doc": $('#cbo_TipoDOC :selected').val() });
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/Cargar_Paciente_Documento",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Paciente_Documento_Cargado,
        complete: function () {
            if ($("#afiliadoId").val().trim().length > 0) setTimeout(function () { $('#desdeaqui').focus(); }, 100); //$("#desdeaqui").focus();
        },
        error: errores
    });
}

function Bloquear() {
    $("#txtNHC").attr("disabled", true);
    $("#txt_dni").attr("disabled", true);
    $("#txtPaciente").attr("disabled", true);
    $("#btnCancelarPedidoTurno").show();
}

function Cargar_Paciente_Documento_Cargado(Resultado) {
    var Paciente = Resultado.d;
    var PError = false;
    if (Paciente.length == 1) {

        $.each(Paciente, function (index, paciente) {
            if (paciente.Vencido) {
                alert("Paciente dado de baja el día: " + paciente.FechaVencido);
                return false;
            }
            $("#btnactualizar").show();
            $("#btnCancelarPedidoTurno").show();

            $("#txtnroturno").prop("readonly", true);

            $("#txtPaciente").attr('value', paciente.Paciente);
            $("#txtNHC").attr('value', paciente.NHC_UOM);
            $("#txtTelefono").attr('value', paciente.Telefono);
            $("#cboSeccional option[value=" + paciente.Nro_Seccional + "]").attr("selected", true);

            $("#btnOtorgados").css('display', 'inline');

            if (paciente.CUIT == 88888888888) EsMonotributo = true; //CUIT = 88888888888, Monotrib
            else EsMonotributo = false;

            if ($("#txtTelefono").val().length < 5) {
                $("#controlTelefono").addClass("error");
                PError = true;
            }
            if (paciente.Nro_Seccional == 999) {
                $("#controlSeccional").addClass("error");
                PError = true;
            }


            if (paciente.Paciente.length > 20) $("#CargadoApellido").html(paciente.Paciente.substring(0, 19) + "...");
            else $("#CargadoApellido").html(paciente.Paciente);
            $("#CargadoEdad").html(paciente.Edad_Format);
            $("#CargadoDNI").html(paciente.documento_real);

            $("#CargadoNHC").html(paciente.NHC_UOM);
            $("#CargadoTelefono").html(paciente.Telefono);
            $("#CargadoCelular").html(paciente.Celular);
            $("#CargadoSeccional").html($("#cboSeccional :selected").text());
            //$('#fotopaciente').attr('src', '../img/Pacientes/' + paciente.documento + '.jpg');
            $('#fotopaciente').attr('src', '../img/Pacientes' + paciente.Foto);

            $("#afiliadoId").val(paciente.documento);

            UltimoAporte_OK(); //Verifica aportes en Padron UOM.
            MostrarObs(paciente.Observaciones);
            Bloquear();

            ExisteTurno(paciente.documento);
            PatologiabyId(paciente.Discapacidad);

            Internado = 1;
            $("#cbo_TipoDOC").val(paciente.TipoDoc);


            $("#discapacidad_val").val(paciente.Discapacidad);


            $("#Cod_OS").val(paciente.OSId);
            if (paciente.Nro_Seccional == 998) {
                $("#cbo_ObraSocial").show();
                $("#cboSeccional").hide();
                $("#Titulo_Seccional_o_OS").html("Ob. Social");
                $("#CargadoSeccionalTitulo").html("Ob. Social");
                Cargar_ObraSociales_Cargar(paciente.OSId);
                if (paciente.ObraSocial.length > 40) {
                    $("#CargadoSeccional").html(paciente.ObraSocial.substring(0, 37) + "...");
                } else {
                    $("#CargadoSeccional").html(paciente.ObraSocial);
                }
            }

            nopaga = !paciente.PagaBono;

            PMIPI = "";
            if (paciente.PMI && paciente.PI == false) {
                PMIPI = "PMI"
            }

            if (paciente.PMI == false && paciente.PI) {
                PMIPI = "PI"
            }

            if (PMIPI != "") {
                $("#CargadoSeccional").html($("#CargadoSeccional").html() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[" + PMIPI + "]");
            }


            if (PError) {
                $("#desdeaqui").hide();
            }
            else {
                $("#desdeaqui").show();
            }
        });
    }
    else if (Paciente.length > 1 && $("#afiliadoId").val().length == 0) {
        $("#txtdocumento").val($("#txt_dni").val());
        BuscarPacientes_fancy();
        $("#txtPaciente").focus();
    }
}




function BuscarPacientes_fancy() {
    $.fancybox({
        'hideOnContentClick': true,
        'width': '85%',
        'href': "../Turnos/BuscarPacientes.aspx?Express=0",
        'height': '85%',
        'autoScale': false,
        'transitionIn': 'none',
        'transitionOut': 'none',
        'type': 'iframe'
    });
}

$("#txt_dni").on('keydown', function (e) {
    var keyCode = e.keyCode || e.which;
    if (keyCode == 13 || keyCode == 9) {
        e.preventDefault();
        if ($("#txt_dni").val().trim().length > 0)
            Cargar_Paciente_Documento($("#txt_dni").val());
    }
});

$("#txtNHC").on('keydown', function (e) {
    var keyCode = e.keyCode || e.which;
    if (keyCode == 13 || keyCode == 9) {
        e.preventDefault();
        if ($("#txtNHC").val().trim().length > 0)
            Cargar_Paciente_NHC($("#txtNHC").val());
    }
});

function Cargar_Autorizantes(Id) {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/Autorizantes",
        data: '{Id: "' + Id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Autorizantes_Cargado,
        error: errores
    });
}

function Cargar_Autorizantes_Cargado(Resultado) {
    var Autorizantes = Resultado.d;
    $('#cboAutorizante').empty();
    $('#cboAutorizante').append('<option value="0">Autorizado por...</option>');
    $.each(Autorizantes, function (index, autori) {
        $('#cboAutorizante').append(
              $('<option></option>').val(autori.id).html(autori.autorizante)
            );
    });
}

function Cargar_AutorizantesBono() {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/AutorizantesBono",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var Autorizantes = Resultado.d;
            $.each(Autorizantes, function (index, autori) {
                $('#cboNoPagaAutoriza').append($('<option></option>').val(autori.id).html(autori.autorizante));
            });
        },
        error: errores
    });
}

function Cargar_MotivoAutorizantesBono() {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/MotivoAutorizaBono",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var Autorizantes = Resultado.d;
            $.each(Autorizantes, function (index, motivo) {
                $('#cboObservacionesNP').append($('<option></option>').val(motivo.id).html(motivo.motivo));
            });
        },
        error: errores
    });
}

function Cargar_Paciente_NHC(NHC) {
    $.ajax({
        type: "POST",
        url: "../Json/DarTurnos.asmx/CargarPacienteNHC_UOM",
        data: '{NHC: "' + NHC + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Paciente_NHC_Cargado,
        complete: function () {
            if ($("#afiliadoId").val().trim().length > 0) $('#desdeaqui').focus();
        },
        error: errores
    });
}


function VerificarSiEsEstudiante(Documento) {
    if (Internado == 1) return false;
    $.ajax({
        type: "POST",
        url: "../Json/Gente/ActualizarGente.asmx/VerificarSiEsEstudiante",
        data: '{Documento: "' + Documento + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_VerificarSiEsEstudiante,
        error: errores
    });
}



function Cargar_VerificarSiEsEstudiante(Resultado) {
    $("#span_Estudiante").html(Resultado.d);
}

function MostrarObs(Obs) {
    if (Internado == 1) return false;
    if (Obs.length > 0) alert(Obs);
}

function Cargar_Paciente_NHC_Cargado(Resultado) {
    var Paciente = Resultado.d;
    var PError = false;


    $.each(Paciente, function (index, paciente) {
        if (paciente.Vencido) {
            alert("Paciente dado de baja el día: " + paciente.FechaVencido);
            $("#desdeaqui").hide();
            return false;
        }
        $("#btnactualizar").show();
        $("#btnCancelarPedidoTurno").show();

        $("#txtnroturno").prop("readonly", true);

        $("#afiliadoId").val(paciente.documento);
        ExisteTurno(paciente.documento);

        VerificarPMI(paciente.documento);
        PatologiabyId(paciente.Discapacidad);

        if (paciente.CUIT == 88888888888) EsMonotributo = true; //CUIT = 88888888888, Monotrib
        else EsMonotributo = false;

        $("#btnOtorgados").css('display', 'inline');
        $("#txtPaciente").attr('value', paciente.Paciente);
        $("#txt_dni").attr('value', paciente.documento_real);

        VerificarSiEsEstudiante(paciente.documento_real);

        $("#txtNHC").attr('value', paciente.NHC_UOM);
        $("#txtTelefono").attr('value', paciente.Telefono);

        $("#discapacidad_val").val(paciente.Discapacidad);

        $("#cboSeccional option[value=" + paciente.Nro_Seccional + "]").attr("selected", true);



        if ($("#txtTelefono").val().length < 5) {
            $("#controlTelefono").addClass("error");
            PError = true;
        }

        if (paciente.Nro_Seccional == "999") {
            $("#controlSeccional").addClass("error");
            PError = true;
        }


        if (paciente.Paciente.length > 20) $("#CargadoApellido").html(paciente.Paciente.substring(0, 19) + "...");
        else $("#CargadoApellido").html(paciente.Paciente);


        $("#CargadoEdad").html(paciente.Edad_Format);
        $("#CargadoDNI").html(paciente.documento_real);
        $("#CargadoNHC").html(paciente.NHC_UOM);
        $("#CargadoTelefono").html(paciente.Telefono);
        $("#CargadoCelular").html(paciente.Celular);
        $("#CargadoSeccional").html($("#cboSeccional :selected").text());

        if (!CertificadoMostrado) {
            CertificadoVencido(paciente.documento);
            CertificadoMostrado = true;
        }

        $("#Cod_OS").val(paciente.OSId);
        if (paciente.Nro_Seccional == 998) {
            $("#cbo_ObraSocial").show();
            $("#cboSeccional").hide();
            $("#Titulo_Seccional_o_OS").html("Ob. Social");
            $("#CargadoSeccionalTitulo").html("Ob. Social");
            Cargar_ObraSociales_Cargar(paciente.OSId);
            if (paciente.ObraSocial.length > 40) {
                $("#CargadoSeccional").html(paciente.ObraSocial.substring(0, 37) + "...");
            } else {
                $("#CargadoSeccional").html(paciente.ObraSocial);
            }
        }
        else {
            //$("#btnVencimiento").show();
        }

        MostrarObs(paciente.Observaciones);

        //EstaInternado(); //Verifica si el paciente se encuentra internado en la clinica.
        UltimoAporte_OK(); //Verifica aportes en Padron UOM.
        Bloquear();
        PMIPI = "";

        nopaga = !paciente.PagaBono;

        if (paciente.PMI && paciente.PI == false) {
            PMIPI = "PMI"
        }

        if (paciente.PMI == false && paciente.PI) {
            PMIPI = "PI"
        }

        if (PMIPI != "") {
            $("#CargadoSeccional").html($("#CargadoSeccional").html() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[" + PMIPI + "]");
        }

        $('#fotopaciente').attr('src', '../img/Pacientes' + paciente.Foto);

        if (PError) {
            $("#desdeaqui").hide();
        }
        else {
            $("#desdeaqui").show();
        }
    });
}

$("#btnBuscarPaciente").fancybox({
        'hideOnContentClick': true,
        'width': '75%',
        'height': '75%',
        'autoScale': false,
        'transitionIn': 'none',
        'transitionOut': 'none',
        'type': 'iframe'
    });

function RecargarPagina(url) {
    document.location = "../Bonos/NuevoBono.aspx" + url;
}

$('#desdeaqui').click(function () {
    if (Internado == 1) return false;
    $("#cbo_Medico option[value=" + MedicoID + "]").attr("selected", true);
    $("#hastaaqui").fadeIn(1500);
    $('html, body').animate({ scrollTop: $("#hastaaqui").offset().top - 60 }, 500);
    $('.container').height($('html').height() + ($('.contenedor_1').height() -
				$('.pie').height() -
				$('#hastaaqui').height()));
    $('#cbo_Especialidad').focus();
});



function Actualizar_Telefono_Seccional(Telefono, Seccional, Documento) {
    Cod_OS = $("#cbo_ObraSocial :selected").val();
    if (Cod_OS == undefined) { Cod_OS = 112103 }

    $.ajax({
        type: "POST",
        url: "../Json/Gente.asmx/Actualizar_Telefono_Seccional",
        data: '{Telefono: "' + Telefono + '", Seccional: "' + Seccional + '", Documento: "' + Documento + '", CodOs: "' + Cod_OS + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Actualizado_Telefono_Documento,
        error: errores
    });
}


function Actualizado_Telefono_Documento(Resultado) {
    //alert(Resultado.d);
    if (Resultado.d == '1') {
        $("#desdeaqui").show();
        $("#controlTelefono").removeClass("error");
        $("#controlSeccional").removeClass("error");
        $("#CargadoTelefono").html($("#txtTelefono").val());

        if ($("#Cod_OS").val() == "112103") {
            $("#CargadoSeccional").html($("#cboSeccional :selected").text());
        }
        else {
            $("#CargadoSeccional").html($("#cbo_ObraSocial :selected").text());
        }

    }
    else {


        if ($("#txtTelefono").val().length < 6) {
            $("#controlTelefono").addClass("error");
            $("#txtTelefono").focus();
        }
        else {
            $("#controlTelefono").removeClass("error");
        }

        if ($("#cboSeccional :selected").val() == "999") {
            $("#controlSeccional").addClass("error");
        }
        else {
            $("#controlSeccional").removeClass("error");
        }

    }

}

$('#btnactualizar').click(function () {
    Actualizar_Telefono_Seccional($('#txtTelefono').val(), $('#cboSeccional option:selected').val(), $('#afiliadoId').val());
});


$(window).keypress(function (e) {
    if (e.keyCode == 43) {
        $("#btnConfirmarNuevoBono").click();
        return false;
    }
});
