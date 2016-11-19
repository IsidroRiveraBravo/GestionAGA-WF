using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    class Solicitud_Turnado
    {
   	    public int Clv_Solicitud {get; set;}
	    public int Clv_Turnado {get; set;}
	    public int Clv_Responsable {get; set;}
	    public int Clv_Usuario {get; set;}
	    public string Fecha_Preturnado {get; set;}
        public string Fecha_Turnado {get; set;}
	    public string Obs_Turnado {get; set;}
        public string Clv_Status { get; set; }

    }
}
