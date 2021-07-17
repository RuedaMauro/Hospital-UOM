var Pedido_Id = 0;
var Sala_Id_Aux;
var Cama_Id_Aux;
var Medico_Id;
var Servicio_Id_Aux;
var objMedicamento = Array();
var Total = -1;
var Editando = 0;
var EditandoPos = 0;
var objMedicamentos = new Array();
var objMedicamentos2 = {};
var Pendiente;
var Id_Internacion;
var TotalaSuministrar = 0;
var NroEntrega = 0;
var Documento;
var Pend = 0;
var Nombre_Alert = "";
var newpos = 0;
var cant_med = -1;

var Confirma = 0;
var seleccionado = 0;
var obj_seleccionado = {};
var AfiliadoId = 0;


//Modificacion//
var NroEntregaDet = 0;
var Desde;
var Hasta;
var ServId;

function PrintPedido() {
    $.fancybox(
        {
            'autoDimensions': false,
            'href': '../Impresiones/Print_Indicacion.aspx?Id=' + Pedido_Id, //Pedido_Id,
            'width': '75%',
            'height': '75%',
            'autoScale': false,
            'transitionIn': 'none',
            'transitionOut': 'none',
            'type': 'iframe',
            'hideOnOverlayClick': false,
            'enableEscapeButton': false
        });

}

$("#btnImprimirPedido").click(function () {
    if (Pedido_Id > 0) PrintPedido();
    else alert("Nro. de Pedido no válido.");
});


function GetQueryString() {
    var querystring = location.search.replace('?', '').split('&');
    var queryObj = {};
    for (var i = 0; i < querystring.length; i++) {
        var name = querystring[i].split('=')[0];
        var value = querystring[i].split('=')[1];
        queryObj[name] = value;
    }
    return queryObj;
}


$(document).ready(function () {
    $("#frm_Cantidad").validate({
        rules: {
            'cantidadent': { required: true, number: true, range: [1, 9999] }
        },
        messages: {
            'cantidadent': { required: '', number: '', range: '' }
        },
        invalidHandler: function (e, validator) {
            var list = validator.invalidElements();
            RemoveClass();
            for (var i = 0; i < list.length; i++) {
                var name_element = $(list[i]).attr("name");
                $("#control" + name_element).addClass("error");
            }
        }

    });
    var Query = {};
    Query = GetQueryString();
    Pedido_Id = Query['Id'];
    if (Query['NroEntregaDet'] != null && Query['NroEntregaDet'] != undefined) NroEntregaDet = Query['NroEntregaDet'];

    if (Query['Pend'] != null && Query['Pend'] != undefined) Pend = 1;

    Desde = Query['Desde'];
    Hasta = Query['Hasta'];
    ServId = Query['ServId'];

    $("#cbo_Medicamento").attr('disabled', 'disabled');
    $("#cantidad").attr('readonly', true);
    $("#Ucantidad").attr('readonly', true);
    $("#Ucantidadent").attr("disabled", true);
    $("#cantidadent").attr("disabled", true);
    $("#btnConfirmarEntrega").attr("disabled", true);
    if (Pedido_Id > 0) {
        EstaPendiente();
        LoadPedido();
        $("#CargadoPedido").html(Pedido_Id);
        $("#btnFinalizarIM").show();
    }
    else $("CargadoFecha").html(FechaActual());
});

$("#btnVolver").click(function () {
    if (Pend == 0) window.location.href = "EntregasIM.aspx?Desde=" + Desde + "&Hasta=" + Hasta + "&ServId=" + ServId;
    else window.location.href = "PedidosPendientes.aspx";
}); 

$("#cantidadent").blur(function () {
    $("#controlcantidadent").removeClass("error");
});

$("#btnCancelarMedicamento").click(function () {
    LimpiarCampos();

});

function LoadPedido() {
    var json = JSON.stringify({"NHC": null, "Id": Pedido_Id, "Apellido": null, "Desde": null, "Hasta": null, "objBusquedaLista": null, "MedicoId": null});
    $.ajax({
        type: "POST",
        url: "../Json/Farmacia/IM.asmx/BuscarIM",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: LoadPedido_Cargado,
        error: errores,
        complete: function () {
            if (NroEntregaDet == 0) LoadDetalles();
            else LoadDetalles_Modifica(Pedido_Id,NroEntregaDet);
            //GetCama();
            GetSala();
            $("#cargando2").hide();
            $("#cont_datospac").show();
            $('#desdeaqui').click();
        },
        beforeSend: function () {
            $("#cargando2").show();
            $("#cont_datospac").hide();
        }
    });
}

