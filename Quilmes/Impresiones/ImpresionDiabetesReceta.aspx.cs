﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Web.Configuration;


public partial class Impresiones_ImpresionDiabetesReceta : System.Web.UI.Page
{

    public bool Existe = true;
   
    protected void Page_Load(object sender, EventArgs e)
    {

        Hospital.CentroBLL Centro = new Hospital.CentroBLL();
        centro C = Centro.elCentro();

        ReportParameter[] parameters = new ReportParameter[1];
        parameters[0] = new ReportParameter("imagen", "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/img/logoprint.jpg");

        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.LocalReport.SetParameters(parameters);
        ReportViewer1.LocalReport.Refresh();
        //ReportViewer1.PrinterSettings();

    }

    public void pdf()
    {
        //ReportViewer1.LocalReport.ReportPath = "Impresion/ConfirmacionTurnos.rdlc";

        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;

        byte[] byteArray = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);

        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = mimeType;
        HttpContext.Current.Response.AddHeader("content-disposition", ("inline; filename=DiabetesImprimir." + "PDF"));
        HttpContext.Current.Response.BinaryWrite(byteArray);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

   
}