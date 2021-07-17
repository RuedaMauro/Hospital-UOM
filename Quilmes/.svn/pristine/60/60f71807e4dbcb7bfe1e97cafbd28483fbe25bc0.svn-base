using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Configuration;

/// <summary>
/// Summary description for GuardiaBLL
/// </summary>
namespace Hospital
{
    public class GuardiaBLL
    {
        public GuardiaBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string ToComaSeparatedString(List<string> aList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string aValue in aList)
            {
                sb.Append(aValue).Append(',');
            }
            if (sb.Length > 0)
                sb.Length = sb.Length - 1;
            return sb.ToString();
        }

        public List<pedidosenfermeria> Enfermeria_Cargar_Guardia(int MedicoId, int Usuario, bool Todos)
        {
            GuardiaDALTableAdapters.H2_Enfermeria_Cargar_Pedidos_Enfermeria_GuardiaTableAdapter adapter = new GuardiaDALTableAdapters.H2_Enfermeria_Cargar_Pedidos_Enfermeria_GuardiaTableAdapter();
            GuardiaDAL.H2_Enfermeria_Cargar_Pedidos_Enfermeria_GuardiaDataTable aTable = adapter.GetData(MedicoId, Usuario, Todos);

            List<pedidosenfermeria> Lista = new List<pedidosenfermeria>();

            foreach (GuardiaDAL.H2_Enfermeria_Cargar_Pedidos_Enfermeria_GuardiaRow row in aTable.Rows)
            {
                pedidosenfermeria p = new pedidosenfermeria();
                p.Fecha = row.Fecha.ToString("dd/MM/yyyy HH:mm:ss");
                p.MedicoId = row.medicoid;
                p.ConsultorioId = row.consultorioid;
                if (!row.IsPedidoNull()) { p.Pedido = row.Pedido; }
                if (!row.IsUsuarioIdNull()) { p.UsuarioId = row.UsuarioId; }
                if (!row.IsEstadoNull())
                {
                    p.Estado = "Entregado";
                    p.Clase = "success";
                }
                if (!row.IsFechaEntregadoNull()) { p.FechaEntregado = row.FechaEntregado.ToString("dd/MM/yyyy HH:mm:ss"); }


                Lista.Add(p);
            }

            return Lista;
        }

        public List<guardia> GuardiaListado(DateTime? FechaInicio, DateTime? FechaFinal, bool Especialidad, string Apellido, string EspecialidadId, int? Estado)
        {

            List<guardia> list = new List<guardia>();
            GuardiaDALTableAdapters.H2_Guardia_ListaTableAdapter adapter = new GuardiaDALTableAdapters.H2_Guardia_ListaTableAdapter();
            GuardiaDAL.H2_Guardia_ListaDataTable aTable = adapter.GetData(FechaInicio, FechaFinal, Especialidad, Apellido, EspecialidadId, Estado);
            foreach (GuardiaDAL.H2_Guardia_ListaRow row in aTable.Rows)
            {
                list.Add(CrearGuardiaItems(row));
            }
            return list;

        }

        public List<Farmacia_PPS_Det_List> GuardiaConsumo(DateTime Desde, DateTime Hasta)
        {

            List<Farmacia_PPS_Det_List> list = new List<Farmacia_PPS_Det_List>();
            GuardiaDALTableAdapters.H2_GUARDIA_CONSUMO_POR_FECHATableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_CONSUMO_POR_FECHATableAdapter();
            GuardiaDAL.H2_GUARDIA_CONSUMO_POR_FECHADataTable aTable = adapter.GetData(Desde, Hasta);
            foreach (GuardiaDAL.H2_GUARDIA_CONSUMO_POR_FECHARow row in aTable.Rows)
            {
                list.Add(CrearGuardiaConsumo(row));
            }
            return list;

        }

        private Farmacia_PPS_Det_List CrearGuardiaConsumo(GuardiaDAL.H2_GUARDIA_CONSUMO_POR_FECHARow row)
        {
            Farmacia_PPS_Det_List f = new Farmacia_PPS_Det_List();
            farmacia i = new farmacia();
            FarmaciaBLL f_ = new FarmaciaBLL();
            i = f_.Get_Insumo_by_Id(row.InsumoId);
            f.STO_MINIMO = i.STO_MINIMO;
            f.STO_CANTIDAD = i.STO_CANTIDAD;
            f.REM_NOMBRE = i.REM_NOMBRE;
            f.REM_GRAMAJE = i.REM_GRAMAJE;
            f.PRESENTACION = i.Presentacion;
            f.MEDIDA = i.Medida;
            f.DET_INS_ID = row.InsumoId.ToString();
            f.DET_CANTIDAD = row.Total.ToString();
            return f;
        }

