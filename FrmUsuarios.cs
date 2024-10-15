using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Manejador;

namespace ProyectoAgencia
{
    public partial class FrmUsuarios : Form
    {
        ManejadorUsuarios mu;
        Funciones f;
        public static int idu = 0;
        int fila = 0, columna = 0;
        public static string nombre = "", apellidop = "", apellidom = "", nickname = "", password = "", nacimiento = "", rfc = "";

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            string query = $"SELECT * FROM usuarios WHERE nombre LIKE '%{busqueda}%' OR apellidop LIKE '%{busqueda}%' OR apellidom LIKE '%{busqueda}%'";
            DataSet ds = f.mostrar(query, "usuarios");
            dgvUsuarios.DataSource = ds.Tables["usuarios"];
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int idu = int.Parse(dgvUsuarios.SelectedRows[0].Cells["idu"].Value.ToString());
                string nombre = dgvUsuarios.SelectedRows[0].Cells["nombre"].Value.ToString();
                mu.Borrar(idu, nombre);
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                idu = int.Parse(dgvUsuarios.SelectedRows[0].Cells["idu"].Value.ToString());
                txtNombre.Text = dgvUsuarios.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtApellidoP.Text = dgvUsuarios.SelectedRows[0].Cells["apellidop"].Value.ToString();
                txtApellidoM.Text = dgvUsuarios.SelectedRows[0].Cells["apellidom"].Value.ToString();
                txtNickname.Text = dgvUsuarios.SelectedRows[0].Cells["nickname"].Value.ToString();
                txtPassword.Text = ""; // For security reasons, don't populate the password
                dtpNacimiento.Value = Convert.ToDateTime(dgvUsuarios.SelectedRows[0].Cells["nacimiento"].Value);
                txtRfc.Text = dgvUsuarios.SelectedRows[0].Cells["rfc"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public FrmUsuarios()
        {
            InitializeComponent();
            f = new Funciones();
            mu = new ManejadorUsuarios();
            CargarUsuarios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idu > 0)
            {
                mu.Modificar(txtNombre, txtApellidoP, txtApellidoM, txtNickname, txtPassword, dtpNacimiento, txtRfc, idu);
            }
            else
            {
                mu.Guardar(txtNombre, txtApellidoP, txtApellidoM, txtNickname, txtPassword, dtpNacimiento, txtRfc);
            }
            LimpiarCampos();
            CargarUsuarios();
        }

        private void LimpiarCampos()
        {
            idu = 0;
            txtNombre.Clear();
            txtApellidoP.Clear();
            txtApellidoM.Clear();
            txtNickname.Clear();
            txtPassword.Clear();
            dtpNacimiento.Value = DateTime.Now;
            txtRfc.Clear();
        }
        private void CargarUsuarios()
        {
            string query = "SELECT * FROM usuarios";
            DataSet ds = f.mostrar(query, "usuarios");
            dgvUsuarios.DataSource = ds.Tables["usuarios"];
        }
    }
}
