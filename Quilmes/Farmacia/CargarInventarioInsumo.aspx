<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargarInventarioInsumo.aspx.cs" Inherits="Farmacia_CargarInventarioInsumo" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<META http-equiv="Content-Type" CONTENT="text/html; charset=iso-8859-1">
<title>Gestión Hospitalaria</title>
       <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/barra.css" />
    <link href="../css/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/autocomplete-tweet.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />

</head>

<body>
<div class="clearfix"></div>


<div id="lightbox" style="display:none;position:absolute;z-index:899;width:100%; height:100%;background-color:RGBA(255,255,255,0.8);"> </div>

<div class="container" style="padding-top:30px;">
  <div class="contenedor_1">
   <div class="contenedor_3" style="height:480px;"> <div class="titulo_seccion" id="titulo_bono">
      <span>Cargar Inventario</span></div>
       <form id="frm_Medicamentos">
        <div class="row">
             <div class="combos" style="margin-left:40px;">
                <div id="Medicamento_val" style="display:none;">0</div>
                <input id="txt_Medicamento" name="txt_Medicamento" value="0" type="hidden" />
                <label for="cbo_Medicamento" style="display:inline;width:80px;" class="span1">Insumo:</label>
                    <input type="text" id="cbo_Medicamento" data-provide="typeahead" autocomplete="off" style="width:600px;" />
             </div> 
        </div>
        <div class="row">
            <div class="span7" style="margin-left:50px; margin-top:10px;">
                <div id="controlote" class="control-group">
                <label for="lote" style="display:inline;margin-right:20px;">Nro. Lote:</label>
                  <select id="cbo_Lotes" class="span5"></select>
                  <input type="hidden" id="lote" name="lote"/>
                  </div>
            </div>
        </div>
        <div class="row">
            <div class="span4" style="margin-left:50px; margin-top:10px;">
                <div id="controlFechaVto" class="control-group">
                <label for="FechaVto" style="display:inline;">Fecha Vto.:</label>
                  <input type="text" id="FechaVto" name="FechaVto" class="input-small" style="margin-left:10px;"/>
                  </div>
            </div>
        </div>
        <div class="row">
            <div class="span4" style="margin-left:50px; margin-top:10px;">
                <div id="controlcantidad" class="control-group">
                <label for="cantidad" style="display:inline;">Cantidad:</label>
                  <input type="text" id="cantidad" name="cantidad" class="input-small numero" maxlength="4" style="margin-left:23px"/>
                  </div>
            </div>
        </div>
        <div class="row">
            <div class="span4" style="margin-left:50px; margin-top:10px;">
            <div id="controlfecha" class="control-group">
                <label for="fecha" style="display:inline;">Fecha:</label>
                  <input type="text" id="fecha" name="fecha" class="input-small"; style="margin-left:40px" />
            </div>
            </div>
        </div>
        <div class="row">
            <div class="span4" style="margin-left:50px; margin-top:10px;">
            <div id="controlhora" class="control-group">
                <label for="hora" style="display:inline;">Hora:</label>
                  <input type="text" id="hora" name="hora" class="input-small", style="margin-left:49px" />
                  </div>
            </div>
        </div>
        <div class="row">
             <div class="span2" style="margin-left:50px; margin-top:10px;">
               <input id="btnCargar" type="button" class="btn btn-success" value="Cargar" style="width:100px;" />
            </div>
            <div class="span2" style="margin-top:10px; margin-left:10px;">
               <input id="btnCancelar" type="button" class="btn btn-danger" value="Cancelar" style="width:100px;" />
            </div>
        </div>
        </form>
        
      </div>
    </div>
  </div>

<!--Pie de p�gina-->
<script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/bootstrap.js"></script>
<script src="../js/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
<script src="../js/jquery.maskedinput-1.3.js" type="text/javascript"></script>
<script src="../js/jQuery-validate.js" type="text/javascript"></script>
<script src="../js/Hospitales/Farmacia/CargaInventarioInsumo.js" type="text/javascript"></script>
<script src="../js/General.js" type="text/javascript"></script>
<script src="../js/ui-datepicker-es.js" type="text/javascript"></script>
<!--Barra sup--> 
<script type="text/javascript">
    parent.document.getElementById("DondeEstoy").innerHTML = "Farmacia > <strong>Carga de Inventario de Insumos</strong>";
</script> 
</body>
</html>

