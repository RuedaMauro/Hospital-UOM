using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for internacion
/// </summary>
public class internacion
{
	public internacion()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

public class int_ingreso
{
    public long id { get; set; }
    public long AfiliadoId { get; set; }
    public DateTime fecha { get; set; }
    public string dia { get; set; }
    public string hora { get; set; }
    public int servicioId { get; set; }
    public int salaId { get; set; }
    public int CamaId { get; set; }
    public string telefono { get; set; }
    public string direccion_acompa { get; set; }
    public string diagnostico { get; set; }
    public int hospitalizadopor { get; set; }
    public int motivoingreso { get; set; }
    public string observaciones { get; set; }
    public int especialidad { get; set; }
    public int medico { get; set; }
    public long NHC { get; set; }
    public string servicio { get; set; }
    public string sala { get; set; }
    public string cama { get; set; }
}

public class int_egreso
{
    public string diagnosticoicd10 { get; set; }
    public string diagnosticoicd10_desc { get; set; }
    
    public string detalleicd10 { get; set; }
    public string detalleicd10_desc { get; set; }

    public string detalleicd10_3 { get; set; }
    public string detalleicd10_3desc { get; set; }

    public int motivoegreso  { get; set; }
    public string observacionegreso  { get; set; }
    public string operado { get; set; }
    public string fechaoperado { get; set; }
    public int egresoespecialidad { get; set; }
    public int egresomedico { get; set; }
    public bool egresocancelado { get; set; }
    public DateTime fechaegreso { get; set; }
    public long NHC { get; set; }
    public long AfiliadoId { get; set; }
    public string Paciente { get; set; }
    public int Edad { get; set; }
    public long DNI { get; set; }
    public string Seccional { get; set; }
    public string Telefono { get; set; }
    public DateTime fecha { get; set; }
    public string dia { get; set; }
    public string hora { get; set; }
    public string servicio { get; set; }
    public string sala { get; set; }
    public string cama { get; set; }
    public string bclas { get; set; }
    public string EgresoUsuario { get; set; }
    public DateTime fechaIngreso { get; set; }//manuel
    public string diaIngreso { get; set; }//manuel
    public string horaIngreso { get; set; }//manuel
}

public class DiagnosticoICD10Detalle
{
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
}

public class intresumen
{
    public string cama { get; set; }
    public string sala { get; set; }
    public string servicio { get; set; }
    public string fechaingreso { get; set; }
    public string fechaegreso { get; set; }
}

public class buscarinternacion
{
    public int Id { get; set; }
    public string Fecha { get; set; }
    public string Servicio { get; set; }
    public string Sala { get; set; }
    public string Cama { get; set; }
    public string Paciente { get; set; }
    public string NHC { get; set; }
    public int CamaId { get; set; }    

}

public class estado_aislado
{
    public string Estado { get; set; }
    public string Clase { get; set; }
    public string Usuario { get; set; }
    public string Fecha { get; set; }
    public string Motivo { get; set; }
}

public class CamaToPrint
{
    public int CamaId { get; set; }
    public string CamaDescripcion { get; set; }
    public string Fecha { get; set; }
    public string Diagnostico { get; set; }
    public string NroHC { get; set; }
    public string NombreYApellido { get; set; }
    public string SeccionalDescripcion { get; set; }
    public string EspecialidadDescripcion { get; set; }
    public string Estado { get; set; }
    public string OS { get; set; }
    public string Hora { get; set; }
    public string Dias { get; set; }
    public string Edad { get; set; }
    public string Sexo { get; set; }

    public CamaToPrint(int CamaId, string CamaDescripcion)
    {
        this.CamaId = CamaId;
        this.CamaDescripcion = CamaDescripcion;
    }
}

public class CensoToPrint
{
    public List<ServicioToPrint> Servicios { get; set; }

    public CensoToPrint()
    {
        Servicios = new List<ServicioToPrint>();
    }
}

public class ServicioToPrint
{
    public int ServicioId { get; set; }
    public string ServicioDescripcion { get; set; }
    public List<SalaToPrint> Salas { get; set; }

    public ServicioToPrint(int ServicioId, string ServicioDescripcion)
    {
        Salas = new List<SalaToPrint>();
        this.ServicioId = ServicioId;
        this.ServicioDescripcion = ServicioDescripcion;
    }
}

public class SalaToPrint
{
    public int SalaId { get; set; }
    public string SalaDescripcion { get; set; }
    public List<CamaToPrint> Camas { get; set; }

