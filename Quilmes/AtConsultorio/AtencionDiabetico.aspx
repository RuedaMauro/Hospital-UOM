<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtencionDiabetico.aspx.cs" Inherits="AtConsultorio_AtencionDiabetico" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<META http-equiv="Content-Type" CONTENT="text/html; charset=iso-8859-1">
<title>Pacientes</title>
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/barra.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../js/webcam.js" type="text/javascript"></script>
    <script type="text/javascript"> 

//    parent.document.getElementById("DondeEstoy").innerHTML = "Consultorio > <strong>Diabetología</strong>";

    </script>

    
</head>

<style>
html {overflow: auto;}
</style>

<script language="JavaScript">
    webcam.set_api_url('Foto.aspx');
    webcam.set_quality(100);
    webcam.set_shutter_sound(false); 
 </script>

<body>

<div class="container">
  <div class="contenedor_1" style="width:811px; margin-left:70px; height:568px">
    <div class="contenedor_a" style="position:relative;margin-left:15px; width:780px; height:520px; margin-top:4px">
    
    <div id="Espereaqueguarde" style="text-align:center; position:absolute; width:100%; height:100%; background-color:White; z-index:5; opacity:0.9; display:none;">
    <div style="margin-top:200px; margin-bottom:10px;">
        <img src="../img/Espere.gif" />
    </div>
    <p id="Mensajedeespera">Guardando</p>
    </div>

      <div id="infoBaja" class="noti_aviso" style="display:none;"> DADO DE BAJA </div>
      <div class="datos_principales_contenedor">
        <div id="datos_webcam" class="datos_principales">

             <div class="datos_principales_form" style="margin-left:0px">


               <div class="datos_persona">
        <div ><img id="fotopaciente" class=" avatar2" ></img> </div>
        <div class="datos_resumen_paciente">
        <div>Paciente: <strong><span id="CargadoApellido"></span> (<span id="CargadoEdad"></span>)</strong></div>
        <span>DNI: <strong><span id="CargadoDNI"></span></strong></span>&nbsp;&nbsp;&nbsp; <span>NHC: <strong><span id="CargadoNHC"></span></strong></span>
        <div>Seccional/OS:&nbsp;&nbsp;&nbsp;<span><strong><span id="CargadoSeccional"></span></strong></span></div>
        <div>Nº Cuil:&nbsp;&nbsp;&nbsp;<span><strong><span id="CargadoCuil"></span></strong></span></div>
        
        </div>        
      </div>
        <div class="pull-left" style="margin-left:0px; margin-top:40px"> 
      <%--  <div>Localidad:&nbsp;&nbsp;&nbsp;<span><strong><span id="CargadoLocalidad"></span></strong></span></div>--%>
        
        <div>Teléfono:&nbsp;&nbsp;&nbsp;<span><strong><span id="CargadoTelefono"></span></strong></span></div>
        <div>Nº Carnet:&nbsp;&nbsp;&nbsp;<span><strong><span id="CargadoCarnet"></span></strong></span></div>
        </div>
        <div class="clearfix"></div>
            
          </div>
          <div class="webcam_box_contenedor" style="margin-top:81px">

    <div id="webcam2contenedor" style="width:300px;">
<br/>
<div class="webcam2box">
<script language="JavaScript">
    document.write(webcam.get_html(300, 300));
</script>
<div class="webcam2menu">
<a class="mano" id="SacarFoto">Tomar</a>
<a class="mano" id="btn_minimizarwebcam">Aceptar</a>
</div>
</div>

