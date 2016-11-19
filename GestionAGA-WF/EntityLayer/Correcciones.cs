using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Correcciones
    {
        public int Clv_Solicitud {get; set;}
	    public int Clv_Turnado {get; set;}
	    public int Clv_Usuario {get; set;}
	    public string Procedencia {get; set;}
	    public string Fecha_Correccion {get; set;}
        public string Clv_Status { get; set; }
    }
}
