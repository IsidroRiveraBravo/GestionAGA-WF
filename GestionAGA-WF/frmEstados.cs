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
    public partial class frmEstados : Form
    {
        string connectionStr = "";
        BusinessLayer.cat_edoBL edoBL = new BusinessLayer.cat_edoBL();
        List<EntityLayer.cat_edo> lista = new List<EntityLayer.cat_edo>();

        public frmEstados()
        {
            InitializeComponent();
        }

        private void frmEstados_Load(object sender, EventArgs e)
        {
            this.connectionStr = MDIPrincipal.connectionStr;
            SetCtrls();
        }

        private void SetCtrls()
        {
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
            lista = edoBL.SelectCat(connectionStr);
            dataGVLista.DataSource = lista;
            groupBData.Text = "Registros encontrados: " + lista.Count.ToString();
        }

        private void dataGVLista_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGVLista.CurrentRow != null && dataGVLista.Rows.Count > 0)
                {
                    txtClave.Text = dataGVLista.CurrentRow.Cells[0].Value.ToString();
                    txtNombre.Text = dataGVLista.CurrentRow.Cells[1].Value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.ToUpper() == "AGREGAR")
            {
                // limpia los textos
                txtClave.Text = "";
                txtNombre.Text = "";

                txtClave.Enabled = true;
                txtNombre.Enabled = true;

                btnAgregar.Text = "Guardar";
                txtClave.Focus();
            }
            else
            {
                bool todoOK = true;

                try
                {
                    EntityLayer.cat_edo edo = new EntityLayer.cat_edo()
                    {
                        SCECve_Edo = txtClave.Text,
                        SCENom_Edo = txtNombre.Text,
                    };

                    todoOK = edoBL.Agregar(connectionStr, edo);
                    SetDataGV();

                    dataGVLista.CurrentCell = dataGVLista.Rows[dataGVLista.Rows.Count - 1].Cells[0]; //'mover a la fila 10
                    MessageBox.Show("Se ha AGREGADO el ESTADO con éxito.", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnAgregar.Text = "Agregar";
                    SetTexts(false);
                    SetButtons(true);


                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool todoOK = true;
            try
            {
                EntityLayer.cat_edo user = new EntityLayer.cat_edo()
                {
                    SCECve_Edo = txtClave.Text,
                    SCENom_Edo = txtNombre.Text,
                };

                todoOK = edoBL.Modificar(connectionStr, user);

                SetDataGV();
                SetTexts(true);
                SetButtons(true);

                MessageBox.Show("Se ha MODIFICADO el estado con éxito.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool todoOK = true;
            try
            {
                EntityLayer.cat_edo user = new EntityLayer.cat_edo()
                {
                    SCECve_Edo = txtClave.Text,
                    SCENom_Edo = txtNombre.Text,
                };

                todoOK = edoBL.Eliminar(connectionStr, user);

                SetDataGV();
                SetTexts(true);
                SetButtons(true);

                MessageBox.Show("Se ha ELIMINADO el estado con éxito.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
