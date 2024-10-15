using Manejador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAgencia
{
    public partial class FrmLogin : Form
    {
        ManejadorLogin ml;
        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }

        private void btnacep_Click(object sender, EventArgs e)
        {
            string[] r = new string[2];
            string nombreUsuario = txtnick.Text;

            // Valida el usuario con el manejador_login
            r = ml.validar(txtnick.Text, txtpass.Text);

            // Si la validación es correcta
            if (r[0].Equals("C0rr3ct0"))
            {
                this.Hide();
                FrmMenu menu = new FrmMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Error de credenciales, revise");
            }
        }
    }
}
