namespace GestionAGA_WF
{
    partial class frmReporteProduccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteProduccion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.progressBProceso = new System.Windows.Forms.ProgressBar();
            this.groupBLegajos = new System.Windows.Forms.GroupBox();
            this.dataGridVParticulares = new System.Windows.Forms.DataGridView();
            this.groupBCajas = new System.Windows.Forms.GroupBox();
            this.dataGridVCajas = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnGenerarExcel = new System.Windows.Forms.Button();
            this.dateTimePFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsgBusqueda = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBLegajos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVParticulares)).BeginInit();
            this.groupBCajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVCajas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.progressBProceso);
            this.groupBox1.Controls.Add(this.groupBLegajos);
            this.groupBox1.Controls.Add(this.groupBCajas);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.btnGenerarExcel);
            this.groupBox1.Controls.Add(this.dateTimePFin);
            this.groupBox1.Controls.Add(this.dateTimePInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblMsgBusqueda);
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 532);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de reporte";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Procesando cajas";
            // 
            // progressBProceso
            // 
            this.progressBProceso.Location = new System.Drawing.Point(9, 134);
            this.progressBProceso.Name = "progressBProceso";
            this.progressBProceso.Size = new System.Drawing.Size(754, 24);
            this.progressBProceso.TabIndex = 20;
            // 
            // groupBLegajos
            // 
            this.groupBLegajos.Controls.Add(this.dataGridVParticulares);
            this.groupBLegajos.Location = new System.Drawing.Point(9, 347);
            this.groupBLegajos.Name = "groupBLegajos";
            this.groupBLegajos.Size = new System.Drawing.Size(757, 178);
            this.groupBLegajos.TabIndex = 19;
            this.groupBLegajos.TabStop = false;
            this.groupBLegajos.Text = "Particulares";
            // 
            // dataGridVParticulares
            // 
            this.dataGridVParticulares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVParticulares.Location = new System.Drawing.Point(6, 19);
            this.dataGridVParticulares.Name = "dataGridVParticulares";
            this.dataGridVParticulares.ReadOnly = true;
            this.dataGridVParticulares.Size = new System.Drawing.Size(745, 153);
            this.dataGridVParticulares.TabIndex = 15;
            // 
            // groupBCajas
            // 
            this.groupBCajas.Controls.Add(this.dataGridVCajas);
            this.groupBCajas.Location = new System.Drawing.Point(9, 164);
            this.groupBCajas.Name = "groupBCajas";
            this.groupBCajas.Size = new System.Drawing.Size(760, 177);
            this.groupBCajas.TabIndex = 18;
            this.groupBCajas.TabStop = false;
            this.groupBCajas.Text = "Institucionales";
            // 
            // dataGridVCajas
            // 
            this.dataGridVCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVCajas.Location = new System.Drawing.Point(6, 19);
            this.dataGridVCajas.Name = "dataGridVCajas";
            this.dataGridVCajas.ReadOnly = true;
            this.dataGridVCajas.Size = new System.Drawing.Size(745, 153);
            this.dataGridVCajas.TabIndex = 15;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(688, 19);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarExcel.Image")));
            this.btnGenerarExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerarExcel.Location = new System.Drawing.Point(688, 48);
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.Size = new System.Drawing.Size(75, 42);
            this.btnGenerarExcel.TabIndex = 14;
            this.btnGenerarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarExcel.UseVisualStyleBackColor = true;
            // 
            // dateTimePFin
            // 
            this.dateTimePFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePFin.Location = new System.Drawing.Point(99, 51);
            this.dateTimePFin.Name = "dateTimePFin";
            this.dateTimePFin.Size = new System.Drawing.Size(183, 20);
            this.dateTimePFin.TabIndex = 12;
            // 
            // dateTimePInicio
            // 
            this.dateTimePInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePInicio.Location = new System.Drawing.Point(99, 22);
            this.dateTimePInicio.Name = "dateTimePInicio";
            this.dateTimePInicio.Size = new System.Drawing.Size(183, 20);
            this.dateTimePInicio.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Del";
            // 
            // lblMsgBusqueda
            // 
            this.lblMsgBusqueda.ForeColor = System.Drawing.Color.Red;
            this.lblMsgBusqueda.Location = new System.Drawing.Point(298, 22);
            this.lblMsgBusqueda.Name = "lblMsgBusqueda";
            this.lblMsgBusqueda.Size = new System.Drawing.Size(344, 20);
            this.lblMsgBusqueda.TabIndex = 6;
            this.lblMsgBusqueda.Text = "label11";
            this.lblMsgBusqueda.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(688, 96);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmReporteProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 550);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteProduccion";
            this.Text = "frmReporteProduccion";
            this.Load += new System.EventHandler(this.frmReporteProduccion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBLegajos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVParticulares)).EndInit();
            this.groupBCajas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVCajas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progressBProceso;
        private System.Windows.Forms.GroupBox groupBLegajos;
        private System.Windows.Forms.DataGridView dataGridVParticulares;
        private System.Windows.Forms.GroupBox groupBCajas;
        private System.Windows.Forms.DataGridView dataGridVCajas;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnGenerarExcel;
        private System.Windows.Forms.DateTimePicker dateTimePFin;
        private System.Windows.Forms.DateTimePicker dateTimePInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMsgBusqueda;
        private System.Windows.Forms.Button btnCerrar;
    }
}