function RemoveClass() {
    $("#controlcantidadent").removeClass("error");
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

function Cargar_Paciente_NHC_Cargado(Resultado) {
    var Paciente = Resultado.d;
    var PError = false;


    $.each(Paciente, function (index, paciente) {

        $("#txt_dni").prop("readonly", true);
        $("#txtNHC").prop("readonly", true);

        $("#txtPaciente").attr('value', paciente.Paciente);
        $("#txt_dni").attr('value', paciente.documento_real);
        $("#txtNHC").attr('value', paciente.NHC_UOM);

        $("#CargadoEdad").html(paciente.Edad_Format);

        $("#afiliadoId").val(paciente.documento);
        AfiliadoId = paciente.documento;
        $("#cbo_TipoDOC").val(paciente.TipoDoc);
        $('#fotopaciente').attr('src', '../img/Pacientes/' + paciente.documento + '.jpg');
        $("#CargadoApellido").html(paciente.Paciente);
        $("#CargadoTelefono").html(paciente.Telefono);
        $("#CargadoSeccional").html(paciente.Seccional);
        $("#CargadoDNI").html(paciente.documento_real);
        $("#CargadoNHC").html(paciente.NHC_UOM);
    });

}


function LoadPedido_Cargado(Resultado) {
    var Lista;
    Lista = Resultado.d;
    $.each(Lista, function (index, PedidoCab) {
        AfiliadoId = PedidoCab.AfiliadoId;
        $("#CargadoDNI").html(PedidoCab.Documento);
        Documento = PedidoCab.Documento;
        $("#CargadoNHC").html(PedidoCab.NHC);
        Cargar_Paciente_NHC(PedidoCab.NHC);
        $("#CargadoEntrega").html(PedidoCab.NroEntrega);

        //FEDE ESTO ES PARA LA REIMPRESION
        if ($("#CargadoEntrega").html() != "Provisorio") {
            $("#btnImprimir").show();
        }

        $("#CargadoTelefono").html(PedidoCab.Telefono);
        $("#CargadoServicio").html(PedidoCab.Servicio);
        $("#CargadoFecha").html(PedidoCab.Fecha);
        $("#CargandoMedico").html(PedidoCab.Medico);
        $("#CargandoDiag").html(PedidoCab.Diagnostico);
        $('#fotopaciente').attr('src', '../img/Pacientes/' + PedidoCab.NHC + '.jpg');
        $("#CargadoApellido").html(PedidoCab.Nombre);
        Sala_Id_Aux = PedidoCab.IdSala;
        Cama_Id_Aux = PedidoCab.IdCama;
        EstaInternado();
        Servicio_Id_Aux = PedidoCab.IdServicio;
        Medico_Id = PedidoCab.IdMedico;
        Id_Internacion = PedidoCab.IdInternacion;
    });
    $("#hastaaqui").fadeIn(1500);
    $('html, body').animate({ scrollTop: $("#hastaaqui").offset().top - 60 }, 500);
    $('.container').height($('html').height() + ($('.contenedor_1').height() -
				$('.pie').height() -
				$('#hastaaqui').height()));
}

function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}


function EstaInternado() {
    $.ajax({
        type: "POST",
        url: "../Json/Farmacia/Farmacia.asmx/List_Internacion_Pac_byDoc",
        data: '{Documento: "' + AfiliadoId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_PacienteInt_byDocumento_Cargado,
        error: errores
    });
}

function Cargar_PacienteInt_byDocumento_Cargado(Resultado) {
    var Paciente = Resultado.d;
    if (Paciente != null) {
        $("#CargadoCama").html(Paciente.Cama);
        $("#CargadoSala").html(Paciente.Sala);        
    }
}

function GetCama() {
    var Cama = Cama_Id_Aux;
    var Sala = Sala_Id_Aux;
    $.ajax({
        type: "POST",
        url: "../Json/Internaciones/IntSSC.asmx/Lista_Camas",
        data: '{IdCama: ' + parseInt(Cama) + ', Sala: ' + parseInt(Sala) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: GetCama_Cargado,
        error: errores
    });
}

function GetCama_Cargado(Resultado) {
    var Cama = Resultado.d;    
    $("#CargadoCama").html(Cama[0].descripcion);
}

function imgErrorPaciente(image) {
    image.onerror = "";
    image.src = "../img/silueta.jpg";
    return true;
}

function GetSala() {
    var Sala = Sala_Id_Aux;
    var ServicioId = Servicio_Id_Aux;
    $.ajax({
        type: "POST",
        url: "../Json/Internaciones/IntSSC.asmx/Lista_Salas",
        data: '{SalaId: ' + parseInt(Sala) + ', Servicio: ' + parseInt(ServicioId) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: GetSala_Cargado,
        error: errores
    });
}

function GetSala_Cargado(Resultado) {
    var Sala = Resultado.d;
    $("#CargadoSala").html(Sala[0].descripcion);
}

function LoadDetalles_Modifica(IdIM,NroEntrega) {
    var json = JSON.stringify({"IdIM": IdIM  , "NroEntregaDet": NroEntrega });
    $.ajax({
        type: "POST",
        url: "../Json/Farmacia/IM.asmx/BuscarIM_ENT_Det_Modifica",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            var Detalles = Resultado.d;
            var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th></th><th>Insumo</th><th>Dosis</th><th>Frec/Hs</th><th>Total Dosis</th><th>Unidades a Entregar</th><th>Dosis Entregada</th><th>Unidades Entregada</th><th>Saldo</th><th>Unidades Stock</th></tr></thead><tbody>";
            var Contenido = "";
            var i = 0;

            $.each(Detalles, function (index, Detalle) {
                $("#btnHistorial").show();
                if (Detalle.Insumo_Id != 0) {
                    Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' rel='tooltip' title='Editar'><i class='icon-edit'></i></a><a id='Elminar" + i + "'onclick='Eliminar(" + i + ");' class='btn btn-mini btn-danger' title='Quitar Insumo'><i class='icon-remove-circle icon-white'></i></a></td><td> " + Detalle.Nombre + " " + Detalle.Gramaje + Detalle.Medida + " - " + Detalle.Presentacion + " </td><td> " + parseFloat(Detalle.Cantidad).toFixed(2) + " </td><td>" + Detalle.Horas + " </td><td>" + Detalle.Total + " </td><td>" + Detalle.Unidad_aEnt + "</td><td><input onblur='CalcularU(this);' maxlength='4' onfocus='Select(this);' onkeydown='Aceptar(event);' id='cantidadent" + i + "' type='text' class='span1 numero cantidadent' rel='" + i + "' value='" + Detalle.UnidadEnt + "'/></td><td><input onblur='CalcularU(this);' onfocus='Select(this);' maxlength='4' onkeydown='Aceptar(event);' id='Ucantidadent" + i + "' type='text' class='span1 numero Ucantidadent' rel='" + i + "' value='" + Detalle.Cantidad_aEnt + "'/></td><td>" + Detalle.Saldo + " </td><td>" + Detalle.Stock + " </td></tr>";
                    cant_med++;
                }
                objMedicamentos[i] = Detalle;
                objMedicamentos[i].Estado = 1;
                Total = Total + 1;
                i = i + 1;
            });
            var Pie = "</tbody></table>";
            $("#TablaMedicamentos").html(Encabezado + Contenido + Pie);
        },
        error: errores
    });
}

