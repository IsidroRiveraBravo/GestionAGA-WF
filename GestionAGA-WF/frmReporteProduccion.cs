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
    public partial class frmReporteProduccion : Form
    {
        // propiedades
        public string strConexion { get; set; }

        BusinessLayer.ControlDeGestion2016BL ctrlDeGestionBl = new BusinessLayer.ControlDeGestion2016BL();
        List<EntityLayer.repProdInstitucionales> listaInstitucionales;
        List<EntityLayer.repProdParticulares> listaParticulares;

        public frmReporteProduccion()
        {
            InitializeComponent();
        }

        private void frmReporteProduccion_Load(object sender, EventArgs e)
        {
            dateTimePInicio.Value = DateTime.Now;
            dateTimePFin.Value = DateTime.Now;
            btnGenerarExcel.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaInstitucionales != null) listaInstitucionales.Clear();
                
                    ctrlDeGestionBl.strConexion = strConexion;
                    listaInstitucionales = ctrlDeGestionBl.RepProdInstitucionales(dateTimePInicio.Value, dateTimePFin.Value);

                    if (listaInstitucionales.Count() > 0)
                    {
                        dataGridVCajas.DataSource = null;
                        dataGridVCajas.DataSource = listaInstitucionales;
                    }

                    listaParticulares = ctrlDeGestionBl.RepProdParticulares(dateTimePInicio.Value, dateTimePFin.Value);
                    dataGridVParticulares.DataSource = listaParticulares;       

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



    }
}
