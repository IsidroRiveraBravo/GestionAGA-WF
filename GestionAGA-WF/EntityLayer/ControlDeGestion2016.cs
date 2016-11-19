using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class ControlDeGestion2016
    {
	    public int IdControlGestion {get; set; } // ] [int] NOT NULL,
	    public string CI {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NOT NULL,
	    public string SIMCR {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string CI_Institucional {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string CI_AGA {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        //public string AreaQueRemite { get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        public string NumeroDeOficio {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string FechaDeOficio {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string FechaRecepcionAR {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string FechaRecepcionAGA {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Poblado {get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Municipio {get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Estado {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Asunto {get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string TurnadoA {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Firma {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Termino {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string OficioRespuesta {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string FechaRespuesta {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string ObservacionesRespuesta {get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        //public string ClasificacionArchivistica { get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        public string SolicitadoPor {get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Costo {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Fojas {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        public string Planos { get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
       
    }
}
