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
    public partial class FrmProductos : Form
    {
        ManejadorProductos mp;
        private bool[] permissions;
        Funciones f;
        public static int codigoProducto = 0;
        public FrmProductos(bool[] permissions)
        {
            InitializeComponent();
            f = new Funciones();
            this.permissions = permissions;
            mp = new ManejadorProductos();
            CargarProductos();
            ApplyPermissions();
        }
        private void ApplyPermissions()
        {
            btnGuardar.Enabled = permissions[1]; // Write permission
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvProductos.SelectedRows.Count > 0;
            btnModificar.Enabled = hasSelection && permissions[3]; // Update permission
            btnEliminar.Enabled = hasSelection && permissions[2]; // Delete permission
        }

        private void CargarProductos()
        {
            string query = "SELECT codigo, nombre, marca, descripcion, create_at, update_at FROM Productos";
            DataSet ds = f.mostrar(query, "productos");
            if (dgvProductos != null && ds != null && ds.Tables["productos"] != null)
            {
                dgvProductos.DataSource = ds.Tables["productos"];
                UpdateButtonStates();
            }
            else
            {
                MessageBox.Show("Error al cargar los productos. Por favor, contacte al administrador del sistema.");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            string query = $"SELECT codigo, nombre, marca, descripcion, create_at, update_at FROM Productos WHERE nombre LIKE '%{busqueda}%' OR codigo LIKE '%{busqueda}%'";
            DataSet ds = f.mostrar(query, "productos");
            dgvProductos.DataSource = ds.Tables["productos"];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (permissions[1]) // Check write permission
            {
                if (codigoProducto > 0 && permissions[3]) // Check update permission for modifications
                {
                    mp.Modificar(txtCodigo, txtNombre, txtDescripcion, txtMarca);
                }
                else if (codigoProducto == 0) // New product
                {
                    mp.Guardar(txtCodigo, txtNombre, txtDescripcion, txtMarca);
                }
                else
                {
                    MessageBox.Show("No tiene permiso para modificar productos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No tiene permiso para guardar productos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (permissions[3] && dgvProductos.SelectedRows.Count > 0) // Check update permission
            {
                codigoProducto = int.Parse(dgvProductos.SelectedRows[0].Cells["codigo"].Value.ToString());
                txtCodigo.Text = codigoProducto.ToString();
                txtNombre.Text = dgvProductos.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dgvProductos.SelectedRows[0].Cells["descripcion"].Value.ToString();
                txtMarca.Text = dgvProductos.SelectedRows[0].Cells["marca"].Value.ToString();
            }
            else
            {
                MessageBox.Show("No tiene permiso para modificar productos o no ha seleccionado un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (permissions[2] && dgvProductos.SelectedRows.Count > 0) // Check delete permission
            {
                int codigo = int.Parse(dgvProductos.SelectedRows[0].Cells["codigo"].Value.ToString());
                string nombre = dgvProductos.SelectedRows[0].Cells["nombre"].Value.ToString();
                mp.Borrar(codigo, nombre);
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No tiene permiso para eliminar productos o no ha seleccionado un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
        private void LimpiarCampos()
        {
            codigoProducto = 0;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
    }
}
