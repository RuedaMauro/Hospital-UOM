using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for documentacion
/// </summary>
public class documentacion
{
	public documentacion()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long id { get; set; }
    public string descripcion {get; set;}
    public bool eliminado { get; set; }

}

public class documentacion_archivos
{
    public long idpaciente { get; set; }
    public int cantidad { get; set; }
    public string archivo { get; set; }
    public string tipodocu { get; set; }

    //Esto es para la documetacion de IMG
    public string fecha { get; set; }
}