function LoadDetalles() {
    $.ajax({
        type: "POST",
        url: "../Json/Farmacia/IM.asmx/BuscarIM_ENT_Det",
        data: '{Id: "' + Pedido_Id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: LoadPedidoDet_Cargado,
        error: errores
    });
}

function LoadPedidoDet_Cargado(Resultado) {
    var Detalles = Resultado.d;
    var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th></th><th>Insumo</th><th>Dosis</th><th>Frec/Hs</th><th>Total Dosis</th><th>Unidades a Entregar</th><th>Dosis Entregada</th><th>Unidades Entregada</th><th>Saldo</th><th>Unidades Stock</th><th>Imprime Etiqueta</th></tr></thead><tbody>";
    var Contenido = "";
    var i = 0;

    $.each(Detalles, function (index, Detalle) {
        $("#btnHistorial").show();
        var check = "checked";
        if (!Detalle.Etiqueta) check = "";
		
		if(Detalle.Cantidad_aEnt == 0) check = "checked";
		
        if (Detalle.Insumo_Id != 0) { //Es Insumo
            
            Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' rel='tooltip' title='Editar'><i class='icon-edit'></i></a></td><td> " + Detalle.Nombre + " " + Detalle.Gramaje + Detalle.Medida + " - " + Detalle.Presentacion + " </td><td> " + parseFloat(Detalle.Cantidad) + " </td><td>" + Detalle.Horas + " </td><td>" + Detalle.Total + " </td><td>" + Detalle.Unidad_aEnt + "</td><td><input onblur='CalcularU(this);' maxlength='4' onfocus='Select(this);' onkeydown='Aceptar(event);' id='cantidadent" + i + "' type='text' class='span1 numero cantidadent' rel='" + i + "' value='" + Detalle.UnidadEnt + "'/></td><td><input onblur='CalcularU(this);' onfocus='Select(this);' maxlength='4' onkeydown='Aceptar(event);' id='Ucantidadent" + i + "' type='text' class='span1 numero Ucantidadent' rel='" + i + "' value='" + Detalle.Cantidad_aEnt + "'/></td><td>" + Detalle.Saldo + " </td><td>" + Detalle.Stock + " </td><td><input id='chk_Etiqueta" + i + "' data-id='" + i + "' class='et_check' type='checkbox' " + check + "/></td></tr>";
            cant_med++;
        }
        else { //Es Indicacion
            Contenido = Contenido + "<tr><td>&nbsp;</td><td> *" + Detalle.Indicacion + " </td><td> " + "" + " </td><td>" + "" + " </td><td>" + "" + " </td><td>" + "" + "</td><td>" + "" + " </td><td>" + "" + " </td><td>" + "" + " </td><td>" + "" + " </td><td>&nbsp;</th></tr>";
        }
        //Detalle.Saldo = Saldo;
        Detalle.Cant_Ini = Detalle.UnidadEnt;
        Detalle.Uni_Ini = Detalle.Cantidad_aEnt;

        Detalle.Unidad_aEnt_Original = Detalle.Unidad_aEnt; //Para cant. dias
        Detalle.Total_Original = Detalle.Total; //Para cant. dias


        objMedicamentos[i] = Detalle;
        objMedicamentos2[i] = Detalle;
        objMedicamentos[i].Estado = 1;
        Total = Total + 1;
        i = i + 1;
    });
    var Pie = "</tbody></table>";
    $("#TablaMedicamentos").html(Encabezado + Contenido + Pie);
}

$(document).on('click', '.et_check', function () {
    var index = $(this).data("id");
    objMedicamentos[index].Etiqueta = $("#chk_Etiqueta" + index).is(":checked");
});

function Editar(Nro) {
    Editando = 1;
    EditandoPos = Nro;
    TotalaSuministrar = 0;
    $("#cantidad").val(TotalaSuministrar);
    $("#txt_CantidadAnterior").val(objMedicamentos[Nro].UnidadEnt);
    $("#txt_UCantidadAnterior").val(objMedicamentos[Nro].Cantidad_aEnt);
    $("#gramaje_aux").val(objMedicamentos[Nro].Gramaje);
    Nombre_Alert = objMedicamentos[Nro].Nombre;
    Get_StockbyId(objMedicamentos[Nro].Insumo_Id);
    $("#cbo_Medicamento").val(objMedicamentos[Nro].Nombre);
    $("#medicamentoId").val(objMedicamentos[Nro].Insumo_Id);
    //$("#chk_Etiqueta").attr("checked", objMedicamentos[Nro].Etiqueta);
    if (parseInt(objMedicamentos[Nro].Insumo_Id) > 0) {
        TotalaSuministrar = objMedicamentos[Nro].Total;
        $("#cantidad").val(TotalaSuministrar);
        $("#cantidadent").val(objMedicamentos[Nro].UnidadEnt);
        $("#Observaciones").val(objMedicamentos[Nro].Observacion);
        $("#Ucantidad").val(objMedicamentos[Nro].Unidad_aEnt); // Unidades a entregar
        $("#Ucantidadent").val(objMedicamentos[Nro].Cantidad_aEnt);
        $("#Ucantidadent").removeAttr('disabled');
        $("#cantidadent").removeAttr('disabled');
    }
}

