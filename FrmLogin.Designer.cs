namespace ProyectoAgencia
{
    partial class FrmLogin
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
            this.btncancel = new System.Windows.Forms.Button();
            this.btnacep = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtnick = new System.Windows.Forms.TextBox();
            this.lblpass = new System.Windows.Forms.Label();
            this.lblnick = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(247, 215);
            this.btncancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(111, 29);
            this.btncancel.TabIndex = 11;
            this.btncancel.Text = "CANCELAR";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnacep
            // 
            this.btnacep.Location = new System.Drawing.Point(129, 215);
            this.btnacep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnacep.Name = "btnacep";
            this.btnacep.Size = new System.Drawing.Size(111, 29);
            this.btnacep.TabIndex = 10;
            this.btnacep.Text = "ACEPTAR";
            this.btnacep.UseVisualStyleBackColor = true;
            this.btnacep.Click += new System.EventHandler(this.btnacep_Click);
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(194, 154);
            this.txtpass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(219, 25);
            this.txtpass.TabIndex = 9;
            // 
            // txtnick
            // 
            this.txtnick.Location = new System.Drawing.Point(172, 68);
            this.txtnick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtnick.Name = "txtnick";
            this.txtnick.Size = new System.Drawing.Size(241, 25);
            this.txtnick.TabIndex = 8;
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.Location = new System.Drawing.Point(85, 157);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(103, 19);
            this.lblpass.TabIndex = 7;
            this.lblpass.Text = "CONTRASEÑA:";
            // 
            // lblnick
            // 
            this.lblnick.AutoSize = true;
            this.lblnick.Location = new System.Drawing.Point(85, 71);
            this.lblnick.Name = "lblnick";
            this.lblnick.Size = new System.Drawing.Size(85, 19);
            this.lblnick.TabIndex = 6;
            this.lblnick.Text = "NICKNAME:";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 311);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnacep);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtnick);
            this.Controls.Add(this.lblpass);
            this.Controls.Add(this.lblnick);
            this.Font = new System.Drawing.Font("Century Gothic", 7F);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnacep;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtnick;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lblnick;
    }
}