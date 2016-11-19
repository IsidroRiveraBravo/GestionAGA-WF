using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Reflection;

namespace GestionAGA_WF
{
    public partial class frmRegistro : Form
    {
        // propiedades
        public string strConexion { get; set; }
        public EntityLayer.Usuario usuario { get; set; }
        public string InsertUpdate { get; set; }

        BusinessLayer.ControlDeGestion2016BL ctrlBl = new BusinessLayer.ControlDeGestion2016BL();
        public List<EntityLayer.ControlDeGestion2016> listCtrl = new List<EntityLayer.ControlDeGestion2016>();
        public EntityLayer.ControlDeGestion2016 ctrlEntity; // = new EntityLayer.ControlDeGestion2016();
        
        //List<EntityLayer.ControlDeGestion2016> listCtrl = new List<EntityLayer.ControlDeGestion2016>();

        public frmRegistro()
        {
            InitializeComponent();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

            ctrlBl.strConexion = this.strConexion;
            SetControles();
        }

        private void SetControles()
        {
            SetEnabledControlesTexto(false);
            SetControlesDataGrid();
            SetControlesBotones();

            checkBAmarillo.BackColor = SystemColors.Control;
            checkBNaranja.BackColor = SystemColors.Control;
            checkBVerde.BackColor = SystemColors.Control;
            checkBRosa.BackColor = SystemColors.Control;
        }

