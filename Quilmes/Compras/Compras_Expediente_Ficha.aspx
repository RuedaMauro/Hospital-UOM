<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Compras_Expediente_Ficha.aspx.cs" Inherits="Compras_Compras_Expediente_Ficha" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<META http-equiv="Content-Type" CONTENT="text/html; charset=iso-8859-1">
<title>Pacientes</title>
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/barra.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
</head>

<style>
html {overflow: hidden;}
</style>

<body>


<div class="container">
  <div class="contenedor_1">
    <div class="contenedor_a" style="position:relative;margin-left:15px; width:880px; height:520px;">
    
      <div class="datos_principales_contenedor" style="height:180px;">
        <div id="datos_webcam" class="datos_principales" style="height:140px;">
          <div class="foto_afiliado">
            <img id="FotoFinal" src="../img/silueta.jpg"> </div>
          <div class="datos_principales_form">
            <div class="pull-left">
              <form class="form-horizontal" style="margin-left:-60px;">
                <div class="control-group">
                <label class="control-label"><strong>Tipo</strong></label>
                  <div class="controls">
                    <select id="cbo_tipo_doc" class="span1" style="width:80px;">
                    </select>
                    <input id="afiliadoID" value="0" type="hidden" />
                  <strong>&nbsp;Nro.</strong>&nbsp;&nbsp;<input id="txtdocumento" maxlength="8" class="span1 numero" style="width:70px;" type="text" placeholder="sin puntos" />
                  </div>
                </div>
              <div id="ControlNHC_Old" class="control-group">
                <label class="control-label"><strong>Nro. HC</strong></label>
                <div class="controls">
                  <input id="txt_NHC_UOM" maxlength="11" class="span2 numero" style="width:195px;" type="text"></div>
              </div>
               <div id="Div1" class="control-group">
                    <label class="control-label"><strong>Nro. Expediente</strong></label> 
                    <span id="CargadoNroExpediente" class="span2" style="font-weight:bold; margin-top:5px;"></span>
                </div>               
    </form>
            </div>
            <div class="pull-left">
              <form class="form-horizontal" >
                 <div id="ControlApellidoyNombre" class="control-group">
                  <label class="control-label"><strong>Apellido y nombre</strong></label>
                  <div class="controls">
                    <input id="txtapellido" maxlength="60" class="span2 datos" style="width:200px;" type="text" tabindex="1">
                    <input id="txtPaciente" maxlength="60" class="span3 datos" type="hidden">
                    <a id="btnBuscarPaciente" href="../Turnos/BuscarPacientes.aspx?Express=0" class="btn"><i class="icon-search icon-black">
                        </i></a>
                  </div>
                </div>
                     <div id="controlcboSeccional" class="control-group">
                    <label class="control-label"><strong>Seccional</strong></label>
                    <div class="controls">
                        <input id="txtSeccionalId" type="hidden">
                        <select id="cboSeccional" class="span2 datos" style="width:255px;"></select>
                    </div>
                </div>
                              <div id="controltxt_NroExpendiente" class="control-group">
               <label class="control-label"><strong>Buscar Expediente</strong></label> 
                  <input id="txt_NroExpendiente" type="text" class="span2" maxlength="8" style="margin-left:10px;"/>
            </div>
              </form>
            </div>
            <div class="clearfix"></div>
            
            <form class="form-horizontal">

              </form>
            
          </div>
        </div>
      </div>
      <div>
        <ul class="nav nav-tabs tabslist" style="background-color:#D8D8D8;" data-tabs="tabs">
          <li class="active datos"><a data-toggle="tab" href="#tab1"> Datos principales</a></li>          
          <li class="datos"><a data-toggle="tab" href="#tab2">Domicilio y contacto</a></li>
          <li class="datos"><a data-toggle="tab" href="#tab4">Datos Extra</a></li>
          <li class="datos" id="tabDocu"><a data-toggle="tab" href="#tab3">Escaneo</a></li>
          <li class="datos" id="tabVerDocu"><a data-toggle="tab" href="#tab5">Ver Documentacion</a></li>
        </ul>
      </div>
      
      <!--DATOS PRINCIPALES-->
      <div id="my-tab-content" class="tab-content datos tabslist">
        <div class="tab-pane active fade in DP" id="tab1">
          <div class="pull-left">
            <form class="form-horizontal" style="margin-bottom: 0px;">
             <div id="controlcboCodPariente" class="control-group">
               <label class="control-label">Parentesco</label>
                <div class="controls">
                    <select id="cboCodPariente" class="span2" style="height:30px; width:190px;">
                    </select>
                </div>
              </div>

              <div id="controltxtNHC" class="control-group" style="display:none;">
                <label class="control-label">Nro. HC</label>
                <div class="controls">
                  <input id="txtNHC" maxlength="11" class="span2" type="text" disabled /></div>
              </div>

              <div id="controltxtFechaBaja" class="control-group">
                <label class="control-label">Fecha Vto. Expte.</label>
                <div class="controls">
                  <input id="txtFechaVencExp" maxlength="10" class="span2" type="text" style="height: 15px;"></div>
              </div>

              <div id="controldiv_diagnostico" class="control-group">
                  <label class="control-label">Diagn�stico</label>
                  <div class="controls">
                        <textarea id="txt_cbo_Diagnostico" class="span4" style="width:250px;" rows="2" readonly></textarea>
                        <div id="div_diagnostico" style="display:none;width: 300px; height:150px; background-color:#969696;margin-top: 0px;position:absolute;">
                            <div id="span_diagnosticos_cargados" style="max-height:150px; overflow:auto;">
                            </div>
                        </div>
                  </div>
              </div>

              <div id="controltxtEmpresa" class="control-group">
                <label class="control-label">Empresa</label>
                    <div class="controls">
                        <input id="txtEmpresa" maxlength="50" class="span4" type="text" style="width:250px;height: 15px;"/>
                    </div>
              </div>
              <div id="controltxtCalle" class="control-group">
                <label class="control-label">Direcci�n Empresa</label>
                    <div class="controls">
                        <input id="txtCalleEmpresa" maxlength="50" class="span4" type="text" style="width:250px;height: 15px;"/>
                    </div>
              </div>

            </form>
          </div>
          <div class="pull-left">
            <form class="form-horizontal">
              <div id="ControlFechaNacimiento" class="control-group">
                <label class="control-label">Fecha Nacimiento</label>
                <div class="controls">
                  <input id="txtFechaNacimiento" maxlength="10" class="span2" type="text" placeholder="dia/mes/a�o" style="height: 15px;">
                  <div class="label_derecho"><i class="icon-arrow-left"></i>&nbsp;&nbsp;&nbsp;<span id="Edad"></span></div>
                </div>
              </div>

              <div id="ControlPatolog�a" class="control-group">
                  <label class="control-label">Patolog�a</label>
                  <div class="controls">
                      <textarea id="txt_cbo_Patologia" class="span4" style="width:290px;" rows="2" readonly></textarea>
                        <div id="div_patologia" style="display:none;width: 300px; height:150px; background-color:#969696;margin-top: 0px;position:absolute;">
                            <div id="span_patologias_cargados" style="max-height:150px; overflow:auto;">
                            </div>
                        </div>
                  </div>
              </div>

              <div id="ControlCUIT" class="control-group">
                    <label class="control-label">CUIT Empresa</label>
                    <div class="controls">
                        <input id="txtcuit" maxlength="11" class="span2" type="text" style="height: 15px;"/>
                    </div>
              </div>
              
              <div id="cont_checks" style="background-color:#D8D8D8;width: 430px;margin-left: 25px;">&nbsp;&nbsp;&nbsp;<b style="text-align:center; margin-left: 100px;">Documentaci�n Entregada</b>
              <div id="checks1" class="control-group" style="margin-left:50px;">
                       <span style="width:100px;">Discapacidad</span> <input type="checkbox" class="check" id="chkDocu_Discapacidad" style="margin-top:0px; margin-right:120px;"/> 
                       <span style="width:100px;">Rec. Sueldo</span> <input type="checkbox" class="check" id="chkDocu_ReciboSueldo" style="margin-top:0px;"/> 
                       
                </div>
                <div id="checks2" class="control-group" style="margin-left:50px;">
                     <span style="width:100px; margin-right:63px;">DNI</span> <input type="checkbox" class="check" id="chkDocu_DNI" style="margin-top:0px; margin-right:105px;"/> 
                     <span style="width:100px;">Nac. o Casam.</span> <input type="checkbox" class="check" id="chkDocu_NacCasam" style="margin-top:0px;"/> 
                </div>
              </div>
            </form>
          </div>
              <div class="span8" style="margin-top:-10px;">
                  <label for="cbo_EstadoExpediente" class="control-label" style="display:inline; margin-right:80px;">Estado</label>
                  <select id="cbo_EstadoExpediente" class="span4" style="height: 30px;width: 265px;">
                  </select>
              </div>
              <div class="span10">
                  <label for="txtObservaciones" class="control-label" style="display:inline; margin-right:30px;">Observaciones</label>
                  <textarea id="txtObservaciones" class="span7" rows="1" style="display:inline; width:80%; height: 15px;"></textarea>
              </div>
          <div class="clearfix"></div>