        public List<Guardia_Box> GuardiaBoxesList(bool Estado)
        {

            List<Guardia_Box> list = new List<Guardia_Box>();
            GuardiaDALTableAdapters.H2_GUARDIA_BOX_LISTTableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_BOX_LISTTableAdapter();
            GuardiaDAL.H2_GUARDIA_BOX_LISTDataTable aTable = adapter.GetData(Estado);
            foreach (GuardiaDAL.H2_GUARDIA_BOX_LISTRow row in aTable.Rows)
            {
                list.Add(CreateRowFromBoxGuardia(row));
            }
            return list;

        }

        private Guardia_Box CreateRowFromBoxGuardia(GuardiaDAL.H2_GUARDIA_BOX_LISTRow row)
        {
            Guardia_Box g = new Guardia_Box();
            g.Box = row.Box;
            if (!row.IsEstadoNull())
                g.Estado = row.Estado;
            else g.Estado = false;
            g.Id = row.id;
            return g;
        }

        public List<guardia> GuardiaListadobyId(int Id)
        {

            List<guardia> list = new List<guardia>();
            GuardiaDALTableAdapters.H2_Guardia_Lista_ByIdTableAdapter adapter = new GuardiaDALTableAdapters.H2_Guardia_Lista_ByIdTableAdapter();
            GuardiaDAL.H2_Guardia_Lista_ByIdDataTable aTable = adapter.GetData(Id);
            foreach (GuardiaDAL.H2_Guardia_Lista_ByIdRow row in aTable.Rows)
            {
                list.Add(CrearGuardiaItems(row));
            }
            return list;

        }

