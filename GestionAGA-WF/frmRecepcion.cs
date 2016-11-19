using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionAGA_WF.DataAccessLayer;
using GestionAGA_WF.BusinessLayer;

namespace GestionAGA_WF
{
    public partial class frmRecepcion : Form
    {
        // propiedades
        private string connectionStr { get; set; }
        public List<EntityLayer.Solicitud> listSolicitud = new List<EntityLayer.Solicitud>();
        EntityLayer.Solicitud solicitudE = new EntityLayer.Solicitud();
        public EntityLayer.Usuario Usuario = new EntityLayer.Usuario();
        int statusInsert { get; set; }
        string[] opcionesDeMenu { get; set; }

        public frmRecepcion()
        {
            InitializeComponent();
            statusInsert = 0;
        }

        private void frmRecepcion_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MDIPrincipal mdi = (MDIPrincipal)this.MdiParent;
            
        }

        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            connectionStr = MDIPrincipal.connectionStr;
            SetCtrls();
        }

       

        /// <summary>
        /// El usuario selecciona algun paso del proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnabledTabControlByUser();

            //opcionesDeMenu = Usuario.opcionesDeMenu.Split(',');

            //switch (tabControl1.SelectedTab.Name)
            //{
            //    case "registroTabPage":
            //        if(Usuario.opcionesDeMenu.IndexOf('8') >= 0) groupBBodyRegistro.Enabled = true;
            //        break;

            //    default:
            //        break;
            //}

   
        }

        private void SetCtrls()
        {
            this.Cursor = Cursors.WaitCursor;


            // Pone disponibles o no los cuerpos de datos de cada pestaña
            SetEnableBodys();

            ////  define el acceso a las pestañas segun las opciones del usuario
            SetEnabledTabControlByUser();
                       
            //// inicia la carga de datos 
            SetDataInGrid();
            SetCtrlsComboBox();
           
            this.Cursor = Cursors.Default;
      

        }

        private void SetEnabledTabControlByUser()
        {
            List<EntityLayer.menuOptionsInsUpDel> listMenu = gestionUserAccess.GetListOptionsMenuUser(this.Usuario);
            foreach (EntityLayer.menuOptionsInsUpDel option in listMenu)
            {
                switch (option.menu.Trim().ToUpper())
                {
                    case "*": // todo
                        SetEnableBodys(enabled: true, enabledBody: true);
                        break;

                    case "0": // nada
                        tabControl1.Enabled = false;
                        MessageBox.Show("Navegue en la cuadricula de datos para localizar la solicitud que usted requiera.");
                        break;

                    case "8":
                        SetEnabledRegistro(false, true);
                        break;

                    case "26":
                        SetEnabledRecepcion(false, true);
                        break;

                    //case "9":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    //case "25":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    //case "10":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    //case "15":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    //case "16":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    //case "17":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    //case "27":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    //case "28":
                    //    SetEnabledRecepcion(false, true);
                    //    break;

                    default:
                        tabControl1.Enabled = true;
                        break;
                }
            }
            
        }

        
        private void SetEnableBodys(bool enabled = false, bool enabledBody = false)
        {

            SetEnabledRegistro(enabled, enabledBody);
            SetEnabledRecepcion(enabled, enabledBody);
            SetEnabledAsignacion(enabled, enabledBody);
            SetEnabledInvestigacion(enabled, enabledBody);
            SetEnabledRespuesta(enabled, enabledBody);
            SetEnabledRevision(enabled, enabledBody);
            SetEnabledFirma(enabled, enabledBody);
            SetEnabledCierre(enabled, enabledBody);
            SetEnabledFacturacion(enabled, enabledBody);
            SetEnabledPago(enabled, enabledBody);

        }

        private void SetEnabledPago(bool enabled = false, bool enabledBody = false )
        {
            groupBBodyPago.Enabled = enabledBody;
            groupBPagoFechas.Enabled = enabled;
            groupBPagoTotal.Enabled = enabled;
            groupBDGVPago.Enabled = enabled;

        }

        private void SetEnabledFacturacion(bool enabled = false, bool enabledBody = false )
        {
            groupBBodyFacturacion.Enabled = enabledBody;
        }

        private void SetEnabledCierre(bool enabled = false, bool enabledBody = false)
        {
            groupBBodyCierre.Enabled = enabledBody;
        }

        private void SetEnabledFirma(bool enabled = false, bool enabledBody = false)
        {
            groupBBodyFirma.Enabled = enabledBody;
        }

        private void SetEnabledRevision(bool enabled = false, bool enabledBody = false)
        {
            groupBBodyRevision.Enabled = enabledBody;
        }

        private void SetEnabledRespuesta(bool enabled = false, bool enabledBody = false)
        {
            groupBBodyRespuesta.Enabled = enabledBody;
        }

        private void SetEnabledInvestigacion(bool enabled = false, bool enabledBody = false)
        {
            groupBBodyInvestigacion.Enabled = enabledBody;
        }

        private void SetEnabledAsignacion(bool enabled = false, bool enabledBody = false)
        {
            groupBBodyAsignacion.Enabled = enabledBody;
        }

        private void SetEnabledRecepcion(bool enabled = false, bool enabledBody = false)
        {
            groupBBodyRecepcion.Enabled = enabledBody;
        }

        private void SetEnabledRegistro(bool enabled = false, bool enabledBody = false)
        {
            
            groupBBodyRegistro.Enabled = enabledBody;
            groupBRecepcionCaratula.Enabled = enabled;
            groupBRecepcionDocSolicitados.Enabled = enabled;

            btnRegistroAgregar.Enabled = gestionUserAccess.GetEnabledInsUserOption(this.Usuario, tabControl1, "INSERT");

        }

        private void SetCtrlsComboBox()
        {
            try
            {
                //
                SetEnabledCtrlsHeaderRegistro(false);
                SetEnabledCtrlsBodyRegistro(false);

                // Selects tabPage2 using SelectedTab.
                this.tabControl1.SelectedTab = tabControl1.TabPages[0];

                SetComboBoxEdo();
                //SetComboBoxMunicipio();
                SetComboBTipoNucleo();
                
                SetComboBPrioridad();
                
                SetcomboBTipo_Proc();
                SetcomboBClv_Proc();
                SetcomboBClv_Status();

                SetComboBNucleo();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void SetcomboBClv_Status()
        {
            BusinessLayer.StatusBL bl = new BusinessLayer.StatusBL();
            bl.strConexion = connectionStr;
            List<EntityLayer.Status> list = bl.Select();
            FillControls.ComboBox(comboBClv_Status, list, "status", "Clv_Status");
        }

        private void SetcomboBAsigStatus()
        {
            BusinessLayer.StatusBL bl = new BusinessLayer.StatusBL();
            bl.strConexion = connectionStr;
            //List<EntityLayer.Status> list = 
            FillControls.ComboBox(comboBAsigStatus, bl.Select(), "status", "Clv_Status");
        }

        private void SetcomboBRev_Clv_Status()
        {
            BusinessLayer.StatusBL bl = new BusinessLayer.StatusBL();
            bl.strConexion = connectionStr;
            //List<EntityLayer.Status> list = 
            FillControls.ComboBox(comboBRev_Clv_Status, bl.Select(), "status", "Clv_Status");
        }

        private void SetcomboBTipo_Proc()
        {
            BusinessLayer.Tipo_ProcedenciaBL bl = new BusinessLayer.Tipo_ProcedenciaBL();
            bl.strConexion = connectionStr;
            List<EntityLayer.Tipo_Procedencia> list = bl.Select();
            FillControls.ComboBox(comboBClv_TipoProc, list, "Des_TipoProc", "Clv_TipoProc");
        }

        private void SetcomboBClv_Proc()
        {
            BusinessLayer.ProcedenciaBL bl = new BusinessLayer.ProcedenciaBL();
            bl.strConexion = connectionStr;
            List<EntityLayer.Procedencia> list = bl.Select();
            FillControls.ComboBox(comboBClv_Proc, list, "Des_Proc", "Clv_Proc");
        }

      
        private void SetComboBPrioridad()
        {
            BusinessLayer.prioridadBL bl = new prioridadBL();
            bl.strConexion = connectionStr;
            List<EntityLayer.Prioridad> list = bl.Select();
            FillControls.ComboBox(comboBPrioridad, list, "Des_Prioridad", "Cve_Prioridad");
        }

        ////comboBAccionAgraria1
        //private void SetComboBAccionAgraria1()
        //{
        //    BusinessLayer.Grupo_DocumentalBL bl = new Grupo_DocumentalBL();
        //    bl.strConexion = connectionStr;

        //    List<EntityLayer.Grupo_Documental> list = bl.Select();
        //    FillControls.ComboBox(comboBAccionAgr1, list, "Des_GpoDoc", "Clv_GpoDoc");

        //    FillControls.ComboBox(comboBAccionAgr2, list, "Des_GpoDoc", "Clv_GpoDoc");
        //}

       

        private void SetComboBNucleo()
        {
            try
            {
                if ((comboBEstado.Items.Count > 0 && comboBEstado.SelectedValue != null)
                && (comboBMunicipio.Items.Count > 0 && comboBMunicipio.SelectedValue != null)
                && (comboBTipoNucleo.Items.Count > 0 && comboBTipoNucleo.SelectedValue != null))
                {
                    BusinessLayer.cat_nucBL bl = new cat_nucBL();
                    bl.strConexion = connectionStr;
                    List<EntityLayer.cat_nuc> list = bl.Select(comboBEstado.SelectedValue.ToString(), comboBMunicipio.SelectedValue.ToString(), comboBTipoNucleo.SelectedValue.ToString());
                    FillControls.ComboBox(comboBNucleo, list, "SCNNom_Nuc", "SCNCve_Unica");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
            
        }

        private void SetComboBTipoNucleo()
        {
            BusinessLayer.Tipo_nucleoBL bl = new Tipo_nucleoBL();
            bl.strConexion = connectionStr;
            List<EntityLayer.Tipo_nucleo> list = bl.Select();
            FillControls.ComboBox(comboBTipoNucleo, list, "Tipo", "Clv_Tipo");


        }

        private void SetComboBoxMunicipio()
        {
            if (comboBEstado.Items.Count > 0 && comboBEstado.SelectedValue != null)
            {
                BusinessLayer.cat_munBL munBl = new cat_munBL();
                munBl.connectionStr = connectionStr;

                comboBMunicipio.DataSource = null;
                comboBMunicipio.Items.Clear();

                List<EntityLayer.cat_mun> list = munBl.Select(connectionStr, comboBEstado.SelectedValue.ToString());
                FillControls.ComboBox(comboBMunicipio, list, "SCMNom_Mun", "SCMCve_Mun");
            }
        }

        private void SetComboBoxEdo()
        {
            BusinessLayer.cat_edoBL edoBL = new BusinessLayer.cat_edoBL();
            List<EntityLayer.cat_edo> list = edoBL.Select(connectionStr);
            FillControls.ComboBox(comboBEstado, list, "SCENom_Edo", "SCECve_Edo");
        }


        #region Agregar Registro

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistroAgregar_Click(object sender, EventArgs e)
        {

            if (btnRegistroAgregar.Text == "Agregar")
            {
                statusInsert = 1;

                btnRegistroAgregar.Text = "Guardar";

                // prepara los controles
                // limpiar encabezado de folio
                btnRegistroCancelar.Visible = true;
                dataGVSolicitud.Enabled = false;

                btnRegistroModificar.Enabled = false;
                btnRegistroEliminar.Enabled = false;

                SetEnabledCtrlsHeaderRegistro(true);
                SetCleanCtrlsHeaderRegistro();
                SetCleanCtrlsBodyRegistro();

                SetEnabledCtrlsBodyRegistro(true);
                SetCleanCtrlsHeaderRegistro();
                SetCleanCtrlsBodyRegistro();

            }
            else
            {
                // hay que guardar los controles para guardar el registro
                if (EvaluaCtrls())
                {
                    btnRegistroAgregar.Text = "Agregar";


                    // cambio de cursor para guardar los datos
                    this.Cursor = Cursors.WaitCursor;
                    groupBox1.Enabled = false;

                    // guardar registro TODO
                    SetValuesToSolicitud();
                    solicitudDAL.Insert(this.connectionStr, solicitudE);
                   
                    btnRegistroCancelar.Visible = false;
                    dataGVSolicitud.Enabled = true;

                    SetEnabledCtrlsHeaderRegistro(false);
                    SetEnabledCtrlsBodyRegistro(false);

                    SetDataInGrid();
                    this.Cursor = Cursors.Default;
                    groupBox1.Enabled = true;

                    MessageBox.Show("La solicitud se ha guardado, Gracias.");
                
                }
            }



        }

        /// <summary>
        /// Valores de los controles al objeto solicitudE
        /// </summary>
        /// <returns></returns>
        private void SetValuesToSolicitud()
        {

            solicitudE.Folio_CI = txtFolio_CI.Text;
            solicitudE.Oficio_Solicitud = txtOficio_Solicitud.Text;
            solicitudE.No_Expediente = txtNoExpediente.Text;
            solicitudE.Fecha_Solicitud = dateTimePFechaSolicitud.Value.ToShortDateString();
            solicitudE.Fecha_Venc = dateTimePFechaVencimiento.Value.ToShortDateString();

            // cuerpo de registro
            solicitudE.Solicitado_por = txtSolicitadoPor.Text;
            solicitudE.Fecha_Oficio = dateTimePFechaOficio.Value.ToShortDateString();
            solicitudE.FolioOfPartes = txtFolioOfPartes.Text;
            solicitudE.FecOfPartes = dateTimePFecOfPartes.Value.ToShortDateString();
            solicitudE.CGI = txtCGI.Text;
            solicitudE.fechaCGI = dateTimePfechaCGI.Value.ToShortDateString();
            solicitudE.SIMCR = txtSIMCR.Text;
            solicitudE.fechaSIMCR = dateTimePfechaSIMCR.Value.ToShortDateString();
            solicitudE.Clv_TipoProc = comboBClv_TipoProc.SelectedValue == null ? 0: Convert.ToInt32(comboBClv_TipoProc.SelectedValue.ToString());
            solicitudE.Clv_Proc = comboBClv_Proc.SelectedValue == null ? 0: Convert.ToInt32(comboBClv_Proc.SelectedValue.ToString());
            solicitudE.Cve_Prioridad = comboBPrioridad.SelectedValue == null ? "": comboBPrioridad.SelectedValue.ToString();
            solicitudE.Clv_Status = comboBClv_Status == null ? "": comboBClv_Status.SelectedValue.ToString();


              //solicitudE.Clv_Turnado = Convert.ToInt32(comboBTurnadoA.SelectedValue.ToString());
              //solicitudE.NombreTurnado = comboBTurnadoA.Text;
             

              //solicitudE.Clv_Edo =
              //solicitudE.Estado =
              //solicitudE.Clv_Mpo =
              //solicitudE.Municipio =
              //solicitudE.ObsMpo =
              //solicitudE.Clv_Tipo =
              //solicitudE.Clv_Nuc =
              //solicitudE.ObsNuc =
              //solicitudE.Clv_GpoDoc1 =
              //solicitudE.Clv_GpoDoc2 =

             

              //solicitudE.Clv_Responsable =
              
              
	    
	    
              //solicitudE.Doc_Solicitados =
              //solicitudE.Obs_Solicitud =
              //solicitudE.Obs_PreTurnado =
              //solicitudE.ObsExt =
              //solicitudE.Oficio_Salida =
              //solicitudE.Oficio_Salida2 =
              //solicitudE.Fecha_OfSalida =
              //solicitudE.Fecha_OfSalida2 =
              
              //solicitudE.FechaReg =
        
      
             
              
	    
              //solicitudE.LugarAtencion =
              
              //solicitudE.fecRecepcion =
        
              //solicitudE.clv_entidadSolicitante  =
              //solicitudE.entidadSolicitante =
              //solicitudE.Clasificacion  =
              //solicitudE.RecibidoAGANET =
              //solicitudE.usr_Captura  =
              //solicitudE.usr_recepcion =
              //solicitudE.status =


            
        }

        private bool EvaluaCtrls()
        {
            bool todoOk = true;

            // inicia la evaluación
            // Valida que no este vacia y contra base de datos
            if (EvaluaFolio_CI())
            {
                todoOk = true;
            }
            else
            { todoOk = false; }

            return todoOk;
        }

        private bool EvaluaFolio_CI()
        {
            bool todoOk = true;

            if (txtFolio_CI.Text == String.Empty)
            {
                MessageShowWarning("Capture el Folio CI, Gracias.");
                todoOk = false;
                txtFolio_CI.Focus();
            }
            else
            {
                // Hay datos en el Folio CI, hay que verificar en BD que no se repita
                todoOk = ValidarFolioCIvsBD();
            }
            return todoOk;
        }

        private void txtFolio_CI_Leave(object sender, EventArgs e)
        {
            // TODO
            //if (statusInsert == 1)
            //    EvaluaFolio_CI(); 
        }

        private void txtFolio_CI_TextChanged_1(object sender, EventArgs e)
        {
            if (txtFolio_CI.Text == "" && btnRegistroAgregar.Text == "Guardar")
            {
                // se define un Insert
                statusInsert = 1;
            }
            else { statusInsert = 0; }
        }

        private void MessageShowWarning(string p)
        {
            MessageBox.Show(p, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        /// <summary>
        /// Valida Folio CI, que no se repita en la base de datos
        /// </summary>
        /// <returns></returns>
        private bool ValidarFolioCIvsBD()
        {
            bool todoOk = true;
            List<EntityLayer.Solicitud> lista = solicitudDAL.SelectFolio_CI(connectionStr, txtFolio_CI.Text);
            if (lista.Count != 0)
            {
                MessageShowWarning("Ya existe el Folio CI se repite, Gracias.");
                todoOk = false;
                txtFolio_CI.Focus();
            }
            return todoOk;
        }

        private void btnRegistroCancelar_Click(object sender, EventArgs e)
        {
           

            SetCtrlsDataFromGrid();
            dataGVSolicitud.Enabled = true;

            SetEnabledBtnABC(true);

            

            // no se ve el boton cancelar
            btnRegistroCancelar.Visible = false;

            //MessageBox.Show("Se ha cancelado");
    
            btnRegistroAgregar.Text = "Agregar";
            btnRegistroAgregar.Refresh();

            btnRegistroModificar.Text = "Modificar";
            btnRegistroModificar.Refresh();

            // Pone los controles de la pestaña Registro no disponibles
            SetEnabledCtrlsHeaderRegistro(false);
            SetEnabledCtrlsBodyRegistro(false);
        
        }


        /// <summary>
        /// candidato para REFLECTION
        /// </summary>
        /// <param name="enabled"></param>
        private void SetEnabledBtnABC(bool enabled = true)
        {
            btnRegistroAgregar.Enabled = true;
            btnRegistroModificar.Enabled = true;
            btnRegistroEliminar.Enabled = true;
        }

        private void btnRegistroModificar_Click(object sender, EventArgs e)
        {
            if (btnRegistroModificar.Text == "Modificar")
            {
                statusInsert = 1;

               

                btnRegistroModificar.Text = "Guardar";

                // limpiar encabezado de folio
                btnRegistroCancelar.Visible = true;
                // se quita el acceso al Grid de datos
                dataGVSolicitud.Enabled = false;

                // Inserta registros o eliminar registro no estan disponibles
                btnRegistroAgregar.Enabled = false;
                btnRegistroEliminar.Enabled = false;

                //
                SetEnabledCtrlsHeaderRegistro(true);
                SetEnabledCtrlsBodyRegistro(true);

                //
                SetEnabledCtrlsRegistroUpDate();

            }
            else
            {
                // hay que guardar los controles para guardar el registro
                //if (EvaluaCtrls())
                //{
                btnRegistroModificar.Text = "Modificar";

                // guardar registro TODO
                //SetValoresASolicitud();
                //solicitudDAL.UpDate(this.connectionStr, solicitudE);

                // se ocuta el botón cancelar
                btnRegistroCancelar.Visible = false;
                // El grid de datos se pone disponible
                dataGVSolicitud.Enabled = true;

                // bloqueo controles de encabezado y cuerpo de la pestaña registro
                SetEnabledCtrlsHeaderRegistro(false);
                SetEnabledCtrlsBodyRegistro(false);

                btnRegistroAgregar.Enabled = true;
                btnRegistroEliminar.Enabled = true;

                MessageBox.Show("La solicitud se ha guardado, Gracias.");

                //}
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistroEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // seleccciono el registro actual,  el seleccionado 
                DataGridViewRow row = dataGVSolicitud.CurrentRow;
                string folioCI = row.Cells["Folio_CI"].Value.ToString();

                string msg = "Confirme que desea eliminar la solicitud con FOLIO CI : " + folioCI + ", gracias.";

                if (MessageRowDelete(msg) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Eliminar el registro, recuerde: no se eliminan los registros solo cambian su estatus
                    
                    this.Cursor = Cursors.WaitCursor;
                    groupBox1.Enabled = false;

                    solicitudDAL.Delete( connectionStr, folioCI, Usuario.clv_Usuario);

                    // recarga de datos, REFRESH
                                
                    SetDataInGrid();                    
                    this.Cursor = Cursors.Default;
                    groupBox1.Enabled = true;

                    MessageBox.Show("Eliminado");

                }
            }
            catch (Exception ex)
            {                
                 MessageBox.Show(ex.ToString());
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private DialogResult MessageRowDelete(string msg)
        {
            DialogResult resultado = MessageBox.Show(msg, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return resultado;
        }



        /// <summary>
        ///  Uso de parámetro opcional
        /// </summary>
        /// <param name="enabled"></param>
        private void SetEnabledCtrlsRegistroUpDate(bool enabled = false)
        {
            txtFolio_CI.Enabled = enabled;
            txtOficio_Solicitud.Focus();
        }

        
        private void SetDateTimePToCtrl(DateTimePicker dtp)
        {
            // pasa a formato corto y le asigna la fecha
            dtp.Format = DateTimePickerFormat.Short;
            dtp.Value = DateTime.Now.Date; 
        }

        private void SetCleanCtrlsBodyRegistro()
        {
            txtSolicitadoPor.Text = "";
            SetDateTimePToCtrl(dateTimePFechaOficio);
            txtFolioOfPartes.Text = "";
            SetDateTimePToCtrl(dateTimePFecOfPartes);
            txtCGI.Text = "";
            SetDateTimePToCtrl(dateTimePfechaCGI);
            txtSIMCR.Text = "";
            SetDateTimePToCtrl(dateTimePfechaSIMCR);
            comboBClv_TipoProc.SelectedValue = 0;
            comboBClv_Proc.SelectedValue = 0;
            comboBPrioridad.SelectedValue = 0;
            comboBClv_Status.SelectedValue = 0;

        }

        private void SetCleanCtrlsHeaderRegistro()
        {
            txtFolio_CI.Text = "";
            txtOficio_Solicitud.Text = "";
            txtNoExpediente.Text = "";
            SetDateTimePToCtrl(dateTimePFechaSolicitud) ;
            SetDateTimePToCtrl(dateTimePFechaVencimiento);

            txtFolio_CI.Focus();

        }

        /// <summary>
        /// Pone disponibles los controles
        /// </summary>
        /// <param name="enabled"></param>
        private void SetEnabledCtrlsHeaderRegistro(bool enabled)
         {
            txtFolio_CI.Enabled = enabled;
            txtOficio_Solicitud.Enabled = enabled;
            txtNoExpediente.Enabled = enabled;
            dateTimePFechaSolicitud.Enabled = enabled;
            dateTimePFechaVencimiento.Enabled = enabled;

         }

        private void SetEnabledCtrlsBodyRegistro(bool enabled)
        {
            txtSolicitadoPor.Enabled = enabled;
            dateTimePFechaOficio.Enabled = enabled;
            txtFolioOfPartes.Enabled = enabled;
            dateTimePFecOfPartes.Enabled = enabled;
            txtCGI.Enabled = enabled;
            dateTimePfechaCGI.Enabled = enabled;
            txtSIMCR.Enabled = enabled;
            dateTimePfechaSIMCR.Enabled = enabled;
            comboBClv_TipoProc.Enabled = enabled;
            comboBClv_Proc.Enabled = enabled;
            comboBPrioridad.Enabled = enabled;
            comboBClv_Status.Enabled = enabled;
        }



        #endregion

        #region Agregar

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecepAgregar_Click(object sender, EventArgs e)
        {
            // limpiar encabezado de folio
            btnRegistroCancelar.Visible = true;
            dataGVSolicitud.Enabled = false;

            btnRecepModificar.Enabled = false;
            btnRecepEliminar.Enabled = false;
        
        }

        private void SetCleanCtrlsBodyRecepcion()
        {
            txtSolicitadoPor.Text = "";
            SetDateTimePToCtrl(dateTimePFechaOficio);
            txtFolioOfPartes.Text = "";
            SetDateTimePToCtrl(dateTimePFecOfPartes);
            txtCGI.Text = "";
            SetDateTimePToCtrl(dateTimePfechaCGI);
            txtSIMCR.Text = "";
            SetDateTimePToCtrl(dateTimePfechaSIMCR);
            comboBClv_TipoProc.SelectedValue = 0;
            comboBClv_Proc.SelectedValue = 0;
            comboBPrioridad.SelectedValue = 0;
            comboBClv_Status.SelectedValue = 0;
        }

        private void setCleanCtrlsHeaderRecepcion()
        {
            txtRegFolio_CI.Text = "";
            txtRegOficio_Solicitud.Text = "";
            txtRegNoExpediente.Text = "";
            SetDateTimePToCtrl(dateTimePRegFechaSolicitud);
            SetDateTimePToCtrl(dateTimePRecepFechaVencimiento);

            txtRegFolio_CI.Focus();
        }

        /// <summary>
        /// Pone disponibles los controles
        /// </summary>
        /// <param name="enabled"></param>
        private void SetEnabledCtrlsHeaderRecepcion(bool enabled)
          {
             txtRegFolio_CI.Enabled = enabled;
             txtRegOficio_Solicitud.Enabled = enabled;
             txtRegNoExpediente.Enabled = enabled;
             dateTimePRegFechaSolicitud.Enabled = enabled;
             dateTimePRecepFechaVencimiento.Enabled = enabled;
             
          }

        private void SetEnabledCtrlsBodyRecepcion(bool enabled)
        {
            comboBEstado.Enabled = enabled;
            comboBMunicipio.Enabled = enabled;
            txtObservacionesMunicipio.Enabled = enabled;
            comboBTipoNucleo.Enabled = enabled;
            comboBNucleo.Enabled = enabled;
            txtNucleo.Enabled = enabled;
            txtObservacionesNucleo.Enabled = enabled;
            textBox29.Enabled = enabled;
            comboBAccionAgr1.Enabled = enabled;
            comboBAccionAgr2.Enabled = enabled;
            txtDocumentosSolicitados.Enabled = enabled;
            txtLugarDeAtencion.Enabled = enabled;
            txtObservacionesDocSol.Enabled = enabled;
            dateTimePFecRecepcion.Enabled = enabled;
        }

        #endregion

        #region Asignación


        private void btnAsigAgregar_Click(object sender, EventArgs e)
        {
            btnAsigCancelar.Visible = true;
            dataGVSolicitud.Enabled = false;

            btnAsigModificar.Enabled = false;
            btnAsigEliminar.Enabled = false;

            //SetEnabledCtrlsHeaderAsignación(true);
            //SetCleanCtrlsHeaderAsignación();
            //SetCleanCtrlsBodyAsignación();

            //SetEnabledCtrlsBodyAsignación(true);
            //SetCleanCtrlsHeaderAsignación();
            //SetCleanCtrlsBodyAsignación();



            //if (btnAsigAgregar.Text == "Agregar")
            //{
            //    statusInsert = 1;

            //    btnAsigAgregar.Text = "Guardar";

            //    // prepara los controles
            //    // limpiar encabezado de folio
            //    btnAsigCancelar.Visible = true;
            //    dataGAsignacion.Enabled = false;

            //    btnAsigModificar.Enabled = false;
            //    btnAsigEliminar.Enabled = false;

            //    SetEnabledCtrlsHeaderRegistro(true);
            //    SetCleanCtrlsHeaderRegistro();
            //    SetCleanCtrlsBodyRegistro();

            //    SetEnabledCtrlsBodyRegistro(true);
            //    SetCleanCtrlsHeaderRegistro();
            //    SetCleanCtrlsBodyRegistro();

            //}
            //else
            //{
            //    // hay que guardar los controles para guardar el registro
            //    if (EvaluaCtrls())
            //    {
            //        btnAsigAgregar.Text = "Agregar";


            //        // cambio de cursor para guardar los datos
            //        this.Cursor = Cursors.WaitCursor;
            //        groupBox1.Enabled = false;

            //        // guardar registro TODO
            //        SetValuesToSolicitud();
            //        solicitudDAL.Insert(this.connectionStr, solicitudE);

            //        btnAsigCancelar.Visible = false;
            //        dataGAsignacion.Enabled = true;

            //        SetEnabledCtrlsHeaderRegistro(false);
            //        SetEnabledCtrlsBodyRegistro(false);

            //        SetDataInGrid();
            //        this.Cursor = Cursors.Default;
            //        groupBox1.Enabled = true;

            //        MessageBox.Show("La solicitud se ha guardado, Gracias.");

            //    }
            //}
        }

        private void btnAsigEliminar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // seleccciono el registro actual,  el seleccionado 
            //    DataGridViewRow row = dataGAsignacion.CurrentRow;
            //    string folioCI = row.Cells["Folio_CI"].Value.ToString();

            //    string msg = "Confirme que desea eliminar la solicitud con FOLIO CI : " + folioCI + ", gracias.";

            //    if (MessageRowDelete(msg) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        // Eliminar el registro, recuerde: no se eliminan los registros solo cambian su estatus

            //        this.Cursor = Cursors.WaitCursor;
            //        groupBox1.Enabled = false;

            //        solicitudDAL.Delete(connectionStr, folioCI, Usuario.clv_Usuario);

            //        // recarga de datos, REFRESH

            //        SetDataInGrid();
            //        this.Cursor = Cursors.Default;
            //        groupBox1.Enabled = true;

            //        MessageBox.Show("Eliminado");

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void btnAsigCancelar_Click(object sender, EventArgs e)
        {
            SetCtrlsDataFromGrid();
            dataGVSolicitud.Enabled = true;
            btnAsigCancelar.Visible = false;

            btnAsigModificar.Enabled = true;
            btnAsigEliminar.Enabled = true;

            //SetCtrlsDataFromGrid();
            //dataGAsignacion.Enabled = true;

            //SetEnabledBtnABC(true);



            //// no se ve el boton cancelar
            //btnAsigCancelar.Visible = false;

            ////MessageBox.Show("Se ha cancelado");

            //btnAsigAgregar.Text = "Agregar";
            //btnAsigAgregar.Refresh();

            //btnAsigModificar.Text = "Modificar";
            //btnAsigModificar.Refresh();

            //// Pone los controles de la pestaña Registro no disponibles
            //SetEnabledCtrlsHeaderRegistro(false);
            //SetEnabledCtrlsBodyRegistro(false);
        }

        private void btnAsigModificar_Click(object sender, EventArgs e)
        {
            btnAsigCancelar.Visible = true;
            dataGVSolicitud.Enabled = false;

            btnAsigAgregar.Enabled = true;
            btnAsigEliminar.Enabled = false;

            SetEnabledCtrlsHeaderRegistro(true);
            SetEnabledCtrlsBodyRegistro(true);

            //if (btnAsigModificar.Text == "Modificar")
            //{
            //    statusInsert = 1;



            //    btnAsigModificar.Text = "Guardar";

            //    // limpiar encabezado de folio
            //    btnAsigCancelar.Visible = true;
            //    // se quita el acceso al Grid de datos
            //    dataGAsignacion.Enabled = false;

            //    // Inserta registros o eliminar registro no estan disponibles
            //    btnAsigAgregar.Enabled = false;
            //    btnAsigEliminar.Enabled = false;

            //    //
            //    SetEnabledCtrlsHeaderRegistro(true);
            //    SetEnabledCtrlsBodyRegistro(true);

            //    //
            //    SetEnabledCtrlsRegistroUpDate();

            //}
            //else
            //{
            //    // hay que guardar los controles para guardar el registro
            //    //if (EvaluaCtrls())
            //    //{
            //    btnAsigModificar.Text = "Modificar";

            //    // guardar registro TODO
            //    //SetValoresASolicitud();
            //    //solicitudDAL.UpDate(this.connectionStr, solicitudE);

            //    // se ocuta el botón cancelar
            //    btnAsigCancelar.Visible = false;
            //    // El grid de datos se pone disponible
            //    dataGAsignacion.Enabled = true;

            //    // bloqueo controles de encabezado y cuerpo de la pestaña registro
            //    SetEnabledCtrlsHeaderRegistro(false);
            //    SetEnabledCtrlsBodyRegistro(false);

            //    btnAsigAgregar.Enabled = true;
            //    btnAsigEliminar.Enabled = true;

            //    MessageBox.Show("La solicitud se ha guardado, Gracias.");

            //    //}
            //}
        }

        private void SetCleanCtrlsBodyAsignación()
        {
            SetDateTimePToCtrl(dateTPPreturnado);
            SetDateTimePToCtrl(dateTPTurnado);
            comboBTurnadoA.SelectedValue = 0;
            comboBRespAsignacion.SelectedValue = 0;
            comboBAsigStatus.SelectedValue = 0;
            txtAsigObservaciones.Text = "";
        }

        private void SetCleanCtrlsHeaderAsignacion()
        {
            txtAsignaFolio_CI.Text = "";
            txtAsigOficio_Solicitud.Text = "";
            txtAsigNoExpediente.Text = "";
            SetDateTimePToCtrl(dateTimePAsigSolicitud);
            SetDateTimePToCtrl(dateTimePAsigFechaVencimiento);

            txtFolio_CI.Focus();

        }

        #endregion Asignación

      
        private void SetEnabledGroupBFolios(bool enabled = false)
        {
            groupBFoliosRegistro.Enabled = enabled;
            groupBFoliosRecepcion.Enabled = enabled;
            groupBFoliosAsignacion.Enabled = enabled;
            groupBFoliosInvestigacion.Enabled = enabled;
            groupBFoliosRespuesta.Enabled = enabled;
            groupBFoliosRevision.Enabled = enabled;
            groupBFoliosFirma.Enabled = enabled;
            groupBFoliosCierre.Enabled = enabled;
            groupBFoliosFacturacion.Enabled = enabled;
            groupBFoliosPago.Enabled = enabled;
        }

        private void SetCtrlsDataFromGrid()
        { 
            DataGridViewRow row =  dataGVSolicitud.CurrentRow;

            try
            {
                if (row != null)
                {
                   

                    // Datos de encabezado
                    SetFolio_CI(row);                    
                    SetOficio_Solicitud(row);
                    SetNo_Expediente(row);
                    SetHeaderDateTimePToRowFieldFechaSolicitud(row);                   
                    SetHeaderDateTimePToRowFieldFecha_Venc(row);

                    // Registro
                    txtSolicitadoPor.Text = row.Cells["Solicitado_por"].Value.ToString();
                    SetFechaDataFromGrid(row, dateTimePFechaOficio, "Fecha_Oficio");
                    txtFolioOfPartes.Text = row.Cells["FolioOfPartes"].Value.ToString();
                    SetFechaDataFromGrid(row, dateTimePFecOfPartes, "FecOfPartes");
                    txtCGI.Text = row.Cells["CGI"].Value.ToString();
                    SetFechaDataFromGrid(row, dateTimePfechaCGI, "fechaCGI");
                    txtSIMCR.Text = row.Cells["SIMCR"].Value.ToString();
                    SetFechaDataFromGrid(row, dateTimePfechaSIMCR, "fechaSIMCR");
                    comboBClv_TipoProc.SelectedValue = row.Cells["Clv_TipoProc"].Value;
                    comboBClv_Proc.SelectedValue = row.Cells["Clv_Proc"].Value;
                    comboBPrioridad.SelectedValue = row.Cells["Cve_Prioridad"].Value.ToString();
                    comboBClv_Status.SelectedValue = row.Cells["Clv_Status"].Value.ToString().Trim();


                    comboBEstado.SelectedValue = row.Cells["Clv_Edo"].Value.ToString();                  
                    comboBTurnadoA.Text = "";

                    comboBMunicipio.SelectedValue = row.Cells["Clv_Mpo"].Value.ToString();                  
                    txtObservacionesMunicipio.Text = row.Cells["ObsMpo"].Value.ToString();
                    comboBTipoNucleo.SelectedValue = row.Cells["Clv_Tipo"].Value.ToString();

                    comboBNucleo.SelectedValue = row.Cells["Clv_Nuc"].Value.ToString();               
                    txtObservacionesNucleo.Text = row.Cells["ObsNuc"].Value.ToString();

                    
                    txtRegNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();

                   

                    


                    
                   

                   
                    
                    SetFechaDataFromGrid(row, dateTimePFecRecepcion, "FecRecepcion");
                    
                    

                               

                    

                    //Clv_GpoDoc1 = row.Cells["Clv_GpoDoc1"] is DBNull ? 0 : Convert.ToInt32(row.Cells["Clv_GpoDoc1"].ToString()),
                    //Clv_GpoDoc2 = row.Cells["Clv_GpoDoc2"] is DBNull ? 0 : Convert.ToInt32(row.Cells["Clv_GpoDoc2"].ToString()),
                    
                    //Clv_Responsable = row.Cells["Clv_Responsable"] is DBNull ? 0 : Convert.ToInt32(row.Cells["Clv_Responsable"].ToString()),
                   
                    

                           
                   
                    txtDocumentosSolicitados.Text = row.Cells["Doc_Solicitados"].Value.ToString();
                    txtObservacionesDocSol.Text = row.Cells["Obs_Solicitud"].Value.ToString();

                    

                   

                    txtLugarDeAtencion.Text = row.Cells["LugarAtencion"].Value.ToString();

                    // 
                    SetComboBoxMunicipio();
                    comboBMunicipio.SelectedValue = row.Cells["Clv_Mpo"].Value.ToString();

                    txtObservacionesMunicipio.Text = row.Cells["ObsMpo"].Value.ToString();
                    txtNucleo.Text = row.Cells["Nucleo"].Value.ToString();
                    txtObservacionesNucleo.Text = row.Cells["ObsNuc"].Value.ToString();

                    SetComboBNucleo();
                    comboBNucleo.SelectedValue = row.Cells["Clv_Nuc"].Value.ToString();

                    SetComboBAccionAgraria1();
                    SetComboBAccionAgraria2();

                    comboBAccionAgr1.SelectedValue = Convert.ToInt32(row.Cells["Clv_GpoDoc1"].Value.ToString());
                    comboBAccionAgr2.SelectedValue = Convert.ToInt32(row.Cells["Clv_GpoDoc2"].Value.ToString());


                    // turnado
                    //SetFechaDataFromGrid(row, dateTPPreturnado, "Fecha_Preturnado");
                    //SetFechaDataFromGrid(row, dateTPTurnado, "Fecha_Turnado");

                    //SetcomboBRespAsignacion();
                    //comboBRespAsignacion.SelectedValue = row.Cells["Clv_ResponsableTurnado"].Value;

                    //SetcomboBTurnadoA();
                    //comboBTurnadoA.SelectedValue = row.Cells["Clv_UsuarioTurnado"].Value;

                    //txtAsigObservaciones.Text = row.Cells["Obs_Turnado"].Value.ToString();

                    //SetcomboBAsigStatus();
                    //comboBAsigStatus.SelectedValue = row.Cells["Clv_StatusTurnado"].Value; 

                    ////// Investigacion
                    ////SetFechaDataFromGrid(row, dateTPFecha_InicioInves, "Fecha_InicioInves");
                    ////SetFechaDataFromGrid(row, dateTPFecha_FinInves, "Fecha_FinInves");
                    ////SetFechaDataFromGrid(row, dateTPfecha_inicio_ProgInves, "fecha_inicio_ProgInves");
                    ////SetFechaDataFromGrid(row, dateTPfecha_fin_ProgInves, "fecha_fin_ProgInves");

                    ////SetcomboBClv_usrInvestigador();
                    ////comboBClv_usrInvestigador.SelectedValue = row.Cells["clv_usrInvestigador"].Value;

                    ////SetcomboBClv_StatusInves();
                    ////comboBClv_StatusInves.SelectedValue = row.Cells["Clv_StatusInves"].Value;

                    ////txtobservacionesInves.Text = row.Cells["observacionesInves"].Value.ToString();


                    //  Descomentar al liberar
                    //SetDataInCtrlsRespuestaFromDataGrid(row);


                    /////
                    //
                    //
                    //
                    //
                    //SetDataInCtrlsRevisionFromDataGrid(row);

                    //setDataInctrlsFirmaFromDataGrid(row);

                    //setDataInctrlsCierreFromDataGrid(row);

                    //setDataInctrlsFacturaciónFromDataGrid(row);

                    //setDataInctrlsPagoFromDataGrid(row);

                    //txtResp_No_Planos

                }

            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void SetHeaderDateTimePToRowFieldFecha_Venc(DataGridViewRow row)
        {
            SetFechaDataFromGrid(row, dateTimePFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePRecepFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePAsigFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePInvesFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePRespFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePRevFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePFirmaFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePCierreFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePFacturaFechaVencimiento, "Fecha_Venc");
            SetFechaDataFromGrid(row, dateTimePPagoFecVenc, "Fecha_Venc");
        }

        private void SetHeaderDateTimePToRowFieldFechaSolicitud(DataGridViewRow row)
        {
            SetFechaDataFromGrid(row, dateTimePFechaSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePRegFechaSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePAsigSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePInvesSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePRespSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePRevSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePFirmaSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePCierreSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePFacturaSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePFacturaSolicitud, "Fecha_Solicitud");
            SetFechaDataFromGrid(row, dateTimePPagoFecSol, "Fecha_Solicitud");
        }

        

            //Pago
        private void setDataInctrlsPagoFromDataGrid(DataGridViewRow row)
        {
            SetFechaDataFromGrid(row, dateTPsp_fecha_Recepcion, "sp_fecha_Recepcion");
            SetFechaDataFromGrid(row, dateTPsp_fecha_Pago, "sp_fecha_Pago");
            txtsp_observacionesPago.Text = row.Cells["sp_observacionesPago"].Value.ToString();
            txtsp_totalPago.Text = row.Cells["sp_totalPago"].Value.ToString();
            
            //SetcomboBsof_elaboro();
            //sp_id_SolPago
            //sp_clv_Solicitud
            //sp_clv_Usuario


        }

        
        
        //Facturación

        private void setDataInctrlsFacturaciónFromDataGrid(DataGridViewRow row)
        {
            SetFechaDataFromGrid(row, dateTPsof_fechaFactura, "sof_fechaFactura");
            SetFechaDataFromGrid(row, dateTPsof_fechaEntrega, "sof_fechaEntrega");
            SetFechaDataFromGrid(row, dateTPsof_fechaOfPartes, "sof_fechaOfPartes");
            txtsof_Observaciones.Text = row.Cells["sof_Observaciones"].Value.ToString();
            txtsof_SelloYfechaOfPartes.Text = row.Cells["sof_SelloYfechaOfPartes"].Value.ToString();
            SetcomboBsof_elaboro();
        }

        private void SetcomboBsof_elaboro()
        {
            BusinessLayer.StatusBL bl = new BusinessLayer.StatusBL();
            bl.strConexion = connectionStr;
            FillControls.ComboBox(comboBsof_elaboro, bl.Select(), "elaboro", "clv_solicitud");
        }

             //Cierre
        private void setDataInctrlsCierreFromDataGrid(DataGridViewRow row)
        {
            SetFechaDataFromGrid(row, dateTPSen_Fecha_Rec, "en_Fecha_Rec");
            SetFechaDataFromGrid(row, dateTPen_Fecha_Entregado, "en_Fecha_Entregado");
            txten_Observaciones.Text = row.Cells["en_Observaciones"].Value.ToString();
            SetcomboBen_status();
            //comboBen_status.SelectedValue = row.Cells["en_status"].Value.ToString();
            //SetcomboBen_clv_usuario_entrega();
            //comboBen_clv_usuario_entrega.SelectedValue = row.Cells["en_clv_usuario_entrega"].Value.ToString();
        }

        private void SetcomboBen_status()
        {
            BusinessLayer.StatusBL bl = new BusinessLayer.StatusBL();
            bl.strConexion = connectionStr;
            FillControls.ComboBox(comboBen_status, bl.Select(), "status", "Clv_Status");
        }
        private void SetcomboBen_clv_usuario_entrega()
        {
            BusinessLayer.usuarioBL bl = new usuarioBL();
            bl.connectionStr = connectionStr;
            List<EntityLayer.Usuario> list = bl.SelectCatalogo();
            FillControls.ComboBox(comboBen_clv_usuario_entrega, list, "nombre", "clv_usuario_entrega");
        }


        //Firma
        private void setDataInctrlsFirmaFromDataGrid(DataGridViewRow row)
        {
            SetFechaDataFromGrid(row, dateTPSsf_Fecha_Rec, "sf_Fecha_Rec");
            SetFechaDataFromGrid(row, dateTPsf_Fecha_Firma, "sf_Fecha_Firma");
            txtsf_Observaciones.Text = row.Cells["sf_Observaciones"].Value.ToString();
            SetcomboBsf_Clv_Status();
            comboBsf_Clv_Status.SelectedValue = row.Cells["sf_Clv_Status"].Value.ToString();
            SetcomboBsf_clv_firmadoPor();
            comboBsf_clv_firmadoPor.SelectedValue = row.Cells["sf_clv_firmadoPor"].Value.ToString();
        }

        private void SetcomboBsf_Clv_Status()
        {
            BusinessLayer.StatusBL bl = new BusinessLayer.StatusBL();
            bl.strConexion = connectionStr;
            //List<EntityLayer.Status> list = 
            FillControls.ComboBox(comboBsf_Clv_Status, bl.Select(), "status", "Clv_Status");
        }

        private void SetcomboBsf_clv_firmadoPor()
        {
            BusinessLayer.usuarioBL bl = new usuarioBL();
            bl.connectionStr = connectionStr;

            List<EntityLayer.Usuario> list = bl.SelectCatalogo();
            FillControls.ComboBox(comboBsf_clv_firmadoPor, list, "nombre", "clv_Usuario");
        }

        //Revision
        private void SetDataInCtrlsRevisionFromDataGrid(DataGridViewRow row)
        {
            SetFechaDataFromGrid(row, dateTPRev_Fecha_Rec, "Rev_Fecha_Rec");
            SetFechaDataFromGrid(row, dateTPRev_Fecha_Revision, "Rev_Fecha_Revision");
            txtRev_Obs_Revision.Text = row.Cells["Rev_Obs_Revision"].Value.ToString();

            SetcomboBRev_Clv_Status();
            // Enlace del combo
            comboBRev_Clv_Status.SelectedValue = row.Cells["Rev_Clv_Status"].Value.ToString();

            SetcomboBRev_clv_usr();
            comboBRev_clv_usr.SelectedValue = row.Cells["Rev_clv_usr"].Value;

        }

        private void SetDataInCtrlsRespuestaFromDataGrid(DataGridViewRow row)
        {
            // Respuesta
            SetFechaDataFromGrid(row, dateTPResp_Resp_Fecha_Inv, "Resp_Fecha_Inv");
            SetFechaDataFromGrid(row, dateTPResp_Fecha_Ini, "Resp_Fecha_Ini");
            SetFechaDataFromGrid(row, dateTPResp_Fecha_Fin, "Resp_Fecha_Fin");
            SetFechaDataFromGrid(row, dateTPResp_Fecha_Fin2, "Resp_Fecha_Fin2");

            txtResp_No_FojasCarOfi.Text = row.Cells["Resp_No_FojasCarOfi"].Value.ToString();
            txtResp_CostoFojCarOfi.Text = row.Cells["Resp_CostoFojCarOfi"].Value.ToString();

            int totalFojas;
            int cantidadFojas;
            int costoFojas;
            if (Int32.TryParse(txtResp_No_FojasCarOfi.Text, out cantidadFojas) && Int32.TryParse(txtResp_CostoFojCarOfi.Text, out costoFojas))
            {
                totalFojas = cantidadFojas * costoFojas;
                txtTotalFojas.Text = totalFojas.ToString();
            }



            // 
            txtResp_No_FojasNoCarOfi.Text = row.Cells["Resp_No_FojasNoCarOfi"].Value.ToString();
            txtResp_CostoFojNoCarOfi.Text = row.Cells["Resp_CostoFojNoCarOfi"].Value.ToString();
            int totalFojasNoCarOf;
            int cantidadFojasNoCarOf;
            int costoNo_FojasNoCarOf;
            if (Int32.TryParse(txtResp_No_FojasNoCarOfi.Text, out cantidadFojasNoCarOf) && Int32.TryParse(txtResp_CostoFojNoCarOfi.Text, out costoNo_FojasNoCarOf))
            {
                totalFojasNoCarOf = cantidadFojasNoCarOf * costoNo_FojasNoCarOf;
                txtTotalCostoFojNoCarOfi.Text = totalFojasNoCarOf.ToString();
            }


            // Planos
            txtResp_No_Planos.Text = row.Cells["Resp_No_Planos"].Value.ToString();
            txtResp_CostoPlanos.Text = row.Cells["Resp_CostoPlanos"].Value.ToString();

            int totalPlanos;
            int cantidadPlanos;
            int costoPlanos;
            if (Int32.TryParse(txtResp_No_Planos.Text, out cantidadPlanos) && Int32.TryParse(txtResp_CostoPlanos.Text, out costoPlanos))
            {
                totalPlanos = cantidadPlanos * costoPlanos;
                txtTotalPlanos.Text = totalPlanos.ToString();
            }

            // HojasPlanos
            txtResp_No_HojaPlano.Text = row.Cells["Resp_No_HojaPlano"].Value.ToString();
            txtResp_CostoHojaPlano.Text = row.Cells["Resp_CostoHojaPlano"].Value.ToString();

            int totalHojasPlanos;
            int cantidadHojasPlanos;
            int costoHojasPlanos;
            if (Int32.TryParse(txtResp_No_HojaPlano.Text, out cantidadHojasPlanos) && Int32.TryParse(txtResp_CostoHojaPlano.Text, out costoHojasPlanos))
            {
                totalHojasPlanos = cantidadHojasPlanos * costoHojasPlanos;
                txtResp_TotalHojaPlano.Text = totalHojasPlanos.ToString();
            }

            // compulsa
            // 
            txtResp_Compulsa.Text = row.Cells["Resp_No_HojaPlano"].Value.ToString();
            txtResp_CostoCompulsa.Text = row.Cells["Resp_CostoCompulsa"].Value.ToString();
            txtResp_Num_Doc.Text = row.Cells["Resp_Num_Doc"].Value.ToString();
            txtResp_CostoTotal.Text = row.Cells["Resp_CostoTotal"].Value.ToString();

            txtResp_Doc_Entregados.Text = row.Cells["Resp_Doc_Entregados"].Value.ToString();
            txtResp_Obs_Respuesta.Text = row.Cells["Resp_Obs_Respuesta"].Value.ToString();

            // TODO
            //comboBResp_Clv_Status.SelectedValue = row.Cells["Resp_Obs_Respuesta"].Value.ToString();

            txtResp_Notificacion.Text = row.Cells["Resp_Notificacion"].Value.ToString();
            SetFechaDataFromGrid(row, dateTPResp_FecEnvio, "Resp_FecEnvio");

            



        }

        private void SetcomboBClv_StatusInves()
        {
            BusinessLayer.StatusBL bl = new BusinessLayer.StatusBL();
            bl.strConexion = connectionStr;
            List<EntityLayer.Status> list = bl.Select();
            FillControls.ComboBox(comboBClv_StatusInves, list, "status", "Clv_Status");
        }

        private void SetComboBAccionAgraria1()
        {
            BusinessLayer.Grupo_DocumentalBL bl = new Grupo_DocumentalBL();
            bl.strConexion = connectionStr;

            List<EntityLayer.Grupo_Documental> list = bl.Select();
            FillControls.ComboBox(comboBAccionAgr1, list, "Des_GpoDoc", "Clv_GpoDoc");

            FillControls.ComboBox(comboBAccionAgr2, list, "Des_GpoDoc", "Clv_GpoDoc");
        }

        private void SetComboBAccionAgraria2()
        {
            BusinessLayer.Grupo_DocumentalBL bl = new Grupo_DocumentalBL();
            bl.strConexion = connectionStr;

            List<EntityLayer.Grupo_Documental> list = bl.Select();
            FillControls.ComboBox(comboBAccionAgr2, list, "Des_GpoDoc", "Clv_GpoDoc");
        }

        //private void SetcomboBTurnadoA()
        //{
        //    BusinessLayer.Grupo_DocumentalBL bl = new Grupo_DocumentalBL();
        //    bl.strConexion = connectionStr;

        //    List<EntityLayer.Grupo_Documental> list = bl.Select();
        //    FillControls.ComboBox(comboBTurnadoA, list, "Des_GpoDoc", "Clv_GpoDoc");
        //}

        private void SetcomboBRespAsignacion()
        {
            BusinessLayer.usuarioBL bl = new usuarioBL();
            bl.connectionStr = connectionStr;

            List<EntityLayer.Usuario> list = bl.SelectCatalogo();
            FillControls.ComboBox(comboBRespAsignacion, list, "nombre", "clv_Usuario");
        }

        private void SetcomboBTurnadoA()
        {
            BusinessLayer.usuarioBL bl = new usuarioBL();
            bl.connectionStr = connectionStr;

            List<EntityLayer.Usuario> list = bl.SelectCatalogo();
            FillControls.ComboBox(comboBTurnadoA, list, "nombre", "clv_Usuario");
        }

        private void SetcomboBRev_clv_usr()
        {
            BusinessLayer.usuarioBL bl = new usuarioBL();
            bl.connectionStr = connectionStr;

            List<EntityLayer.Usuario> list = bl.SelectCatalogo();
            FillControls.ComboBox(comboBRev_clv_usr, list, "nombre", "clv_Usuario");
        }

        // comboBClv_usrInvestigador
        private void SetcomboBClv_usrInvestigador()
        {
            BusinessLayer.usuarioBL bl = new usuarioBL();
            bl.connectionStr = connectionStr;

            List<EntityLayer.Usuario> list = bl.SelectCatalogo();
            FillControls.ComboBox(comboBClv_usrInvestigador, list, "nombre", "clv_Usuario");
        }


        private void SetNo_Expediente(DataGridViewRow row)
        {
            txtNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtRegNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtAsigNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtInvesNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtRespNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtRevNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtFirmaNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtCierraNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtFacturaNoExpediente.Text = row.Cells["No_Expediente"].Value.ToString();
            txtPagoNoExp.Text = row.Cells["No_Expediente"].Value.ToString();
        }

        private void SetOficio_Solicitud(DataGridViewRow row)
        {
            txtOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtRegOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtAsigOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtInvesOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtRespOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtRevOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtFirmaOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtCierreOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtFacturaOficio_Solicitud.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
            txtPagoOficioSol.Text = row.Cells["Oficio_Solicitud"].Value.ToString();
        }

        private void SetFechaDataFromGrid(DataGridViewRow row, DateTimePicker dtp,  string columna)
        {
            DateTime fecha;
            if (DateTime.TryParse(row.Cells[columna].Value.ToString(), out fecha))
            {
                dtp.Format = DateTimePickerFormat.Short;
                dtp.Value = Convert.ToDateTime(row.Cells[columna].Value.ToString());
            }
            else
            {
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = " ";
            }

        }

        private void SetFolio_CI(DataGridViewRow row)
        {
            txtFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtRegFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtAsignaFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtInvestigaFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtRespFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtRevFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtFirmaFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtCierreFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtFacturaFolio_CI.Text = row.Cells["Folio_CI"].Value.ToString();
            txtPagoFolioCI.Text = row.Cells["Folio_CI"].Value.ToString();
        }     
        
        private void SetDataInGrid()
        {
            try 
	        {
                dataGVSolicitud.DataSource = null;
                listSolicitud = solicitudDAL.Select(connectionStr);

                dataGVSolicitud.DataSource = listSolicitud;
                groupBData.Text = "Registros encontrados: " + dataGVSolicitud.Rows.Count.ToString();

                SetVisibleDataGridCells();

	        }
	        catch (Exception ex)
	        {
		
		        MessageBox.Show(ex.ToString());
	        }
            
        }


        private void SetDataInGridFolio_CI()
        {
            try
            {
                dataGVSolicitud.DataSource = null;
                listSolicitud = solicitudDAL.SelectFolio_CI(connectionStr, txtFolio_CI.Text);

                dataGVSolicitud.DataSource = listSolicitud;
                groupBData.Text = "Solicitudes : " + dataGVSolicitud.Rows.Count.ToString();

                SetVisibleDataGridCells();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }


        private void SetVisibleDataGridCells()
        {
            //dataGVSolicitud.Columns[0].Visible = false;

        }
        
        
        private void btnActualizaDatos_Click(object sender, EventArgs e)
        {
            SetDataInGrid();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        ///// <summary>
        ///// Agregar
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void button6_Click(object sender, EventArgs e)
        //{
        //    if (btnRecepAgregar.Text == "Agregar")
        //    {
        //        SetClearCtrls();
        //    }
        //    else
        //    {
        //        SetCtrlsEdicionToEntity();

        //    }
            
        //}

        private void SetClearCtrls()
        {
              txtFolio_CI.Text = "";
              txtNoExpediente.Text = "";

              comboBEstado.Text = "";
              comboBEstado.Text = "";
              comboBMunicipio.Text =  "";
              comboBMunicipio.Text = "";
              txtObservacionesMunicipio.Text = "";
              comboBTipoNucleo.Text = "";
              comboBNucleo.Text = "";
              comboBNucleo.Text = "";
              txtObservacionesNucleo.Text = "";
        }

        private void SetCtrlsEdicionToEntity()
        {
            solicitudE = new EntityLayer.Solicitud()
            {
                
                //Clv_Solicitud = Convert.ToInt32(dr["Clv_Solicitud"].ToString()),
                Folio_CI = txtFolio_CI.Text,
                Clv_Edo = comboBEstado.SelectedValue.ToString(),
                Estado = comboBEstado.Text,
                Clv_Mpo = comboBMunicipio.SelectedValue.ToString(),
                Municipio = comboBMunicipio.Text,
                ObsMpo = txtObservacionesMunicipio.Text,
                Clv_Tipo = comboBTipoNucleo.SelectedValue.ToString(),
                Clv_Nuc = comboBNucleo.SelectedValue.ToString(),
                Nucleo = comboBNucleo.Text,
                ObsNuc = txtObservacionesNucleo.Text,
                No_Expediente = txtNoExpediente.Text,
                //Clv_GpoDoc1 = dr["Clv_GpoDoc1"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_GpoDoc1"].ToString()),
                //Clv_GpoDoc2 = dr["Clv_GpoDoc2"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_GpoDoc2"].ToString()),
                //Clv_TipoProc = dr["Clv_TipoProc"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_TipoProc"].ToString()),
                //Clv_Proc = dr["Clv_Proc"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_Proc"].ToString()),
                Clv_Responsable = Usuario.clv_Usuario,
                Fecha_Oficio = dateTimePFechaOficio.Value.ToString(),
                Solicitado_por = txtSolicitadoPor.Text,
                Oficio_Solicitud = txtOficio_Solicitud.Text,
                Fecha_Solicitud = dateTimePFechaSolicitud.Value.ToString(),
                Doc_Solicitados = txtDocumentosSolicitados.Text,
                Obs_Solicitud = txtObservacionesDocSol.Text,
                Obs_PreTurnado = "",
                //ObsExt = dr["ObsExt"] is DBNull ? "" : dr["ObsExt"].ToString(),
                //Oficio_Salida = dr["Oficio_Salida"] is DBNull ? "" : dr["Oficio_Salida"].ToString(),
                //Oficio_Salida2 = dr["Oficio_Salida2"] is DBNull ? "" : dr["Oficio_Salida2"].ToString(),
                //Fecha_OfSalida = dr["Fecha_OfSalida"] is DBNull ? "" : dr["Fecha_OfSalida"].ToString(),
                //Fecha_OfSalida2 = dr["Fecha_OfSalida2"] is DBNull ? "" : dr["Fecha_OfSalida2"].ToString(),
                Clv_Status = "",
                //FechaReg = dr["FechaReg"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["Clv_Status"].ToString())

            };

            
        }

        private void dataGVSolicitud_CurrentCellChanged(object sender, EventArgs e)
        {
            SetCtrlsDataFromGrid();
        }

        private void txtFolio_CI_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void comboBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetComboBoxMunicipio();
        }

        private void label86_Click(object sender, EventArgs e)
        {

        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void txtRespCantidadFojas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (txtRespCantidadFojas.Text.IndexOf(".") > 0)
            //{ e.Handled = true; }

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (txtResp_No_FojasCarOfi.Text.IndexOf(".") > 0)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFolio_CI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {                
                e.Handled = true;
                txtOficio_Solicitud.Focus();
            }
        }

        private void txtOficio_Solicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                txtNoExpediente.Focus();
            }
        }

        #region Revision
        private void btnRevAgregar_Click(object sender, EventArgs e)
        {
            //if (btnRevAgregar.Text == "Agregar")
            //{
            //    statusInsert = 1;

            //    btnRevAgregar.Text = "Guardar";

            //    // prepara los controles
            //    // limpiar encabezado de folio
            //    btnAsigCancelar.Visible = true;
            //    dataGRevision.Enabled = false;

            //    btnRevModificar.Enabled = false;
            //    btnRevEliminar.Enabled = false;

            //    SetEnabledCtrlsHeaderRegistro(true);
            //    SetCleanCtrlsHeaderRegistro();
            //    SetCleanCtrlsBodyRegistro();

            //    SetEnabledCtrlsBodyRegistro(true);
            //    SetCleanCtrlsHeaderRegistro();
            //    SetCleanCtrlsBodyRegistro();

            //}
            //else
            //{
            //    // hay que guardar los controles para guardar el registro
            //    if (EvaluaCtrls())
            //    {
            //        btnRevAgregar.Text = "Agregar";


            //        // cambio de cursor para guardar los datos
            //        this.Cursor = Cursors.WaitCursor;
            //        groupBox1.Enabled = false;

            //        // guardar registro TODO
            //        SetValuesToSolicitud();
            //        solicitudDAL.Insert(this.connectionStr, solicitudE);

            //        btnAsigCancelar.Visible = false;
            //        dataGRevision.Enabled = true;

            //        SetEnabledCtrlsHeaderRegistro(false);
            //        SetEnabledCtrlsBodyRegistro(false);

            //        SetDataInGrid();
            //        this.Cursor = Cursors.Default;
            //        groupBox1.Enabled = true;

            //        MessageBox.Show("La solicitud se ha guardado, Gracias.");

            //    }
            //}
        }

        private void btnRevModificar_Click(object sender, EventArgs e)
        {
            //if (btnRevModificar.Text == "Modificar")
            //{
            //    statusInsert = 1;



            //    btnRevModificar.Text = "Guardar";

            //    // limpiar encabezado de folio
            //    btnAsigCancelar.Visible = true;
            //    // se quita el acceso al Grid de datos
            //    dataGAsignacion.Enabled = false;

            //    // Inserta registros o eliminar registro no estan disponibles
            //    btnRevAgregar.Enabled = false;
            //    btnRevEliminar.Enabled = false;

            //    //
            //    SetEnabledCtrlsHeaderRegistro(true);
            //    SetEnabledCtrlsBodyRegistro(true);

            //    //
            //    SetEnabledCtrlsRegistroUpDate();

            //}
            //else
            //{
            //    // hay que guardar los controles para guardar el registro
            //    //if (EvaluaCtrls())
            //    //{
            //    btnRevModificar.Text = "Modificar";

            //    // guardar registro TODO
            //    //SetValoresASolicitud();
            //    //solicitudDAL.UpDate(this.connectionStr, solicitudE);

            //    // se ocuta el botón cancelar
            //    btnAsigCancelar.Visible = false;
            //    // El grid de datos se pone disponible
            //    dataGRevision.Enabled = true;

            //    // bloqueo controles de encabezado y cuerpo de la pestaña registro
            //    SetEnabledCtrlsHeaderRegistro(false);
            //    SetEnabledCtrlsBodyRegistro(false);

            //    btnRevAgregar.Enabled = true;
            //    btnRevEliminar.Enabled = true;

            //    MessageBox.Show("La solicitud se ha guardado, Gracias.");

            //    //}
            //}
        }

        private void btnRevEliminar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // seleccciono el registro actual,  el seleccionado 
            //    DataGridViewRow row = dataGRevision.CurrentRow;
            //    string folioCI = row.Cells["Folio_CI"].Value.ToString();

            //    string msg = "Confirme que desea eliminar la solicitud con FOLIO CI : " + folioCI + ", gracias.";

            //    if (MessageRowDelete(msg) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        // Eliminar el registro, recuerde: no se eliminan los registros solo cambian su estatus

            //        this.Cursor = Cursors.WaitCursor;
            //        groupBox1.Enabled = false;

            //        solicitudDAL.Delete(connectionStr, folioCI, Usuario.clv_Usuario);

            //        // recarga de datos, REFRESH

            //        SetDataInGrid();
            //        this.Cursor = Cursors.Default;
            //        groupBox1.Enabled = true;

            //        MessageBox.Show("Eliminado");

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }


        private void btnCorreccionRevision_Click(object sender, EventArgs e)
        {

        }


        private void btnRevisionFirma_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarRevision_Click(object sender, EventArgs e)
        {

        }


        #endregion Revision

        #region Facturacion
        private void btnFactAgregar_Click(object sender, EventArgs e)
        {
            //if (btnFactAgregar.Text == "Agregar")
            //{
            //    statusInsert = 1;

            //    btnFactAgregar.Text = "Guardar";

            //    // prepara los controles
            //    // limpiar encabezado de folio
            //    btnAsigCancelar.Visible = true;
            //    dataGFacturacion.Enabled = false;

            //    btnFactModificar.Enabled = false;
            //    btnFactEliminar.Enabled = false;

            //    SetEnabledCtrlsHeaderRegistro(true);
            //    SetCleanCtrlsHeaderRegistro();
            //    SetCleanCtrlsBodyRegistro();

            //    SetEnabledCtrlsBodyRegistro(true);
            //    SetCleanCtrlsHeaderRegistro();
            //    SetCleanCtrlsBodyRegistro();

            //}
            //else
            //{
            //    // hay que guardar los controles para guardar el registro
            //    if (EvaluaCtrls())
            //    {
            //        btnFactAgregar.Text = "Agregar";


            //        // cambio de cursor para guardar los datos
            //        this.Cursor = Cursors.WaitCursor;
            //        groupBox1.Enabled = false;

            //        // guardar registro TODO
            //        SetValuesToSolicitud();
            //        solicitudDAL.Insert(this.connectionStr, solicitudE);

            //        btnAsigCancelar.Visible = false;
            //        dataGFacturacion.Enabled = true;

            //        SetEnabledCtrlsHeaderRegistro(false);
            //        SetEnabledCtrlsBodyRegistro(false);

            //        SetDataInGrid();
            //        this.Cursor = Cursors.Default;
            //        groupBox1.Enabled = true;

            //        MessageBox.Show("La solicitud se ha guardado, Gracias.");

            //    }
            //}
        }

        private void btnFactModificar_Click(object sender, EventArgs e)
        {
            //if (btnFactModificar.Text == "Modificar")
            //{
            //    statusInsert = 1;



            //    btnFactModificar.Text = "Guardar";

            //    // limpiar encabezado de folio
            //    btnAsigCancelar.Visible = true;
            //    // se quita el acceso al Grid de datos
            //    dataGFacturacion.Enabled = false;

            //    // Inserta registros o eliminar registro no estan disponibles
            //    btnFactAgregar.Enabled = false;
            //    btnFactEliminar.Enabled = false;

            //    //
            //    SetEnabledCtrlsHeaderRegistro(true);
            //    SetEnabledCtrlsBodyRegistro(true);

            //    //
            //    SetEnabledCtrlsRegistroUpDate();

            //}
            //else
            //{
            //    // hay que guardar los controles para guardar el registro
            //    //if (EvaluaCtrls())
            //    //{
            //    btnFactModificar.Text = "Modificar";

            //    // guardar registro TODO
            //    //SetValoresASolicitud();
            //    //solicitudDAL.UpDate(this.connectionStr, solicitudE);

            //    // se ocuta el botón cancelar
            //    btnAsigCancelar.Visible = false;
            //    // El grid de datos se pone disponible
            //    dataGFacturacion.Enabled = true;

            //    // bloqueo controles de encabezado y cuerpo de la pestaña registro
            //    SetEnabledCtrlsHeaderRegistro(false);
            //    SetEnabledCtrlsBodyRegistro(false);

            //    btnFactAgregar.Enabled = true;
            //    btnFactEliminar.Enabled = true;

            //    MessageBox.Show("La solicitud se ha guardado, Gracias.");

            //    //}
            //}
        }

        private void btnFactEliminar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // seleccciono el registro actual,  el seleccionado 
            //    DataGridViewRow row = dataGFacturacion.CurrentRow;
            //    string folioCI = row.Cells["Folio_CI"].Value.ToString();

            //    string msg = "Confirme que desea eliminar la solicitud con FOLIO CI : " + folioCI + ", gracias.";

            //    if (MessageRowDelete(msg) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        // Eliminar el registro, recuerde: no se eliminan los registros solo cambian su estatus

            //        this.Cursor = Cursors.WaitCursor;
            //        groupBox1.Enabled = false;

            //        solicitudDAL.Delete(connectionStr, folioCI, Usuario.clv_Usuario);

            //        // recarga de datos, REFRESH

            //        SetDataInGrid();
            //        this.Cursor = Cursors.Default;
            //        groupBox1.Enabled = true;

            //        MessageBox.Show("Eliminado");

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        #endregion Facturacion

        #region Investigacion
        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void btnInvestigacionModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnInvestigacionCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnInvestigacionEliminar_Click(object sender, EventArgs e)
        {

        }

        #endregion Investigacion

        private void button18_Click(object sender, EventArgs e)
        {

        }

       
        
       

       

        #region Respuesta


        #endregion Respuesta

    }
}