</div>        
            </div>
        </div>
      </div>
      <div>
        <ul class="nav nav-tabs" data-tabs="tabs" style="margin-bottom:0px" >
        
          <li id="1" class="active"><a data-toggle="tab" href="#tab1" onclick="llamar1()">Diagnostico y Clínica</a></li>          
          <li id="2"><a data-toggle="tab" href="#tab2" onclick="llamar2()">Complicaciones</a></li>
          <li id="3"><a data-toggle="tab" href="#tab3" onclick="llamar3()">Estudios</a></li>
          <li id="Li1"><a data-toggle="tab" href="#tab4" onclick="llamar4()">Tratamiento</a></li>
       <%--   <li id="4"><a data-toggle="tab" href="#tab4" onclick="llamar4()">Tratamiento</a></li>--%>
         <%-- <li id="5"><a data-toggle="tab" href="#tab5" onclick="llamar5()">LABORATORIO Y EXÁMENES COMPLEMENTARIOS</a></li>--%>
          

        </ul>
      </div>
      
              <script type="text/javascript">
                  var valor =1;

                  function llamar1() {
                      valor = 1;

                      }
                      function llamar2() {
                          valor = 2;
                      }
                      function llamar3() {
                          valor = 3;
                      }
                      function llamar4() {
                          valor = 4;
                      }
                      function llamar5() {
                          valor = 5;
                      }
                      function llamar6() {
                          valor = 6;
                      }

                      function limpiar() {

                          switch (valor)
                          {
                              case 1:
                                  $(".limpiarChecks1").removeAttr('checked');
                                  $("#CheckTipo1").attr('checked', true);
                                  $(".limpiarText1").val("");
                                  $(".limpiarCbo1").val(0);
                                  //                                  $("#TxtAntiguedad").attr('disabled', true);
                                  break;

                              case 2:
                                  $(".limpiarText2").val("");
                                  break;
                              case 3:
                                  $(".limpiarCbo3").val(0);
                                  $(".limpiarChecks3").removeAttr('checked');
                                  $(".limpiarChecks3").attr('disabled', true);
                                  $(".limpiarText3").val("");
                                  $(".limpiarText3").attr('disabled', true);
                                  break;

                              case 4:
                                  $(".limpiarText4").val("");

                                  break;


                              case 5:
                                  $(".limpiarText5").val("");

                                  $("#").attr('disabled', true);
                                  $("#").attr('disabled', true);
                                  $("#").attr('disabled', true);
                                  $("#").attr('disabled', true);
                                  $("#").attr('disabled', true);
                                  $("#").attr('disabled', true);

                                  break;

                              case 6:
                                  $(".limpiarCbo6").val(0);
                                  break;
                          }
                      }
        </script>



      <!--DIAGNOSTICO Y CLÍNICA-->

          <div id="my-tab-content" class="tab-content" style="height:357px" scroll="no">
        <div class="tab-pane active fade in DP" id="tab1">
          <div class="pull-left">
            <form class="form-horizontal" >
           

            </form>
          </div>
          <div class="clearfix"></div>

<form class="form-horizontal DP pull-left" style="margin-top:-14px; width:700px; height:30px">
<div id="TipoDiabetes" class="control-group" style=" width:765px; height:20px">

<form class="form-horizontal">
<div class="contenedor_1" style="vertical-align:middle; margin-left:14px; margin-top:5px">
<label style="display:inline; margin-left:110px">Fecha:
<input id="fechaDiagnostico" type="text" class="fechas" style="text-align:center; width:100px"/></label>
<label style="display:inline; margin-left:170px">Edad al Diagnóstico:
<input id="EdadDiagnostico" type="text" class=" numero input-mini" style="text-align:center" maxlength="2"/></label>
</div>
<div class="contenedor_1" style=" margin-left:14px; margin-top:20px">
<table id="DatosDiagnosticoYclinica" style=" margin:auto"></table>
</div>

</form>
</form>     
              </div>
        
         </div>
   
        <!--COMPLICACIONES-->
        <div class="tab-pane fade in" id="tab2">

            <script type="text/javascript">
            function calcularIMC()
            {
                if ($("#txtAltura").val() != "" && $("#txtPeso").val() != "") {
                    var altura = 0;
                    var peso = 0;
                    var IMC = 0;
                    var aux = 0;

                    altura = $("#txtAltura").val();
                    peso = $("#txtPeso").val();

                    aux = Math.pow(altura, 2);

                    IMC = peso / aux;
                    IMC = Math.round(IMC);
                    $("#txtIMC").val(IMC);

                }
                if ($("#txtAltura").val() == "" || $("#txtPeso").val() == "") {
                    $("#txtIMC").val("");
                }
            }
            </script>
            <form class="form-horizontal DP pull-left" style="margin-top:-14px; width:700px; height:30px">
<div id="Div1" class="control-group" style=" width:765px; height:20px">

<form class="form-horizontal">
<div class="contenedor_1" style=" margin-top:20px">
<table id="Complicaciones" style=" margin:auto"></table>
</div>

</form>
</form> 

          </div>      
   </div>
     
        <!--ESTUDIOS-->

        <div class="tab-pane fade in" id="tab3">
 <form class="form-horizontal">
<div class="contenedor_1" style=" margin-top:5px">
<table id="Estudios" style=" margin:auto"></table>
</div>
</form>
        </div>
        
        <!--TRATAMIENTO-->

        <div class="tab-pane fade in" id="tab4">
 <form class="form-horizontal">
 <div class="contenedor_1" style="vertical-align:middle; margin-left:0px; margin-top:5px">


<label style="display:inline; margin-left:70px">Insulina Basal
<select id="cboInsulinaBasal"></select></label>

<label style="display:inline">Marca Comercial
<input id="txtBasalComercial" type="text" disabled/></label>



<label style="display:inline; margin-left:16px">Insulina de Corrección
<select id="cboInsulinaCorreccion"></select></label>

<label style="display:inline">Marca Comercial
<input id="txtCorreccionComercial" type="text" disabled/></label>

</div>

<div class="contenedor_1" style=" margin-top:0px">
<table id="Tratamiento" style=" margin:auto"></table>
</div>
</form>
        </div>

      <div class="pie_gris">

        <a id="btnGuardar" class="btn btn-info pull-right"><i id="I1" class=" icon-hdd icon-white"></i>&nbsp;Guardar</a>
        <a id="btnImprimir" class="btn btn-info pull-right" disabled="true"><i id="imprimir" class=" icon-print"></i>&nbsp;Imprimir</a>
