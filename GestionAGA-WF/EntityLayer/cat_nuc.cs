using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.EntityLayer
{
    public class cat_nuc
    {
	    public string SCNCve_Unica {get; set;}
	    public string SCNCve_Clasif {get; set;}
	    public string SCNCve_Edo {get; set;}
	    public string SCNCve_Mun {get; set;}
	    public string SCNTipo_Nuc {get; set;}
	    public string SCNNom_Nuc {get; set;}
	    public string SCNNom_Ant {get; set;}
	    public string SCNFol_Mat {get; set;}
	    public decimal NCNSup_Parc {get; set;}
	    public decimal NCNSup_Uso {get; set;}
	    public decimal NCNSup_Asent {get; set;}
	    public decimal NCNSup_AsenSt {get; set;}
	    public decimal NCNSup_Plano {get; set;}
	    public decimal NCNSup_Achu {get; set;}
	    public decimal NCNSup_Reser {get; set;}
	    public decimal NCNSup_Explo {get; set;}
	    public decimal NCNSup_Otros {get; set;}
	    public int NCNNum_BenEji {get; set;}
	    public int NCNNum_BenPos {get; set;}
	    public int NCNNum_BenAve {get; set;}
	    public  DateTime DCNFec_Alta {get; set;}
	    public DateTime DCNFec_Baja {get; set;}
	    public string ObservacionesNucleo {get; set;}
	    public string cancela {get; set;}
	    public int NCNNum_Acciones {get; set;}
	    public decimal Tot_Nuc {get; set;}
	    public decimal Plano_Gral {get; set;}
	    public decimal Sup_Delimitada {get; set;}
	    public decimal NCNSup_Ach {get; set;}
	    public decimal NCNBeneficiados {get; set;}
	    public string Tipo_mov {get; set;}
	    public string Usuario_mov {get; set;}
	    public DateTime Fecha_mov {get; set;}
	    public decimal NucleoAccion {get; set;}
	    public decimal NCNSup_NoReg {get; set;}
	    public decimal NAASup_Acc {get; set;}
	    public string SCNCve_Mun_inegi {get; set;}
	    public string SCNCve_Nuc_inegi {get; set;}
        public string SCNCve_FolTierras { get; set; }
    }
}
