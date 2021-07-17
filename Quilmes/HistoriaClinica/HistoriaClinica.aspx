<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistoriaClinica.aspx.cs" Inherits="HistoriaClinica_HistoriaClinica" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<META http-equiv="Content-Type" CONTENT="text/html; charset=iso-8859-1">
<title>Gestión Hospitalaria</title>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.css"/>
<link rel="stylesheet" type="text/css" href="../css/barra.css"/>
<link href="../css/arbol.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div class="container">
  <div class="contenedor_1" style="overflow:hidden;position:relative"> 
    <!--Datos del paciente-->
    
      <div class="resumen_datos">
        
        <div class="datos_persona">
        <div><img id="fotopaciente" class="avatar2" src="../img/silueta.jpg" onerror="imgErrorPaciente(this);"></img> </div>
        <div class="datos_resumen_paciente">
          <div>Paciente: <strong><span id="CargadoApellido"></span> (<span id="CargadoEdad"></span>)</strong><a href="javascript:VerMas();" class="ver_mas_datos">Ver más</a></div>
          <span>DNI: <strong><span id="CargadoDNI"></span></strong></span>&nbsp;&nbsp;&nbsp; <span>NHC: <strong><span id="CargadoNHC"></span></strong></span>&nbsp;&nbsp;&nbsp; <span>Teléfono: <strong><span id="CargadoTelefono"></span></strong></span>
          <div><span id="CargadoSeccionalTitulo">Seccional:</span> <strong><span id="CargadoSeccional"></span></strong></div>
        </div>
         <input id="txtdocumento" type="hidden" />
         <input id="afiliadoId" value="" class="ingreso" type="hidden"/>
      </div>        
      </div>

<!--COLUMNA IZQUIERDA-->    
    

<!--CONTENIDO-->
<div>



<div class="ContenedorHistoriaClinica">
<a  id="mostrarantecedentes" class="btn btn-success pull-left">Mostrar Historia Clínica</a>
<a  id="btnOpciones" class="btn btn-info pull-left" style="margin-left:5px;">Opciones</a>
<input type="hidden" id="medicoId" />
<input type="hidden" id="Fecha_Hora" runat="server" />
<a id="btnVolver" class="btn pull-left" style="margin-left:5px;"><i class="icon-th-list"></i>&nbsp;Volver</a>
<div class="clearfix"></div>

<div class="MenuHistoriaClinica">
<a id="cerrarantecedentes"style="position:absolute;right:0;top:0" class="btn pull-right">x</a>

<div class="ArbolHistoriaClinica">

<div id="wrapper">
<div class="tree">
        <ul>
                <li><a>Antecedentes Internaciones</a>
                        <ul>
                                <li><a>Registro de Internaciones</a>
                                <ul id="ulInternaciones">
                                    <asp:Literal ID="InternacionAnios" runat="server"></asp:Literal>
								</ul>
                                </li>
                                <li><a>Cirugias</a>
                                <ul id="ulCirugias">
                                    <asp:Literal ID="CirugiasAnios" runat="server"></asp:Literal>
								</ul>
                                </li>
                                <li><a>Interconsultas</a>
                                <ul id="ulInterconsultas">
                                    <asp:Literal ID="InterconsultaAnios" runat="server"></asp:Literal>
								</ul>
                                </li>
                        </ul>
                </li>
                <li><a>Antecedentes Ambulatorios</a>
                        <ul>
                            <asp:Literal ID="UlAmbulatorio" runat="server"></asp:Literal>
                        </ul>
                </li>
                <li><a>Analisis y Estudios</a>
                        <ul>
                                <li><a>Laboratorio</a>
                                <ul id="UlLaboratorio">
                                    <asp:Literal ID="LaboratorioAnios" runat="server"></asp:Literal>
								</ul>
                                </li>
                                <li><a>Recetas de Medicamentos</a>
                                <ul>
                                    <asp:Literal ID="RecetasAnios" runat="server"></asp:Literal>
								</ul>
                                </li>
                                <li><a>Diagnóstico por Imágenes</a>
                                <ul id="UlImagenes">
                                    <asp:Literal ID="ImagenesAnios" runat="server"></asp:Literal>
								</ul>
                                </li>

                                <li><a>Anatomía Patológica</a>
                                <ul id="UlAnatomiaPatologica">
                                    <asp:Literal ID="AnatomiaPatologicaAnios" runat="server"></asp:Literal>
								</ul>
                                </li>

                                <li><a>Endoscopía</a>
                                <ul id="UlEndoscopia">
                                    <asp:Literal ID="EndoscopiaAnios" runat="server"></asp:Literal>
								</ul>
                                </li>

                        </ul>
                </li>
                <li><a>Atención en Guardia</a>
                        <ul>
                            <asp:Literal ID="UlGuardia" runat="server"></asp:Literal>
                        </ul>
                </li>
        </ul>
</div>
</div>

</div>

<div class="PieHistoriaClinica">
<a class="btn pull-right" style="display:none;"><i class="icon-print"></i>&nbsp;Imprimir</a>
<div class="clearfix"></div>
</div>

</div>


<div style="float:left;width:850px;margin-left:15px">
<br/>
<span class="DatoHistoriaClinica"></span>
<br/><br/>

