<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Listado_Cantidad_Pac_Por_Esp.aspx.cs" Inherits="Turnos_Listado_Cantidad_Pac_Por_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title></title>

<link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
<link rel="stylesheet" type="text/css" href="../css/barra.css" />
<link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/bootstrap.js"></script>
<script src="../js/General.js" type="text/javascript"></script>
<script src="../js/GeneralG.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script src="../js/ui-datepicker-es.js" type="text/javascript"></script>
<script src="../js/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
<link href="../css/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery.maskedinput-1.3.js" type="text/javascript"></script>
<link href="../css/deshabilitar.css" rel="stylesheet" type="text/css" />


</head>
<body>
    <form id="form1" runat="server">
    
    
    <div class="contenedor_1" style="width:770px; height:492px; margin-top:150px; margin-left:auto; margin-right:auto">
    <div id="contenedorFiltros" class="contenedor_2" style="margin-left:30px; height:400px;width:710px">
    <div class="titulo_seccion" style="text-align:center; margin-left:0px">
    <span style=" text-align:center" id="titulo">Cantidad de Pacientes Atendidos Por Especialidad</span>
    </div>
    <div class="control-group" style="margin-top:30px; display:none">
    <label style="display:inline; margin-left:16px">Tipo Listado</label>
    <select id="CbotipoListado" style=" margin-bottom:0px">
    </select>
    </div>
    <div>
       <label style="display:inline; margin:50px">Fecha</label><label style="margin-left:50px; display:inline">Desde
       <input id="txtFechaInicio" type="text" style="width:100px; text-align:center" /></label>

       <label style="margin-left:50px; display:inline">Hasta
       <input id="txtFechaFin"  type="text" style="width:100px; margin-left:2px ; text-align:center"/></label>
  </div>
   <div>
       <label style="display:inline; margin:50px">Especialidad</label>
       <select id="cbo_Especialidad" class="input-xlarge"></select>
  </div>
  <div>
        <label style="display:inline; margin:50px">Solo Quilmes</label><input type="radio" id="rdQuilmes" name="opc" checked/>
        <label style="display:inline; margin:50px">Todo Excepto Quilmes</label><input type="radio" id="rdNoQuilmes" name="opc" />
    
  </div>
  <br />
   <div class="control-group" style="margin-left:250px;">
                    <div class="controls">
                        <a id="btn_Imprimir" class="btn"><i class="icon-print"></i>&nbsp;Imprimir</a>
                    </div>
    </div>

    </div>
    </div>

    </form>
</body>
<script src="../js/Hospitales/Turnos/Listado_Cantidad_Pac_Por_Esp.js" type="text/javascript"></script>
</html>