        public void EntregarGuardiaEnfermeria(DateTime Fecha, int MedicoId, int Usuario, int ConsultorioId, int Estado)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            try
            {
                adapter.H2_Enfermeria_Entregar_Guardia(MedicoId, ConsultorioId, Fecha, Estado, Usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public List<pedidosenfermeria> Enfermeria_Cargar_Todos_Guardia(int MedicoId, int ConsultorioId, int Cuales)
        {
            GuardiaDALTableAdapters.H2_Enfermeria_Pedidos_CargarTodos_GuardiaTableAdapter adapter = new GuardiaDALTableAdapters.H2_Enfermeria_Pedidos_CargarTodos_GuardiaTableAdapter();
            try
            {
                DateTime Fecha = DateTime.Now;
                GuardiaDAL.H2_Enfermeria_Pedidos_CargarTodos_GuardiaDataTable aTable = adapter.GetData(MedicoId, ConsultorioId, Fecha, Cuales);

                List<pedidosenfermeria> Lista = new List<pedidosenfermeria>();

                foreach (GuardiaDAL.H2_Enfermeria_Pedidos_CargarTodos_GuardiaRow row in aTable.Rows)
                {
                    pedidosenfermeria p = new pedidosenfermeria();
                    p.Fecha = row.Fecha.ToString("dd/MM/yyyy HH:mm:ss");
                    p.MedicoId = row.medicoid;
                    p.ConsultorioId = row.consultorioid;
                    if (!row.IsPedidoNull()) { p.Pedido = row.Pedido; }
                    if (!row.IsUsuarioIdNull()) { p.UsuarioId = row.UsuarioId; }
                    if (!row.IsEstadoNull())
                    {
                        p.Estado = "Entregado";
                        p.Clase = "success";
                    }
                    else
                    {
                        p.Clase = "warning";
                    }
                    if (!row.IsFechaEntregadoNull()) { p.FechaEntregado = row.FechaEntregado.ToString("dd/MM/yyyy HH:mm:ss"); }
                    p.Consultorio = row.ConsultorioNombre;
                    p.Medico = row.Medico;
                    Lista.Add(p);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<medicos> MedicosGuardiabyEsp(int Especialidad)
        {

            List<medicos> list = new List<medicos>();
            GuardiaDALTableAdapters.H2_Guardia_ListaMedicos_EspecialidadTableAdapter adapter = new GuardiaDALTableAdapters.H2_Guardia_ListaMedicos_EspecialidadTableAdapter();
            GuardiaDAL.H2_Guardia_ListaMedicos_EspecialidadDataTable aTable = adapter.GetData(Especialidad);
            foreach (GuardiaDAL.H2_Guardia_ListaMedicos_EspecialidadRow row in aTable.Rows)
            {
                list.Add(CrearMedicosGuardia(row));
            }
            return list;

        }

        public List<Boxes> BoxesList(string FechaIni, string HoraIni, string FechaFin, string HoraFin)
        {

            List<Boxes> list = new List<Boxes>();
            GuardiaDALTableAdapters.H2_Guardia_Box_LibresTableAdapter adapter = new GuardiaDALTableAdapters.H2_Guardia_Box_LibresTableAdapter();
            GuardiaDAL.H2_Guardia_Box_LibresDataTable aTable = adapter.GetData(DateTime.Parse(FechaIni), DateTime.Parse(FechaFin), HoraIni, HoraFin);
            foreach (GuardiaDAL.H2_Guardia_Box_LibresRow row in aTable.Rows)
            {
                list.Add(CrearBoxes(row));
            }
            return list;

        }

        public List<Guardia_Enfermeria> EnfermeriaList(string FechaIni, int Estado)
        {

            List<Guardia_Enfermeria> list = new List<Guardia_Enfermeria>();
            GuardiaDALTableAdapters.H2_GUARDIA_ENFERMERIA_LISTTableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_ENFERMERIA_LISTTableAdapter();
            DateTime Fecha;
            if (!string.IsNullOrEmpty(FechaIni)) Fecha = DateTime.Parse(FechaIni);
            else Fecha = DateTime.MinValue;
            GuardiaDAL.H2_GUARDIA_ENFERMERIA_LISTDataTable aTable = adapter.GetData(Fecha,Estado);
            foreach (GuardiaDAL.H2_GUARDIA_ENFERMERIA_LISTRow row in aTable.Rows)
            {
                list.Add(CrearGuardiaEnfermeria(row));
            }
            return list;

        }

        public int Save(int? BonoId, string NHC, int? MedicoId, int EspecialidadId, DateTime? FechaBono, int? id, int Box, int? MEgreso, int? Diagnostico, int? IC10, bool? Accidente, int? MotivoAccidenteId, string Obs, int? Espfinal, int Estado)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            try
            {
                object Resultado = adapter.H2_Guardia_Inicia(BonoId, Convert.ToInt64(NHC), MedicoId, EspecialidadId, FechaBono, id, Box, MEgreso, Diagnostico, IC10, Accidente, MotivoAccidenteId, Obs, Espfinal, Estado);
                if (Resultado != null) return Convert.ToInt32(Resultado);
                else throw new Exception("Error al guardar guardia.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Atencion_Save(Guardia_Atencion g)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            try
            {
                object Resultado = adapter.H2_GUARDIA_ATENCION_SAVE(g.IdGuardia, g.NHC, g.MotivoConsulta, g.Evolucion, g.ICD10, g.Laboratorio, g.Rx, g.Tac, g.Ecografia, g.Otros, g.Interconsulta, g.IndicacionesEnfermeria, g.MotivoEgreso, g.Policial, g.Internado,g.ART);
                if (Resultado != null) return Convert.ToInt32(Resultado);
                else throw new Exception("Error al guardar atención en guardia.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Enfermeria_Guardar(pedidosenfermeria p)
        {
            DateTime fecha;
            if (!DateTime.TryParse(p.Fecha, out fecha)) fecha = DateTime.Now;
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            try
            {
                object Resultado = adapter.H2_Enfermeria_Pedir_Guardia(p.MedicoId, p.ConsultorioId, p.Pedido, fecha, p.UsuarioId);
                if (Resultado != null) return Convert.ToInt32(Resultado);
                else throw new Exception("Error al guardar pedido a enfermeria.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Enfermeria_Borrar(int Medico, string Fecha, int Usuario)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            try
            {
                object Resultado = adapter.H2_Enfermeria_Borrar_Pedidos_Guardia(Medico, DateTime.Parse(Fecha),Usuario);
                if (Resultado != null) return Convert.ToInt32(Resultado);
                else throw new Exception("Error al eliminar pedido a enfermeria.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Historial(string Texto, int? MedicoId, string NHC, int? Protocolo, int GuardiaId)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_Guardia_Historial(Texto, MedicoId, Convert.ToInt64(NHC), Protocolo, GuardiaId);
        }

        public long MedicoId_by_Usuario(long UsuarioId)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            try
            {
                object id = adapter.H2_GUARDIA_MEDICOID_BY_USER(UsuarioId);
                if (id != null) return Convert.ToInt64(id.ToString());
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Guardia_Plantilla_Med_Delete()
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_Guardia_Plantilla_Med_Delete();
        }

        public void Guardia_Plantilla_Prac_Delete()
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_GUARDIA_PLANTILLA_PRAC_DELETE();
        }

        public void Guardia_Med_Delete(int Id)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_GUARDIA_MEDICAMENTOS_DELETE(Id);
        }

        public void Ausente(int? Id)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_Guardia_Ausente(Id);
        }

        public void OcuparBox(int? Box, int? Id)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_Guardia_Ocupar_Box(Id, Box);
        }

        public void BoxDelete(int Id)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_GUARDIA_BOX_DELETE(Id);
        }

        public void CambiarEstado(int Id, bool Estado)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_GUARDIA_BOX_CAMBIAR_EST(Id,Estado);
        }

        public void BoxGuardar(int Id, string Box)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_GUARDIA_BOX_GUARDAR(Id, Box);
        }

        private Boxes CrearBoxes(GuardiaDAL.H2_Guardia_Box_LibresRow row)
        {
            Boxes b = new Boxes();
            b.IDBOX = row.id;
            b.NOMBREBOX = row.Box;
            return b;
        }

        private medicos CrearMedicosGuardia(GuardiaDAL.H2_Guardia_ListaMedicos_EspecialidadRow row)
        {
            medicos m = new medicos();
            m.Id = row.Id;
            m.Medico = row.ApellidoYNombre;
            return m;
        }

        private Guardia_Enfermeria CrearGuardiaEnfermeria(GuardiaDAL.H2_GUARDIA_ENFERMERIA_LISTRow row)
        {
            Guardia_Enfermeria g = new Guardia_Enfermeria();
            
            g.Afiliado = row.apellido;
            if (!row.IsBoxNull())
                g.Box = row.Box.ToString();
            else g.Box = "ENF";
            g.Fecha = row.Fecha.ToString();
            g.IdGuardia = Convert.ToInt32(row.id);
            if (!row.IsIndicacionesEnfermeriaNull())
            g.Indicaciones = row.IndicacionesEnfermeria;
            g.Medico = row.ApellidoYNombre;
            if (!row.IsNHCNull())
            g.NHC = Convert.ToInt64(row.NHC);
            g.Practica = row.Practica;
            if (!row.IsEstadoNull())
            g.Estado = row.Estado.ToString();
            if (!row.IsFechaEnfermeriaNull())
                g.FechaEntrega = row.FechaEnfermeria.ToString();
            else g.FechaEntrega = string.Empty;
            return g;
        }

        private guardia CrearGuardiaItems(GuardiaDAL.H2_Guardia_Lista_ByIdRow row)
        {
            guardia g = new guardia();

            if (!row.IsidNull())
                g.ID = Convert.ToInt32(row.id);

            if (!row.IsBonoNull())
                g.HORA = row.Bono.ToString().Substring(0, 5);

            if (!row.IsRecepcionoNull())
            { g.RECEPCIONO = row.Recepciono.ToString("HH:mm"); }
            else
            {
                g.RECEPCIONO = "";
            }


            if (!row.IsAtencionNull())
                g.ATENCION = row.Atencion.ToString("HH:mm");
            else g.ATENCION = "";

            if (!row.IsNHCNull())
                g.NHC = row.NHC.ToString();

            if (!row.IsapellidoNull())
                g.APELLIDO = row.apellido;

            if (!row.IsmedicoidNull())
                g.MEDICOID = row.medicoid;

            if (!row.IsApellidoYNombreNull())
                g.MEDICONOMBRE = row.ApellidoYNombre;
            else g.MEDICONOMBRE = "";

            if (!row.IsEstadoNull())
            {
                switch (row.Estado)
                {
                    case 1: { g.ESTADO = "En Consultorio"; break; }
                    case 2: { g.ESTADO = "Finalizado"; break; }
                    case 3: { g.ESTADO = "Transito"; break; }
                    case 4: { g.ESTADO = "En Observación"; break; }
                    case 99: { g.ESTADO = "Ausente"; break; }
                }
            }
            else
            {
                g.ESTADO = "En Espera";
            }


            g.ESPECIALIDADID = row.Especialidadid;
            g.ESPECIALIDAD = row.Especialidad;

            g.FECHA = row.Fecha.ToString("dd/MM/yy");

            g.BONOID = row.BonoId;

            if (!row.IsMotivoEgresoNull())
                g.MOTIVOEGRESO = Convert.ToInt32(row.MotivoEgreso);

            if (!row.IsDiagnosticoNull())
                g.DIAGNOSTICO = row.Diagnostico;

            if (row.EsUrgencia)
            { g.ESGUARDIA = "Si"; }
            else
            { g.ESGUARDIA = ""; }

            return g;

        }

        private guardia CrearGuardiaItems(GuardiaDAL.H2_Guardia_ListaRow row)
        {
            guardia g = new guardia();

            if (!row.IsidNull())
                g.ID = Convert.ToInt32(row.id);

            if (!row.IsBonoNull())
                g.HORA = row.Bono.ToString().Substring(0, 5);

            if (!row.IsRecepcionoNull())
            { g.RECEPCIONO = row.Recepciono.ToString("HH:mm"); }
            else
            {
                g.RECEPCIONO = "";
            }


            if (!row.IsAtencionNull())
                g.ATENCION = row.Atencion.ToString("HH:mm");
            else g.ATENCION = "";

            if (!row.IsNHCNull())
                g.NHC = row.NHC.ToString();

            if (!row.IsapellidoNull())
                g.APELLIDO = row.apellido;

            if (!row.IsmedicoidNull())
                g.MEDICOID = row.medicoid;

            if (!row.IsApellidoYNombreNull())
                g.MEDICONOMBRE = row.ApellidoYNombre;
            else g.MEDICONOMBRE = "";

            if (!row.IsEstadoNull())
            {
                switch (row.Estado)
                {
                    case 0: { g.ESTADO = "Espera"; break; }
                    case 1: { g.ESTADO = "Llamado"; break; }
                    case 2: { g.ESTADO = "Atendido"; break; }
                    case 3: { g.ESTADO = "Transito"; break; }
                    case 4: { g.ESTADO = "En Observación"; break; }
                    case 99: { g.ESTADO = "Ausente"; break; }
                }
            }
            else
            {
                g.ESTADO = "Espera";
            }


            g.ESPECIALIDADID = row.Especialidadid;
            g.ESPECIALIDAD = row.Especialidad;

            //g.FECHA = row.Fecha.ToString("dd/MM/yy");
            g.FECHA = row.Fecha.ToString("dd/MM/yy HH:mm");

            g.BONOID = row.BonoId;

            if (!row.IsMotivoEgresoNull())
                g.MOTIVOEGRESO = Convert.ToInt32(row.MotivoEgreso);

            if (!row.IsDiagnosticoNull())
                g.DIAGNOSTICO = row.Diagnostico;

            if (row.EsUrgencia)
            { g.ESGUARDIA = "Si"; }
            else
            { g.ESGUARDIA = ""; }

            g.BOX = row.Box;
            return g;

        }

        public List<especialidades> Especialidades_Lista(int Todas)
        {
            List<especialidades> lista = new List<especialidades>();
            GuardiaDALTableAdapters.H2_ESPECIALIDAD_LIST_GUARDIATableAdapter adapter = new GuardiaDALTableAdapters.H2_ESPECIALIDAD_LIST_GUARDIATableAdapter();
            GuardiaDAL.H2_ESPECIALIDAD_LIST_GUARDIADataTable aTable = adapter.GetData(Todas);

            foreach (GuardiaDAL.H2_ESPECIALIDAD_LIST_GUARDIARow row in aTable.Rows)
            {
                especialidades e = new especialidades();
                e.Id = row.Id;
                e.Especialidad = row.Descripcion;
                lista.Add(e);
            }

            return lista;
        }

        public List<MotivoEgreso_Guardia> List_Egreso()
        {
            List<MotivoEgreso_Guardia> lista = new List<MotivoEgreso_Guardia>();
            GuardiaDALTableAdapters.H2_GUARDIA_EGRESO_LISTTableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_EGRESO_LISTTableAdapter();
            GuardiaDAL.H2_GUARDIA_EGRESO_LISTDataTable aTable = adapter.GetData();
            foreach (GuardiaDAL.H2_GUARDIA_EGRESO_LISTRow row in aTable.Rows)
            {
                lista.Add(CreateFromRow_MotivoEgreso(row));
            }
            return lista;
        }

        private MotivoEgreso_Guardia CreateFromRow_MotivoEgreso(GuardiaDAL.H2_GUARDIA_EGRESO_LISTRow row)
        {
            MotivoEgreso_Guardia m = new MotivoEgreso_Guardia();
            m.Id = row.id;
            if (!row.IsmotivoNull())
            m.Motivo = row.motivo;
            return m;
        }

        public List<Guardia_Plantilla_Med> List_Plantilla_Med()
        {
            List<Guardia_Plantilla_Med> lista = new List<Guardia_Plantilla_Med>();
            GuardiaDALTableAdapters.H2_Guardia_Plantilla_Med_ListTableAdapter adapter = new GuardiaDALTableAdapters.H2_Guardia_Plantilla_Med_ListTableAdapter();
            GuardiaDAL.H2_Guardia_Plantilla_Med_ListDataTable aTable = adapter.GetData();
            foreach (GuardiaDAL.H2_Guardia_Plantilla_Med_ListRow row in aTable.Rows)
            {
                lista.Add(CreateFromRowPlantillaMed(row));
            }
            return lista;
        }

        public List<Guardia_Plantilla_Prac> List_Plantilla_Prac()
        {
            List<Guardia_Plantilla_Prac> lista = new List<Guardia_Plantilla_Prac>();
            GuardiaDALTableAdapters.H2_GUARDIA_PLANTILLA_PRAC_LISTTableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_PLANTILLA_PRAC_LISTTableAdapter();
            GuardiaDAL.H2_GUARDIA_PLANTILLA_PRAC_LISTDataTable aTable = adapter.GetData();
            foreach (GuardiaDAL.H2_GUARDIA_PLANTILLA_PRAC_LISTRow row in aTable.Rows)
            {
                lista.Add(CreateFromRowPlantillaPrac(row));
            }
            return lista;
        }

        public void List_Plantilla_Med_Insert(Guardia_Plantilla_Med g)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_Guardia_Plantilla_Med_Insert(g.Id, g.Medicamento, g.Monodroga, g.Cantidad);
        }

        public void Insert_Guardia_Medicamentos(Guardia_Medicamentos g)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_Guardia_Medicamentos_Agregar(g.IdGuardia, g.InsumoId, g.Cantidad, g.PedidoFarmaciaId);
        }

        public void Insert_Guardia_Practicas(Guardia_Plantilla_Prac g, int GuardiaId)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_Guardia_Practicas_Agregar(Convert.ToInt64(GuardiaId), Convert.ToInt32(g.Codigo), g.Cantidad);
        }

          public void Delete_Guardia_Practicas(int GuardiaId)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_GUARDIA_PRACTICA_DELETE(Convert.ToInt64(GuardiaId));
        }

        public void List_Plantilla_Prac_Insert(Guardia_Plantilla_Prac g)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            adapter.H2_GUARDIA_PLANTILLA_PRAC_INSERT(g.Codigo, g.Descripcion, g.Cantidad);
        }

        public int Insert_Pedido_Cab(Guardia_Pedido_Medicamentos f)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_GUARDIA_INSERT_PEDIDOS_CAB(f.Servicio_Id, f.NHC, f.Usuario_Id, f.GuardiaId);
            if (Id != null)
                return Convert.ToInt32(Id.ToString());
            else return -1;
        }

