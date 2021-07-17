var sourceArr = [];
var mapped = {};

$(document).ready(function () {
    List_by_Monodroga(0);
});


function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}

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

$("#cbo_Medicamento").typeahead({
    source: sourceArr,
    updater: function (selection) {
        Get_StockbyId(mapped[selection]);
        $("#txt_Medicamento").val(selection); //nom
        $("#Medicamento_val").html(mapped[selection]); //id
        List_Lotes_by_Insumo(mapped[selection]);
    },
    minLength: 4,
    items: 10
});

function Cargar_Medicamentos_Cargado(Resultado) {
    var Medicamentos = Resultado.d;
    $.each(Medicamentos, function (i, item) {
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
        if (i == 0) {
            sourceArr.length = 0;
        }
        str = Medicamentos[i].REM_NOMBRE + ' - ' + Medicamentos[i].REM_GRAMAJE + Medida + ' - ' + Presentacion;
        mapped[str] = item.REM_ID;
        sourceArr.push(str);
    });
}

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

function Get_StockbyId(Id) {
    $.ajax({
        type: "POST",
        data: "{Id: '" + Id + "'}",
        url: "../Json/Farmacia/Farmacia.asmx/Get_StockbyId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Get_StockbyId_Cargado,
        error: errores
    });
}

function Get_StockbyId_Cargado(Resultado) {
    var Insumo = Resultado.d;
    $("#cbo_Medicamento").val($("#txt_Medicamento").val());
}

function List_Lotes_by_Insumo(Id) {
    $.ajax({
        type: "POST",
        data: "{Id: '" + Id + "'}",
        url: "../Json/Farmacia/Farmacia.asmx/List_Lotes_by_Insumo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: List_Lotes_by_Insumo_Cargado,
        error: errores
    });
}

function List_Lotes_by_Insumo_Cargado(Resultado) {
    var Lotes = Resultado.d;
    $("#cbo_Lotes").empty();
    $("#cbo_Lotes").append($("<option></option>").val('-1').html('SIN ASIGNAR LOTE'));
    $.each(Lotes, function (index, Lote) {
        $("#cbo_Lotes").append($("<option></option>").val(Lote.NROLOTE).html(Lote.NROLOTE));
    });
}

$("#cbo_Lotes").change(function () {
    $("#lblFechaVencimiento").html("");
    var json = JSON.stringify({ "IdInsumo": $("#Medicamento_val").html(), "NroLote": $("#cbo_Lotes :selected").val() });
    $.ajax({
        type: "POST",
        data: json,
        url: "../Json/Farmacia/Farmacia.asmx/Insumo_StockInfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            $("#lblFechaVencimiento").html(Resultado.d.STO_VENCIMIENTO);
        },
        error: errores
    });
});

function Validar() {
    var currentDt = new Date();
    var mm = currentDt.getMonth() + 1;
    mm = (mm < 10) ? '0' + mm : mm;
    var yyyy = currentDt.getFullYear();
    var dia = currentDt.getDate() > 9 ? currentDt.getDate() : '0' + currentDt.getDate();
    var d = dia + '/' + mm + '/' + yyyy; //fecha del dia

    if ($("#chkVencimiento").is(":checked")) { if (process($("#lblFechaVencimiento").html()) > process(d)) { alert("No se puede descontar stock. No se ha cumplido el vencimiento del lote."); return false; } }

    if ($("#Medicamento_val").html() == "0") { alert("Ingrese Insumo."); return false; }
    if ($("#cantidad").val().trim().length == "0") { alert("Ingrese Cantidad."); return false; }
    return true;
}

function process(date) {
    var parts = date.toString().split("/");
    return new Date(parts[2], parts[1] - 1, parts[0]);
}

function LoadData(){
     var f = {};
     var Motivo = "Vencimiento";
     if ($("#chkRotura").is(":checked")) Motivo = "Rotura";     
     f.CodigoMovimiento = 4; //1 ingreso, 2 egreso, 3 inventario, 4 Descuento Stock
     f.Descripcion = "Descuento de Stock de Insumo " + $("#Medicamento_val").html() + " por " + Motivo + " - Nro. Lote " + $("#cbo_Lotes :selected").text();
     f.InsumoId = $("#Medicamento_val").html();
     f.Cantidad = parseInt($("#cantidad").val()) * -1;
     f.PedidoId = 0;
     f.PedidoTipo = 8; //Descuento Stock
     f.NroLote = $("#cbo_Lotes :selected").val();
     return f;
}

$("#btnCargar").click(function () {
    if (confirm("¿Desea continuar?")) {
        if (!Validar()) return false;
        var f = LoadData();
        var json = JSON.stringify({ "m": f });
        $.ajax({
            data: json,
            url: "../Json/Farmacia/Farmacia.asmx/InsertMovimientoCtaCteInsumos",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                alert("Descuento de stock realizado.");
                document.location = "Descontar_Stock.aspx";
            },
            error: errores
        });
    }
});