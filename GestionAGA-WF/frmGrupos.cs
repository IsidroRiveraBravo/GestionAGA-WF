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
    public partial class frmGrupos : Form
    {
        //string connectionStr = "";
        //BusinessLayer.grupoBL grupoBL = new BusinessLayer.grupoBL();
        //List<EntityLayer.Grupo_Acceso> listaUser = new List<EntityLayer.Grupo_Acceso>();

        public frmGrupos()
        {
            InitializeComponent();
        }
        private void frmGrupos_Load(object sender, EventArgs e)
        {
            //this.connectionStr = MDIPrincipal.connectionStr;
            SetCtrls();
        }

        private void SetCtrls()
        {
            // define valor de conexión
            //grupoBL.connectionStr = MDIPrincipal.connectionStr; ;
            SetDataGV();
            SetTexts(true);
        }

        private void SetButtons(bool enabled = false)
        {
            btnAgregar.Enabled = enabled;
            btnEliminar.Enabled = enabled;
            btnModificar.Enabled = enabled;
        }

        private void SetTexts(bool enabled)
        {
            txtClave.Enabled = false;
            txtNombre.Enabled = enabled;
        }

        private void SetDataGV()
        {
            try
            {
                //listaGroup = gruposBL.SelectCatalogo();
                //dataGVLista.DataSource = listaGroup;
                //groupBData.Text = "Registros encontrados: " + listaGroup.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }

        }

        private void dataGVLista_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                //clv_Usuario = dr["clv_Usuario"] is DBNull ? 0 : Convert.ToInt32(dr["clv_Usuario"].ToString()),
                //               usuario = dr["usuario"] is DBNull ? "" : dr["usuario"].ToString(),
                //               password = dr["password"] is DBNull ? "" : dr["password"].ToString(),
                //               nombre = dr["nombre"] is DBNull ? "" : dr["nombre"].ToString(),
                //               clv_Area = dr["clv_Area"] is DBNull ? 0 : Convert.ToInt32(dr["clv_Area"].ToString()),
                //               clv_GpoAcc = dr["clv_GpoAcc"] is DBNull ? 0 : Convert.ToInt32(dr["clv_GpoAcc"].ToString()),
                //               estatus = dr["estatus"] is DBNull ? 0 : Convert.ToInt32(dr["estatus"].ToString())

                if (dataGVLista.CurrentRow != null && dataGVLista.Rows.Count > 0)
                {
                    txtClave.Text = dataGVLista.CurrentRow.Cells["clv_GpoAcc"].Value.ToString();
                    //txtGrupo.Text = dataGVLista.CurrentRow.Cells["Des_GpoAcc"].Value.ToString();
                    //txtpwd.Text = dataGVLista.CurrentRow.Cells["password"].Value.ToString();
                    //txtNombre.Text = dataGVLista.CurrentRow.Cells["nombre"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