    public SalaToPrint(int SalaId, string SalaDescripcion)
    {
        Camas = new List<CamaToPrint>();
        this.SalaId = SalaId;
        this.SalaDescripcion = SalaDescripcion;
    }


    public int TotalDeCamas
    {
        get { return Camas.Count; }
    }

    public int Ocupadas
    {
        get
        {
            int count = 0;
            foreach (CamaToPrint c in Camas)
            {
                if (c.Estado != "Libre")
                    count++;
            }
            return count;
        }
    }

    public int Libres
    {
        get
        {
            int count = 0;
            foreach (var c in Camas)
            {
                if (c.Estado == "Libre")
                    count++;
            }
            return count;
        }
    }

    public double OcupadasPorcentaje
    {
        get
        {
            if (Ocupadas + Libres == 0)
                return 0;
            return Ocupadas * 100 / (Ocupadas + Libres);
        }
    }

    public double LibresPorcentaje
    {
        get
        {
            if (Ocupadas + Libres == 0)
                return 0;
            return Libres * 100 / (Ocupadas + Libres);
        }
    }

    public int DiasInternado { get; set; }

}

public class at_internaciones_buscar
{
    public string Sala { get; set; }
    public string Cama { get; set; }
    public long NHC { get; set; }
    public string Afiliado { get; set; }
    public string FIngreso { get; set; }
    public string Diagnostico { get; set; }
    public int SalaId { get; set; }
    public int CamaId { get; set; }
    public int ServicioId { get; set; }
    public long internacion { get; set; }
    public string NHC_UOM { get; set; }
    public string Seccional { get; set; }
    public string Servicio { get; set; }
}


public class evolucion
{
    public string fecha { get; set; }
    public string hh { get; set; }
    public string ff { get; set; }
    public int medicoid { get; set; }
    public string medico { get; set; }
    public string evoluciones { get; set; }
    public long internacionid { get; set; }
    public long NHC { get; set; }
    public int camaid { get; set; }
    public string cama { get; set; }
    public int salaid { get; set; }
    public string sala { get; set; }
    public long EId { get; set; }
    public int especialidadId { get; set; }
    public string especialidad { get; set; }
    public bool Editable { get; set; }
}

public class BusquedaInternadosId
{
    public string fecha { get; set; }
    public string medico { get; set; }
    public int medicoid { get; set; }
    public int dni { get; set; }
    public long NHC { get; set; }
    public int camaid { get; set; }
    public string cama { get; set; }
    public int salaid { get; set; }
    public string sala { get; set; }
    public string paciente { get; set; }
    public long servicioid { get; set; }
    public string servicio { get; set; }
}

public class EpicrisisDatosCargado
{
    public string NHC { get; set; }
    public string internacionId { get; set; }
    public string ingreso_DX { get; set; }
    public string ingreso_Detalle { get; set; }
    public string ingreso_Ant1 { get; set; }
    public string ingreso_Ant2 { get; set; }
    public string ingreso_Ant3 { get; set; }
    public string ingreso_Ant4 { get; set; }
    public string ingreso_Ant5 { get; set; }
    public string ingreso_Ant6 { get; set; }
    public string ingreso_Ant7 { get; set; }
    public string ingreso_Ant8 { get; set; }
    public string ingreso_Ant9 { get; set; }
    public string ingreso_Ant10 { get; set; }
    public string ingreso_motivo { get; set; }
    public string ingreso_ant_personales { get; set; }
    public string ingreso_int_actual { get; set; }
    public string laboratorio { get; set; }
    public string imagen { get; set; }
    public string otros { get; set; }
    public string diagnostico { get; set; }
    public int motivo_alta { get; set; }
    public string egreso_indicacion { get; set; }
    public string fecha_concurrir { get; set; }
    public string egreso_compilacion { get; set; }
    public string egreso_dx { get; set; }
    public string egreso_detalle { get; set; }
    public string egreso_detalle3 { get; set; }
    public int MedicoId { get; set; }
    public int EspecialidadId { get; set; }
    public string fecha_ingreso { get; set; }
    public string fecha_egreso { get; set; }