        public void Insert_Pedido_Det(Farmacia_Pedido_Pac_Det f, int GuardiaId)
        {
            GuardiaDALTableAdapters.QueriesTableAdapter adapter = new GuardiaDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_GUARDIA_INSERT_PEDIDOS_DET(f.Pedido_Id, f.Insumo_Id, f.Cantidad, f.Usuario_Id,GuardiaId);
        }

        public List<Guardia_Plantilla_Prac> List_Practicas_byId(long GuardiaId)
        {
            List<Guardia_Plantilla_Prac> lista = new List<Guardia_Plantilla_Prac>();
            GuardiaDALTableAdapters.H2_GUARDIA_PRACTICA_BYIDTableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_PRACTICA_BYIDTableAdapter();
            GuardiaDAL.H2_GUARDIA_PRACTICA_BYIDDataTable aTable = adapter.GetData(GuardiaId);
            foreach (GuardiaDAL.H2_GUARDIA_PRACTICA_BYIDRow row in aTable.Rows)
            {
                lista.Add(CreateFromRowPlantillaPracticabyId(row));
            }
            return lista;
        }

        public List<Guardia_Plantilla_Med> List_Medicamentos_byId(long GuardiaId)
        {
            List<Guardia_Plantilla_Med> lista = new List<Guardia_Plantilla_Med>();
            GuardiaDALTableAdapters.H2_GUARDIA_MEDICAMENTOS_BYIDTableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_MEDICAMENTOS_BYIDTableAdapter();
            GuardiaDAL.H2_GUARDIA_MEDICAMENTOS_BYIDDataTable aTable = adapter.GetData(GuardiaId);
            foreach (GuardiaDAL.H2_GUARDIA_MEDICAMENTOS_BYIDRow row in aTable.Rows)
            {
                lista.Add(CreateFromRowPlantillaMedbyId(row));
            }
            return lista;
        }

