using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

/// <summary>
/// Summary description for CambiarClave
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]
public class CambiarClave : System.Web.Services.WebService {

    public CambiarClave () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public int CambiarLaClave(string ClaveAnt, string ClaveNueva, string ClaveNuevaRep)
    {
        if (Session["Usuario"] != null)
        {
            usuarios u = new usuarios();
            Hospital.AdministracionBLL adm = new Hospital.AdministracionBLL();
            if (!string.Equals(ClaveNueva, ClaveNuevaRep, StringComparison.OrdinalIgnoreCase)) throw new Exception("Las claves no coinciden.");
            return adm.Administracion_Cambiar_Clave(Convert.ToInt32(((usuarios)Session["Usuario"]).id), ClaveAnt, ClaveNueva);
        }
        else return 0;
    }
    
}