function Eliminar(Nro) {
    objMedicamentos[Nro].Estado = 0;
    objMedicamentos = $.grep(objMedicamentos, function (value) {
        return value.Estado != 0;
    });
    Total = Total - 1;
    RenderizarTabla_Modifica();
    $("#btnConfirmarEntrega").removeAttr("disabled");
}

function Existe(Algo) {
    for (var i = 0; i <= Total; i++) {
        if (objMedicamentos[i].Insumo_Id == Algo && objMedicamentos[i].Estado == 1 && Editando != 1) {
            alert("Ya ha cargado el Medicamento Nro: " + Algo);
            LimpiarCampos();
            $("#cbo_Medicamento").focus();
            return true;
        }
    }
    return false;
}

$("#medicamentoId").change(function () {
    Get_StockbyId($('#medicamentoId').val());
});

function Get_Insumo_by_Id(Id) {
    $.ajax({
        type: "POST",
        data: "{Id: '" + Id + "'}",
        url: "../Json/Farmacia/Farmacia.asmx/Get_Insumo_by_Id",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Get_Insumo_by_Id_Cargado,
        error: errores
    });
}

function Get_Insumo_by_Id_Cargado(Resultado) {
    var Insumo = Resultado.d;
    if (Insumo != null) {
        $("#stock_medicamento").html(Insumo.STO_CANTIDAD);
    }
    else $("#stock_medicamento").html('0');
}

function ModificarItem() {
    var index = parseInt($("#modificaItem").val());

    newpos = index + 1;
    //var cant = parseFloat($("#cantidadent" + index).val()) + parseFloat($("#txt_CantidadAnterior").val());
    var cant = parseFloat($("#cantidadent" + index).val());
    var stock = parseInt($("#stock_medicamento").html());
    //var Cantidad_aEnt = parseFloat($("#Ucantidadent" + index).val()) + parseFloat($("#txt_UCantidadAnterior").val());
    var Cantidad_aEnt = parseFloat($("#Ucantidadent" + index).val());
    UnidadEnt = cant;
    Observacion = $("#Observaciones").val().trim().toUpperCase();
    Stock = $("#stock_medicamento").html();
    var Estado = 1;
    var Cual = EditandoPos;
    objMedicamento = {};
    Nombre = objMedicamentos[Cual].Nombre;
    Codigo = objMedicamentos[Cual].Insumo_Id;
    objMedicamento.Insumo_Id = Codigo;
    objMedicamento.Cantidad = objMedicamentos[Cual].Cantidad;
    objMedicamento.Estado = Estado;
    objMedicamento.Nombre = Nombre;
    objMedicamento.Stock = Stock;
    objMedicamento.Observacion = Observacion;
    objMedicamento.UnidadEnt = UnidadEnt;
    objMedicamento.Unidad_aEnt = objMedicamentos[Cual].Unidad_aEnt;
    objMedicamento.Cantidad_aEnt = Cantidad_aEnt;
    objMedicamento.Horas = objMedicamentos[Cual].Horas;
    objMedicamento.Medida = objMedicamentos[Cual].Medida;
    objMedicamento.Total = objMedicamentos[Cual].Total;
    objMedicamento.Gramaje = objMedicamentos[Cual].Gramaje;
    //objMedicamento.Etiqueta = $("#chk_Etiqueta").is(":checked");
    objMedicamento.Etiqueta = objMedicamentos[Cual].Insumo_Id;
    if (objMedicamentos[Cual].Gramaje != "")
        objMedicamento.CantEnt = parseFloat(objMedicamento.UnidadEnt) * parseFloat(objMedicamentos[Cual].Gramaje);
    else objMedicamento.CantEnt = parseFloat(objMedicamento.UnidadEnt);
    var Saldo = parseFloat(TotalaSuministrar.toString()) - UnidadEnt;
    objMedicamento.Saldo = Saldo;
    objMedicamentos[Cual] = objMedicamento;
    RenderizarTabla_Modifica();
    Editando = 0;
    EditandoPos = -1;
    $("#btnConfirmarEntrega").removeAttr("disabled");
    LimpiarCampos();
}