    public string egreso_dx_desc { get; set; }
    public string egreso_detalle_desc { get; set; }
    public string egreso_detalle3_desc { get; set; }
}

public class Acompa_Internacion
{
    public Acompa_Internacion()
    { 
    
    }

    public long NroInternacion { get; set; }
    public string Nombre { get; set; }
    public string TipoDoc { get; set; }
    public int DNI { get; set; }
    public string Parentezco { get; set; }
    public string Calle { get; set; }
    public string Numero { get; set; }
    public string Piso { get; set; }
    public string CP { get; set; }
    public string Localidad { get; set; }
    public string Provincia { get; set; }
    public string Telefono { get; set; }
    public string Observaciones { get; set; }
}

public class Interconsulta
{
    public Interconsulta()
    {

    }
    public long IdInterconsulta { get; set; }
    public long NroInternacion { get; set; }
    public long NHC { get; set; }
    public long MedicoSol { get; set; }
    public long MedicoInter { get; set; }
    public long EspecialidadInter { get; set; }
    public string Fecha { get; set; }
    public string FechaCierre { get; set; }
    public string Motivo { get; set; }
    public int Estado { get; set; }
    public string Observacion { get; set; }
    public string Indicacion { get; set; }
}

public class InterconsultaList : Interconsulta
{
    public InterconsultaList()
    { }

    public string MedicoSolDesc { get; set; }
    public string MedicoInterDesc { get; set; }
    public string EspecialidadInterDesc { get; set; }
    public string RowClass { get; set; }
    public string HC_UOM { get; set; }
    public string Afiliado { get; set; }
    public string Servicio { get; set; }
    public string Cama { get; set; }
    public string MedicoExterno { get; set; }
}

public class HojaEnfermeria
{
    public HojaEnfermeria() { }

    public long IdDetalle { get; set; }
    public long IdIM { get; set; }
    public long IdInsumo { get; set; }
    public int Frecuencia { get; set; }
    public bool EnHoras { get; set; }
    public string Indicacion { get; set; }
}

public class HojaEnfermeriaCab
{
    public HojaEnfermeriaCab() { }

    public long IdHoja {get;set;}
    public long NHC {get;set;}
    public long IdSala {get;set;}
    public long IdCama {get;set;}
    public long IdServicio {get;set;}
    public string Fecha {get;set;}
    public long IdInternacion {get;set;}
    public long UsuarioId { get; set; }
    public long MedicoId { get; set; }
}

public class HojaEnfermeriaDet:HojaEnfermeria
{
    public HojaEnfermeriaDet() { }

     public long IdHoja {get;set;}
     public long IdInsumo {get;set;}
     public string Indicacion {get;set;}
     public bool EnHoras {get;set;}
     public int Frecuencia {get;set;}
     public string Observaciones {get;set;}
     public int Enfermera {get;set;}
     public bool Realizado {get;set;}

}

public class HojaEnfermeriaList
{
    public HojaEnfermeriaList() { }

    public long IdHoja { get; set; }
    public long NHC { get; set; }
    public string Paciente { get; set; }
    public string Medico { get; set; }
    public string Servicio { get; set; }
    public string Fecha { get; set; }
}
 
public class HojaEnfermeriaCabList : HojaEnfermeriaCab
{
    public HojaEnfermeriaCabList() { }

