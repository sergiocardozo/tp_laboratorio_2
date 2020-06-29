namespace MainCorreo
{
    partial class FrmPPal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gBEstadoPaquetes = new System.Windows.Forms.GroupBox();
            this.lblEntregado = new System.Windows.Forms.Label();
            this.lblEnViaje = new System.Windows.Forms.Label();
            this.lblIngresado = new System.Windows.Forms.Label();
            this.lstEntregado = new System.Windows.Forms.ListBox();
            this.lstEnViaje = new System.Windows.Forms.ListBox();
            this.lstEstadoIngresado = new System.Windows.Forms.ListBox();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.gBPaquete = new System.Windows.Forms.GroupBox();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.cmsListas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBEstadoPaquetes.SuspendLayout();
            this.gBPaquete.SuspendLayout();
            this.cmsListas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBEstadoPaquetes
            // 
            this.gBEstadoPaquetes.Controls.Add(this.lblEntregado);
            this.gBEstadoPaquetes.Controls.Add(this.lblEnViaje);
            this.gBEstadoPaquetes.Controls.Add(this.lblIngresado);
            this.gBEstadoPaquetes.Controls.Add(this.lstEntregado);
            this.gBEstadoPaquetes.Controls.Add(this.lstEnViaje);
            this.gBEstadoPaquetes.Controls.Add(this.lstEstadoIngresado);
            this.gBEstadoPaquetes.Location = new System.Drawing.Point(12, 12);
            this.gBEstadoPaquetes.Name = "gBEstadoPaquetes";
            this.gBEstadoPaquetes.Size = new System.Drawing.Size(714, 242);
            this.gBEstadoPaquetes.TabIndex = 0;
            this.gBEstadoPaquetes.TabStop = false;
            this.gBEstadoPaquetes.Text = "Estado Paquetes";
            // 
            // lblEntregado
            // 
            this.lblEntregado.AutoSize = true;
            this.lblEntregado.Location = new System.Drawing.Point(485, 25);
            this.lblEntregado.Name = "lblEntregado";
            this.lblEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEntregado.TabIndex = 5;
            this.lblEntregado.Text = "Entregado";
            // 
            // lblEnViaje
            // 
            this.lblEnViaje.AutoSize = true;
            this.lblEnViaje.Location = new System.Drawing.Point(248, 25);
            this.lblEnViaje.Name = "lblEnViaje";
            this.lblEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEnViaje.TabIndex = 4;
            this.lblEnViaje.Text = "En Viaje";
            // 
            // lblIngresado
            // 
            this.lblIngresado.AutoSize = true;
            this.lblIngresado.Location = new System.Drawing.Point(14, 25);
            this.lblIngresado.Name = "lblIngresado";
            this.lblIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblIngresado.TabIndex = 3;
            this.lblIngresado.Text = "Ingresado";
            // 
            // lstEntregado
            // 
            this.lstEntregado.FormattingEnabled = true;
            this.lstEntregado.Location = new System.Drawing.Point(488, 41);
            this.lstEntregado.Name = "lstEntregado";
            this.lstEntregado.Size = new System.Drawing.Size(207, 186);
            this.lstEntregado.TabIndex = 2;
            // 
            // lstEnViaje
            // 
            this.lstEnViaje.FormattingEnabled = true;
            this.lstEnViaje.Location = new System.Drawing.Point(251, 41);
            this.lstEnViaje.Name = "lstEnViaje";
            this.lstEnViaje.Size = new System.Drawing.Size(207, 186);
            this.lstEnViaje.TabIndex = 1;
            // 
            // lstEstadoIngresado
            // 
            this.lstEstadoIngresado.FormattingEnabled = true;
            this.lstEstadoIngresado.Location = new System.Drawing.Point(17, 41);
            this.lstEstadoIngresado.Name = "lstEstadoIngresado";
            this.lstEstadoIngresado.Size = new System.Drawing.Size(207, 186);
            this.lstEstadoIngresado.TabIndex = 0;
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Location = new System.Drawing.Point(12, 260);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.ReadOnly = true;
            this.rtbMostrar.Size = new System.Drawing.Size(373, 156);
            this.rtbMostrar.TabIndex = 1;
            this.rtbMostrar.Text = "";
            // 
            // gBPaquete
            // 
            this.gBPaquete.Controls.Add(this.btnMostrarTodos);
            this.gBPaquete.Controls.Add(this.btnAgregar);
            this.gBPaquete.Controls.Add(this.txtDireccion);
            this.gBPaquete.Controls.Add(this.mtxtTrackingID);
            this.gBPaquete.Controls.Add(this.lblDireccion);
            this.gBPaquete.Controls.Add(this.lblTrackingID);
            this.gBPaquete.Location = new System.Drawing.Point(400, 260);
            this.gBPaquete.Name = "gBPaquete";
            this.gBPaquete.Size = new System.Drawing.Size(326, 156);
            this.gBPaquete.TabIndex = 2;
            this.gBPaquete.TabStop = false;
            this.gBPaquete.Text = "Paquete";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(203, 82);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(104, 36);
            this.btnMostrarTodos.TabIndex = 9;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(203, 40);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(104, 36);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(51, 98);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(146, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(51, 56);
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(146, 20);
            this.mtxtTrackingID.TabIndex = 6;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(48, 82);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(48, 40);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 4;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // cmsListas
            // 
            this.cmsListas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.cmsListas.Name = "cmsListas";
            this.cmsListas.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // FrmPPal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 428);
            this.Controls.Add(this.gBPaquete);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.gBEstadoPaquetes);
            this.Name = "FrmPPal";
            this.Text = "Correo UTN por Sergio.Esteban.Cardozo.2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPPal_FormClosing);
            this.gBEstadoPaquetes.ResumeLayout(false);
            this.gBEstadoPaquetes.PerformLayout();
            this.gBPaquete.ResumeLayout(false);
            this.gBPaquete.PerformLayout();
            this.cmsListas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBEstadoPaquetes;
        private System.Windows.Forms.ListBox lstEntregado;
        private System.Windows.Forms.ListBox lstEnViaje;
        private System.Windows.Forms.ListBox lstEstadoIngresado;
        private System.Windows.Forms.Label lblEntregado;
        private System.Windows.Forms.Label lblEnViaje;
        private System.Windows.Forms.Label lblIngresado;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.GroupBox gBPaquete;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.ContextMenuStrip cmsListas;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