        public void SetControlesDataGrid()
        {
            try
            {
                //listCtrl = ctrlBl.Select();
                // LLenado de datos del Grid
                listCtrl = new List<EntityLayer.ControlDeGestion2016>(ctrlBl.Select());

                dataGridVControl.DataSource = listCtrl;
                groupBSolicitudes.Text = "Solicitudes : " + listCtrl.Count.ToString();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void SetControlesBotones()
        {
            //usuario.clv_GpoAcc = 3;
            // Si el usuario es de captura, aunque sea abogado
            // no puede insertar
            btnInsert.Enabled = usuario.clv_GpoAcc == 3 ? false: true;
            btnDelete.Enabled = false;
        }

        private void SetEnabledControlesTexto(bool disponible)
        {

            //usuario.clv_GpoAcc = 3;

            //txtIdControlGestion.Enabled = false;
            txtCI.Enabled = false;

            txtSIMCR.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtCI_Institucional.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtCI_AGA.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtNumeroDeOficio.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtFechaDeOficio.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            //txtFechaRecepcionAR.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtFechaRecepcionAGA.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtPoblado.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtMunicipio.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtEstado.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtAsunto.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            comboBTurnadoA.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            //txtFirma.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtTermino.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;

            richTextBObservacionesCosto.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;

            // estos estan disponobles para todos los usuarios
            txtOficioRespuesta.Enabled = disponible;
            //txtFechaRespuesta.Enabled = disponible;

            txtObservacionesRespuesta.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtSolicitadoPor.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtCosto.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtFojas.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;
            txtPlanos.Enabled = usuario.clv_GpoAcc == 3 ? false : disponible;

            // para abogados
            txtOficioRespuesta.Enabled = usuario.clv_GpoAcc == 3 ? true : false;
            dateTimePRespuesta.Enabled = usuario.clv_GpoAcc == 3 ? true : false;
            txtObservacionesRespuesta.Enabled = usuario.clv_GpoAcc == 3 ? true : false;

            txtCosto.Enabled = usuario.clv_GpoAcc == 3 ? true : false;
            txtFojas.Enabled = usuario.clv_GpoAcc == 3 ? true : false;
            txtPlanos.Enabled = usuario.clv_GpoAcc == 3 ? true : false;
            richTextBObservacionesCosto.Enabled = usuario.clv_GpoAcc == 3 ? true : false;
            checkBCertificadas.Enabled = usuario.clv_GpoAcc == 3 ? true : false;
            checkBCopiasSimples.Enabled = usuario.clv_GpoAcc == 3 ? true : false;

            

            // para firma
            comboBFirmadoPor.Enabled = usuario.clv_GpoAcc == 4 ? true : false;
            txtObservacionesFirma.Enabled = usuario.clv_GpoAcc == 4 ? true : false;
            dateTimePFechaFirma.Enabled = usuario.clv_GpoAcc == 4 ? true : false;
            
        }

        private void dataGridVControl_CurrentCellChanged(object sender, EventArgs e)
        {
            if(dataGridVControl != null && dataGridVControl.Rows.Count > 0)
            {
                SetDataCurrentRowInTexts();                
            }
        }

        /// <summary>
        /// Coloca en los controles de texto el valor del renglon en curso
        /// </summary>
        private void SetDataCurrentRowInTexts()
        {
            DataGridViewRow row = dataGridVControl.CurrentRow;

            if (row != null)
            {
                //txtIdControlGestion.Text = row.Cells["IdControlGestion"].Value.ToString();
                txtCI.Text = row.Cells["CI"].Value.ToString();
                txtCIRespuesta.Text = row.Cells["CI"].Value.ToString();
                txtCIFirma.Text = row.Cells["CI"].Value.ToString();


                txtSIMCR.Text = row.Cells["SIMCR"].Value.ToString();
                txtCI_Institucional.Text = row.Cells["CI_Institucional"].Value.ToString();
                txtCI_AGA.Text = row.Cells["CI_AGA"].Value.ToString();
                txtNumeroDeOficio.Text = row.Cells["NumeroDeOficio"].Value.ToString();
                txtFechaDeOficio.Text = row.Cells["FechaDeOficio"].Value.ToString();
                //txtFechaRecepcionAR.Text = row.Cells["FechaRecepcionAR"].Value.ToString();
                txtFechaRecepcionAGA.Text = row.Cells["FechaRecepcionAGA"].Value.ToString();
                txtPoblado.Text = row.Cells["Poblado"].Value.ToString();
                txtMunicipio.Text = row.Cells["Municipio"].Value.ToString();
                txtEstado.Text = row.Cells["Estado"].Value.ToString();
                txtAsunto.Text = row.Cells["Asunto"].Value.ToString();
                comboBTurnadoA.Text = row.Cells["TurnadoA"].Value.ToString();
                //txtFirma.Text = row.Cells["Firma"].Value.ToString();
                txtTermino.Text = row.Cells["Termino"].Value.ToString();
                txtOficioRespuesta.Text = row.Cells["OficioRespuesta"].Value.ToString();
                //txtFechaRespuesta.Text = row.Cells["FechaRespuesta"].Value.ToString();
                txtObservacionesRespuesta.Text = row.Cells["ObservacionesRespuesta"].Value.ToString();
                txtSolicitadoPor.Text = row.Cells["SolicitadoPor"].Value.ToString();
                txtCosto.Text = row.Cells["Costo"].Value.ToString();
                txtFojas.Text = row.Cells["Fojas"].Value.ToString();
                txtPlanos.Text = row.Cells["Planos"].Value.ToString();
            }
        }

       

        private void SetTextControlesTxT()
        {
            if (InsertUpdate == "I")
            {
                //txtIdControlGestion.Text = NuevoIdControlDeGestion();
                txtCI.Text = NuevoIdControlDeGestion();
            }
            
            //txtIdControlGestion.Enabled = false;

            if (InsertUpdate == "I")
            {
                txtCI.Text = NuevoCI();
            }

            txtSIMCR.Text = "";
            txtCI_Institucional.Text = "";
            txtCI_AGA.Text = "";
            txtNumeroDeOficio.Text = "";
            txtFechaDeOficio.Text = "";
            //txtFechaRecepcionAR.Text = "";
            txtFechaRecepcionAGA.Text = "";
            txtPoblado.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            txtAsunto.Text = "";
            comboBTurnadoA.Text = "";
            //txtFirma.Text = "";
            txtTermino.Text = "";
            txtOficioRespuesta.Text = "";
            //txtFechaRespuesta.Text = "";
            txtObservacionesRespuesta.Text = "";
            txtSolicitadoPor.Text = "";
            txtCosto.Text = "";
            txtFojas.Text = "";
            txtPlanos.Text = "";

            txtFojas.Text = "";
            txtPlanos.Text = "";
        }

        private string NuevoCI()
        {
            // TODO
            string ci = "NuevoCI";
            return ci;
        }

        private string NuevoIdControlDeGestion()
        {
            // TODO
            string idct = "Nuevo ID Control";
            return idct;
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            if (btnUpDate.Text == "Modificar")
            {
                btnInsert.Enabled = false;
                btnCancelar.Visible = true;

                btnUpDate.Text = "Guardar";
                SetEnabledControlesTexto(true);
            }
            else
            {
                // Guardar datos
                btnCancelar.Visible = false;
                btnUpDate.Text = "Modificar";

                try
                {
                    // llamar Insert de BL
                    SetDataEntityObject();
                    ctrlBl.UpDate(ctrlEntity);
                    SetControlesDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                

                // texto no disponibles
                SetEnabledControlesTexto(false);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnUpDate.Text == "Guardar")
            {
                InsertUpdate = "U";
                btnUpDate.Text = "Modificar";

                // colocar el valor del renglon actual
                SetDataCurrentRowInTexts();  

                // texto no disponibles
                btnInsert.Enabled = true;
                SetEnabledControlesTexto(false);
                InsertUpdate = "";
            }

            if (btnInsert.Text == "Guardar")
            {
                btnInsert.Text = "Agregar";
                // colocar el valor del renglon actual
                SetDataCurrentRowInTexts();  


                // texto no disponibles
                btnUpDate.Enabled = true;
                SetEnabledControlesTexto(false);

            }
            btnCancelar.Visible = false;
            dataGridVControl.Enabled = true;
            groupBSolicitudes.Enabled = true;

        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            

            if (btnInsert.Text == "Agregar")
            {
                txtSIMCR.Focus();
                txtSIMCR.Refresh();

                dataGridVControl.Enabled = false;
                groupBSolicitudes.Enabled = false;

                InsertUpdate = "I";

                btnUpDate.Enabled = false;
                btnCancelar.Visible = true;

                btnInsert.Text = "Guardar";

                SetTextControlesTxT();
                SetEnabledControlesTexto(true);
                InsertUpdate = "";
                groupBSolicitudes.Enabled = true;
            }
            else
            {
                // Guardar datos
                btnCancelar.Visible = false;
                btnInsert.Text = "Agregar";
               
                try
                {
                    // llamar Insert de BL
                    SetDataEntityObject();
                    ctrlBl.Insert(ctrlEntity);
                    SetControlesDataGrid();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // texto no disponibles
                SetEnabledControlesTexto(false);
                groupBSolicitudes.Enabled = true;

                dataGridVControl.Enabled = true;
                groupBSolicitudes.Enabled = true;
            }

        }

        private void SetDataEntityObject()
        {
            try
            {
                ctrlEntity = new EntityLayer.ControlDeGestion2016()
                {
                    //IdControlGestion = btnInsert.Text == "Guardar" ? 0 : Convert.ToInt32(txtIdControlGestion.Text),
                    CI = txtCI.Text,
                    SIMCR = txtSIMCR.Text,
                    CI_Institucional = txtCI_Institucional.Text,
                    CI_AGA = txtCI_AGA.Text,
                    NumeroDeOficio = txtNumeroDeOficio.Text,
                    FechaDeOficio = txtFechaDeOficio.Text,
                    //FechaRecepcionAR = txtFechaRecepcionAR.Text,
                    FechaRecepcionAGA = txtFechaRecepcionAGA.Text,
                    Poblado = txtPoblado.Text,
                    Municipio = txtMunicipio.Text,
                    Estado = txtEstado.Text, // = row.Cells["Estado"].Value.ToString();
                    Asunto = txtAsunto.Text,  // = row.Cells["Asunto"].Value.ToString();
                    TurnadoA = comboBTurnadoA.Text, //= row.Cells["TurnadoA"].Value.ToString();
                    //Firma = txtFirma.Text, // = row.Cells["Firma"].Value.ToString();
                    Termino = txtTermino.Text, //= row.Cells["Termino"].Value.ToString();
                    OficioRespuesta = txtOficioRespuesta.Text, // = row.Cells["OficioRespuesta"].Value.ToString();
                    //FechaRespuesta = txtFechaRespuesta.Text, // = row.Cells["FechaRespuesta"].Value.ToString();
                    ObservacionesRespuesta = txtObservacionesRespuesta.Text, // = row.Cells["ObservacionesRespuesta"].Value.ToString();
                    SolicitadoPor = txtSolicitadoPor.Text, // = row.Cells["SolicitadoPor"].Value.ToString();
                    Costo = txtCosto.Text, // = row.Cells["Costo"].Value.ToString();
                    Fojas = txtFojas.Text,  // = row.Cells["Fojas"].Value.ToString();
                    Planos = txtPlanos.Text  // = row.Cells["Planos"].Value.ToString();

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void dataGridVControl_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int colIndex = e.ColumnIndex;
            //MessageBox.Show(dataGridVControl.Columns[e.ColumnIndex].HeaderText);
        }

        private void dataGridVControl_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            List<EntityLayer.ControlDeGestion2016> listaOrd = new List<EntityLayer.ControlDeGestion2016>();

            switch (dataGridVControl.Columns[e.ColumnIndex].HeaderText)
            { 
                case "IdControlGestion":
                    listaOrd = listCtrl.OrderBy(c => c.IdControlGestion).ToList();
                    break;
               
	            case  "CI": 
                    listaOrd = listCtrl.OrderBy(c => c.CI).ToList();
                    break;

                case  "SIMCR": 
                    listaOrd = listCtrl.OrderBy(c => c.SIMCR).ToList();
                    break;

                case  "CI_Institucional":
                    listaOrd = listCtrl.OrderBy(c => c.CI_Institucional).ToList();
                    break;
                case  "CI_AGA":
                    listaOrd = listCtrl.OrderBy(c => c.CI_AGA).ToList();
                    break;
                case  "NumeroDeOficio":
                    listaOrd = listCtrl.OrderBy(c => c.NumeroDeOficio).ToList();
                    break;
                case  "FechaDeOficio":
                    listaOrd = listCtrl.OrderBy(c => c.FechaDeOficio).ToList();
                    break;
                case  "FechaRecepcionAR":
                    listaOrd = listCtrl.OrderBy(c => c.FechaRecepcionAR).ToList();
                    break;
                case  "FechaRecepcionAGA": 
                    listaOrd = listCtrl.OrderBy(c => c.FechaRecepcionAGA).ToList();
                    break;
                case  "Poblado": 
                    listaOrd = listCtrl.OrderBy(c => c.Poblado).ToList();
                    break;
                case  "Municipio":
                    listaOrd = listCtrl.OrderBy(c => c.Municipio).ToList();
                    break;
                case  "Estado":
                    listaOrd = listCtrl.OrderBy(c => c.Estado).ToList();
                    break;
                case  "Asunto":
                    listaOrd = listCtrl.OrderBy(c => c.Asunto).ToList();
                    break;
                case  "TurnadoA": 
                    listaOrd = listCtrl.OrderBy(c => c.TurnadoA).ToList();
                    break;
                case  "Firma": 
                    listaOrd = listCtrl.OrderBy(c => c.Firma).ToList();
                    break;
                case  "Termino": 
                    listaOrd = listCtrl.OrderBy(c => c.Termino).ToList();
                    break;
                case  "OficioRespuesta": 
                    listaOrd = listCtrl.OrderBy(c => c.OficioRespuesta).ToList();
                    break;
                case  "FechaRespuesta": 
                    listaOrd = listCtrl.OrderBy(c => c.FechaRespuesta).ToList();
                    break;
                case  "ObservacionesRespuesta": 
                    listaOrd = listCtrl.OrderBy(c => c.ObservacionesRespuesta).ToList();
                    break;
                case  "SolicitadoPor": 
                    listaOrd = listCtrl.OrderBy(c => c.SolicitadoPor).ToList();
                    break;
                case  "Costo": 
                    listaOrd = listCtrl.OrderBy(c => c.Costo).ToList();
                    break;
                case  "Fojas":
                    listaOrd = listCtrl.OrderBy(c => c.Fojas).ToList();
                    break;
                case "Planos":
                    listaOrd = listCtrl.OrderBy(c => c.Planos).ToList();
                    break;
                default:
                    break;

	        }

            dataGridVControl.DataSource = null;
            dataGridVControl.DataSource = listaOrd;

            //int colIndex = e.ColumnIndex;
            //MessageBox.Show(dataGridVControl.Columns[e.ColumnIndex].HeaderText);


            //// Check which column is selected, otherwise set NewColumn to null.
            //DataGridViewColumn newColumn = dataGridVControl.Columns[e.ColumnIndex];

            ////DataGridViewColumn newColumn =
            ////    dataGridVControl.Columns.GetColumnCount(
            ////    DataGridViewElementStates.Selected) == 1 ?
            ////    dataGridVControl.SelectedColumns[0] : null;

            //DataGridViewColumn oldColumn = dataGridVControl.SortedColumn;
            //ListSortDirection direction;

            //// If oldColumn is null, then the DataGridView is not currently sorted.
            //if (oldColumn != null)
            //{
            //    // Sort the same column again, reversing the SortOrder.
            //    if (oldColumn == newColumn &&
            //        dataGridVControl.SortOrder == SortOrder.Ascending)
            //    {
            //        direction = ListSortDirection.Descending;
            //    }
            //    else
            //    {
            //        // Sort a new column and remove the old SortGlyph.
            //        direction = ListSortDirection.Ascending;
            //        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            //    }
            //}
            //else
            //{
            //    direction = ListSortDirection.Ascending;
            //}

                       
            //// If no column has been selected, display an error dialog  box.
            //if (newColumn == null)
            //{
            //    MessageBox.Show("Select a single column and try again.",
            //        "Error: Invalid Selection", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
            //else
            //{
            //    dataGridVControl.Sort(newColumn, direction);
            //    newColumn.HeaderCell.SortGlyphDirection =
            //        direction == ListSortDirection.Ascending ?
            //        SortOrder.Ascending : SortOrder.Descending;
            //}

        }

        private void btnInsert_EnabledChanged(object sender, EventArgs e)
        {
            btnInsert.Enabled = usuario.clv_GpoAcc == 3 ? false : true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBAmarillo.Checked == true)
            {
                checkBAmarillo.BackColor = Color.Yellow;
            }
            else
            {
                checkBAmarillo.BackColor = SystemColors.Control;
            }
        }

        private void checkBNaranja_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBNaranja.Checked == true)
            {
                checkBNaranja.BackColor = Color.Orange;
            }
            else
            {
                checkBNaranja.BackColor = SystemColors.Control;
            }
        }

        private void checkBVerde_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBVerde.Checked == true)
            {
                checkBVerde.BackColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                checkBVerde.BackColor = SystemColors.Control;
            }
        }

