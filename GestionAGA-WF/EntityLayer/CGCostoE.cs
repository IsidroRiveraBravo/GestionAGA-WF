using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class CGCostoE
    {
        public int Id_Costo {get; set; } // ] [int] IDENTITY(1,1) NOT NULL,
	public int IdControlGestion {get; set; } //] [int] NULL,
	public double Costo {get; set; } //] [money] NULL,
	public DateTime FechaMovCosto {get; set; } //] [datetime] NULL,
	public int Fojas {get; set; } //] [int] NULL,
	public int Planos {get; set; } //] [int] NULL,
	public string TipoCopia {get; set; } //] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	public int  Clv_Usuario {get; set; } //] [tinyint] NULL,
	public DateTime FechaReg {get; set; } //] [datetime] NULL,
	public string Observaciones {get; set; } //] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
    public string estatus { get; set; } //] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        
    }
}
