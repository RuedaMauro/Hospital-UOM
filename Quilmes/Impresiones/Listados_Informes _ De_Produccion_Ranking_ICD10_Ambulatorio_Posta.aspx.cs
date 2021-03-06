using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Web.Configuration;

public partial class Impresiones_Listado_Ranking_ICD10_Posta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         Session.Timeout = 10;
        //Server.ScriptTimeout = 10;
        if (!IsPostBack)
        {
            Hospital.CentroBLL Centro = new Hospital.CentroBLL();
            centro C = Centro.elCentro();

            ReportParameter[] parameters = new ReportParameter[5];
            parameters[0] = new ReportParameter("imagen", "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/img/logoprint.jpg");
            parameters[1] = new ReportParameter("Usuario", "Impreso Por: " + ((usuarios)Session["Usuario"]).nombre + ". Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            parameters[2] = new ReportParameter("Rotulo", "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/img/Rotulo.jpg");
            parameters[3] = new ReportParameter("PDF", Request.QueryString["PDF"]);
            parameters[4] = new ReportParameter("TodosMenorMayor", Request.QueryString["TodosMenorMayor"]);

            //ReportViewer1.ServerReport.Timeout = 900000;
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.SetParameters(parameters);
            ReportViewer1.LocalReport.Refresh();
        }
    }


    public void pdf()
    {
        //ReportViewer1.LocalReport.ReportPath = "Impresion/ConfirmacionTurnos.rdlc";

        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;
        //Session.Timeout = 10;
        byte[] byteArray = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);

        
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = mimeType;
        HttpContext.Current.Response.AddHeader("content-disposition", ("inline; filename=GuardiaAtencion." + "PDF"));
        HttpContext.Current.Response.BinaryWrite(byteArray);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
       
    }

}
