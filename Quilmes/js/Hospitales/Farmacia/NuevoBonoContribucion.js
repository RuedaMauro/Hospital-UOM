var objMedicamento = Array();
var Total = -1;
var Editando = 0;
var EditandoPos = 0;
var objMedicamentos = new Array();
var contra= 0;
var sourceArr = [];
var mapped = {};
var OS = 0;

function List_by_Monodroga(MonoId) {
    $.ajax({
        type: "POST",
        url: "../Json/Farmacia/Farmacia.asmx/Medicamentos_Lista_by_Mono",
        data: '{MonoId: "' + MonoId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Medicamentos_Cargado,
        beforeSend: function () {
            $("#cbo_Medicamento").attr("disabled", true);
        },
        complete: function () {
            $("#cbo_Medicamento").removeAttr("disabled");
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

$(document).ready(function () {
    $("#frm_Cantidad").validate({
        rules: {
            'cantidad': { required: true, number: true, range: [1, 999] },
            'descuento': { required: true, number: true, range: [0, 100] },
            'precio_medicamento': { required: true, number: true }
        },
        messages: {
            'cantidad': { required: ' ', number: ' ', range: ' ' },
            'descuento': { required: ' ', number: ' ', range: ' ' },
            'precio_medicamento': { required: ' ', number: ' ' }

        },
        invalidHandler: function (e, validator) {
            var list = validator.invalidElements();
            for (var i = 0; i < list.length; i++) {
                var name_element = $(list[i]).attr("name");
                $("#control" + name_element).addClass("error");
            }
        }

    });
    $("#txtNHC").mask("9999999999?9", { placeholder: "-" });
    $("#txt_dni").mask("9999999?9", { placeholder: "-" });
    List_by_Monodroga(0);
    ListTipoDoc();
    var Query = {};
    Query = GetQueryString();
    if (Query['NHC'] != null) {
        Cargar_Paciente_NHC(Query['NHC']);
    }
    if (Query['ID'] != null)
    {
        $("#afiliadoId").val(Query["ID"]);
        CargarPacienteID(Query["ID"]);
    }
});

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

$("#cbo_Medicamento").typeahead({
    source: sourceArr,
    updater: function (selection) {
        Get_Stock_byId(mapped[selection]);
        $("#txt_Medicamento").val(selection); //nom
        $("#Medicamento_val").html(mapped[selection]); //id
        $("#cantidad").focus();
        return selection;
    },
    minLength: 3,
    items: 15
});

function Cargar_Medicamentos_Guardia() {
    $.ajax({
        type: "POST",
        url: "../Json/Farmacia/Farmacia.asmx/Medicamentos_Lista_Guardia_SN",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Cargar_Medicamentos_Cargado,
        beforeSend: function () {
            $("#cbo_Medicamento").attr("disabled", true);
        },
        complete: function () {
            $("#cbo_Medicamento").removeAttr("disabled");
        },
        error: errores
    });
}

function Cargar_Medicamentos_Cargado(Resultado) {
    var Medicamentos = Resultado.d;
    $.each(Medicamentos, function (i, item) {
        if (i == 0) {
            sourceArr.length = 0;
        }
        if (Medicamentos[i].Medida != null) {
            var Medida = Medicamentos[i].Medida;
        }
        else {
            var Medida = '';
        }
        if (Medicamentos[i].Presentacion != null) {
            var Presentacion = Medicamentos[i].Presentacion;
        }
        else {
            var Presentacion = '';
        }
       str = Medicamentos[i].REM_NOMBRE + ' - ' + Medicamentos[i].REM_GRAMAJE + Medida + ' - ' + Presentacion;
       mapped[str] = item.REM_ID;
       sourceArr.push(str);
    });
}

function imgErrorPaciente(image) {
    image.onerror = "";
    image.src = "../img/silueta.jpg";
    return true;
}

$("#btnContraMovimiento").click(function () {
    contra = 1;
    $("#titulo_bono").html("Datos del Bono (Contramovimiento)");
    $("#btnContraMovimiento").hide();
});

$("#cantidad").blur(function (){
     $("#controlcantidad").removeClass("error");
});

$("#descuento").blur(function (){
     $("#controldescuento").removeClass("error");
});

$("#txt_dni").keypress(function (event) {
    if (event.which == 13) {
        if ($('#txt_dni').attr('readonly') == undefined) {
            Cargar_Paciente_Documento($("#txt_dni").val());
        }

    }
});

$("#precio_medicamento").blur(function () {
    var e = $("#precio_medicamento").val();
    if (!isNaN(Number(e)) && e != "")
        $("#precio_medicamento").val(parseFloat(e).toFixed(2));
});


$("#txt_dni").blur(function () {
    Cargar_Paciente_Documento($("#txt_dni").val()); 
});

$("#txtNHC").blur(function () {
    Cargar_Paciente_NHC($("#txtNHC").val());
});

$("#txtNHC").keypress(function (event) {
    if (event.which == 13) {
        if ($('#txtNHC').attr('readonly') == undefined) {
            Cargar_Paciente_NHC($("#txtNHC").val());
        }

    }
});

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

function Cargar_Paciente_NHC_Cargado(Resultado) {
    var Paciente = Resultado.d;
    var PError = false;


    $.each(Paciente, function (index, paciente) {

        $("#txt_dni").prop("readonly", true);
        $("#txtNHC").prop("readonly", true);

        $("#txtPaciente").attr('value', paciente.Paciente);
        $("#txt_dni").attr('value', paciente.documento);
        $("#txtNHC").attr('value', paciente.NHC);

        var AnioActual = new Date();
        var AnioNacimiento = new Date(parseJsonDate(paciente.fecha_nacimiento));


        var edad = AnioActual.getFullYear() - AnioNacimiento.getFullYear();
        if (AnioNacimiento.getFullYear() == 0) {
            edad = S / FN;
        }
        $("#CargadoEdad").html(paciente.Edad_Format);

        $("#CargadoApellido").html(paciente.Paciente);
        $("#CargadoTelefono").html(paciente.Telefono);
        var Seccional_Id = paciente.Nro_Seccional;
        if (Seccional_Id != 998) $("#CargadoSeccional").html(paciente.Seccional);
        else $("#CargadoSeccional").html(paciente.ObraSocial);
        OS = paciente.OSId;

        $("#CargadoDNI").html(paciente.documento_real);
        $("#CargadoNHC").html(paciente.cuil);

        $("#afiliadoId").val(paciente.documento);

        $('#fotopaciente').attr('src', '../img/Pacientes/' + paciente.cuil + '.jpg');

        if (PError) {
            $("#desdeaqui").hide();
        }
        else {
            $("#desdeaqui").show();
        }

    });

}

function Cargar_Paciente_Documento(Documento) {
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

function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}

function Get_Stock_byId(Id) {
    $.ajax({
        type: "POST",
        data: "{Id: '" + Id + "'}",
        url: "../Json/Farmacia/Farmacia.asmx/Get_StockbyId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Get_StockbyId_Cargado,
        beforeSend: function () {
            $("#precio_medicamento").val('0');
            $("#stock_medicamento").html('0');
            $("#precio_medicamento").attr('disabled',true);
        },
        error: errores
    });
}

function Get_StockbyId_Cargado(Resultado) {
    var Insumo = Resultado.d;
    $("#precio_medicamento").val(parseFloat(Insumo.REM_PRECIO).toFixed(2));
    $("#stock_medicamento").html(parseInt(Insumo.STO_CANTIDAD));
    $("#txtNrolote").val(Insumo.NROLOTE)
    $("#precio_medicamento").removeAttr("disabled");
    $("#cantidadx").val("1");
    $("#cantidad").val(0);
    $("#descuento").val(0);
}

function Calcular_Descuento() {
    Descuento = parseFloat($("#descuento").val());
    var porc = parseFloat(100);
    var desc = (porc - Descuento) / porc;
    return desc;
}

function Existe(Algo) {
    for (var i = 0; i <= Total; i++) {
        if (objMedicamentos[i].Codigo == Algo && objMedicamentos[i].Estado == 1 && Editando != 1) {
            alert("Ya ha cargado el Medicamento Nro: " + Algo);
            LimpiarCampos();
            $("#cbo_Medicamentos").focus();
            return true;
        }
    }
    return false;
}

function LimpiarCampos() {
    $("#precio_medicamento").val("0");
    $("#stock_medicamento").html("");
    $("#cantidadx").val("1");
    $("#cantidad").val("1");
    $("#descuento").val("");
    $("#btnAgregarMedicamento").html("<i class='icon-plus-sign icon-white'></i> Agregar");
    $("#btnCancelarMedicamento").html("<i class='icon-remove-circle icon-white'></i> Cancelar");
    $("#txt_Medicamento").val('');
    $("#cbo_Medicamento").val('');
    $("#txt_Medicamento").focus();
    $("#Medicamento_val").html('0');
    $("#txtNrolote").val("");
}

$(".numero").on('keydown', function (e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

$(".numeroDecimal").on('keydown', function (e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
        if (e.keyCode == 190) {
            if ($(this).val().indexOf('.') == -1 && $(this).val().trim().length > 0) return;
            else e.preventDefault();
        }
        else return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

function ValidarAgregarIns() {
    if ($("#Medicamento_val").html() == 0) { alert("Seleccione Insumo."); return false; }
    
    if (parseInt($("#cantidad").val()) <= 0) { alert("Ingrese Cantidad."); return false; }

    if ((parseInt($("#stock_medicamento").html()) < parseInt($("#cantidad").val())) && contra == 0) { alert("Insumo sin stock."); return false; }

    if ($("#precio_medicamento").val().length <= 0) { alert("Ingrese Precio."); return false; }
    return true;
}


$("#btnAgregarMedicamento").click(function () {
    Codigo = $("#Medicamento_val").html();

    if (Existe(Codigo)) return;
    if (!ValidarAgregarIns()) return false;

    Nombre = $("#txt_Medicamento").val();
    Cantidad = parseInt($("#cantidad").val());
    var desc = Calcular_Descuento();
    Descuento = parseInt($("#descuento").val());
    Precio = parseFloat($("#precio_medicamento").val().replace(",", "."));
    Subtotal = parseInt($("#cantidad").val()) * Precio * desc;
    Stock = parseInt($("#stock_medicamento").html());
    $("#cbo_Medicamento").removeAttr("disabled");
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
    objMedicamento.Codigo = Codigo;
    objMedicamento.CANT_UNIDADES = parseInt($("#cantidadx").val()); //CANT_UNIDADES es la cantidad de blister que llevan
    objMedicamento.Cantidad = Cantidad; // Cantidad es la cantidad total de unidades .... cant_unidades * unidades_por_blister
    objMedicamento.Precio = Precio;
    objMedicamento.Stock = Stock;
    objMedicamento.Descuento = Descuento;
    objMedicamento.Subtotal = Subtotal.toFixed(2);
    objMedicamento.Estado = Estado;
    objMedicamento.Nombre = Nombre;
    objMedicamento.NroLote = $("#txtNrolote").val();
    objMedicamentos[Cual] = objMedicamento;
    RenderizarTabla();
    LimpiarCampos();
    Editando = 0;
    EditandoPos = -1;
});



$("#btnCancelarMedicamento").click(function () {
    Editando = 0;
    EditandoPos = -1;
    $("#btnAgregarMedicamento").html("<i class='icon-plus-sign icon-white'></i> Agregar");
    $("#btnCancelarMedicamento").html("<i class='icon-remove-circle icon-white'></i> Cancelar");
    $("#cbo_Medicamento").removeAttr("disabled");
    LimpiarCampos();
});

function Cargar_Paciente_Documento_Cargado(Resultado) {
    var Paciente = Resultado.d;
    var PError = false;
    $.each(Paciente, function (index, paciente) {

        $("#txt_dni").prop("readonly", true);
        $("#txtNHC").prop("readonly", true);

        $("#txtPaciente").attr('value', paciente.Paciente);
        $("#txtNHC").attr('value', paciente.cuil);

        $("#CargadoApellido").html(paciente.Paciente);

        var AnioActual = new Date();
        var AnioNacimiento = new Date(parseJsonDate(paciente.fecha_nacimiento));


        var edad = AnioActual.getFullYear() - AnioNacimiento.getFullYear();
        if (AnioNacimiento.getFullYear() == 0) {
            edad = S / FN;
        }
        $("#CargadoEdad").html(paciente.Edad_Format);
        $("#CargadoDNI").html(paciente.documento_real);
        $("#CargadoNHC").html(paciente.cuil);
        $("#CargadoTelefono").html(paciente.Telefono);
        $("#afiliadoId").val(paciente.documento);
        var Seccional_Id = paciente.Nro_Seccional;
        if (Seccional_Id != 998) $("#CargadoSeccional").html(paciente.Seccional);
        else $("#CargadoSeccional").html(paciente.ObraSocial);
        $('#fotopaciente').attr('src', '../img/Pacientes/' + paciente.cuil + '.jpg');
        OS = paciente.OSId;
        if (PError) {
            $("#desdeaqui").hide();
        }
        else {
            $("#desdeaqui").show();
            $("#desdeaqui").focus();
        }

    });
}

function RenderizarTabla() {
    var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th></th><th>Insumo</th><th>Cantidad</th><th>Precio</th><th>Subtotal</th><th style='display:none;'>Descuento</th></tr></thead><tbody>";
    var Contenido = "";
    var Acumulado = 0;
    for (var i = 0; i <= Total; i++) {
        //Estado = 0 es Borrado
        if (objMedicamentos[i].Estado == 1) {
            var _insumo = objMedicamentos[i].Nombre;
            if (_insumo.length > 55) _insumo = _insumo.substring(0, 55);
            Contenido = Contenido + "<tr><td><a id='Editar" + i + "' onclick='Editar(" + i + ");' class='btn btn-mini' title='Editar Insumo'><i class='icon-edit'></i></a><a id='Elminar" + i + "'onclick='Eliminar(" + i + ");' class='btn btn-mini btn-danger' title='Quitar Insumo'><i class='icon-remove-circle icon-white'></i></a></td><td> " + _insumo + " </td><td> " + objMedicamentos[i].Cantidad + " </td><td> $ " + formatoMoneda(parseFloat(objMedicamentos[i].Precio)) + " </td><td> $ " + formatoMoneda(parseFloat(objMedicamentos[i].Subtotal)) + " </td><td style='display:none;'> " + objMedicamentos[i].Descuento + " </td></tr>";
            Acumulado = Acumulado + parseFloat(objMedicamentos[i].Subtotal);
        }
      
    }
    $("#Total").html("Precio TOTAL : $ " + formatoMoneda(parseFloat(Acumulado)));
    var Pie = "</tbody></table>";
    $("#TablaMedicamentos").html(Encabezado + Contenido + Pie);
}

function RecargarPagina(url) {
    document.location = "../Farmacia/BonoContribucion.aspx" + url;
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


function GetQueryString() {
    var querystring = location.search.replace('?', '').split('&');
    // declare object
    var queryObj = {};
    // loop through each name-value pair and populate object
    for (var i = 0; i < querystring.length; i++) {
        // get name and value
        var name = querystring[i].split('=')[0];
        var value = querystring[i].split('=')[1];
        // populate object
        queryObj[name] = value;
    }
    return queryObj;
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

$("a#inline").fancybox({
    'hideOnContentClick': true
});

function Editar(Nro) {
    Editando = 1;
    EditandoPos = Nro;
    $("#cantidad").val(objMedicamentos[Nro].Cantidad);
    $("#precio_medicamento").val(objMedicamentos[Nro].Precio);
    $("#descuento").val(objMedicamentos[Nro].Descuento);
    $("#cantidadx").val(objMedicamentos[Nro].CANT_UNIDADES);

    $("#txt_Medicamento").val(objMedicamentos[Nro].Nombre);
    $("#cbo_Medicamento").val($("#txt_Medicamento").val());

    $("#txt_Medicamento").attr('disabled', 'disabled');
    $("#Medicamento_val").html(objMedicamentos[Nro].Codigo);

    $("#btnAgregarMedicamento").html("<i class='icon-plus-sign icon-white'></i> Aceptar Cambio");
    $("#btnCancelarMedicamento").html("<i class='icon-remove-circle icon-white'></i> Cancelar Cambio");
    $("#stock_medicamento").html(objMedicamentos[Nro].Stock);
}

function Eliminar(Nro) {
    objMedicamentos[Nro].Estado = 0;    
    objMedicamentos = $.grep(objMedicamentos, function (value) {
        return value.Estado != 0;
    });
    Total = Total - 1;
    RenderizarTabla();
}

function Insert_Bono_Contribucion() {
    Nombre = $("#CargadoApellido").html();
    NHC = $("#afiliadoId").val();
    Auditor = 0;
    $.ajax({
        data: '{Afiliado_Nombre: "' + Nombre + '", NHC: "' + NHC + '" , Cod_Auditor: "' + Auditor + '"}',
        url: "../Json/Farmacia/Farmacia.asmx/Insert_Bono_Contribucion_Cabecera",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Insert_Bono_Contribucion_Cabecera_Cargado,
        error: errores
    });
}

function Insert_Bono_Contribucion_Detalles(IdBono, objMedicamentos) {
    var json = JSON.stringify({ "NroPedido": parseInt(IdBono), "objMedicamentos": objMedicamentos });
    $.ajax({
        type: "POST",
        data: json,
        url: "../Json/Farmacia/Farmacia.asmx/Insert_Bono_Contribucion_Detalle?Contramov=" + contra,
        contentType: "application/json; charset=utf8",
        dataType: "json",
        success: Insert_Bono_Contribucion_Detalles_Cargado,
        error: errores
    });
}

function Bono_Contribucion_Guardado(IdBono) {
    $.fancybox(
        {
            'autoDimensions': false,
		    'href': '../Impresiones/VentaalPublico_Impresion.aspx?Id=' + IdBono,
		    'width': '75%',
		    'height': '75%',
		    'autoScale': false,
		    'transitionIn': 'none',
		    'transitionOut': 'none',
		    'type': 'iframe',
		    'hideOnOverlayClick': false,
		    'enableEscapeButton': false,
		    'onClosed': function () {
		     window.location.href = "BonoContribucion.aspx";
        }
    });
}

function Insert_Bono_Contribucion_Detalles_Cargado(Resultado) {
    if (Resultado.d > 0) //Se guardo detalles de manera correcta
    {
        Bono_Contribucion_Guardado(Resultado.d);
    }
    else { //Resultado.d == -1
    alert("Error!!! No se Insertaron los detalles!!!")
    }

}

function Insert_Bono_Contribucion_Cabecera_Cargado(Resultado) {
    if (Resultado.d > 0) { //Si se inserto de manera correcta...ID_Bono
        Insert_Bono_Contribucion_Detalles(Resultado.d, objMedicamentos);
    }
    else {
        alert('Error!!!'); 
    }
}


$("#btnConfirmarBonoContribucion").click(function () {
    if (confirm("¿Desea confirmar el ingreso del bono contribución?")) {
        if (objMedicamentos.length > 0)
            Insert_Bono_Contribucion();
        else alert("No hay Medicamentos en la Lista");
    }
});

$("#txtPaciente").keypress(function (event) {
    if (event.which == 42) {
        if ($('#txtPaciente').attr('readonly') == undefined) {
            $("#desdeaqui").show();
        }
    }
});

$("#desdeaqui").click(function () {
    $("#CargadoApellido").html($('#txtPaciente').val());
    $("#txt_Medicamento").focus();
});

//function Get_StockbyId(Id) {
//    //Get_Insumo_by_Id(Id);
//    
//    $.ajax({
//        type: "POST",
//        data: "{Id: '" + Id + "'}",
//        url: "../Json/Farmacia/Farmacia.asmx/Get_StockbyId",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: Get_StockbyId_Cargado,
//        beforeSend: function () {
//            $("#stock_medicamento").html('0');
//        },
//        error: errores
//    });
//}

//function Get_StockbyId_Cargado(Resultado) {
//    var Insumo = Resultado.d;
//    $("#cbo_Medicamento").val($("#txt_Medicamento").val());
//    $("#stock_medicamento").html(Insumo.STO_CANTIDAD);
//    $("#cantidadx").val("1");
//    $("#cantidad").val("1");
//    $("#descuento").val(0);
//}

//function Precio_Insumo(Id) {
//    var json = JSON.stringify({ "InsumoId":Id });
//    $.ajax({
//        type: "POST",
//        data: json,
//        url: "../Json/Farmacia/Farmacia.asmx/Precio_Insumo",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (Resultado) {
//            $("#precio_medicamento").val(parseFloat(Resultado.d).toFixed(2));
//            $("#cantidadx").val("1");
//            $("#cantidad").val("1");
//            $("#descuento").val(0);
//        },
//        beforeSend: function () {
//            $("#precio_medicamento").val('0');
//        },
//        error: errores
//    });
//}

