using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hospital;

public partial class HistoriaClinica_HistoriaClinica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            long NHC = Convert.ToInt64(Request.QueryString["NHC"]);
            Fecha_Hora.Value = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm");
            pacientes Paciente = null;
            try
            {
                //NHC = ID ???????????????
                Hospital.PacientesBLL P = new PacientesBLL();
                Paciente = P.Paciente_ID(NHC)[0];
            }
            catch
            {
                Paciente = null;
            }

            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            List<lista_anios> Anios = H.Ambulatorio_Anios(NHC);
            foreach (lista_anios anio in Anios)
            {
                UlAmbulatorio.Text = UlAmbulatorio.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",3);'>" + anio.anio + "</a>";

                List<lista_meses> Meses = H.Ambulatorio_Meses(NHC, Convert.ToInt32(anio.anio));
                foreach (lista_meses mes in Meses)
                {
                    UlAmbulatorio.Text = UlAmbulatorio.Text + "<ul><li><a onclick='javascript:CargarAnioyMes(" + anio.anio + "," + mes.mes + ",3);'>" + Nombredelmes(Convert.ToInt32(mes.mes)) + "</a></li></ul>";
                }
                UlAmbulatorio.Text = UlAmbulatorio.Text + "</li>";
            }

            Anios = H.Cirugias_Anios(NHC);
            foreach (lista_anios anio in Anios)
            {
                CirugiasAnios.Text = CirugiasAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",2);'>" + anio.anio + "</a></li>";
            }

            Anios = H.Internaciones_Anios(NHC);
            foreach (lista_anios anio in Anios)
            {
                InternacionAnios.Text = InternacionAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",1);'>" + anio.anio + "</a></li>";
            }

            //Recetas
            Anios = H.Recetas_Anios(NHC);
            foreach (lista_anios anio in Anios)
            {
                RecetasAnios.Text = RecetasAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",4);'>" + anio.anio + "</a></li>";
            }
            //Guardia
            Anios = H.Guardia_Anios(NHC);
            foreach (lista_anios anio in Anios)
            {
                UlGuardia.Text = UlGuardia.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",5);'>" + anio.anio + "</a></li>";
            }
            //Labo
            PacientesBLL pbll = new PacientesBLL();
            Anios = H.Labo_Anios(pbll.Paciente_ID(NHC)[0].documento.ToString());
            foreach (lista_anios anio in Anios)
            {
                LaboratorioAnios.Text = LaboratorioAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",6);'>" + anio.anio + "</a></li>";
            }
            Anios = H.Interconsultas_Anios(NHC.ToString());
            foreach (lista_anios anio in Anios)
            {
                InterconsultaAnios.Text = InterconsultaAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",7);'>" + anio.anio + "</a></li>";
            }

            //IMAGENES Y ANATOMIA PATOLOGICA
            //SE CONECTA AL SERVIDOR 10.10.8.65
            //SE UTILIZAN LAS TABLAS IMG_TIP_PROTOCOLO (LAS PLANTILLAS)
            //IMG_TIP_IMAGEN (TIPO DE ESTUDIOS)
            //IMG_ESTUDIO (ESTAN LOS ESTUDIOS REALIZADOS A MOSTRAR EN FORMATO DOC)

            if (Paciente.Soc_Id == null)
            {
                Paciente.Soc_Id = "";
            }

            //if (Paciente.Soc_Id != null)
            //{
                Anios = H.Imagenes_Anios(Paciente.Soc_Id.ToString(), pbll.Paciente_ID(NHC)[0].documento.ToString());
                foreach (lista_anios anio in Anios)
                {
                    ImagenesAnios.Text = ImagenesAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",8);'>" + anio.anio + "</a></li>";
                }
            //}


               // if (Paciente.Soc_Id != null && Paciente.documento.Soc_Id != "")
                if (Paciente.documento.ToString() != null && Paciente.documento.ToString() != "")
            {
                //Anios = H.AnatomiaPatologica_Anios(Paciente.Soc_Id.ToString());
                Anios = H.AnatomiaPatologica_Anios(Paciente.documento.ToString());
                foreach (lista_anios anio in Anios)
                {
                    AnatomiaPatologicaAnios.Text = AnatomiaPatologicaAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",9);'>" + anio.anio + "</a></li>";
                }
            }


            Anios = H.Endoscopia_Anios(NHC);
            foreach (lista_anios anio in Anios)
            {
                EndoscopiaAnios.Text = EndoscopiaAnios.Text + "<li><a onclick='javascript:CargarAnio(" + anio.anio + ",10);'>" + anio.anio + "</a></li>";
            }


        }
    }

    private string Nombredelmes(int intMes)
    {
        string[] Mes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        return Mes[intMes - 1];
    }
}