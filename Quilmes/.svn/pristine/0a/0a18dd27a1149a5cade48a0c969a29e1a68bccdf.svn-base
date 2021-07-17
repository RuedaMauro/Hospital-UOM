using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

/// <summary>
/// Summary description for HistoriaClinica
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]
public class HistoriaClinica : System.Web.Services.WebService {

    public HistoriaClinica () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<lista_anios> Internaciones_Anios(long nhc)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Internaciones_Anios(nhc);
        }
        else
        {
            return null;
        }
        
    }


    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<hc_imagenes> Imagenes_Datos(string nhc, string anio, string PacienteId)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Imagenes_Datos(nhc, anio, PacienteId);
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<hc_anatomiapatologica> AnatomiaPatologica_Datos(string nhc, string anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.AnatomiaPatologica_Datos(nhc, anio);
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<labo_protocolos> Labo_Datos(string nhc, string anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Labo_Protocolos_by_Anio(nhc, anio);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<interconsulta> Interconsultas_Datos(string nhc, string anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Interconsultas_Datos(nhc, anio);
        }
        else return null;
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<lista_anios> Cirugias_Anios(long nhc)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Cirugias_Anios(nhc);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<lista_anios> Guardia_Anios(long nhc)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Guardia_Anios(nhc);
        }
        else
        {
            return null;
        }

    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<lista_anios> Ambulatorio_Anio(long nhc)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Ambulatorio_Anios(nhc);
        }
        else
        {
            return null;
        }

    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<lista_meses> Ambulatorio_Mes(long nhc, int anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Ambulatorio_Meses(nhc, anio);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<registro_internacion> Internacion_Datos(long nhc, int anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Internacion_Datos(nhc, anio);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<registro_cirugias> Cirugia_Datos(long nhc, int anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Cirugia_Datos(nhc, anio);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<registro_recetas> Recetas_Datos(long nhc, int anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Recetas_Datos(nhc, anio);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<registro_recetas> Guardia_Datos(long nhc, int anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Guardia_Datos(nhc, anio);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<registro_ambulatorio> Ambulatorio_Datos(long nhc, int anio, int mes)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Ambulatorio_Datos(nhc, anio, mes);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<HC_Compacta> Historia_Clinica_Compacta(long nhc)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Historia_Clinica_Compacta(nhc);
        }
        else
        {
            return null;
        }

    }

    [WebMethod(EnableSession = true)]
    public void HC_Movimiento_Insert(HC_Movimiento h)
    {
        if (Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL Hbll = new Hospital.HistoriaClinicaBLL();
            Hbll.HC_Movimiento_Insert(h);
        }
    }

    [WebMethod(EnableSession = true)]
    public void HC_Movimiento_Delete(long Id)
    {
        if (Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL Hbll = new Hospital.HistoriaClinicaBLL();
            Hbll.HC_Movimiento_Delete(Id, ((usuarios)Session["Usuario"]).id);
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<HC_Movimiento> HC_Movimiento_Listar(long NHC)
    {
        if (Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL Hbll = new Hospital.HistoriaClinicaBLL();
            return Hbll.HC_Movimiento_Listar(NHC);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<IM_Buscar> BuscarIM_by_Internacion(string IdInt)
    {
        if (Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL Hbll = new Hospital.HistoriaClinicaBLL();
            return Hbll.BuscarIM_by_Internacion(IdInt);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    public long MedicoporUsuario()
    {
        if (Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL Hbll = new Hospital.HistoriaClinicaBLL();
            return Hbll.MedicoporUsuario(((usuarios)Session["Usuario"]).id);
        }
        else return -1;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<lista_anios> Endoscopias_Anios(long nhc)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Endoscopia_Anios(nhc);
        }
        else
        {
            return null;
        }

    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<registro_cirugias> Endoscopia_Datos(long nhc, int anio)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.HistoriaClinicaBLL H = new Hospital.HistoriaClinicaBLL();
            return H.Endoscopia_Datos(nhc, anio);
        }
        else
        {
            return null;
        }

    }
}
