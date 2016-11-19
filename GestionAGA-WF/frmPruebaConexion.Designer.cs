namespace GestionAGA_WF
{
    partial class frmPruebaConexion
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
            this.lblConexion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dataGVPrueba = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblAbriendo = new System.Windows.Forms.Label();
            this.lblConexionExito = new System.Windows.Forms.Label();
            this.lblCerrando = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPrueba)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConexion
            // 
            this.lblConexion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConexion.Location = new System.Drawing.Point(12, 9);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(476, 74);
            this.lblConexion.TabIndex = 0;
            this.lblConexion.Text = "label1";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(494, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dataGVPrueba
            // 
            this.dataGVPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVPrueba.Location = new System.Drawing.Point(12, 213);
            this.dataGVPrueba.Name = "dataGVPrueba";
            this.dataGVPrueba.Size = new System.Drawing.Size(476, 122);
            this.dataGVPrueba.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(494, 41);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblAbriendo
            // 
            this.lblAbriendo.Location = new System.Drawing.Point(12, 130);
            this.lblAbriendo.Name = "lblAbriendo";
            this.lblAbriendo.Size = new System.Drawing.Size(476, 23);
            this.lblAbriendo.TabIndex = 4;
            this.lblAbriendo.Text = "Abriendo ...";
            // 
            // lblConexionExito
            // 
            this.lblConexionExito.Location = new System.Drawing.Point(12, 153);
            this.lblConexionExito.Name = "lblConexionExito";
            this.lblConexionExito.Size = new System.Drawing.Size(476, 23);
            this.lblConexionExito.TabIndex = 5;
            this.lblConexionExito.Text = "Conexion exito ... ";
            // 
            // lblCerrando
            // 
            this.lblCerrando.Location = new System.Drawing.Point(12, 176);
            this.lblCerrando.Name = "lblCerrando";
            this.lblCerrando.Size = new System.Drawing.Size(476, 23);
            this.lblCerrando.TabIndex = 6;
            this.lblCerrando.Text = "Conexion cerrada";
            // 
            // frmPruebaConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 347);
            this.Controls.Add(this.lblCerrando);
            this.Controls.Add(this.lblConexionExito);
            this.Controls.Add(this.lblAbriendo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dataGVPrueba);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblConexion);
            this.Name = "frmPruebaConexion";
            this.Text = "frmPruebaConexion";
            this.Load += new System.EventHandler(this.frmPruebaConexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVPrueba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dataGVPrueba;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblAbriendo;
        private System.Windows.Forms.Label lblConexionExito;
        private System.Windows.Forms.Label lblCerrando;
    }
}