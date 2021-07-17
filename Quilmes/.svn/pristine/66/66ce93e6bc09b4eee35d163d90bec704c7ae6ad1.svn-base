using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de reportesCompras
/// </summary>


namespace Hospital
{
    public class reportesComprasBLL
    {
        public reportesComprasBLL()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public List<itemCombo> Reportes_Compras_Traer_Patologias()
        {

            ReportesComprasTableAdapters.H2_Reportes_Compras_Traer_PatologiasTableAdapter adapter = new ReportesComprasTableAdapters.H2_Reportes_Compras_Traer_PatologiasTableAdapter();
            ReportesCompras.H2_Reportes_Compras_Traer_PatologiasDataTable aTable = adapter.GetData();

            List<itemCombo> list = new List<itemCombo>();
            foreach (ReportesCompras.H2_Reportes_Compras_Traer_PatologiasRow row in aTable.Rows)
            {
                itemCombo item = new itemCombo();

                item.id = row.id;
                item.descripcion = row.Descripcion;
                list.Add(item);
            }

            return list;
        }

        public List<itemCombo> Reportes_Compras_Traer_Insumos()
        {

            ReportesComprasTableAdapters.H2_Reportes_Compras_Traer_InsumosTableAdapter adapter = new ReportesComprasTableAdapters.H2_Reportes_Compras_Traer_InsumosTableAdapter();
            ReportesCompras.H2_Reportes_Compras_Traer_InsumosDataTable aTable = adapter.GetData();

            List<itemCombo> list = new List<itemCombo>();
            foreach (ReportesCompras.H2_Reportes_Compras_Traer_InsumosRow row in aTable.Rows)
            {
                itemCombo item = new itemCombo();

                item.id = row.id;
                item.descripcion = row.descripcion;
                list.Add(item);
            }

            return list;
        }

    }
}