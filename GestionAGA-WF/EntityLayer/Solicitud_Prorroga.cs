using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Solicitud_Prorroga
    {
    public int id {get; set;}
	public int clv_solicitud {get; set;}
	public string fecha_prorroga {get; set;}
	public string fecha_VencimientoProrroga {get; set;}
    public string Status { get; set; }
    }
}