        public List<HistorialGuardia> List_Historial_Guardia(string FDesde, string FHasta, int MedicoId, string NHC)
        {
            List<HistorialGuardia> lista = new List<HistorialGuardia>();
            GuardiaDALTableAdapters.H2_Guardia_Historial_ListTableAdapter adapter = new GuardiaDALTableAdapters.H2_Guardia_Historial_ListTableAdapter();
            DateTime Desde, Hasta;
            long HC;
            if (!string.IsNullOrEmpty(FDesde)) Desde = DateTime.Parse(FDesde);
            else Desde = DateTime.MinValue;
            if (!string.IsNullOrEmpty(FHasta)) Hasta = DateTime.Parse(FHasta);
            else Hasta = DateTime.MaxValue;
            if (!string.IsNullOrEmpty(NHC)) HC = Convert.ToInt64(NHC);
            else HC = 0;
            GuardiaDAL.H2_Guardia_Historial_ListDataTable aTable = adapter.GetData(Desde, Hasta, MedicoId, HC);
            foreach (GuardiaDAL.H2_Guardia_Historial_ListRow row in aTable.Rows)
            {
                lista.Add(CreateFromRowHistorial(row));
            }
            return lista;
        }

        public Guardia_Atencion List_GuardiaAtencionbyId(int GuardiaId)
        {
            Guardia_Atencion g = new Guardia_Atencion();
            GuardiaDALTableAdapters.H2_GUARDIA_ATENCION_LIST_BYIDTableAdapter adapter = new GuardiaDALTableAdapters.H2_GUARDIA_ATENCION_LIST_BYIDTableAdapter();
            GuardiaDAL.H2_GUARDIA_ATENCION_LIST_BYIDDataTable aTable = adapter.GetData(GuardiaId);
            foreach (GuardiaDAL.H2_GUARDIA_ATENCION_LIST_BYIDRow row in aTable.Rows)
            {
               g = CreateFromRowGuardiaAtencion(row);
            }
            return g;
        }

