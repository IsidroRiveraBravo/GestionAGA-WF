using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Solicitud_Respuesta
    {
        public int Clv_Solicitud {get; set;}
	    public int Clv_Turnado {get; set;}
	    public int Clv_Usuario {get; set;}
	    public string Fecha_Inv {get; set;}
	    public string Fecha_Ini {get; set;}
	    public string Fecha_Fin {get; set;}
	    public string Fecha_Fin2 {get; set;}
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
	    public string Num_Doc {get; set;}
	    public string Doc_Entregados {get; set;}
	    public string Doc_Entregados2 {get; set;}
	    public string Obs_Respuesta {get; set;}
	    public string Obs_Respuesta2 {get; set;}
	    public string Clv_Status {get; set;}
	    public string Notificacion {get; set;}
        public string FecEnvio {get; set;}
    }
}
