using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class CGPagosE
    {
        public int Id_Pagos {get; set; } //] [int] IDENTITY(1,1) NOT NULL,
	    public int IdControlGestion {get; set; } //] [int] NULL,
	    public double Pago {get; set; } //] [money] NULL,
	    public DateTime FechaPago {get; set; } //] [datetime] NULL,
	    public int Clv_Usuario {get; set; } //] [tinyint] NULL,
	    public DateTime FechaReg {get; set; } //] [datetime] NULL,
	    public string Observaciones {get; set; } //] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        public string estatus { get; set; } //] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
    }
}
