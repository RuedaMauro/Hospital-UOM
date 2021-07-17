using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Hospital;

public partial class Impresiones_Impresion_Consumo_by_Insumo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int rubroid;
            if (!int.TryParse(Request.QueryString["RubroId"].ToString(), out rubroid)) throw new Exception("Rubro incorrecto.");
            FarmaciaBLL f = new FarmaciaBLL();
            
            ReportParameter[] parameters = new ReportParameter[6];
            parameters[2] = new ReportParameter("Usuario", "" + ((usuarios)Session["Usuario"]).nombre);
            parameters[3] = new ReportParameter("Imagen", "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/img/logoprint.jpg");
            parameters[0] = new ReportParameter("Desde", Request.QueryString["Desde"]);
            parameters[1] = new ReportParameter("Hasta", Request.QueryString["Hasta"]);
            parameters[4] = new ReportParameter("Rubro", f.ListRubrobyId(rubroid)[0].Rubro);
            parameters[5] = new ReportParameter("Servicio",GetServicio(Request.QueryString["IdServicio"]));
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.SetParameters(parameters);
            ReportViewer1.LocalReport.Refresh();
        }
    }

    private string GetServicio(string IdServicio)
    {
        if (!string.IsNullOrEmpty(IdServicio))
        {
            int ServId = int.Parse(IdServicio);
            if (ServId == 0) return "Todos";
            ServicioBLL s = new ServicioBLL();
            return s.Servicio_Lista(ServId, string.Empty)[0].descripcion;
        }
        return string.Empty;
    }

    public void Crearpdf()
    {
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;
        byte[] byteArray = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = mimeType;
        HttpContext.Current.Response.AddHeader("content-disposition", ("inline; filename=ConsumobyInsumo." + "PDF"));
        HttpContext.Current.Response.BinaryWrite(byteArray);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
}