<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" /> 
<title>GesInMed</title>
<link rel="stylesheet" type="text/css" href="css/bootstrap.css"/>
<link rel="stylesheet" type="text/css" href="css/barra.css"/>

<script type="text/javascript" >
    var Nro_Box = -1;

    function imgErrorPaciente(image) {
        image.onerror = "";
        image.src = "img/silueta.jpg";
        return true;
    }

    function Abrir_popUP() {
        var ancho = 900;
        var alto = 600;
        var posicion_x = (screen.width / 2) - (ancho / 2);
        var posicion_y = (screen.height / 2) - (alto / 2);
        var pagina = "Pacientes/Alta.aspx";
        var opciones = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, width=508, height=365, top=85, left=140";
        window.open(pagina, "", "width=" + ancho + ",height=" + alto + ",menubar=0,toolbar=0,directories=0,scrollbars=no,resizable=no,left=" + posicion_x + ",top=" + posicion_y + "");
    }

    function AltaProvisoria() {
        var ancho = 900;
        var alto = 600;
        var posicion_x = (screen.width / 2) - (ancho / 2);
        var posicion_y = (screen.height / 2) - (alto / 2);
        var pagina = "Pacientes/NuevoAfiliado.aspx";
        var opciones = "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, width=900, height=365, top=85, left=140";
        window.open(pagina, "", "width=" + ancho + ",height=" + alto + ",menubar=0,toolbar=0,directories=0,scrollbars=no,resizable=no,left=" + posicion_x + ",top=" + posicion_y + "");
    }

    function OError() {
        $("#barra_sup").hide();
    }

    function Perfil() {
        $('#uom_boton').click();
        $('#Pagina').attr('src', 'Administracion/CambiarClave.aspx');
        $('#Pagina').reload();
    }


</script>


</head>

<body>

<div id="Advertencia" style="background-color:#1E00AE; width:100%; height:100%; display:none; position:absolute; z-index:99999; font-family:Consolas; font-weight:bold; font-size:20px; "><div style="margin-left:45%; margin-top:100px;"><span style="text-align:center; background-color:#A9A9A9; color:#1E00AE; width:200px; display:block">GesInMed</span></div><div style="color:White; font-weight:bold; margin-top:100px; margin-left:100px;">Ha ocurrido un error con la sesión. Para continuar:<br /><br />Abra una pestaña del navegador y vuelva a iniciar sesión.<br /><br />Este mensaje desaparecerá automáticamente y podrá seguir con lo que estaba hace un instante.<br /><br />De no ser así comuniquese con sistemas al 229 o 349 de lunes a viernes de 9 a 20 hs.<br /><br /><br />Error: Perdida de conectividad.</div></div>

<div id="barra_sup">
  <div id="datos_usuario">
    <div class="pull-left"> <img src="img/logo.png" id="logo_img" style="cursor:pointer;"/> <span class="titulo_UOM">GESTIÓN INTEGRAL MÉDICA - 
        <asp:Label ID="lblSeccional" runat="server" Text=""></asp:Label></span></div>

<% Hospital.VerificadorBLL v = new Hospital.VerificadorBLL();%>

<span class="pull-right">

<a class="btn  cerrar_sesion" href="CerrarSession.aspx" ><i class="icon-off"></i>&nbsp;&nbsp;Cerrar sesión</a>
</span> <span class="pull-right">

<%if (v.PermisoSM("12")) {%>
<a class="btn cerrar_sesion" href="#" onclick="AsignarBox();"><i class="icon-user"></i>&nbsp;&nbsp;Nro. Box: <b><span id="span_nro_box"> - </span></b></a>
<%} %>