<div style="height:400px;overflow:inherit;overflow-x:hidden; background-color:#fff; overflow:auto;" >
<table id="TablaInternacion" class="table table-condensed table-hover" style="display:none;">
<thead class="contenido">
           <tr>
              <th>Ingreso</th>
              <th>Egreso</th>
              <th>Servicio</th>
              <th>Motivo Ingreso</th>
              <th>Motivo Egreso</th>
              <th>Especialidad</th>
              <th>Médico</th>
          </tr>
          </thead>
          <tbody id="TInternacion" class="contenido">
          </tbody>
</table>

<table id="TablaCirugia" class="table table-condensed table-hover" style="display:none;">
 <thead class="contenido">
          <tr>
          <th>Fecha</th>
          <th>Cirugia</th>
          <th>Cirujano</th>
          <th>Diangostico</th>
          <th>Especialidad</th>
          </tr>
</thead>
          <tbody id="TCirugia" class="contenido">

          </tbody>
</table>

<table id="TablaAmbulatorio" class="table table-condensed table-hover" style="display:none;">
<thead class="contenido">
          <tr>
          <th>Fecha</th>
          <th>Especialidad</th>
          <th>Médico</th>
          <th>Diagnostico</th>
          </tr>
          </thead>
          <tbody id="TAmbulatorio" class="contenido">

          </tbody>        
</table>

<table id="TablaRecetas" class="table table-condensed table-hover" style="display:none;">
<thead class="contenido">
          <tr>
          <th>Fecha</th>
          <th>Especialidad</th>
          <th>Médico</th>
          <th>Diagnostico</th>
          </tr>
          </thead>
          <tbody id="TRecetas" class="contenido">

          </tbody>        
</table>

<table id="TablaLaboratorio" class="table table-condensed table-hover" style="display:none;">
  <div id="cargando" style="text-align:center; display:none;">
                    <br /><br />
                    <img src="../img/Espere.gif" /><br />
                    Cargando...
 </div>   
<thead class="contenido">
          <tr>
          <th>Protocolo</th>
          <th>Fecha</th>
          </tr>
          </thead>
          <tbody id="TLabo" class="contenido">

          </tbody>        
</table>

<table id="TablaInterconsultas" class="table table-condensed table-hover" style="display:none;">
<thead class="contenido">
          <tr>
          <th>Fecha</th>
          <th>Med. Solicitante</th>
          <th>Esp. de Interconsulta</th>
          <th>Med. Interconsulta</th>
          <th>Motivo</th>
          </tr>
          </thead>
          <tbody id="TInter" class="contenido">

          </tbody>        
</table>



<table id="TablaImagenes" class="table table-condensed table-hover" style="display:none;">
<thead class="contenido">
          <tr>
          <th></th>
          <th>Fecha</th>
          <th>Est. Solicitado</th>          
          </tr>
          </thead>
          <tbody id="TImg" class="contenido">

          </tbody>        
</table>


<table id="TablaAnatomiaPatologica" class="table table-condensed table-hover" style="display:none;">
<thead class="contenido">
          <tr>
          <th>Fecha</th>
          <th>Cirugía</th>          
          <th>Cirujano</th>          
          </tr>
          </thead>
          <tbody id="TAnaPato" class="contenido">

          </tbody>        
</table>


<table id="TablaEndoscopia" class="table table-condensed table-hover" style="display:none;">
 <thead class="contenido">
          <tr>
          <th>Fecha</th>
          <th>Procedimiento</th>
          <th>Endoscopista</th>
          <th>Diangostico</th>
          <th>Especialidad</th>
          </tr>
</thead>
          <tbody id="TEndo" class="contenido">

          </tbody>
</table>

</div>
</div>
</div>
<div class="clearfix"></div>

   
</div>
</div>
</div>

<div id="myModalOpciones" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
<div class="modal-header">
<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
<h3 id="myModalLabel">Opciones</h3>
</div>
<div class="modal-body">
<p>
<a class="btn" onclick="ConsultaG();" style="margin: 5px 5px 5px 5px;">Carga de Consulta</a>
<a class="btn" onclick="Receta();" style="margin: 5px 5px 5px 5px;">Recetas</a>
<a class="btn" onclick="CargadeEstudios();" style="margin: 5px 5px 5px 5px;">Ordenes de Estudios</a>
<a class="btn" onclick="AltaComplejidad();" style="margin: 5px 5px 5px 5px;">Estudios de Alta Complejidad</a>
<a class="btn" onclick="CertificadoMedico();" style="margin: 5px 5px 5px 5px;">Certificado Médico</a>
<a class="btn" onclick="OrdenesInternacion();" style="margin: 5px 5px 5px 5px;">Orden de Internación</a>
<a class="btn" onclick="SolicituddeTraslado();" style="margin: 5px 5px 5px 5px;">Orden de Traslado</a>

</p>
</div>
<div class="modal-footer">
<button class="btn" data-dismiss="modal" aria-hidden="true">Cerrar</button>
</div>
</div>
<script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/bootstrap.js"></script> 
<script src="../js/Hospitales/HistoriaClinica/HistoriaClinica.js" type="text/javascript"></script>
<script src="../js/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
<link href="../css/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
<script src="../js/GeneralG.js" type="text/javascript"></script>
</body>
</html>