﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Imagenes_Turno_Practica_Duracion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Hospital.VerificadorBLL v = new Hospital.VerificadorBLL(); if (!v.Permiso("112")) { Response.Redirect("Login.aspx"); }
    }
}