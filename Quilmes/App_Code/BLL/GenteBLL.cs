﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenteBLL
/// </summary>
namespace Hospital
{
    public class GenteBLL
    {
        public GenteBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int ActualizarGente(long id,string tipo_doc,Int64 cuil, int documento, string apellido, string sexo, string telefono, int Seccional, Int64 cuit, string calle, string numero, string piso,
            string depto, string localidad, int provincia, DateTime fecha_nacimiento, DateTime FechaBaja, bool Provisorio, Int64 cuil_titu, DateTime FechaRevisado, DateTime FechaActualizacion, DateTime FechaAlta,
                int CodOS, int Cod_Pariente, string email, string celular, string Comentario, string CodPos, int Discapacidad, string FechaDiscapacidad, int AnioEstudiante, bool Certificado1, bool Certificado2, bool EsEstudiante, 
            bool PMI, bool PI, string NHC_UOM, DateTime FechaVencPMI, string EstadoCivil, string Nacionalidad, string NroCarnet)
        {
            string Usuario = "";
            int UId = 0;
            try
            {
                Usuario = ((usuarios)HttpContext.Current.Session["Usuario"]).nombre;
                UId = Convert.ToInt32(((usuarios)HttpContext.Current.Session["Usuario"]).id);
            }
            catch
            {
                throw new Exception("Hubo un error con la session de Usuario. Por favor cierre y habra de nuevo su sesión, e intentelo nuevamente. De Persistir el error, por favor comunicarse con Sistemas");
            }

            long _NHC_UOM;
            if (!long.TryParse(NHC_UOM, out _NHC_UOM)) _NHC_UOM = 0;




            GenteDALTableAdapters.QueriesTableAdapter adapter = new GenteDALTableAdapters.QueriesTableAdapter();
            object r = adapter.H2_Padron_Alta(cuil, documento, apellido, sexo, telefono, Seccional, cuit, calle, numero, piso, depto, localidad, provincia, fecha_nacimiento, Provisorio,
                cuil_titu, FechaRevisado, FechaActualizacion, FechaAlta, CodOS, Cod_Pariente, email, celular, Usuario, FechaBaja, Comentario, CodPos, Discapacidad, Convert.ToDateTime(FechaDiscapacidad), AnioEstudiante, Certificado1, Certificado2, EsEstudiante, 
                PMI, PI, _NHC_UOM.ToString(), tipo_doc, id, FechaVencPMI,EstadoCivil,Nacionalidad,NroCarnet);

            Estadisticas.Est_PacienteMovBLL E = new Estadisticas.Est_PacienteMovBLL();
            if (id > 0) E.EstPacMov(id, 1, UId, "Modificacion de HC.");
            else E.EstPacMov(Convert.ToInt32(r.ToString()), 1, UId, "Alta de HC."); //Sirve para saber quien dio el alta de HC

            if (r != null) return Convert.ToInt32(r.ToString());
            else return 0;
        }

        public int VerificarPMI(long PacienteID)
        {
            GenteDALTableAdapters.QueriesTableAdapter adapter = new GenteDALTableAdapters.QueriesTableAdapter();
            object existe = adapter.H2_GENTE_VENCIMIENTO_PMI(PacienteID);
            if (existe != null) return Convert.ToInt32(existe.ToString());
            else return 0;
        }

        public int ExisteNHC(long NHC_UOM_CENTRAL, long PacienteID)
        {
            GenteDALTableAdapters.QueriesTableAdapter adapter = new GenteDALTableAdapters.QueriesTableAdapter();
            object existe = adapter.H2_PADRON_EXISTE_NHC(NHC_UOM_CENTRAL.ToString(), PacienteID);
            if (existe != null) return Convert.ToInt32(existe.ToString());
            else return 0;
        }

        public long HC_UOM_Provisoria()
        {
            GenteDALTableAdapters.QueriesTableAdapter adapter = new GenteDALTableAdapters.QueriesTableAdapter();
            object existe = adapter.H2_GENTE_HC_UOM_PROVISORIA();
            if (existe != null) return Convert.ToInt64(existe.ToString());
            else return 0;
        }

        public string VerificarSiEsEstudiante(int documento)
        {
            GenteDALTableAdapters.QueriesTableAdapter adapter = new GenteDALTableAdapters.QueriesTableAdapter();
            return adapter.H2_Padron_Estudiantes_Mayoresa21(documento).ToString();
        }

    }
}