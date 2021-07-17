using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Autorizaciones
/// </summary>
/// 
namespace Hospital
{
    public class Autorizaciones
    {
        public Autorizaciones()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public List<especialidades> Traer_Especialidades_Combo(int id)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Especilidades_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Especilidades_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Especilidades_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Especilidades_ComboDataTable();
            tabla = adapter.GetData(id);
            List<especialidades> lista = new List<especialidades>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Especilidades_ComboRow row in tabla.Rows)
            {
                especialidades esp = new especialidades();
                esp.Especialidad = row.especialidad;
                esp.Id = row.id;
                lista.Add(esp);
            }
            return lista;
        }
        public List<especialidades> Traer_Especialidades_ComboDT(int id)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Especilidades_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Especilidades_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Especilidades_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Especilidades_ComboDataTable();
            tabla = adapter.GetData(id);
            List<especialidades> lista = new List<especialidades>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Especilidades_ComboRow row in tabla.Rows)
            {
                especialidades esp = new especialidades();
                esp.Especialidad = row.especialidad;
                esp.Id = row.id;
                lista.Add(esp);
            }
            return lista;
        }
        public List<medicos> Traer_Medicos_Combo(int id)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Medicos_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Medicos_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Medicos_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Medicos_ComboDataTable();
            tabla = adapter.GetData(id);
            List<medicos> lista = new List<medicos>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Medicos_ComboRow row in tabla.Rows)
            {
                medicos med = new medicos();
                med.Medico = row.medico;
                med.Id = row.id;
                lista.Add(med);
            }
            return lista;
        }
        public List<medicos> Traer_Medicos_ComboDT(int id)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Medicos_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Medicos_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Medicos_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Medicos_ComboDataTable();
            tabla = adapter.GetData(id);
            List<medicos> lista = new List<medicos>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Medicos_ComboRow row in tabla.Rows)
            {
                medicos med = new medicos();
                med.Medico = row.medico;
                med.Id = row.id;
                lista.Add(med);
            }
            return lista;
        }

        public List<practicas> Traer_Practicas_Combo(int tipo)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Practicas_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Practicas_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Practicas_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Practicas_ComboDataTable();
            tabla = adapter.GetData(tipo);
            List<practicas> lista = new List<practicas>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Practicas_ComboRow row in tabla.Rows)
            {
                practicas prac = new practicas();
                prac.Practica = row.Descripcion;
                prac.Codigo = row.Codigo;
                prac.Id = row.Id;
                lista.Add(prac);
            }
            return lista;
        }

        public List<Modulo> Traer_Modulos_Combo()
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Modulo_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Modulo_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Modulo_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Modulo_ComboDataTable();
            tabla = adapter.GetData();
            List<Modulo> lista = new List<Modulo>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Modulo_ComboRow row in tabla.Rows)
            {
                Modulo mod = new Modulo();
                mod.nombre = row.Descripcion;
                mod.id = (int)row.Codigo;
                lista.Add(mod);
            }
            return lista;
        }

        public List<Estado> Traer_Estados_Combo()
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Estados_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Estados_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Estados_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Estados_ComboDataTable();
            tabla = adapter.GetData();
            List<Estado> lista = new List<Estado>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Estados_ComboRow row in tabla.Rows)
            {
                Estado est = new Estado();
                est.nombre = row.Descripcion;
                est.id = row.id;
                lista.Add(est);
            }
            return lista;
        }

        public List<SubRubro> Traer_Subrubros_Combo()
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Subrubros_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Subrubros_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Subrubros_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Subrubros_ComboDataTable();
            tabla = adapter.GetData();
            List<SubRubro> lista = new List<SubRubro>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Subrubros_ComboRow row in tabla.Rows)
            {
                SubRubro sub = new SubRubro();
                sub.nombre = row.RUS_DESCRIPCION;
                sub.id = row.RUS_ID;

                if(!row.IsEXTERNONull())
                sub.externo = row.EXTERNO;

                lista.Add(sub);
            }
            return lista;
        }

        public List<Prestador> Traer_Prestadores_Combo()
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Proveedores_ComboTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Proveedores_ComboTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Proveedores_ComboDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Proveedores_ComboDataTable();

            tabla = adapter.GetData();
            List<Prestador> lista = new List<Prestador>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Proveedores_ComboRow row in tabla.Rows)
            {
                Prestador pres = new Prestador();
                pres.nombre = row.proveedor;
                pres.id = row.id;
                lista.Add(pres);
            }
            return lista;
        }

        public Precios_Prestadores Traer_Precios_Prestadores_Lista(int prestador, int practica)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Precios_ProveedoresTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Precios_ProveedoresTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Precios_ProveedoresDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Precios_ProveedoresDataTable();

            tabla = adapter.GetData(prestador, practica);
            //List<Precios_Prestadores> lista = new List<Precios_Prestadores>();
            Precios_Prestadores precio = new Precios_Prestadores();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Precios_ProveedoresRow row in tabla.Rows)
            {
                //Precios_Prestadores precio = new Precios_Prestadores();
                precio.valor = (float)row.valor;
                //precio.Add(precio);
            }
            return precio;
        }

        public int Guardar_Valor_Practica(int idPractica, int idPrestador, decimal valor, long idUsuario, DateTime fecha)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            return Convert.ToInt32(adapter.H2_Autorizaciones_Actualizar_Tabla(idPractica, idPrestador, idUsuario, fecha, valor));
        }




        public int Guardar_Actulizar_Encabezado(long id, int p, long idPaciente, string intAmbu, DateTime fecha, int idEspecialidad, int idMedico, string observacion, int estado, string Usuario, string medicoExterno, DateTime fechaTurno, DateTime fechaAuditado, DateTime fechaRetirado)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            return Convert.ToInt32(adapter.H2_Autorizaciones_Alta_Edicion(id, 1, idPaciente, intAmbu, fecha, idEspecialidad, idMedico, observacion, estado, Usuario, medicoExterno, fechaTurno, fechaAuditado, fechaRetirado));
        }


        public int Guardar_Detalle(List<Practica_Autorizacion> lista, int id)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();

            adapter.H2_Autorizacion_Borrar_Detalle(id);
            object obj = new object();
            foreach (Practica_Autorizacion item in lista)
            {
                obj = adapter.H2_Autorizaciones_Guardar_Detalle(id, item.codigoPrac, item.importe, item.usuario, Convert.ToDateTime(item.fecha), item.cantidad, item.esPractica,item.subRubroCodigo,item.prestadorCodigo);
            }
            return Convert.ToInt32(obj);
        }

        public List<Encabezado_autorizacion> Traer_Encabezado(int id, int cuantos)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_EncabezadoTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_EncabezadoTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_EncabezadoDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_EncabezadoDataTable();

            tabla = adapter.GetData(id, cuantos);
            List<Encabezado_autorizacion> lista = new List<Encabezado_autorizacion>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_EncabezadoRow row in tabla.Rows)
            {
                Encabezado_autorizacion encabezado = new Encabezado_autorizacion();

                if (!row.IsTIPONull())
                    encabezado.tipo = row.TIPO;
                else
                    encabezado.tipo = "";

                encabezado.numero = row.NUMERO;

                if (!row.IsFECHANull())
                    encabezado.fecha = row.FECHA.ToShortDateString();
                else encabezado.fecha = "";

                if (!row.IsCOMENTARIOSNull())
                    encabezado.comentarios = row.COMENTARIOS;
                else
                    encabezado.comentarios = "";

                if (!row.IsESPECIALIDADNull())
                    encabezado.especialidad = row.ESPECIALIDAD;
                else
                    encabezado.especialidad = "";

                if (!row.IsPRESTADORNull())
                    encabezado.prestador = row.PRESTADOR;
                else
                    encabezado.prestador = "";

                lista.Add(encabezado);
            }
            return lista;
        }


        public List<Encabezado_autorizacion> Chekear_Pendientes(int id)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Chekear_PendientesTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Chekear_PendientesTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Chekear_PendientesDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Chekear_PendientesDataTable();

            tabla = adapter.GetData(id);
            List<Encabezado_autorizacion> lista = new List<Encabezado_autorizacion>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Chekear_PendientesRow row in tabla.Rows)
            {
                Encabezado_autorizacion encabezado = new Encabezado_autorizacion();

                if (!row.IsTIPONull())
                    encabezado.tipo = row.TIPO;
                else
                    encabezado.tipo = "";

                encabezado.numero = row.NUMERO;

                if (!row.IsFECHANull())
                    encabezado.fecha = row.FECHA.ToShortDateString();
                else encabezado.fecha = "";

                if (!row.IsCOMENTARIOSNull())
                    encabezado.comentarios = row.COMENTARIOS;
                else
                    encabezado.comentarios = "";

                if (!row.IsESPECIALIDADNull())
                    encabezado.especialidad = row.ESPECIALIDAD;
                else
                    encabezado.especialidad = "";

                if (!row.IsPRESTADORNull())
                    encabezado.prestador = row.PRESTADOR;
                else
                    encabezado.prestador = "";

                lista.Add(encabezado);
            }
            return lista;
        }

        public List<Encabezado_autorizacion> Traer_Un_Encabezado(int id)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Un_EncabezadoTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Un_EncabezadoTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Un_EncabezadoDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Un_EncabezadoDataTable();

            tabla = adapter.GetData(id);
            List<Encabezado_autorizacion> lista = new List<Encabezado_autorizacion>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Un_EncabezadoRow row in tabla.Rows)
            {
                Encabezado_autorizacion encabezado = new Encabezado_autorizacion();

                if (!row.IsSUB_RUBRO_IDNull())
                    encabezado.subRubroId = row.SUB_RUBRO_ID;
                else encabezado.subRubroId = 0;
 
                encabezado.amb_int = row.AMB_INT;
                encabezado.numero = row.NUMERO;
                encabezado.fecha = row.FECHA.ToShortDateString();

                if (!row.IsCOMENTARIOSNull())
                    encabezado.comentarios = row.COMENTARIOS;
                else encabezado.comentarios = "";

                encabezado.especialidadId = row.ESPECIALIDAD_ID;

                if(!row.IsPRESTADOR_IDNull())
                encabezado.prestadorId = row.PRESTADOR_ID;
                else encabezado.prestadorId = 0;


                if (!row.IsMEDICO_INTERNO_IDNull())
                    encabezado.medicoInternoId = row.MEDICO_INTERNO_ID;
                else encabezado.medicoInternoId = 0;

                if (!row.IsMEDICO_EXTERNONull())
                    encabezado.medicoExterno = row.MEDICO_EXTERNO;
                else encabezado.medicoExterno = "";

                encabezado.estadoId = row.ESTADO_ID;
                if (!row.IsFECHA_TURNONull())
                    encabezado.fechaTurno = row.FECHA_TURNO.ToShortDateString();
                else encabezado.fechaTurno = "";

                if (!row.IsFECHA_AUDITADONull())
                    encabezado.fechaAuditado = row.FECHA_AUDITADO.ToShortDateString();
                else encabezado.fechaAuditado = "";

                if (!row.IsFECHA_RETIRONull())
                    encabezado.fechaRetiro = row.FECHA_RETIRO.ToShortDateString();
                else encabezado.fechaRetiro = "";

                lista.Add(encabezado);
            }
            return lista;
        }

        public List<Detalle_Autorizacion> Traer_Detalle(int id)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_DetalleTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_DetalleTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_DetalleDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_DetalleDataTable();

            tabla = adapter.GetData(id);
            List<Detalle_Autorizacion> lista = new List<Detalle_Autorizacion>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_DetalleRow row in tabla.Rows)
            {
                Detalle_Autorizacion detalle = new Detalle_Autorizacion();


                detalle.codigo = row.CODIGO;

                if (!row.IsDESCRIPCIONNull())
                    detalle.descripcion = row.DESCRIPCION;
                else detalle.descripcion = "";

                if (!row.IsCANTIDADNull())
                    detalle.cantidad = row.CANTIDAD;

                detalle.importe = (float)row.IMPORTE;

                detalle.esPractica = row.ES_PRACTICA;

                detalle.subRubro = row.RUBRO;

                detalle.proveedor = row.PRESTADOR;

                lista.Add(detalle);
            }
            return lista;
        }

        public List<Practica_Autorizacion> Traer_Detalle_Plantilla(int id)
       
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_DetalleTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_DetalleTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_DetalleDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_DetalleDataTable();

            tabla = adapter.GetData(id);
            List<Practica_Autorizacion> lista = new List<Practica_Autorizacion>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_DetalleRow row in tabla.Rows)
            {
                Practica_Autorizacion detalle = new Practica_Autorizacion();


                detalle.codigoPrac = row.CODIGO;
                detalle.codigoMod = row.CODIGO;
                detalle.nombreMod = row.DESCRIPCION;
                detalle.nombrePrac = row.DESCRIPCION;

                detalle.cantidad = row.CANTIDAD;

                detalle.importe = row.IMPORTE;

                detalle.esPractica = row.ES_PRACTICA;

                if (!row.IsRUBRONull())
                    detalle.subRubroNombre = row.RUBRO;
                else detalle.subRubroNombre = "";

                if (!row.IsRUBRO_IDNull())
                    detalle.subRubroCodigo = row.RUBRO_ID;
                else detalle.subRubroCodigo = 0;

                if (!row.IsPRESTADORNull())
                    detalle.prestadorNombre = row.PRESTADOR;
                else detalle.prestadorNombre = "";

                if (!row.IsPRESTADRO_IDNull())
                    detalle.prestadorCodigo = row.PRESTADRO_ID;
                else detalle.prestadorCodigo = 0;

                lista.Add(detalle);
            }
            return lista;
        }

        public List<Detalle_Autorizacion> Traer_Un_Detalle(int id)// modificar
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Un_DetalleTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Traer_Un_DetalleTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Traer_Un_DetalleDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Traer_Un_DetalleDataTable();

            tabla = adapter.GetData(id);
            List<Detalle_Autorizacion> lista = new List<Detalle_Autorizacion>();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Traer_Un_DetalleRow row in tabla.Rows)
            {
                Detalle_Autorizacion detalle = new Detalle_Autorizacion();


                detalle.practicaModuloId = row.PRACTICA_ID;


                //detalle.moduloId = row.MODULO_ID;

                if (!row.IsCANTIDADNull())
                    detalle.cantidad = row.CANTIDAD;

                detalle.importe = (float)row.IMPORTE;
                lista.Add(detalle);
            }
            return lista;
        }

        public int Actualizar_Estado_Encabezado(int id, long UsuarioId)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            return Convert.ToInt32(adapter.H2_Autorizaciones_Cambiar_Estado(id, UsuarioId));
        }

        //public int Actualizar_Estado_Encabezado(int id, long UsuarioId)
        //{
        //    AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
        //    return Convert.ToInt32(adapter.H2_Autorizaciones_Cambiar_Estado(id, UsuarioId));
        //}


        public Detalle_Autorizacion Autorizaciones_Mostrar_Un_Encabezado(int id)// modificar
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Mostrar_Un_DetalleTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Mostrar_Un_DetalleTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Mostrar_Un_DetalleDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Mostrar_Un_DetalleDataTable();

            tabla = adapter.GetData(id);
            //Detalle_Autorizacion lista = new Detalle_Autorizacion();
            Detalle_Autorizacion detalle = new Detalle_Autorizacion();
            foreach (AutorizacionesDAL.H2_Autorizaciones_Mostrar_Un_DetalleRow row in tabla.Rows)
            {

                if (!row.IsfechaNull())
                    detalle.fecha = row.fecha.ToShortDateString();
                else detalle.fecha = "";
 
                detalle.tipo = row.tipo;
                detalle.subRubro = row.subrubro;
                detalle.especialidad = row.especialidad;

                if (!row.IsPRV_NOMBRENull())
                    detalle.proveedor = row.PRV_NOMBRE;
                else detalle.proveedor = ""; 


                if(!row.IsmedicoNull())
                detalle.medico = row.medico;
                else
                detalle.medico = "";

                if (!row.IsmedicoExternoNull())
                    detalle.medicoExterno = row.medicoExterno;
                else detalle.medicoExterno = "";

                if (!row.IscomentariosNull())
                    detalle.comentarios = row.comentarios;
                else detalle.comentarios = "";

                detalle.estado = row.estado;

                if (row.Isfecha_auditadoNull() || row.fecha_auditado.ToShortDateString() == "01/01/1900") { detalle.fechaAuditado = ""; }
                else { detalle.fechaAuditado = row.fecha_auditado.ToShortDateString(); }

                if (row.Isfecha_retiradoNull() || row.fecha_retirado.ToShortDateString() == "01/01/1900") { detalle.fechaRetirado = ""; }
                else { detalle.fechaRetirado = row.fecha_retirado.ToShortDateString(); }

                if (row.Isfecha_turnoNull() || row.fecha_turno.ToShortDateString() == "01/01/1900") { detalle.fechaTurno = ""; }
                else { detalle.fechaTurno = row.fecha_turno.ToShortDateString(); }

                //detalle.codigo = row.CODIGO;
                //detalle.descripcion = row.DESCRIPCION;
                //detalle.cantidad = row.cantidad;
                //detalle.importe =   (float)row.importe;
                //lista.Add(detalle);
            }
            return detalle;
        }
        /// <summary>
        /// modificacione
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<PracticaAutoComplete> CargarPracticaAutocomplete(string str)
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Practicas_AutocompleteTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Practicas_AutocompleteTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Practicas_AutocompleteDataTable aTable = adapter.GetData(str);

            List<PracticaAutoComplete> Lista = new List<PracticaAutoComplete>();

            foreach (AutorizacionesDAL.H2_Autorizaciones_Practicas_AutocompleteRow row in aTable.Rows)
            {
                PracticaAutoComplete d = new PracticaAutoComplete();
                d.Codigo = row.Codigo.ToString();//.Trim();
                d.Descripcion = row.Descripcion;
                Lista.Add(d);
            }
            return Lista;
        }


        public string Traer_Practica_Por_Codigo(int codigo)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            string nombre = "";
            try
            {
                nombre = adapter.H2_Autorizacion_Traer_Practica_Por_Codigo(codigo).ToString();
            }
            catch
            {
                if (nombre == null) { nombre = ""; }
            }
                return nombre;
        }
            //return Convert.ToInt32(adapter.H2_Autorizaciones_Cambiar_Estado(id, UsuarioId));
        /// modificacione
        /// 
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////DYT

        public List<DYT_Centro> Traer_Combos(int tipo)
        {
            AutorizacionesDALTableAdapters.H2_DYT_Traer_CombosTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_DYT_Traer_CombosTableAdapter();
            AutorizacionesDAL.H2_DYT_Traer_CombosDataTable tabla = new AutorizacionesDAL.H2_DYT_Traer_CombosDataTable();
            tabla = adapter.GetData(tipo);
            List<DYT_Centro> lista = new List<DYT_Centro>();
            foreach (AutorizacionesDAL.H2_DYT_Traer_CombosRow row in tabla.Rows)
            {
                DYT_Centro centro = new DYT_Centro();
                centro.id = row.ID;
                centro.descripcion = row.DESCRIPCION;
                lista.Add(centro);
            }
            return lista;
        }

        public int Guardar_Actulizar_DYT(int id, DYT_Item item)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();

            if (item.fechaAlta == "") { item.fechaAlta = "01/01/1900"; }
            if (item.fechaInternacion == "") { item.fechaInternacion = "01/01/1900"; }
            return Convert.ToInt32(adapter.H2_DYT_Guardar_Editar(id, item.tipo, item.pacienteId, Convert.ToDateTime(item.fechaPedido), item.horaPedido, item.solicitanteId, item.centroOrigen, item.especialidadOrigen, item.medicoOrigen
            , item.motivo, item.centroDestino, item.especialidadDestino, item.medicoDestino, item.traslado, item.prestacion, item.seguimiento, Convert.ToDateTime(item.fechaInternacion), Convert.ToDateTime(item.fechaAlta), item.estado, item.rechazos, item.usuario, item.diagnostico, item.observaciones));
        }



        public List<DYT_Item> Buscar_DYT(string donde, string FechaDesde, string FechaHasta, string HC, int centroOrigen, int especialidadOrigen, int solicitadoPor
        , int centroDestino, int especialidadDestino, int medicoDestino, int trasladadoPor, int prestacion, int seguimiento, int rechazos, int estado)
        {
            AutorizacionesDALTableAdapters.H2_DYT_BuscarTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_DYT_BuscarTableAdapter();
            AutorizacionesDAL.H2_DYT_BuscarDataTable tabla = new AutorizacionesDAL.H2_DYT_BuscarDataTable();

            tabla = adapter.GetData(donde, FechaDesde, FechaHasta, HC, centroOrigen, especialidadOrigen, solicitadoPor
        , centroDestino, especialidadDestino, medicoDestino, trasladadoPor, prestacion, seguimiento, rechazos, estado);
            List<DYT_Item> lista = new List<DYT_Item>();

            foreach (AutorizacionesDAL.H2_DYT_BuscarRow row in tabla.Rows)
            {
                DYT_Item item = new DYT_Item();
                item.id = row.ID;
                item.tipo = row.TIPO;
                if (!row.IsFECHA_PEDIDONull())
                    item.fechaPedido = row.FECHA_PEDIDO.ToShortDateString();
                else item.fechaPedido = "";

                if (!row.IsHORA_PEDIDONull())
                    item.horaPedido = row.HORA_PEDIDO;
                else item.horaPedido = "";

                if (!row.IsCENTRO_ORIGEN_IDNull())
                    item.centroOrigen = row.CENTRO_ORIGEN_ID;

                if (!row.IsESPECIALIDAD_ORIGEN_IDNull())
                    item.especialidadOrigen = row.ESPECIALIDAD_ORIGEN_ID;

                item.solicitanteId = row.SOLICITANTE_ID;
                if (!row.IsCENTRO_DESTINONull())
                    item.centroDestino = row.CENTRO_DESTINO_ID;
                if (!row.IsESPECIALIDAD_DESTINO_IDNull())
                    item.especialidadDestino = row.ESPECIALIDAD_DESTINO_ID;
                if (!row.IsMEDICO_DESTINO_IDNull())
                    item.medicoDestino = row.MEDICO_DESTINO_ID;
                if (!row.IsTRASLADO_IDNull())
                    item.traslado = row.TRASLADO_ID;
                item.prestacion = row.PRESTACION_ID;
                if (!row.IsSEGUIMIENTO_IDNull())
                    item.seguimiento = row.SEGUIMIENTO_ID;
                if (!row.IsRECHAZOS_IDNull())
                    item.rechazos = row.RECHAZOS_ID;
                if (!row.IsESTADO_IDNull())
                    item.estado = row.ESTADO_ID;

                if (!row.IsNOMBRENull())
                    item.apellidoNombre = row.NOMBRE;
                else item.apellidoNombre = "";

                if (!row.IsCENTRO_ORIGENNull())
                    item.origenNombre = row.CENTRO_ORIGEN;
                else item.origenNombre = "";

                if (!row.IsCENTRO_DESTINONull())
                    item.destinoNombre = row.CENTRO_DESTINO;
                else item.destinoNombre = "";

                if (!row.IsESTADONull())
                    item.estadoNombre = row.ESTADO;
                else item.estadoNombre = "";
                lista.Add(item);

            }
            return lista;
        }

        public List<DYT_Item> Traer_Todas_DYT_Paciente(int idPaciente)
        {
            AutorizacionesDALTableAdapters.H2_DYT_Traer_Todas_PacienteTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_DYT_Traer_Todas_PacienteTableAdapter();
            AutorizacionesDAL.H2_DYT_Traer_Todas_PacienteDataTable tabla = new AutorizacionesDAL.H2_DYT_Traer_Todas_PacienteDataTable();

            tabla = adapter.GetData(idPaciente);
            List<DYT_Item> lista = new List<DYT_Item>();

            foreach (AutorizacionesDAL.H2_DYT_Traer_Todas_PacienteRow row in tabla.Rows)
            {
                DYT_Item item = new DYT_Item();
                item.id = row.ID;
                item.fechaPedido = row.FECHA.ToShortDateString();
                item.horaPedido = row.HORA;
                item.usuario = row.USUARIO;
                item.origenNombre = row.ORIGEN;
                item.destinoNombre = row.DESTINO;
                item.motivo = row.MOTIVO;
                item.estadoNombre = row.ESTADO;
                item.rechazosNombre = row.RECHAZOS;
                lista.Add(item);
            }
            return lista;
        }

        public DYT_Item Traer_Una_DYT(int idDYT)
        {
            AutorizacionesDALTableAdapters.H2_DYT_Traer_Una_DYTTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_DYT_Traer_Una_DYTTableAdapter();
            AutorizacionesDAL.H2_DYT_Traer_Una_DYTDataTable tabla = new AutorizacionesDAL.H2_DYT_Traer_Una_DYTDataTable();

            tabla = adapter.GetData(idDYT);
            DYT_Item item = new DYT_Item();
            foreach (AutorizacionesDAL.H2_DYT_Traer_Una_DYTRow row in tabla.Rows)
            {
                item.tipo = row.TIPO;
                item.fechaPedido = row.FECHA_PEDIDO.ToShortDateString();

                if (!row.IsHORA_PEDIDONull())
                    item.horaPedido = row.HORA_PEDIDO;

                item.solicitanteId = row.SOLICITANTE_ID;
                item.centroOrigen = row.CENTRO_ORIGEN_ID;
                item.especialidadOrigen = row.ESPECIALIDAD_ORIGEN_ID;
                item.medicoOrigen = row.MEDICO_ORIGEN_ID;
                item.centroDestino = row.CENTRO_DESTINO_ID;
                item.especialidadDestino = row.ESPECIALIDAD_DESTINO_ID;
                item.medicoDestino = row.MEDICO_DESTINO_ID;


                item.motivo = row.MOTIVO;

                if (!row.IsDIAGNOSTICO_IDNull())
                    item.diagnosticoID = row.DIAGNOSTICO_ID;

                if (!row.IsDIAGNOSTICONull())
                    item.diagnostico = row.DIAGNOSTICO;

                item.traslado = row.TRASLADO_ID;
                item.prestacion = row.PRESTACION_ID;
                item.seguimiento = row.SEGUIMIENTO_ID;

                if (!row.IsFECHA_INTERNACIONNull())
                    item.fechaInternacion = row.FECHA_INTERNACION.ToShortDateString();

                if (!row.IsFECHA_ALTANull())
                    item.fechaAlta = row.FECHA_ALTA.ToShortDateString();

                item.estado = row.ESTADO_ID;
                item.rechazos = row.RECHAZOS_ID;

                if (!row.IsOBSERVACIONESNull())
                    item.observaciones = row.OBSERVACIONES;
            }

            return item;
        }

        public DYT_Item Traer_Una_DYT_Detalle(int idDYT)
        {
            AutorizacionesDALTableAdapters.H2_DYT_Traer_Una_DYT_DetalleTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_DYT_Traer_Una_DYT_DetalleTableAdapter();
            AutorizacionesDAL.H2_DYT_Traer_Una_DYT_DetalleDataTable tabla = new AutorizacionesDAL.H2_DYT_Traer_Una_DYT_DetalleDataTable();

            tabla = adapter.GetData(idDYT);
            DYT_Item item = new DYT_Item();

            foreach (AutorizacionesDAL.H2_DYT_Traer_Una_DYT_DetalleRow row in tabla.Rows)
            {
                item.id = row.ID;
                if (!row.IsLUGARNull())
                    item.lugar = row.LUGAR;
                else item.lugar = "";

                if (!row.IsPACIENTENull())
                    item.paciente = row.PACIENTE;
                else item.paciente = "";

                item.fechaPedido = row.FECHA_PEDIDO.ToShortDateString();
                if (!row.IsHORA_PEDIDONull())
                    item.horaPedido = row.HORA_PEDIDO;
                else item.horaPedido = "";

                if (!row.IsSOLICITANTENull())
                    item.solicitanteNombre = row.SOLICITANTE;
                else item.solicitanteNombre = "";

                if (!row.IsCENTRO_ORIGENNull())
                    item.origenNombre = row.CENTRO_ORIGEN;
                else item.origenNombre = "";

                if (!row.IsESPECIALIDAD_ORIGENNull())
                    item.especialidadOrigenNombre = row.ESPECIALIDAD_ORIGEN;
                else item.especialidadOrigenNombre = "";

                if (!row.IsMEDICO_ORIGENNull())
                    item.medicoOrigenNombre = row.MEDICO_ORIGEN;
                else item.medicoOrigenNombre = "";

                if (!row.IsCENTRO_DESTINONull())
                    item.DestinoNombre = row.CENTRO_DESTINO;
                else item.DestinoNombre = "";

                if (!row.IsESPECIALIDAD_DESTINONull())
                    item.especialidadDestinoNombre = row.ESPECIALIDAD_DESTINO;
                else item.especialidadDestinoNombre = "";

                if (!row.IsMEDICO_DESTINONull())
                    item.medicoDestinoNombre = row.MEDICO_DESTINO;
                else item.medicoDestinoNombre = "";

                if (!row.IsMOTIVONull())
                    item.motivo = row.MOTIVO;
                else item.motivo = "";

                //if (!row.IsDIAGNOSTICO_IDNull())
                //    item.diagnosticoID = row.DIAGNOSTICO_ID;
                if (!row.IsDIAGNOSTICONull())
                    item.diagnostico = row.DIAGNOSTICO;
                else item.diagnostico = "";

                if (!row.IsTRASLADONull())
                    item.trasladoNombre = row.TRASLADO;
                else item.trasladoNombre = "";

                if (!row.IsPRESTACIONNull())
                    item.prestacionNombre = row.PRESTACION;
                else item.prestacionNombre = "";

                if (!row.IsSEGUIMIENTONull())
                    item.seguimientoNombre = row.SEGUIMIENTO;
                else item.seguimientoNombre = "";

                if (!row.IsFECHA_INTERNACIONNull())
                    item.fechaInternacion = row.FECHA_INTERNACION.ToShortDateString();
                else item.fechaInternacion = "";

                if (!row.IsFECHA_ALTANull())
                    item.fechaAlta = row.FECHA_ALTA.ToShortDateString();
                else item.fechaAlta = "";

                if (!row.IsESTADONull())
                    item.estadoNombre = row.ESTADO;
                else item.estadoNombre = "";

                if (!row.IsRECHAZOSNull())
                    item.rechazosNombre = row.RECHAZOS;
                else item.rechazosNombre = "";

                if (!row.IsOBSERVACIONESNull())
                    item.observaciones = row.OBSERVACIONES;
                else item.observaciones = "";
            }

            return item;
        }


        public int Guardar_Actulizar_Subrubro(int id, string descripcion,int externo)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();

            return Convert.ToInt32(adapter.H2_Autorizaciones_Alta_y_Edicion_De_Subrubros(id, descripcion,externo));
        }

        public int Guardar_Actulizar_Prestadores(int id, string descripcion)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();

            return Convert.ToInt32(adapter.H2_Autorizaciones_Alta_y_Edicion_De_Prestadores(id, descripcion));
        }


        ////////////////////////////////EXPRESSSSSSS

        public int Guardar_Actulizar_Encabezado_Autorizacion_Express(int id, string fecha, long idPaciente, string observacion, int usuario, string email)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            return Convert.ToInt32(adapter.H2_Autorizaciones_Express_Guardar_Actualizar_Encabezado(id,fecha,idPaciente,observacion,usuario,email ));
        }

        public int Guardar_Detalle_Autorizacion_Express(List<Practica_Autorizacion_Express> lista, int id)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();

            adapter.H2_Autorizaciones_Express_Borrar_Detalle(id);
            object obj = new object();
            foreach (Practica_Autorizacion_Express item in lista)
            {
                obj = adapter.H2_Autorizaciones_Express_Guardar_Detalle(id,item.codigoPrac,item.idMedico );
            }
            return Convert.ToInt32(obj);
        }

        public string Traer_Email(long id)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            return Convert.ToString(adapter.H2_Autorizaciones_Traer_Email(id)); 
        }

        public List<Encabezado_Autorizacion_Express> Buscar_Express(int idEncabezado, int tipo, string desde, string hasta, string documento)           
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Express_Traer_Ver_Una_Buscar_EncabezadoTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Express_Traer_Ver_Una_Buscar_EncabezadoTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Express_Traer_Ver_Una_Buscar_EncabezadoDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Express_Traer_Ver_Una_Buscar_EncabezadoDataTable();
            tabla = adapter.GetData(idEncabezado,tipo,desde,hasta,documento);
            List<Encabezado_Autorizacion_Express> lista = new List<Encabezado_Autorizacion_Express>();

            foreach (AutorizacionesDAL.H2_Autorizaciones_Express_Traer_Ver_Una_Buscar_EncabezadoRow row in tabla.Rows)
            {
                Encabezado_Autorizacion_Express encabezado = new Encabezado_Autorizacion_Express();
                encabezado.id = row.id;
                encabezado.paciente = row.paciente;
                encabezado.idPaciente = row.idPaciente;
                encabezado.dni = row.dni;

                if (!row.IsemailNull())
                    encabezado.email = row.email;
                else
                    encabezado.email = "";

                if (!row.IsfechaNull())
                    encabezado.fecha = row.fecha;
                else
                    encabezado.fecha = "";
          
                //encabezado.medico = row.medico;
                //encabezado.idMedico = row.medicoId;

                if(!row.IsobservacionNull())
                encabezado.observacion = row.observacion;
                else
                encabezado.observacion = "";

                lista.Add(encabezado);
            }
            return lista;
        }

        public List<Practica_Autorizacion_Express> Traer_Detalle_Express(int idEncabezado)
        
        {
            AutorizacionesDALTableAdapters.H2_Autorizaciones_Express_Traer_Ver_Una_DetalleTableAdapter adapter = new AutorizacionesDALTableAdapters.H2_Autorizaciones_Express_Traer_Ver_Una_DetalleTableAdapter();
            AutorizacionesDAL.H2_Autorizaciones_Express_Traer_Ver_Una_DetalleDataTable tabla = new AutorizacionesDAL.H2_Autorizaciones_Express_Traer_Ver_Una_DetalleDataTable();
            tabla = adapter.GetData(idEncabezado);
            List<Practica_Autorizacion_Express> lista = new List<Practica_Autorizacion_Express>();

            foreach (AutorizacionesDAL.H2_Autorizaciones_Express_Traer_Ver_Una_DetalleRow row in tabla.Rows)
            {
                Practica_Autorizacion_Express detalle = new Practica_Autorizacion_Express();
                detalle.descripcionPrac = row.estudio;
                detalle.codigoPrac = row.codigoPractica;
                detalle.medico = row.medico;
                detalle.idMedico = row.idMedico;
                lista.Add(detalle);
            }
            return lista;
        }

        public int Borrar_Autorizacion_Express(int idEncabezado, long idUsuario)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            return Convert.ToInt32(adapter.H2_Autorizaciones_Express_Borrar_Encabezado(idEncabezado,Convert.ToInt32(idUsuario)));
        }


        public int Traer_Paciente_Por_N_Carga(int NumeroCarga)
        {
            AutorizacionesDALTableAdapters.QueriesTableAdapter adapter = new AutorizacionesDALTableAdapters.QueriesTableAdapter();
            return Convert.ToInt32(adapter.H2_Autorizacion_Traer_Paciente_Por_N_Carga(NumeroCarga));
        }
    }
}