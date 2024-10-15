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
            this.tsFrmProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFrmHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFrmUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mst.SuspendLayout();
            this.SuspendLayout();
            // 
            // mst
            // 
            this.mst.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mst.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mst.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFrmProductos,
            this.tsFrmHerramientas,
            this.tsFrmUsuarios,
            this.btnExit});
            this.mst.Location = new System.Drawing.Point(0, 0);
            this.mst.Name = "mst";
            this.mst.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mst.Size = new System.Drawing.Size(1477, 33);
            this.mst.TabIndex = 1;
            this.mst.Text = "menuStrip1";
            // 
            // tsFrmProductos
            // 
            this.tsFrmProductos.BackColor = System.Drawing.Color.MistyRose;
            this.tsFrmProductos.Name = "tsFrmProductos";
            this.tsFrmProductos.Size = new System.Drawing.Size(131, 29);
            this.tsFrmProductos.Text = "PRODUCTOS";
            // 
            // tsFrmHerramientas
            // 
            this.tsFrmHerramientas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tsFrmHerramientas.Name = "tsFrmHerramientas";
            this.tsFrmHerramientas.Size = new System.Drawing.Size(157, 29);
            this.tsFrmHerramientas.Text = "HERRAMIENTAS";
            // 
            // tsFrmUsuarios
            // 
            this.tsFrmUsuarios.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tsFrmUsuarios.Name = "tsFrmUsuarios";
            this.tsFrmUsuarios.Size = new System.Drawing.Size(166, 29);
            this.tsFrmUsuarios.Text = "REGISTRO USERS";
            this.tsFrmUsuarios.Click += new System.EventHandler(this.tsFrmUsuarios_Click);
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
        private System.Windows.Forms.ToolStripMenuItem tsFrmProductos;
        private System.Windows.Forms.ToolStripMenuItem tsFrmHerramientas;
        private System.Windows.Forms.ToolStripMenuItem tsFrmUsuarios;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

