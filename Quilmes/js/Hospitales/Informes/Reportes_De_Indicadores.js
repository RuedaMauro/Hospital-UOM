//parent.document.getElementById("DondeEstoy").innerHTML = "Informes > <strong>Reportes de Indicadores</strong>";
Traer_Indicadores();

function Traer_Indicadores() {
    $.ajax({
        type: "POST",
        url: "../Json/QuirofanoReporte.asmx/traerIndicadores",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: CargarIndicadores,
        error: errores
    });
}

function CargarIndicadores(resultado) {
    var lista = resultado.d;

    $("#Tindicadores").empty();
    var Encabezado = "<table class='table table-hover table-condensed' style='width: 100%;overflow:auto'><thead><tr><th></th></tr></thead><tbody>";
    var Contenido = "";
    $.each(lista, function (index, item) {
        //alert(item.descripcion);
        if (item.titulo == 1) {

            Contenido = Contenido + "<tr style='height:20px; background-color:#E2E8EB; cursor:defaulta'>" +
           "<td style='width:1%'><strong>" + item.codigo + "</strong></td>" +
            //           "<td onclick='Seleccionar(" + item.idIndicador + ")' style='width:2%'><input type='checkbox' id='" + item.idIndicador + "' onChange='Seleccionar(" + item.idIndicador + ")'/></td>" +
           "<td  style='width:2%'></td>" +
           "<td style='cursor:default;width:70%; text-align:left'><strong>" + item.descripcion.toUpperCase() + "</strong></td>" +
           "<td style='cursor:default' ></td>"
            //+ "<td><label><strong>Cantidad</strong></label></td>"
        } else {
            if (item.soon == 1) {
                Contenido = Contenido + "<tr style='height:20px; background-color:#E3CEF6 ;cursor:not-allowed'>" +
           "<td style='cursor:not-allowed'>" + item.codigo + "</td>" +
           "<td style='width:2%;cursor:not-allowed'><input type='checkbox' id='" + item.idIndicador + "' disabled='disabled'/></td>" +
           "<td style='cursor:not-allowed;width:70%; text-align:left'>" + item.descripcion + "</td>" +
           "<td style='cursor:not-allowed' ><div id='valor" + item.idIndicador + "'>PROXIMAMENTE</div></td>"
             } else {
                Contenido = Contenido + "<tr style='height:20px; cursor:pointer' id='fila" + item.idIndicador + "'>" +
           "<td onclick='Seleccionar(" + item.idIndicador + ")' >" + item.codigo + "</td>" +
           "<td onclick='Seleccionar(" + item.idIndicador + ")' style='width:2%'><input type='checkbox' id='" + item.idIndicador + "'  onChange='Seleccionar(" + item.idIndicador + ")' class='checks'/></td>" +
           "<td onclick='Seleccionar(" + item.idIndicador + ")' style='cursor:pointer;width:70%; text-align:left'>" + item.descripcion + "</td>" +
           "<td onclick='Seleccionar(" + item.idIndicador + ")' style='cursor:pointer' ><div id='valor" + item.idIndicador + "' class='valores'>    </div></td>"
            }
        }
        //$("#valor" + item.idIndicador).css("font-weight", "Bold");
    });
    var Pie = "</tbody></table>";
    $("#Tindicadores").html(Encabezado + Contenido + Pie);
  
  }

function errores(msg) {
var jsonObj = JSON.parse(msg.responseText);
alert('Error: ' + jsonObj.Message);
}