        private Guardia_Atencion CreateFromRowGuardiaAtencion(GuardiaDAL.H2_GUARDIA_ATENCION_LIST_BYIDRow row)
        {
            Guardia_Atencion g = new Guardia_Atencion();
            if (!row.IsEcografiaNull())
            g.Ecografia = row.Ecografia;
            if (!row.IsEvolucionNull())
            g.Evolucion = row.Evolucion;
            g.Fecha = row.Fecha.ToString();
            g.ICD10 = row.ICD10;
            g.IdGuardia = row.IdGuardia;
            if (!row.IsIndicacionesEnfermeriaNull())
            g.IndicacionesEnfermeria = row.IndicacionesEnfermeria;
            if (!row.IsInterconsultaNull())
            g.Interconsulta = row.Interconsulta;
            if (!row.IsInternadoNull())
            g.Internado = row.Internado;
            if (!row.IsLaboratorioNull())
            g.Laboratorio = row.Laboratorio;
            g.MotivoConsulta = row.MotivoConsulta;
            g.MotivoEgreso = row.MotivoEgreso;
            g.NHC = row.NHC;
            if (!row.IsOtrosNull())
            g.Otros = row.Otros;
            if (!row.IsPolicialNull())
            g.Policial = row.Policial;
            if (!row.IsRxNull())
            g.Rx = row.Rx;
            if (!row.IsTacNull())
            g.Tac = row.Tac;
            if (!row.IsICD10DescNull())
            g.ICD10_Desc = row.ICD10Desc;
            if (!row.IsARTNull())
                g.ART = row.ART;
            else g.ART = false;

            return g;
        }


