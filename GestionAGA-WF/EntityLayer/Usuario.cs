using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Usuario
    {
        public int clv_Usuario {get; set;}
	    public string usuario {get; set;}
	    public string password {get; set;}
	    public string nombre {get; set;}
	    public int clv_Area {get; set;}
	    public int clv_GpoAcc {get; set;}
        public int estatus { get; set; }
        public string abogado { get; set; }
        public string opcionesDeMenu { get; set; }
    }
}
