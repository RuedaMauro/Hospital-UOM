<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelacionPracticaIndicaciones.aspx.cs" Inherits="Imagenes_Turno_RelacionPracticaIndicaciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<META http-equiv="Content-Type" CONTENT="text/html; charset=iso-8859-1">
<title>Gesti�n Hospitalaria</title>
<link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../css/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
<link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
<link href="../css/Hospitales.css" rel="stylesheet" type="text/css" />
<link href="../css/barra.css" rel="stylesheet" type="text/css" />

<style>
.active {background-color:Yellow;}
.manito {cursor:pointer;}
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="Contenedor_Info_Medico well"><select id="cbo_especialidad">            
        </select></div>
    </div>

    <div class="well">
    <div class="well" style="display:block; width:500px; height:500px; background-color:#F3EFFD; float:left; max-height: 500px; min-height:500px; overflow:auto; " id="div_practicas">
        
    </div>



    <div class="well" style="display:block; width:700px; height:500px; background-color:#F3EFFD; float:left; max-height: 500px; min-height:500px; overflow:auto;" id="div_indicaciones">
        
    </div>

    <div style="clear:both;"></div>

    </div>

    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/bootstrap.js"></script> 

    <script src="../js/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
    <script src="../js/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
    <script src="../js/jquery.validate.js" type="text/javascript"></script>
    <script src="../js/ui-datepicker-es.js" type="text/javascript"></script>
    <script src="../js/GeneralG.js" type="text/javascript"></script>
    <script src="../js/Hospitales/ObraSociales/ObraSociales.js" type="text/javascript"></script>
    <script src="../js/Hospitales/Gente/Vencimiento.js" type="text/javascript"></script>

    <script>

        $("#cbo_especialidad").change(function () {            
                CargarListaDePracticas($("#cbo_especialidad :selected").val());                
        });


        

        function CargarListaDePracticas(EspecialidadId) {
            var json = JSON.stringify({ "PracticaId": 0, "EspecialidadId": EspecialidadId });
            $.ajax({
                type: "POST",
                url: "../Json/Practicas/Practicas.asmx/H2_IMAGENES_PRACTICAS_LISTAR",
                data: json,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: Practicas_Listadas,
                error: errores
            });
        }


        var Array_Practicas = Array()
        function Practicas_Listadas(Resultado) {            
            datos = "";
            $("#div_practicas").empty();
            var lista = Resultado.d;
            $.each(lista, function (index, dato) {
                var Objeto_Practicas = {}
                Objeto_Practicas.Practica_Nombre = dato.PracticaNombre;
                Objeto_Practicas.Practica_Id = dato.PracticaCodigo;
                datos = datos + "<div><a class='manito pract_opciones' onclick='Cargar(" + dato.PracticaCodigo + ",this)'>" + dato.PracticaNombre + "</a></div>";
            });
            $("#div_practicas").html(datos);
        }







        var QuePractica = 0;
        function Cargar(Practica, este) {
            $(".pract_opciones").removeClass("active");
            $(este).addClass("active");
            QuePractica = Practica;
            var json = JSON.stringify({ "Practica": Practica });
            $.ajax({
                type: "POST",
                url: "../Json/Imagenes/Imagenes.asmx/IMG_PREPARACION_LISTA",
                data: json,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: Preparacion_Listadas,
                error: errores
            });
        }


        
        function Preparacion_Listadas(Resultado) {
            datos = "";
            $("#div_indicaciones").empty();
            var lista = Resultado.d;
            $.each(lista, function (index, dato) {
                check = "checked";
                if (!dato.ESTADO) {
                    check = "";
                }
                datos = datos + "<div><input type='checkbox' id='ck_" + dato.ID + "' onclick='CambiarEstado(" + dato.ID + ",this);' value='" + dato.ID + "' " + check + "/><label class='manito' for='ck_" + dato.ID + "' style='display:inline;'>" + dato.TITULO + "</label></div>";
            });
            $("#div_indicaciones").html(datos);
        }

                
        function CambiarEstado(id, este) {
            var json = JSON.stringify({ "Practica": QuePractica, "PreparacionId": id });
            $.ajax({
                type: "POST",
                url: "../Json/Imagenes/Imagenes.asmx/IMG_PREPARACION_ACTUALIZAR",
                data: json,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (resultado) { 
                },
                error: errores
            });
        }



        function errores(msg) {
            var jsonObj = JSON.parse(msg.responseText);
            alert("Error " + jsonObj.Message);
        }


        parent.document.getElementById("DondeEstoy").innerHTML = "Im�genes > <strong>Indicaciones de Pr�cticas</strong>";


        function CargarListaDeEspecialidades() {
            var json = JSON.stringify({ "PracticaId": 0, "EspecialidadId": 0 });
            $.ajax({
                type: "POST",
                url: "../Json/Imagenes/Imagenes.asmx/Imagenes_Especialidades",
                data: json,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: Especialidades_Listadas,
                error: errores
            });
        }

        function Especialidades_Listadas(Resultado) {
            var lista = Resultado.d;
            $('#cbo_especialidad').append($('<option>', { value: 0, text: "Seleccione Especialidad" }));
            $.each(lista, function (index, dato) {
                $('#cbo_especialidad').append($('<option>', { value: dato.Id, text: dato.Especialidad }));
            });
        }

        CargarListaDeEspecialidades();

    </script>

    </form>



</body>
</html>
