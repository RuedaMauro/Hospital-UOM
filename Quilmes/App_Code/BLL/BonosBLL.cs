using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BonosBLL
/// </summary>
namespace Hospital
{
public class BonosBLL 
    {
        public BonosBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public List<bonos_encabezado> Existe_Turno(long AfiliadoId)
        {
            BonosDALTableAdapters.H2_BONOS_TURNO_PROXIMOTableAdapter adapter = new BonosDALTableAdapters.H2_BONOS_TURNO_PROXIMOTableAdapter();
            BonosDAL.H2_BONOS_TURNO_PROXIMODataTable aTable = adapter.GetData(AfiliadoId);
            List<bonos_encabezado> lista = new List<bonos_encabezado>();
            foreach (BonosDAL.H2_BONOS_TURNO_PROXIMORow row in aTable.Rows)
            {
                bonos_encabezado be = new bonos_encabezado();
                be.especialidad = row.Especialidad;
                be.especialidadid = row.TurnoEspecialidadId;
                be.fecha = row.Fecha.ToShortDateString();
                be.hora = row.Fecha.ToShortTimeString();
                be.medico = row.Medico;
                be.medicoid = row.TurnoMedicoId;
                lista.Add(be);
            }
            return lista;
        }

        public List<bono_cajavale_conceptos> Bono_CajaVale_Conceptos_List()
        {
            List<bono_cajavale_conceptos> lista = new List<bono_cajavale_conceptos>();
            BonosDALTableAdapters.H2_BONO_CAJAVALE_LISTTableAdapter adapter = new BonosDALTableAdapters.H2_BONO_CAJAVALE_LISTTableAdapter();
            BonosDAL.H2_BONO_CAJAVALE_LISTDataTable aTable = adapter.GetData();
            foreach (BonosDAL.H2_BONO_CAJAVALE_LISTRow row in aTable.Rows)
            {
                bono_cajavale_conceptos be = new bono_cajavale_conceptos();
                be.id = row.Id;
                be.descripcion = row.Descripcion;
                lista.Add(be);
            }
            return lista;
        }

