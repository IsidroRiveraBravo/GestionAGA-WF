using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class CGRespuestaE
    {
        public int Id_Respuesta {get; set; } //] [int] IDENTITY(1,1) NOT NULL,
	    public int IdControlGestion {get; set; } //] [int] NULL,
	    public string Oficio {get; set; } //] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public int Clv_Usuario {get; set; } //] [tinyint] NULL,
	    public DateTime FechaReg  {get; set; } //] [datetime] NULL,
	    public string Observaciones  {get; set; } //] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        public string estatus { get; set; } //] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
    }
}
