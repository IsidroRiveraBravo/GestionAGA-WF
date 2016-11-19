namespace GestionAGA_WF
{
    partial class frmCargarDatos
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
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.openFileCargaDatos = new System.Windows.Forms.OpenFileDialog();
            this.grbCargaDatos = new System.Windows.Forms.GroupBox();
            this.lblCargaExcel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMsgNumReg = new System.Windows.Forms.Label();
            this.grbCargaDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(435, 45);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(435, 74);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 6;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(435, 103);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(8, 29);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(46, 13);
            this.lblArchivo.TabIndex = 3;
            this.lblArchivo.Text = "Archivo:";
            this.lblArchivo.Click += new System.EventHandler(this.lblArchivo_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(8, 45);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(405, 20);
            this.txtArchivo.TabIndex = 4;
            // 
            // openFileCargaDatos
            // 
            this.openFileCargaDatos.FileName = "openFileCargaDatos";
            // 
            // grbCargaDatos
            // 
            this.grbCargaDatos.Controls.Add(this.lblMsgNumReg);
            this.grbCargaDatos.Controls.Add(this.progressBar1);
            this.grbCargaDatos.Controls.Add(this.lblCargaExcel);
            this.grbCargaDatos.Controls.Add(this.btnAbrir);
            this.grbCargaDatos.Controls.Add(this.txtArchivo);
            this.grbCargaDatos.Controls.Add(this.lblArchivo);
            this.grbCargaDatos.Controls.Add(this.btnCargar);
            this.grbCargaDatos.Controls.Add(this.btnCancelar);
            this.grbCargaDatos.Location = new System.Drawing.Point(4, 12);
            this.grbCargaDatos.Name = "grbCargaDatos";
            this.grbCargaDatos.Size = new System.Drawing.Size(516, 145);
            this.grbCargaDatos.TabIndex = 1;
            this.grbCargaDatos.TabStop = false;
            this.grbCargaDatos.Text = "Carga de Datos";
            this.grbCargaDatos.Enter += new System.EventHandler(this.grbCargaDatos_Enter);
            // 
            // lblCargaExcel
            // 
            this.lblCargaExcel.AutoSize = true;
            this.lblCargaExcel.Location = new System.Drawing.Point(11, 72);
            this.lblCargaExcel.Name = "lblCargaExcel";
            this.lblCargaExcel.Size = new System.Drawing.Size(0, 13);
            this.lblCargaExcel.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 103);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(402, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // lblMsgNumReg
            // 
            this.lblMsgNumReg.AutoSize = true;
            this.lblMsgNumReg.Location = new System.Drawing.Point(14, 84);
            this.lblMsgNumReg.Name = "lblMsgNumReg";
            this.lblMsgNumReg.Size = new System.Drawing.Size(118, 13);
            this.lblMsgNumReg.TabIndex = 9;
            this.lblMsgNumReg.Text = "Número de Registros :  ";
            // 
            // CargarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 166);
            this.Controls.Add(this.grbCargaDatos);
            this.Name = "CargarDatos";
            this.Text = "Cargar de Datos";
            this.Load += new System.EventHandler(this.CargarDatos_Load);
            this.grbCargaDatos.ResumeLayout(false);
            this.grbCargaDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.OpenFileDialog openFileCargaDatos;
        private System.Windows.Forms.GroupBox grbCargaDatos;
        private System.Windows.Forms.Label lblCargaExcel;
        private System.Windows.Forms.Label lblMsgNumReg;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}