        private void checkBRosa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBRosa.Checked == true)
            {
                checkBRosa.BackColor = Color.FromArgb(255, 128, 255);
            }
            else
            {
                checkBRosa.BackColor = SystemColors.Control;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnInsert.Enabled = false;
            btnUpDate.Enabled = false;

            if (btnBuscar.Text == "Buscar") 
            { 
                btnBuscar.Text = "Cerrar";
            }
            else
            {
                btnBuscar.Text = "Buscar";
            }

            SetTextControlesTxT();
            SetEnabledControlesTexto(true);
            //txtIdControlGestion.Enabled = true;
            txtCI.Enabled = true;

            
        }

        private void txtIdControlGestion_TextChanged(object sender, EventArgs e)
        {


            //if (txtIdControlGestion.Text != String.Empty && btnBuscar.Text == "Cerrar")
            //{
            //    List<EntityLayer.ControlDeGestion2016> nuevaLista = new List<EntityLayer.ControlDeGestion2016>(ctrlBl.Select());
            //    nuevaLista = ctrlBl.Select().Where(elemento => elemento.IdControlGestion == Convert.ToInt32(txtIdControlGestion.Text)).ToList();

            //    dataGridVControl.DataSource = null;
            //    dataGridVControl.DataSource = nuevaLista;

            //    //BuscaCaja();

            //    //BusinessLayer.CajaExpedienteXImprimirBL cajaExpBl = new BusinessLayer.CajaExpedienteXImprimirBL();
            //    //List<EntityLayer.CajaExpedienteXImprimir> listExp =
            //    //    cajaExpBl.SelExpedientesXCaja(Convert.ToInt32(txtNoCaja.Text.ToString()));

            //    //dataGridVExpedientes.DataSource = null;
            //    //dataGridVExpedientes.DataSource = listExp;
            //}
        }

