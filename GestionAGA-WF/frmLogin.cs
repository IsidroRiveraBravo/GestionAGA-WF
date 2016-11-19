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
    public partial class frmLogin : Form
    {
        // propiedades

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BusinessLayer.usuarioBL usuarioBL = new BusinessLayer.usuarioBL();
            usuarioBL.connectionStr = MDIPrincipal.connectionStr;

            List<EntityLayer.Usuario> usuarioList = usuarioBL.SelectUsuarioPwd(txtUsuario.Text, txtPwd.Text);

            if (usuarioList.Count == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Usuario y/o Password incorrectos.";
                txtUsuario.Focus();
            }
            else
            {
                //frmPrincipal.usuario = usuarioList[0];
                //MDIPrincipal.Usuario = usuarioList[0].clv_Usuario.ToString();

                MDIPrincipal.Usuario = usuarioList[0];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtPwd.Focus();
        }
    }
}
