using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//se anexa
using LinqToExcel;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionAGA_WF
{
    public partial class frmCargarDatos : Form
    {
        //propiedades

        public static string strConexion { get; set; }

        List<EntityLayer.ControlGestionAGA> listaCargaDatos = new List<EntityLayer.ControlGestionAGA>();
        BusinessLayer.ControlGestionAGABL metaBL = new BusinessLayer.ControlGestionAGABL();

        public frmCargarDatos()
        {
            InitializeComponent();
        }

        private void CargarDatos_Load(object sender, EventArgs e)
        {
            SetControles();

        }

        private void SetControles()
        {
            SetControlesDeTexto();
            SetControlesBotones();
            SetControlProgressBar();

        }
        private void SetControlProgressBar()
        {
            // TODO
        }

        private void SetControlesBotones()
        {
            // TODO
        }

        private void SetControlesDeTexto()
        {
            // TODO
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargaDeDatos();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileCargaDatos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtArchivo.Text = openFileCargaDatos.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CargaDeDatos()
        {
            grbCargaDatos.Enabled = false;
            LlenaLista();
            InsertaRegControlGestionAGA();

            // corre procedimiento para que coloque los datos en el formato correcto


        }

        private void InsertaRegControlGestionAGA()
        {
            try
            {
                grbCargaDatos.Enabled = false;

                LlenaLista();
                lblMsgNumReg.Text = "1. Cantidad de Registros : " + listaCargaDatos.Count();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = listaCargaDatos.Count;


                metaBL.strConexion = strConexion;

                // recorrido e Insert
                foreach (EntityLayer.ControlGestionAGA item in listaCargaDatos)
                {                   
                    metaBL.Insert(item);
                    ++progressBar1.Value;
                }

            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        private void LlenaLista()
        {
            try
            {
                lblCargaExcel.Text = "1. Inicia carga de Excel-Control de Gestion";
                lblCargaExcel.Refresh();

                var book = new ExcelQueryFactory(txtArchivo.Text);

                listaCargaDatos = (from row in book.Worksheet("Hoja1")
                                   let item = new EntityLayer.ControlGestionAGA
                                   {

                                   //    //id	CI	INFOMEX O SIMCR	C.I. INSTITUCIONAL	CI AGA 	ÁREA QUE REMITE	NUMERO DE OFICIO	FECHA DE OFICIO	FECHA DE RECIBIDO EN AR	FECHA DE RECIBIDO EN AGA	POBLADO	MUNICIPIO	ESTADO	                ASUNTO	RESPONSABLE 	FIRMA	TERMINO	OFICIO RESPUESTA	FECHA	OBSERVACIONES	CLASIFICACIÓN ARCHIVISTICA	SOLICITADO POR	costo	fojas	planos	fecha	usuario	estatus

                                       IdControlGestion = Convert.ToInt32(row["id"].ToString()),
                                       CI = row["CI"].ToString(),
                                       SIMCR = row["INFOMEX O SIMCR"].ToString(),
                                       //"C.I. INSTITUCIONAL"
                                       CI_Institucional = row["CI INSTITUCIONAL"].ToString(),
                                       //"CI AGA"
                                       CI_AGA = row["CI AGA "].ToString(),
                                       AreaQueRemite = row["ÁREA QUE REMITE"].ToString(),
                                       NumeroDeOficio = row["NUMERO DE OFICIO"].ToString(),
                                       FechaDeOficio = row["FECHA DE OFICIO"].ToString(),
                                       FechaRecepcionAR = row["FECHA DE RECIBIDO EN AR"].ToString(),
                                       FechaRecepcionAGA = row["FECHA DE RECIBIDO EN AGA"].ToString(),
                                       Poblado = row["POBLADO"].ToString(),
                                       Municipio = row["MUNICIPIO"].ToString(),
                                       Estado = row["ESTADO"].ToString(),
                                       Asunto = row["                ASUNTO"].ToString(),
                                       TurnadoA = row["RESPONSABLE "].ToString(),
                                       Firma = row["FIRMA"].ToString(),
                                       //Termino = row["TERMINO"].ToString(),
                                       FechaTermino = row["TERMINO"].ToString(),
                                       OficioRespuesta = row["OFICIO RESPUESTA"].ToString(),
                                       FechaRespuesta = row["FECHA"].ToString(),
                                       ObservacionesRespuesta = row["OBSERVACIONES"].ToString(),
                                       ClasificacionArchivistica = row["CLASIFICACIÓN ARCHIVISTICA"].ToString(),
                                       SolicitadoPor = row["SOLICITADO POR"].ToString(),
                                       Costo = row["costo"].ToString(),
                                       Fojas = row["fojas"].ToString(),
                                       Planos = row["planos"].ToString(),
                                       //FechaReg = row["fecha"].ToString(),
                                       //usuario = row["usuario"].ToString(),
                                       //estatus = row["estatus"].ToString(),

                                   }
                                   select item).ToList();

                book.Dispose();
                lblCargaExcel.Text = "Fin de carga de Excel-Control de Gestion";
                lblCargaExcel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lblArchivo_Click(object sender, EventArgs e)
        {

        }

        private void grbCargaDatos_Enter(object sender, EventArgs e)
        {

        }

    }
}
