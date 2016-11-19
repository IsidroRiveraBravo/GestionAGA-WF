using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAGA_WF
{
    public partial class frmFiltrar : Form
    {
        // propiedades
        public static string strConexion { get; set; }
        public DataGridView datagridBuscar { get; set; }
        public List<EntityLayer.ControlDeGestion2016> listCtrl { get; set; }
        public frmRegistro frmregistro;
        public int index = 0;

        // propiedades
        //public string strConexion { get; set; }
        public EntityLayer.Usuario usuario { get; set; }
        public string InsertUpdate { get; set; }

        BusinessLayer.ControlDeGestion2016BL ctrlBl = new BusinessLayer.ControlDeGestion2016BL();
        //public List<EntityLayer.ControlDeGestion2016> listCtrl = new List<EntityLayer.ControlDeGestion2016>();
        public EntityLayer.ControlDeGestion2016 ctrlEntity; // = new EntityLayer.ControlDeGestion2016();


        public frmFiltrar()
        {
            InitializeComponent();
        }

        private void frmFiltrar_Load(object sender, EventArgs e)
        {
            SetControles();
            datagridBuscar = new DataGridView();
        }

        private void SetControles()
        {
            SetCamposDeDataGrid();
        }

        private void SetCamposDeDataGrid()
        {
            try
            {


                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmRegistro))
                    {


                        frmregistro = (frmRegistro)frm;

                        //listCtrl = frmregistro.listCtrl;
                        datagridBuscar = frmregistro.dataGridVControl;

                        foreach (DataGridViewColumn column in datagridBuscar.Columns)
                        {
                            comboBCampos.Items.Add(column.HeaderText);
                        }


                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtValorInicio.Text != String.Empty)
            {
                ctrlBl.strConexion = strConexion;

                List<EntityLayer.ControlDeGestion2016> nuevaLista = new List<EntityLayer.ControlDeGestion2016>(ctrlBl.Select());
                //nuevaLista = ctrlBl.Select().Where(elemento => elemento.Poblado == txtValorInicio.Text).ToList();

               


                switch (comboBCampos.Text)
                {
                    case "IdControlGestion":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.IdControlGestion == Convert.ToInt32(txtValorInicio.Text)).ToList();
                        break;

                    case "CI":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.CI == txtValorInicio.Text).ToList();
                        break;

                    case "SIMCR":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.SIMCR == txtValorInicio.Text).ToList();
                        break;

                    case "CI_Institucional":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.CI_Institucional == txtValorInicio.Text).ToList();
                        break;

                    case "CI_AGA":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.CI_AGA == txtValorInicio.Text).ToList();
                        break;

                    //public string AreaQueRemite { get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                    case "NumeroDeOficio":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.NumeroDeOficio == txtValorInicio.Text).ToList();
                        break;

                    case "FechaDeOficio":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.FechaDeOficio == txtValorInicio.Text).ToList();
                        break;


                    case "FechaRecepcionAR":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.FechaRecepcionAR == txtValorInicio.Text).ToList();
                        break;


                    case "FechaRecepcionAGA":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.FechaRecepcionAGA == txtValorInicio.Text).ToList();
                        break;

                    case "Poblado":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Poblado == txtValorInicio.Text).ToList();
                        break;


                    case "Municipio":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Municipio == txtValorInicio.Text).ToList();
                        break;


                    case "Estado":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Estado == txtValorInicio.Text).ToList();
                        break;

                    case "Asunto":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Asunto == txtValorInicio.Text).ToList();
                        break;

                    case "TurnadoA":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.TurnadoA == txtValorInicio.Text).ToList();
                        break;
                    case "Firma":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Firma == txtValorInicio.Text).ToList();
                        break;
                    case "Termino":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Termino == txtValorInicio.Text).ToList();
                        break;
                    case "OficioRespuesta":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.OficioRespuesta == txtValorInicio.Text).ToList();
                        break;
                    case "FechaRespuesta":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.FechaRespuesta == txtValorInicio.Text).ToList();
                        break;
                    case "ObservacionesRespuesta":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.ObservacionesRespuesta == txtValorInicio.Text).ToList();
                        break;
                    //public string ClasificacionArchivistica { get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                    case "SolicitadoPor":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.SolicitadoPor == txtValorInicio.Text).ToList();
                        break;
                    case "Costo":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Costo == txtValorInicio.Text).ToList();
                        break;
                    case "Fojas":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Fojas == txtValorInicio.Text).ToList();
                        break;
                    case "Planos":
                        nuevaLista = ctrlBl.Select().Where(elemento => elemento.Planos == txtValorInicio.Text).ToList();
                        break;

                    default:
                        index = 0;
                        break;
                }


                frmregistro.dataGridVControl.DataSource = null;
                frmregistro.dataGridVControl.DataSource = nuevaLista;


      
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Refrescar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarSiguiente_Click(object sender, EventArgs e)
        {
            RefrescaFrmRegistro();
        }

        private void RefrescaFrmRegistro()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(frmRegistro))
                {
                    //this.Enabled = false;

                    frmRegistro frmenc = (frmRegistro)frm;
                    frmenc.SetControlesDataGrid();
                    break;

                    //this.Enabled = true;
                }
            }
        }


    }
}
