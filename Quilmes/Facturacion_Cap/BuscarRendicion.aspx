<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuscarRendicion.aspx.cs" Inherits="Facturacion_BuscarRendicion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<META http-equiv="Content-Type" CONTENT="text/html; charset=iso-8859-1">
<title>Gestión Hospitalaria</title>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/barra.css" />
</head>

<body>
<div class="clearfix"></div>


<div id="lightbox" style="display:none;position:absolute;z-index:899;width:100%; height:100%;background-color:RGBA(255,255,255,0.8);"> </div>

<div class="container" style="padding-top:30px;">
  <div class="contenedor_1">
   <div class="contenedor_3" style="height:530px;">
      <form id="frm_Main" name="frm_Main">
  
 <div class="contenedor_4 pagination-centered" style="height:150px; margin-top:5px; margin-left:10px;">
         <div class="row" style="margin-left:5px;">
               <div id="controltxtRendicion" class="span5 form">
                    <label for="txtRendicion" style="display:inline; margin-top:10px;">Rendición: </label>
                    <input type="text" id="txtRendicion" name="txtRendicion" class="input-small form numero" style="margin-top:10px;" />
              </div>
        </div> 
          
          <div class="row" style="margin-left:5px;">
              <div id="controlcbo_Seccional" class="span5">
                    <label for="cbo_Seccional" style="display:inline; margin-top:10px;">Seccional: </label>
                    <select id="cbo_Seccional" name="cbo_Seccional" class="input-xlarge" style="margin-top:10px; margin-left:3px;">
                    <option value="0"></option>
                    </select>
              </div>
        </div>
                 <div class="row" style="margin-left:5px;">
                    <div class="span2">
                        <div id="controlrdAmbulatorio" class="control-group">
                             <input id="rdAmbulatorio" name="grupo1" type="radio" class="input-xlarge" checked="checked" style="vertical-align:middle; display:inline; margin-right:5px;" /><label for="rdAmbulatorio" style="display:inline; margin-left:5px; margin-right:5px;">Ambulatorio</label>
                        </div>
                    </div>
                        <div class="span2">
                            <div id="controlrdInternacion" class="control-group">
                                    <input id="rdInternacion" name="grupo1" type="radio" class="input-xlarge" style="vertical-align:middle;" /><label for="rdInternacion" style="display:inline; margin-left:5px; margin-right:5px;">Internación</label>
                                </div>
                        </div>
                    </div>
  </div>
          <div class="contenedor_4 pagination-centered" style="height:150px; margin-top:5px; margin-left:10px;">
              <div class="row" style="margin-left:5px; margin-top:10px;">
              
               <div id="controltxtAnioDesde" class="span2">
                    <label for="txtAnioDesde" style="display:inline; margin-top:10px;">Desde Año</label>
                    <input type="text" name="txtAnioDesde" id="txtAnioDesde" class="input-mini numero" maxlength="4" style="width:50px;" />
              </div>
                 <div id="controltxtMesDesde" class="span2" style="width:200px;">
                    <label for="txtMesDesde" style="display:inline; margin-top:10px;">Mes</label>
                    <select name="txtMesDesde" id="txtMesDesde" class="input-small" style="width:120px;">
                        <option value="01">Enero</option>
                        <option value="02">Febrero</option>
                        <option value="03">Marzo</option>
                        <option value="04">Abril</option>
                        <option value="05">Mayo</option>
                        <option value="06">Junio</option>
                        <option value="07">Julio</option>
                        <option value="08">Agosto</option>
                        <option value="09">Septiembre</option>
                        <option value="10">Octubre</option>
                        <option value="11">Noviembre</option>
                        <option value="12">Diciembre</option>
                    </select>
              </div>
            </div>

            <div class="row" style="margin-left:5px; margin-top:10px;">
            
               <div id="controltxtAnioHasta" class="span2">
                    <label for="txtAnioHasta" style="display:inline; margin-top:10px; margin-left:5px;">Hasta Año</label>
                    <input type="text" name="txtAnioHasta" id="txtAnioHasta" class="input-mini numero" maxlength="4" style="width:50px;" />
              </div>
                 <div id="controltxtMesHasta" class="span2" style="width:200px;">
                    <label for="txtMesHasta" style="display:inline; margin-top:10px;">Mes</label>
                    <select name="txtMesHasta" id="txtMesHasta" class="input-small" style="width:120px;">
                        <option value="01">Enero</option>
                        <option value="02">Febrero</option>
                        <option value="03">Marzo</option>
                        <option value="04">Abril</option>
                        <option value="05">Mayo</option>
                        <option value="06">Junio</option>
                        <option value="07">Julio</option>
                        <option value="08">Agosto</option>
                        <option value="09">Septiembre</option>
                        <option value="10">Octubre</option>
                        <option value="11">Noviembre</option>
                        <option value="12">Diciembre</option>
                    </select>
              </div>
            </div>
 </div>

</form>
          <div class="clearfix"></div>
        <!--Tabla de estudios-->
        <div style="padding:15px 15px 0px 15px;">
            
            <div class="clearfix"></div>
            <div id="cargando" style="text-align:center; display:none;">
                <br /><br />
                <img src="../img/Espere.gif" /><br />
                Cargando...
            </div> 
            <div id="TablaPartes_div" class="tabla" style="height:330px;width:100%; margin-top:-10px;">
              <table class="table table-hover table-condensed">
                <thead>					
                  <tr>
                    <th></th>
                    <th>Nro Rendición</th>
                    <th>F.Facturación</th>
                    <th>Año</th>
                    <th>Mes</th>
                    <th>Seccional</th>
                  </tr>
                  <tbody id="trx"></tbody>
                </thead>

              </table>
            </div>
        </div>
        <div class="clearfix"></div>

<div class="pie_gris">
<div class="span2 pull-right">
<button id = "btnBuscar" class="btn btn-info pull-right"><i class=" icon-search icon-white"></i>&nbsp;Buscar</button>
</div>
</div>
      </div>
    </div>
  </div>
<!--Pie de p�gina-->
<script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
<script src="../js/bootstrap.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script src="../js/GeneralG.js" type="text/javascript"></script>
<script src="../js/ui-datepicker-es.js" type="text/javascript"></script>
<script src="../js/jquery.maskedinput-1.3.js" type="text/javascript"></script>
<script src="../js/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
<link href="../css/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
<script src="../js/Hospitales/Facturacion_Cap/BuscarRendicion.js" type="text/javascript"></script>
<!--Barra sup--> 
<script type="text/javascript">
    parent.document.getElementById("DondeEstoy").innerHTML = "Facturación > <strong>Buscar Rendiciones</strong>";
</script> 
</body>
</html>



