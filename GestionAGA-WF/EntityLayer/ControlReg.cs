using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class ControlReg
    {
        public int ID {get; set;}
	    public int Clv_Solicitud {get; set;}
	    public string Clv_Edo {get; set;}
	    public string Estado {get; set;}
	    public string Clv_Mpo {get; set;}
	    public string Municipio {get; set;}
	    public string ObsMpo {get; set;}
	    public string Clv_Tipo {get; set;}
	    public string Clv_Nuc {get; set;}
	    public string Nucleo {get; set;}
	    public string ObsNuc {get; set;}
	    public int Clv_GpoDoc1 {get; set;}
	    public int Clv_GpoDoc2 {get; set;}
	    public int Clv_TipoProc {get; set;}
	    public int Clv_Proc {get; set;}
	    public int Clv_Responsable {get; set;}
	    public string Fecha_Oficio {get; set;}
	    public string Solicitado_por {get; set;}
	    public string Oficio_Solicitud {get; set;}
	    public string Fecha_Solicitud {get; set;}
	    public string Doc_Solicitados {get; set;}
	    public string Obs_Solicitud {get; set;}
	    public string Obs_PreTurnado {get; set;}
	    public string Oficio_Salida {get; set;}
	    public string Oficio_Salida2 {get; set;}
	    public string Fecha_OfSalida {get; set;}
	    public string Fecha_OfSalida2 {get; set;}
	    public string Clv_Status {get; set;}
	    public string FolioOfPartes {get; set;}
	    public string FecOfPartes {get; set;}
	    public string No_Expediente {get; set;}
	    public string Cve_Prioridad {get; set;}
	    public string Fecha_Venc {get; set;}
	    public int Clv_Turnado {get; set;}
	    public int Clv_Usuario {get; set;}
	    public string Fecha_Turnado {get; set;}
	    public string Obs_Turnado {get; set;}
	    public string No_FojasCarOfi {get; set;}
	    public string CostoFojCarOfi {get; set;}
	    public string No_FojasNoCarOfi {get; set;}
	    public string CostoFojNoCarOfi {get; set;}
	    public string No_Planos {get; set;}
	    public string CostoPlanos {get; set;}
	    public string No_HojaPlano {get; set;}
	    public string CostoHojaPlano {get; set;}
	    public string Compulsa {get; set;} 
	    public string CostoCompulsa {get; set;} 
	    public string CostoTotal {get; set;} 
	    public string Doc_Entregados {get; set;} 
	    public string Obs_Respuesta {get; set;} 
	    public string Obs_Revision {get; set;} 
	    public string Obs_Firma {get; set;} 
	    public string Obs_ControlReg {get; set;} 
	    public string Fecha_Mod {get; set;} 
	    public string UsuarioMod {get; set;} 
	    public string tipoMod {get; set;} 
    }
}
