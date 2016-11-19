using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Solicitud_Entrega
    {
        public int Clv_Solicitud {get; set;}
	    public string Fecha_Rec {get; set;}
	    public string Fecha_Entregado {get; set;}
        public string Observaciones { get; set; }
    }
}