        private HistorialGuardia CreateFromRowHistorial(GuardiaDAL.H2_Guardia_Historial_ListRow row)
        {
            HistorialGuardia g = new HistorialGuardia();
            
            g.medico = row.ApellidoYNombre;
            if(!row.IsFechaNull())
            g.fecha = row.Fecha.ToString();
            g.id = Convert.ToInt32(row.id);
            if(!row.IsProtocoloNull())
            g.protocolo = row.Protocolo;
            if (!row.IsMedicoIDNull())
            g.medicoid = row.MedicoID;
            if(!row.IsNHCNull())
            g.nhc = row.NHC;
            if(!row.IsHistorialNull())
            g.texto = row.Historial;
            return g;
        }

        private Guardia_Plantilla_Med CreateFromRowPlantillaMedbyId(GuardiaDAL.H2_GUARDIA_MEDICAMENTOS_BYIDRow row)
        {
            Guardia_Plantilla_Med g = new Guardia_Plantilla_Med();
            if (!row.IsCantidad_MedicamentoNull())
                g.Cantidad = Convert.ToInt32(row.Cantidad_Medicamento);
            else g.Cantidad = 0;
            if (!row.IsCodigo_MedicamentoNull())
                g.Id = Convert.ToInt32(row.Codigo_Medicamento);
            else g.Id = 0;
            if(!row.IsMedicamentoNull())
            g.Medicamento = row.Medicamento;
            if (!row.IsMonodrogaNull())
            g.Monodroga = row.Monodroga;
            
            return g;
        }

