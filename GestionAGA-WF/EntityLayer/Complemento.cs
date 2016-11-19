using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Complemento
    {
    public int ID {get; set;}
	public int Clv_Solicitud {get; set;} 
	public string Folio_CI {get; set;} 
	public string Fecha_Peticion {get; set;} 
	public string Peticion {get; set;} 
	public string Fecha_Enterado {get; set;} 
	public string Fecha_Respuesta {get; set;}
	public string Respuesta {get; set;} 
	public int ClvUsr_Respuesta {get; set;} 
	public string Status {get; set;} 
    }
}