        private void txtSIMCR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtCI_Institucional.Focus();
        }

        private void txtCI_Institucional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtCI_AGA.Focus();
        }

        private void txtCI_AGA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtNumeroDeOficio.Focus();
        }

        private void dateTimePOficio_ValueChanged(object sender, EventArgs e)
        {
            txtFechaDeOficio.Text = dateTimePOficio.Value.ToString();
            txtFechaDeOficio.Focus();
            txtFechaDeOficio.Select(txtFechaDeOficio.Text.Length, 0);
        }

        private void dateTimePRecepcionAR_ValueChanged(object sender, EventArgs e)
        {
            //txtFechaRecepcionAR.Text = dateTimePRecepcionAR.Value.ToString();
            //txtFechaRecepcionAR.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void ExportarAExcel()
        {

            int anchoColRep = 4;

            object oOpt = System.Reflection.Missing.Value;

            // inicia la apliación excel para pbtener un objeto
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            // Definicion de tipo de fuente
            excel.StandardFont = "Arial";
            excel.StandardFontSize = 11;

            //Crea un nuevo libro
            Microsoft.Office.Interop.Excel.Workbook excelworkBook = excel.Workbooks.Add(Type.Missing);

            // crea una hoja de trabajo
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Datos Filtrados";

            //
            // rango de celdas para diferentes partes del reporte
            //
            // Fondo del reporte
            Microsoft.Office.Interop.Excel.Range rangeColorDeTitulo = excelSheet.get_Range("A1", oOpt).get_Resize(1, anchoColRep);
            // Coloreando las celdas
            rangeColorDeTitulo.Interior.Color = Color.LightGray;

            // Titulo de reporte
            Microsoft.Office.Interop.Excel.Range rangeTitulo = excelSheet.get_Range("A1", oOpt).get_Resize(1, 1);
            rangeTitulo.Font.Size = 20;
            rangeTitulo.set_Value(oOpt, "Reporte de Gestion");

            // fechas del reporte, en tamaño definido al inicio
            Microsoft.Office.Interop.Excel.Range rangeFechasReporte = excelSheet.get_Range("C1", oOpt).get_Resize(1, 1);
            rangeFechasReporte.set_Value(oOpt, "Día " + DateTime.Now.ToShortDateString()); 

            Range rangeTituloDatos = excelSheet.get_Range("A2", oOpt).get_Resize(1, anchoColRep);
            rangeTituloDatos.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Navy);
            rangeTituloDatos.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.White);

            //Obtiene las propiedades de la colección y colocal os valore sne 
            // la lista de propiedades
            PropertyInfo[] props = typeof(EntityLayer.ControlDeGestion2016).GetProperties();
            List<PropertyInfo> propList = GetSelectedProperties(props, "", "");


            //List<string> propList = new List<string>() { "Clave", "Nombre", "Hora entrada", "Hora salida" };

            //////Convierte la lista a arreglo para las propiedades seleccionadas
            object[,] listArray = new object[listCtrl.Count + 1, propList.Count];
            

            //Agrega el nombre de las propiedades en el primer renglon
            int colIdx = 0;
            foreach (var prop in propList)
            {

                listArray[0, colIdx] = prop;
                colIdx++;

            }

             //Itera a travez de la lista de registros loalizados
            int rowIdx = 1;
            foreach (EntityLayer.ControlDeGestion2016 item in listCtrl)
            {
                colIdx = 0;
                //Iterate through property collection for columns
                foreach (var prop in propList)
                {
                    //Do property value
                    listArray[rowIdx, colIdx] = prop.GetValue(item, null);
                    colIdx++;
                }
                rowIdx++;
            }



            //// rango de celda Nombre
            //Excel.Range rangoDatosnNombre = excelSheet.get_Range("B1", oOpt).get_Resize(1, 1);
            //rangoDatosnNombre.EntireColumn.ColumnWidth = 50;

            //// rango de celda Hora Entrada
            //Excel.Range rangoDatosHoraEntrada = excelSheet.get_Range("C1", oOpt).get_Resize(1, 1);
            //rangoDatosHoraEntrada.EntireColumn.ColumnWidth = 15;

            //// rango de celda Hora Salida
            //Excel.Range rangoDatosHoraSalida = excelSheet.get_Range("D1", oOpt).get_Resize(1, 1);
            //rangoDatosHoraSalida.EntireColumn.ColumnWidth = 15;


            progressBExportEcel.Value = 0;
            progressBExportEcel.Minimum = 0;
            progressBExportEcel.Maximum = listArray.Length + 1;

            int nrow = 2;
            int ncol = 0;
            foreach (var item in listArray)
            {
                //// rango para la clave
                //Excel.Range rangoDatosnClave = excelSheet.get_Range("A" + nrow.ToString(), oOpt).get_Resize(1, 1);
                //rangoDatosnClave.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                //// rango para la Hora de entrada
                //Excel.Range rangoDatosnHoraEntrada = excelSheet.get_Range("C" + nrow.ToString(), oOpt).get_Resize(1, 1);
                //rangoDatosnHoraEntrada.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                //// rango para la Hora de salida
                //Excel.Range rangoDatosnHoraSalida = excelSheet.get_Range("D" + nrow.ToString(), oOpt).get_Resize(1, 1);
                //rangoDatosnHoraSalida.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;




                excelSheet.Cells[nrow, ++ncol] = item.ToString();
                ++progressBExportEcel.Value;

                if (ncol == propList.Count)
                {
                    ncol = 0;
                    ++nrow;
                }

                if (nrow == 20) break;

            }

            

            excel.Visible = true;

        }


        private static List<PropertyInfo> GetSelectedProperties(PropertyInfo[] props, string include, string exclude)
        {
            List<PropertyInfo> propList = new List<PropertyInfo>();
            if (include != "") //Do include first
            {
                var includeProps = include.ToLower().Split(',').ToList();
                foreach (var item in props)
                {
                    var propName = includeProps.Where(a => a == item.Name.ToLower()).FirstOrDefault();
                    if (!string.IsNullOrEmpty(propName))
                        propList.Add(item);
                }
            }
            else if (exclude != "") //Then do exclude
            {
                var excludeProps = exclude.ToLower().Split(',');
                foreach (var item in props)
                {
                    var propName = excludeProps.Where(a => a == item.Name.ToLower()).FirstOrDefault();
                    if (string.IsNullOrEmpty(propName))
                        propList.Add(item);
                }
            }
            else //Default
            {
                propList.AddRange(props.ToList());
            }
            return propList;
        }



    }
}
