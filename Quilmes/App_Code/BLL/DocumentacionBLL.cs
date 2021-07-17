using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DocumentacionBLL
/// </summary>
namespace Hospital
{
    public class DocumentacionBLL
    {
        public DocumentacionBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public List<documentacion> Documentacion_Lista()
        {
            DocumentacionPacientesTableAdapters.H2_GENTE_DOCUMENTOS_LISTATableAdapter adapter = new DocumentacionPacientesTableAdapters.H2_GENTE_DOCUMENTOS_LISTATableAdapter();
            DocumentacionPacientes.H2_GENTE_DOCUMENTOS_LISTADataTable aTable = adapter.GetData();
            List<documentacion> Lista = new List<documentacion>();
            foreach (DocumentacionPacientes.H2_GENTE_DOCUMENTOS_LISTARow row in aTable.Rows)
            {
                documentacion d = new documentacion();
                d.descripcion = row.descri;
                d.id = row.id;
                Lista.Add(d);
            }
            return Lista;
        }

        public List<documentacion_archivos> Documentacion_Archivos(long IdPaciente)
        {
            DocumentacionPacientesTableAdapters.H2_PACIENTES_DOCUMENTACIONTableAdapter adapter = new DocumentacionPacientesTableAdapters.H2_PACIENTES_DOCUMENTACIONTableAdapter();
            DocumentacionPacientes.H2_PACIENTES_DOCUMENTACIONDataTable aTable = adapter.GetData(IdPaciente);
            List<documentacion_archivos> Lista = new List<documentacion_archivos>();
            foreach (DocumentacionPacientes.H2_PACIENTES_DOCUMENTACIONRow row in aTable.Rows)
            {
                documentacion_archivos d = new documentacion_archivos();
                d.archivo = row.archivo;
                d.cantidad = row.documentos_cant;
                d.idpaciente = row.idpaciente;
                d.tipodocu = row.tipodesc;
                Lista.Add(d);
            }
            return Lista;
        }

        public List<documentacion_archivos> Documentacion_Archivos_Ordenes_Medica(long IdPaciente)
        {
            DocumentacionPacientesTableAdapters.H2_PACIENTES_DOCUMENTACION_ORDEN_MEDICOTableAdapter adapter = new DocumentacionPacientesTableAdapters.H2_PACIENTES_DOCUMENTACION_ORDEN_MEDICOTableAdapter();
            DocumentacionPacientes.H2_PACIENTES_DOCUMENTACION_ORDEN_MEDICODataTable aTable = adapter.GetData(IdPaciente);
            List<documentacion_archivos> Lista = new List<documentacion_archivos>();
            foreach (DocumentacionPacientes.H2_PACIENTES_DOCUMENTACION_ORDEN_MEDICORow row in aTable.Rows)
            {
                documentacion_archivos d = new documentacion_archivos();
                d.archivo = row.archivo;
                d.cantidad = row.documentos_cant;
                d.idpaciente = row.idpaciente;
                d.tipodocu = row.tipodesc;
                d.fecha = row.documentacion_fecha.ToShortDateString();
                Lista.Add(d);
            }
            return Lista;
        }

        public void Documentacion_Eliminar(string Archivo, int PacienteId)
        {
            DocumentacionPacientesTableAdapters.QueriesTableAdapter adapter = new DocumentacionPacientesTableAdapters.QueriesTableAdapter();
            adapter.H2_Documentacion_Paciente_Eliminar(Archivo, PacienteId);            
        }


    }
}