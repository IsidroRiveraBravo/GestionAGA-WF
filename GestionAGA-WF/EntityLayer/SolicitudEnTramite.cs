using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class SolicitudEnTramite
    {
        public string Folio_CI { get; set; }
        public int Clv_Solicitud { get; set; }
        public string Clv_Edo { get; set; }
        public string Estado { get; set; }
        public string Clv_Mpo { get; set; }
        public string Municipio { get; set; }
        public string ObsMpo { get; set; }
        public string Clv_Tipo { get; set; }
        public string Tipo { get; set; }
        public string Clv_Nuc { get; set; }
        public string Nucleo { get; set; }
        public string ObsNuc { get; set; }
        public int Clv_GpoDoc1 { get; set; }
        public string Des_GpoDoc { get; set; }
        public int Clv_GpoDoc2 { get; set; }
        public int Clv_TipoProc { get; set; }
        public string Des_TipoProc { get; set; }
        public int Clv_Proc { get; set; }
        public string Des_Proc { get; set; }
        public int Clv_Responsable { get; set; }
        public string Nombre { get; set; }
        public string Fecha_Oficio { get; set; }
        public string Solicitado_por { get; set; }
        public string Oficio_Solicitud { get; set; }
        public string Fecha_Solicitud { get; set; }
        public string Doc_Solicitados { get; set; }
        public string Obs_Solicitud { get; set; }
        public string Obs_PreTurnado { get; set; }
        public string ObsExt { get; set; }
        public string Oficio_Salida { get; set; }
        public string Oficio_Salida2 { get; set; }
        public string Fecha_OfSalida { get; set; }
        public string Fecha_OfSalida2 { get; set; }
        public string Clv_Status { get; set; }
        public string Status { get; set; }
    }
}
