using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Solicitud
    {
        public int Clv_Solicitud {get; set;}
        public string Folio_CI { get; set; } // splicitud_registro
       
        public string No_Expediente { get; set; } //
        public int Clv_Turnado { get; set; } //
        public string NombreTurnado { get; set; }

        public string Oficio_Solicitud { get; set; }
        public string Fecha_Solicitud { get; set; }
        public string Fecha_Venc { get; set; }

	    public string Clv_Edo {get; set;}
	    public string Estado {get; set;}
	    public string Clv_Mpo {get; set;}
	    public string Municipio {get; set;}
	    public string ObsMpo {get; set;}
	    public string Clv_Tipo {get; set;}
	    public string Clv_Nuc {get; set;}
	    public string Nucleo  {get; set;}
	    public string ObsNuc {get; set;}
	    public int Clv_GpoDoc1 {get; set;}
	    public int Clv_GpoDoc2 {get; set;}

	    public int Clv_TipoProc {get; set;}
	    public int Clv_Proc {get; set;}

	    public int Clv_Responsable {get; set;}
	    public string Fecha_Oficio {get; set;}
	    public string Solicitado_por {get; set;}
	    
	    
	    public string Doc_Solicitados {get; set;}
	    public string Obs_Solicitud {get; set;}
	    public string Obs_PreTurnado {get; set;}
	    public string ObsExt {get; set;}
	    public string Oficio_Salida {get; set;}
	    public string Oficio_Salida2 {get; set;}
	    public string Fecha_OfSalida {get; set;}
	    public string Fecha_OfSalida2 {get; set;}
        public string Clv_Status { get; set; }
        public DateTime FechaReg { get; set; }


        // Recepcion
	    public string FolioOfPartes  { get; set; } // ] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string FecOfPartes   { get; set; } // [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Cve_Prioridad   { get; set; } // [char](2) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    
	    public string LugarAtencion   { get; set; } // [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string CGI   { get; set; } // [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string fechaCGI   { get; set; } // [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string SIMCR   { get; set; } //  [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string fechaSIMCR   { get; set; } //  [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string fecRecepcion   { get; set; } // [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        //public string fecPago { get; set; } // [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        //public string totalPago { get; set; } // [decimal](18, 2) NULL,
        //public string obsPago { get; set; } //  [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string clv_entidadSolicitante   { get; set; } //  [nvarchar](2) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string entidadSolicitante   { get; set; } // [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Clasificacion   { get; set; } // [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public int RecibidoAGANET   { get; set; } //  [int] NULL,
	    public int usr_Captura   { get; set; } // [int] NULL,
	    public int usr_recepcion   { get; set; } // [int] NULL,
        public string status { get; set; } // [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,

        // turnado
        //[Clv_Solicitud] [int] NOT NULL,
        //public int Clv_Turnado { get; set; } // ] [tinyint] NOT NULL,
        public int Clv_ResponsableTurnado { get; set; } // ] [tinyint] NULL,
	    public int Clv_UsuarioTurnado { get; set; } // ] [tinyint] NULL,
	    public string Fecha_Preturnado { get; set; } // ] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Fecha_Turnado { get; set; } // ] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Obs_Turnado { get; set; } // ] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Clv_StatusTurnado { get; set; } // ] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        public string statusTurnado { get; set; } // ] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,


        // Investigacion
        //public int [Clv_Solicitud] [int] NULL,
	    public string Fecha_InicioInves  { get; set; } // ] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string Fecha_FinInves { get; set; } // ] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string fecha_inicio_ProgInves { get; set; } // ] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public string fecha_fin_ProgInves { get; set; } // ] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	    public int clv_usrInvestigador { get; set; } // ] [int] NULL,
        public string Clv_StatusInves { get; set; } // ] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
        public string statusInves { get; set; } // ] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AI NULL
        public string observacionesInves { get; set; }
        
        
        // Respuesta
        //public int Clv_Solicitud { get; set; }
        //public int Clv_Turnado { get; set; }
        //public int Clv_Usuario { get; set; }
        public string Resp_Fecha_Inv { get; set; }
        public string Resp_Fecha_Ini { get; set; }
        public string Resp_Fecha_Fin { get; set; }
        public string Resp_Fecha_Fin2 { get; set; }
        public string Resp_No_FojasCarOfi { get; set; }
        public string Resp_CostoFojCarOfi { get; set; }
        public string Resp_No_FojasNoCarOfi { get; set; }
        public string Resp_CostoFojNoCarOfi { get; set; }
        public string Resp_No_Planos { get; set; }
        public string Resp_CostoPlanos { get; set; }
        public string Resp_No_HojaPlano { get; set; }
        public string Resp_CostoHojaPlano { get; set; }
        public string Resp_Compulsa { get; set; }
        public string Resp_CostoCompulsa { get; set; }
        public string Resp_CostoTotal { get; set; }
        public string Resp_Num_Doc { get; set; }
        public string Resp_Doc_Entregados { get; set; }
        public string Resp_Doc_Entregados2 { get; set; }
        public string Resp_Obs_Respuesta { get; set; }
        public string Resp_Obs_Respuesta2 { get; set; }
        public string Resp_Clv_Status { get; set; }
        public string Resp_Notificacion { get; set; }
        public string Resp_FecEnvio { get; set; }



        // Revision
        public string Rev_Clv_Solicitud { get; set; }
        public string Rev_Fecha_Rec { get; set; }
        public string Rev_Fecha_Revision { get; set; }
        public string Rev_Obs_Revision { get; set; }
        public string Rev_Clv_Status { get; set; }
        public int Rev_clv_usr { get; set; }
        public string Rev_status { get; set; }



        //Firma
        public string sf_Fecha_Rec { get; set; }
        public string sf_Fecha_Firma { get; set; }
        public string sf_Observaciones { get; set; }
        public string sf_Clv_Status { get; set; }
        public int sf_clv_firmadoPor { get; set; }



        //Cierre        
	   public string en_Fecha_Rec { get; set; }
       public string en_Fecha_Entregado { get; set; }
       public string en_Observaciones { get; set; }
       public string en_status { get; set; }
       public string en_clv_usuario_entrega { get; set; }



        //Facturación
       public string sof_elaboro { get; set; }
       public string sof_fechaFactura { get; set; }
       public string sof_fechaEntrega { get; set; }
       public string sof_fechaOfPartes { get; set; }
       public string sof_SelloYfechaOfPartes { get; set; }
       public string sof_Observaciones { get; set; }
       public string sof_Status { get; set; }
        //usuario que ingresa al sistema
       public string sof_Usr_Factura { get; set; }


        //Pago
       public string sp_id_SolPago { get; set; }
       public string sp_clv_Solicitud { get; set; }
	   public string sp_fecha_Recepcion { get; set; }
	   public string sp_fecha_Pago { get; set; }
	   public string sp_totalPago { get; set; }
	   public string sp_observacionesPago { get; set; }
       public string sp_clv_Usuario { get; set; }

    }
}
