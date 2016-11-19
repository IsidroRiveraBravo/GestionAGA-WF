using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace GestionAGA_WF
{
    public partial class MDIPrincipal : Form
    {
        //private int childFormNumber = 0;
        public static string connectionStr = "";
        public static EntityLayer.Usuario Usuario = new EntityLayer.Usuario();

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
#if (DEBUG)
            // conexión de Desarrollo
            connectionStr = ConfigurationManager.ConnectionStrings["GestionAGA_Des"].ToString();
#else
            // conexión de Producción
            connectionStr = ConfigurationManager.ConnectionStrings["GestionAGA_Des"].ToString();
#endif

            //frmLogin frmlog = new frmLogin();
            //System.Windows.Forms.DialogResult resultado = frmlog.ShowDialog();
            //if (frmlog.DialogResult == DialogResult.Cancel)
            //{
            //    // cierra la aplicación
            //    this.Close();
            //}
            //else
            //{
            //    //Usuario = usuario.id_usr.ToString();
            //    toolStripStatusLabel.Text = Usuario.nombre;

            //    //SetMenuXUsuarioPerfil();
            //    this.Text = "SAD-Gestión Documental  V. 1.0.0.0";

            //}
            //frmlog.Dispose();

            Usuario.clv_Usuario = 93;
            Usuario.usuario = "isi";
            Usuario.nombre = "Isidro Rivera Bravo... Dev";
            Usuario.password = "123";
            Usuario.clv_Area = 1;

            // con este campo se controla la edicion
            Usuario.clv_GpoAcc = 1;
            //Usuario.opcionesDeMenu = "0"; // nada
            //Usuario.opcionesDeMenu = "*"; // todo
            // Usuario.opcionesDeMenu = "8; 26"; //,26,9,25,10,15,16,17,27,28"; // toda las opciones del proceso
            Usuario.opcionesDeMenu = "8:{Ins:false, UpDate: true, Del:true }; 26"; //,26,9,25,10,15,16,17,27,28"; // toda las opciones del proceso

            toolStripStatusLabel.Text = Usuario.nombre;


        }


        private void bUscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirBuscar();            
        }

        private void AbrirBuscar()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(frmRegistro) || frm.GetType() == typeof(frmRecepcion))
                {
                    frmBuscar childForm = new frmBuscar();
                    frmBuscar.strConexion = MDIPrincipal.connectionStr;

                    childForm.Text = "Buscar";
                    childForm.Show(frm);

                    break;

                }
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
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


        private void RecepcionMenu(object sender, EventArgs e)
        {
            menuGestionRegistro.Enabled = false;

            frmRecepcion childForm = new frmRecepcion();
            childForm.Usuario = Usuario;

            childForm.MdiParent = this;
            childForm.Text = "Recepción";
            childForm.Show();
        }

        

        private void RegistroMenu(object sender, EventArgs e)
        {

            frmRegistro childForm = new frmRegistro();
            childForm.usuario = Usuario;

            childForm.strConexion = MDIPrincipal.connectionStr;

            childForm.MdiParent = this;
            childForm.Text = "Recepción";
            childForm.Show();

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = openFileDialog.FileName;
            //}
        }

        private void InvestigacionMenu(object sender, EventArgs e)
        {
            Form childForm = new frmInvestigacion();
            childForm.MdiParent = this;
            childForm.Text = "Recepción";
            childForm.Show();

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = saveFileDialog.FileName;
            //}
        }

        private void menuGestionAsignacion_Click(object sender, EventArgs e)
        {
            Form childForm = new frmAsignacion();
            childForm.MdiParent = this;
            childForm.Text = "Asignación";
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuGestionRespuesta_Click(object sender, EventArgs e)
        {
            Form childForm = new frmRespuesta();
            childForm.MdiParent = this;
            childForm.Text = "Respuesta";
            childForm.Show();
        }

        private void menuGestionRevision_Click(object sender, EventArgs e)
        {
            Form childForm = new frmRevision();
            childForm.MdiParent = this;
            childForm.Text = "Revision";
            childForm.Show();
        }

        private void menuGestionFirma_Click(object sender, EventArgs e)
        {
            Form childForm = new frmFirma();
            childForm.MdiParent = this;
            childForm.Text = "Firma";
            childForm.Show();
        }

        private void menuGestionCierre_Click(object sender, EventArgs e)
        {
            Form childForm = new frmCierre();
            childForm.MdiParent = this;
            childForm.Text = "Cierre";
            childForm.Show();
        }

        private void pruebaDeConexiónTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmPruebaConexion();
            childForm.MdiParent = this;
            childForm.Text = "Cierre";
            childForm.Show();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void recepcionTStripB_Click(object sender, EventArgs e)
        {
            RecepcionMenu(sender, e);
        }

        private void registroTStripB_Click(object sender, EventArgs e)
        {
            RegistroMenu(sender, e);
        }

        private void estadosToolStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmEstados();
            childForm.MdiParent = this;
            childForm.Text = "Estados";
            childForm.Show();
        }

        private void municipiosTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmMunicipios();
            childForm.MdiParent = this;
            childForm.Text = "Municipios";
            childForm.Show();
        }

        private void pobladosTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmPoblados();
            childForm.MdiParent = this;
            childForm.Text = "Poblados";
            childForm.Show();
        }

        private void areasTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmAreas();
            childForm.MdiParent = this;
            childForm.Text = "Areas";
            childForm.Show();
        }

        private void grupoDocTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmGrupoDocumental();
            childForm.MdiParent = this;
            childForm.Text = "Grupo Documental";
            childForm.Show();
        }

        private void procedenciasTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmProcedencias();
            childForm.MdiParent = this;
            childForm.Text = "Procedencias";
            childForm.Show();
        }

        private void tipoProcedenciaTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmTipoProcedencia();
            childForm.MdiParent = this;
            childForm.Text = "Tipo de Procedencia";
            childForm.Show();
        }

        private void gruposTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmGrupos();
            childForm.MdiParent = this;
            childForm.Text = "Grupos";
            childForm.Show();
        }

        private void usuariosTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmUsuarios();
            childForm.MdiParent = this;
            childForm.Text = "Usuarios";
            childForm.Show();
        }

        private void menuTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmMenu();
            childForm.MdiParent = this;
            childForm.Text = "Menu";
            childForm.Show();
        }

        private void permisosTStripM_Click(object sender, EventArgs e)
        {
            Form childForm = new frmPermisos();
            childForm.MdiParent = this;
            childForm.Text = "Permisos";
            childForm.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmAboutBox();
            childForm.MdiParent = this;
            childForm.Text = "Acerca de ";
            childForm.Show();
        }

        private void estatusDelProcesoDeGestiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new frmEstatusSolicitud ();
            childForm.MdiParent = this;
            childForm.Text = "Acerca de ";
            childForm.Show();
        }

        private void buscarToolStripB_Click(object sender, EventArgs e)
        {
            AbrirBuscar();   
        }

        private void actualizarToolStripB_Click(object sender, EventArgs e)
        {
            RefrescaFrmRegistro();
        }

        private void cargaDeDatosTStripMenu_Click(object sender, EventArgs e)
        {
            frmCargarDatos.strConexion = connectionStr;
            frmCargarDatos fromTIFF = new frmCargarDatos();
            fromTIFF.MdiParent = this;
            fromTIFF.Show();
        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFiltrar();
        }

        private void AbrirFiltrar()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(frmRegistro))
                {
                    frmFiltrar childForm = new frmFiltrar();
                    frmFiltrar.strConexion = MDIPrincipal.connectionStr;

                    childForm.Text = "Filtrar";
                    childForm.Show(frm);

                    break;

                }
            }
        }

        private void producciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmReporteProduccion fromTIFF = new frmReporteProduccion();
            fromTIFF.strConexion = connectionStr;

            fromTIFF.MdiParent = this;
            fromTIFF.Show();
        }

        

 

        

       
       

        

       

       
    }
}
