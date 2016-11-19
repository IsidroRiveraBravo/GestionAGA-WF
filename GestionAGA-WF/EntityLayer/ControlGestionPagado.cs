using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class ControlGestionPagado
    {
        public string ESTADO {get; set;}
	    public float CONTROL_INTERNO {get; set;}
	    public decimal COSTO {get; set;} 
	    public string Mes {get; set;} 
	    public string folio_ci {get; set;} 
    }
}