        public long Bono_CajaVale_CAB(bono_cajavale b) 
        {
            //Esp = 237 (Otros), Med = 80000553 (Desconocido), Doc = 378319 (Urgencia)
            BonosDALTableAdapters.QueriesTableAdapter adapter = new BonosDALTableAdapters.QueriesTableAdapter();
            try 
            {
                string ip = ((usuarios)HttpContext.Current.Session["Usuario"]).ip;
                object obj = adapter.H2_Bono_Insert(DateTime.Now.Date, 378319, false, null,true,0, 80000553, 237,false,false,false,(int)b.usuarioid, ip,null,null,string.Empty);
                if (obj != null) return Convert.ToInt64(obj.ToString());
                else throw new Exception("Error al generar bono cabecera.");
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long Bono_CajaVale_Insert(bono_cajavale b)
        {
            b.bonoid = Bono_CajaVale_CAB(b);
            BonosDALTableAdapters.QueriesTableAdapter adapter = new BonosDALTableAdapters.QueriesTableAdapter();
            try
            {
                object obj = adapter.H2_BONO_CAJAVALE_INSERT(b.bonoid, DateTime.Parse(b.fecha), b.concepto, b.importe, b.observaciones, b.usuarioid,b.bonoid_rel);
                if (obj != null) return Convert.ToInt64(obj.ToString());
                else throw new Exception("Error al guardar vale de caja.");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bonos_encabezado Cargar_Bono_por_Turno(int Nro_Turno)
        {

            BonosDALTableAdapters.H2_Bono_CargarDatos_por_TurnoTableAdapter adapter = new BonosDALTableAdapters.H2_Bono_CargarDatos_por_TurnoTableAdapter();
            BonosDAL.H2_Bono_CargarDatos_por_TurnoDataTable aTable = adapter.GetData(Nro_Turno);
            bonos_encabezado be = new bonos_encabezado();
            if (aTable.Rows.Count > 0)
            {
                be.cuil = aTable[0].cuil;
                be.documento = aTable[0].documento;
                be.documento_real = aTable[0].documento_real;
                be.apellido = aTable[0].apellido;
                if (!aTable[0].IsSeccionalNull()) be.seccional = aTable[0].Seccional;
                if (!aTable[0].IstelefonoNull()) be.telefono = aTable[0].telefono;
                if (!aTable[0].IsFecha_BajaNull()) be.fechabaja = aTable[0].Fecha_Baja.ToShortDateString();
                if (!aTable[0].IsNro_SeccionalNull()) be.nro_seccional = aTable[0].Nro_Seccional;
                be.fecha = aTable[0].TurnoFecha.ToShortDateString();
                be.hora = aTable[0].TurnoFecha.ToString("HH:mm:ss");
                be.medico = aTable[0].Medico;
                be.especialidad = aTable[0].Especialidad;
                be.comentario_turno = aTable[0].Comentario;
                if (!aTable[0].IsMotivoCancelacionIdNull()) be.motivo_cancelacion = aTable[0].MotivoCancelacionId;
                be.esconfirmado = aTable[0].EsConfirmado;
                if (!aTable[0].IsPasoporVentanillaNull()) be.pasoporventanilla = true; else be.pasoporventanilla = false;
                if (!aTable[0].Isfecha_nacimientoNull()) be.fecha_nacimiento = aTable[0].fecha_nacimiento;
                be.medicoid = aTable[0].MedicoId;
                be.especialidadid = aTable[0].EspecialidadId;
                be.OSId = aTable[0].OSId;
                be.ObraSocial = aTable[0].OS;
                if (!aTable[0].IsDiscapacidadNull())
                {
                    if (aTable[0].Discapacidad == 1)
                        be.Discapacidad = 1;
                    else
                        be.Discapacidad = 0;
                }
                else
                {
                    be.Discapacidad = 3;
                }

            }

            return be;

        }


        public string Nro_Reserva_Ahora()
        {
            string Resultado = "";
            BonosDALTableAdapters.QueriesTableAdapter adapter = new BonosDALTableAdapters.QueriesTableAdapter();
            try
            {
                object Resultados = adapter.H2_Nro_Bono_Reserva_Ahora().ToString();
                if (Resultados != null)
                {
                    Resultado = Resultados.ToString();
                    int Nro = Convert.ToInt32(Resultado) + 1;
                    if (Nro > 0)
                    {
                        Resultado = string.Format("{0}{1:D2}", GetLetterFromNumber(Nro / 100), (Nro % 100));
                    }
                    else
                    {
                        Resultado = "A01";
                    }
                }
                return Resultado;
            }
            catch
            {
                return "A01";
            }


        }

        private string GetLetterFromNumber(int columnNumber)
        {
            string columnName = Convert.ToChar(65 + columnNumber).ToString();
            return columnName;
        }

        public string GuardarBono(List<Confirmarturnos> Practicas, int Documento, bool EsPrimeraVez, string Verificado, bool EmiteComprobante, int AutorizanteId, 
            int MedicoId, int EspecialidadId, bool EsAtencionSinTurno, bool EsUrgencia, bool ReservaTurnoAhora, Int32 Usuario, string IP,int AutorizaBono,int MotivoAutorizaBono,
            string Observaciones)
        {
            
            DateTime Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00");

            BonosDALTableAdapters.QueriesTableAdapter adapter = new BonosDALTableAdapters.QueriesTableAdapter();

            Int32 Id = Convert.ToInt32(adapter.H2_Bono_Insert(Fecha, Documento, EsPrimeraVez, Verificado, EmiteComprobante, AutorizanteId, MedicoId, EspecialidadId,
                EsAtencionSinTurno, EsUrgencia, ReservaTurnoAhora, Usuario, IP, AutorizaBono, MotivoAutorizaBono,Observaciones));


            Hospital.BonosBLL B = new BonosBLL();
            long Doc = Documento;

            usuarios U = (usuarios)HttpContext.Current.Session["Usuario"];
            Estadisticas.Est_PacienteMovBLL E = new Estadisticas.Est_PacienteMovBLL();
            E.EstPacMov(Doc, 3, (Int32)U.id, "Nuevo Bono // Fecha: " + Fecha);


            adapter.H2_BonoPractica_Delete(Fecha, Id);
            foreach (Confirmarturnos practica in Practicas)
            {
                if (practica.Estado != 0)
                {
                    adapter.H2_BonoPractica_Insert(Fecha, Id, practica.PracticaId, Convert.ToDecimal(practica.Precio), Convert.ToDecimal(practica.PrecioReal));
                }
            }

            if (MotivoAutorizaBono == 6) BonoAcentarDeudaHC(Id, Documento); //Paciente sin dinero...

            return "id=" + Id + "&Fecha=" + Fecha.ToShortDateString() + " 00:00";
        }

        public void BonoAcentarDeudaHC(long NroBono, long PacienteId)
        {
            BonosDALTableAdapters.QueriesTableAdapter adapter = new BonosDALTableAdapters.QueriesTableAdapter();
            try
            {
                adapter.H2_BONO_ACENTAR_DEUDA_HC(NroBono, PacienteId);
            }
            catch (SqlException ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public List<rendicion_bono> RendicionImprimir(DateTime? desde, int nroCpteDesde, int nroCpteHasta, int usuario, string Terminal)
        {
            List<rendicion_bono> list = new List<rendicion_bono>();
            BonosDALTableAdapters.H2_Bono_RendicionImprimirTableAdapter adapter = new BonosDALTableAdapters.H2_Bono_RendicionImprimirTableAdapter();
            BonosDAL.H2_Bono_RendicionImprimirDataTable aTable = adapter.GetData(desde, nroCpteDesde, nroCpteHasta, usuario,Terminal);
            foreach (BonosDAL.H2_Bono_RendicionImprimirRow row in aTable)
            {
                rendicion_bono b = new rendicion_bono();
                if (!row.IsNroHCNull()) b.cuil = row.NroHC;
                if (!row.IsNroNull()) b.Nro = row.Nro;
                b.Bono_Id = row.Bono_Id;
                b.Fecha = row.Fecha.ToShortDateString();
                b.apellido = row.NombreYApellido;
                if (!row.IsNUsuarioNull()) b.Nombre_Usuario = row.NUsuario;
                b.Autorizantes = row.Autorizante;
                if (!row.IsImporteRealNull()) b.Importe = row.ImporteReal.ToString(); else b.Importe = "0";
                list.Add(b);
            }
            return list;
        }

        public List<bono_terminal> List_Terminales_Bonos()
        {
            List<bono_terminal> list = new List<bono_terminal>();
            BonosDALTableAdapters.H2_BONOS_LISTA_PCSTableAdapter adapter = new BonosDALTableAdapters.H2_BONOS_LISTA_PCSTableAdapter();
            BonosDAL.H2_BONOS_LISTA_PCSDataTable aTable = adapter.GetData();
            foreach (BonosDAL.H2_BONOS_LISTA_PCSRow row in aTable)
            {
                bono_terminal b = new bono_terminal();
                b.Ip = row.IP;
                b.Descripcion = row.Descripcion;
                list.Add(b);
            }
            return list;
        }


        public List<impresion_bono> Bono_Buscar(string Afiliado, Nullable<DateTime> Desde, Nullable<DateTime> Hasta, Nullable<int> NroComprobante, string nroHC, string PracticaIds)
        {

            List<impresion_bono> list = new List<impresion_bono>();
            BonosDALTableAdapters.H2_Bono_BuscarTableAdapter adapter = new BonosDALTableAdapters.H2_Bono_BuscarTableAdapter();
            BonosDAL.H2_Bono_BuscarDataTable aTable = adapter.GetData(Afiliado, Desde, Hasta, NroComprobante, nroHC, PracticaIds);
            foreach (BonosDAL.H2_Bono_BuscarRow row in aTable)
            {
                impresion_bono b = new impresion_bono();
                b.Bono_Id = row.Bono_Id;
                b.Nro = row.Id;
                b.Fecha = row.Fecha.ToShortDateString();
                b.cuil = row.NroHC;
                b.apellido = row.NombreYApellido;
                b.documento = row.NroDoc;
                b.Especialidad = row.Especialidad;
                if (!row.IsValorNull()) b.Valor = row.Valor;
                else b.Valor = 0;
                list.Add(b);
            }
            return list;
        }

        public List<impresion_bono> Bono_Buscar_Con_Cancelados(string Afiliado, Nullable<DateTime> Desde, Nullable<DateTime> Hasta, Nullable<int> NroComprobante, string nroHC, string PracticaIds)
        {
            List<impresion_bono> list = new List<impresion_bono>();
            BonosDALTableAdapters.H2_Bono_Buscar_Con_CanceladosTableAdapter adapter = new BonosDALTableAdapters.H2_Bono_Buscar_Con_CanceladosTableAdapter();
            BonosDAL.H2_Bono_Buscar_Con_CanceladosDataTable aTable = adapter.GetData(Afiliado, Desde, Hasta, NroComprobante, nroHC, PracticaIds);
            foreach (BonosDAL.H2_Bono_Buscar_Con_CanceladosRow row in aTable)
            {
                impresion_bono b = new impresion_bono();
                b.Bono_Id = row.Bono_Id;
                b.Nro = row.Id;
                b.Fecha = row.Fecha.ToShortDateString() + " " + row.Hora.Hours.ToString() + ":" + row.Hora.Minutes.ToString() + "hs.";
                //b.Fecha += " " + row.Fecha.ToShortTimeString();
                b.cuil = row.NroHC;
                b.apellido = row.NombreYApellido;
                b.documento = row.NroDoc;
                b.Especialidad = row.Especialidad;
                if (!row.IsValorNull()) b.Valor = row.Valor;
                else b.Valor = 0;
                b.Cancelado = row.EstaCancelado;
                list.Add(b);
            }
            return list;
        }

        public long Documento_Del_Bono(DateTime Fecha, int BonoId)
        {
            BonosDALTableAdapters.QueriesTableAdapter B = new BonosDALTableAdapters.QueriesTableAdapter();
            object R = B.H2_Documento_delBono(Fecha, BonoId);
            return Convert.ToInt64(R);
        }




        public bono_estado_usado EstadodelBono(long NroBono)
        {
            bono_estado_usado b = new bono_estado_usado();
            BonosDALTableAdapters.H2_Bono_EstadoTableAdapter adapter = new BonosDALTableAdapters.H2_Bono_EstadoTableAdapter();
            BonosDAL.H2_Bono_EstadoDataTable aTable = adapter.GetData(NroBono);
            if (aTable[0] != null)
            {
                if (!aTable[0].Isfecha_usadoNull()) { b.fecha = aTable[0].fecha_usado.ToString(); }
                b.id = aTable[0].bono_id;
                if (!aTable[0].IsusadoNull()) {
                    if (aTable[0].usado) { 
                        b.usado = true; 
                    }                    
                }
                else
                {
                    b.usado = false;
                }
            }
            return b;
        }



        public void bono_UsarBono_PorId(long NroBono, int Usuario)
        {
            BonosDALTableAdapters.QueriesTableAdapter B = new BonosDALTableAdapters.QueriesTableAdapter();
            B.H2_Bono_UsarBono_porID(NroBono, Usuario);
        }


        public bool EstadodelBonoProvi(string NroBono)
        {
            BonosDALTableAdapters.QueriesTableAdapter B = new BonosDALTableAdapters.QueriesTableAdapter();
            object Resultado = B.H2_Bono_Estado_Provi(NroBono);
            if (Resultado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public rendicion_bono BonoInfo(long NroBono)
        {
            BonosDALTableAdapters.H2_BONO_LIST_BY_IDTableAdapter adapter = new BonosDALTableAdapters.H2_BONO_LIST_BY_IDTableAdapter();
            try
            {
                BonosDAL.H2_BONO_LIST_BY_IDDataTable aTable = adapter.GetData(NroBono);
                rendicion_bono b = new rendicion_bono();
                foreach (BonosDAL.H2_BONO_LIST_BY_IDRow row in aTable)
                {
                    b.Fecha = row.Fecha.ToShortDateString();
                    b.Nombre_Usuario = row.Usuario;
                    b.Importe = row.Importe.ToString();
                }
                return b;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        public List<bono_practicas_por_usuarios> Bono_PracticasporUsuarios(long NHC, Nullable<DateTime> Desde, Nullable<DateTime> Hasta)
        {
            List<bono_practicas_por_usuarios> list = new List<bono_practicas_por_usuarios>();
            BonosDALTableAdapters.H2_Bonos_TotalesPracticasPorUsuariosTableAdapter adapter = new BonosDALTableAdapters.H2_Bonos_TotalesPracticasPorUsuariosTableAdapter();
            BonosDAL.H2_Bonos_TotalesPracticasPorUsuariosDataTable aTable = adapter.GetData(NHC, Desde, Hasta);
            foreach (BonosDAL.H2_Bonos_TotalesPracticasPorUsuariosRow row in aTable)
            {
                bono_practicas_por_usuarios b = new bono_practicas_por_usuarios();
                b.Documento = row.documento.ToString();
                b.Fecha = row.Fecha.ToShortDateString();
                b.NHC = row.cuil.ToString();
                b.Paciente = row.apellido;
                b.Practica = row.Practica;
                list.Add(b);
            }
            return list;
        }

    }
}