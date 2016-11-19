using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using GestionAGA_WF.DataAccessLayer;

namespace GestionAGA_WF
{
    public partial class frmPruebaConexion : Form
    {
        private string connectionStr;

        public frmPruebaConexion()
        {
            InitializeComponent();
        }

        private void frmPruebaConexion_Load(object sender, EventArgs e)
        {
            this.connectionStr = MDIPrincipal.connectionStr;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                lblConexion.Text = connectionStr;

                using (var con = new SqlConnection(connectionStr))
                {
                    lblAbriendo.Text = "Abriendo conexión ............ ";

                    con.Open();
                    lblConexionExito.Text = "Conexión CORRECTA.......";                                        
                    //dataGVPrueba.DataSource = cat_edoDAL.Select(connectionStr);
                    con.Close();
                }

                lblCerrando.Text = "Conexión CERRADA.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }

        }
    }
}
