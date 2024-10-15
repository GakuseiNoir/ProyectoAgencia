using AccesoDatos;
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
    public partial class FrmHerramientas : Form
    {
        ManejadorHerramientas mh;
        private bool[] permissions;
        Funciones f;
        public static int codigoHerramienta = 0;
        public FrmHerramientas(bool[] permissions)
        {
            InitializeComponent();
            f = new Funciones();
            this.permissions = permissions;
            mh = new ManejadorHerramientas();
        }
        private void ApplyPermissions()
        {
            btnGuardar.Enabled = permissions[1]; // Write permission
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvHerramientas.SelectedRows.Count > 0;
            btnModificar.Enabled = hasSelection && permissions[3]; // Update permission
            btnEliminar.Enabled = hasSelection && permissions[2]; // Delete permission
        }

        private void CargarHerramientas()
        {
            string query = "SELECT codigo, nombre, medida, marca, descripcion FROM Herramientas";
            DataSet ds = f.mostrar(query, "herramientas");
            if (dgvHerramientas != null && ds != null && ds.Tables["herramientas"] != null)
            {
                dgvHerramientas.DataSource = ds.Tables["herramientas"];
                UpdateButtonStates();
            }
            else
            {
                MessageBox.Show("Error al cargar las herramientas. Por favor, contacte al administrador del sistema.");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            string query = $"SELECT codigo, nombre, medida, marca, descripcion FROM Herramientas WHERE nombre LIKE '%{busqueda}%' OR codigo LIKE '%{busqueda}%'";
            DataSet ds = f.mostrar(query, "herramientas");
            dgvHerramientas.DataSource = ds.Tables["herramientas"];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (permissions[1]) // Check write permission
            {
                if (codigoHerramienta > 0 && permissions[3]) // Check update permission for modifications
                {
                    mh.Modificar(txtCodigo, txtNombre, txtMedida, txtMarca, txtDescripcion);
                }
                else if (codigoHerramienta == 0) // New tool
                {
                    mh.Guardar(txtCodigo, txtNombre, txtMedida, txtMarca, txtDescripcion);
                }
                else
                {
                    MessageBox.Show("No tiene permiso para modificar herramientas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LimpiarCampos();
                CargarHerramientas();
            }
            else
            {
                MessageBox.Show("No tiene permiso para guardar herramientas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (permissions[3] && dgvHerramientas.SelectedRows.Count > 0) // Check update permission
            {
                codigoHerramienta = int.Parse(dgvHerramientas.SelectedRows[0].Cells["codigo"].Value.ToString());
                txtCodigo.Text = codigoHerramienta.ToString();
                txtNombre.Text = dgvHerramientas.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtMedida.Text = dgvHerramientas.SelectedRows[0].Cells["medida"].Value.ToString();
                txtMarca.Text = dgvHerramientas.SelectedRows[0].Cells["marca"].Value.ToString();
                txtDescripcion.Text = dgvHerramientas.SelectedRows[0].Cells["descripcion"].Value.ToString();
            }
            else
            {
                MessageBox.Show("No tiene permiso para modificar herramientas o no ha seleccionado una herramienta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (permissions[2] && dgvHerramientas.SelectedRows.Count > 0) // Check delete permission
            {
                int codigo = int.Parse(dgvHerramientas.SelectedRows[0].Cells["codigo"].Value.ToString());
                string nombre = dgvHerramientas.SelectedRows[0].Cells["nombre"].Value.ToString();
                mh.Borrar(codigo, nombre);
                CargarHerramientas();
            }
            else
            {
                MessageBox.Show("No tiene permiso para eliminar herramientas o no ha seleccionado una herramienta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LimpiarCampos()
        {
            codigoHerramienta = 0;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtMedida.Clear();
            txtMarca.Clear();
            txtDescripcion.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvHerramientas_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
    }
}