        private Guardia_Plantilla_Prac CreateFromRowPlantillaPracticabyId(GuardiaDAL.H2_GUARDIA_PRACTICA_BYIDRow row)
        {
            Guardia_Plantilla_Prac g = new Guardia_Plantilla_Prac();
            g.Codigo = row.Codigo_Practica;
            if (!row.IsCantidadNull())
                g.Cantidad = row.Cantidad;
            else g.Cantidad = 0;
            g.Descripcion = row.Descripcion;
            return g;
        }

        private Guardia_Plantilla_Med CreateFromRowPlantillaMed(GuardiaDAL.H2_Guardia_Plantilla_Med_ListRow row)
        {
            Guardia_Plantilla_Med g = new Guardia_Plantilla_Med();
            g.Id = (int)row.IdInsumo;
            if (!row.IsCantidadNull())
                g.Cantidad = (int)row.Cantidad;
            else g.Cantidad = 0;
            if (!row.IsMedicamentoNull())
            g.Medicamento = row.Medicamento;
            if (!row.IsMonodrogaNull())
            g.Monodroga = row.Monodroga;
            return g;
        }

        private Guardia_Plantilla_Prac CreateFromRowPlantillaPrac(GuardiaDAL.H2_GUARDIA_PLANTILLA_PRAC_LISTRow row)
        {
            Guardia_Plantilla_Prac g = new Guardia_Plantilla_Prac();
            g.Codigo = row.Codigo;
            if (!row.IsPracticaNull())
            g.Descripcion = row.Practica;
            g.Cantidad = row.Cantidad;
            return g;
        }

        public List<Farmacia_PPS_Det_List> ListPlantillaforPedido()
        {
            List<Farmacia_PPS_Det_List> list = new List<Farmacia_PPS_Det_List>();
            GuardiaDALTableAdapters.H2_Guardia_PPS_PlantillaInsumos_ListTableAdapter adapter = new GuardiaDALTableAdapters.H2_Guardia_PPS_PlantillaInsumos_ListTableAdapter();
            GuardiaDAL.H2_Guardia_PPS_PlantillaInsumos_ListDataTable aTable = adapter.GetData();
            foreach (GuardiaDAL.H2_Guardia_PPS_PlantillaInsumos_ListRow row in aTable.Rows)
            {
                list.Add(CreateFromRowListPlantillaforPedido(row));
            }
            return list;
        }

        private Farmacia_PPS_Det_List CreateFromRowListPlantillaforPedido(GuardiaDAL.H2_Guardia_PPS_PlantillaInsumos_ListRow row)
        {
            Farmacia_PPS_Det_List d = new Farmacia_PPS_Det_List();
            if (!row.IsCantidadNull()) d.DET_CANTIDAD = row.Cantidad.ToString();
            if (!row.IsMedicamentoNull()) d.REM_NOMBRE = row.Medicamento;
            if (!row.IsMinimoNull()) d.STO_MINIMO = row.Minimo.ToString();
            if (!row.IsStockNull()) d.STO_CANTIDAD = row.Stock.ToString();
            d.DET_INS_ID = row.IdInsumo.ToString();
            return d;
        }
    }
}