using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AtConsultorio_Cargar_Recetas_Diabetes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  
            AtConsultoioDALTableAdapters.H2_AtConsultorio_Diabetes_Traer_Presentaciones_DiabetesTableAdapter adapter = new AtConsultoioDALTableAdapters.H2_AtConsultorio_Diabetes_Traer_Presentaciones_DiabetesTableAdapter();
            AtConsultoioDAL.H2_AtConsultorio_Diabetes_Traer_Presentaciones_DiabetesDataTable atable = new AtConsultoioDAL.H2_AtConsultorio_Diabetes_Traer_Presentaciones_DiabetesDataTable();

            List<PresentacionesDiabetes> L = new List<PresentacionesDiabetes>();

            atable = adapter.GetData("glibenclamida");
            foreach (AtConsultoioDAL.H2_AtConsultorio_Diabetes_Traer_Presentaciones_DiabetesRow row in atable.Rows)
            {
                PresentacionesDiabetes p = new PresentacionesDiabetes();
                    
                p.id = row.id;
                p.presentacion = row.presetacion;
                p.seCorresponde = row.seCorresponde;
                L.Add(p);
            }
     
       

        }

}