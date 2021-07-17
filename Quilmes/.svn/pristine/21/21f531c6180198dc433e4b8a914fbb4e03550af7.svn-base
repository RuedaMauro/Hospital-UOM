using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VerificadorBLL
/// </summary>
namespace Hospital
{
    public class VerificadorBLL
    {
        public VerificadorBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool Permisos(string Permisos, string Seccion, string Tipo)
        {
            bool Resultado = false;

            if (Tipo == null)
            {
                Resultado = false;
                return Resultado;
            }

            if (Permisos == "") { Permisos = "-1"; }

            
           

            if (Tipo == "SuperUsuario" || Tipo.ToString() == "Administrador")
            {
                Resultado = true;
            }
            else
            {
                char[] separator = new char[] { '|' };
                string[] strSplitArr = Permisos.Split(separator);
                foreach (string arrStr in strSplitArr)
                {
                    if (arrStr == Seccion)
                    {
                        Resultado = true;
                        return true;
                    }
                }
            }

            return Resultado;
        }

    


        public bool PermisosM(string Permisos, string Seccion, string Tipo)
        {
            bool Resultado = false;

            if (Tipo == null)
            {
                Resultado = false;
                return Resultado;
            }


            if (Seccion.Equals("9999"))
            {
                string interno = ((usuarios)HttpContext.Current.Session["Usuario"]).interno;
                if (interno.Equals("SISTEMAS")) return true;
                else return false;
            }

            if (Permisos == "") { Permisos = "-1"; }
            if (Tipo == "SuperUsuario" || Tipo.ToString() == "Administrador")
            {
                Resultado = true;
            }
            else
            {
                char[] separator = new char[] { '|' };
                string[] strSplitArr = Permisos.Split(separator);
                foreach (string arrStr in strSplitArr)
                {
                    string Consultando = arrStr;
                    if (Consultando.Length > 1) { Consultando = Consultando.Substring(0, Consultando.Length - 1); }
                    if (Consultando == Seccion)
                    {
                        Resultado = true;
                        return true;
                    }
                }
            }

            return Resultado;
        }

        public bool PermisoOK(String Seccion)
        {
            try
            {
                usuarios u = (usuarios)HttpContext.Current.Session["Usuario"];
                if (u == null)
                {
                    return false;
                }
                if (Permisos(u.permisos, Seccion, u.tipo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool Permiso(String Seccion)
        {
            try
            {
                usuarios u = (usuarios)HttpContext.Current.Session["Usuario"];
                if (u == null) {
                    System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");
                    return false; 
                }
                if (Permisos(u.permisos, Seccion, u.tipo))
                {
                    return true;
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");
                    return false;
                }
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");
                return false;
            }
        }

        public bool PermisoMenu(String Seccion)
        {
            try
            {
                usuarios u = (usuarios)System.Web.HttpContext.Current.Session["Usuario"];
                if (u == null) {
                    System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");
                    return false; 
                }
                if (PermisosM(u.permisos, Seccion, u.tipo))
                {
                    return true;
                }
                else
                {                       
                    return false;
                }
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");
                return false;
            }
        }

        public bool PermisoSM(String Seccion)
        {
            try
            {
                usuarios u = (usuarios)System.Web.HttpContext.Current.Session["Usuario"];
                if (u == null)
                {
                    System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");
                    return false;
                }
                if (Permisos(u.permisos, Seccion, u.tipo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx");
                return false;
            }
        }



        public bool PermisoMensajes(String Seccion)
        {
            try
            {
                usuarios u = (usuarios)System.Web.HttpContext.Current.Session["Usuario"];
                if (u == null)
                {
                    return false;
                }
                if (PermisosSinPrivilegios(u.permisos, Seccion, u.tipo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        public bool PermisosSinPrivilegios(string Permisos, string Seccion, string Tipo)
        {
            bool Resultado = false;

            if (Tipo == null)
            {
                Resultado = false;
                return Resultado;
            }

            if (Permisos == "") { Permisos = "-1"; }
            
            
            {
                char[] separator = new char[] { '|' };
                string[] strSplitArr = Permisos.Split(separator);
                foreach (string arrStr in strSplitArr)
                {
                    if (arrStr == Seccion)
                    {
                        Resultado = true;
                        return true;
                    }
                }
            

            return Resultado;
        }



}


    }
}