<%--         <a onclick="javascript:window.close();" class="btn pull-right">Cancelar</a>--%>
        <%-- <a id="btnLimpiar" onclick="limpiar()" class="btn pull-right">Limpiar Campos</a>--%>
         <a class="btn btn-info" id="BtnVolver" href="javascript:history.go(-1)">
         <i id="i" class=" icon-arrow-left icon-white"></i>&nbsp;Volver</a>
         <a class="btn btn-info" id="btnCance" href="Buscar_Paciente.aspx">
         <i id="btnCancelar" class=" icon-off icon-white"></i>&nbsp;Cancelar</a>
        <div class="clearfix"></div>
      </div>
  
</div>

    <script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
        <script src="../js/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script src="../js/GeneralG.js" type="text/javascript"></script>    
    <script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
    <script src="../js/ui-datepicker-es.js" type="text/javascript"></script>
    <script src="../js/Hospitales/AtConsultorio/AtencionDiabeticos.js" type="text/javascript"></script>    


<!--Barra sup--> 


</body>
</html>



<%--    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h3 id="myModalLabel">Paciente NO encontrado</h3>
  </div>
  <div class="modal-body">
    <p>El paciente no se encuentra en el sistema.</p>
    <p>Verifique...</p>
    <ul>
    <li>Que haya ingreso de forma correcta los datos de busqueda, como el DNI, CUIL o APELLIDO Y NOMBRE.</li>
    <li>Que de haber dado de alta el afiliado y le está mostrando este mensaje, por favor comuniquese con SITEMAS</li>    
    <li>De haber verificado el punto anterior, ¿Desea darlo de alta?</li>    
    </ul>
    <p></p>
    <p></p>
    <p></p>

  </div>
  <div class="modal-footer">
    <button onclick="javascript:window.close();" class="btn" data-dismiss="modal" aria-hidden="true">No</button>
    <button class="btn" data-dismiss="modal" aria-hidden="true">Si</button>    
  </div>
   </div>--%>



 <div id="myModalTitular" class="modal hide fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">    
    <h3 id="H1">TITULAR NO encontrado</h3>
  </div>
  <div class="modal-body">
    <p>El Titular del paciente no se encuentra en el sistema Local.</p>
    <p>Verifique...</p>
    <ul>
    <li>Que haya ingreso de forma correcta el CUIL del Titular.</li>
    <li>Verifique en el PADRON UOM si está el Titular, de ser asi, actualicelo.</li>
    <li>Que de haber dado de alta al Titular y se está mostrando este mensaje, por favor comuniquese con SISTEMAS</li>    
    <li>De haber verificado los puntos anteriores. Es necesario dar de alta al titular. ¿Desea hacerlo ahora?</li>    
    </ul>
    <p></p>
    <p></p>
    <p></p>

  </div>
  <div class="modal-footer">
    <button onclick="javascript:window.close();" class="btn" data-dismiss="modal" aria-hidden="true">No</button>
    <button onclick="javascript:self.location='NuevoAfiliado.aspx';" class="btn" data-dismiss="modal" aria-hidden="true">Si</button>    
    <button onclick="javascript:IgnorarTitular();" class="btn" data-dismiss="modal" aria-hidden="true">Ignorar</button>    
  </div>
   </div>


<%--    <div id="ModalExistePaciente" class="modal hide fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">    
    <h3 id="H2">El Paciente ya existe</h3>
  </div>
  <div class="modal-body">
    <p>El paciente que está cargando ya existe en el sistema.</p>
    <p>Tenga en cuenta que...</p>
    <ul>
    <li>Si continua modificando los datos del paciente actual, al Actualizar los datos, todos los datos del paciente anterior, junto con su familiar, pueden llegar a perderse.</li>
    <li>Verifique el Nro de Documento o CUIL antes de continuar.</li>
    <li>Documento: <script>                       document.write($("#txtdocumento").val());</script> Cuil: <script>                                                                                                               document.write($("#txtcuil").val());</script></li>
    <li>¿Desea Seguir Cargando el paciente?.</li>
    </ul>
    <p></p>
    <p></p>
    <p></p>

  </div>
  <div class="modal-footer">
    <button onclick="#" class="btn" data-dismiss="modal" aria-hidden="true">Si</button>    
    <button onclick="javascript:window.close();" class="btn" data-dismiss="modal" aria-hidden="true">No</button>
    <button onclick="javascript:if($('#txtdocumento').val().length>=7){self.location='NuevoAfiliado.aspx?Documento='+$('#txtdocumento').val()+'';}else{if($('#txtcuil').val().length>=7){self.location='NuevoAfiliado.aspx?NHCDocumento='+$('#txtcuil').val()+'';}}" class="btn" data-dismiss="modal" aria-hidden="true">Ver Paciente</button>    
  </div>
   </div>--%>