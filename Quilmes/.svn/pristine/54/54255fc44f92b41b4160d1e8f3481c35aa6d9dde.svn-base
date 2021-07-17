using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Summary description for HistoriaClinicaBLL
/// </summary>
namespace Hospital
{
    public class HistoriaClinicaBLL
    {
        public HistoriaClinicaBLL()
        {
            //
            // TODO: Add constructor logic here
            //


        }

        public List<historiaclinica> HistoriaClinica(long NHC, DateTime FechaDesde, DateTime FechaHasta, string EspecialidadesId, bool Diabetologia, bool Internacion, bool Cirugia)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_TotalTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_TotalTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_TotalDataTable aTable = adapter.GetData(NHC, FechaDesde, FechaHasta, EspecialidadesId, Diabetologia, Internacion, Cirugia);
            List<historiaclinica> Lista = new List<historiaclinica>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_TotalRow row in aTable.Rows)
            {
                historiaclinica h = new historiaclinica();
                h.HClinica = row.HC;
                Lista.Add(h);
            }
            return Lista;

        }

        public List<lista_anios> Internaciones_Anios(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_InternacionesTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_InternacionesTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_InternacionesDataTable aTable = adapter.GetData(NHC);
            List<lista_anios> Lista = new List<lista_anios>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_InternacionesRow row in aTable.Rows)
            {
                lista_anios i = new lista_anios();
                i.anio = row.Anio.ToString();
                Lista.Add(i);
            }
            return Lista;

        }

        public List<lista_anios> Recetas_Anios(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_RecetasTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_RecetasTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_RecetasDataTable aTable = adapter.GetData(NHC);
            List<lista_anios> Lista = new List<lista_anios>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_RecetasRow row in aTable.Rows)
            {
                lista_anios i = new lista_anios();
                i.anio = row.Anio.ToString();
                Lista.Add(i);
            }
            return Lista;

        }

        public List<lista_anios> Guardia_Anios(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_GuardiaTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_GuardiaTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_GuardiaDataTable aTable = adapter.GetData(NHC);
            List<lista_anios> Lista = new List<lista_anios>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_GuardiaRow row in aTable.Rows)
            {
                lista_anios i = new lista_anios();
                i.anio = row.Anio.ToString();
                Lista.Add(i);
            }
            return Lista;

        }

        public List<lista_anios> Labo_Anios(string Doc)
        {
            long _PacienteID;
            List<lista_anios> list_anios = new List<lista_anios>();

            if (!long.TryParse(Doc, out _PacienteID)) throw new Exception("Error en Paciente ID.");
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Anio_LaboratorioTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Anio_LaboratorioTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Anio_LaboratorioDataTable aTable = adapter.GetData(_PacienteID);
            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Anio_LaboratorioRow row in aTable.Rows)
            {
                lista_anios a = new lista_anios();
                a.anio = row.Anio.ToString();
                list_anios.Add(a);
            }
            return list_anios;
        }

        public List<labo_protocolos> Labo_Protocolos_by_Anio(string Doc, string Anio)
        {
            long _PacienteID;
            if (!long.TryParse(Doc, out _PacienteID)) throw new Exception("Error en Paciente ID.");

            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Protocolos_LaboratorioTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Protocolos_LaboratorioTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Protocolos_LaboratorioDataTable aTable = adapter.GetData(_PacienteID, int.Parse(Anio));
            List<labo_protocolos> protocolos = new List<labo_protocolos>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Protocolos_LaboratorioRow row in aTable)
            {
                labo_protocolos p = new labo_protocolos();
                p.archivo = row.Archivo;
                p.fecha =  row.Archivo.Substring(31,2) + "/" + row.Archivo.Substring(29,2) + "/" + row.Anio.ToString();
                p.protocolo = row.Archivo.Substring(10,10);
                p.ruta = "http://10.10.8.71/pdfs/" + row.Dire + "/" + row.Archivo;
                protocolos.Add(p);
            }
            return protocolos;
        }

        public List<lista_anios> Interconsultas_Anios(string NHC)
        {
            long _PacienteID;
            List<lista_anios> list_anios = new List<lista_anios>();
            if (!long.TryParse(NHC, out _PacienteID)) throw new Exception("Error en Paciente ID.");

            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Interconsulta_AniosTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Interconsulta_AniosTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Interconsulta_AniosDataTable aTable = adapter.GetData(_PacienteID);
            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Interconsulta_AniosRow row in aTable.Rows)
            {
                lista_anios a = new lista_anios();
                a.anio = row.Anio.ToString();
                list_anios.Add(a);
            }
            return list_anios;
        }


        public List<lista_anios> AnatomiaPatologica_Anios(string Soc_Id)
        {
            int _Soc_Id;
            List<lista_anios> list_anios = new List<lista_anios>();
            if (!int.TryParse(Soc_Id, out _Soc_Id)) throw new Exception("Error en Paciente ID.");

            HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_Anio_AnatomiaPatologicaTableAdapter adapter = new HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_Anio_AnatomiaPatologicaTableAdapter();
            HistoriaClinicaDAL.Axion_Historia_Clinica_Anio_AnatomiaPatologicaDataTable aTable = adapter.GetData(_Soc_Id);
            foreach (HistoriaClinicaDAL.Axion_Historia_Clinica_Anio_AnatomiaPatologicaRow row in aTable.Rows)
            {
                lista_anios a = new lista_anios();
                a.anio = row.Anio.ToString();
                list_anios.Add(a);
            }
            return list_anios;
        }

        public List<lista_anios> Imagenes_Anios(string Soc_Id, string PacienteId)
        {
            int _Soc_Id;
            List<lista_anios> list_anios = new List<lista_anios>();
            if (Soc_Id != "")
            {
                if (!int.TryParse(Soc_Id, out _Soc_Id)) throw new Exception("Error en Paciente ID.");

                HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_Anio_ImagenesTableAdapter adapter = new HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_Anio_ImagenesTableAdapter();
                HistoriaClinicaDAL.Axion_Historia_Clinica_Anio_ImagenesDataTable aTable = adapter.GetData(_Soc_Id);
                foreach (HistoriaClinicaDAL.Axion_Historia_Clinica_Anio_ImagenesRow row in aTable.Rows)
                {
                    lista_anios a = new lista_anios();
                    a.anio = row.Anio.ToString();
                    list_anios.Add(a);
                }
            }

            HistoriaClinicaDALTableAdapters.GesInMed_Historia_Clinica_Anio_ImagenesTableAdapter adapter_img = new HistoriaClinicaDALTableAdapters.GesInMed_Historia_Clinica_Anio_ImagenesTableAdapter();
            HistoriaClinicaDAL.GesInMed_Historia_Clinica_Anio_ImagenesDataTable aTable_img = adapter_img.GetData(int.Parse(PacienteId));
            foreach (HistoriaClinicaDAL.GesInMed_Historia_Clinica_Anio_ImagenesRow row_img in aTable_img.Rows)
            {
                lista_anios a = new lista_anios();
                a.anio = row_img.Anio.ToString();
                bool esta = false;
                foreach (lista_anios anios in list_anios)
                {
                    if (int.Parse(anios.anio)  == int.Parse(a.anio))
                    {
                        esta = true;
                    }                    
                }
                if (!esta)
                {
                    list_anios.Add(a);
                }
            }

            list_anios.OrderByDescending(p => p.anio).ToList();            
            return list_anios;
        }

        public List<lista_anios> Imagenes_AnatomiaPatologica(string Soc_Id)
        {
            int _Soc_Id;
            List<lista_anios> list_anios = new List<lista_anios>();
            if (!int.TryParse(Soc_Id, out _Soc_Id)) throw new Exception("Error en Paciente ID.");

            HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_Anio_ImagenesTableAdapter adapter = new HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_Anio_ImagenesTableAdapter();
            HistoriaClinicaDAL.Axion_Historia_Clinica_Anio_ImagenesDataTable aTable = adapter.GetData(_Soc_Id);
            foreach (HistoriaClinicaDAL.Axion_Historia_Clinica_Anio_ImagenesRow row in aTable.Rows)
            {
                lista_anios a = new lista_anios();
                a.anio = row.Anio.ToString();
                list_anios.Add(a);
            }
            return list_anios;            
        }



        public List<hc_anatomiapatologica> AnatomiaPatologica_Datos(string Soc_Id, string Anio)
        {
            int _Soc_Id;
            if (!int.TryParse(Soc_Id, out _Soc_Id)) throw new Exception("Error en Paciente ID.");

            HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_AnatomiaPatologicaTableAdapter adapter = new HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_AnatomiaPatologicaTableAdapter();
            HistoriaClinicaDAL.Axion_Historia_Clinica_AnatomiaPatologicaDataTable aTable = adapter.GetData(_Soc_Id, int.Parse(Anio));
            List<hc_anatomiapatologica> imagenes = new List<hc_anatomiapatologica>();

            foreach (HistoriaClinicaDAL.Axion_Historia_Clinica_AnatomiaPatologicaRow row in aTable)
            {
                hc_anatomiapatologica i = new hc_anatomiapatologica();
                i.PAT_NUMERO = row.PAT_NUMERO;
                i.MED_APELLIDO_NOMBRE = row.APELLIDOYNOMBRE;
                if (!row.IsPAT_FECHA_INICIONull()) i.PAT_FECHA_INICIO = row.PAT_FECHA_INICIO.ToShortDateString();
                if(!row.IsPMAT_DESCRIPCIONNull()) i.PMAT_DESCRIPCION = row.PMAT_DESCRIPCION;
                imagenes.Add(i);
            }
            return imagenes;
        }


        
        public List<hc_imagenes> Imagenes_Datos(string Soc_Id, string Anio, string PacienteId)
        {
            int _Soc_Id;
            List<hc_imagenes> imagenes = new List<hc_imagenes>();
            if (Soc_Id != null)
            {
                if (!int.TryParse(Soc_Id, out _Soc_Id)) throw new Exception("Error en Paciente ID.");                
                if (_Soc_Id != 0)
                {
                    HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_ImagenesTableAdapter adapter = new HistoriaClinicaDALTableAdapters.Axion_Historia_Clinica_ImagenesTableAdapter();
                    HistoriaClinicaDAL.Axion_Historia_Clinica_ImagenesDataTable aTable = adapter.GetData(_Soc_Id, int.Parse(Anio));

                    foreach (HistoriaClinicaDAL.Axion_Historia_Clinica_ImagenesRow row in aTable)
                    {
                        hc_imagenes i = new hc_imagenes();
                        if (!row.IsIMG_FECHA_INICIONull()) i.IMG_FECHA_INICIO = row.IMG_FECHA_INICIO.ToShortDateString();
                        i.IMG_ID = row.IMG_ID;
                        i.IMG_NUMERO = row.IMG_NUMERO.ToString();
                        if (!row.IsIMG_PATH_CONVERTIDONull()) i.IMG_PATH = row.IMG_PATH_CONVERTIDO;
                        if (!row.IsIMG_USUARIONull()) i.IMG_USUARIO = row.IMG_USUARIO;
                        i.TIMG_DESCRIPCION = row.TIMG_DESCRIPCION;
                        imagenes.Add(i);
                    }
                }
            }

            //ACA TENGO QUE CARGAR TAMBIEN LOS NUESTROS....

            HistoriaClinicaDALTableAdapters.H2_IMG_HC_DETALLESTableAdapter adapter_ges = new HistoriaClinicaDALTableAdapters.H2_IMG_HC_DETALLESTableAdapter();
            HistoriaClinicaDAL.H2_IMG_HC_DETALLESDataTable aTable_ges = adapter_ges.GetData(int.Parse(PacienteId), int.Parse(Anio));

            foreach (HistoriaClinicaDAL.H2_IMG_HC_DETALLESRow row in aTable_ges)
            {
                hc_imagenes i = new hc_imagenes();
                i.IMG_FECHA_INICIO = row.IMG_TURNO_FECHA.ToShortDateString();
                i.IMG_ID = row.IMG_TURNO_ID;
                i.IMG_NUMERO = row.IMG_TURNO_ESTADO.ToString();
                i.IMG_PATH = row.IMG_TURNO_ID.ToString();
                i.IMG_USUARIO = "";
                i.TIMG_DESCRIPCION = row.Descripcion;
                if (!row.Isna_accessionnumberNull()) i.WORK_LIST_NUMERO = row.na_accessionnumber.ToString(); else i.WORK_LIST_NUMERO = "";
                imagenes.Add(i);
            }
            
            imagenes.OrderByDescending(p => p.IMG_FECHA_INICIO).ToList();
            return imagenes;
        }



        public List<interconsulta> Interconsultas_Datos(string NHC, string Anio)
        {
            long _PacienteID;
            if (!long.TryParse(NHC, out _PacienteID)) throw new Exception("Error en Paciente ID.");

            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_InterconsultaTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_InterconsultaTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_InterconsultaDataTable aTable = adapter.GetData(_PacienteID, int.Parse(Anio));
            List<interconsulta> interconsultas = new List<interconsulta>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_InterconsultaRow row in aTable)
            {
                interconsulta i = new interconsulta();
                i.espinter = row.EspInter;
                i.fecha = row.Fecha.ToShortDateString();
                i.id = row.IdInterconsulta;
                i.medinter = row.MedInter;
                i.medsol = row.MedSol;
                if (!row.IsMotivoNull())
                i.motivo = row.Motivo;
                interconsultas.Add(i);
            }
            return interconsultas;
        }

        public List<lista_anios> Cirugias_Anios(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_CirugiasTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_CirugiasTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_CirugiasDataTable aTable = adapter.GetData(NHC);
            List<lista_anios> Lista = new List<lista_anios>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_CirugiasRow row in aTable.Rows)
            {
                lista_anios i = new lista_anios();
                i.anio = row.Anio.ToString();
                Lista.Add(i);
            }
            return Lista;
        }


        public List<lista_anios> Ambulatorio_Anios(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Anio_Antecedentes_AmbulatoriosTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Anio_Antecedentes_AmbulatoriosTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Anio_Antecedentes_AmbulatoriosDataTable aTable = adapter.GetData(NHC);
            List<lista_anios> Lista = new List<lista_anios>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Anio_Antecedentes_AmbulatoriosRow row in aTable.Rows)
            {
                lista_anios i = new lista_anios();
                i.anio = row.Anio.ToString();
                Lista.Add(i);
            }
            return Lista;

        }



        public List<lista_meses> Ambulatorio_Meses(long NHC, int Anio)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Meses_Antecedentes_AmbulatoriosTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_Meses_Antecedentes_AmbulatoriosTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Meses_Antecedentes_AmbulatoriosDataTable aTable = adapter.GetData(Anio, NHC);
            List<lista_meses> Lista = new List<lista_meses>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_Meses_Antecedentes_AmbulatoriosRow row in aTable.Rows)
            {
                lista_meses m = new lista_meses();
                m.mes = row.Mes.ToString();
                Lista.Add(m);
            }
            return Lista;

        }


        public List<registro_internacion> Internacion_Datos(long NHC, int Anio)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_InternacionTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_InternacionTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_InternacionDataTable aTable = adapter.GetData(Anio, NHC);
            List<registro_internacion> Lista = new List<registro_internacion>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_InternacionRow row in aTable.Rows)
            {
                registro_internacion i = new registro_internacion();
                if (!row.IsEgresoFechaNull()) { i.egreso = row.EgresoFecha.ToString(); } else { i.egreso = ""; }
                if (!row.IsEspecialidadNull()) { i.especialidad = row.Especialidad; } else { i.especialidad = ""; }
                i.id = row.Id.ToString();;
                i.ingreso = row.Fecha.ToShortDateString();
                if (!row.IsMedicoNull()) { i.medico = row.Medico; } else { i.medico = ""; }
                if (!row.IsMotivoEgresoNull()) { i.motivoegreso = row.MotivoEgreso; } else { i.motivoegreso = ""; }
                if (!row.IsMotivoIngresoNull()) { i.motivoingreso = row.MotivoIngreso; } else { i.motivoingreso = ""; }
                if (!row.IsServicioNull()) { i.servicio = row.Servicio; } else { i.servicio = ""; }
                Lista.Add(i);
            }
            return Lista;

        }



        public List<registro_cirugias> Cirugia_Datos(long NHC, int Anio)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_CirugiasTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_CirugiasTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_CirugiasDataTable aTable = adapter.GetData(Anio, NHC);
            List<registro_cirugias> Lista = new List<registro_cirugias>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_CirugiasRow row in aTable.Rows)
            {
                registro_cirugias c = new registro_cirugias();
                if (!row.IsCirugiaNull()) { c.cirugia = row.Cirugia; } else { c.cirugia = ""; }
                if (!row.IsDiagnosticoNull()) { c.diagnostico = row.Diagnostico; } else { c.diagnostico = ""; }
                if (!row.IsEspecialidadNull()) { c.especialidad = row.Especialidad; } else { c.especialidad = ""; }
                c.fecha = row.fecha.ToShortDateString();
                c.id = row.id.ToString();
                if (!row.IsCirujanoNull()) { c.medico = row.Cirujano; } else { c.medico = ""; }
                Lista.Add(c);
            }
            return Lista;

        }

        public List<registro_recetas> Recetas_Datos(long NHC, int Anio)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_RecetasTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_RecetasTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_RecetasDataTable aTable = adapter.GetData(Anio, NHC);
            List<registro_recetas> Lista = new List<registro_recetas>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_RecetasRow row in aTable.Rows)
            {
                registro_recetas c = new registro_recetas(); 
                c.diagnostico = row.Diagnostico; 
                c.especialidad = row.Especialidad;
                c.fecha = row.FechaInicio.ToShortDateString();
                c.id = row.Protocolo.ToString();
                c.medico = row.Medico;
                Lista.Add(c);
            }
            return Lista;

        }

        public List<registro_recetas> Guardia_Datos(long NHC, int Anio)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_GuardiaTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_GuardiaTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_GuardiaDataTable aTable = adapter.GetData(NHC, Anio);
            List<registro_recetas> Lista = new List<registro_recetas>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_GuardiaRow row in aTable.Rows)
            {
                registro_recetas c = new registro_recetas(); 
                c.diagnostico = row.Diagnostico; 
                c.especialidad = row.Especialidad;
                c.fecha = row.Fecha.ToShortDateString();
                c.id = row.Id.ToString();
                c.medico = row.Medico;
                Lista.Add(c);
            }
            return Lista;

        }

        public List<registro_ambulatorio> Ambulatorio_Datos(long NHC, int Anio, int Mes)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_AmbulatorioTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_AmbulatorioTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_AmbulatorioDataTable aTable = adapter.GetData(Anio, NHC, Mes);
            List<registro_ambulatorio> Lista = new List<registro_ambulatorio>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_AmbulatorioRow row in aTable.Rows)
            {
                registro_ambulatorio a = new registro_ambulatorio();

                if (!row.IsDiagnosticoNull()) { a.diagnostico = row.Diagnostico; } else { a.diagnostico = ""; }
                if (!row.IsEspecialidadNull()) { a.especialidad = row.Especialidad; } else { a.especialidad = ""; }
                a.fecha = row.Fecha_Atencion.ToShortDateString();
                a.id = row.Id.ToString();
                if (!row.IsMedicoNull()) { a.medico = row.Medico; } else { a.medico = ""; }
                if (!row.IsTipoNull()) { a.tipo = row.Tipo; } else { a.tipo = ""; }

                Lista.Add(a);
            }
            return Lista;

        }



        public List<HC_Compacta> Historia_Clinica_Compacta(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_CompactaTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_CompactaTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_CompactaDataTable aTable = adapter.GetData(NHC.ToString());
            List<HC_Compacta> Lista = new List<HC_Compacta>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_CompactaRow row in aTable.Rows)
            {
                HC_Compacta i = new HC_Compacta();
                if (!row.IsHCNull()) { i.HC = row.HC; }
                else i.HC = "";
                if (!row.IsFechaNull()) { i.fecha = row.Fecha.ToShortDateString(); }                
                Lista.Add(i);
            }
            return Lista;

        }

        public void HC_Movimiento_Insert(HC_Movimiento h)
        {
            HistoriaClinicaDALTableAdapters.QueriesTableAdapter adapter = new HistoriaClinicaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_HC_MOVIMIENTO_INSERT(h.Id,DateTime.Parse(h.Fecha), h.OrigenId, h.DestinoId, h.UsuarioId, h.NHC, h.Observaciones);
        }

        public void HC_Movimiento_Delete(long Id, long UsuarioId)
        {
            HistoriaClinicaDALTableAdapters.QueriesTableAdapter adapter = new HistoriaClinicaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_HC_MOVIMIENTOS_DELETE(Id, UsuarioId);
        }

        public List<HC_Movimiento> HC_Movimiento_Listar(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_HC_MOVIMIENTOS_LIST_BY_NHCTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_HC_MOVIMIENTOS_LIST_BY_NHCTableAdapter();
            HistoriaClinicaDAL.H2_HC_MOVIMIENTOS_LIST_BY_NHCDataTable aTable = adapter.GetData(NHC.ToString());
            List<HC_Movimiento> Lista = new List<HC_Movimiento>();
            foreach (HistoriaClinicaDAL.H2_HC_MOVIMIENTOS_LIST_BY_NHCRow row in aTable.Rows)
            {
                HC_Movimiento i = new HC_Movimiento();
                i.Destino = row.Destino;
                i.DestinoId = row.DestinoId;
                i.Fecha = row.Fecha.ToString();
                i.Id = row.Id;
                i.NHC = row.NHC;
                i.Origen = row.Origen;
                i.OrigenId = row.OrigenId;
                if (!row.IsUsuarioNull())
                    i.Usuario = row.Usuario;
                else i.Usuario = string.Empty;
                i.UsuarioId = row.UsuarioId;
                if (!row.IsObservacionesNull())
                    i.Observaciones = row.Observaciones;
                else i.Observaciones = string.Empty;
                Lista.Add(i);
            }
            return Lista;
        }

        public List<IM_Buscar> BuscarIM_by_Internacion(string IdInternacion)
        {
            long Id;

            if (!long.TryParse(IdInternacion, out Id)) throw new Exception("Error en Nro. de Internación.");

            HistoriaClinicaDALTableAdapters.H2_HC_LISTARIM_BY_NROINTTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_HC_LISTARIM_BY_NROINTTableAdapter();
            HistoriaClinicaDAL.H2_HC_LISTARIM_BY_NROINTDataTable aTable = adapter.GetData(Id);
            List<IM_Buscar> lista = new List<IM_Buscar>();
            foreach (HistoriaClinicaDAL.H2_HC_LISTARIM_BY_NROINTRow row in aTable.Rows)
            {
                IM_Buscar i = new IM_Buscar();
                i.Cama = row.Cama;
                i.Sala = row.Sala;
                i.Servicio = row.Servicio;
                i.IM_Id = row.Id.ToString();
                i.AfiliadoId = row.NHC;
                i.Medico = row.Medico;
                i.Fecha = row.Fecha.ToShortDateString();
                lista.Add(i);
            }
            return lista;
        }

        public long MedicoporUsuario(long UsuarioId)
        {
            HistoriaClinicaDALTableAdapters.QueriesTableAdapter adapter = new HistoriaClinicaDALTableAdapters.QueriesTableAdapter();
            object id = adapter.H2_MEDICO_POR_USUARIOID(UsuarioId);
            if (id != null) return Convert.ToInt64(id.ToString());
            else return 0;
        }

        public List<lista_anios> Endoscopia_Anios(long NHC)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_EndoscopiasTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_Arbol_EndoscopiasTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_EndoscopiasDataTable aTable = adapter.GetData(NHC);
            List<lista_anios> Lista = new List<lista_anios>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_Arbol_EndoscopiasRow row in aTable.Rows)
            {
                lista_anios i = new lista_anios();
                i.anio = row.Anio.ToString();
                Lista.Add(i);
            }
            return Lista;

        }


        public List<registro_cirugias> Endoscopia_Datos(long NHC, int Anio)
        {
            HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_EndoscopiasTableAdapter adapter = new HistoriaClinicaDALTableAdapters.H2_Historia_Clinica_EndoscopiasTableAdapter();
            HistoriaClinicaDAL.H2_Historia_Clinica_EndoscopiasDataTable aTable = adapter.GetData(Anio, NHC);
            List<registro_cirugias> Lista = new List<registro_cirugias>();

            foreach (HistoriaClinicaDAL.H2_Historia_Clinica_EndoscopiasRow row in aTable.Rows)
            {
                registro_cirugias c = new registro_cirugias();
                if (!row.IsCirugiaNull()) { c.cirugia = row.Cirugia; } else { c.cirugia = ""; }
                if (!row.IsDiagnosticoNull()) { c.diagnostico = row.Diagnostico; } else { c.diagnostico = ""; }
                if (!row.IsEspecialidadNull()) { c.especialidad = row.Especialidad; } else { c.especialidad = ""; }
                c.fecha = row.fecha.ToShortDateString();
                c.id = row.id.ToString();
                if (!row.IsCirujanoNull()) { c.medico = row.Cirujano; } else { c.medico = ""; }
                Lista.Add(c);
            }
            return Lista;

        }

    }
}