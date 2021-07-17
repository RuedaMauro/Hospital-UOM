using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for historiaclinica
/// </summary>
public class historiaclinica
{
	public historiaclinica()
	{
		//
		// TODO: Add constructor logic here
		//

     }
    public string HClinica { get; set; }

}

public class lista_protocolos
{
    public string ruta { get; set; }
    public string archivo { get; set; }
}

public class labo_protocolos
{
    public int documento { get; set; }
    public string protocolo { get; set; }
    public string archivo { get; set; }
    public string fecha { get; set; }
    public string ruta { get; set; }
}

public class interconsulta
{
    public long id { get; set; }
    public string fecha { get; set; }
    public string medsol { get; set; }
    public string espinter { get; set; }
    public string medinter { get; set; }
    public string motivo { get; set; }
}


public class hc_imagenes
{
    public long IMG_ID { get; set; }
    public string IMG_FECHA_INICIO { get; set; }
    public string IMG_NUMERO { get; set; }
    public string IMG_PATH { get; set; }
    public string IMG_USUARIO { get; set; }
    public string TIMG_DESCRIPCION { get; set; }
    public string WORK_LIST_NUMERO { get; set; }
}


public class hc_anatomiapatologica
{
    public long PAT_NUMERO { get; set; }
    public string PAT_FECHA_INICIO { get; set; }
    public string PMAT_DESCRIPCION { get; set; }
    public string MED_APELLIDO_NOMBRE { get; set; }
    //public string IMG_USUARIO { get; set; }
    //public string TIMG_DESCRIPCION { get; set; }
}

public class lista_anios
{
    public string anio { get; set; }
}

public class lista_meses
{
    public string mes { get; set; }
}

public class registro_internacion
{
    public string ingreso { get; set; }
    public string egreso { get; set; }
    public string servicio { get; set; }
    public int idservicio { get; set; }
    public string motivoingreso { get; set; }
    public string motivoegreso { get; set; }
    public string especialidad { get; set; }
    public string medico { get; set; }
    public string id { get; set; }
    public string cama { get; set; }
}


public class registro_cirugias
{
    public string fecha { get; set; }
    public string cirugia { get; set; }
    public string medico { get; set; }
    public string diagnostico { get; set; }
    public string especialidad { get; set; }
    public string id { get; set; }
}

public class registro_recetas
{
    public string fecha { get; set; }
    public string medico { get; set; }
    public string diagnostico { get; set; }
    public string especialidad { get; set; }
    public string id { get; set; }
}

public class registro_ambulatorio
{
    public string id { get; set; }
    public string fecha { get; set; }
    public string especialidad { get; set; }
    public string medico { get; set; }
    public string diagnostico { get; set; }
    public string tipo { get; set; }
}

public class HC_Compacta
{
    public string fecha { get; set; }
    public string HC { get; set; }
}

public class HC_Movimiento
{
    public long Id { get; set; }
    public string Fecha { get; set; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public long OrigenId { get; set; }
    public long DestinoId { get; set; }
    public string Usuario { get; set; }
    public long UsuarioId { get; set; }
    public bool Estado { get; set; }
    public string NHC { get; set; }
    public string Observaciones { get; set; }

    public HC_Movimiento() { }
}