function Seleccionar(id) {
    if ($("#txtDesde").val() == "" || $("#txtHasta").val() == "") {
        alert("Ingrese un rango de Fechas.");
        $("#" + id).attr('checked', false);
        return false;
    }
    //alert(event.target.id);
    if (event.target.id == "") {
        $("#" + id).attr('checked', !$("#" + id).is(':checked'));
    }
    //alert(event.target.id);
    if ($("#" + id).is(':checked')) {
        Calcular_Indicadores(id);
    } else {
        $("#valor" + id).html("");
           }
    }



    function Calcular_Indicadores(id) {
//        alert(id);
//        return false;
    //alert(tipo);
    var json = JSON.stringify({ "desde": $("#txtDesde").val(), "hasta": $("#txtHasta").val(), "tipo": id });
    $.ajax({
        type: "POST",
        url: "../Json/QuirofanoReporte.asmx/CalcularIndicadores",
        contentType: "application/json; charset=utf-8",
        data: json,
        dataType: "json",
        beforeSend: function () {
            $("#cargando").show();
            //$("#Tindicadores").empty();
            $("#Tindicadores").hide();
        },
        complete: function () {
            $("#cargando").hide();
            $("#Tindicadores").show();
            $("#fila" + id).get(0).scrollIntoView();
        },
        success: mostrar,
        error: errores
    });

    function mostrar(resultado) {
        var obj = {};
        obj =  resultado.d;
        //alert(obj.cantidad);
        $("#valor" + id).html(obj.cantidad.toString());
        $("#valor" + id).css("font-weight", "Bold");
        $("#valor" + id).css("text-align", "right");
        //guardarEnTabla(id, obj.cantidad, $("#txtDesde").val(), $("#txtHasta").val());

    }
}
function guardarEnTabla(id, cantidad, desde, hasta) {
    var json = JSON.stringify({ "id": id, "cantidad": cantidad,"desde": $("#txtDesde").val(),"hasta": $("#txtHasta").val()});
    $.ajax({
        type: "POST",
        url: "../Json/QuirofanoReporte.asmx/actualizartabla",
        contentType: "application/json; charset=utf-8",
        data: json,
        dataType: "json",
        error: errores
    });

}

$("#txtDesde").datepicker({
    dateFormat: 'dd/mm/yy',
    changeMonth: true,
    changeYear: true,
    maxDate: '0m',
    onClose: function (selectedDate) {
        $("#txtHasta").datepicker("option", "minDate", selectedDate);
    },
    onSelect: function () {
        $(".valores").html("");
        $(".checks").attr('checked', false);
    }
});

$("#txtHasta").datepicker({
    dateFormat: 'dd/mm/yy',
    changeMonth: true,
    changeYear: true,
    minDate: '0m',
    onClose: function (selectedDate) {
        $("#txtDesde").datepicker("option", "maxDate", selectedDate);
    },
    onSelect: function () {
        $(".valores").html("");
        $(".checks").attr('checked', false);
    }
});

$("#txtHasta").mask("99/99/9999", { placeholder: "-" });
$("#txtDesde").mask("99/99/9999", { placeholder: "-" });


$("#btnImprimir").click(function () {
    if ($("#txtDesde").val() == "" || $("#txtHasta").val() == "") {
        alert("Ingrese un rango de Fechas.");
        return false;
    }

    var lista = new Array();
    $(".valores").each(function () {
        if ($(this).html() != "") {
            var obj = {};
            obj.idIndicador = parseInt($(this).attr('id').toString().replace("valor", ""));
            obj.cantidad = $(this).html();
            obj.desde = $("#txtDesde").val();
            obj.hasta = $("#txtHasta").val();
            lista.push(obj);
        }

    });

    var json = JSON.stringify({ "lista": lista });
    $.ajax({
        type: "POST",
        url: "../Json/QuirofanoReporte.asmx/actualizarImpresionIndicadores",
        contentType: "application/json; charset=utf-8",
        data: json,
        dataType: "json",
        success: imprimir,
        error: errores
    });
});

    function imprimir() {
        $.fancybox({
            'href': "../Impresiones/IndicadoresDeSeguridadSocial/Indicadores.aspx?desde=" + $("#txtDesde").val() + "&hasta=" + $("#txtHasta").val(),
            'width': '100%',
            'height': '75%',
            'autoScale': false,
            'transitionIn': 'elastic',
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
        });
    }