$("#btnAgregarMedicamento").click(function () {
    if ($("#modificaItem").val() == "-1") return false;
    var valid = $("#frm_Cantidad").valid();
    if (valid) {
        RemoveClass();
        if (NroEntregaDet > 0) { ModificarItem(); return false; } //Es una modificacion


        var index = parseInt($("#modificaItem").val());

        newpos = index + 1;

        //FEDE ESTO ES PARA QUE NO SEA ACUMULATIVO
        //$("#txt_CantidadAnterior").val(objMedicamentos[EditandoPos].Cant_Ini);
        //$("#txt_UCantidadAnterior").val(objMedicamentos[EditandoPos].Uni_Ini);

        $("#txt_CantidadAnterior").val("0");
        $("#txt_UCantidadAnterior").val("0");
        
        var cant = parseFloat($("#cantidadent" + index).val()) + parseFloat($("#txt_CantidadAnterior").val());


        var stock = parseInt($("#stock_medicamento").html());

        var Cantidad_aEnt = parseFloat($("#Ucantidadent" + index).val()) + parseFloat($("#txt_UCantidadAnterior").val());

        UnidadEnt = cant;
        Observacion = $("#Observaciones").val().trim().toUpperCase();
        Stock = $("#stock_medicamento").html();
        var Estado = 1;
        var Cual = Total;
        if (Editando == 1) {
            Cual = EditandoPos;
        }
        else {
            Total = Total + 1;
            Cual = Total;
        }
        objMedicamento = {};
        Nombre = objMedicamentos[Cual].Nombre;
        Codigo = objMedicamentos[Cual].Insumo_Id;
        objMedicamento.DetalleId = objMedicamentos[Cual].DetalleId;

        objMedicamento.Cant_Ini = $("#txt_CantidadAnterior").val();
        objMedicamento.Uni_Ini = $("#txt_UCantidadAnterior").val();

        objMedicamento.Insumo_Id = Codigo;
        objMedicamento.Cantidad = objMedicamentos[Cual].Cantidad;
        objMedicamento.Estado = Estado;
        objMedicamento.Nombre = Nombre;

        objMedicamento.Stock = Stock;
        objMedicamento.Observacion = Observacion;
        objMedicamento.UnidadEnt = UnidadEnt;
        objMedicamento.Unidad_aEnt = objMedicamentos[Cual].Unidad_aEnt;
        objMedicamento.Cantidad_aEnt = Cantidad_aEnt;
        objMedicamento.Horas = objMedicamentos[Cual].Horas;
        objMedicamento.Medida = objMedicamentos[Cual].Medida;
        objMedicamento.Total = objMedicamentos[Cual].Total;
        objMedicamento.Gramaje = objMedicamentos[Cual].Gramaje;
        //objMedicamento.Etiqueta = $("#chk_Etiqueta").is(":checked");
        //objMedicamento.Etiqueta = true;
        if (objMedicamentos[Cual].Gramaje != "")
            objMedicamento.CantEnt = parseFloat(objMedicamento.UnidadEnt) * parseFloat(objMedicamentos[Cual].Gramaje);
        else objMedicamento.CantEnt = parseFloat(objMedicamento.UnidadEnt);
        var Saldo = parseFloat(TotalaSuministrar.toString()) - UnidadEnt;
        objMedicamento.Saldo = Saldo;
        objMedicamentos[Cual] = objMedicamento;
        RenderizarTabla();
        Editando = 0;
        EditandoPos = -1;
        $("#btnConfirmarEntrega").removeAttr("disabled");
        LimpiarCampos();
    }
});

function LimpiarCampos() {
    $("#stock_medicamento").html("0");
    $("#Observaciones").val("");
    $("#cantidadent").val("0");
    $("#cbo_Medicamento").val("");
    $("#medicamentoId").val("0");
    $("#modificaItem").val('-1');
    $("#txt_CantidadAnterior").val('0');
    $("#cantidad").val('0');
    $("#Ucantidadent").val('0');
    $("#Ucantidad").val('0');
    $("#txt_UCantidadAnterior").val('0');
    $("#cantidadent").attr('disabled',true);
    $("#Ucantidadent").attr('disabled',true);
    $("#Ucantidad").attr('disabled', true);
    //$("#chk_Etiqueta").removeAttr("checked");
    Editando = 0;
    EditandoPos = -1;
    TotalaSuministrar = 0;
}

function RenderizarTabla() {
    var Encabezado = "<table id='TablaMedicamentos' class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th></th><th>Insumo</th><th>Dosis</th><th>Frec/Hs</th><th>Total Dosis</th><th>Unidades a Entregar</th><th>Dosis Entregada</th><th>Unidades Entregada</th><th>Saldo</th><th>Unidades Stock</th><th>Imprime Etiqueta</th></tr></thead><tbody>";
    var Contenido = "";
    for (var i = 0; i <= Total; i++) {
        var check = "";
        if (objMedicamentos[i].Etiqueta) check = "checked";

        if (objMedicamentos[i].Insumo_Id != 0)
            Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' title='Editar'><i class='icon-edit'></i></a></td><td> " + objMedicamentos[i].Nombre + " " + objMedicamentos[i].Gramaje + objMedicamentos[i].Medida + " </td><td> " + parseFloat(objMedicamentos[i].Cantidad) + " </td><td>" + objMedicamentos[i].Horas + " </td><td>" + objMedicamentos[i].Total + " </td><td>" + objMedicamentos[i].Unidad_aEnt + " </td><td><input onblur='CalcularU(this);' onfocus='Select(this);' id='cantidadent" + i + "' type='text' maxlength='4' onkeydown='Aceptar(event);' class='span1 numero cantidadent' rel='" + i + "' value='" + objMedicamentos[i].UnidadEnt + "'/></td><td><input onblur='CalcularU(this);' maxlength='4' onkeydown='Aceptar(event);' id='Ucantidadent" + i + "' rel='" + i + "' type='text' onfocus='Select(this);' class='span1 numero Ucantidadent' value='" + objMedicamentos[i].Cantidad_aEnt + "'/></td><td>" + objMedicamentos[i].Saldo + " </td><td>" + objMedicamentos[i].Stock + " </td><td><input id='chk_Etiqueta" + i + "' data-id='" + i + "' class='et_check' type='checkbox' " + check + "/></td></tr>";
    else
        Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' title='Editar'><i class='icon-edit'></i></a></td><td> " + objMedicamentos[i].Indicacion + " </td><td> " + '' + " </td><td> " + '' + " </td><td>" + '' + " </td><td>" + '' + " </td><td>" + '' + " </td><td>&nbsp;</th><td>&nbsp;</th><td>" + '' + " </td><td>&nbsp;</th></tr>";
    }

    var Pie = "</tbody></table>";
    $("#TablaMedicamentos").html(Encabezado + Contenido + Pie);
    $("#cantidadent" + newpos).focus();
}

