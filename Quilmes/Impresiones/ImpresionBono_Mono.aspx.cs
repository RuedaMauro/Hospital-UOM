using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Net;

public partial class Impresiones_ImpresionBono_Mono : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                txtId.Text = Request.QueryString["id"].ToString();
                txtFecha.Text = Request.QueryString["Fecha"].ToString();
                ReportViewer1.LocalReport.Refresh();

                Hospital.ImpresionesBLL impre = new Hospital.ImpresionesBLL();
                impresion_bono i = impre.Bono(txtFecha.Text, Convert.ToInt32(txtId.Text));

                ReportParameter[] parameters = new ReportParameter[24];
                parameters[0] = new ReportParameter("Usuario", "" + ((usuarios)Session["Usuario"]).nombre);
                parameters[1] = new ReportParameter("Apellido", i.apellido);
                parameters[2] = new ReportParameter("NroAfiliado", i.documento.ToString());
                string Fecha = i.Fecha;
                if (Fecha == "01/01/1900") Fecha = "Sin Fecha";
                parameters[3] = new ReportParameter("Fecha", Fecha);
                parameters[4] = new ReportParameter("NroBono", i.Bono_Id.ToString());
                parameters[5] = new ReportParameter("FN", i.fecha_nacimiento);
                parameters[6] = new ReportParameter("NHC", i.cuil.ToString());




                string Turno = NroTurnoToLetters(i.Nro);
                if (Turno.Length > 1)
                {
                    Turno = " - " + Turno;
                }
                else
                    Turno = "";


                //parameters[7] = new ReportParameter("Policlinico", i.Centro);
                parameters[7] = new ReportParameter("Policlinico", i.Razon_Social);

                parameters[8] = new ReportParameter("Medico", i.Medico);
                parameters[9] = new ReportParameter("Especialidad", i.Especialidad);

                parameters[10] = new ReportParameter("Documento", i.documento_real.ToString());



                if (i.Seccional.ToUpper() == ("Obra Social").ToUpper())
                {
                    parameters[11] = new ReportParameter("Seccional", "<b>Ob. Social:</b> " + i.OS);
                }
                else
                {
                    parameters[11] = new ReportParameter("Seccional", "<b>Seccional: </b><span style='font-size: 10px;'>" + i.Seccional + "</span>");
                }


                parameters[12] = new ReportParameter("TurnoAhora", Turno);

                try
                {
                    parameters[13] = new ReportParameter("Autorizado", "<b>Autorizado por: </b>" + i.Autorizantes);
                }
                catch
                {
                    parameters[13] = new ReportParameter("Autorizado", "");
                }

                try
                {
                    parameters[14] = new ReportParameter("BonoPorUsuarios", i.BonoporUsuario.ToString());
                }
                catch
                {
                    parameters[14] = new ReportParameter("BonoPorUsuarios", "0");
                }

                string codigo = i.Bono_Id.ToString().PadLeft(8, '0');
                string RutaCodigo = "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + string.Format(@"/fonts/code.ashx?code={0}&format={1}" + "&width=350&height=30&size=60", codigo, "0");

                parameters[15] = new ReportParameter("ImgBono", RutaCodigo);
                parameters[16] = new ReportParameter("Bono_Numero_Total", i.Bono_Id.ToString().PadLeft(8, '0'));
                //parameters[17] = new ReportParameter("PC", GetComputerName(Request.UserHostAddress));
                parameters[17] = new ReportParameter("Atendido", i.Nombre_Usuario);
                parameters[18] = new ReportParameter("Tipo", i.Tipo.ToString());
                parameters[19] = new ReportParameter("Imagen", "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/img/logoprint.jpg");
                parameters[20] = new ReportParameter("PacienteImg", "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/img/pacientes" + i.Foto);
                //parameters[21] = new ReportParameter("SiluetaImg", "http://" + Request.Url.Host + ":" + Request.Url.Port + HttpContext.Current.Request.ApplicationPath + "/img/pacientes/" + i.cuil.ToString() + ".jpg");
                parameters[21] = new ReportParameter("RazonSocial", i.Centro);

                string Cancelado = "";
                if (i.Cancelado) Cancelado = "ANULADO";

                parameters[22] = new ReportParameter("Cancelado", Cancelado);
                parameters[23] = new ReportParameter("Patologia", i.PatologiaDesc);
                ReportViewer1.LocalReport.EnableExternalImages = true;

                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.LocalReport.Refresh();

            }
        }
    }

    public void pdf_Click()
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
        HttpContext.Current.Response.AddHeader("content-disposition", ("inline; filename=BonoMono." + "PDF"));
        HttpContext.Current.Response.BinaryWrite(byteArray);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }


    public string NroTurnoToLetters(int Nro)
    {
        string result = string.Empty;
        if (Nro > 0)
            result = string.Format("{0}{1:D2}", GetLetterFromNumber(Nro / 100), (Nro % 100));
        return result;
    }

    private string GetLetterFromNumber(int columnNumber)
    {
        string columnName = Convert.ToChar(65 + columnNumber).ToString();
        return columnName;
    }

    public string GetComputerName(string clientIP)
    {
        try
        {
            var hostEntry = Dns.GetHostEntry(clientIP);
            return hostEntry.HostName;
        }
        catch
        {
            return string.Empty;
        }
    }
}