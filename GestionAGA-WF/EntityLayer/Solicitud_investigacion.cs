using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Solicitud_investigacion
    {
        public int Clv_Solicitud {get; set;}
	    public string Fecha_Inicio {get; set;}
	    public string Fecha_Fin {get; set;}
	    public string fecha_inicio_Programado {get; set;}
	    public string fecha_fin_Programado {get; set;}
        public int clv_usrInvestigador { get; set; }
    }
}
