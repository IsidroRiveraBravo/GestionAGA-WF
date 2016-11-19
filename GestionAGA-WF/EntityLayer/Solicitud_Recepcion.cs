using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class Solicitud_Recepcion
    {
        public int Clv_Solicitud { get; set; }
        public string Folio_CI { get; set; }
        public string FolioOfPartes { get; set; }
        public string FecOfPartes { get; set; }
        public string No_Expediente { get; set; }
        public string Cve_Prioridad { get; set; }
        public string Fecha_Venc { get; set; }
        public string LugarAtencion { get; set; }
        public string CGI { get; set; }
        public string fechaCGI { get; set; }
        public string SIMCR { get; set; }
        public string fechaSIMCR { get; set; }
        public string fecRecepcion { get; set; }
        public string fecPago { get; set; }
        public decimal totalPago { get; set; }
        public string obsPago { get; set; }
        public string clv_entidadSolicitante { get; set; }
        public string entidadSolicitante { get; set; }
        public string Clasificacion { get; set; }
        public int RecibidoAGANET { get; set; }
        public int usr_Captura { get; set; }
        public int usr_recepcion { get; set; }
    }
}
