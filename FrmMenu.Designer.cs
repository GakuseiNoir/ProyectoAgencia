namespace ProyectoAgencia
{
    partial class FrmMenu
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
            this.mst = new System.Windows.Forms.MenuStrip();
            this.btnProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mst.SuspendLayout();
            this.SuspendLayout();
            // 
            // mst
            // 
            this.mst.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mst.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mst.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProductos,
            this.btnHerramientas,
            this.btnUsuarios,
            this.btnExit});
            this.mst.Location = new System.Drawing.Point(0, 0);
            this.mst.Name = "mst";
            this.mst.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mst.Size = new System.Drawing.Size(1477, 33);
            this.mst.TabIndex = 1;
            this.mst.Text = "menuStrip1";
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.MistyRose;
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(131, 29);
            this.btnProductos.Text = "PRODUCTOS";
            // 
            // btnHerramientas
            // 
            this.btnHerramientas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnHerramientas.Name = "btnHerramientas";
            this.btnHerramientas.Size = new System.Drawing.Size(157, 29);
            this.btnHerramientas.Text = "HERRAMIENTAS";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(166, 29);
            this.btnUsuarios.Text = "REGISTRO USERS";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 29);
            this.btnExit.Text = "EXIT";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 819);
            this.Controls.Add(this.mst);
            this.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.Name = "FrmMenu";
            this.Text = "Form1";
            this.mst.ResumeLayout(false);
            this.mst.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mst;
        private System.Windows.Forms.ToolStripMenuItem btnProductos;
        private System.Windows.Forms.ToolStripMenuItem btnHerramientas;
        private System.Windows.Forms.ToolStripMenuItem btnUsuarios;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

