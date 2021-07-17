﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de ComprasBLL
/// </summary>
public class ComprasBLL
{
	public ComprasBLL()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public void BajaAdjunto(long idArchivo)
    {
        ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
        try
        {
            adapter.H2_Compras_BajaAdjunto(idArchivo);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Compras_Adjuntos> Adjuntos_List(long ExpId)
    {
        ComprasDALTableAdapters.H2_COMPRAS_ADJUNTOS_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_ADJUNTOS_LISTTableAdapter();
        ComprasDAL.H2_COMPRAS_ADJUNTOS_LISTDataTable aTable = adapter.GetData(ExpId);
        List<Compras_Adjuntos> Lista = new List<Compras_Adjuntos>();
        foreach (ComprasDAL.H2_COMPRAS_ADJUNTOS_LISTRow row in aTable.Rows)
        {
            Compras_Adjuntos adjunto = new Compras_Adjuntos();
            adjunto.IdDetalle = row.IdDetalle;
            adjunto.ExpId = row.ExpId;
            adjunto.RutaArchivo = row.RutaArchivo;
            adjunto.Estado = row.Estado;
            adjunto.FechaSistema = row.FechaSistema.ToString();
            Lista.Add(adjunto);
        }
        return Lista;
    }

    public void Compras_Adjunto_Insert(Compras_Adjuntos adjunto)
    {
        ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
        try
        {
            adapter.H2_Compras_Adjuntos_Insert(adjunto.IdDetalle, adjunto.ExpId, adjunto.RutaArchivo, adjunto.Estado);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_insumos_combo> List_InsumosCombo(bool Todos)
    {
        List<compras_insumos_combo> list = new List<compras_insumos_combo>();
        try
        {
            ComprasDALTableAdapters.H2_COMPRAS_LIST_INSUMOS_COMBOTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_LIST_INSUMOS_COMBOTableAdapter();
            ComprasDAL.H2_COMPRAS_LIST_INSUMOS_COMBODataTable aTable = adapter.GetData(Todos);
            foreach (ComprasDAL.H2_COMPRAS_LIST_INSUMOS_COMBORow row in aTable.Rows)
                list.Add(new compras_insumos_combo(row.INS_ID, row.INS_DESCRIPCION.Trim(),row.INS_RUBRO));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_insumos_combo> List_InsumosCombo_by_Desc(string Descripcion)
    {
        List<compras_insumos_combo> list = new List<compras_insumos_combo>();
        try
        {
            ComprasDALTableAdapters.H2_COMPRAS_LIST_INSUMOS_COMBO_BY_DESCTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_LIST_INSUMOS_COMBO_BY_DESCTableAdapter();
            ComprasDAL.H2_COMPRAS_LIST_INSUMOS_COMBO_BY_DESCDataTable aTable = adapter.GetData(Descripcion);
            foreach (ComprasDAL.H2_COMPRAS_LIST_INSUMOS_COMBO_BY_DESCRow row in aTable.Rows)
                list.Add(new compras_insumos_combo(row.INS_ID, row.INS_DESCRIPCION.Trim(),row.INS_RUBRO));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public compras_insumo_info List_Insumo_byId(int IdInsumo)
    {
        try
        {
            ComprasDALTableAdapters.H2_COMPRAS_INSUMO_BY_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_INSUMO_BY_IDTableAdapter();
            ComprasDAL.H2_COMPRAS_INSUMO_BY_IDDataTable aTable = adapter.GetData(IdInsumo);
            foreach (ComprasDAL.H2_COMPRAS_INSUMO_BY_IDRow row in aTable.Rows)
                return new compras_insumo_info(row.UltimoPrecio, row.StockActual,row.INS_RUBRO);
            return null;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }      
    }

    public List<compras_deposito> List_Depositos(bool Todos)
    {
        try
        {
            List<compras_deposito> list = new List<compras_deposito>();
            ComprasDALTableAdapters.H2_COMPRAS_DEPOSITOS_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_DEPOSITOS_LISTTableAdapter();
            ComprasDAL.H2_COMPRAS_DEPOSITOS_LISTDataTable aTable = adapter.GetData(Todos);
            foreach (ComprasDAL.H2_COMPRAS_DEPOSITOS_LISTRow row in aTable.Rows)
                list.Add(new compras_deposito(row.id, row.deposito, row.Estado));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void DeleteDetallesRemito(long RemitoId)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_REMITOS_DET_DELETE(RemitoId);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long Insert_Remitos_Cabecera(compras_remito_cabecera cab)
    {
        try
        {
            if (cab.REM_I_ID > 0) DeleteDetallesRemito(cab.REM_I_ID); //Modificacion
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_COMPRAS_REMITOS_ING_CAB_INSERT(cab.REM_I_ID, cab.REM_I_LETRA, cab.REM_I_SUCURSAL, cab.REM_I_NUMERO, cab.REM_I_PRV_ID, Convert.ToDateTime(cab.REM_I_FECHA),
                cab.REM_I_USUARIO, cab.REM_I_OBS, cab.REM_USUARIO_MOD, cab.REM_I_LETRA_FACT,cab.REM_I_SUCURSAL_FACT,cab.REM_I_NUMERO_FACT);
            if (Id != null) return Convert.ToInt64(Id.ToString());
            else throw new Exception("Error al insertar cabecera.");
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long Insert_Remitos_Detalle(compras_remito_detalle det)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_COMPRA_FAR_REMITOS_ING_DET_INSERT(det.RED_REM_ID, det.RED_INS_ID, det.RED_CANTIDAD, det.RED_PRECIO, det.RED_DEP_ID, 
                det.NRO_LOTE, Convert.ToDateTime(det.FechaVencimiento),det.RED_INS_RUBRO);
            if (Id != null) return Convert.ToInt64(Id.ToString());
            else throw new Exception("Error al insertar detalle.");
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public int Existe_Remito(compras_remito_cabecera cab)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_COMPRAS_EXISTE_REMITO(cab.REM_I_LETRA, cab.REM_I_SUCURSAL, cab.REM_I_NUMERO, cab.REM_I_PRV_ID);
            if (Id != null) return Convert.ToInt32(Id.ToString());
            else return 0;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_remito_buscar> Remitos_List(string Desde, string Hasta, int ProveedorId,string Letra, int Sucursal, int Numero, 
        string Letra_Fact, int Sucursal_Fact, int Numero_Fact)
    {
        try
        {
            List<compras_remito_buscar> list = new List<compras_remito_buscar>();
            ComprasDALTableAdapters.H2_COMPRAS_LIST_REMITOSTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_LIST_REMITOSTableAdapter();
            ComprasDAL.H2_COMPRAS_LIST_REMITOSDataTable aTable = adapter.GetData(Convert.ToDateTime(Desde),Convert.ToDateTime(Hasta),ProveedorId,Letra,Sucursal,Numero,
                Letra_Fact, Sucursal_Fact, Numero_Fact);
            foreach (ComprasDAL.H2_COMPRAS_LIST_REMITOSRow row in aTable.Rows)
                list.Add(new compras_remito_buscar((int)row.Remito_ID,row.Letra,row.Sucursal,row.Numero,row.NroProveedor,
                    row.Fecha.ToShortDateString(),row.Observaciones,row.Proveedor,row.Letra_Fact, row.Sucursal_Fact, row.Numero_Fact));
            return list;
        }
        catch(SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public compras_remito_cabecera_list Remito_List_Cab_Id(long RemitoId)
    {
        try
        {
            ComprasDALTableAdapters.H2_COMPRAS_REMITO_CAB_LIST_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_REMITO_CAB_LIST_IDTableAdapter();
            ComprasDAL.H2_COMPRAS_REMITO_CAB_LIST_IDDataTable aTable = adapter.GetData(RemitoId);
            foreach (ComprasDAL.H2_COMPRAS_REMITO_CAB_LIST_IDRow row in aTable.Rows)
                return new compras_remito_cabecera_list(row.RemitoId, row.Letra, row.Sucursal, row.Numero, row.ProveedorId, row.Fecha.ToShortDateString(), row.UsuarioId, 
                    row.Observaciones, row.Proveedor, row.Usuario, row.Letra_Fact,row.Sucursal_Fact,row.Numero_Fact);
            return null;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_remito_detalle> Remito_List_Det_Id(long RemitoId)
    {
        try
        {
            List<compras_remito_detalle> list = new List<compras_remito_detalle>();
            ComprasDALTableAdapters.H2_COMPRAS_REMITO_DET_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_REMITO_DET_IDTableAdapter();
            ComprasDAL.H2_COMPRAS_REMITO_DET_IDDataTable aTable = adapter.GetData(RemitoId);
            foreach (ComprasDAL.H2_COMPRAS_REMITO_DET_IDRow row in aTable.Rows)
                list.Add(new compras_remito_detalle(row.RemitoId, row.InsumoId, row.CantidadUnidades, row.Precio, row.DepositoId, row.NroLote, row.Insumo, 
                    row.FechaVencimiento.ToShortDateString(),row.RUBRO_ID ));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Remito_Baja(long RemitoId, long UsuarioMod)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_REMITOS_BAJA(RemitoId, UsuarioMod);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_expediente_estado> Expediente_Estado_List(bool Todos)
    {
        try
        {
            List<compras_expediente_estado> list = new List<compras_expediente_estado>();
            ComprasDALTableAdapters.H2_COMPRAS_EXPEDIENTE_ESTADO_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_EXPEDIENTE_ESTADO_LISTTableAdapter();
            ComprasDAL.H2_COMPRAS_EXPEDIENTE_ESTADO_LISTDataTable aTable = adapter.GetData(Todos);
            foreach (ComprasDAL.H2_COMPRAS_EXPEDIENTE_ESTADO_LISTRow row in aTable.Rows)
                list.Add(new compras_expediente_estado(row.Expediente_Estado_Id, row.Expediente_Estado_Desc, row.Expediente_Estado_Baja));
            return list;              
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_expediente_diagnostico> Expediente_Diagnostico_List(bool Todos)
    {
        try
        {
            List<compras_expediente_diagnostico> list = new List<compras_expediente_diagnostico>();
            ComprasDALTableAdapters.H2_COMPRAS_DIAGNOSTICOS_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_DIAGNOSTICOS_LISTTableAdapter();
            ComprasDAL.H2_COMPRAS_DIAGNOSTICOS_LISTDataTable aTable = adapter.GetData(Todos);
            foreach (ComprasDAL.H2_COMPRAS_DIAGNOSTICOS_LISTRow row in aTable.Rows)
                list.Add(new compras_expediente_diagnostico((int)row.Diagnostico_Id, row.Diagnostico_Desc, row.Diagnostico_Baja));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public expediente_cab Expediente_Cab_List_byId(long ExpId)
    {
        try
        {
            ComprasDALTableAdapters.H2_EXPEDIENTES_LIST_BY_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXPEDIENTES_LIST_BY_IDTableAdapter();
            ComprasDAL.H2_EXPEDIENTES_LIST_BY_IDDataTable aTable = adapter.GetData(ExpId);
            foreach (ComprasDAL.H2_EXPEDIENTES_LIST_BY_IDRow row in aTable.Rows)
            {
                string EXP_FEC_NAC = string.Empty;
                string EXP_VENC_FECHA = string.Empty;
                if (!row.IsEXP_FEC_NACNull()) EXP_FEC_NAC = row.EXP_FEC_NAC.ToShortDateString();
                if (!row.IsEXP_VENC_FECHANull()) EXP_VENC_FECHA = row.EXP_VENC_FECHA.ToShortDateString();

                return new expediente_cab(row.EXP_ID, row.EXP_TIPO_DOC, row.EXP_NRO_DOC, row.EXP_NOMBRE, row.EXP_DIRECCION, row.EXP_COD_POST, row.EXP_NHC, row.EXP_SEC_ID,
                    row.EXP_OBS, row.EXP_GRU_ID, row.EXP_TRAB_EMPR, row.EXP_TRAB_CUIT, row.EXP_TRAB_DIR, row.EXP_DIS_ID, row.EXP_DOC_DISCA, row.EXP_DOC_SUEL,
                    row.EXP_DOC_DNI, row.EXP_DOC_CERT, row.EXP_TELEFONO, row.EXP_EST_ID, row.EXP_FECHA.ToShortDateString(), row.EXP_USUARIO,
                    EXP_FEC_NAC, EXP_VENC_FECHA, row.Calle, row.Numero, row.Piso, row.Depto, row.CP, row.Localidad, row.Provincia, row.Celular, row.Telefono);
            }
            return null;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        } 
    }

    public List<int> Expediente_Patologias_List_by_ExpId(long ExpId)
    {
        try
        {
            List<int> list = new List<int>();
            ComprasDALTableAdapters.H2_EXPEDIENTES_PATOLOGIAS_LIST_BY_EXPIDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXPEDIENTES_PATOLOGIAS_LIST_BY_EXPIDTableAdapter();
            ComprasDAL.H2_EXPEDIENTES_PATOLOGIAS_LIST_BY_EXPIDDataTable aTable = adapter.GetData(ExpId);
            foreach (ComprasDAL.H2_EXPEDIENTES_PATOLOGIAS_LIST_BY_EXPIDRow row in aTable.Rows)
                list.Add(row.EXP_PAT_PAT_ID);
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long Expediente_Cab_Insert(expediente_cab expediente)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object ExpId = adapter.H2_EXPEDIENTES_CAB_INSERT(expediente.EXP_ID, expediente.EXP_TIPO_DOC, expediente.EXP_NRO_DOC, expediente.EXP_NOMBRE, expediente.EXP_DIRECCION, expediente.EXP_COD_POST,
                expediente.EXP_NHC, expediente.EXP_SEC_ID, expediente.EXP_OBS, expediente.EXP_GRU_ID, expediente.EXP_TRAB_EMPR, expediente.EXP_TRAB_CUIT, expediente.EXP_TRAB_DIR, 0,
                1, expediente.EXP_DOC_DISCA, expediente.EXP_DOC_SUEL, expediente.EXP_DOC_DNI, expediente.EXP_DOC_CERT, false, expediente.EXP_TELEFONO, expediente.EXP_EST_ID,
                DateTime.Parse(expediente.EXP_FECHA), expediente.EXP_USUARIO, DateTime.Parse(expediente.EXP_FEC_NAC), DateTime.Parse(expediente.EXP_VENC_FECHA));
            if (ExpId != null) return Convert.ToInt64(ExpId.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Expediente_Patologia_Insert(long ExpId, int PatologiaId)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXPEDIENTES_PATOLOGIA_INSERT(ExpId, PatologiaId);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Expediente_Patologia_Delete(long ExpId)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXPEDIENTES_PATOLOGIAS_DELETE(ExpId);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Expediente_Baja(long ExpId, long UsuarioBajaId)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXPEDIENTES_CAB_BAJA(ExpId, UsuarioBajaId);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Expediente_Extras_Insert(expediente_extras extra)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXPEDIENTE_EXTRAS_INSERT(extra.EXP_EXT_EXP_ID, DateTime.Parse(extra.EXP_EXT_PMI_DESDE), DateTime.Parse(extra.EXP_EXT_PMI_HASTA), 
                DateTime.Parse(extra.EXP_EXT_CODEM_DESDE), DateTime.Parse(extra.EXP_EXT_CODEM_HASTA),
                DateTime.Parse(extra.EXP_EXT_SSS_DESDE), DateTime.Parse(extra.EXP_EXT_SSS_HASTA), DateTime.Parse(extra.EXP_EXT_PM_DESDE), DateTime.Parse(extra.EXP_EXT_PM_HASTA), 
                DateTime.Parse(extra.EXP_EXT_CERT_DESDE), DateTime.Parse(extra.EXP_EXT_CERT_HASTA), DateTime.Parse(extra.EXP_EXT_VENC_PAT),extra.EXP_EXT_TUTOR, extra.EXP_EXT_EST_LEGAL);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public expediente_extras Expediente_Extras_List_byExpId(long ExpId)
    {
        try
        {
            ComprasDALTableAdapters.H2_EXPEDIENTE_EXTRAS_SELECT_EXPIDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXPEDIENTE_EXTRAS_SELECT_EXPIDTableAdapter();
            ComprasDAL.H2_EXPEDIENTE_EXTRAS_SELECT_EXPIDDataTable aTable = adapter.GetData(ExpId);
            foreach (ComprasDAL.H2_EXPEDIENTE_EXTRAS_SELECT_EXPIDRow row in aTable.Rows)
            {
                string _EXP_EXT_PMI_DESDE = string.Empty;
                if(!row.IsEXP_EXT_PMI_DESDENull()) _EXP_EXT_PMI_DESDE =  row.EXP_EXT_PMI_DESDE.ToShortDateString();

                string _EXP_EXT_PMI_HASTA = string.Empty;
                if (!row.IsEXP_EXT_PMI_HASTANull()) _EXP_EXT_PMI_HASTA = row.EXP_EXT_PMI_DESDE.ToShortDateString();

                string _EXP_EXT_CODEM_DESDE = string.Empty;
                if (!row.IsEXP_EXT_CODEM_DESDENull()) _EXP_EXT_CODEM_DESDE = row.EXP_EXT_CODEM_DESDE.ToShortDateString();

                string _EXP_EXT_CODEM_HASTA = string.Empty;
                if (!row.IsEXP_EXT_CODEM_HASTANull()) _EXP_EXT_CODEM_HASTA = row.EXP_EXT_CODEM_HASTA.ToShortDateString();

                string _EXP_EXT_SSS_DESDE = string.Empty;
                if (!row.IsEXP_EXT_SSS_DESDENull()) _EXP_EXT_SSS_DESDE = row.EXP_EXT_SSS_DESDE.ToShortDateString();

                string _EXP_EXT_SSS_HASTA = string.Empty;
                if (!row.IsEXP_EXT_SSS_HASTANull()) _EXP_EXT_SSS_HASTA = row.EXP_EXT_SSS_HASTA.ToShortDateString();

                string _EXP_EXT_PM_DESDE = string.Empty;
                if (!row.IsEXP_EXT_PM_DESDENull()) _EXP_EXT_PM_DESDE = row.EXP_EXT_PM_DESDE.ToShortDateString();

                string _EXP_EXT_PM_HASTA = string.Empty;
                if (!row.IsEXP_EXT_PM_HASTANull()) _EXP_EXT_PM_HASTA = row.EXP_EXT_PM_HASTA.ToShortDateString();

                string _EXP_EXT_CERT_DESDE = string.Empty;
                if (!row.IsEXP_EXT_CERT_DESDENull()) _EXP_EXT_CERT_DESDE = row.EXP_EXT_CERT_DESDE.ToShortDateString();

                string _EXP_EXT_CERT_HASTA = string.Empty;
                if (!row.IsEXP_EXT_CERT_HASTANull()) _EXP_EXT_CERT_HASTA = row.EXP_EXT_CERT_HASTA.ToShortDateString();

                string _EXP_EXT_VENC_PAT = string.Empty;
                if (!row.IsEXP_EXT_VENC_PATNull()) _EXP_EXT_VENC_PAT = row.EXP_EXT_VENC_PAT.ToShortDateString();

                return new expediente_extras(row.EXP_EXT_EXP_ID, _EXP_EXT_PMI_DESDE, _EXP_EXT_PMI_HASTA, _EXP_EXT_CODEM_DESDE, _EXP_EXT_CODEM_HASTA,
                    _EXP_EXT_SSS_DESDE, _EXP_EXT_SSS_HASTA, _EXP_EXT_PM_DESDE, _EXP_EXT_PM_HASTA, _EXP_EXT_CERT_DESDE, _EXP_EXT_CERT_HASTA,
                    _EXP_EXT_VENC_PAT, row.EXP_EXT_TUTOR, row.EXP_EXT_EST_LEGAL);
            }
            return null;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Expediente_Diagnosticos_Insert(long ExpId, int DiagnosticoId)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXPEDIENTE_DIAGNOSTICOS_INSERT(ExpId, DiagnosticoId);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Expediente_Diagnosticos_Delete(long ExpId)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXPEDIENTE_DIAGNOSTICOS_DELETE_BY_EXPID(ExpId);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<int> Expediente_Diagnosticos_List(long ExpId)
    {
        try
        {
            List<int> list = new List<int>();
            ComprasDALTableAdapters.H2_EXPEDIENTE_DIAGNOSTICOS_LIST_BY_EXPIDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXPEDIENTE_DIAGNOSTICOS_LIST_BY_EXPIDTableAdapter();
            ComprasDAL.H2_EXPEDIENTE_DIAGNOSTICOS_LIST_BY_EXPIDDataTable aTable = adapter.GetData(ExpId);
            foreach (ComprasDAL.H2_EXPEDIENTE_DIAGNOSTICOS_LIST_BY_EXPIDRow row in aTable.Rows)
                list.Add(row.EXP_DIAG_DIAG_ID);
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<expediente_buscar> Expediente_Buscar(long EXP_ID, int EXP_ESTADO, string EXP_NOMBRE, int EXP_DIAG_ID, int EXP_NRO_DOC, string EXP_VENC_FECHA_DESDE,
        string EXP_VENC_FECHA_HASTA, bool EXP_CERT_CASAM, bool EXP_CERT_DNI, bool EXP_CERT_DISC, bool EXP_CERT_SUELDO, string SeccionalesIds, string PatologiasIds,
        long NroPedidoId)
    {
        try
        {
            List<expediente_buscar> list = new List<expediente_buscar>();
            ComprasDALTableAdapters.H2_EXPEDIENTES_BUSCARTableAdapter adapter = new ComprasDALTableAdapters.H2_EXPEDIENTES_BUSCARTableAdapter();
            ComprasDAL.H2_EXPEDIENTES_BUSCARDataTable aTable = adapter.GetData(EXP_ID, EXP_ESTADO, EXP_NOMBRE, EXP_DIAG_ID, EXP_NRO_DOC,
                DateTime.Parse(EXP_VENC_FECHA_DESDE), DateTime.Parse(EXP_VENC_FECHA_HASTA), EXP_CERT_CASAM, EXP_CERT_DNI, EXP_CERT_DISC, EXP_CERT_SUELDO,
                SeccionalesIds, PatologiasIds, NroPedidoId);
            foreach (ComprasDAL.H2_EXPEDIENTES_BUSCARRow row in aTable.Rows)
            {
                string Fecha_venc = string.Empty;
                if (!row.IsEXP_VENC_FECHANull()) Fecha_venc = row.EXP_VENC_FECHA.ToShortDateString();

                string EXP_FEC_NAC = string.Empty;
                if (!row.IsEXP_FEC_NACNull()) EXP_FEC_NAC = row.EXP_FEC_NAC.ToShortDateString();
                list.Add(new expediente_buscar(row.EXP_ID, (int)row.EXP_NRO_DOC, row.EXP_NOMBRE, row.Seccional, Fecha_venc, row.Patologias, row.Estado, EXP_FEC_NAC));
            }
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long EXP_PEDIDOS_CAB_INSERT(expediente_pedidos_cab pedido)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object PedidoId = adapter.H2_EXP_PEDIDOS_CAB_INSERT(pedido.EXP_PED_ID, pedido.EXP_PED_EPA_ID, DateTime.Parse(pedido.EXP_PED_FECHA), DateTime.Parse(pedido.EXP_PED_FECHA_RECETA), pedido.EXP_PED_OBS, pedido.EXP_PED_DURACION,
                pedido.EXP_PED_USUARIO, DateTime.Parse(pedido.EXP_PED_FEC_AUTORIZ), pedido.EXP_PED_URGENTE, DateTime.Parse(pedido.EXP_PED_FEC_AUDIT), pedido.EXP_PED_USU_AUDIT, pedido.EXP_PED_ESTADO, pedido.EXP_PED_OBS_AUDIT,
                pedido.EXP_PED_EXP_ID);
            if (PedidoId != null) return Convert.ToInt64(PedidoId.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long EXP_PEDIDOS_DET_INSERT(expediente_pedidos_det detalle)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object PedidoId = adapter.H2_EXP_PEDIDOS_DET_INSERT(detalle.PDT_ID,detalle.PDT_PED_ID, detalle.PDT_INS_ID, detalle.PDT_CANTIDAD, detalle.PDT_POR_DESC, detalle.PDT_USUARIO,
                detalle.PDT_NOENTREGAR, detalle.PDT_SALDO, detalle.PDT_USU_AUDIT, DateTime.Parse(detalle.PDT_FEC_AUDIT), detalle.PDT_OBS, detalle.PDT_PLAN);
            if (PedidoId != null) return Convert.ToInt64(PedidoId.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void EXP_PEDIDOS_DET_DELETE(long PDT_PED_ID)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXP_PEDIDOS_DET_DELETE(PDT_PED_ID);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public expediente_pedidos_cab EXP_PED_CAB_LIST_ID(long PDT_PED_ID)
     {
        try
        {
            ComprasDALTableAdapters.H2_EXP_PED_CAB_LIST_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_PED_CAB_LIST_IDTableAdapter();
            ComprasDAL.H2_EXP_PED_CAB_LIST_IDDataTable aTable = adapter.GetData(PDT_PED_ID);
            foreach (ComprasDAL.H2_EXP_PED_CAB_LIST_IDRow row in aTable.Rows)
            {
                string EXP_PED_FEC_AUDIT = string.Empty;
                if(!row.IsEXP_PED_FEC_AUDITNull()) EXP_PED_FEC_AUDIT = row.EXP_PED_FEC_AUDIT.ToShortDateString();

                string EXP_PED_FEC_AUTORIZ = string.Empty;
                if(!row.IsEXP_PED_FEC_AUTORIZNull()) EXP_PED_FEC_AUTORIZ = row.EXP_PED_FEC_AUTORIZ.ToShortDateString();

                string OBS_AA = string.Empty;
                if(!row.IsOBS_AANull()) OBS_AA = row.OBS_AA;

                string OBS_PED = string.Empty;
                if(!row.IsOBS_PEDNull()) OBS_PED = row.OBS_PED;

                string UsuarioAA = string.Empty;
                if(!row.IsUsuarioAANull()) UsuarioAA = row.UsuarioAA;

                string UsuarioPed = string.Empty;
                if(!row.IsUsuarioPedNull()) UsuarioPed = row.UsuarioPed;

                return new expediente_pedidos_cab(row.PedidoId, 0, row.EXP_PED_FECHA.ToShortDateString(), row.EXP_PED_FECHA_RECETA.ToShortDateString(), OBS_PED, row.EXP_PED_DURACION,
                    0, row.EXP_PED_FECHA.ToShortDateString(), EXP_PED_FEC_AUTORIZ, row.EXP_PED_URGENTE, EXP_PED_FEC_AUTORIZ, 0, row.EXP_PED_ESTADO,
                    OBS_AA, row.ExpedienteId, UsuarioPed, UsuarioAA,30,true,0);
            }
            return null;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
     }

    public List<expediente_pedidos_det> EXP_PED_DET_LIST_ID(long PDT_PED_ID)
    {
        try
        {
            List<expediente_pedidos_det> list = new List<expediente_pedidos_det>();
            ComprasDALTableAdapters.H2_EXP_PEDIDOS_DET_LIST_BY_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_PEDIDOS_DET_LIST_BY_IDTableAdapter();
            ComprasDAL.H2_EXP_PEDIDOS_DET_LIST_BY_IDDataTable aTable = adapter.GetData(PDT_PED_ID);
            foreach (ComprasDAL.H2_EXP_PEDIDOS_DET_LIST_BY_IDRow row in aTable.Rows)
            {
                string PDT_FEC_AUDIT = string.Empty;
                if(!row.IsPDT_FEC_AUDITNull()) PDT_FEC_AUDIT = row.PDT_FEC_AUDIT.ToShortDateString();
                list.Add(new expediente_pedidos_det(row.PDT_ID,row.PDT_PED_ID, row.PDT_INS_ID, row.PDT_CANTIDAD, row.PDT_POR_DESC, 0, row.PDT_NOENTREGAR, row.PDT_SALDO, 0, PDT_FEC_AUDIT,
                    row.PDT_OBS, row.PDT_PLAN, row.InsumoDesc, row.USU_PED, row.USU_AUD));
            }
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<expediente_pedidos_cab> EXP_PED_CAB_LIST_EXPID(long EXP_ID)
    {
        try
        {
            List<expediente_pedidos_cab> list = new List<expediente_pedidos_cab>();
            ComprasDALTableAdapters.H2_EXP_PED_CAB_LIST_EXPIDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_PED_CAB_LIST_EXPIDTableAdapter();
            ComprasDAL.H2_EXP_PED_CAB_LIST_EXPIDDataTable aTable = adapter.GetData(EXP_ID);
            foreach (ComprasDAL.H2_EXP_PED_CAB_LIST_EXPIDRow row in aTable.Rows)
            {
                string EXP_PED_FEC_AUDIT = string.Empty;
                if (!row.IsEXP_PED_FEC_AUDITNull()) EXP_PED_FEC_AUDIT = row.EXP_PED_FEC_AUDIT.ToShortDateString();

                string EXP_PED_FEC_AUTORIZ = string.Empty;
                if (!row.IsEXP_PED_FEC_AUTORIZNull()) EXP_PED_FEC_AUTORIZ = row.EXP_PED_FEC_AUTORIZ.ToShortDateString();

                string OBS_AA = string.Empty;
                if (!row.IsOBS_AANull()) OBS_AA = row.OBS_AA;

                string OBS_PED = string.Empty;
                if (!row.IsOBS_PEDNull()) OBS_PED = row.OBS_PED;

                string UsuarioAA = string.Empty;
                if (!row.IsUsuarioAANull()) UsuarioAA = row.UsuarioAA;

                string UsuarioPed = string.Empty;
                if (!row.IsUsuarioPedNull()) UsuarioPed = row.UsuarioPed;

                long _PED_ORIGEN = 0;
                if (!row.IsPED_ORIGENNull()) _PED_ORIGEN = Convert.ToInt64(row.PED_ORIGEN);

                list.Add(new expediente_pedidos_cab(row.PedidoId, 0, row.EXP_PED_FECHA.ToShortDateString(), row.EXP_PED_FECHA_RECETA.ToShortDateString(), OBS_PED, row.EXP_PED_DURACION,
                    0, row.EXP_PED_FECHA.ToShortDateString(), EXP_PED_FEC_AUTORIZ, row.EXP_PED_URGENTE, EXP_PED_FEC_AUTORIZ, 0, row.EXP_PED_ESTADO,
                    OBS_AA, row.ExpedienteId, UsuarioPed, UsuarioAA, row.EXP_PED_ES_60_90, Convert.ToBoolean(row.EXP_PED_EDITABLE), _PED_ORIGEN,row.Insumos,row.EXP_PED_PEDIENTE));
            }
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public List<expediente_rubros> EXP_RUBROS_LIST(bool Todos)
    {
        try
        {
            List<expediente_rubros> list = new List<expediente_rubros>();
            ComprasDALTableAdapters.H2_COMPRAS_EXP_RUBROS_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_EXP_RUBROS_LISTTableAdapter();
            ComprasDAL.H2_COMPRAS_EXP_RUBROS_LISTDataTable aTable = adapter.GetData(Todos);
            foreach (ComprasDAL.H2_COMPRAS_EXP_RUBROS_LISTRow row in aTable.Rows)
                list.Add(new expediente_rubros(row.COMPRAS_RUBROS_ID, row.COMPRAS_RUBROS_DESC, row.COMPRAS_RUBROS_BAJA));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void EXP_PEDIDOS_DET_AUDITAR(int Tarea, long PDT_PED_ID, long PDT_ID, long PDT_USU_AUDIT, DateTime PDT_FEC_AUDIT, string PDT_OBS)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXP_PEDIDOS_DET_AUDITAR(Tarea, PDT_PED_ID, PDT_ID, PDT_USU_AUDIT, PDT_FEC_AUDIT, PDT_OBS);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<expediente_entregas_det> EXP_PEDIDOS_ENTREGAS_DET_BY_PED_ID(long PDT_PED_ID)
    {
        try
        {
            List<expediente_entregas_det> list = new List<expediente_entregas_det>();
            ComprasDALTableAdapters.H2_EXP_PEDIDOS_ENTREGAS_DET_BY_PED_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_PEDIDOS_ENTREGAS_DET_BY_PED_IDTableAdapter();
            ComprasDAL.H2_EXP_PEDIDOS_ENTREGAS_DET_BY_PED_IDDataTable aTable = adapter.GetData(PDT_PED_ID);
            foreach (ComprasDAL.H2_EXP_PEDIDOS_ENTREGAS_DET_BY_PED_IDRow row in aTable.Rows)
            {
                list.Add(new expediente_entregas_det(row.PDT_ID, row.PDT_PED_ID, row.PDT_INS_ID, row.CANT_PEDIDA, row.DESCUENTO, row.ENT_SALDO, row.OBS, row.Insumo, row.Usuario,
                    row.PRE_UNI, row.CANT_ENTR, row.DEP_ID, row.ENT_FEC_ENT.ToShortDateString(), row.Deposito, row.PreUltCompra, row.EntDet_Id, row.USU_MED));
            }
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long EXP_PEDIDOS_ENTREGAS_CAB_INSERT(expediente_entregas_cab cab)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_EXP_PEDIDOS_ENTREGAS_CAB_INSERT(cab.PEE_NUMERO_REM, cab.PEE_EXP_ID, DateTime.Now.Date, cab.PEE_USUARIO,cab.PEE_PED_ID);
            if (Id != null) return Convert.ToInt64(Id.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long EXP_PEDIDOS_ENTREGAS_DET_INSERT(expediente_entregas_det ent)
    { 
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_EXP_PEDIDOS_ENTREGAS_DET_INSERT(ent.PEE_ID, ent.PEE_NUMERO_REM, ent.PDT_ID, ent.PEE_CANT_ENTR, ent.PEE_DEP_ID, DateTime.Parse(ent.PEE_FEC_ENTREGA), ent.PDT_OBS, ent.PEE_PRE_UNI,
                ent.PEE_MARCA, 0, ent.PDT_POR_DESC);
            if (Id != null) return Convert.ToInt64(Id.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void EXP_PEDIDOS_ENTREGAS_DET_DELETE(long PEE_ID)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_EXP_PEDIDOS_ENTREGAS_DET_DELETE(PEE_ID);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<expedientes_auditar_pedidos> COMPRAS_AUDITAR_PEDIDOS_LIST(string FechaDesde, string FechaHasta, long NroPedDesde, long NroPedHasta,
        string Insumo_nom, string Paciente, int Seccional, bool ConAuditoriaMed)
    {
        try
        {
            List<expedientes_auditar_pedidos> list = new List<expedientes_auditar_pedidos>();
            ComprasDALTableAdapters.H2_COMPRAS_AUDITAR_PEDIDOS_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_AUDITAR_PEDIDOS_LISTTableAdapter();
            ComprasDAL.H2_COMPRAS_AUDITAR_PEDIDOS_LISTDataTable aTable = adapter.GetData(DateTime.Parse(FechaDesde), DateTime.Parse(FechaHasta),
                NroPedDesde, NroPedHasta, Insumo_nom, Paciente, Seccional, ConAuditoriaMed);
            foreach (ComprasDAL.H2_COMPRAS_AUDITAR_PEDIDOS_LISTRow row in aTable.Rows)
            {
                //string _FechaAA = string.Empty;
                //if(!row.IsFechaAANull()) _FechaAA = row.FechaAA.ToShortDateString();

                string _FAuditado = string.Empty;
                if (!row.IsFAuditadoNull()) _FAuditado = row.FAuditado.ToShortDateString();

                list.Add(new expedientes_auditar_pedidos(row.ExpId, row.Afiliado, row.NroPed, row.PedAnt.ToShortDateString(), row.FReceta.ToShortDateString(), row.Insumo, row.Pedido, row.Urgente, row.Duracion, row.Descuento,
                   _FAuditado, row.Auditor, row.FIngreso.ToShortDateString(), row.USU_ING, row.Observaciones, row.DetalleID));
            }
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void COMPRAS_CONFIRMAR_AUDITORIA(long Usuario_Auditor, long PedidoID, bool Confirma, decimal Porcentaje)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_CONFIRMAR_AUDITORIA(Usuario_Auditor, PedidoID, Confirma, Porcentaje);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<expedientes_informe_global> COMPRAS_INFORME_GLOBAL_LIST(string FechaRemito_Desde, string FechaRemito_Hasta, long Nro_Remito_Desde, long Nro_Remito_Hasta, string Nom_Insumo, 
        long NroPedido_Desde, long NroPedido_Hasta, bool Pendientes, bool Entregados,string Paciente,int Seccional, int Deposito)
    {
        try
        {
            List<expedientes_informe_global> list = new List<expedientes_informe_global>();
            ComprasDALTableAdapters.H2_COMPRAS_INFORME_GLOBAL_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_INFORME_GLOBAL_LISTTableAdapter();
            ComprasDAL.H2_COMPRAS_INFORME_GLOBAL_LISTDataTable aTable = adapter.GetData(DateTime.Parse(FechaRemito_Desde), DateTime.Parse(FechaRemito_Hasta), Nro_Remito_Desde, Nro_Remito_Hasta, Nom_Insumo, NroPedido_Desde,
                NroPedido_Hasta, Pendientes, Entregados,Paciente,Seccional,Deposito);
            foreach (ComprasDAL.H2_COMPRAS_INFORME_GLOBAL_LISTRow row in aTable.Rows)
            {
                list.Add(new expedientes_informe_global(row.NroExpedienteCAB, row.Insumo, row.Pedido, row.Descuento, row.Fecha.ToShortDateString(), row.FarCant, row.FarPrecio, row.FarDesc, row.Saldo, row.Entregado,
                    row.Deposito, row.NroRemitoEnt, row.ENT_DET_ID));
            }
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long EXP_PEDIDOS_CAB_COPIAR(long PedidoId, int UsuarioId, int Duracion, bool Es_a_60_90)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object PedidoId_Nuevo = adapter.H2_COMPRAS_EXP_PEDIDOS_CAB_COPIAR(PedidoId, UsuarioId,Duracion);
            if (PedidoId_Nuevo != null) 
            {
                EXP_PEDIDOS_DET_COPIAR(PedidoId, Convert.ToInt64(PedidoId_Nuevo.ToString()), UsuarioId, Es_a_60_90);
                return Convert.ToInt64(PedidoId_Nuevo.ToString());
            }
            else throw new Exception("Error al crear copia del pedido.");        
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void EXP_PEDIDOS_DET_COPIAR(long PedidoId_CAB_Origen, long PedidoId_CAB_Nuevo, int UsuarioId, bool Es_a_60_90)
    { 
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_EXP_PEDIDOS_DET_COPIAR(PedidoId_CAB_Origen, PedidoId_CAB_Nuevo, UsuarioId, Es_a_60_90);    
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<expediente_historial_insumo> EXP_ENTREGAS_HISTORIAL_INSUMO_100(long NroExpediente, long InsumoID)
    {
        try
        {
            List<expediente_historial_insumo> list = new List<expediente_historial_insumo>();
            ComprasDALTableAdapters.H2_EXP_ENTREGAS_HISTORIAL_INSUMO_100TableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_ENTREGAS_HISTORIAL_INSUMO_100TableAdapter();
            ComprasDAL.H2_EXP_ENTREGAS_HISTORIAL_INSUMO_100DataTable aTable = adapter.GetData(NroExpediente, InsumoID);
            foreach (ComprasDAL.H2_EXP_ENTREGAS_HISTORIAL_INSUMO_100Row row in aTable.Rows)
            {
                string _FechaEntrega = string.Empty;
                if (!row.IsFechaEntregaNull()) _FechaEntrega = row.FechaEntrega.ToShortDateString();

                list.Add(new expediente_historial_insumo(row.Insumo, row.CantidadPedida, row.NroPedido, row.CantidadEntregada, _FechaEntrega));
            }
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public expediente_entregas_cab EXP_ENTREGA_CAB_BY_PED_CAB_ID(long PED_CAB_ID)
    {
        try
        {
            expediente_entregas_cab cab = new expediente_entregas_cab();
            ComprasDALTableAdapters.H2_EXP_ENTREGA_CAB_BY_PED_CAB_IDTableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_ENTREGA_CAB_BY_PED_CAB_IDTableAdapter();
            ComprasDAL.H2_EXP_ENTREGA_CAB_BY_PED_CAB_IDDataTable aTable = adapter.GetData(PED_CAB_ID);
            if (aTable.Rows.Count > 0)
                return (new expediente_entregas_cab(aTable[0].PEE_NUMERO_REM, aTable[0].PEE_EXP_ID, aTable[0].PEE_FECHA.ToShortDateString(), 0, PED_CAB_ID,aTable[0].IMPRESO));
            else return null;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
        
    }

    public void COMPRAS_ENTREGAS_CAB_IMPRESO(long PEE_REMITO_CAB)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_ENTREGAS_CAB_IMPRESO(PEE_REMITO_CAB);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void COMPRAS_ENT_CONTROL_DET_UPDATE(long EntDetId, decimal PrecioFarUni, int CantFarEnt, decimal DescFarEnt)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_ENT_CONTROL_DET_UPDATE(EntDetId, PrecioFarUni, CantFarEnt, DescFarEnt);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void COMPRAS_EXP_PEDIDOS_CAB_BAJA(long NroPedidoCAB)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_EXP_PEDIDOS_CAB_BAJA(NroPedidoCAB);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<expediente_entregas_cab> EXP_PEDIDOS_ENTREGAS_IDS_DURACION(long NroEntregaID)
    {
        try
        {
            List<expediente_entregas_cab> list = new List<expediente_entregas_cab>();
            ComprasDALTableAdapters.H2_EXP_PEDIDOS_ENTREGAS_IDS_DURACIONTableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_PEDIDOS_ENTREGAS_IDS_DURACIONTableAdapter();
            ComprasDAL.H2_EXP_PEDIDOS_ENTREGAS_IDS_DURACIONDataTable aTable = adapter.GetData(NroEntregaID);
            foreach (ComprasDAL.H2_EXP_PEDIDOS_ENTREGAS_IDS_DURACIONRow row in aTable.Rows)
                list.Add(new expediente_entregas_cab(row.PEE_NUMERO_REM,row.PED_ID));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<long> EXP_PEDIDOS_CAB_ID_POR_CAB_ORIGEN(long NroPedidoID_Origen)
    {
        try
        {
            List<long> list = new List<long>();
            list.Add(NroPedidoID_Origen);
            ComprasDALTableAdapters.H2_EXP_PEDIDOS_CAB_ID_POR_CAB_ORIGENTableAdapter adapter = new ComprasDALTableAdapters.H2_EXP_PEDIDOS_CAB_ID_POR_CAB_ORIGENTableAdapter();
            ComprasDAL.H2_EXP_PEDIDOS_CAB_ID_POR_CAB_ORIGENDataTable aTable = adapter.GetData(NroPedidoID_Origen);
            foreach (ComprasDAL.H2_EXP_PEDIDOS_CAB_ID_POR_CAB_ORIGENRow row in aTable.Rows)
                list.Add(row.PedidoCabID);
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long EXP_COMPRAS_ENTREGA_TOTAL_POR_PEDIDO(long PedidoIdOrigen, long PEE_USUARIO, long PEE_EXP_ID, int PEE_DEP_ID, DateTime PEE_FECHA_ENTREGA)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_EXP_COMPRAS_ENTREGA_TOTAL_POR_PEDIDO(PedidoIdOrigen, PEE_USUARIO, PEE_EXP_ID, PEE_DEP_ID, PEE_FECHA_ENTREGA);
            if (Id != null) return Convert.ToInt64(Id.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long EXP_COMPRAS_ENTREGA_PARCIAL_POR_PEDIDO(long PedidoIdOrigen, long PEE_USUARIO, long PEE_EXP_ID, int PEE_DEP_ID, DateTime PEE_FECHA_ENTREGA,
        int PEE_CANTIDAD, int PDT_INS_ID, long PDT_ID, decimal PDT_PORC_DESC)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_EXP_COMPRAS_ENTREGA_PARCIAL_POR_PEDIDO(PedidoIdOrigen, PEE_USUARIO, PEE_EXP_ID, PEE_DEP_ID, PEE_FECHA_ENTREGA,PEE_CANTIDAD,
                PDT_INS_ID,PDT_ID,PDT_PORC_DESC);
            if (Id != null) return Convert.ToInt64(Id.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public long EXP_COMPRAS_ENTREGA_PARCIAL_100(long PedidoIdOrigen, long PEE_USUARIO, long PEE_EXP_ID, int PEE_DEP_ID, DateTime PEE_FECHA_ENTREGA,
        int PEE_CANTIDAD, int PDT_INS_ID, long PDT_ID, decimal PDT_PORC_DESC)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object Id = adapter.H2_EXP_COMPRAS_ENTREGA_PARCIAL_100(PedidoIdOrigen, PEE_USUARIO, PEE_EXP_ID, PEE_DEP_ID, PEE_FECHA_ENTREGA, PEE_CANTIDAD,
                PDT_INS_ID, PDT_ID, PDT_PORC_DESC);
            if (Id != null) return Convert.ToInt64(Id.ToString());
            else return -1;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_reporte_amb_caba> COMPRAS_REPORTE_AMB_CABA(string Desde, string Hasta, int Filtro)
    {
        try
        {
            List<compras_reporte_amb_caba> list = new List<compras_reporte_amb_caba>();
            ComprasDALTableAdapters.H2_COMPRAS_REPORTE_AMB_CABATableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_REPORTE_AMB_CABATableAdapter();
            ComprasDAL.H2_COMPRAS_REPORTE_AMB_CABADataTable aTable = adapter.GetData(DateTime.Parse(Desde), DateTime.Parse(Hasta), Filtro);
            foreach (ComprasDAL.H2_COMPRAS_REPORTE_AMB_CABARow row in aTable.Rows)
                list.Add(new compras_reporte_amb_caba(row.NroExpediente, row.Paciente, row.Documento, row.NHC, row.NroPedido, row.Insumo, row.Cantidad_Pedida,
                    row.Porcentaje_Audit, row.Cantidad_Entregada, row.NroRemito, row.Saldo, row.Deposito,row.FechaPedido.ToShortDateString(), row.Seccional));
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void COMPRAS_INSUMOS_UPDATE(long INS_ID, string INS_DESCRIPCION, int INS_RUBRO)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_INSUMOS_UPDATE(INS_ID, INS_DESCRIPCION, INS_RUBRO);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public decimal COMPRAS_PEDIDOS_DESCUENTO_INSUMO_PAC(int INS_ID, long NRO_DOC)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object res = adapter.H2_COMPRAS_PEDIDOS_PORCENTAJE_POR_INSUMO_PAC(INS_ID, NRO_DOC);
            if (res != null) return Convert.ToDecimal(res.ToString());
            else return 0;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public long COMPRAS_CONSTANCIA_ENTREGA_INSERT(compras_constancia_entrega constancia)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            object res = adapter.H2_COMPRAS_CONSTANCIA_ENTREGA_INSERT(constancia.COMPRAS_CDE_ID, Convert.ToDateTime(constancia.COMPRAS_CDE_FECHA_RECETA), constancia.COMPRAS_CDE_PAC_ID,constancia.COMPRAS_CDE_PACIENTE,
                constancia.COMPRAS_CDE_NRODOC, constancia.COMPRAS_CDE_SECC, constancia.COMPRAS_CDE_ACTIVO, constancia.COMPRAS_CDE_USU_ID, constancia.COMPRAS_CDE_QUIROFANO,DateTime.Parse(constancia.COMPRAS_CDE_FECHA_QUIRO));
            if (res != null) return Convert.ToInt64(res.ToString());
            else return 0;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void COMPRAS_CONSTANCIA_ENTREGA_BAJA(long CDE_ID)
    {
        try
        {
            ComprasDALTableAdapters.QueriesTableAdapter adapter = new ComprasDALTableAdapters.QueriesTableAdapter();
            adapter.H2_COMPRAS_CONSTANCIA_ENTREGA_BAJA(CDE_ID);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<compras_constancia_entrega> COMPRAS_CONSTANCIA_ENTREGA_LIST(string Desde, string Hasta)
    {
        try
        {
            List<compras_constancia_entrega> list = new List<compras_constancia_entrega>();
            ComprasDALTableAdapters.H2_COMPRAS_CONSTANCIA_ENTREGA_LISTTableAdapter adapter = new ComprasDALTableAdapters.H2_COMPRAS_CONSTANCIA_ENTREGA_LISTTableAdapter();
            ComprasDAL.H2_COMPRAS_CONSTANCIA_ENTREGA_LISTDataTable aTable = adapter.GetData(DateTime.Parse(Desde), DateTime.Parse(Hasta));
            foreach (ComprasDAL.H2_COMPRAS_CONSTANCIA_ENTREGA_LISTRow row in aTable.Rows)
            {
                string _FECHA_QUIRO = string.Empty;
                if(!row.IsCOMPRAS_CDE_FECHA_QUIRONull()) _FECHA_QUIRO = row.COMPRAS_CDE_FECHA_QUIRO.ToShortDateString();
                list.Add(new compras_constancia_entrega(row.CDE_ID, row.FechaReceta.ToShortDateString(), row.PacienteID, row.Paciente, row.NroDoc, row.SeccionalID,
                        true, 0, _FECHA_QUIRO, row.COMPRAS_CDE_QUIROFANO, row.Seccional));
            }         
            return list;
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
