var Cantidad_Estado = [0, 0]; //Entregados,Pendientes

function Contadores() {
    $("#btn_Libres").html("Pendientes (" + Cantidad_Estado[0] + ")");
    $("#btn_SobreT").html("Entregados (" + Cantidad_Estado[1] + ")");
    var Totales = Cantidad_Estado[0] + Cantidad_Estado[1];
    $("#btn_Todos").html("Todos (" + Totales + ")");
}

function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}


$(document).ready(function () {
    $("#frm_Main").validate({
        rules: {
            'desde': { dateES: true },
            'hasta': { dateES: true },
            'txtNroPed': { number: true }
        },
        messages: {
            'desde': { dateES: ' ' },
            'hasta': { dateES: ' ' },
            'txtNroPed': { number: ' ' }
        },
        invalidHandler: function (e, validator) {
            var list = validator.invalidElements();
            for (var i = 0; i < list.length; i++) {
                var name_element = $(list[i]).attr("name");
                $("#control" + name_element).addClass("error");
            }
        }

    });
    $("#desde").mask("99/99/9999", { placeholder: "-" });
    $("#hasta").mask("99/99/9999", { placeholder: "-" });
    $("#txtNHC").mask("9?9999999999", { placeholder: "-" });
    $("#txtNroPed").mask("9?99999999", { placeholder: "-" });
    var currentDt = new Date();
    var mm = currentDt.getMonth() + 1;
    mm = (mm < 10) ? '0' + mm : mm;
    var yyyy = currentDt.getFullYear();
    var dia = currentDt.getDate() > 9 ? currentDt.getDate() : '0' + currentDt.getDate();
    var d = dia + '/' + mm + '/' + yyyy;
    var p = '01' + '/' + mm + '/' + yyyy;
    $("#desde").val(p);
    $("#hasta").val(d);
    List_Servicios();
});

$(function () {
    $("#desde").datepicker({
        onClose: function (selectedDate) {
            $("#hasta").datepicker("option", "minDate", selectedDate);
        }
    });
    $("#hasta").datepicker({
        onClose: function (selectedDate) {
            $("#desde").datepicker("option", "maxDate", selectedDate);
        }
    });
});




function List_Servicios() {
    $.ajax({
        type: "POST",
        url: "../Json/Farmacia/Farmacia.asmx/List_Servicios",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: List_Servicios_Cargado,
        error: errores
    });
}

function List_Servicios_Cargado(Resultado) {
    var Lista = Resultado.d;
    $.each(Lista, function (index, Servicio) {
        $("#cbo_Servicio").append($("<option></option>").val(Servicio.id).html(Servicio.descripcion));
    });

}

$("#btn_Libres").click(function () {
    $(".reff").removeClass("reff_activo");
    $("#btn_Libres").addClass("reff_activo");
    Buscar();
});

$("#btn_SobreT").click(function () {
    $(".reff").removeClass("reff_activo");
    $("#btn_SobreT").addClass("reff_activo");
    Buscar();
});

$("#btn_Todos").click(function () {
    $(".reff").removeClass("reff_activo");
    $("#btn_Todos").addClass("reff_activo");
    Buscar();
});


$("#btnBuscar").click(function () {
    Buscar();
});

function Buscar() {
    var Pendiente = 0;
    if ($("#btn_Todos").hasClass("reff_activo")) Pendiente = 2;
    if ($("#btn_Libres").hasClass("reff_activo")) Pendiente = 1;
    if ($("#btn_SobreT").hasClass("reff_activo")) Pendiente = 0;
    var valid = $("#frm_Main").valid();
    if (valid) {
        var json = JSON.stringify({ "NHC": $('#txtNHC').val(), "Id": $('#txtNroPed').val(), "Desde": $('#desde').val(), "Hasta": $('#hasta').val(), "ServicioId": $('#cbo_Servicio :selected').val(), "Pendiente": Pendiente });
        $.ajax({
            type: "POST",
            url: "../Json/Farmacia/Farmacia.asmx/BuscarPPP_ENT",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: Pedidos_Cargados,
            error: errores,
            beforeSend: function () {
                $("#cargando").show();
                $("#TablaPedidos_div").hide();
            },
            complete: function () {
                $("#cargando").hide();
                $("#TablaPedidos_div").show();
                Contadores();
            }
        });
    }
}

function Pedidos_Cargados(Resultado) {
    Pedidos = Resultado.d;
    var Tabla_Datos = "";
    Cantidad_Estado = [0, 0]; //Entregados,Pendientes
    Tabla_Titulo = "<table id='TablaPedidos_div' class='table table-hover table-condensed' style='width: 100%;'><thead><tr><th>Pedido</th><th>NHC</th><th>Paciente</th><th>Servicio</th><th>Fecha</th><th>Usuario</th></tr></thead><tbody>";
    $.each(Pedidos, function (index, Pedido) {
        Clase = "Turnos_Libres";
        if (!Pedido.Pendiente) { Cantidad_Estado[1]++; Clase = "Turnos_Ocupados"; } //Entregados
        else Cantidad_Estado[0]++;
        Tabla_Datos = Tabla_Datos + "<tr class='" + Clase + "'";
        Tabla_Datos = Tabla_Datos + " style='cursor:pointer' onclick=Ventana('CargarEntregaPPP.aspx?Id=" + Pedido.Pedido_Id + "');";
        Tabla_Datos = Tabla_Datos + "><td>" + Pedido.Pedido_Id + "</td><td>" + Pedido.NHC + "</td><td>" + Pedido.Paciente + "</td><td>" + Pedido.Servicio + "</td><td>" + Pedido.Fecha + "</td><td>" + Pedido.Usuario + "</td></tr>";
    });

    Tabla_Fin = "</tbody></table>";
    $("#TablaPedidos_div").html(Tabla_Titulo + Tabla_Datos + Tabla_Fin);

}

function Ventana(url) {
    document.location = url;
}