<form class="form-horizontal DP pull-left" style="margin-top:-14px;">


</form>          
          
        </div>
        
        <!--CONTACTO Y DOMICILIO-->
        <div class="tab-pane fade in" id="tab2">
          <div class="label_top_grupo">
            <div class="label_top">
              <div>Calle</div>
              <input id="txtcalle" maxlength="60" type="text" class="span3">
            </div>
            <div class="label_top">
              <div>N�mero</div>
              <input id="txtnumero" type="text" maxlength="10" class="span1">
            </div>
            <div class="label_top">
              <div>Piso</div>
              <input id="txtpiso" type="text" maxlength="6" class="span1">
            </div>
            <div class="label_top">
              <div>Depto.</div>
              <input id="txtdpto" type="text" maxlength="6" class="span1">
            </div>
            <div class="label_top">
              <div>Cod Postal.</div>
              <input id="txtcodpos" maxlength="10" type="text" class="span1">
            </div>
            
            <div class="clearfix"></div>
          </div>
          
          <div class="label_top_grupo">
          <div class="label_top">
              <div>Localidad</div>
              <input id="txtlocalidad" maxlength="60" type="text" class="span3">
            </div>
            <div class="label_top">
              <div>Provincia</div>
              <select id="cboProvincia" type="text" class="span2" style="width:200px;">
              </select>
            </div>


            <div class="clearfix"></div>
          </div>

          <div class="label_top_grupo">
                      <div class="label_top">
              <div>Celular</div>
              <input id="txtcelular" maxlength="60" type="text" class="span3">
            </div>
            <div class="label_top" id="ControlTelefono">
              <div>Tel�fono</div>
              <input id="txttelefono" maxlength="13" placeholder="Ej. 43625910" class="span2" type="text" style="width:188px;">
            </div>
          <div class="clearfix"></div>
          </div>
          
        </div>

        <!--Datos Extra-->
        <div class="tab-pane fade in" id="tab4">

          <div class="control-group" style="margin-bottom:0px;" id="controlPMI">
              <label for="txtPMIDesde" class="span2" style="margin-top:10px;">Plan Materno Infantil</label>
              <span for="txtPMIDesde">Desde</span>
              <input id="txtPMIDesde" maxlength="10" type="text" class="input-small date" style="width:80px;"/>
              <span for="txtPMIHasta">Hasta</span>
              <input id="txtPMIHasta" maxlength="10" type="text" class="input-small date hasta" style="width:80px;"/>

              <span style=" margin-right:33px;">Plan Materno</span>
              <span for="txtPMDesde">Desde</span>
              <input id="txtPMDesde" maxlength="10" type="text" class="input-small date" style="width:80px;"/>
              <span for="txtPMHasta">Hasta</span>
              <input id="txtPMHasta" maxlength="10" type="text" class="input-small date hasta" style="width:80px;"/>
          </div>
          <div class="control-group" style="margin-bottom:0px;" id="controlCodem">
              <label for="txtCodemDesde" class="span2" style="margin-top:10px;">CODEM</label>
              <span for="txtCodemDesde">Desde</span>
              <input id="txtCodemDesde" maxlength="10" type="text" class="input-small date" style="width:80px;"/>
              <span for="txtCodemHasta">Hasta</span>
              <input id="txtCodemHasta" maxlength="10" type="text" class="input-small date hasta" style="width:80px;"/>

              <span style=" margin-right:2px;">Cert Discapacidad</span>
              <span for="txtCertificadoDiscDesde">Desde</span>
              <input id="txtCertificadoDiscDesde" maxlength="10" type="text" class="input-small date" style="width:80px;"/>
              <span for="txtCertificadoDiscHasta">Hasta</span>
              <input id="txtCertificadoDiscHasta" maxlength="10" type="text" class="input-small date hasta" style="width:80px;"/>

          </div>

           <div class="control-group" style="margin-bottom:0px;" id="controlSSS">
              <label for="txtSSSDesde" class="span2" style="margin-top:10px;">S.S.S.</label>
              <span for="txtSSSDesde">Desde</span>
              <input id="txtSSSDesde" maxlength="10" type="text" class="input-small date" style="width:80px;"/>
              <span for="txtSSSHasta">Hasta</span>
              <input id="txtSSSHasta" maxlength="10" type="text" class="input-small date hasta" style="width:80px;"/>
              <div style="background-color: #D8D8D8;width: 220px;margin-left: 95px;margin-top: 0px; position:absolute; display:inline;">
                <span for="txtVencimientoPatologia" style="margin-left: 5px;">Vto. de Patologia</span>
                <input id="txtVencimientoPatologia" maxlength="10" type="text" class="input-small date hasta" style="width:80px;margin-top: 5px;">
              </div>
          </div>
          <br />
           <div class="control-group" style="margin-bottom:0px;" id="controlTutor">
                <label for="txtTutor" class="span4" style="margin-top:5px;">Nombre del Tutor (Familiar a cargo)</label>
                <input id="txtTutor" maxlength="50" type="text" class="input-xxlarge" style="width:510px;"/>
           </div>

           <div class="control-group" style="margin-bottom:0px;" id="controlEstadolegal">
                <label for="cbo_EstadoLegal" class="span4" style="margin-top:5px;">Estado Legal</label>
                <select id="cbo_EstadoLegal" class="span4">              
                </select>
           </div>

        </div>

        <!--Documentacion-->
        <div class="tab-pane fade in" id="tab3">
             <form id="Form1" runat="server" action="" style="margin-left:20px;">
              <input id="id_Expediente" type="hidden" runat="server"/> <!--Guardo el numero de requerimiento -->
              <div>
                <asp:FileUpload ID="File_NHC" runat="server" AllowMultiple="true" />
                <asp:Button ID="btnSubirFile_NHC" runat="server" Text="Subir" 
                    onclick="btnSubir_Click" UseSubmitBehavior="false"/>
                <br />
                <p id="lbl_File_NHC" runat="server" style="font-weight:bold; color: Green;"></p>
                <br />
            </div>
            </form>
        </div>
        <div class="tab-pane fade in DP" id="tab5"> <!--Div Tab Ver Adjuntos-->
            <div id="fotos" style="height:300px; max-height:300px; overflow:auto;">
            </div>
          </div> <!--FIN Div Ver Adjuntos-->
      </div>
      <div class="pie_gris">
        <a id="btnPedidos" class="btn pull-left" style="display:none;">Pedidos</a>
        <a id="btnEntregas" class="btn pull-left" style="display:none;">Entregas</a>

        <a id="btnGuardar" class="btn btn-info pull-right"><i class="icon-ok"></i>&nbsp;&nbsp;&nbsp;Guardar</a>
        <a id="btnBaja" class="btn btn-danger pull-right" style="display:none;"><i class="icon-remove"></i>&nbsp;&nbsp;&nbsp;Baja</a>
        <a id="btnBuscarExpedientes" class="btn pull-right"><i class="icon-search"></i>&nbsp;&nbsp;&nbsp;Buscar Expedientes</a>
        <a id="btnNuevoExp" class="btn pull-right"><i class="icon-file"></i>&nbsp;&nbsp;&nbsp;Nuevo Expediente</a>
        
        <div class="clearfix"></div>
      </div>
    </div>
  </div>  
</div>
    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
    <script src="../js/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script src="../js/Hospitales/Compras/Compras_Expediente_Ficha.js" type="text/javascript"></script>
    <script src="../js/GeneralG.js" type="text/javascript"></script>    
    <script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
    <script src="../js/ui-datepicker-es.js" type="text/javascript"></script>    
<script type="text/javascript">
    parent.document.getElementById("DondeEstoy").innerHTML = "Compras > Ambulatorio CABA > <strong>Expediente</strong>";
</script> 
</body>
</html>




