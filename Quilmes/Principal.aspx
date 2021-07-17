<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/barra.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="js/JPantalla.js" type="text/javascript"></script>



    <title></title>

<style>

.btn-novedades {
	-moz-box-shadow:inset 0px 1px 0px 0px #bbdaf7;
	-webkit-box-shadow:inset 0px 1px 0px 0px #bbdaf7;
	box-shadow:inset 0px 1px 0px 0px #bbdaf7;
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #79bbff), color-stop(1, #378de5) );
	background:-moz-linear-gradient( center top, #79bbff 5%, #378de5 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#79bbff', endColorstr='#378de5');
	background-color:#79bbff;
	-moz-border-radius:6px;
	-webkit-border-radius:6px;
	border-radius:6px;
	border:1px solid #84bbf3;
	display:inline-block;
	color:#ffffff;
	font-family:arial;
	font-size:15px;
	font-weight:bold;
	padding:6px 24px;
	text-decoration:none;
	text-shadow:1px 1px 0px #528ecc; 
}.btn-novedades:hover {
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #378de5), color-stop(1, #79bbff) );
	background:-moz-linear-gradient( center top, #378de5 5%, #79bbff 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#378de5', endColorstr='#79bbff');
	background-color:#378de5;
}.btn-novedades:active {
	position:relative;
	top:1px;
}


body{font-family:Verdana, Geneva, sans-serif}
</style>
</head>
<body>
    <div>
        <div id="Novedades" class="DivNovedades" style="height:600px; overflow-x:hidden; overflow-y:auto; padding-top: 100px; position: relative">
          <div style="width:800px;margin-left:auto;margin-right:auto">

          <div style="position: relative; top: 200px;left: 330px;">
          <a href="#TituloLasNovedades" style="display:none;" class="btn-novedades">Ver Novedades</a>
          </div>
			
            <img src="img/Novedades/logoGris.jpg"/>
            <div class="TituloNov"><asp:Literal ID="LSeccional" runat="server"></asp:Literal></div>
            <div class="BienvenidoUsuario"><asp:Literal ID="LUsuario" runat="server"></asp:Literal></div>
              
            <asp:Literal ID="lscript" runat="server"></asp:Literal>

            <div class="box_gris_novedades" style="position:absolute; left:20px; top:10px;">
<%--            <img src="img/Novedades/ico_telefono.jpg"/>--%>
            <div style="color:#696969">
            <b>Sistema GesinMed: 229/349</b> <br />
                <div style="font-size:12px;">
                    Horario de atención <br />
                    Lunes a viernes de 9-20hs
                </div>
            <span style="text-align:left; display:inline-block;">
            Soporte Técnico e Insumos (Toners, Impresores, Internet y otros): 262 <br />
            Sistema AxyonCare: 292 <br />
            Imágenes (Visual Medica): 214 / 216 <br />
            <br />
            </span>    
            <a class="btn btn-primary" href="Internos/Internos Telefónicos.htm" ><i class="icon-white icon-bullhorn
"></i> Ver Internos</a>
            </div>
            </div>

            <div class="TituloLasNovedades" id="TituloLasNovedades">Versiones y Cambios</div>
            <asp:Literal ID="LNovedades" runat="server"></asp:Literal>
            <span id="Nombre" runat="server" style="display:none;"></span>

            <br /><br /><br /><br />

        </div></div>
    </div>

    <script>
        $("#Nombre").html(Nombre_Usuario);
    </script>

</body>
</html>