function RenderizarTabla_Modifica() {
    var Encabezado = "<table id='TablaMedicamentos' class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th></th><th>Insumo</th><th>Dosis</th><th>Frec/Hs</th><th>Total Dosis</th><th>Unidades a Entregar</th><th>Dosis Entregada</th><th>Unidades Entregada</th><th>Saldo</th><th>Unidades Stock</th><th>Imprime Etiqueta</th></tr></thead><tbody>";
    var Contenido = "";
    for (var i = 0; i <= Total; i++) {
        var check = "";
        if (objMedicamentos[i].Etiqueta) check = "checked";

        if (objMedicamentos[i].Insumo_Id != 0)
            Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' title='Editar'><i class='icon-edit'></i></a><a id='Elminar" + i + "'onclick='Eliminar(" + i + ");' class='btn btn-mini btn-danger' title='Quitar Insumo'><i class='icon-remove-circle icon-white'></i></a></td><td> " + objMedicamentos[i].Nombre + " " + objMedicamentos[i].Gramaje + objMedicamentos[i].Medida + " </td><td> " + parseFloat(objMedicamentos[i].Cantidad).toFixed(2) + " </td><td>" + objMedicamentos[i].Horas + " </td><td>" + objMedicamentos[i].Total + " </td><td>" + objMedicamentos[i].Unidad_aEnt + " </td><td><input onblur='CalcularU(this);' onfocus='Select(this);' id='cantidadent" + i + "' type='text' maxlength='4' onkeydown='Aceptar(event);' class='span1 numero cantidadent' rel='" + i + "' value='" + objMedicamentos[i].UnidadEnt + "'/></td><td><input onblur='CalcularU(this);' maxlength='4' onkeydown='Aceptar(event);' id='Ucantidadent" + i + "' rel='" + i + "' type='text' onfocus='Select(this);' class='span1 numero Ucantidadent' value='" + objMedicamentos[i].Cantidad_aEnt + "'/></td><td>" + objMedicamentos[i].Saldo + " </td><td>" + objMedicamentos[i].Stock + " </td><td><input id='chk_Etiqueta" + i + "' data-id='" + i + "' class='et_check' type='checkbox' " + check + "/></td></tr>";
    }
    var Pie = "</tbody></table>";
    $("#TablaMedicamentos").html(Encabezado + Contenido + Pie);
    $("#cantidadent" + newpos).focus();
}

$("#btnConfirmarEntrega").click(function () {
    if ($("#btnConfirmarEntrega").attr("disabled") == "disabled") return false;

    if (confirm("¿Desea confirmar la entrega?")) {

        if (NroEntregaDet > 0) {
            DeleteItems(); //Es una modificacion
            Pendiente = true;
        }
        else {
            VerificarPendiente();
            GetNroEntregaForRemito(); //Entrega nueva 
        }
    }
});

function DeleteItems() {
    var json = JSON.stringify({ "IdIM": Pedido_Id, "NroEntregaDet": NroEntregaDet });
    $.ajax({
        data: json,
        url: "../Json/Farmacia/IM.asmx/IM_DeleteItems_Modifica",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () { //Inserto Nuevos Items
            NroEntrega = NroEntregaDet;
            var json = JSON.stringify({ "i": objMedicamentos, "Sala": Sala_Id_Aux, "Cama": Cama_Id_Aux, "Id": Pedido_Id, "Tipo": "IM", "NroEnt": NroEntregaDet });
            $.ajax({
                data: json,
                url: "../Json/Farmacia/IM.asmx/Insert_IM_Ent",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: Insert_IM_Ent_Cargado,
                error: errores
            });
        },
        error: errores
    });
}

function VerificarPendiente() {
    Pendiente = false;
    for (var k = 0; k <= Total; k++) {
        if (objMedicamentos[k].Saldo > 0 && objMedicamentos[k].Insumo_Id > 0)
            Pendiente = true;
    }
}

function GetNroEntregaForRemito() {
    var json = JSON.stringify({ "IdIM": Pedido_Id });
    $.ajax({
        data: json,
        url: "../Json/Farmacia/IM.asmx/Get_NroEntrega_for_Remito",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Insert_IM_Ent,
        error: errores
    });
}

function Insert_IM_Ent(Resultado) {
    NroEntrega = Resultado.d;
    if (NroEntrega > 0) {
        var json = JSON.stringify({ "i": objMedicamentos, "Sala": Sala_Id_Aux, "Cama": Cama_Id_Aux, "Id": Pedido_Id, "Tipo": "IM", "NroEnt": NroEntrega });
        $.ajax({
            data: json,
            url: "../Json/Farmacia/IM.asmx/Insert_IM_Ent",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: Insert_IM_Ent_Cargado,
            error: errores
        });
    }
    else alert("Error al Ingresar Entrega");
}




