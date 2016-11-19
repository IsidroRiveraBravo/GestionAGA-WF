using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF
{
    public class TramiteInterno
    {
        public int clv_solicitud {get; set;}
	    public string Observaciones {get; set;}
	    public string fecha_preturnado {get; set;}
	    public string fecha_turnado {get; set;}
	    public string fecha_enterado {get; set;}
	    public string fecha_envio {get; set;}
	    public int clv_usr {get; set;}
	    public int clv_Tramite {get; set;}
	    public string fecha_inicio_Investigacion {get; set;}
	    public string Fecha_fin_investigacion {get; set;}
        public int clv_usrInvestigador { get; set; }
    }
}
