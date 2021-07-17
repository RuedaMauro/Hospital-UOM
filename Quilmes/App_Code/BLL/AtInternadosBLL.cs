using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AtInternadosBLL
/// </summary>
namespace Hospital
{
    public class AtInternadosBLL
    {
        public AtInternadosBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public List<at_internaciones_buscar> Buscar(string Servicios, string Paciente, int Documento, string NHC)
        {
            List<at_internaciones_buscar> list = new List<at_internaciones_buscar>();
            AtInternadosDALTableAdapters.H2_AtInternados_BuscarTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AtInternados_BuscarTableAdapter();
            AtInternadosDAL.H2_AtInternados_BuscarDataTable aTable = adapter.GetData(Servicios, Paciente, Documento, NHC);
            foreach (AtInternadosDAL.H2_AtInternados_BuscarRow row in aTable)
            {
                at_internaciones_buscar at = new at_internaciones_buscar();
                at.Afiliado = row.apellido;
                at.Cama = row.Cama;
                if (!row.IsDiagnosticoNull()) { at.Diagnostico = row.Diagnostico; }
                at.FIngreso = row.Fecha.ToShortDateString();
                at.internacion = row.Id;
                at.NHC = row.NHC;
                at.Sala = row.Sala;
                at.SalaId = row.SalaId;
                at.CamaId = row.CamaId;
                at.Seccional = row.OS;
                at.Servicio = row.Servicio;
                at.ServicioId = row.ServicioId;
                if (!row.IsNHC_UOMNull())
                    at.NHC_UOM = row.NHC_UOM;
                else at.NHC_UOM = string.Empty;
                list.Add(at);
            }
            return list;
        }

        public List<evolucion> CargarEvoluciones(long Id, long Internacion, int MedicoId)
        {
            List<evolucion> list = new List<evolucion>();
            AtInternadosDALTableAdapters.H2_AtInternados_CargarEvolucionTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AtInternados_CargarEvolucionTableAdapter();
            AtInternadosDAL.H2_AtInternados_CargarEvolucionDataTable aTable = adapter.GetData(Id, Internacion);
            foreach (AtInternadosDAL.H2_AtInternados_CargarEvolucionRow row in aTable)
            {
                evolucion e = new evolucion();
                e.cama = row.cama;
                e.camaid = row.camaid;
                e.evoluciones = row.evolucion;
                e.fecha = row.fecha.ToShortDateString();
                e.ff = row.fecha.ToShortDateString();
                e.hh = row.fecha.ToShortTimeString();
                e.internacionid = row.internacionid;
                e.medico = row.medico;
                e.medicoid = row.medicoid;
                e.NHC = row.paciente;
                e.sala = row.sala;
                e.salaid = row.salaid;
                e.EId = row.EId;
                e.especialidad = row.Especialidad;
                e.especialidadId = row.especialidadId;

                if (e.fecha.Equals(DateTime.Now.ToShortDateString()) && e.medicoid.Equals(MedicoId)) e.Editable = true;
                else e.Editable = false;

                list.Add(e);
            }
            return list;
        }


        public void Guardar(DateTime Fecha, int MedicoId, long internacionid, string evolucion, long NHC, int CamaId, int SalaId, long EvolucionId, int Especialidad)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            adapter.H2_AtInternados_Guardar_Evolucion(Fecha, MedicoId, internacionid, evolucion, NHC, CamaId, SalaId, EvolucionId,Especialidad);
        }

