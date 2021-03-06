<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enfermeria_Entregar.aspx.cs" Inherits="AtConsultorio_Enfermeria_Entregar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/barra.css" />
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <div class="clearfix">
    </div>
    <script>
        parent.document.getElementById("DondeEstoy").innerHTML = "Consultorio > <strong>Pedidos a Enfermería</strong>";
    </script>
    <form id="form1" runat="server" class="form-horizontal">
    <div class="container" style="padding-top: 30px; height: 1496px;">
        <div class="contenedor_1">
            <div class="contenedor_3" style="height:500px;">
                <div class="titulo_seccion" style="margin-top: 5px;">
                    <span>Pedidos a Enfermería</span>
                </div>
                <div class="minicontenedor100">
                    <span>Consultorio: </span> <select id="cbo_Consultorio"></select><span style="margin-left:20px;">Médico: </span><select id="cbo_Medico"></select>
                </div>
                <div style="margin-left: 10px; margin-top:10px;">
                    <div id="btn_Todos" class="reff">
                        Todos</div>
                    <div id="btn_Entregados" class="reff ref_1" style="background-color:#58FA58;">
                        Entregados</div>
                    <div id="btn_Pendientes" class="reff ref_4" style="background-color:#F4FA58;">
                        Pendientes</div>
                </div>
                <div id="Resultado" class="tabla" style="height: 320px; width: 98%; margin-left: 1%">
                    <table id="TablaPedidos" class="table table-bordered table-bordered">
                        <thead>
                            <tr>
                                <th>
                                    Estado
                                </th>
                                <th>
                                    Fecha
                                </th>
                                <th>
                                    Médico
                                </th>
                                <th>
                                    Consultorio
                                </th>
                                <th>
                                    Pedido
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="pie_gris">

                </div>
            </div>
        </div>
    </div>
       
    </form>
</body>
</html>
<script src="../js/jquery-1.8.3.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/bootstrap.js"></script>
<script src="../js/GeneralG.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script src="../js/ui-datepicker-es.js" type="text/javascript"></script>
<script src="../js/Hospitales/AtConsultorio/EntregaEnfermeria.js" type="text/javascript"></script>

