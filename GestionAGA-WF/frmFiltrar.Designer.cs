namespace GestionAGA_WF
{
    partial class frmFiltrar
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnBuscarSiguiente = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtValorFin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBCoincideTodaCelda = new System.Windows.Forms.CheckBox();
            this.checkBCoindicirMayMin = new System.Windows.Forms.CheckBox();
            this.txtValorInicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBCampos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(389, 195);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(112, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnBuscarSiguiente
            // 
            this.btnBuscarSiguiente.Location = new System.Drawing.Point(271, 195);
            this.btnBuscarSiguiente.Name = "btnBuscarSiguiente";
            this.btnBuscarSiguiente.Size = new System.Drawing.Size(112, 23);
            this.btnBuscarSiguiente.TabIndex = 6;
            this.btnBuscarSiguiente.Text = "Refrescar";
            this.btnBuscarSiguiente.UseVisualStyleBackColor = true;
            this.btnBuscarSiguiente.Click += new System.EventHandler(this.btnBuscarSiguiente_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(153, 195);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(112, 23);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtValorFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBCoincideTodaCelda);
            this.groupBox1.Controls.Add(this.checkBCoindicirMayMin);
            this.groupBox1.Controls.Add(this.txtValorInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBCampos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 177);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtValorFin
            // 
            this.txtValorFin.Location = new System.Drawing.Point(133, 72);
            this.txtValorFin.Name = "txtValorFin";
            this.txtValorFin.Size = new System.Drawing.Size(227, 20);
            this.txtValorFin.TabIndex = 7;
            this.txtValorFin.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor final";
            this.label3.Visible = false;
            // 
            // checkBCoincideTodaCelda
            // 
            this.checkBCoincideTodaCelda.AutoSize = true;
            this.checkBCoincideTodaCelda.Location = new System.Drawing.Point(6, 153);
            this.checkBCoincideTodaCelda.Name = "checkBCoincideTodaCelda";
            this.checkBCoincideTodaCelda.Size = new System.Drawing.Size(227, 17);
            this.checkBCoincideTodaCelda.TabIndex = 5;
            this.checkBCoincideTodaCelda.Text = "Coincidir con el contenido de toda la celda";
            this.checkBCoincideTodaCelda.UseVisualStyleBackColor = true;
            this.checkBCoincideTodaCelda.Visible = false;
            // 
            // checkBCoindicirMayMin
            // 
            this.checkBCoindicirMayMin.AutoSize = true;
            this.checkBCoindicirMayMin.Location = new System.Drawing.Point(6, 130);
            this.checkBCoindicirMayMin.Name = "checkBCoindicirMayMin";
            this.checkBCoindicirMayMin.Size = new System.Drawing.Size(187, 17);
            this.checkBCoindicirMayMin.TabIndex = 4;
            this.checkBCoindicirMayMin.Text = "Coincidir mayúsculas y minúsculas";
            this.checkBCoindicirMayMin.UseVisualStyleBackColor = true;
            this.checkBCoindicirMayMin.Visible = false;
            // 
            // txtValorInicio
            // 
            this.txtValorInicio.Location = new System.Drawing.Point(133, 46);
            this.txtValorInicio.Name = "txtValorInicio";
            this.txtValorInicio.Size = new System.Drawing.Size(227, 20);
            this.txtValorInicio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor (inicio)";
            // 
            // comboBCampos
            // 
            this.comboBCampos.FormattingEnabled = true;
            this.comboBCampos.Location = new System.Drawing.Point(133, 18);
            this.comboBCampos.Name = "comboBCampos";
            this.comboBCampos.Size = new System.Drawing.Size(227, 21);
            this.comboBCampos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Columna ";
            // 
            // frmFiltrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 229);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnBuscarSiguiente);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFiltrar";
            this.Text = "Filtrar";
            this.Load += new System.EventHandler(this.frmFiltrar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnBuscarSiguiente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtValorFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBCoincideTodaCelda;
        private System.Windows.Forms.CheckBox checkBCoindicirMayMin;
        private System.Windows.Forms.TextBox txtValorInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBCampos;
        private System.Windows.Forms.Label label1;
    }
}