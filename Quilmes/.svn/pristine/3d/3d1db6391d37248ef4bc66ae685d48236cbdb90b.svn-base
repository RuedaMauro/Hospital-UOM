var listaPracticas = new Array();
var listaPracticas = new Array();
﻿var listaPracticas = new Array();
var listaModulos = new Array();
var listpracticas = [];
var valor = 0;
var total = 0;
var editar = 0;
var indiceEditar = 0;
var intAmbu = "";
var idAutorizacion = 0;
var GET = {};
var plantilla = {};
var copiar = 0;
var fecha = new Date();
var nombrePractica = "";
var idPractica = 0;
var avanzar = 0;

$(".fechas").mask("99/99/9999", { placeholder: "-" });
var f = "";
f = f + fecha.getDate();
f = f + "/" + (fecha.getMonth() + 1) + "/";
f = f + fecha.getFullYear();
$("#txtFechaMigue").val(f);

    ListTipoDoc();
    if ($("[rel=tooltip]").length) {
        $("[rel=tooltip]").tooltip();
    }
    $("#txt_dni").focus();
    var NHC = "";
    var Documento = "";
    $("#txtNHC").mask("9?9999999999", { placeholder: "-" });
    $("#txt_dni").mask("999999?99", { placeholder: "-" });
    $("#txtTelefono").mask("99999999?99999", { placeholder: "-" });

    document.location.search.replace(/\??(?:([^=]+)=([^&]*)&?)/g, function () {
        function decode(s) {
            return decodeURIComponent(s.split("+").join(" "));
        }

        GET[decode(arguments[1])] = decode(arguments[2]);
    });

if (GET["volver"] != "" && GET["volver"] != null) {
   
    $("#txt_dni").val(GET["volver"]);

    if (GET["idAutorizacion"] != "" && GET["idAutorizacion"] != null) {
        idAutorizacion = GET["idAutorizacion"];
    }
    if (GET["copiar"] != "" && GET["copiar"] != null) {
        copiar = GET["copiar"];
    }
    //setInterval("$('#txtNHC').focus();", 500);
    //$("#txtNHC").focus();
//        $("#txt_dni").change(function(){
//   alert();
//    });

    //$("#desdeaqui").click();
//    e = jQuery.Event("keypress")
//    e.which = 13 //choose the one you want
//    $("#desdeaqui").keypress(function(){
//    // alert('keypress triggered')
//    }).trigger(e)
//var callback = function(e){
//    console.log(e.type, e);
//    var text = e.type;
//    var code = 13;//e.which ? e.which : e.keyCode;
////    if(13 === code){
////        text += ': ENTER';
////    } else {
////        text += ': keycode '+code;
////    }
////    console.d(text);
//};
//alert(callback);
//$('#txt_dni').keydown(callback);
//$('#txt_dni').focusout(function(){
//alert();
//});

//alert(avanzar);
//if(avanzar == 0)
//{
//var e = jQuery.Event("keypress");
//e.which = 13; // # Some key code value
////alert(e);
//setInterval("$('#txt_dni').trigger(e);", 500);
//autoclick = setInterval("$('#desdeaqui').click();", 1000);
//setInterval("clearInterval(autoclick);",2000);
//}
}


