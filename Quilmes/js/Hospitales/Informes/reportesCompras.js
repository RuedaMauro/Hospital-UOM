$("#titulo").html("Pedidos Compras");
$("#lbl1").html("Insumo");
$("#lbl2").html("Porcentaje");
$("#lbl3").html("Patología");

cargarCombo("cbo3", "../Json/reportesCompras.asmx/ReportesComprasTraerPatologias", 1, "");
cargarCombo("cbo1", "../Json/reportesCompras.asmx/ReportesComprasTraerInsumos", 1, "");

$("#cbo2").append(new Option("Seleccione", 0));
$("#cbo2").append(new Option("40%", 40));
$("#cbo2").append(new Option("70%", 70));
$("#cbo2").append(new Option("100%", 100));


$("#btnVolver").click(function () {
    document.location = "../Informes/ReportesDeCompras.aspx";
});

$("#btnPDF").click(function () {
    var comprobar = [];
    $(".fechaMask").each(function () {
        if ($(this).val() == "") { comprobar.push(1); }
    });
    if (comprobar.length >= 1) { alert("Ingrese un rango de fechas."); return false; }
    imprimir("../Impresiones/ReportesCompras/Reporte_Compras_Pedidos_Susana.aspx?desde=" + $("#txtDesde").val() + "&hasta=" + $("#txtHasta").val() + "&insumo=" + $("#cbo1").val() + "&descuento=" + $("#cbo2").val() + "&discapacidad=" + $("#cbo3").val() + "&PDF=1", 0);
});

$("#btnEXECL").click(function () {
    var comprobar = [];
    $(".fechaMask").each(function () {
        if ($(this).val() == "") { comprobar.push(1); }
    });
    if (comprobar.length >= 1) { alert("Ingrese un rango de fechas."); return false; }
     imprimir("../Impresiones/ReportesCompras/Reporte_Compras_Pedidos_Susana.aspx?desde=" + $("#txtDesde").val() + "&hasta=" + $("#txtHasta").val() + "&insumo=" + $("#cbo1").val() + "&descuento=" + $("#cbo2").val() + "&discapacidad=" + $("#cbo3").val() + "&PDF=0", 0);
 });