<a class="btn cerrar_sesion" href="#" onclick="Perfil();"><i class="icon-user"></i>&nbsp;&nbsp;Cambiar Clave</a></span> </div>
  <div class="clearfix"></div>
     <div id="menu_principal">
    <ul class="nav nav-pills">
      

            <% if (v.PermisoMenu("1"))
         { %>
      <li class="dropdown bmenu" id="Li1" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Turnos<b class="caret"></b></a>
        <ul class="dropdown-menu">
         
          <% if (v.PermisoSM("11")) { %><li pric="Turnos" rel="Turnos/GeneraciondeTurnos.aspx"><a href="#">Generar Grilla de Turnos de los Médicos</a></li><%} %>
          <% if (v.PermisoSM("11")) { %><li pric="Turnos" rel="Turnos/Generacion_Turno_DiayHora.aspx"><a href="#">Generar Grilla de Turnos (Dia y Hora)</a></li><%} %>
          <% if (v.PermisoSM("12")) { %><li pric="Turnos" rel="Turnos/CargaExpress.aspx"><a>Pedidos de Turno</a></li><%} %>
          <% if (v.PermisoSM("13")) { %><li pric="Turnos" rel="Turnos/ConfirmarAtencion.aspx"><a href="#">Confirmar Turno</a></li><%} %>
          <% if (v.PermisoSM("14")) { %><li pric="Turnos" rel="Turnos/CancelacionDeTurnos.aspx"><a href="#">Cancelar Turno</a></li><%} %>
          <% if (v.PermisoSM("16")) { %><li pric="Turnos" rel="Turnos/VerTodoslosTurnos.aspx"><a href="#">Parte Diario</a></li><%} %>
          <% if (v.PermisoSM("17")) { %><li pric="Turnos" rel="Turnos/HistoricodeTurnosporPaciente.aspx"><a href="#">Informe Histórico de Turnos por Paciente</a></li><%} %>
          <% if (v.PermisoMenu("16")){ %>
                  <li pric="Informes" rel="Informes/ReportesDePatologia.aspx?tipodeInforme=11"><a>Reportes de Patología</a></li>
                  <%}%>
          <% if (v.PermisoSM("9920"))
             { %><li pric="Turnos"><a href="javascript:AltaProvisoria();">Pacientes</a></li><%} %>
        </ul>
      </li>
      <%} %>



           <% if (v.PermisoMenu("11"))
         { %>
      <li class="dropdown bmenu" id="Imagenes" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Imagenes<b class="caret"></b></a>
        <ul class="dropdown-menu">                    
          <% if (v.PermisoSM("111")) { %><li pric="Imagenes" rel="Imagenes_Turno/Turno.aspx"><a>Pedidos de Turno</a></li><%} %>          
          <% if (v.PermisoSM("112")) { %><li pric="Imagenes" rel="Imagenes_Turno/Practica_Duracion.aspx"><a>Modificar duración de prácticas</a></li><%} %>          
          <% if (v.PermisoSM("113")) { %><li pric="Imagenes" rel="Imagenes_Turno/Medico_Opciones.aspx"><a>Modificar días de atención</a></li><%} %>          
          <% if (v.PermisoSM("119")) { %><li pric="Imagenes" rel="Imagenes_Turno/RelacionPracticaMedico.aspx"><a href="#">Prácticas por Médicos</a></li><%} %>          
          <% if (v.PermisoSM("114")) { %><li pric="Imagenes" rel="Imagenes_Turno/RelacionPracticaIndicaciones.aspx"><a>Indicaciones de Prácticas</a></li><%} %>          
          <% if (v.PermisoSM("115")) { %><li pric="Imagenes" rel="Imagenes_Turno/Informe_Practica_Cargar.aspx"><a>Cargar Informes</a></li><%} %>          
          <% if (v.PermisoSM("116")) { %><li pric="Imagenes" rel="Imagenes_Turno/TurnoConsultorio.aspx"><a href="#">Pacientes del Día (IMAGENES)</a></li><%} %>
          <% if (v.PermisoSM("117")) { %><li pric="Imagenes" rel="Imagenes_Turno/Informes_Plantilla.aspx"><a href="#">Edición Plantillas</a></li><%} %>
          <% if (v.PermisoSM("118")) { %><li pric="Imagenes" rel="Imagenes_Turno/ListadoTurnos.aspx"><a href="#">Listado de turnos</a></li><%} %>          
          <% if (v.PermisoSM("119")) { %><li pric="Imagenes" rel="Imagenes_Turno/IMGMedicoFirma.aspx"><a href="#">Firma de médicos</a></li><%} %>            
          
          
          <% if (v.PermisoSM("9920"))
             { %><li pric="Turnos"><a href="javascript:AltaProvisoria();">Pacientes</a></li><%} %>
        </ul>
      </li>
      <%} %>


      <% if (v.PermisoMenu("2"))
         { %>
      <li class="dropdown bmenu" id="Bonos" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Bonos <b class="caret"></b></a>
        <ul class="dropdown-menu">
           <% if (v.PermisoSM("21")) { %><li pric="Bonos" rel="Bonos/NuevoBono.aspx"><a>Nuevo Bono</a></li><%} %>
           <% if (v.PermisoSM("22")) { %><li pric="Bonos" rel="Bonos/BuscarBonos.aspx"><a>Buscar Bonos</a></li><%} %>
           <% if (v.PermisoSM("23")) { %><li pric="Bonos" rel="Bonos/RendicionBono.aspx"><a>Rendición de Bonos por Usuarios</a></li><%} %>
           <% if (v.PermisoSM("24")) { %><li pric="Bonos" rel="Bonos/CancelarBono.aspx"><a>Cancelar Bonos</a></li><%} %>
           <% if (v.PermisoSM("25")) { %><li pric="Bonos" rel="Turnos/Listado_Cantidad_Pac_Por_Esp.aspx"><a>Listado de Pacientes Atendidos por Especialidad</a></li><%} %>
           <% if (v.PermisoSM("27")) { %><li pric="Bonos" rel="Bonos/CambiarEspecialidad.aspx"><a>Compensación de Bono</a></li><%} %>
           <% if (v.PermisoSM("28")) { %><li pric="Bonos" rel="Bonos/Bonos_ValeCaja.aspx"><a>Vale de Caja</a></li><%} %> 
           <% if (v.PermisoSM("29")) { %><li pric="Bonos" rel="Bonos/Bonos_CajaVale_Listado.aspx"><a>Listado de Bonos (Vale de Caja)</a></li><%} %>
           <% if (v.PermisoSM("26")) { %><li pric="Bonos" rel="Bonos/RendicionPracticasPorPacientes.aspx"><a>Informe de Prácticas por Pacientes</a></li><%} %>
           <% if (v.PermisoSM("30")) { %><li pric="Bonos" rel="Imagenes_Turno/Bono.aspx"><a>Bonos para Imagenes</a></li><%} %>
           <% if (v.PermisoSM("9927")){ %><li pric="Bonos" rel="Bonos/LiberarBono.aspx"><a>Liberar Bono</a></li><%} %>
           <% if (v.PermisoSM("9920"))
              { %><li pric="Bonos"><a href="javascript:AltaProvisoria();">Pacientes</a></li><%} %>
        </ul>
      </li>
      <%} %>

 

      <% if (v.PermisoMenu("3"))
         { %>
      <li class="dropdown bmenu" id="AtConsultorio" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Consultorio<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("31")) { %><li pric="AtConsultorio" rel="AtConsultorio/RecepciondePacientes.aspx"><a href="#">Recepción de Pacientes</a></li><%} %>
          <% if (v.PermisoSM("32")) { %><li pric="AtConsultorio" rel="AtConsultorio/PacientesDelDia.aspx"><a href="#">Pacientes del Día</a></li><%} %>
          <% if (v.PermisoSM("33")) { %><li pric="AtConsultorio" rel="HistoriaClinica/BuscarPacienteHC.aspx"><a href="#">Historia Clínica</a></li><%} %>
          <% if (v.PermisoSM("34")) { %><li pric="AtConsultorio" rel="AtConsultorio/Buscar_Paciente.aspx"><a href="#">Diabetología</a></li><%} %>		 
          <% if (v.PermisoSM("36")) { %><li pric="AtConsultorio" rel="AtConsultorio/Enfermeria_Entregar.aspx"><a href="#">Pedidos a Enfermería</a></li><%} %>
          <% if (v.PermisoSM("37")) { %><li pric="AtConsultorio" rel="AtConsultorio/Historial_Llamado.aspx"><a href="#">Historial de Llamados por Consultorio</a></li><%} %>
          <% if (v.PermisoSM("38")) { %><li pric="AtConsultorio" rel="HistoriaClinica/Archivo_Movimientos.aspx"><a href="#">Archivo de Historias Clínicas</a></li><%} %>
          <% if (v.PermisoSM("310")) { %><li pric="AtConsultorio" rel="Turnos/AsignarConsultoriodelDia.aspx"><a href="#">Asignar Consultorio del Día</a></li><%} %>          
          <% if (v.PermisoSM("9920"))
             { %><li pric="AtConsultorio"><a href="javascript:AltaProvisoria();">Pacientes</a></li><%} %>
        </ul>
      </li>
      <%} %>

      <% if (v.PermisoMenu("4"))
         { %>
      <li class="dropdown bmenu" id="Guardia" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Guardia<b class="caret"></b></a>
        <ul class="dropdown-menu">
         <% if (v.PermisoSM("41")) { %><li pric="Guardia" rel="Guardia/Listado.aspx"><a href="#">Pacientes del Día</a></li><%} %>
         <% if (v.PermisoSM("42")) { %><li pric="Guardia" rel="Guardia/PedidosEnfermeria.aspx"><a href="#">Pedidos a Enfermeria por Paciente</a></li><%} %>
         <% if (v.PermisoSM("42")) { %><li pric="Guardia" rel="Guardia/EnfermeriaEntregar_Guardia.aspx"><a href="#">Pedidos a Enfermeria</a></li><%} %>
         <% if (v.PermisoSM("43")) { %><li pric="Guardia" rel="Guardia/Consumo.aspx"><a href="#">Consumo General en Guardia</a></li><%} %>
          <% if (v.PermisoSM("44")) { %><li pric="Guardia" rel="Guardia/Historial.aspx"><a href="#">Historial de Llamados por Guardia</a></li><%} %>
         <%-- <% if (v.PermisoSM("45")) { %><li pric="Guardia" rel="Informes/Filtrar_Listados.aspx?informe=guardia"><a href="#">Informes</a></li><%} %>--%>
           <% if (v.PermisoSM("9920"))
              { %><li pric="Guardia"><a href="javascript:AltaProvisoria();">Pacientes</a></li><%} %>
        </ul>
      </li>
      <%} %>

           <% if (v.PermisoMenu("5"))
         { %>
      <li class="dropdown bmenu" id="Internacion" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Admisión<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("51")) { %><li pric="Internacion" rel="Internacion/Internaciones.aspx"><a href="#">Ingresos</a></li><%} %>
          <% if (v.PermisoSM("52")) { %><li pric="Internacion" rel="Internacion/Egreso.aspx"><a href="#">Egresos</a></li><%} %>
           <% if (v.PermisoSM("51"))
             { %><li pric="Internacion" rel="Internacion/AnularIngEgr.aspx"><a href="#">Anular Ingreso/Egreso</a></li><%} %>
          <% if (v.PermisoSM("51"))
             { %><li pric="Internacion" rel="Internacion/BuscarInternacion.aspx?Desde=1"><a href="#">Buscar Internados</a></li><%} %>
          <% if (v.PermisoSM("53")) { %><li pric="Internacion" rel="Internacion/BuscarEgreso.aspx"><a href="#">Buscar Egresos</a></li><%} %>
          <% if (v.PermisoSM("54")) { %><li pric="Internacion" rel="Internacion/CensoDiario.aspx"><a href="#">Censo Diario de Camas</a></li><%} %>
		  <% if (v.PermisoSM("55")) { %><li pric="Internacion" rel="Internacion/ListarporFechas.aspx"><a href="#">Listado de Pacientes Internados</a></li><%} %>
          <% if (v.PermisoSM("56")) { %><li pric="Internacion" rel="Internacion/ListarporFechas_Egresos.aspx"><a href="#">Listado de Pacientes Egresados</a></li><%} %>
          <%--<% if (v.PermisoSM("57")) { %><li pric="Internacion" rel="Internacion/Listado_por_apellido.aspx"><a href="#">Historial por Apellido</a></li><%} %>--%>
          <%-- <% if (v.PermisoSM("57")) { %><li pric="Internacion" rel="Informes/Filtrar_Listados.aspx?informe=admision"><a href="#">Informes</a></li><%} %>--%> <%-------MANUEL--------%>
          <% if (v.PermisoSM("9920"))
             { %><li pric="Internacion"><a href="javascript:AltaProvisoria();">Pacientes</a></li><%} %>
        </ul>
      </li>
      <%} %>

      <% if (v.PermisoMenu("6"))
         { %>
      <li class="dropdown bmenu" id="AtInternacion" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Internación<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("61")) { %><li pric="AtInternacion" rel="AtInternados/ListaPacientesInternados.aspx"><a href="#">Pacientes Internados</a></li><%} %>
          <% if (v.PermisoSM("62")) { %><li pric="AtInternacion" rel="AtInternados/InterconsultaMedico.aspx"><a href="#">Interconsultas Solicitadas</a></li><%} %>
          <% if (v.PermisoSM("64")) { %><li pric="AtInternacion" rel="AtInternados/InterconsultasDireccion.aspx"><a href="#">Interconsultas Dirección</a></li><%} %>
          <% if (v.PermisoSM("63")) { %><li pric="AtInternacion" rel="Nutricion/Nutricion.aspx?como=todos&indiceAseguir=0"><a href="#">Nutrición</a></li><%} %>
          <% if (v.PermisoSM("63")) { %><li pric="AtInternacion" rel="Nutricion/TotalDeComidasDiarias.aspx"><a href="#">Total de Comidas Diarias</a></li><%} %>
          <% if (v.PermisoSM("63")) { %><li pric="AtInternacion" rel="Nutricion/Pedido_De_Catering.aspx"><a href="#">Pedidos de Catering</a></li><%} %>
          <% if (v.PermisoSM("65")) { %><li pric="AtInternacion" rel="AtInternados/Pase_Guardia_UTI_ListarPasesdelDia.aspx"><a href="#">Pases de Guardia a UTI del Dia</a></li><%} %>
          
        </ul>
      </li>
      <%} %>

         <% if (v.PermisoMenu("16"))
         { %>
            <li id = "Compras" class="dropdown" style="margin-right:8px">
            <a class="dropdown-toggle" data-toggle="dropdown"  href="#">Compras<b class="caret"></b></a>
            <ul class="dropdown-menu multi-level">
              <li class="dropdown-submenu">
                <a tabindex="-1" href="#">Ambulatorio CABA</a> 
                    <ul class="dropdown-menu">
                      <% if (v.PermisoSM("163"))
                         { %><li pric="Compras" rel="Compras/Mostrar_Expedientes.aspx"><a href="#">Buscar Expedientes</a></li><%} %>
                      <% if (v.PermisoSM("163"))
                         { %><li pric="Compras" rel="Compras/Compras_Expediente_Ficha.aspx"><a href="#">Nuevo Expediente</a></li><%} %>
                      <% if (v.PermisoSM("164")) { %><li pric="Compras" rel="Compras/Compras_Auditar_Pedidos.aspx"><a href="#">Auditoria</a></li><%} %>
                      <% if (v.PermisoSM("161"))
                         { %><li pric="Compras" rel="Compras/Compras_CargarRemito.aspx"><a href="#">Ingreso de Insumos del Proveedor</a></li><%} %>
                      <% if (v.PermisoSM("167")) { %><li pric="Compras" rel="Compras/Compras_InformeGlobal.aspx"><a href="#">Control de Entregas</a></li><%} %>
                      <% if (v.PermisoSM("168")) { %><li pric="Compras" rel="Compras/ReporteAmbulatorioCABA.aspx"><a href="#">Reporte Ambulatorio CABA</a></li><%} %>
                    </ul>              
              </li>
              <li class="dropdown-submenu">
                <a tabindex="-1" href="#">Submenú 2</a> 
                    <ul class="dropdown-menu">
                    </ul>              
              </li>
              <li class="dropdown-submenu">
                <a tabindex="-1" href="#">Submenú 3</a> 
                    <ul class="dropdown-menu">
                    </ul>              
              </li>
            </ul>
            </li>
      <%} %>

      <% if (v.PermisoMenu("7"))
         { %>
      <li class="dropdown bmenu" id="Quirofano" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Quirófano<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("71")) { %><li pric="Quirofano" rel="Quirofano/CargadeTurnos.aspx"><a href="#">Turnos</a></li><%} %>
          <% if (v.PermisoSM("33")) { %><li pric="Quirofano" rel="HistoriaClinica/BuscarPacienteHC.aspx"><a href="#">Historia Clínica</a></li><%} %>
         <%-- <% if (v.PermisoSM("33")) { %><li pric="Quirofano" rel="Informes/Filtrar_Listados.aspx?informe=quirofano"><a href="#">Informes</a></li><%} %>--%> <%-------MANUEL--------%>
        </ul>
      </li>
      <%} %>



      <% if (v.PermisoMenu("13"))
         { %>
      <li class="dropdown bmenu" id="Endoscopia" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Endoscopía<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("131")) { %><li pric="Endoscopia" rel="Endoscopia/CargadeTurnos.aspx"><a href="#">Turnos</a></li><%} %>
          <% if (v.PermisoSM("33")) { %><li pric="Endoscopia" rel="HistoriaClinica/BuscarPacienteHC.aspx"><a href="#">Historia Clínica</a></li><%} %>         
        </ul>
      </li>
      <%} %>

       <% if (v.PermisoMenu("14"))
         { %>
      <li class="dropdown bmenu" id="Legales" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Legales<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("141"))
             { %><li pric="Legales" rel="Legales/CargarPedido.aspx"><a href="#">Cargar Pedido</a></li><%} %>
          <% if (v.PermisoSM("142"))
             { %><li pric="Legales" rel="Legales/BuscarPedido.aspx"><a href="#">Buscar Pedido</a></li><%} %>         
            <% if (v.PermisoSM("9920"))
             { %><li pric="Legales"><a href="javascript:AltaProvisoria();">Pacientes</a></li><%} %>
        </ul>
      </li>
      <%} %>

             <% if (v.PermisoMenu("8")) { %>
      <li class="dropdown bmenu" id="Li2" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Farmacia<b class="caret"></b></a>
        <ul class="dropdown-menu">
        <% if (v.PermisoSM("81")) { %>  <li pric="Farmacia" rel="Farmacia/MostrarInsumos.aspx"><a href="#">Alta, Modificación y Eliminación de Insumos</a></li> <%} %>
        <%--<% if (v.PermisoSM("82")) { %>  <li pric="Farmacia" rel="Farmacia/CargarPPS.aspx"><a href="#">Pedidos por Servicio</a></li><%} %>
        <% if (v.PermisoSM("819")) { %>  <li pric="Farmacia" rel="Farmacia/CargarPPSP.aspx"><a href="#">Pedidos Predeterminados por Servicio</a></li><%} %>
        <% if (v.PermisoSM("83")) { %>  <li pric="Farmacia" rel="Farmacia/CargarPedidoporPaciente.aspx"><a href="#">Pedidos por Paciente Ambulatorio</a></li><%} %>
        <% if (v.PermisoSM("84")) { %>  <li pric="Farmacia" rel="Farmacia/CargarIM.aspx"><a href="#">Pedidos por Indicación Médica</a></li><%} %>
        <% if (v.PermisoSM("85")) { %>  <li pric="Farmacia" rel="Farmacia/EntregasPPS.aspx"><a href="#">Entregas por Servicio</a></li><%} %>
        <% if (v.PermisoSM("86")) { %>  <li pric="Farmacia" rel="Farmacia/EntregasPPP.aspx"><a href="#">Entregas por Paciente Ambulatorio</a></li><%} %>
        <% if (v.PermisoSM("87")) { %>  <li pric="Farmacia" rel="Farmacia/EntregasIM.aspx"><a href="#">Entregas por Indicación Médica</a></li><%} %>
        <% if (v.PermisoSM("88")) { %>  <li pric="Farmacia" rel="Farmacia/PedidosPendientes.aspx"><a href="#">Pedidos Pendientes</a></li><%} %>
        <% if (v.PermisoSM("89")) { %>  <li pric="Farmacia" rel="Farmacia/DevolucionporServicio.aspx"><a href="#">Devoluciones por Servicio</a></li><%} %>
        <% if (v.PermisoSM("811")) { %> <li pric="Farmacia" rel="Farmacia/DevolucionporPaciente.aspx"><a href="#">Devoluciones por Paciente</a></li><%} %>--%>
        <% if (v.PermisoSM("812")) { %> <li pric="Farmacia" rel="Farmacia/CargaRemitoProveedores.aspx"><a href="#">Remitos de Proveedores</a></li><%} %>
        <% if (v.PermisoSM("813")) { %><li pric="Farmacia" rel="Farmacia/ControlVencimientos.aspx"><a href="#">Control de Vencimientos</a></li><%} %>
        <% if (v.PermisoSM("813")) { %> <li pric="Farmacia" rel="Farmacia/ControlStock.aspx"><a href="#">Control de Stock</a></li><%} %>
        <% if (v.PermisoSM("814")) { %> <li pric="Farmacia" rel="Farmacia/CargarInventarioInsumo.aspx"><a href="#">Carga de Inventario de Insumos</a></li><%} %>
        <% if (v.PermisoSM("815")) { %> <li pric="Farmacia" rel="Farmacia/BusquedaCtaCte.aspx"><a href="#">Listado de Movimientos de Insumos</a></li><%} %>
        <% if (v.PermisoSM("816")) { %> <li pric="Farmacia" rel="Farmacia/HistorialporPaciente.aspx"><a href="#">Historial de Consumo por Paciente</a></li><%} %>
        <% if (v.PermisoSM("817")) { %> <li pric="Farmacia" rel="Farmacia/Descontar_Stock.aspx"><a href="#">Descontar Stock</a></li><%} %>
        <% if (v.PermisoSM("818")) { %> <li pric="Farmacia" rel="Farmacia/ConsumobyInsumo.aspx"><a href="#">Consumo por Rubro</a></li><%} %>
        <% if (v.PermisoSM("819")) { %>  <li pric="Farmacia" rel="Farmacia/BonoContribucion.aspx"><a href="#">Bono contribución</a></li><%} %>
        <% if (v.PermisoSM("819"))
           { %>  <li pric="Farmacia" rel="Farmacia/BuscarBonoContribucion.aspx"><a href="#">Buscar Bono contribución</a></li><%} %>
        <% if (v.PermisoSM("820"))
           { %>  <li pric="Farmacia" rel="Farmacia/RendicionBonoContribucion.aspx"><a href="#">Rendicion Bono Contribución</a></li><%} %>
        </ul>
      </li>
      <%} %>

       <% if (v.PermisoMenu("9"))
         { %>
      <li class="dropdown bmenu" id="Facturacion" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Facturación<b class="caret"></b></a>
        <ul class="dropdown-menu"> 
           <% if (v.PermisoSM("91"))
              { %><li pric="Facturacion" rel="Facturacion_Cap/AltaNomencladores.aspx"><a href="#">Altas y Edición de Convenios</a></li><%} %>
              <% if (v.PermisoSM("91"))
              { %><li pric="Facturacion" rel="Facturacion_Cap/CrearNomencladores.aspx"><a href="#">Altas y Edición de Nomencladores</a></li><%} %>
          <% if (v.PermisoSM("92"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/CreacionModulos.aspx"><a href="#">Alta de Módulos</a></li><%} %>
          <% if (v.PermisoSM("93"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/CreacionPractica.aspx"><a href="#">Alta de Prácticas</a></li><%} %>
          <% if (v.PermisoSM("94"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/ValorizacionModulos.aspx"><a href="#">Valorización y Asignación de Módulos</a></li><%} %>
          <% if (v.PermisoSM("95"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/ValorizacionPracticas.aspx"><a href="#">Valorización y Asignación de Prácticas</a></li><%} %>
          <% if (v.PermisoSM("97"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/CargaPracticasMedicasHC.aspx"><a href="#">Carga de Parte</a></li><%} %>
          <% if (v.PermisoSM("99"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/Selecciondedatos.aspx"><a href="#">Selección de Datos para Facturar</a></li><%} %>
          <% if (v.PermisoSM("912"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/Facturacion.aspx"><a href="#">Proceso de Facturación</a></li><%} %>
          <% if (v.PermisoSM("915"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/LiquidacionMensual.aspx"><a href="#">Listado de Liquidación Mensual</a></li><%} %>
          <% if (v.PermisoSM("917"))
             { %><li pric="Facturacion" rel="Facturacion_Cap/Presupuestos.aspx"><a href="#">Presupuesto</a></li><%} %>
        </ul>
      </li>
      <%} %>


     <li id = "Informes" class="dropdown" style="margin-right:8px">
            <a class="dropdown-toggle" data-toggle="dropdown"  href="#">Informes <b class="caret"></b></a>

    		<ul class="dropdown-menu multi-level">

              <li pric="Informe"  rel="Informes_Medicos/Informes_Medicos.aspx"><a>Protocolos de Atención</a></li>
             
              <li class="divider"></li>
              <li class="dropdown-submenu">
                <a tabindex="-1" href="#">Informes Administrativos</a> 
                <ul class="dropdown-menu">
                  <li pric="Informes" rel="Informes/ReportesDeGuardia.aspx?tipodeInforme=1"><a>Reportes de Guardia</a></li>
                   <% if (v.PermisoSM("9919"))
                     { %>
                        <li pric="Informes" rel="Informes/ReportesDeProduccion.aspx?tipodeInforme=2"><a>Reportes de Producción</a></li>
                  <%} %>
                  <li pric="Informes" rel="Informes/ReportesDeTurnos.aspx?tipodeInforme=3"><a>Reportes de Turnos</a></li>
                  <li pric="Informes" rel="Informes/ReportesDeLaboratorio.aspx?tipodeInforme=4"><a>Reportes de Laboratorio</a></li>
                  <li pric="Informes" rel="Informes/ReportesDeDiabetologia.aspx?tipodeInforme=5"><a>Reportes de Diabetología</a></li>
           <% if (v.PermisoSM("9919"))
              { %><li pric="Informes" rel="Informes/ReportesDeBonos.aspx?tipodeInforme=7"><a>Reportes de Bonos</a></li>
         <%} %>
                  <li pric="Informes" rel="Informes/ReportesDeAutorizaciones.aspx?tipodeInforme=8"><a>Reportes de Autorizaciones</a></li>
                  <li pric="Informes" rel="Informes/ReportesDeQuirofanoFiltros.aspx?tipodeInforme=9"><a>Reportes de Quirofano</a></li>
                  <li pric="Informes" rel="Informes/ReportesDeEndoscopia.aspx"><a>Reportes de Endoscopia</a></li>
                  <li pric="Informes" rel="Informes/ReportesDeInternacion.aspx?tipodeInforme=10"><a>Reportes de Internación</a></li>
                  <% if (v.PermisoMenu("15"))
                  { %>
                  <li pric="Informes" rel="Informes/ReportesDePatologia.aspx?tipodeInforme=11"><a>Reportes de Patología</a></li>
                  <%}%>
                  <li pric="Informes" rel="Informes/ReportesDeImagenes.aspx?tipodeInforme=12"><a>Reportes de Imágenes</a></li>
                  <li pric="Informes" rel="Informes/ReportesDeART.aspx?tipodeInforme=6"><a>Reportes de ART</a></li>
                   <li pric="Informes" rel="Informes/Reportes_De_Indicadores.aspx"><a>Reportes de Indicadores</a></li>
                   <li pric="Informes" rel="Informes/ReportesDeCompras.aspx"><a>Reportes de Compras</a></li>
                    <li pric="Informes" rel="Informes/Reporte_Hc_Supreme.aspx"><a>Ficha de Consumo</a></li>
                </ul>
              
              </li>
            </ul>
       </li>
      
       
      <% if (v.PermisoMenu("12"))
         { %>
      <li class="dropdown bmenu" id="Deriv_Autoriz" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Derivaciones <b class="caret"></b></a>
        <ul class="dropdown-menu">
         <% if (v.PermisoSM("121")) { %><li pric="Deriv_Autoriz" rel="DerivacionyTraslado/DerivacionyTraslado.aspx?opcion=1"><a href="#">Derivaciones y Traslados</a></li><%} %>
         <% if (v.PermisoSM("122")) { %><li pric="Deriv_Autoriz" rel="DerivacionyTraslado/DerivacionyTraslado.aspx?opcion=2"><a href="#">Autorizaciones</a></li><%} %>
         <% if (v.PermisoSM("126")) { %><li pric="Deriv_Autoriz" rel="DerivacionyTraslado/AutorizacionExpress.aspx"><a href="#">Autorización Express</a></li><%} %>
         <% if (v.PermisoSM("123")) { %><li pric="Deriv_Autoriz" rel="DerivacionyTraslado/AutorizacionesCargarValoresPracticas.aspx"><a href="#">Nomenclador de Prestadores</a></li><%} %>
         <% if (v.PermisoSM("124")) { %><li pric="Deriv_Autoriz" rel="DerivacionyTraslado/Alta_Edicion_Subrubros_Prestadores.aspx?titulo=1"><a href="#">Alta y Edición de Subrubros</a></li><%} %>
         <% if (v.PermisoSM("125")) { %><li pric="Deriv_Autoriz" rel="DerivacionyTraslado/Alta_Edicion_Subrubros_Prestadores.aspx?titulo=2"><a href="#">Alta y Edición de Prestadores</a></li><%} %>
         <% if (v.PermisoSM("127")) { %><li pric="Deriv_Autoriz" rel="Compras/ConstanciaEntrega.aspx"><a href="#">Constancia de Entrega</a></li><%} %>
         <li pric="Internacion"><a href="javascript:AltaProvisoria();">Pacientes</a></li>
        </ul>
      </li>
      <%} %>


<%--      <% if (v.PermisoMenu("99"))
         { %>--%>
      <li class="dropdown bmenu" id="Administracion" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Administración<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("991")) { %><li pric="Administracion" rel="Turnos/Centro.aspx" ><a href="#">Centro de Salud</a></li><%} %>
          <% if (v.PermisoSM("992")) { %><li pric="Administracion" rel="Turnos/Medicos.aspx"><a href="#">Médicos</a></li><%} %>
          <% if (v.PermisoSM("994")) { %><li pric="Administracion" rel="Administracion/Feriados.aspx"><a href="#">Feriados</a></li><%} %>
          <% if (v.PermisoSM("995")) { %><li pric="Administracion" rel="Administracion/BuscarUsuarios.aspx"><a href="#">Usuarios</a></li><%} %>
          <% if (v.PermisoSM("996")) { %><li pric="Administracion" rel="Administracion/AdministracionEditarPerfiles.aspx"><a href="#">Perfiles</a></li><%} %>
          <% if (v.PermisoSM("997")) { %><li pric="Administracion" rel="Administracion/RelacionUsuarioMedico.aspx"><a href="#">Relación Usuario - Médicos</a></li><%} %>
          <% if (v.PermisoSM("998")) { %><li pric="Administracion" rel="Administracion/admin_Especialidades.aspx"><a>Altas y Edición de Especialidades</a></li><%} %>
          <% if (v.PermisoSM("999")) { %><li pric="Administracion" rel="Guardia/GuardiaBoxes.aspx"><a href="#">Edición de Boxes de Guardia</a></li><%} %>
                    <% if (v.PermisoSM("999")) { %><li pric="Administracion" rel="Informes/Filtrar_txt_Diabetes.aspx"><a href="#">Generación Archivo para Super Intendencia de Salud</a></li><%} %>
          <% if (v.PermisoSM("9911"))
             { %><li pric="Administracion" rel="Guardia/EditarPlantillas.aspx"><a href="#">Editar Plantilla de Insumos y Prácticas de Guardia</a></li><%} %>
          <% if (v.PermisoSM("9913")) { %><li pric="Administracion" rel="Internacion/ServicioSalaCama.aspx"><a href="#">Servicios - Salas - Camas</a></li><%} %>
          <% if (v.PermisoSM("9914")) { %><li pric="Administracion" rel="Quirofano/EditarPlantilla.aspx"><a href="#">Editar Plantilla de Insumos de Quirófano</a></li><%} %>
          <% if (v.PermisoSM("9915")) { %><li pric="Administracion" rel="Farmacia/ABM_Proveedores.aspx"><a href="#">Altas y Edición de Proveedores</a></li><%} %>
          <% if (v.PermisoSM("9918")) { %><li pric="Administracion" rel="Farmacia/ABM_Depositos.aspx"><a href="#">Altas y Edición de Depósitos</a></li><%} %>
          <% if (v.PermisoSM("9918")) { %><li pric="Administracion" rel="Administracion/admin_Localidades.aspx"><a href="#">Altas y Edición de Localidades</a></li><%} %>
          <% if (v.PermisoSM("9919")) { %><li pric="Administracion" rel="Administracion/PasajedeHC.aspx"><a href="#">Pasaje de Historia Clinica</a></li><%} %>
          <% if (v.PermisoSM("9920")) { %><li pric="Administracion" rel="Administracion/admin_EliminarHC.aspx"><a href="#">Eliminar Historia Clinica</a></li><%} %>
         <% if (v.PermisoSM("9921")) { %><li pric="Administracion" rel="Administracion/admin_OrdenesEstudio_Plantilla.aspx"><a href="#">Altas y Edición de Plantillas de Estudios</a></li><%} %>
        </ul>
      </li>
<%--      <%} %>--%>

<% if (v.PermisoSM("9926"))
   { %>
   <li class="bmenu" rel="Entrega_de_Resultados/AdministrarEntrega.aspx"><a href="#"></i>Entrega de Resultados</a></li>
<%} %>


  <% if (v.PermisoMenu("15"))
         { %>
      <li class="dropdown bmenu" id="APtológica" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Patología<b class="caret"></b></a>
        <ul class="dropdown-menu">
          <% if (v.PermisoSM("151")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/Principal.aspx?titulo=carga&mostrar=1"><a href="#">Carga Estudio</a></li><%} %>
          <% if (v.PermisoSM("158")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/PAP.aspx"><a href="#">Carga PAP</a></li><%} %>
          <% if (v.PermisoSM("152")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/ABMS.aspx?titulo=Procedimientos&mostrar=1"><a href="#">Alta y Edición de Procedimientos</a></li><%} %>
          <% if (v.PermisoSM("153")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/ABMS.aspx?titulo=Material&mostrar=1"><a href="#">Alta y Edición de Material</a></li><%} %>
          <% if (v.PermisoSM("154")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/ABMS.aspx?titulo=Métodos&mostrar=1"><a href="#">Alta y Edición de Métodos</a></li><%} %>
          <% if (v.PermisoSM("155")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/ABMS.aspx?titulo=Técnicas&mostrar=1"><a href="#">Alta y Edición de Técnicas Especiales</a></li><%} %>
          <% if (v.PermisoSM("156")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/ABMS.aspx?titulo=Nomenclador&mostrar=1"><a href="#">Alta y Edición de Nomenclador Nacional</a></li><%} %>
          <% if (v.PermisoSM("157")) { %><li pric="APtológica" rel="AnatomiaPatologicaTrue/ABMS.aspx?titulo=Diagnósticos&mostrar=1"><a href="#">Alta y Edición de Códigos de Diagnóstico</a></li><%} %>
        </ul>
      </li>
      <%} %>

<% if (v.PermisoSM("9922")) { %>
   <li class="bmenu"><a href="javascript:Abrir_popUP();"></i>Padrón U.O.M.</a></li>
<%} %>



<% if (v.PermisoMenu("9999"))
   { %>
      <li class="dropdown bmenu" id="Sistemas" style="margin-right:8px"> <a class="dropdown-toggle" data-toggle="dropdown" href="#">Sistemas<b class="caret"></b></a>
         <ul class="dropdown-menu">
            <li pric="Sistemas" rel="Sistemas/Version_Comentario.aspx"><a href="#">Versiones y Cambios</a></li>
         </ul>
      </li>
<% } %>
  </div>
  <!--Fin del menu principal--> 
  
  <!--Barra superior de color-->
  <div class="barra_dondeestoy" style="cursor:pointer;">
    <div id="DondeEstoy"><strong>Inicio</strong></div>
  </div>
  <div id="uom_boton" class=" pull-right uom_boton">
    <div style="margin-top:-20px;"> <span class="avatar"><img src="img/Usuarios/<asp:Literal ID="LiteralUsuario" runat="server"></asp:Literal>.jpg" onerror="imgErrorPaciente(this);"/></span> <span class="nombre usuario"><asp:Literal ID="LiteralUsuario2" runat="server"></asp:Literal></span><img class="pull-right" src="img/show.png" style="margin-top:10px" >
    </div>
  </div>
</div>
<div id="lightbox" style="display:none;position:absolute;z-index:899;width:100%; height:100%;background-color:RGBA(255,255,255,0.8);"> </div>
              <input type="hidden" id="cantidad" runat="server" />

  <iframe id="Pagina" style="padding-top:20px;" src="Principal.aspx" width="100%" frameborder="0" scrolling="no"></iframe>





<!--Pie de página-->
<div class="pie">
Desarrollado por <strong>Tres Componentes S.R.L.</strong> 
<div runat="server" id="Version" style=" margin-right:10px;float:right;"></div>
</div>



<script src="js/jquery-1.8.3.js" type="text/javascript"></script>
<script type="text/javascript" src="js/bootstrap.js"></script> 
<script src="js/Hospitales/Mensajes.js" type="text/javascript"></script>
<script>
    $(document).ready(function () {
        $('#txt_Codigo').focus();


        $('#menu_principal li').click(function () {
            var url = $(this).attr('rel');
            if (url != undefined) {
                var Prin = $(this).attr('pric');
                $('li').removeClass("active");
                $('#' + Prin).addClass("active");
                $(this).addClass("active");
                $('#uom_boton').click();
                $('#Pagina').attr('src', url);
                $('#Pagina').reload();
            }
        });

    });
</script> 

<!--Barra sup--> 
<script>
    $('#desdeaqui').click(function () {        
        $("#hastaaqui").fadeIn(1500);
        $('html, body').animate({ scrollTop: $("#hastaaqui").offset().top - 60 }, 500);
    });
       

       

    $('#uom_boton').click(function () {
        $("body").trigger("click")
    });

    $('#uom_boton').toggle(
   function () {
       $('#barra_sup').animate({ top: "-93" }, 200);
       $('#lightbox').fadeOut(200);
   },
   function () {
       $('#barra_sup').animate({ top: "0" }, 200);
       $('#lightbox').fadeIn(200);
       $('#lightbox').height($('html').height());
   });

</script>
<div id="Modal" class="modal hide fade" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">    
    <h3 id="H2"></h3>
  </div>
  <div class="modal-body">

    <li>¿Desea visualizarlas?</li>
    </ul>
    <p></p>
    <p></p>
    <p></p>

  </div>
  <div class="modal-footer">
    <button onclick="si();" class="btn" data-dismiss="modal" aria-hidden="true">Si</button>    
    <button onclick="javascript:window.close();" class="btn" data-dismiss="modal" aria-hidden="true">No</button>   
  </div>
   </div> 
<script type='text/javascript'>
    $(document).ready(function () {
        IframeHeight();

        window.setInterval(function () {
            Mensajes();
        }, 35700);
		
		window.setInterval(function () {
			UsuarioActivo();
        }, 15000);

        <% if (v.PermisoSM("18")) { %>  
        window.setInterval(function () {
            Pedidos();
        }, 20000);
        <%} %>        
        
    });
    $(window).resize(IframeHeight);

    function IframeHeight() {
        var newHeight = $(window).height() - 40 + "px";
        $('#Pagina').css("height", newHeight);
        $('#Pagina').css("width", $(window).width() - 10 + "px");
    }

    $("#logo_img").click(function () {
       $('#uom_boton').click();
       $('#Pagina').attr('src', 'Principal.aspx');
       $("#DondeEstoy").empty();
       $("#DondeEstoy").html('<strong>Inicio</strong>');
       $('#Pagina').reload();
    });

    $(".barra_dondeestoy").click(function () {
        $('#uom_boton').click();
    });

        var cantidad = $("#cantidad").val();
        if (cantidad > 0) {
                $("#H2").html("Usted tiene Interconsultas Pendientes (" + cantidad + ").");
                $("#Modal").modal('show');

        }

    function si(){
       $('#Pagina').attr('src', "AtInternados/InterconsultaMedico.aspx");
       $('#uom_boton').click();
    }
</script>
<script>
    function AsignarBox() {
        var field;
        while (true) {
            var box = prompt("Ingrese el número de box desde el cual otorgará los turnos").toLowerCase();
            if (!box || /^(1|2|3|4|5|6|7|8|9|10|11|12)$/.test(box)) {
                boxes = "Boxes " + ("1|2|3|4|5|6|7|8|9|10|11|12".split("|").indexOf(box) + 1);

                $.ajax({
                    type: "POST",
                    url: "Json/Turnera/TurneraBonos.asmx/Asignar_Box_Bonos_Turnos",
                    data: '{Box: "' + box + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {
                        alert("Se le ha asignado el Box " + box);
                        Nro_Box = box;
                        $("#span_nro_box").html(box);
                    },
                    error: function () {
                        alert("No se ha podido asignar el box");
                    }
                });

                break;
            } else {
                alert("Ingrese un Box válido");
            }
        }
    }
    </script>

    <asp:Literal ID="lit_java_script" runat="server"></asp:Literal>

</body>
</html>
<div class="NotiBoxContenedor"> 
    <input id="MensajeNumero" type="hidden" />
    <button type="button" class="close" onclick="javascript:CerrarNotiBoxContenedor();">&times;</button>
    <div id="NotiEncabezado" class="NotiBoxHeader"><i class="icon-info-sign icon-white"></i>&nbsp;&nbsp;&nbsp;<span id="NotiEncabezadoMensaje">Un poco de Humor :)</span></div>
    <div class="NotiAutor"><img id="NotiImagen" src="img/silueta.jpg" class="NotiAvatar"></img>&nbsp;por<div class="NotiNombre">Nombre de usuario</div></div>
    <div id="NotiMensaje" class="NotiBoxBody">        

    </div>
</div>