cargarEditar(idAutorizacion);

    $(".fechas").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true
    });
   // $(".fechas").keydown(function () { return false; });
   //$(".fechas").mask("99/99/9999", { placeholder: "-" });
        $.ajax({
        type: "POST",
        url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerPracticasCombo",
        contentType: "application/json; charset=utf-8",
        data: '{tipo: "' + 2 + '"}',
        dataType: "json",
        success: function (Resultado) {
            listaPracticas = Resultado.d;
            $("#cboPractica").append(new Option("Seleccione", 0));
            $.each(listaPracticas, function (index, item) {
                $("#cboPractica").append(new Option(item.Practica, item.Codigo));
            });
        }
    });

    $.ajax({
        type: "POST",
        url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerModulosCombo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Resultado) {
            listaModulos = Resultado.d;
            $("#cboModulo").append(new Option("Seleccione", 0));
            $.each(listaModulos, function (index, item) {
                $("#cboModulo").append(new Option(item.nombre, item.id));
            });
        }
    });



    $("#txtCodigo").keyup(function () {
    
        $("#cboPractica").val($("#txtCodigo").val());
//        var json = JSON.stringify({ "id": $("#txtCodigo").val() });
//                $.ajax({
//            type: "POST",
//            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerPracticaPorCodigo",
//            contentType: "application/json; charset=utf-8",
//            data: json,
//            dataType: "json",
//            success: function (Resultado) {
//            //alert(Resultado.d);
//                 $("#cboPractica").val(Resultado.d);
//                 }
//        });  

        if ($("#txtCodigo").val().trim().length > 0) {
            $("#cboModulo").attr('disabled', true);
            $("#cboModulo").val(0);
            $("#txtCodMod").attr('disabled', true);
            $("#txtCodMod").val("");

            var json = JSON.stringify({ "prestador": $('#cboPrestador option:selected').val(), "practica": $("#txtCodigo").val() });
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerPreciosPrestadoresLista",
            contentType: "application/json; charset=utf-8",
            data: json,
            dataType: "json",
            success: function (Resultado) {
                valor = Resultado.d;
                $("#txtImporte").val(valor.valor);
                $("#txtCantidad").val("1");

                total = total + $("#txtImporte").val() * $("#txtCantidad").val();

                $("#txtTotal").val("$ " + total);
                seleccion.importe = $('#txtImporte').val();
            }
        });         
        } else {
            $("#cboModulo").attr('disabled', false);
            $("#cboModulo").val("");
            $("#txtCodMod").attr('disabled', false);
            $("#txtCodMod").val("");
            $("#txtImporte").val("");
        }
    });

            $("#txtCodigo").keydown(function (event) {
    if (event.shiftKey) {
        event.preventDefault();
    }

    if (event.keyCode == 46 || event.keyCode == 8) {
    }
    else {
        if (event.keyCode < 95) {
            if (event.keyCode < 48 || event.keyCode > 57) {
                event.preventDefault();
            }
        }
        else {
            if (event.keyCode < 96 || event.keyCode > 105) {
                event.preventDefault();
            }
        }
    }

});



    $("#cboPractica").change(function () {

         $("#txtCodigo").val($("#cboPractica").val());
//       $.each(mapped,function(index,item){
//       alert(item);
//       });
      // $("#txtCodigo").val(mapped[$("#cboPractica").val()]);

        if ($("#cboPractica").val() != 0) { $("#cboModulo").val(0); $("#cboModulo").attr('disabled', true); $("#txtCodMod").val(""); $("#txtCodMod").attr('disabled', true); } else { $("#cboModulo").attr('disabled', false); $("#txtCodMod").attr('disabled', false); }

    });

    $("#txtCodMod").keyup(function () {
        $("#cboModulo").val($("#txtCodMod").val());

        if ($("#txtCodMod").val().trim().length > 0) {
            $("#cboPractica").attr('disabled', true);
            $("#cboPractica").val(0);
            $("#txtCodigo").attr('disabled', true);
            $("#txtCodigo").val("");
        } else {
            $("#cboPractica").attr('disabled', false);
            $("#cboPractica").val(0);
            $("#txtCodigo").attr('disabled', false);
            $("#txtCodigo").val("");
            $("#txtImporte").val("");
        }
    });

    $("#txtCodMod").keydown(function (event) {
        if (event.shiftKey) {
            event.preventDefault();
        }

        if (event.keyCode == 46 || event.keyCode == 8) {
        }
        else {
            if (event.keyCode < 95) {
                if (event.keyCode < 48 || event.keyCode > 57) {
                    event.preventDefault();
                }
            }
            else {
                if (event.keyCode < 96 || event.keyCode > 105) {
                    event.preventDefault();
                }
            }
        } 
    });


    $("#cboModulo").change(function () {

        $("#txtCodMod").val($("#cboModulo").val());
        if ($("#cboModulo").val() != 0) { $("#cboPractica").val(0); $("#cboPractica").attr('disabled', true); $("#txtCodigo").val(""); $("#txtCodigo").attr('disabled', true); } else { $("#cboPractica").attr('disabled', false); $("#txtCodigo").attr('disabled', false); }
    });

    $('#btnactualizar').click(function () {
        Actualizar_Telefono_Seccional($('#txtTelefono').val(), $('#cboSeccional option:selected').val(), $('#afiliadoId').val());
    });


    $("#btnAgregar").click(function () {
        if ($("#cboPrestador").val() == 0) { alert("Seleccione Prestador"); return false; }
        if ($('#cboPractica option:selected').val() == 0 && $('#cboModulo option:selected').val() == 0) { alert("Seleccione una Práctica."); return false; }
//        if (mapped[("#cboPractica").val()] == 0 && $('#cboModulo option:selected').val() == 0) { alert("Seleccione una Práctica."); return false; }
        if ($('#cboModulo option:selected').val() == 0 && $('#cboPractica option:selected').val() == 0) { alert("Seleccione un Módulo"); return false; }
        if($('#cboSubrubro option:selected').val() == 0){alert("Seleccione un Subrubro"); return false;}
     // if ($('#cboModulo option:selected').val() == 0 && mapped[("#cboPractica").val()] == 0) { alert("Seleccione un Módulo"); return false; }
        if ($("#txtCantidad").val() == 0 || $("#txtCantidad").val() == "") { alert("Ingrese una Cantidad"); return false; }

        if ($('#cboPractica option:selected').val() != 0 && $('#cboModulo option:selected').val() != 0) { alert("Seleccione un Modulo o una Práctica por Vez"); return false; }
     //if (mapped[("#cboPractica").val()] != 0 && $('#cboModulo option:selected').val() != 0) { alert("Seleccione un Modulo o una Práctica por Vez"); return false; }
       // $("#cboPrestador").attr('disabled', true);

        if (editar == 1) {

            total = total - listpracticas[indiceEditar].importe;
            //            listpracticas[indiceEditar].codigoPrac = $('#cboPractica option:selected').val();
            //            listpracticas[indiceEditar].nombrePrac = $('#cboPractica option:selected').text();
            //            listpracticas[indiceEditar].codigoMod = $('#cboModulo option:selected').val();
            //            listpracticas[indiceEditar].nombreMod = $('#cboModulo option:selected').text();
            if (listpracticas[indiceEditar].esPractica == 0) {//$('#cboPractica option:selected').val() == 0) {
                listpracticas[indiceEditar].codigoPrac = $('#cboModulo option:selected').val();
                listpracticas[indiceEditar].nombrePrac = $('#cboModulo option:selected').text();
                listpracticas[indiceEditar].subRubroCodigo = $('#cboSubrubro option:selected').val();
                listpracticas[indiceEditar].subRubroNombre = $('#cboSubrubro option:selected').text();
                listpracticas[indiceEditar].prestadorCodigo = $('#cboPrestador option:selected').val();
                listpracticas[indiceEditar].prestadorNombre = $('#cboPrestador option:selected').text();
            } else {
                listpracticas[indiceEditar].codigoPrac = $('#cboPractica option:selected').val();
                listpracticas[indiceEditar].nombrePrac = $('#cboPractica option:selected').text();
                listpracticas[indiceEditar].subRubroCodigo = $('#cboSubrubro option:selected').val();
                listpracticas[indiceEditar].subRubroNombre = $('#cboSubrubro option:selected').text();
                listpracticas[indiceEditar].prestadorCodigo = $('#cboPrestador option:selected').val();
                listpracticas[indiceEditar].prestadorNombre = $('#cboPrestador option:selected').text();

            }
            listpracticas[indiceEditar].cantidad = $('#txtCantidad').val();
            listpracticas[indiceEditar].importe = $('#txtImporte').val() * $('#txtCantidad').val();

            //            var json = JSON.stringify({ "prestador": $('#cboPrestador option:selected').val(), "practica": $("#cboPractica").val() });
            //            $.ajax({
            //                type: "POST",
            //                url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerPreciosPrestadoresLista",
            //                contentType: "application/json; charset=utf-8",
            //                data: json,
            //                dataType: "json",
            //                success: function (Resultado) {
            //                    //                    valor = Resultado.d;
            //                    //                    total = total + valor.valor * $("#txtCantidad").val();

            //                    //                    $("#txtImporte").val(valor.valor * $("#txtCantidad").val());
            //                    //                    $("#txtTotal").val("$ " + total);
            //                    //                    listpracticas[indiceEditar].importe = $('#txtImporte').val();
            //                    //                    alert(listpracticas[indiceEditar].importe);

            //                    if (valor.valor > 0) {
            //                        $("#txtImporte").val(valor.valor * $("#txtCantidad").val());
            //                    } else {
            //                        var aux = $("#txtImporte").val() * $("#txtCantidad").val();
            //                        $("#txtImporte").val(aux);
            //                    }

            //                    total = total + $("#txtImporte").val() * $("#txtCantidad").val();

            //                    $("#txtTotal").val("$ " + total);
            //                    seleccion.importe = $('#txtImporte').val();
            //                },
            //            });

            //            var indice = listpracticas.length;
            //            listpracticas[indice] = seleccion;

            total = 0;
            $.each(listpracticas, function (index, item) { total = parseFloat(total) + parseFloat(item.importe); });
            $("#txtTotal").val(total);

            cargarTabla(listpracticas);
            editar = 0;
            $("#btnCancelarEdicion").click();
            $("#cboSubrubro").val(0);
            $("#cboPrestador").val(0);
        } else {
            var seleccion = {};
            //si el combo de practica esta en seleccione cargo el modulo y viceversa
            //if (mapped[("#cboPractica").val()] == 0) {
            if ($('#cboPractica option:selected').val() == 0) {
                seleccion.codigoPrac = $('#cboModulo option:selected').val();
                seleccion.nombrePrac = $('#cboModulo option:selected').text();
                seleccion.subRubroCodigo = $('#cboSubrubro option:selected').val();
                seleccion.subRubroNombre = $('#cboSubrubro option:selected').text();
                seleccion.prestadorCodigo = $('#cboPrestador option:selected').val();
                seleccion.prestadorNombre = $('#cboPrestador option:selected').text();
                seleccion.esPractica = 0;
                //alert(seleccion.esPractica);
            } else {
            //seleccion.codigoPrac = mapped[("#cboPractica").val()];
            //seleccion.nombrePrac = $('#cboPractica option:selected').text();
                seleccion.codigoPrac = $('#cboPractica option:selected').val();
                seleccion.nombrePrac = $('#cboPractica option:selected').text();
                seleccion.subRubroCodigo = $('#cboSubrubro option:selected').val();
                seleccion.subRubroNombre = $('#cboSubrubro option:selected').text();
                seleccion.prestadorCodigo = $('#cboPrestador option:selected').val();
                seleccion.prestadorNombre = $('#cboPrestador option:selected').text();
                seleccion.esPractica = 1;
            }

            seleccion.cantidad = $('#txtCantidad').val();
            seleccion.usuario = "";
            seleccion.fecha = "";
            //alert($('#txtImporte').val()); 
            if ($('#txtImporte').val() == "") { seleccion.importe = 0; } else { seleccion.importe = $('#txtImporte').val() * seleccion.cantidad; }


            var indice = listpracticas.length;
            //listpracticas[indice] = seleccion;
            listpracticas.push(seleccion);
            total = 0;
            $.each(listpracticas, function (index, item) { total = parseFloat(total) + parseFloat(item.importe); });
            $("#txtTotal").val("$ " + total);
            cargarTabla(listpracticas);
        }
    });


    function Eliminar(indice) {
    if(editar == 1){return false;}
        var resta = listpracticas[indice].importe;
        total = (total - resta);
        listpracticas.splice(indice, 1);
        if (total == 0) { $("#txtTotal").val("") } else { $("#txtTotal").val("$ " + total);}
        
        cargarTabla(listpracticas);
        restablecerControles();
        if (listpracticas.length <= 0) {$("#cboPrestador").attr('disabled', false); } 
    }

    function Edita(indice) {
        $("#btnCancelarEdicion").show();
        $("#btnAgregar").html("<i class='icon-plus-sign icon-white'></i> Aceptar Edicion");
        //$("#btnCancelarPractica").html("<i class='icon-remove-circle icon-white'></i> Cancelar Cambio");
        editar = 1;
        indiceEditar = indice;
        if (listpracticas[indice].esPractica == 1) {
            $("#cboPractica").val(listpracticas[indice].codigoPrac);
            $("#txtCodigo").val(listpracticas[indice].codigoPrac);
            $("#cboSubrubro").val(listpracticas[indice].subRubroCodigo);
            $("#cboPrestador").val(listpracticas[indice].prestadorCodigo);
            //deshabilito los controles de seleccion de modulo.
        $("#cboModulo").attr('disabled',true);
        $("#txtCodMod").attr('disabled',true);
        } 
        else {
        //alert(listpracticas[indice].codigoMod);
        $("#cboModulo").val(listpracticas[indice].codigoPrac);
        $("#txtCodMod").val(listpracticas[indice].codigoPrac);
        $("#cboSubrubro").val(listpracticas[indice].subRubroCodigo);
        $("#cboPrestador").val(listpracticas[indice].prestadorCodigo);
        //deshabilito los controles de seleccion de practica.
        $("#cboPractica").attr('disabled',true);
        $("#txtCodigo").attr('disabled',true);
        }
        $("#txtCantidad").val(listpracticas[indice].cantidad);
        $("#txtImporte").val(listpracticas[indice].importe);
     }

    function cargarTabla(lista) {

        $("#tablaPracticas").empty();
        var Contenido = "";
        var Pie = "";
        var Encabezado = "";
        //Encabezado = ""; //"<table class='tabla table-hover table-condensed' style='width: 100%;'><thead style='height:0px'><tr><th  style='width:8%'></th><th style='padding:0px; text-align:center; width:8%'></th><th style='padding:0px; text-align:center; width:60%;color:Black'></th><th style='padding:0px; text-align:center; width:10%;color:Black' ></th><th style='padding:0px; text-align:center; width:8%;color:Black'></th><th style='padding:0px; text-align:center; width:8%;color:Black'></th></tr></thead><tbody>";
        var cont = listpracticas.length - 1;
        $.each(lista, function (index, item) {

            //var numero = (parseInt(index) + 1);
            //alert(numero + "/" + item.codigoPrac + "/" + item.nombrePrac + "/" + item.cantidad + "/" + item.importe);
            var pract_mod_nomb = "";
            var prcat_mod_cod = 0;
            if (lista[cont].codigoPrac == 0) { pract_mod_nomb = lista[cont].nombreMod; } else { pract_mod_nomb = lista[cont].nombrePrac; }
            if (lista[cont].codigoPrac == 0) { prcat_mod_cod = lista[cont].codigoMod; } else { prcat_mod_cod = lista[cont].codigoPrac }
            Contenido = Contenido + "<tr style='width:100%'>" +
            "<td style='cursor:auto;width:6%;padding-left:3px;padding-right:3px'><a id='Editar" + cont + "' onclick='Edita(" + cont + ");' class='btn btn-mini' rel='tooltip' title='Editar Práctica'><i class='icon-edit'></i></a>" +
            "<a id='Elminar" + cont + "'onclick='Eliminar(" + cont + ");' class='btn btn-mini btn-danger' rel='tooltip' title='Quitar Práctica' style='float:right'><i class='icon-remove-circle icon-white'></i></a></td>" +
            "<td style='cursor:auto;width:5%;padding-left:3px;padding-right:3px; text-align:center; color:black'> " + prcat_mod_cod + " </td>" +
            "<td style='cursor:auto; width:30%;padding-left:3px;padding-right:3px; text-aling:center; color:black'>" + pract_mod_nomb + "</td>" +
            "<td style='width:8%;padding-left:3px;padding-right:3px; text-align:center; color:black'>" + lista[cont].cantidad + "</td>" +
            "<td style='width:1%;padding-left:3px;padding-right:3px'></td>" +
            "<td style='width:8%;padding-left:3px;padding-right:3px; text-align:center; color:black'>" + "$ " + lista[cont].importe + "</td>" +
            "<td style='width:20%;padding-left:3px;padding-right:3px; color:black'>" + lista[cont].subRubroNombre + "</td>" +
            "<td style='width:20%;padding-left:3px;padding-right:3px; color:black'>" + lista[cont].prestadorNombre + "</td>";
            cont--;
//                seleccion.subRubroCodigo 
//                seleccion.subRubroNombre
        });
        Pie = "</tbody></table>";
        $("#tablaPracticas").html(Encabezado + Contenido + Pie);
        restablecerControles();
    }

    function restablecerControles() {
        $("#cboPractica").val(0);
        $("#cboPractica").attr('disabled', false);
        $("#cboModulo").val(0);
        $("#cboModulo").attr('disabled', false);
        $("#txtCodigo").val("");
        $("#txtCodigo").attr('disabled',false);
        $("#txtCodMod").val("");
        $("#txtCodMod").attr('disabled', false);
        $("#txtCantidad").val(1);
        $("#txtImporte").val("");
        //$("#txtTotal").val("");
    }

    function restablecerControlesTodos() {
        $("#cboPractica").val(0);
        $("#cboPractica").attr('disabled', false);
        $("#cboModulo").val(0);
        $("#cboModulo").attr('disabled', false);
        $("#txtCodigo").val("");
        $("#txtCodigo").attr('disabled', false);
        $("#txtCodMod").val("");
        $("#txtCodMod").attr('disabled', false);
        $("#txtCantidad").val(1);
        $("#txtImporte").val("");
        $("#txtFechaMigue").val(f);
        $("#rdo_Ambulatorio").attr('checked', true);
        $("#cboSubrubro").val(0);
        $("#cboEspecialidad").val(0);
        $("#cboPrestador").val(0);
        $("#cboPrestador").attr('disabled', false);
        $("#cboMedInterno").val(0);
        $("#txtMedExt").attr('disabled', false);
        $("#txtMedExt").val("");
        $("#txtComentarios").val("");
        $("#cboEstado").val(0);
        $("#txtFecTurno").val("");
        $("#txtFecAuditado").val("");
        $("#txtFecRetirado").val("");
        listpracticas.length = 0;
        $("#tablaPracticas").empty();
        $("#txtTotal").val("0");
    }

    $("#btnCancelarEdicion").click(function () {
        indiceEditar = 0;
        editar = 0;
        $("#btnCancelarEdicion").hide();
        $("#btnAgregar").html("<i class='icon-plus-sign icon-white'></i> Agregar");
        restablecerControles();
        $("#cboSubrubro").val(0);
        $("#cboPrestador").val(0);
    });

    $("#btnGuardar").click(function () {
        if ($("#cboMedInterno").val() == 0 && $("#txtMedExt").val().trim().length == 0) { alert("Seleccione Médico"); return false; }
        //if ($("#txtMedExt").val().trim().length == 0) { alert("Ingrese Médico Externo"); return false; }

        //if ($("#cboSubrubro").val() == 0) { alert("Seleccione Sub Rubro"); return false; }
        if ($("#cboEspecialidad").val() == 0) { alert("Seleccione Especialidad"); return false; }

        //if ($("#cboPrestador").val() == 0) { alert("Seleccione Prestador"); return false; }

        if (listpracticas.length == 0) { alert("Cargue alguna Especialidad o Modulo"); return false; }
        //        if ($("#txtFecTurno").val() == "") { alert("Ingrese Fecha De Turno"); return false; }
        //        if ($("#txtFecAuditado").val() == "") { alert("Ingrese Fecha Auditado"); return false; }
        //        if ($("#txtFecRetirado").val() == "") { alert("Ingrese Fecha Retirado"); return false; }
        if ($("#cboEstado").val() == 0) { alert("Seleccione Un Estado"); return false; }
        if ($("#txtFechaMigue").val() == "") { alert("Ingrese una Fecha"); return false; }

        if ($("#rdo_Ambulatorio").is(':checked')) { intAmbu = "A" } else { intAmbu = "I" }

//        if (copiar == 1) {
//            idAutorizacion = 0;
//            copiar = 0;
//        }

        var json = JSON.stringify({
            "id": idAutorizacion
        //, "idRubro": $('#cboSubrubro option:selected').val()
        , "numero": 1
        , "idPaciente": $("#afiliadoId").val()
        , "intAmbu": intAmbu
        , "fecha": $("#txtFechaMigue").val()
        , "prestador": $("#cboPrestador").val()
        , "idEspecialidad": $('#cboEspecialidad option:selected').val()
        , "idMedico": $('#cboMedInterno option:selected').val()
        , "observacion": $("#txtComentarios").val()
        , "estado": $('#cboEstado option:selected').val()
        , "medicoExterno": $("#txtMedExt").val()
        , "fechaTurno": $("#txtFecTurno").val()
        , "fechaAuditado": $("#txtFecAuditado").val()
        , "fechaRetirado": $("#txtFecRetirado").val()
        //, "idPrestador": $('#cboPrestador option:selected').val()
        });


        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/GuardarActulizarEncabezado",
            contentType: "application/json; charset=utf-8",
            data: json,
            dataType: "json",
            success: function (Resultado) {
                idAutorizacion = Resultado.d;
                //                alert(Resultado.d);
               //                alert(idAutorizacion);
                //alert("guardado");
                guardarDetalle(idAutorizacion);
            }
            //complete: guardarDetalle(idAutorizacion)
        });
    });

    function guardarDetalle(id) {
   
//        $.each(listpracticas,function(index,item){
//        alert(item.subRubroCodigo + "/" + item.subRubroNombre + "/" + item.prestadorCodigo + "/" + item.prestadorNombre);
////               seleccion.subRubroCodigo = $('#cboSubrubro option:selected').val();
////                seleccion.subRubroNombre = $('#cboSubrubro option:selected').text();
////                seleccion.prestadorCodigo = $('#cboPrestador option:selected').val();
////                seleccion.prestadorNombre
//        });
        var json = JSON.stringify({"lista": listpracticas,"id": id });
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/GuardarDetalle",
            contentType: "application/json; charset=utf-8",
            data: json,
            dataType: "json",
            success: function (Resultado) {
                //idAutorizacion = Resultado.d;
                //                alert(Resultado.d);
                //                alert(idAutorizacion);
                alert("guardado. Número: " + idAutorizacion);
                idAutorizacion = 0;
                restablecerControlesTodos();
                chekearPendientes();
            }
        }); 
    }
     


     function  chekearPendientes(){
        var json = JSON.stringify({ "id": pacienteId });
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/ChekearPendientes",
            contentType: "application/json; charset=utf-8",
            data: json,
            dataType: "json",
            success: function(resultado){ 
            if(resultado.d == ""){
            $("#btnSinResolucion").hide();
            }} 
        });}

    $("#cboMedInterno").change(function () {
        if ($("#cboMedInterno").val() > 0) { $("#txtMedExt").val(""); $("#txtMedExt").attr('disabled', true); } else { $("#txtMedExt").attr('disabled', false); }
    });
    $("#txtMedExt").keyup(function () {
        if ($("#txtMedExt").val().trim().length > 0) { $("#cboMedInterno").val(0); $("#cboMedInterno").attr('disabled', true); } else { $("#cboMedInterno").attr('disabled',false); }
    });

    
    $("#btnVolver").click(function () {
      avanzar = 1;
        $("#primero").fadeIn(1500);
        $('html, body').animate({ scrollTop: $("#primero").offset().top - 60 }, 500);
        $('.container').height($('html').height() + ($('.contenedor_1').height() -
				$('.pie').height() -
				$('#primero').height()));
        //$('#cbo_Especialidad').focus();
        $("#autorizaciones").hide();
        $("#txt_dni").focus();
    });

    function cargarEditar(id) {
        //alert("cargar plantilla");
        //if (copiar == 1) { $("#cboPrestador").attr('disabled', true);}
        var json = JSON.stringify({ "id": id });
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerUnEncabezado",
            contentType: "application/json; charset=utf-8",
            data: json,
            dataType: "json",
            success: function (Resultado) {
                var lista = Resultado.d;
                $.each(lista, function (index, item) {
                    //alert(item.subRubroId);
                    plantilla.subRubroId = item.subRubroId;
                    plantilla.amb_int = item.amb_int;
                    plantilla.numero = item.numero;
                    plantilla.fecha = item.fecha;
                    plantilla.comentarios = item.comentarios;
                    plantilla.especialidadId = item.especialidadId;
                    plantilla.prestadorId = item.prestadorId;
                    plantilla.medicoInternoId = item.medicoInternoId;
                    plantilla.estadoId = item.estadoId;
                    plantilla.fechaTurno = item.fechaTurno;
                    plantilla.fechaAuditado = item.fechaAuditado;
                    plantilla.fechaRetiro = item.fechaRetiro;
                    plantilla.medicoExterno = item.medicoExterno;
                    //alert(plantilla.comentarios);
                    if (plantilla.amb_int == "A") { $("#rdo_Ambulatorio").attr('checked', true); } else { $("#radio_Internacion").attr('checked', true); }
                    $("#txtFechaMigue").val(plantilla.fecha);
                    $("#txtComentarios").val(plantilla.comentarios);
                    $("#txtMedExt").val(plantilla.medicoExterno);

                    if (plantilla.fechaTurno == "01/01/1900") {
                        $("#txtFecTurno").val("");
                    } else { $("#txtFecTurno").val(plantilla.fechaTurno); }
              
                    if (plantilla.fechaAuditado == "01/01/1900") {
                        $("#txtFecAuditado").val("");
                    } else { $("#txtFecAuditado").val(plantilla.fechaAuditado); }

                    if (plantilla.fechaRetiro == "01/01/1900") {
                        $("#txtFecRetirado").val("");
                    } else { $("#txtFecRetirado").val(plantilla.fechaRetiro); }
                });
                //alert(" plantilla cargada");
            },
            complete: function () {

                cargarDetalles(id);
                cargarSubRubro();
                cargarMedico();
                cargarEspecialidad();
                cargarEstados();
                cargarPrestadores();

            }
        });
    }

    $("#BtnBuscar").click(function () { document.location = "../DerivacionyTraslado/BuscarAutorizaciones.aspx?pacienteId=" + $("#afiliadoId").val(); });

    function cargarSubRubro() {
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerSubrubrosCombo",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (Resultado) {
                listaModulos = Resultado.d;
                $("#cboSubrubro").append(new Option("Seleccione", 0));
                $.each(listaModulos, function (index, item) {
                    $("#cboSubrubro").append(new Option(item.nombre, item.id));
                });
            }//,
