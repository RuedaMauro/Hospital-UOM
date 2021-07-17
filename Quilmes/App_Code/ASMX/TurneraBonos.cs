using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de TurneraTurno
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class TurneraBonos : System.Web.Services.WebService {

    public TurneraBonos()
    {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public turnera_bonos H2_Turnera_Turnos_Leer()
    {
        Hospital.TurneraBLL T = new Hospital.TurneraBLL();
        return T.ProximoTurnoBono();
    }

    [WebMethod(EnableSession = true)]
    public void Asignar_Box_Bonos_Turnos(string Box)
    {
        if (Session["Usuario"] != null)
        {
            ((usuarios)Session["Usuario"]).Box_Turno_Bono = Box;
        }
    }


    [WebMethod(EnableSession = true)]
    public turnera_bonos Turnera_Turno_Llamar_Bonos()
    {
        Hospital.TurneraBLL T = new Hospital.TurneraBLL();
        if (Session["Usuario"] != null)
        {
            try
            {
                return T.Llamar_Turno_Bono(((usuarios)Session["Usuario"]).Box_Turno_Bono, Convert.ToInt32(((usuarios)Session["Usuario"]).id));
            }
            catch
            {
                throw new Exception("Error al llamar un paciente");
            }
        }
        else
        {
            throw new Exception("Por favor vuelva a iniciar sesión.");
        }
        return null;
    }
    
    
}
