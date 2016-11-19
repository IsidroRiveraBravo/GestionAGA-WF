using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class CGTurnadoAE
    {
        public int Id_TunadoA { get; set; }
        public int IdControlGestion { get; set; }
        public int Clv_Usuario { get; set; }
        public DateTime FechaReg { get; set; }
        public string Observaciones { get; set; }
        public string TurnadoA { get; set; }
        public string estatus { get; set; } 
    }
}
