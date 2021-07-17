using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de QuirofanoReporte
/// </summary>
public class QuirofanoReporteItem
{
    public QuirofanoReporteItem()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public QuirofanoReporteItem(long idd, string nombree)
    {
        id = idd;
        nombre = nombree;
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public string nombre { get; set; }
    public long id { get; set; }

    ////reporte de indicadores
    public int idIndicador;
    public string codigo;
    public string descripcion;
    public Boolean titulo;
    public int cantidad;
    public Boolean soon;
    public string desde;
    public string hasta;
   
}