//   complete: function () { $("#cboSubrubro").val(plantilla.subRubroId); }
        }); 
    }

    function cargarMedico() {
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerMedicosCombo",
            contentType: "application/json; charset=utf-8",
            data: '{id: "' + 0 + '"}',
            dataType: "json",
            success: function (Resultado) {
                var lista = Resultado.d;
                $("#cboMedInterno").append(new Option("Seleccione", 0));
                $.each(lista, function (index, item) {
                    $("#cboMedInterno").append(new Option(item.Medico, item.Id));
                });
            },
            complete: function () { $("#cboMedInterno").val(plantilla.medicoInternoId); }
        });
    }
    function cargarEspecialidad() {
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerEspecialidadesCombo",
            contentType: "application/json; charset=utf-8",
            data: '{id: "' + 0 + '"}',
            dataType: "json",
            success: function (Resultado) {
                var lista = Resultado.d;
                $("#cboEspecialidad").append(new Option("Seleccione", 0));
                $.each(lista, function (index, item) {
                    $("#cboEspecialidad").append(new Option(item.Especialidad, item.Id));
                });
            },
            complete: function () { $("#cboEspecialidad").val(plantilla.especialidadId); }
        });
    }

    function cargarEstados() {

        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerEstadosCombo",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (Resultado) {
                listaModulos = Resultado.d;
                $("#cboEstado").append(new Option("Seleccione", 0));
                $.each(listaModulos, function (index, item) {
                    $("#cboEstado").append(new Option(item.nombre, item.id));
                });
            },
            complete: function () { $("#cboEstado").val(plantilla.estadoId); }
        });
    }

    function cargarPrestadores() {

        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerPrestadoresCombo",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (Resultado) {
                listaPrestadores = Resultado.d;
                $("#cboPrestador").append(new Option("Seleccione", 0));
                $.each(listaPrestadores, function (index, item) {
                    $("#cboPrestador").append(new Option(item.nombre, item.id));
                });
            }//,
            //complete: function () { $("#cboPrestador").val(plantilla.prestadorId); }
        });
    
    }
    function cargarDetalles(id) {
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerDetallePlantilla",
            contentType: "application/json; charset=utf-8",
            data: '{id: "' + id + '"}',
            dataType: "json",
            success: function (Resultado) {
                listpracticas = Resultado.d;
                cargarTabla(listpracticas);
            },
            complete: function () {
                //if (listpracticas.length >= 0) {
                    total = 0;
                    $.each(listpracticas, function (index, item) { total = parseFloat(total) + parseFloat(item.importe); });
                    $("#txtTotal").val(total);
                //}
            }
        });
    }

    $("#cboPractica").change(function () {
        var json = JSON.stringify({ "prestador": $('#cboPrestador option:selected').val(), "practica": $("#cboPractica").val() });
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerPreciosPrestadoresLista",
            contentType: "application/json; charset=utf-8",
            data: json,
            dataType: "json",
            success: function (Resultado) {
                valor = Resultado.d;
//                alert(valor.valor);
                $("#txtImporte").val(valor.valor);
                $("#txtCantidad").val("1");
                //                if (valor.valor > 0) {
                //                    $("#txtImporte").val(valor.valor * $("#txtCantidad").val());
                //                } else {
                //                    var aux = $("#txtImporte").val() * $("#txtCantidad").val();
                //                    $("#txtImporte").val(aux);
                //                }

                total = total + $("#txtImporte").val() * $("#txtCantidad").val();

                $("#txtTotal").val("$ " + total);
                seleccion.importe = $('#txtImporte').val();
            }
        });
    });


    $("#cboPrestador").change(function () {
        var json = JSON.stringify({ "prestador": $('#cboPrestador option:selected').val(), "practica": $("#cboPractica").val() });
        $.ajax({
            type: "POST",
            url: "../Json/Autorizaciones/Autorizaciones.asmx/TraerPreciosPrestadoresLista",
            contentType: "application/json; charset=utf-8",
            data: json,
            dataType: "json",
            success: function (Resultado) {
                valor = Resultado.d;
//                alert(valor.valor);
                $("#txtImporte").val(valor.valor);
                $("#txtCantidad").val("1");
                //                if (valor.valor > 0) {
                //                    $("#txtImporte").val(valor.valor * $("#txtCantidad").val());
                //                } else {
                //                    var aux = $("#txtImporte").val() * $("#txtCantidad").val();
                //                    $("#txtImporte").val(aux);
                //                }

                total = total + $("#txtImporte").val() * $("#txtCantidad").val();

                $("#txtTotal").val("$ " + total);
                seleccion.importe = $('#txtImporte').val();
            }
        });
    });

    $("#txtImporte").keydown(function (event) {

        if (event.shiftKey) {
            event.preventDefault();
        }

        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 190 || event.keyCode == 110) {
        }
        else {
            if (event.keyCode < 95) {
                if (event.keyCode < 48 || event.keyCode > 57) {
                    event.preventDefault();
                }
            }
            else {
                if (event.keyCode < 96 || event.keyCode > 105) {
                    event.preventDefault();
                }
            }
        }
        $("#txtCantidad").val(1);
    });

    $("#txtCantidad").keydown(function (event) {
        if (event.shiftKey) {
            event.preventDefault();
        }

        if (event.keyCode == 46 || event.keyCode == 8) {
        }
        else {
            if (event.keyCode < 95) {
                if (event.keyCode < 48 || event.keyCode > 57) {
                    event.preventDefault();
                }
            }
            else {
                if (event.keyCode < 96 || event.keyCode > 105) {
                    event.preventDefault();
                }
            }
        }
    
    });

    $("#txtCantidad").keyup(function (event) {
        if (event.shiftKey) {
            event.preventDefault();
        }

        if (event.keyCode == 46 || event.keyCode == 8) {
        }
        else {
            if (event.keyCode < 95) {
                if (event.keyCode < 48 || event.keyCode > 57) {
                    event.preventDefault();
                }
            }
            else {
                if (event.keyCode < 96 || event.keyCode > 105) {
                    event.preventDefault();
                }
            }
        }
        if( isNaN($("#txtImporte").val()))
        $("#txtImporte").val(parseFloat($("#txtImporte").val()) * $("#txtCantidad").val());
    });

    ///////////////////////////////////////////////////MODIFICACIONES
