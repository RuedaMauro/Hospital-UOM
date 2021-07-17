﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Hospital;

/// <summary>
/// Summary description for Quirofano_
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Quirofano_ : System.Web.Services.WebService {

    public Quirofano_ () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano_Diagnostico> Diagnostico(string Id, bool estado)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Diagnostico(int.Parse(Id), estado);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano_Diagnostico> Diagnostico_Planificar_Cirugia(string Id, bool estado, int Cirugia_id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.DiagnosticoDiagnostico_Planificar_Cirugia(int.Parse(Id), estado, Cirugia_id);
        }
        else return null;
    }

    [WebMethod]
    [ScriptMethod]
    public List<Quirofano_Diagnostico> Diagnostico_Planificar_Cirugia_Combo(string Id, bool estado, int Cirugia_id, string Diagnostico)
    {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.DiagnosticoDiagnostico_Planificar_Cirugia_Combo(int.Parse(Id), estado, Cirugia_id, Diagnostico);
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano_Cirugia> Cirugia_Planificar_Cirugia(string Id, bool estado, int Cirugia_id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Cirugias_Planificar_Cirugia(int.Parse(Id), estado, Cirugia_id);
        }
        else return null;
    }

    [WebMethod]
    [ScriptMethod]
    public List<Quirofano_Cirugia> Cirugia_Planificar_Cirugia_Combo(string Id, bool estado, int Cirugia_id, string Cirugia)
    {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Cirugias_Planificar_Cirugia_Combo(int.Parse(Id), estado, Cirugia_id, Cirugia);
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void H2_QUIROFANO_PARTE_ANESTESIA_GUARDAR(int Cirugia_id, string Peso, string Premeditacion, int Induccion, string Sangre, string Plasma, string Suero, string Otro, string HALLAZGOS_FISICOS_ANORMALES, string AGENTES_ANESTESICOS, string METODOS_ANESTESICOS, string RECUPERACION, string OBSERVACIONES )
    public void H2_QUIROFANO_PARTE_ANESTESIA_GUARDAR(Parte_Anestesia pa, int Cirugia_Id, List<Post_csv> signos_vitales, List<Post_Monitoreo> monitoreo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();

            //Parte_Anestesia pa = new Parte_Anestesia();
            //pa.Peso = Peso;
            //pa.Premeditacion = Premeditacion;
            //pa.Induccion = Induccion;
            //pa.Sangre = Sangre;
            //pa.Plasma = Plasma;
            //pa.Suero = Suero;
            //pa.Otro = Otro;
            //pa.HALLAZGOS_FISICOS_ANORMALES = HALLAZGOS_FISICOS_ANORMALES;
            //pa.AGENTES_ANESTESICOS = AGENTES_ANESTESICOS;
            //pa.METODOS_ANESTESICOS = METODOS_ANESTESICOS;
            //pa.RECUPERACION = RECUPERACION;
            //pa.OBSERVACIONES = OBSERVACIONES;

            q.H2_QUIROFANO_PARTE_ANESTESIA_GUARDAR(Cirugia_Id, pa, Convert.ToInt32(((usuarios)Session["Usuario"]).id), signos_vitales, monitoreo);
        }        
    }

    


    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Guardar_Diagnostico_PlanificarCirugia(int Id, string Diagnostico)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            q.Guardar_Diagnostico_PlanificarCirugia(Id, Diagnostico);
        }        
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Eliminar_Diagnostico_PlanificarCirugia(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            q.Eliminar_Diagnostico_PlanificarCirugia(Id);
        }
    }
    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Eliminar_Cirugia_PlanificarCirugia(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            q.Eliminar_Cirugia_PlanificarCirugia(Id);
        }
    }
    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano_Diagnostico> Diagnostico_Planificar_Cirugia_Todas(string Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.DiagnosticoDiagnostico_Planificar_Cirugia_Todas(int.Parse(Id));
        }
        else return null;
    }
    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano_Diagnostico> Diagnostico_Post(string Id, bool estado)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Diagnostico_Post(int.Parse(Id), estado);
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<medicos> List_Medicos_Quirofano(string Activo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Lista_Medicos_TODOS(Activo);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<medicos> List_Medicos_QuirofanobyEsp(string Activo, string Especialidad)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Lista_Medicos_byEsp(Activo, int.Parse(Especialidad));
        }
        else return null;
    }

    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<medicos_quirofano_x_especialidad> Listar_Medico_x_Especialidad(string Especialidad, int Medico_Predeterminado)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Listar_Medico_x_Especialidad(int.Parse(Especialidad), Medico_Predeterminado);
        }
        else return null;
    }

    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Anestesia> ListaAnestesia(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Anestesia_Lista(Id);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public  List<Cirugia_Tipo> ListaCirugia(string Id, bool estado, int Cirugia_id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Cirugia_Tipo(int.Parse(Id), estado, Cirugia_id);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int GuardarCirugia(Quirofano qobj)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.QuirofanoTurno_Guardar(qobj,((usuarios)Session["Usuario"]).id);
        }
        else return -1;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano_Listado> ListaCirugias(int Id, string Fecha, bool Baja, int Turno, int cuales)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Quirofano_Turno_Lista(Id, Fecha, Baja, Turno, cuales);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Quirofano_turnos_totales ListaCirugias_Totales(int Id, string Fecha, bool Baja, int Turno, int cuales)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Quirofano_Turno_Lista_cantidad(Id, Fecha, Baja, Turno, 0);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano> ListaCirugias_Id(int Id, string Fecha, bool Baja)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Quirofano_CirugiaList(Id, Fecha, Baja);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<MotivoSusp> ListMotivo()
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Motivo_Susp_Lista(0);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int SuspenderCirugia(int Id, int Motivo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                q.Suspender_Cirugia(Id, Motivo, ((usuarios)Session["Usuario"]).id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        else return -1;
    }


        
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int ReanudarCirugia(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                q.Reanudar_Cirugia(Id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        else return -1;
    }


    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int BorrarCirugia(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                q.Borrar_Cirugia(Id, ((usuarios)Session["Usuario"]).id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        else return -1;
    }

    //[WebMethod(EnableSession = true)]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void DeleteInsumosPreQuirurgicos(int Id)
    //{
    //    if (HttpContext.Current.Session["Usuario"] != null)
    //    {
    //        try
    //        {
    //            QuirofanoBLL q = new QuirofanoBLL();
    //            q.Delete_Quirofano_InsumosbyIdOperacion(Id, );
    //        }
    //        catch
    //        {
                
    //        }
    //    }
    //}

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeleteInsumosQuirurgicos(long Cirugia_Id, int Tipo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                q.Delete_Quirofano_InsumosbyIdOperacion(Cirugia_Id, Tipo);
            }
            catch
            {

            }
        }
    }

    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]    
    public void InsertInsumosPreQuirurgicos(int Id, List<Insumo_Pre> Insumos)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                foreach (Insumo_Pre insu in Insumos)
                {
                    q.Insert_Insumos_Quirofano(Id, insu.Insumo_Id, insu.Cantidad, insu.Observacion, insu.Monodroga, insu.Tipo);
                }                
            }
            catch
            {

            }
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertInsumosQuirurgicos(long Cirugia_Id, List<Qurifano_Insumo> Insumos, int Tipo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                foreach (Qurifano_Insumo insu in Insumos)
                {
                    if (insu != null)
                    {
                        q.Insert_Insumos_Quirofano(Cirugia_Id, insu.Insumo_Id, insu.Cantidad, "", 0, Tipo);
                    }
                }
            }
            catch
            {

            }
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertPreQuirurgicos_Plantilla(int Id, int IdInsumo, int Cantidad, int Tipo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                int Cod_Quirofano = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("MesesTurnos"));
                q.Insert_Plantilla_Servicios(1, IdInsumo, Cod_Quirofano, Cantidad, Tipo);
            }
            catch
            {

            }
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DeletePreQuirurgicos_Plantilla()
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                q.BorrarPlantillaInsumos();
            }
            catch
            {

            }
        }
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo> ListInsumosPlantilla(int IdRubro, int Plantilla)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                return q.Select_Plantilla_by_Rubro(IdRubro, Plantilla);
            }
            catch
            {
                return null;
            }
        }
        else return null;
    }

    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo> ListInsumosPlantilla_cargada(int Planilla)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                return q.Select_Plantilla_by_Rubro_Cargado(Planilla);
            }
            catch
            {
                return null;
            }
        }
        else return null;
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo> ListInsumosPlantilla_cargada_POS(int Planilla)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                return q.Select_Plantilla_by_Rubro_Cargado_pos(Planilla);
            }
            catch
            {
                return null;
            }
        }
        else return null;
    }

    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo> ListInsumosbyCirugiaId(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                List<Insumo> list = new List<Insumo>();
                list = q.Select_Insumos_Quirofano_by_IdOperacion(Id);
                if (list.Count > 0) return list;
                else return q.Select_Plantilla_by_Rubro(0, 1);
            }
            catch
            {
                return null;
            }
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int UpdateTurnoCirugia(Quirofano qobj)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            qobj.usuario_id_modificacion = ((usuarios)Session["Usuario"]).id;
            q.Quirofano_Turnos_Update(qobj);
            return 1;
        }
        else return -1;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Quirofano_PreAnes_Enc> ListPreAnes_Enc(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.ListPreAnes_Enc(Id);
        }
        else return null;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int Guardar_Pre_Anestesico(PreQuirurgico p, int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            long Usuario = ((usuarios)Session["Usuario"]).id;
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Guardar_Pre_Anestesico(p, Id, (int)Usuario);
        }
        else return -1;
    }
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int Quirofano_ControlSignosVitales_Guardar(List<Quirofano_ControlSignosVitales> q)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL qbll = new QuirofanoBLL();
            foreach (Quirofano_ControlSignosVitales qq in q)
            {
                qbll.Quirofano_ControlSignosVitales_Guardar(qq);
            }
            
            return 1;
        }
        else return -1;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int Quirofano_RecPosAnestesia_Guardar(Quirofano_RecPosAnestesia q)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL qbll = new QuirofanoBLL();
            qbll.Quirofano_RecPosAnestesia_Guardar(q);
            return 1;
        }
        else return -1;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int Quirofano_ControlSignosVitales_Delete(Quirofano_ControlSignosVitales q)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL qbll = new QuirofanoBLL();
            qbll.Quirofano_ControlSignosVitales_Delete(q);
            return 1;
        }
        else return -1;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int Quirofano_RecPosAnestesia_Delete(Quirofano_RecPosAnestesia q)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL qbll = new QuirofanoBLL();
            qbll.Quirofano_RecPosAnestesia_Delete(q);
            return 1;
        }
        else return -1;
    }

     [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Quirofano_RecPosAnestesia Quirofano_RecPosAnestesia_ListById(int Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL qbll = new QuirofanoBLL();
            return qbll.Quirofano_RecPosAnestesia_ListById(Id);
        }
        else return null;
    }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public List<Quirofano_ControlSignosVitales> Quirofano_ControlSignosVitales_ListbyCirugiaId(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             return qbll.Quirofano_ControlSignosVitales_ListbyCirugiaId(Id);
         }
         else return null;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public List<DiagnosticoICD10> ListDiagnosticoICD10()
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             return qbll.ListDiagnosticoICD10();
         }
         else return null;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public int Quirofano_Protocolos_Guardar(Quirofano_Protocolos q)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             qbll.Quirofano_Protocolos_Guardar(q, (int)((usuarios)HttpContext.Current.Session["Usuario"]).id);
             return 1;
         }
         else return -1;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public int Quirofano_Protocolos_Borrar(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             qbll.Quirofano_Protocolos_Borrar(Id);
             return 1;
         }
         else return -1;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public Quirofano_Protocolos ListProtocolo_ByCirugiaId(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             return qbll.ListByCirugiaId(Id);
         }
         else return null;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public int Resolucion28_Guardar(Resolucion28 c)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             qbll.Resolucion28_Guardar(c);
             return 1;
         }
         else return -1;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public Resolucion28 CargarResolucion(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             return qbll.CargarResolucion(Id);
         }
         else return null;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public int Borrar_ProtesisyOtros(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             qbll.Borrar_Protesis_Det(Id);
             return 1;
         }
         else return -1;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public int Guardar_Protesis_Cab(Quirofano_Protesis_Cab p)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             p.usuario = ((usuarios)Session["Usuario"]).id;
             qbll.Guardar_Protesis_Cab(p);
             return 1;
         }
         else return -1;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public int Guardar_Protesis_Det(List<QuirofanoProtesis> p)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();             
             foreach (QuirofanoProtesis qp in p)
             {
                 qp.usuario = ((usuarios)Session["Usuario"]).id;
                 qbll.Guardar_Protesis_y_Otros(qp);   
             }             
             return 1;
         }
         else return -1;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public int UpdateCargaInsumosOtros(int Id, string Otros)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             qbll.UpdateCargaInsumosOtros(Id, Otros);
             return Id;
         }
         else return -1;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public List<Quirofano_Protesis_Cab> Protesis_CAB(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             return qbll.Protesis_Lista_CAB(Id);
         }
         else return null;
     }

     [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public List<QuirofanoProtesis> Protesis_Lista_Det(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             return qbll.Protesis_Lista_Det(Id);
         }
         else return null;
     }


     
    [WebMethod(EnableSession = true)]
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
     public PreQuirurgico Cargar_Preanestesico(int Id)
     {
         if (HttpContext.Current.Session["Usuario"] != null)
         {
             QuirofanoBLL qbll = new QuirofanoBLL();
             return qbll.Cargar_Pre_Anestesico(Id);
         }
         else return null;
     }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Sala_y_Cama Cargar_Sala_y_Cama(int Quirofano_ID)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL qbll = new QuirofanoBLL();
            return qbll.Cargar_Sala_y_Cama(Quirofano_ID);
        }
        else return null;
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Guardar_Cirugia_PlanificarCirugia(int Id, string Cirugia)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            q.Guardar_Cirugia_PlanificarCirugia(Id, Cirugia);
        }
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo_PRE_Anestesia_Listado> Listar_Insumos_PreAnestesia(long CirugiaID)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Listar_Insumos_PreAnestesia(CirugiaID);
        }
        else
            return null;
    }

    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsumoProtesis_AM_Insumos_Guardar(long Insumo_ID, string Descripcion)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            q.InsumoProtesis_AM_Insumos_Guardar(Insumo_ID, Descripcion);
        }        
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo_y_Protesis_Insumo> InsumoProtesis_Insumos_Listar(long Insumo_ID)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.InsumoProtesis_Insumos_Listar(Insumo_ID);
        }
        return null;
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Protocolo_Cirugia_Info Protocolos_Cirugia_Info(long CirugiaId)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.Protocolos_Cirugia_Info(CirugiaId);
        }
        return null;
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo> Cargar_Plantilla_Cargado(long Cirugia_id, int Tipo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                return q.Cargar_Plantilla_Cargado(Cirugia_id, Tipo);
            }
            catch
            {
                return null;
            }
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Insumo> H2_QUIROFANO_LISTAR_INSUMOS(string Insumo)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            try
            {
                QuirofanoBLL q = new QuirofanoBLL();
                return q.H2_QUIROFANO_LISTAR_INSUMOS(Insumo);
            }
            catch
            {
                return null;
            }
        }
        else return null;
    }


     
    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Parte_Anestesia> H2_QUIROFANO_PARTE_ANESTESIA_CARGAR(long Cirugia_Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.H2_QUIROFANO_PARTE_ANESTESIA_CARGAR(Cirugia_Id);
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void H2_QUIROFANO_POST_GUARDAR(Post_Gral cg, List<Post_csv> csv, List<Post_Monitoreo> pm)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            q.H2_QUIROFANO_POST_GUARDAR(cg, csv, pm);
        }        
    }





    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Post_Gral H2_QUIROFANO_POST_CABECERA_CARGAR(long Cirugia_Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.H2_QUIROFANO_POST_CARGAR(Cirugia_Id);
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Post_csv> H2_QUIROFANO_POST_SIGNOS_VITALES_CARGAR(long Cirugia_Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.H2_QUIROFANO_POST_SIGNOS_VITALES_CARGAR(Cirugia_Id);
        }
        else return null;
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Post_csv> H2_QUIROFANO_PARTE_ANESTESIA_CONTROL_SIGNOS_VITALES_CARGAR(long Cirugia_Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.H2_QUIROFANO_PARTE_ANESTESIA_CONTROL_SIGNOS_VITALES_CARGAR(Cirugia_Id);
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Post_Monitoreo> H2_QUIROFANO_POST_CABECERA_DETALLE_MONITOREO_CARGAR(long Cirugia_Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.H2_QUIROFANO_POST_MONITOREO_CARGAR(Cirugia_Id);
        }
        else return null;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Post_Monitoreo> H2_QUIROFANO_PARTE_ANESTESIA_MONITOREO_CARGAR(long Cirugia_Id)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.H2_QUIROFANO_PARTE_ANESTESIA_MONITOREO_CARGAR(Cirugia_Id);
        }
        else return null;
    }
    


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void CambiarPaciente(long CirugiaId, long PacienteId)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            q.H2_QUIROFANO_CAMBIAR_PACIENTE_PROVISORIO(CirugiaId, PacienteId);
        }        
    }

    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Quirofano_Estado H2_QUIROFANO_ESTADOS(long CirugiaId)
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            QuirofanoBLL q = new QuirofanoBLL();
            return q.H2_QUIROFANO_ESTADOS(CirugiaId);
        }
        else {
            return null;
        }
    }

    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool TengoPermisoPlanificarCirugia()
    {
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.VerificadorBLL v = new Hospital.VerificadorBLL(); if (!v.PermisoSM("72")) { return false; } else { return true; }
        }
        else {
            return false;
        }
    }
    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Quirofano_Permisos_Tiempo TengoPermisoEdicion(int CirugiaId)
    {        
        Quirofano_Permisos_Tiempo estado = new Quirofano_Permisos_Tiempo();
        if (HttpContext.Current.Session["Usuario"] != null)
        {
            Hospital.VerificadorBLL v = new Hospital.VerificadorBLL();
            if (v.PermisoSM("73"))
            {
                estado.Dias = "0";
                estado.Puedo = true;
                return estado;
            } 

            QuirofanoBLL q = new QuirofanoBLL();
            int? dias = q.H2_Quirofano_Permiso_Edicion(CirugiaId);
            estado.Dias = dias.ToString();
            estado.Puedo = true;
            if (dias < -7)            
            {
                estado.Puedo = false;
            }
            return estado;
        }
        else
        {
            throw new Exception("Error Sesion");
        }
        
    }



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public Quirofano_Permisos_Tiempo PuedoModificarParte(int U)
    {
        Quirofano_Permisos_Tiempo estado = new Quirofano_Permisos_Tiempo();
        if (HttpContext.Current.Session["Usuario"] != null)
        {

            if (U == 0)
            {
                estado.Dias = "0";
                estado.Puedo = true;
            }
            else
            {
                Hospital.VerificadorBLL v = new Hospital.VerificadorBLL();
                if ((((usuarios)HttpContext.Current.Session["Usuario"]).id == U) || v.PermisoSM("73"))
                {
                    estado.Dias = "0";
                    estado.Puedo = true;
                }
                else
                {
                    estado.Dias = "0";
                    estado.Puedo = false;
                }
            }
            return estado;
        }
        else
        {
            throw new Exception("Error Sesion");
        }

    }



    
    

}