function Insert_IM_Ent_Cargado(Resultado) {
    var json = JSON.stringify({ "Id": Pedido_Id, "Pendiente": Pendiente });
    $.ajax({
        data: json,
        url: "../Json/Farmacia/Farmacia.asmx/UpdateIMPendiente",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Print,
        error: errores
    });
    }

    function Print() {
        var str = "";
        if (NroEntregaDet > 0) str = "&M=1";
        $.fancybox(
        {
            'autoDimensions': false,
            'href': '../Impresiones/EntregasIM.aspx?Id=' + Pedido_Id + "&Nro=" + NroEntrega + str,
            'width': '75%',
            'height': '75%',
            'autoScale': false,
            'transitionIn': 'none',
            'transitionOut': 'none',
            'type': 'iframe',
            'hideOnOverlayClick': false,
            'enableEscapeButton': false,
            'onClosed': function () {
                                setTimeout(function () {
                                    Imprimir_Etiq(Pedido_Id, NroEntrega,1);
                                }, 1000);
                //window.location.href = "EntregasIM.aspx?Desde=" + Desde + "&Hasta=" + Hasta + "&ServId=" + ServId; //nueva entrega
            }
        });
    }

    function Imprimir_Etiq(Id, Nro, New) {
        $.fancybox(
                {
                    'autoDimensions': false,
                    'href': '../Impresiones/ImpresionFarmacia_Etiq.aspx?Id=' + Id + '&Nro=' + Nro + "&EsIM=1",
                    'width': '75%',
                    'height': '75%',
                    'autoScale': false,
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'type': 'iframe',
                    'hideOnOverlayClick': false,
                    'enableEscapeButton': false,
                    'onClosed': function () {
                        if (New == 1) window.location.href = "EntregasIM.aspx"; //New = 1 nueva entrega
                    }
                });
    }

    function EstaPendiente() {
        $.ajax({
            type: "POST",
            url: "../Json/Farmacia/Farmacia.asmx/IMPendiente",
            data: '{Id: "' + Pedido_Id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: EstaPendiente_Cargado,
            error: errores
        });
    }

    function EstaPendiente_Cargado(Resultado) {
        var EstaPendiente = Resultado.d;
        if (EstaPendiente) { //El Pedido Esta Pendiente
            $("#btnConfirmarEntrega").removeAttr("disabled");
        }
    }


    $("#EntregasModal").on('show', function () {
        $.ajax({
            type: "POST",
            url: "../Json/Farmacia/IM.asmx/VerHistorialEntregasIM",
            data: '{IMId: "' + $("#CargadoPedido").html() + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (Resultado) {
                var Entregas = Resultado.d;
                var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th>Nro. Entrega</th><th>Fecha</th><th>Usuario</th></tr></thead><tbody>";
                var Contenido = "";
                $.each(Entregas, function (index, Entrega) {
                    Contenido = Contenido + "<tr onclick=LoadPedido_Modifica(" + Entrega.NRO_ENTREGA + ")><td>" + Entrega.NRO_ENTREGA + " </td><td> " + Entrega.FECHA + " </td><td>" + Entrega.USUARIO + " </td></tr>";
                });
                var Pie = "</tbody></table>";
                $("#TablaEntregas_div").html(Encabezado + Contenido + Pie);
            },
            error: errores
        });
    });

    function LoadPedido_Modifica(NroEntregaDet) {
        window.location = "CargarEntregaIM.aspx?Id=" + $("#CargadoPedido").html() + "&NroEntregaDet=" + NroEntregaDet + "&Desde=" + Desde + "&Hasta=" + Hasta + "&ServId=" + ServId;
    }

    function LoadRemito(Entrega) {
        $.fancybox(
                {
                    'autoDimensions': false,
                    'href': '../Impresiones/EntregasIM.aspx?Id=' + $("#CargadoPedido").html() + "&Nro=" + Entrega,
                    'width': '75%',
                    'height': '75%',
                    'autoScale': false,
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'type': 'iframe',
                    'hideOnOverlayClick': false,
                    'enableEscapeButton': false,
                    'onClosed': function () {
                        setTimeout(function () { Imprimir_Etiq($("#CargadoPedido").html(), Entrega, 0); }, 1000);
                    }
                });
            }

            function Get_StockbyId(Id) {
                $.ajax({
                    type: "POST",
                    data: "{Id: '" + Id + "'}",
                    url: "../Json/Farmacia/Farmacia.asmx/Get_StockbyId",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: Get_StockbyId_Cargado,
                    beforeSend: function () {
                        $("#stock_medicamento").html('0');
                    },
                    error: errores
                });
            }

            function Get_StockbyId_Cargado(Resultado) {
                var Insumo = Resultado.d;
                if (Insumo != null) {
                    $("#stock_medicamento").html(Insumo.STO_CANTIDAD);
                    if (parseInt(Insumo.STO_MINIMO) > parseInt(Insumo.STO_CANTIDAD) && Nombre_Alert.length > 0) { alert("Insumo por debajo del stock mínimo."); Nombre_Alert = ""; }
                }
                else $("#stock_medicamento").html('0');
            }

            function CalcularU(obj) {                                
    $("#modificaItem").val("-1");
    var k = $(obj).attr("rel");
    $("#modificaItem").val(k);
    $("#Editar" + k).click();
    if ($(obj).hasClass("cantidadent")) {
        var dosis_total = parseFloat($("#cantidadent" + k).val() / $("#gramaje_aux").val());
        if (dosis_total - parseInt(dosis_total) > 0) dosis_total++;
        $("#Ucantidadent" + k).val(parseInt(dosis_total));
        Confirma = 1;
    }
    else {
        var dosis_total = parseFloat($("#Ucantidadent"+k).val() * $("#gramaje_aux").val());
        $("#cantidadent" + k).val(parseFloat(dosis_total));
        Confirma = 1;
    }
}

