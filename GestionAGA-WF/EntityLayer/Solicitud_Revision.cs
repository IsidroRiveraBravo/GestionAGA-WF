using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Solicitud_Revision
    {
        public int Clv_Solicitud {get; set;}
	    public string Fecha_Rec {get; set;}
	    public string Fecha_Revision {get; set;}
	    public string Obs_Revision {get; set;}
	    public string Clv_Status {get; set;}
        public int clv_usr { get; set; }
    }
}