    public string Paciente {get;set;}
    public string Cama {get;set;}
    public string Sala {get;set;}
    public string Servicio {get;set;}
    public string Medico {get;set;}
    public string Seccional {get;set;}
}


//=======================MANUEL===============================================================
//public class encabezadoNutricion
//{
//    public encabezadoNutricion() { }
//    public string telefono { get; set; }
//    public string localidad { get; set; }
//    public string NHC_UOM { get; set; }
//    public long documento_real { get; set; }
//    public string apellido { get; set; }
//    public int edad { get; set; }
//    public string seccional { get; set; }
//    public string servicio { get; set; }
//    public string cama { get; set; }
//    public string medico { get; set; }
//    public string documento { get; set; }
//}

//public class indicacionesNutricion
//{
//    public indicacionesNutricion() { }

//    public string REM_NOMBRE { get; set; }
//    public string indicacion { get; set; }
//    public string codAlmuerzo { get; set; }
//    public string descAlmuerzo { get; set; }
//    public string codCena { get; set; }
//    public string descCena { get; set; }
//}

//public class pedidoNutricion
//{
//    public pedidoNutricion() { }

//    public long idPedido { get; set; }
//    public string tipificacion { get; set; }
//    public string dieta { get; set; }
//    public int cantidad { get; set; }
//    public string fecha { get; set; }
//    public string codAlmuerzo { get; set; }
//    public string desAlmuerzo { get; set; }
//    public string codCena { get; set; }
//    public string desCena { get; set; }
//}


public class AtInternacionHojaQuirirgico
{
    public int PRQ_ID { get; set; }
    public string PRQ_FECHA { get; set; }
    public string PRQ_SOC_ID { get; set; }
    public string PRQ_DIAG_ID { get; set; }
    public string PRQ_ESP_ID { get; set; }
    public string PRQ_MEDICO_ID { get; set; }
    public string PRQ_CIRU_ID { get; set; }
    public string PRQ_ESQUEMA_OPE { get; set; }
    public string PRQ_SESION { get; set; }
    public string PRQ_USUARIO { get; set; }
    public string PRQ_CAMA_ID { get; set; }
    public string PRQ_GUA_ID { get; set; }
    public string CAMA_DESCRIPCION { get; set; }
    public string PRACTICA_DESCRIPCION { get; set; }
    public string SALA_DESCRIPCION { get; set; }    
}

public class Pase_Guardia_UTI
{
    public Pase_Guardia_UTI() { }

    public long Pase_Guardia_UTI_Id { get; set; }
    public long PacienteId { get; set; }
    public string Fecha { get; set; }
    public string Cama { get; set; }
    public string DiagnosticoPresuntivo { get; set; }
    public string Antecedentes { get; set; }
    public int DiasUTI { get; set; }
    public string DatosQuirurgicos { get; set; }
    public string DatosAP { get; set; }
    public bool VentilacionMecanica { get; set; }
    public bool Traqueostomia { get; set; }
    public string ModoVentilatorio { get; set; }
    public int DiasVentilacion { get; set; }
    public string RX { get; set; }
    public string ECG { get; set; }
    public int Alimentacion { get; set; }
    public string OtrasImagenes { get; set; }
    public string Gases { get; set; }
    public string Laboratorio_DatosPositivos { get; set; }
    public bool Infectologia { get; set; }
    public string Cultivos_Germen { get; set; }
    public string DiasATB { get; set; }
    public string Pendientes_Interconsultas { get; set; }
    public string Pendientes_Estudios { get; set; }
    public string Novedades_del_dia { get; set; }
    public bool Estado { get; set; }
    public long UsuarioId { get; set; }
    public long InternacionId { get; set; }
    public long UsuarioId_Visto { get; set; }
    public string FechaSistema_Visto { get; set; }
    public string UsuarioNombre_Visto { get; set; }
    public string Observaciones { get; set; }
    public int DiasAlimentacion { get; set; }
}

public class Pase_Guardia_UTI_Lista
{
    public Pase_Guardia_UTI_Lista() { }

    public long EvolucionId { get; set; }
    public string Fecha { get; set; }
    public long InternacionId { get; set; }
    public string Evolucion { get; set; }
    public string Servicio { get; set; }
    public string Sala { get; set; }
    public string Cama { get; set; }
    public string PacienteNombre { get; set; }
    public string NHC { get; set; }
}

public class PaseCama
{
    public long PaseCama_Id { get; set; }
    public string PaseCama_Desc { get; set; }
    public string PaseCama_Fecha { get; set; }
    public long PaseCama_UsuarioId { get; set; }
    public bool PaseCama_Baja { get; set; }
    public long PaseCama_InternacionId { get; set; }

    public PaseCama() { }

    public PaseCama(long _PaseCama_Id, string _PaseCama_Desc, string _PaseCama_Fecha,long _PaseCama_InternacionId, long _PaseCama_UsuarioId = 0, bool _PaseCama_Baja = false) 
    {
        PaseCama_Id = _PaseCama_Id;
        PaseCama_Desc = _PaseCama_Desc;
        PaseCama_Fecha = _PaseCama_Fecha;
        PaseCama_InternacionId = _PaseCama_InternacionId;
        PaseCama_UsuarioId = _PaseCama_UsuarioId;
        PaseCama_Baja = _PaseCama_Baja;
    }
}