        public void Eliminar(long Id)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            adapter.H2_AtInternado_EliminarEvolucion(Id);
        }

        public void Insert_PedidoInterconsulta(Interconsulta i)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            DateTime _FechaCierre = DateTime.MinValue;
            if (!string.IsNullOrEmpty(i.FechaCierre)) _FechaCierre = DateTime.Parse(i.FechaCierre);
            adapter.H2_AT_INTERNADOS_PEDIDOSINTER_INSERT(i.IdInterconsulta,i.NroInternacion, i.NHC, i.MedicoSol, i.MedicoInter, i.EspecialidadInter, DateTime.Parse(i.Fecha), i.Motivo, i.Estado, i.Observacion, i.Indicacion, _FechaCierre);
        }

        public BusquedaInternadosId CargarEncabezdoInternacionId(long Id)
        {
            AtInternadosDALTableAdapters.H2_AtInternados_Internacion_IdTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AtInternados_Internacion_IdTableAdapter();
            AtInternadosDAL.H2_AtInternados_Internacion_IdDataTable aTable = adapter.GetData(Id);
            BusquedaInternadosId i = new BusquedaInternadosId();
            if (aTable.Rows.Count > 0)
            {                
                i.cama = aTable[0].Cama;
                i.camaid = aTable[0].Camaid;
                i.dni = aTable[0].documento;
                i.fecha = aTable[0].Fecha.ToString();
                i.medico = aTable[0].Medico;
                i.medicoid = aTable[0].MedicoId;
                i.NHC = aTable[0].cuil;
                i.sala = aTable[0].Sala;
                i.salaid = aTable[0].SalaId;
                i.paciente = aTable[0].Paciente;
                i.servicio = aTable[0].Servicio;
                i.servicioid = aTable[0].ServicioId;
            }
            return i;
        }

        public void Epicrisis_Guardar(int Id, long PacienteNHC, int internacionid, string Ingreso_DX, string Ingreso_Detalle, string Ingreso_Ant1, string Ingreso_Ant2, 
            string Ingreso_Ant3, string Ingreso_Ant4, string Ingreso_Ant5, string Ingreso_Ant6, string Ingreso_Ant7, string Ingreso_Ant8, string Ingreso_Ant9, 
            string Ingreso_Ant10, string Ingreso_Motivo, string Ingreso_Antecedentes_Personales, string Ingreso_Internacion_Actual, string Complementarios_Laboratorio, 
            string Complementarios_Imagenes, string Complementarios_Otros, string Egreso_Diagnostico, int Egreso_Motivo_Alta, string Egreso_Indicacion, 
            string Egreso_Concurrir, string Egreso_Complicacion, string Egreso_Dx, string Egreso_Detalle, string Egreso_Detalle3,int Usuario, int Medico, int Especialidad, string FechaIngreso, 
            string FechaEgreso)
        {
            try
            {
                AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
                adapter.H2_Epicrisis_Guardar(Id, PacienteNHC, internacionid, Ingreso_DX, Ingreso_Detalle, Ingreso_Ant1, Ingreso_Ant2, Ingreso_Ant3, Ingreso_Ant4, 
                    Ingreso_Ant5, Ingreso_Ant6, Ingreso_Ant7, Ingreso_Ant8, Ingreso_Ant9, Ingreso_Ant10, Ingreso_Motivo, Ingreso_Antecedentes_Personales, 
                    Ingreso_Internacion_Actual, Complementarios_Laboratorio, Complementarios_Imagenes, Complementarios_Otros, Egreso_Diagnostico, Egreso_Motivo_Alta, 
                    Egreso_Indicacion, Egreso_Concurrir, Egreso_Complicacion, Egreso_Dx, Egreso_Detalle,Egreso_Detalle3,Usuario, Medico, Especialidad, DateTime.Parse(FechaIngreso), 
                    DateTime.Parse(FechaEgreso));
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void PaseUTI_Piso_Guardar(int Id, long PacienteNHC, int internacionid, string Ingreso_DX, string Ingreso_Detalle, string Ingreso_Ant1, string Ingreso_Ant2, string Ingreso_Ant3, string Ingreso_Ant4, string Ingreso_Ant5, string Ingreso_Ant6, string Ingreso_Ant7, string Ingreso_Ant8, string Ingreso_Ant9, string Ingreso_Ant10, string Ingreso_Motivo, string Ingreso_Antecedentes_Personales, string Ingreso_Internacion_Actual, string Complementarios_Laboratorio, string Complementarios_Imagenes, string Complementarios_Otros, string Egreso_Diagnostico, int Egreso_Motivo_Alta, string Egreso_Indicacion, string Egreso_Concurrir, string Egreso_Complicacion, string Egreso_Dx, string Egreso_Detalle, int Usuario, int Medico, int Especialidad, string FechaIngreso, string FechaEgreso)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            adapter.H2_AtInternados_PaseUTI_Piso_Guardar(Id, PacienteNHC, internacionid, Ingreso_DX, Ingreso_Detalle, Ingreso_Ant1, Ingreso_Ant2, Ingreso_Ant3, Ingreso_Ant4, Ingreso_Ant5, Ingreso_Ant6, Ingreso_Ant7, Ingreso_Ant8, Ingreso_Ant9, Ingreso_Ant10, Ingreso_Motivo, Ingreso_Antecedentes_Personales, Ingreso_Internacion_Actual, Complementarios_Laboratorio, Complementarios_Imagenes, Complementarios_Otros, Egreso_Diagnostico, Egreso_Motivo_Alta, Egreso_Indicacion, Egreso_Concurrir, Egreso_Complicacion, Egreso_Dx, Egreso_Detalle, Usuario, Medico, Especialidad, DateTime.Parse(FechaIngreso), DateTime.Parse(FechaEgreso));
        }

        public long Hoja_Enfermeria_InsertCab(HojaEnfermeriaCab h)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            object gen;
            try
            {
                gen = adapter.H2_AT_INTERNADOS_HOJA_ENF_INSERT_CAB(h.NHC, h.IdSala, h.IdCama, h.IdServicio, DateTime.Parse(h.Fecha), h.IdInternacion, h.UsuarioId,h.MedicoId);
                return Convert.ToInt64(gen.ToString());
            }
            catch {
                throw new Exception("No se pudo insertar el registro");
            }
        }

        public int Interconsultas_Pendientes_by_Usuario(long Usuario)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            object obj;
            try
            {
                obj = adapter.H2_AT_INTERNADOS_INTERCONS_PENDIENTES(Usuario);
                if (obj != null)
                    return Convert.ToInt32(obj.ToString());
                else return 0;
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    throw new Exception(((SqlException)ex).Message);
                else throw new Exception(ex.Message);
            }
        }

        public void Hoja_Enfermeria_InsertDet(HojaEnfermeriaDet h)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            try
            {
                adapter.H2_AT_INTERNADOS_HOJA_ENF_INSERT_DET(h.IdHoja, h.IdInsumo, h.Indicacion, h.EnHoras, h.Frecuencia, h.Observaciones, h.Enfermera, h.Realizado);
            }
            catch {
                throw new Exception("No se pudo insertar el registro");
            }
        }

        public long UltimaHojaEnf_by_Int(long IdInternacion)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            try
            {
                object Id = adapter.H2_AT_INTERNADOS_ULTIMA_HOJA_BY_INT(IdInternacion);
                if (Id != null) return Convert.ToInt64(Id.ToString());
                else return 0;
            }
            catch
            {
                throw new Exception("Error al buscar ultima hoja.");
            }
        }

        public EpicrisisDatosCargado CargarEpicrisis(int intId)
        {
            AtInternadosDALTableAdapters.H2_AtInternados_Epicrisis_CargarTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AtInternados_Epicrisis_CargarTableAdapter();
            AtInternadosDAL.H2_AtInternados_Epicrisis_CargarDataTable aTable = adapter.GetData(intId);
            EpicrisisDatosCargado i = new EpicrisisDatosCargado();
            if (aTable.Rows.Count > 0)
            {
                if (!aTable[0].IsEgreso_DiagnosticoNull()) i.diagnostico = aTable[0].Egreso_Diagnostico;
                if (!aTable[0].IsEgreso_ComplicacionNull()) i.egreso_compilacion = aTable[0].Egreso_Complicacion;
                
                
                if (!aTable[0].IsEgreso_IndicacionNull()) i.egreso_indicacion = aTable[0].Egreso_Indicacion;
                if (!aTable[0].IsEgreso_ConcurrirNull()) i.fecha_concurrir = aTable[0].Egreso_Concurrir;
                if (!aTable[0].IsComplementarios_ImagenesNull()) i.imagen = aTable[0].Complementarios_Imagenes;
                if (!aTable[0].IsIngreso_Antecedentes_PersonalesNull()) i.ingreso_ant_personales = aTable[0].Ingreso_Antecedentes_Personales;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant1 = aTable[0].Ingreso_Ant1;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant2 = aTable[0].Ingreso_Ant2;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant3 = aTable[0].Ingreso_Ant3;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant4 = aTable[0].Ingreso_Ant4;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant5 = aTable[0].Ingreso_Ant5;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant6 = aTable[0].Ingreso_Ant6;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant7 = aTable[0].Ingreso_Ant7;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant8 = aTable[0].Ingreso_Ant8;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant9 = aTable[0].Ingreso_Ant9;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant10 = aTable[0].Ingreso_Ant10;
                if (!aTable[0].IsIngreso_DetalleNull()) i.ingreso_Detalle = aTable[0].Ingreso_Detalle;
                if (!aTable[0].IsIngreso_DXNull()) i.ingreso_DX = aTable[0].Ingreso_DX;
                if (!aTable[0].IsIngreso_Internacion_ActualNull()) i.ingreso_int_actual = aTable[0].Ingreso_Internacion_Actual;
                if (!aTable[0].IsIngreso_MotivoNull()) i.ingreso_motivo = aTable[0].Ingreso_Motivo;
                i.internacionId = aTable[0].internacionid.ToString();
                if (!aTable[0].IsComplementarios_LaboratorioNull()) i.laboratorio = aTable[0].Complementarios_Laboratorio;
                if (!aTable[0].IsEgreso_Motivo_AltaNull()) i.motivo_alta = aTable[0].Egreso_Motivo_Alta;
                if (!aTable[0].IsPacienteNHCNull()) i.NHC = aTable[0].PacienteNHC.ToString();
                if (!aTable[0].IsComplementarios_OtrosNull()) i.otros = aTable[0].Complementarios_Otros;
                if (!aTable[0].IsFechaIngresoNull()) i.fecha_ingreso = aTable[0].FechaIngreso.ToShortDateString();
                else i.fecha_ingreso = "01/01/1900";
                i.MedicoId = aTable[0].MedicoId;
                i.EspecialidadId = aTable[0].EspecialidadId;
                if (!aTable[0].IsFechaEgresoNull()) i.fecha_egreso = aTable[0].FechaEgreso.ToShortDateString();
                else i.fecha_egreso = "01/01/1900";

                if (!aTable[0].IsEgreso_DxNull())
                    i.egreso_dx = aTable[0].Egreso_Dx;
                else i.egreso_dx = string.Empty;

                if (!aTable[0].IsEgreso_DetalleNull()) i.egreso_detalle = aTable[0].Egreso_Detalle;
                else i.egreso_detalle = string.Empty;

                if (!aTable[0].IsEgreso_Detalle3Null())
                    i.egreso_detalle3 = aTable[0].Egreso_Detalle3;
                else i.egreso_detalle3 = string.Empty;

                if (!aTable[0].IsICD10_1_DescNull()) i.egreso_dx_desc = aTable[0].ICD10_1_Desc;
                else i.egreso_dx_desc = string.Empty;

                if (!aTable[0].IsICD10_2_DescNull()) i.egreso_detalle_desc = aTable[0].ICD10_2_Desc;
                else i.egreso_detalle_desc = string.Empty;

                if (!aTable[0].IsICD10_3_DescNull()) i.egreso_detalle3_desc = aTable[0].ICD10_3_Desc;
                else i.egreso_detalle3_desc = string.Empty;
            }
            return i;
        }


        public EpicrisisDatosCargado CargarPaseUTI_Piso(int intId)
        {
            AtInternadosDALTableAdapters.H2_AtInternados_PaseUTI_PISO_CargarTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AtInternados_PaseUTI_PISO_CargarTableAdapter();
            AtInternadosDAL.H2_AtInternados_PaseUTI_PISO_CargarDataTable aTable = adapter.GetData(intId);
            EpicrisisDatosCargado i = new EpicrisisDatosCargado();
            if (aTable.Rows.Count > 0)
            {
                if (!aTable[0].IsEgreso_DiagnosticoNull()) i.diagnostico = aTable[0].Egreso_Diagnostico;
                if (!aTable[0].IsEgreso_ComplicacionNull()) i.egreso_compilacion = aTable[0].Egreso_Complicacion;
                if (!aTable[0].IsEgreso_DetalleNull()) i.egreso_detalle = aTable[0].Egreso_Detalle;
                if (!aTable[0].IsEgreso_DxNull()) i.egreso_dx = aTable[0].Egreso_Dx;
                if (!aTable[0].IsEgreso_IndicacionNull()) i.egreso_indicacion = aTable[0].Egreso_Indicacion;
                if (!aTable[0].IsEgreso_ConcurrirNull()) i.fecha_concurrir = aTable[0].Egreso_Concurrir;
                if (!aTable[0].IsComplementarios_ImagenesNull()) i.imagen = aTable[0].Complementarios_Imagenes;
                if (!aTable[0].IsIngreso_Antecedentes_PersonalesNull()) i.ingreso_ant_personales = aTable[0].Ingreso_Antecedentes_Personales;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant1 = aTable[0].Ingreso_Ant1;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant2 = aTable[0].Ingreso_Ant2;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant3 = aTable[0].Ingreso_Ant3;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant4 = aTable[0].Ingreso_Ant4;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant5 = aTable[0].Ingreso_Ant5;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant6 = aTable[0].Ingreso_Ant6;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant7 = aTable[0].Ingreso_Ant7;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant8 = aTable[0].Ingreso_Ant8;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant9 = aTable[0].Ingreso_Ant9;
                if (!aTable[0].IsIngreso_Ant1Null()) i.ingreso_Ant10 = aTable[0].Ingreso_Ant10;
                if (!aTable[0].IsIngreso_DetalleNull()) i.ingreso_Detalle = aTable[0].Ingreso_Detalle;
                if (!aTable[0].IsIngreso_DXNull()) i.ingreso_DX = aTable[0].Ingreso_DX;
                if (!aTable[0].IsIngreso_Internacion_ActualNull()) i.ingreso_int_actual = aTable[0].Ingreso_Internacion_Actual;
                if (!aTable[0].IsIngreso_MotivoNull()) i.ingreso_motivo = aTable[0].Ingreso_Motivo;
                i.internacionId = aTable[0].internacionid.ToString();
                if (!aTable[0].IsComplementarios_LaboratorioNull()) i.laboratorio = aTable[0].Complementarios_Laboratorio;
                if (!aTable[0].IsEgreso_Motivo_AltaNull()) i.motivo_alta = aTable[0].Egreso_Motivo_Alta;
                if (!aTable[0].IsPacienteNHCNull()) i.NHC = aTable[0].PacienteNHC.ToString();
                if (!aTable[0].IsComplementarios_OtrosNull()) i.otros = aTable[0].Complementarios_Otros;
                if (!aTable[0].IsFechaIngresoNull()) i.fecha_ingreso = aTable[0].FechaIngreso.ToShortDateString();
                else i.fecha_ingreso = DateTime.Now.ToShortDateString();
                i.MedicoId = aTable[0].MedicoId;
                i.EspecialidadId = aTable[0].EspecialidadId;
                if (!aTable[0].IsFechaEgresoNull()) i.fecha_egreso = aTable[0].FechaEgreso.ToShortDateString();
                else i.fecha_egreso = DateTime.Now.ToShortDateString();
            }
            return i;
        }

        public void At_Internados_PedidosInter_Update(long Id, long MedicoInter, string Observacion, string MedicoExterno)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            adapter.H2_At_Internados_PedidosInter_Update(Id, MedicoInter, Observacion, MedicoExterno);
        }

        public List<InterconsultaList> Interconsultas_by_NHC(long NHC, long Medico,long EspId)
        { 
            List<InterconsultaList> list = new List<InterconsultaList>();
            AtInternadosDALTableAdapters.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LISTTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LISTTableAdapter();
            AtInternadosDAL.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LISTDataTable aTable = adapter.GetData(NHC, Medico,EspId);
            foreach (AtInternadosDAL.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LISTRow row in aTable.Rows)
            {
                list.Add(CreateRowFromRowInterconsultas(row));
            }
            return list;
        }

        private InterconsultaList CreateRowFromRowInterconsultas(AtInternadosDAL.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LISTRow row)
        {
            InterconsultaList i = new InterconsultaList();
            i.EspecialidadInter = row.EspInterId;
            i.EspecialidadInterDesc = row.EspecialidadInter;
            if(!row.IsEstadoNull())
            i.Estado = row.Estado;
            i.Fecha = row.Fecha.ToShortDateString();
            if (!row.IsIndicacionNull())
            i.Indicacion = row.Indicacion;
            i.MedicoInter = row.MedInterId;
            i.MedicoInterDesc = row.MedicoInter;
            i.MedicoSol = row.MedSolId;
            i.MedicoSolDesc = row.MedicoSol;
            if(!row.IsMotivoNull())
            i.Motivo = row.Motivo;
            i.NHC = row.NHC;
            i.NroInternacion = row.NroInternacion;
            if(!row.IsObservacionNull())
            i.Observacion = row.Observacion;
            i.IdInterconsulta = row.IdInterconsulta;
            if (!row.IsFechaCierreNull())
                i.FechaCierre = row.FechaCierre.ToShortDateString();
            switch (i.Estado)
            {
                case 1: i.RowClass = "success"; break;
                case 0: i.RowClass = "warning"; break;
                case 2: i.RowClass = "error"; break;
                case 3: i.RowClass = "info"; break;
            }
            return i;
        }


        public List<InterconsultaList> Interconsultas_by_Fecha(long NHC, long Medico, long EspId, string Desde, string Hasta, bool Todos, string Afiliado)
        {
            List<InterconsultaList> list = new List<InterconsultaList>();
            AtInternadosDALTableAdapters.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LIST_BY_FECHATableAdapter adapter = new AtInternadosDALTableAdapters.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LIST_BY_FECHATableAdapter();
            AtInternadosDAL.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LIST_BY_FECHADataTable aTable = adapter.GetData(NHC, Medico, EspId, DateTime.Parse(Desde), DateTime.Parse(Hasta), Todos, Afiliado);
            foreach (AtInternadosDAL.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LIST_BY_FECHARow row in aTable.Rows)
            {
                list.Add(CreateRowFromRowInterconsultas(row));
            }
            return list;
        }

        private InterconsultaList CreateRowFromRowInterconsultas(AtInternadosDAL.H2_AT_INTERNADOS_PEDIDOS_INTERCONSULTAS_LIST_BY_FECHARow row)
        {
            InterconsultaList i = new InterconsultaList();
            i.EspecialidadInter = row.EspInterId;
            i.EspecialidadInterDesc = row.EspecialidadInter;
            if (!row.IsEstadoNull())
                i.Estado = row.Estado;
            i.Fecha = row.Fecha.ToShortDateString();
            if (!row.IsIndicacionNull())
                i.Indicacion = row.Indicacion;
            i.MedicoInter = row.MedInterId;
            i.MedicoInterDesc = row.MedicoInter;
            i.MedicoSol = row.MedSolId;
            i.MedicoSolDesc = row.MedicoSol;
            if (!row.IsMotivoNull())
                i.Motivo = row.Motivo;
            i.NHC = row.NHC;
            i.NroInternacion = row.NroInternacion;
            if (!row.IsObservacionNull())
                i.Observacion = row.Observacion;
            else i.Observacion = string.Empty;
            i.IdInterconsulta = row.IdInterconsulta;
            if (!row.IsFechaCierreNull())
                i.FechaCierre = row.FechaCierre.ToShortDateString();
            switch (i.Estado)
            {
                case 1: i.RowClass = "success"; break;
                case 0: i.RowClass = "warning"; break;
                case 2: i.RowClass = "error"; break;
                case 3: i.RowClass = "info"; break;
            }
            if (!row.IsHC_UOMNull()) i.HC_UOM = row.HC_UOM;
            if (!row.IsCamaNull()) i.Cama = row.Cama;
            if (!row.IsServicioNull()) i.Servicio = row.Servicio;
            i.Afiliado = row.Paciente;
            if (!row.IsMedicoExternoNull())
                i.MedicoExterno = row.MedicoExterno;
            else i.MedicoExterno = string.Empty;

            return i;
        }

        public List<HojaEnfermeriaDet> UltimaIMbyNHC(long NHC)
        {
            List<HojaEnfermeriaDet> list = new List<HojaEnfermeriaDet>();
            AtInternadosDALTableAdapters.H2_AT_INTERNADOS_ULT_IM_BY_NHCTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AT_INTERNADOS_ULT_IM_BY_NHCTableAdapter();
            AtInternadosDAL.H2_AT_INTERNADOS_ULT_IM_BY_NHCDataTable aTable = adapter.GetData(NHC);
            foreach (AtInternadosDAL.H2_AT_INTERNADOS_ULT_IM_BY_NHCRow row in aTable.Rows)
            {
                list.Add(CreateRowFromRowUltimaIMbyNHC(row));
            }
            return list;
        }

        private HojaEnfermeriaDet CreateRowFromRowUltimaIMbyNHC(AtInternadosDAL.H2_AT_INTERNADOS_ULT_IM_BY_NHCRow row)
        {
            HojaEnfermeriaDet h = new HojaEnfermeriaDet();
            h.EnHoras = row.EnHoras;
            if (!row.IsFrecuenciaNull())
            h.Frecuencia = row.Frecuencia;
            h.IdDetalle = row.Id;
            if (!row.IsIdIndicacionMedicaNull())
            h.IdIM = row.IdIndicacionMedica;
            if (!row.IsIdInsumoNull())
            h.IdInsumo = row.IdInsumo;
            if (!row.IsIndicacionNull())
            h.Indicacion = row.Indicacion;
            if (!row.IsObservacionesNull())
            h.Observaciones = row.Observaciones;
            return h;
        }

        public List<HojaEnfermeriaList> Hoja_Enfermeria_List(long NHC, long MedicoId, DateTime FechaDesde, DateTime FechaHasta, long ServicioId, string Afiliado)
        {
            List<HojaEnfermeriaList> list = new List<HojaEnfermeriaList>();
            AtInternadosDALTableAdapters.H2_AT_INTERNADOS_HOJAS_ENF_LISTTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AT_INTERNADOS_HOJAS_ENF_LISTTableAdapter();
            AtInternadosDAL.H2_AT_INTERNADOS_HOJAS_ENF_LISTDataTable aTable = adapter.GetData(NHC,MedicoId,FechaDesde,FechaHasta,ServicioId,Afiliado);
            foreach (AtInternadosDAL.H2_AT_INTERNADOS_HOJAS_ENF_LISTRow row in aTable.Rows)
            {
                list.Add(CreateRowFromRowHoja_Enfermeria_List(row));
            }
            return list;
        }

        private HojaEnfermeriaList CreateRowFromRowHoja_Enfermeria_List(AtInternadosDAL.H2_AT_INTERNADOS_HOJAS_ENF_LISTRow row)
        {
            HojaEnfermeriaList h = new HojaEnfermeriaList();
            h.Fecha = row.Fecha.ToShortDateString();
            h.IdHoja = row.IdHoja;
            h.Medico = row.Medico;
            h.NHC = row.NHC;
            h.Paciente = row.Paciente;
            h.Servicio = row.Servicio;
            return h;
        }

        public List<HojaEnfermeriaCabList> Hoja_Enfermeria_List_Cab_byId(long Id)
        {
            List<HojaEnfermeriaCabList> list = new List<HojaEnfermeriaCabList>();
            AtInternadosDALTableAdapters.H2_AT_INTERNADOS_LIST_BY_ID_CABTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AT_INTERNADOS_LIST_BY_ID_CABTableAdapter();
            AtInternadosDAL.H2_AT_INTERNADOS_LIST_BY_ID_CABDataTable aTable = adapter.GetData(Id);
            foreach (AtInternadosDAL.H2_AT_INTERNADOS_LIST_BY_ID_CABRow row in aTable.Rows)
            {
                list.Add(CreateRowFromRowHoja_Enfermeria_List_Cab_byId(row));
            }
            return list;
        }

        private HojaEnfermeriaCabList CreateRowFromRowHoja_Enfermeria_List_Cab_byId(AtInternadosDAL.H2_AT_INTERNADOS_LIST_BY_ID_CABRow row)
        {
            HojaEnfermeriaCabList h = new HojaEnfermeriaCabList();
            h.Cama = row.Cama;
            h.Fecha = row.Fecha.ToShortDateString();
            h.IdCama = row.IdCama;
            h.IdHoja = row.IdHoja;
            h.IdSala = row.IdSala;
            h.IdServicio = row.IdServicio;
            h.Medico = row.Medico;
            h.MedicoId = row.MedicoId;
            h.NHC = row.NHC;
            h.Paciente = row.Paciente;
            h.Sala = row.Sala;
            h.Seccional = row.Seccional;
            h.Servicio = row.Servicio;
            return h;
        }

        public List<HojaEnfermeriaDet> Hoja_Enfermeria_List_Det_byId(long Id)
        {
            List<HojaEnfermeriaDet> list = new List<HojaEnfermeriaDet>();
            AtInternadosDALTableAdapters.H2_AT_INTERNADOS_LIST_BY_ID_DETTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AT_INTERNADOS_LIST_BY_ID_DETTableAdapter();
            AtInternadosDAL.H2_AT_INTERNADOS_LIST_BY_ID_DETDataTable aTable = adapter.GetData(Id);
            foreach (AtInternadosDAL.H2_AT_INTERNADOS_LIST_BY_ID_DETRow row in aTable.Rows)
            {
                list.Add(CreateRowFromRowHoja_Enfermeria_List_Det_byId(row));
            }
            return list;
        }

        private HojaEnfermeriaDet CreateRowFromRowHoja_Enfermeria_List_Det_byId(AtInternadosDAL.H2_AT_INTERNADOS_LIST_BY_ID_DETRow row)
        {
            HojaEnfermeriaDet h = new HojaEnfermeriaDet();
            h.Enfermera = row.Enfermera;
            h.EnHoras = row.EnHoras;
            if (!row.IsFrecuenciaNull())
            h.Frecuencia = row.Frecuencia;
            h.IdHoja = row.IdHoja;
            h.IdInsumo = row.IdInsumo;
            if (!row.IsIndicacionNull())
            h.Indicacion = row.Indicacion;
            if (!row.IsObservacionesNull())
            h.Observaciones = row.Observaciones;
            h.Realizado = row.Realizado;
            return h;
        }

        public void Hoja_Enfermeria_Delete_Det(long Id)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            adapter.H2_AT_INTERNADOS_DELETE_BY_ID_DET(Id);
        }


        public List<AtInternacionHojaQuirirgico> AtInternados_Hoja_Quirurgica_Listar(int Id, int PacienteId, int InternacionId)
        {
            List<AtInternacionHojaQuirirgico> list = new List<AtInternacionHojaQuirirgico>();
            AtInternadosDALTableAdapters.H2_At_Internados_HC_PRACTICAS_QUIRURGICAS_ListarTableAdapter adapter = new AtInternadosDALTableAdapters.H2_At_Internados_HC_PRACTICAS_QUIRURGICAS_ListarTableAdapter();
            AtInternadosDAL.H2_At_Internados_HC_PRACTICAS_QUIRURGICAS_ListarDataTable aTable = adapter.GetData(Id, PacienteId, InternacionId);
            foreach (AtInternadosDAL.H2_At_Internados_HC_PRACTICAS_QUIRURGICAS_ListarRow row in aTable.Rows)
            {
                AtInternacionHojaQuirirgico q = new AtInternacionHojaQuirirgico();
                q.PRQ_ID = row.PRQ_ID;
                q.PRQ_FECHA = row.PRQ_FECHA.ToShortDateString();
                q.PRQ_SOC_ID = row.PRQ_SOC_ID.ToString();
                q.PRQ_DIAG_ID = row.PRQ_DIAG_ID.ToString();
                q.PRQ_ESP_ID = row.PRQ_ESP_ID.ToString();
                q.PRQ_MEDICO_ID = row.PRQ_MEDICO_ID.ToString();
                q.PRQ_CIRU_ID = row.PRQ_CIRU_ID.ToString();
                q.PRQ_ESQUEMA_OPE = row.PRQ_ESQUEMA_OPE;
                q.PRQ_SESION = row.PRQ_SESION.ToString();
                q.PRQ_USUARIO = row.PRQ_USUARIO.ToString();
                q.PRQ_CAMA_ID = row.PRQ_CAMA_ID.ToString();
                q.PRQ_GUA_ID = row.PRQ_GUA_ID.ToString();
                if(!row.IsCAMA_DESCRIPCIONNull()) q.CAMA_DESCRIPCION = row.CAMA_DESCRIPCION;
                if (!row.IsPRACTICA_DESCRIPCIONNull()) q.PRACTICA_DESCRIPCION = row.PRACTICA_DESCRIPCION;
                if (!row.IsSALA_DESCRIPCIONNull()) q.SALA_DESCRIPCION = row.SALA_DESCRIPCION;

                list.Add(q);
            }
            return list;
        }

        public Int32 AtInternados_Hoja_Quirurgica_Guardar(AtInternacionHojaQuirirgico Hoja)
        {
            AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
            object ID = adapter.H2_At_Internados_HC_PRACTICAS_QUIRURGICAS_Guardar(Hoja.PRQ_ID, Convert.ToDateTime(Hoja.PRQ_FECHA), Convert.ToInt32(Hoja.PRQ_SOC_ID), Convert.ToInt32(Hoja.PRQ_DIAG_ID), Convert.ToInt32(Hoja.PRQ_ESP_ID), Convert.ToInt32(Hoja.PRQ_MEDICO_ID), Convert.ToInt32(Hoja.PRQ_CIRU_ID), Hoja.PRQ_ESQUEMA_OPE
                , Convert.ToInt32(Hoja.PRQ_SESION), Convert.ToInt32(Hoja.PRQ_USUARIO), Convert.ToInt32(Hoja.PRQ_CAMA_ID), Convert.ToInt32(Hoja.PRQ_GUA_ID));
            return Convert.ToInt32(ID);
        }

        public long Pase_Guardia_UTI_Guardar(Pase_Guardia_UTI datos)
        {
            try
            {
                AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
                object Pase_Guardia_Id = adapter.H2_GUARDIA_PASE_GUARDIA_UTI_GUARDAR(datos.Pase_Guardia_UTI_Id, datos.PacienteId, Convert.ToDateTime(datos.Fecha), datos.Cama, datos.DiagnosticoPresuntivo, datos.Antecedentes, datos.DiasUTI, datos.DatosQuirurgicos,
                    datos.DatosAP, datos.VentilacionMecanica, datos.Traqueostomia, datos.ModoVentilatorio, datos.DiasVentilacion, datos.RX, datos.ECG, datos.Alimentacion,
                    datos.OtrasImagenes, datos.Gases, datos.Laboratorio_DatosPositivos, datos.Infectologia, datos.Cultivos_Germen, datos.DiasATB, datos.Pendientes_Interconsultas,
                    datos.Pendientes_Estudios, datos.Novedades_del_dia, datos.UsuarioId, datos.InternacionId, datos.DiasAlimentacion, datos.Observaciones);
                if (Pase_Guardia_Id != null) return Convert.ToInt64(Pase_Guardia_Id.ToString());
                else return -1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Pase_Guardia_UTI_Grabar_Visto(long Pase_Guardia_UTI_Id, long UsuarioId)
        {
            try
            {
                AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
                adapter.H2_GUARDIA_PASE_GUARDIA_UTI_GUARDAR_VISTO(Pase_Guardia_UTI_Id, UsuarioId);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Pase_Guardia_UTI_Contar_DiasVentilacion(long InternacionId)
        {
            try
            {
                AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
                object Dias = adapter.H2_GUARDIA_PASE_GUARDIA_UTI_CONTAR_DIAS_VENT(InternacionId);
                if (Dias != null) return Convert.ToInt32(Dias.ToString());
                else return 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pase_Guardia_UTI Pase_Guardia_UTI_Cargar_Ultimo_Pase_NHC(long NHC)
        {
            try
            {
                Pase_Guardia_UTI plantilla = new Pase_Guardia_UTI();
                AtInternadosDALTableAdapters.H2_GUARDIA_PASE_GUARDIA_UTI_CARGAR_ULTIMO_PACIDTableAdapter adapter = new AtInternadosDALTableAdapters.H2_GUARDIA_PASE_GUARDIA_UTI_CARGAR_ULTIMO_PACIDTableAdapter();
                AtInternadosDAL.H2_GUARDIA_PASE_GUARDIA_UTI_CARGAR_ULTIMO_PACIDDataTable aTable = adapter.GetData(NHC);
                foreach (AtInternadosDAL.H2_GUARDIA_PASE_GUARDIA_UTI_CARGAR_ULTIMO_PACIDRow row in aTable.Rows)
                {
                    if (!row.IsAlimentacionNull())
                        plantilla.Alimentacion = row.Alimentacion;
                    else plantilla.Alimentacion = -1;
                    if (!row.IsAntecedentesNull())
                        plantilla.Antecedentes = row.Antecedentes;
                    else plantilla.Antecedentes = string.Empty;
                    if (!row.IsCamaNull())
                        plantilla.Cama = row.Cama;
                    else plantilla.Cama = string.Empty;
                    if (!row.IsCultivos_GermenNull())
                        plantilla.Cultivos_Germen = row.Cultivos_Germen;
                    else plantilla.Cultivos_Germen = string.Empty;
                    if (!row.IsDatosAPNull())
                        plantilla.DatosAP = row.DatosAP;
                    else plantilla.DatosAP = string.Empty;
                    if (!row.IsDatosQuirurgicosNull())
                        plantilla.DatosQuirurgicos = row.DatosQuirurgicos;
                    else plantilla.DatosQuirurgicos = string.Empty;
                    if (!row.IsDiagnosticoPresuntivoNull())
                        plantilla.DiagnosticoPresuntivo = row.DiagnosticoPresuntivo;
                    else plantilla.DiagnosticoPresuntivo = string.Empty;
                    if (!row.IsDiasATBNull())
                        plantilla.DiasATB = row.DiasATB;
                    else plantilla.DiasATB = string.Empty;
                    if (!row.IsDiasUTINull())
                        plantilla.DiasUTI = row.DiasUTI;
                    else plantilla.DiasUTI = 0;
                    if (!row.IsDiasVentilacionNull())
                        plantilla.DiasVentilacion = row.DiasVentilacion;
                    else plantilla.DiasVentilacion = 0;
                    if (!row.IsECGNull())
                        plantilla.ECG = row.ECG;
                    else plantilla.ECG = string.Empty;

                    plantilla.Estado = row.Estado;
                    plantilla.Fecha = row.Fecha.ToShortDateString();

                    if (!row.IsGasesNull())
                        plantilla.Gases = row.Gases;
                    else plantilla.Gases = string.Empty;

                    plantilla.Infectologia = row.Infectologia;

                    if (!row.IsLaboratorio_DatosPositivosNull())
                        plantilla.Laboratorio_DatosPositivos = row.Laboratorio_DatosPositivos;
                    else plantilla.Laboratorio_DatosPositivos = string.Empty;
                    if (!row.IsModoVentilatorioNull())
                        plantilla.ModoVentilatorio = row.ModoVentilatorio;
                    else plantilla.ModoVentilatorio = string.Empty;
                    if (!row.IsOtrasImagenesNull())
                        plantilla.OtrasImagenes = row.OtrasImagenes;
                    else plantilla.OtrasImagenes = string.Empty;

                    plantilla.PacienteId = row.PacienteId;
                    plantilla.Pase_Guardia_UTI_Id = row.Pase_Guardia_UTI_Id;

                    if (!row.IsPendientes_EstudiosNull())
                        plantilla.Pendientes_Estudios = row.Pendientes_Estudios;
                    else plantilla.Pendientes_Estudios = string.Empty;
                    if (!row.IsPendientes_InterconsultasNull())
                        plantilla.Pendientes_Interconsultas = row.Pendientes_Interconsultas;
                    else plantilla.Pendientes_Interconsultas = string.Empty;
                    if (!row.IsRXNull())
                        plantilla.RX = row.RX;
                    else plantilla.RX = string.Empty;

                    if (!row.IsNovedades_del_diaNull())
                        plantilla.Novedades_del_dia = row.Novedades_del_dia;
                    else plantilla.Novedades_del_dia = string.Empty;

                    plantilla.Traqueostomia = row.Traqueostomia;
                    plantilla.UsuarioId = row.UsuarioId;
                    plantilla.VentilacionMecanica = row.VentilacionMecanica;

                    plantilla.UsuarioNombre_Visto = row.UsuarioVisto;

                    if (!row.IsUsuarioId_VistoNull())
                        plantilla.UsuarioId_Visto = row.UsuarioId_Visto;
                    else plantilla.UsuarioId_Visto = 0;


                    if (!row.IsFechaSistema_VistoNull())
                        plantilla.FechaSistema_Visto = row.FechaSistema_Visto.ToShortDateString() + " " + row.FechaSistema_Visto.ToShortTimeString();
                    else plantilla.FechaSistema_Visto = string.Empty;

                    if (!row.IsDiasAlimentacionNull()) plantilla.DiasAlimentacion = row.DiasAlimentacion;
                    else plantilla.DiasAlimentacion = 0;

                    if (!row.IsObservacionesNull()) plantilla.Observaciones = row.Observaciones;
                    else plantilla.Observaciones = string.Empty;

                }
                return plantilla;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pase_Guardia_UTI Pase_Guardia_UTI_Listar(long Pase_Guardia_UTI_Id)
        {
            try
            {
                Pase_Guardia_UTI plantilla = new Pase_Guardia_UTI();
                AtInternadosDALTableAdapters.H2_GUARDIA_PASE_GUARDIA_UTI_LISTARTableAdapter adapter = new AtInternadosDALTableAdapters.H2_GUARDIA_PASE_GUARDIA_UTI_LISTARTableAdapter();
                AtInternadosDAL.H2_GUARDIA_PASE_GUARDIA_UTI_LISTARDataTable aTable = adapter.GetData(Pase_Guardia_UTI_Id);
                foreach (AtInternadosDAL.H2_GUARDIA_PASE_GUARDIA_UTI_LISTARRow row in aTable.Rows)
                {
                    if (!row.IsAlimentacionNull())
                        plantilla.Alimentacion = row.Alimentacion;
                    else plantilla.Alimentacion = -1;
                    if (!row.IsAntecedentesNull())
                        plantilla.Antecedentes = row.Antecedentes;
                    else plantilla.Antecedentes = string.Empty;
                    if (!row.IsCamaNull())
                        plantilla.Cama = row.Cama;
                    else plantilla.Cama = string.Empty;
                    if (!row.IsCultivos_GermenNull())
                        plantilla.Cultivos_Germen = row.Cultivos_Germen;
                    else plantilla.Cultivos_Germen = string.Empty;
                    if (!row.IsDatosAPNull())
                        plantilla.DatosAP = row.DatosAP;
                    else plantilla.DatosAP = string.Empty;
                    if (!row.IsDatosQuirurgicosNull())
                        plantilla.DatosQuirurgicos = row.DatosQuirurgicos;
                    else plantilla.DatosQuirurgicos = string.Empty;
                    if (!row.IsDiagnosticoPresuntivoNull())
                        plantilla.DiagnosticoPresuntivo = row.DiagnosticoPresuntivo;
                    else plantilla.DiagnosticoPresuntivo = string.Empty;
                    if (!row.IsDiasATBNull())
                        plantilla.DiasATB = row.DiasATB;
                    else plantilla.DiasATB = string.Empty;
                    if (!row.IsDiasUTINull())
                        plantilla.DiasUTI = row.DiasUTI;
                    else plantilla.DiasUTI = 0;
                    if (!row.IsDiasVentilacionNull())
                        plantilla.DiasVentilacion = row.DiasVentilacion;
                    else plantilla.DiasVentilacion = 0;
                    if (!row.IsECGNull())
                        plantilla.ECG = row.ECG;
                    else plantilla.ECG = string.Empty;

                    plantilla.Estado = row.Estado;
                    plantilla.Fecha = row.Fecha.ToShortDateString();

                    if (!row.IsGasesNull())
                        plantilla.Gases = row.Gases;
                    else plantilla.Gases = string.Empty;

                    plantilla.Infectologia = row.Infectologia;

                    if (!row.IsLaboratorio_DatosPositivosNull())
                        plantilla.Laboratorio_DatosPositivos = row.Laboratorio_DatosPositivos;
                    else plantilla.Laboratorio_DatosPositivos = string.Empty;
                    if (!row.IsModoVentilatorioNull())
                        plantilla.ModoVentilatorio = row.ModoVentilatorio;
                    else plantilla.ModoVentilatorio = string.Empty;
                    if (!row.IsOtrasImagenesNull())
                        plantilla.OtrasImagenes = row.OtrasImagenes;
                    else plantilla.OtrasImagenes = string.Empty;

                    plantilla.PacienteId = row.PacienteId;
                    plantilla.Pase_Guardia_UTI_Id = row.Pase_Guardia_UTI_Id;

                    if (!row.IsPendientes_EstudiosNull())
                        plantilla.Pendientes_Estudios = row.Pendientes_Estudios;
                    else plantilla.Pendientes_Estudios = string.Empty;
                    if (!row.IsPendientes_InterconsultasNull())
                        plantilla.Pendientes_Interconsultas = row.Pendientes_Interconsultas;
                    else plantilla.Pendientes_Interconsultas = string.Empty;
                    if (!row.IsRXNull())
                        plantilla.RX = row.RX;
                    else plantilla.RX = string.Empty;

                    if (!row.IsNovedades_del_diaNull())
                        plantilla.Novedades_del_dia = row.Novedades_del_dia;
                    else plantilla.Novedades_del_dia = string.Empty;



                    plantilla.Traqueostomia = row.Traqueostomia;
                    plantilla.UsuarioId = row.UsuarioId;
                    plantilla.VentilacionMecanica = row.VentilacionMecanica;
                    plantilla.UsuarioNombre_Visto = row.UsuarioVisto;
                    
                    if (!row.IsUsuarioId_VistoNull())
                        plantilla.UsuarioId_Visto = row.UsuarioId_Visto;
                    else plantilla.UsuarioId_Visto = 0;
                   

                    if (!row.IsFechaSistema_VistoNull())
                        plantilla.FechaSistema_Visto = row.FechaSistema_Visto.ToShortDateString() + " " + row.FechaSistema_Visto.ToShortTimeString();
                    else plantilla.FechaSistema_Visto = string.Empty;


                }
                return plantilla;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pase_Guardia_UTI_Lista> Pase_Guardia_UTI_Listar_Pases_del_Dia(DateTime Fecha)
        {
            try
            {
                List<Pase_Guardia_UTI_Lista> Lista_de_Pases = new List<Pase_Guardia_UTI_Lista>();
                AtInternadosDALTableAdapters.H2_AT_INTERNADOS_LISTADO_PASE_GUARDIA_UTI_EVOTableAdapter adapter = new AtInternadosDALTableAdapters.H2_AT_INTERNADOS_LISTADO_PASE_GUARDIA_UTI_EVOTableAdapter();
                AtInternadosDAL.H2_AT_INTERNADOS_LISTADO_PASE_GUARDIA_UTI_EVODataTable aTable = adapter.GetData(Fecha);
                foreach (AtInternadosDAL.H2_AT_INTERNADOS_LISTADO_PASE_GUARDIA_UTI_EVORow row in aTable.Rows)
                {
                    Pase_Guardia_UTI_Lista pase = new Pase_Guardia_UTI_Lista();
                    pase.Sala = row.Sala;
                    pase.Cama = row.Cama;
                    pase.Servicio = row.Servicio;
                    pase.Fecha = row.fecha.ToShortDateString();
                    pase.PacienteNombre = row.Paciente;
                    pase.InternacionId = row.internacionid;
                    pase.NHC = row.NHC;
                    pase.EvolucionId = row.id;
                    pase.Evolucion = row.evolucion;
                    Lista_de_Pases.Add(pase);
                }
                return Lista_de_Pases;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PaseCama> PaseCama_List_by_NroInternacion(long PaseCama_InternacionId)
        {
            try
            {
                List<PaseCama> list = new List<PaseCama>();
                AtInternadosDALTableAdapters.H2_At_Internados_PaseCama_List_by_NroInternacionTableAdapter adapter = new AtInternadosDALTableAdapters.H2_At_Internados_PaseCama_List_by_NroInternacionTableAdapter();
                AtInternadosDAL.H2_At_Internados_PaseCama_List_by_NroInternacionDataTable aTable = adapter.GetData(PaseCama_InternacionId);
                foreach (AtInternadosDAL.H2_At_Internados_PaseCama_List_by_NroInternacionRow row in aTable)
                    list.Add(new PaseCama(row.PaseCama_Id, row.PaseCama_Desc, row.PaseCama_Fecha.ToString("dd/MM/yyyy HH:ss"), PaseCama_InternacionId));
                return list;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long PaseCama_Insert(PaseCama objData)
        {
            try
            {
                AtInternadosDALTableAdapters.QueriesTableAdapter adapter = new AtInternadosDALTableAdapters.QueriesTableAdapter();
                object Id = adapter.H2_At_Internados_PaseCama(objData.PaseCama_Id, objData.PaseCama_Desc, objData.PaseCama_UsuarioId, objData.PaseCama_Baja, objData.PaseCama_InternacionId);
                if (Id != null)
                {
                    MensajesBLL m = new MensajesBLL();
                    m.MensajeEnviar(objData.PaseCama_Desc,1,"MOVIMIENTO DE CAMA","SISTEMAS"); //Mando msj para Admision, Grupo 1 es Admision (Ver Usuarios_Grupos)
                    return Convert.ToInt64(Id.ToString());
                }
                else return 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}