function Aceptar(event) {
    ValidarNum(event);
    var keyCode = event.keyCode;
    var i = parseInt($("#modificaItem").val());

   

    var ultimo = parseInt($('.cantidadent').last().attr("rel"));
    if (seleccionado == ultimo && keyCode == 9 && $(obj_seleccionado).hasClass("Ucantidadent")) { event.preventDefault(); $('.cantidadent').last().focus(); }
    if (Confirma == 0) return false;
    if (keyCode == 13) { //enter        
        event.preventDefault();
        if (parseFloat($("#cantidad").val()) <= 0) return false;
        if ($("#cantidadent" + i).val().trim().length == 0) return false;
        if ($("#Ucantidadent" + i).val().trim().length == 0) return false;
        $("#btnAgregarMedicamento").click();
        Confirma = 0;
    }
}

function Select(obj) {
    seleccionado = parseInt($(obj).attr("rel"));
    obj_seleccionado = $(obj);
    $(obj).select();
}

function ValidarNum(e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 110,190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
}


//FEDE ESTO ES PARA LA REIMPRESION
$("#btnImprimir").click(function () {
    LoadRemito($("#CargadoEntrega").html());
});

//FINALIZA MANUALMENTE UNA INDICACION... PARA QUE NO QUEDE PENDIENTE...
$("#btnFinalizarIM").click(function () {
    if (confirm("¿Desea finalizar la indicación?")) {
        if (Pedido_Id > 0) {
            var json = JSON.stringify({ "Id": Pedido_Id, "Pendiente": false });
            $.ajax({
                data: json,
                url: "../Json/Farmacia/Farmacia.asmx/UpdateIMPendiente",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    alert("La indicación ha sido finalizada.");
                    window.location.href = "EntregasIM.aspx?Desde=" + Desde + "&Hasta=" + Hasta + "&ServId=" + ServId;
                },
                error: errores
            });
        }
    }
});

$("#btnEntregaRapida").click(function () {
    if (confirm("¿Desea completar la entrega?")) Entrega_Rapida();
});

//Entrega Rapida, completa automaticamente lo pedido...
function Entrega_Rapida() {
    var Encabezado = "<table id='TablaMedicamentos' class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th></th><th>Insumo</th><th>Dosis</th><th>Frec/Hs</th><th>Total Dosis</th><th>Unidades a Entregar</th><th>Dosis Entregada</th><th>Unidades Entregada</th><th>Saldo</th><th>Unidades Stock</th><th>Imprime Etiqueta</th></tr></thead><tbody>";
    var Contenido = "";
    for (var i = 0; i <= Total; i++) {
        if (objMedicamentos[i].Insumo_Id != 0) {
            var check = "";
            

            objMedicamentos[i].UnidadEnt = objMedicamentos[i].Total;
            objMedicamentos[i].Cantidad_aEnt = objMedicamentos[i].Unidad_aEnt;
            objMedicamentos[i].Saldo = 0;
            objMedicamentos[i].Etiqueta = true;
			
			if (objMedicamentos[i].Etiqueta) check = "checked";
            Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' title='Editar'><i class='icon-edit'></i></a></td><td> " + objMedicamentos[i].Nombre + " " + objMedicamentos[i].Gramaje + objMedicamentos[i].Medida + " </td><td> " + parseFloat(objMedicamentos[i].Cantidad) + " </td><td>" + objMedicamentos[i].Horas + " </td><td>" + objMedicamentos[i].Total + " </td><td>" + objMedicamentos[i].Unidad_aEnt + " </td><td><input onblur='CalcularU(this);' onfocus='Select(this);' id='cantidadent" + i + "' type='text' maxlength='4' onkeydown='Aceptar(event);' class='span1 numero cantidadent' rel='" + i + "' value='" + objMedicamentos[i].UnidadEnt + "'/></td><td><input onblur='CalcularU(this);' maxlength='4' onkeydown='Aceptar(event);' id='Ucantidadent" + i + "' rel='" + i + "' type='text' onfocus='Select(this);' class='span1 numero Ucantidadent' value='" + objMedicamentos[i].Cantidad_aEnt + "'/></td><td>" + objMedicamentos[i].Saldo + " </td><td>" + objMedicamentos[i].Stock + " </td><td><input id='chk_Etiqueta" + i + "' data-id='" + i + "' class='et_check' type='checkbox' " + check + "/></td></tr>";
        }
        else
            Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' title='Editar'><i class='icon-edit'></i></a></td><td> " + objMedicamentos[i].Indicacion + " </td><td> " + '' + " </td><td> " + '' + " </td><td>" + '' + " </td><td>" + '' + " </td><td>" + '' + " </td><td>&nbsp;</th><td>&nbsp;</th><td>" + '' + " </td><td>&nbsp;</th></tr>";
    }

    var Pie = "</tbody></table>";
    $("#TablaMedicamentos").html(Encabezado + Contenido + Pie);
}

////Multiplicar por dias////

$("#Cant_Dias").change(function () {
    var Cantidad_dias = parseInt($("#Cant_Dias").val().trim());
    for (var i = 0; i <= Total; i++) {
        if (objMedicamentos[i].Insumo_Id != 0) {
            objMedicamentos[i].Unidad_aEnt = objMedicamentos[i].Unidad_aEnt_Original * Cantidad_dias;
            objMedicamentos[i].Total = objMedicamentos[i].Total_Original * Cantidad_dias;
        }
    }
    RenderizarTabla();
});