//var sourceArr = [];
//var mapped = {};
//var idDYT = 0;
//var icd10ID = "";
//var Documento = 0;

//$("#cboPractica").typeahead({
//    updater: function (item) {
//        $("#cboPractica").val(item); //nom
//        $("#txtCodigo").val(mapped[item]); //id
//        icd10ID = mapped[item];
//        return item;
//    },
//    minLength: 4,
//    items: 50,
//    hint: true,
//    highlight: true,
//    source: function (query, process) {
//        var json = JSON.stringify({ "str": query });
//        $.ajax({
//            url: "../Json/Autorizaciones/Autorizaciones.asmx/CargarPractica_Autocomplete",
//            type: 'POST',
//            dataType: "json",
//            data: json,
//            contentType: "application/json; charset=utf-8",
//            success: function (Resultado) {
//                var lista = Resultado.d;
//                $.each(lista, function (i, icd) {
//                    if (i == 0) {
//                        sourceArr.length = 0;
//                    }
//                    str = icd.Descripcion;
//                    nombrePractica = icd.Descripcion;
//                    mapped[str] = icd.Codigo;
//                    idPractica = icd.Codigo;
//                    sourceArr.push(str);
//                });
//                return process(sourceArr);
//            }
//        });
//    }
//});
//var veces = 0;
//function efectoBlink()	{
//	parpadeo = document.getElementById("btnSinResolucion").style;
//	parpadeo.visibility = (parpadeo.visibility == "visible") ? "hidden" : "visible";
//    veces = veces + 1;
//    alert(veces);
//}

//if(veces <= 5){
//var tagBlink = setInterval("efectoBlink()", 500);
//}