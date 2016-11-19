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
    public partial class frmBuscar : Form
    {
        // propiedades
        public static string strConexion { get; set; }
        public  DataGridView datagridBuscar { get; set; }
        //public List<EntityLayer.ControlDeGestion2016> listSolicitud { get; set; }
        public List<EntityLayer.Solicitud> listSolicitud = new List<EntityLayer.Solicitud>();

        public frmRegistro frmregistro;
        public frmRecepcion frmrecepcion;
        public int index = 0;

        public frmBuscar()
        {
            InitializeComponent();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
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

                    //  para Registro
                    //if (frm.GetType() == typeof(frmRegistro))
                    //{
                    //    frmregistro = (frmRegistro)frm;
                    //    listSolicitud = frmregistro.listSolicitud;
                    //    datagridBuscar = frmregistro.dataGridVControl;
                    //    foreach (DataGridViewColumn column in datagridBuscar.Columns)
                    //    {
                    //        comboBCampos.Items.Add(column.HeaderText);
                    //    }
                    //    break;
                    //}


                    if (frm.GetType() == typeof(frmRecepcion))
                    {
                        frmrecepcion = (frmRecepcion)frm;
                        listSolicitud = frmrecepcion.listSolicitud;
                        datagridBuscar = frmrecepcion.dataGVSolicitud;
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

        private void button3_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int index = 0;

            switch (comboBCampos.Text)
            {
                case "Folio_CI":
                    index = listSolicitud.FindIndex(ele => ele.Folio_CI == txtValorInicio.Text);
                    break;

                //case "IdControlGestion":
                //    index = listSolicitud.FindIndex(ele => ele.IdControlGestion == Convert.ToInt32(txtValorInicio.Text));
                //    break;

                //case "CI":
                //    index = listSolicitud.FindIndex(ele => ele.CI == txtValorInicio.Text);
                //    break;

                //case "SIMCR":
                //    index = listSolicitud.FindIndex(ele => ele.SIMCR == txtValorInicio.Text);
                //    break;

                //case "CI_Institucional":
                //    index = listSolicitud.FindIndex(ele => ele.CI_Institucional == (txtValorInicio.Text));
                //    break;

                //case "CI_AGA":
                //    index = listSolicitud.FindIndex(ele => ele.CI_AGA == (txtValorInicio.Text));
                //    break;

                ////public string AreaQueRemite { get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                //case "NumeroDeOficio":
                //    index = listSolicitud.FindIndex(ele => ele.NumeroDeOficio == (txtValorInicio.Text));
                //    break;

                //case "FechaDeOficio":
                //    index = listSolicitud.FindIndex(ele => ele.FechaDeOficio == (txtValorInicio.Text));
                //    break;


                //case "FechaRecepcionAR":
                //    index = listSolicitud.FindIndex(ele => ele.FechaRecepcionAR == (txtValorInicio.Text));
                //    break;


                //case "FechaRecepcionAGA":
                //    index = listSolicitud.FindIndex(ele => ele.FechaRecepcionAGA == (txtValorInicio.Text));
                //    break;

                //case "Poblado":
                //    index = listSolicitud.FindIndex(ele => ele.Poblado == (txtValorInicio.Text));
                //    break;


                //case "Municipio":
                //    index = listSolicitud.FindIndex(ele => ele.Municipio == (txtValorInicio.Text));
                //    break;


                //case "Estado":
                //    index = listSolicitud.FindIndex(ele => ele.Estado == (txtValorInicio.Text));
                //    break;

                //case "Asunto":
                //    index = listSolicitud.FindIndex(ele => ele.Asunto == (txtValorInicio.Text));
                //    break;

                //case "TurnadoA":
                //    index = listSolicitud.FindIndex(ele => ele.TurnadoA == (txtValorInicio.Text));
                //    break;
                //case "Firma":
                //    index = listSolicitud.FindIndex(ele => ele.Firma == (txtValorInicio.Text));
                //    break;
                //case "Termino":
                //    index = listSolicitud.FindIndex(ele => ele.Termino == (txtValorInicio.Text));
                //    break;
                //case "OficioRespuesta":
                //    index = listSolicitud.FindIndex(ele => ele.OficioRespuesta == (txtValorInicio.Text));
                //    break;
                //case "FechaRespuesta":
                //    index = listSolicitud.FindIndex(ele => ele.FechaRespuesta == (txtValorInicio.Text));
                //    break;
                //case "ObservacionesRespuesta":
                //    index = listSolicitud.FindIndex(ele => ele.ObservacionesRespuesta == (txtValorInicio.Text));
                //    break;
                ////public string ClasificacionArchivistica { get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                //case "SolicitadoPor":
                //    index = listSolicitud.FindIndex(ele => ele.SolicitadoPor == (txtValorInicio.Text));
                //    break;
                //case "Costo":
                //    index = listSolicitud.FindIndex(ele => ele.Costo == (txtValorInicio.Text));
                //    break;
                //case "Fojas":
                //    index = listSolicitud.FindIndex(ele => ele.Fojas == (txtValorInicio.Text));
                //    break;
                //case "Planos":
                //    index = listSolicitud.FindIndex(ele => ele.Planos == (txtValorInicio.Text));
                //    break;

                default:
                    index = 0;
                    break;
            }

            //if (index < 0) index = 0;

            //frmregistro.dataGridVControl.Rows[index].Selected = true;
            //frmregistro.dataGridVControl.CurrentCell = frmregistro.dataGridVControl.Rows[index].Cells[0];

            //datagridBuscar.Rows[index].Selected = true;
            //datagridBuscar.CurrentCell = frmregistro.dataGridVControl.Rows[index].Cells[0];

            //datagrid.Rows(index).Selected = True;
            //datagrid.CurrentCell = grdHoja.Rows(fila_que_queremos_seleccionar).Cells(0);

            if (index < 0) index = 0;

            frmrecepcion.dataGVSolicitud.Rows[index].Selected = true;
            frmrecepcion.dataGVSolicitud.CurrentCell = frmrecepcion.dataGVSolicitud.Rows[index].Cells[0];

            //datagridBuscar.Rows[index].Selected = true;
            //datagridBuscar.CurrentCell = frmrecepcion.dataGVSolicitud.Rows[index].Cells[0];

            //datagrid.Rows(index).Selected = True;
            //datagrid.CurrentCell = grdHoja.Rows(fila_que_queremos_seleccionar).Cells(0);


        }
    }
}
