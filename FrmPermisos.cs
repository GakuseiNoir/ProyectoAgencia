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
    public partial class FrmPermisos : Form
    {
        ManejadorPermisos mp;
        Funciones f;
        private Dictionary<string, TabPage> formTabs;
        public FrmPermisos()
        {
            InitializeComponent();
            mp = new ManejadorPermisos();
            f = new Funciones();
            formTabs = new Dictionary<string, TabPage>();
            CargarFormularios();
            CargarUsuarios();
        }
        private void CargarFormularios()
        {
            string query = "SELECT nombre_formulario FROM Formularios";
            DataSet ds = f.mostrar(query, "formularios");

            foreach (DataRow row in ds.Tables["formularios"].Rows)
            {
                string formName = row["nombre_formulario"].ToString();
                CrearTabFormulario(formName);
            }
        }
        private void CrearTabFormulario(string formName)
        {
            TabPage tabPage = new TabPage(formName);

            ComboBox cboUsuario = new ComboBox();
            cboUsuario.Dock = DockStyle.Top;
            cboUsuario.DropDownStyle = ComboBoxStyle.DropDownList;

            CheckBox chkLectura = new CheckBox() { Text = "Lectura", AutoSize = true };
            CheckBox chkEscritura = new CheckBox() { Text = "Escritura", AutoSize = true };
            CheckBox chkEliminacion = new CheckBox() { Text = "Eliminación", AutoSize = true };
            CheckBox chkActualizacion = new CheckBox() { Text = "Actualización", AutoSize = true };

            Button btnGuardar = new Button() { Text = "Guardar", AutoSize = true };
            btnGuardar.Click += (sender, e) => GuardarPermisos(formName);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Controls.AddRange(new Control[] { chkLectura, chkEscritura, chkEliminacion, chkActualizacion, btnGuardar });

            tabPage.Controls.Add(panel);
            tabPage.Controls.Add(cboUsuario);

            tabControl1.TabPages.Add(tabPage);
            formTabs[formName] = tabPage;
        }

        private void CargarUsuarios()
        {
            string query = "SELECT nickname FROM Usuarios";
            DataSet ds = f.mostrar(query, "usuarios");

            foreach (TabPage tab in tabControl1.TabPages)
            {
                ComboBox cboUsuario = tab.Controls.OfType<ComboBox>().FirstOrDefault();
                if (cboUsuario != null)
                {
                    cboUsuario.DataSource = ds.Tables["usuarios"];
                    cboUsuario.DisplayMember = "nickname";
                    cboUsuario.ValueMember = "nickname";
                }
            }
        }

        private void GuardarPermisos(string formName)
        {
            TabPage tab = formTabs[formName];
            ComboBox cboUsuario = tab.Controls.OfType<ComboBox>().FirstOrDefault();
            FlowLayoutPanel panel = tab.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

            if (cboUsuario == null || panel == null) return;

            string usuario = cboUsuario.SelectedValue.ToString();
            bool lectura = panel.Controls.OfType<CheckBox>().First(c => c.Text == "Lectura").Checked;
            bool escritura = panel.Controls.OfType<CheckBox>().First(c => c.Text == "Escritura").Checked;
            bool eliminar = panel.Controls.OfType<CheckBox>().First(c => c.Text == "Eliminación").Checked;
            bool actualizar = panel.Controls.OfType<CheckBox>().First(c => c.Text == "Actualización").Checked;

            string query = $@"INSERT INTO Permisos (id_usuario, id_formulario, lectura, escritura, eliminar, actualizar)
                          VALUES ((SELECT idu FROM Usuarios WHERE nickname = '{usuario}'),
                                  (SELECT id_formulario FROM Formularios WHERE nombre_formulario = '{formName}'),
                                  {(lectura ? 1 : 0)}, {(escritura ? 1 : 0)}, {(eliminar ? 1 : 0)}, {(actualizar ? 1 : 0)})
                          ON DUPLICATE KEY UPDATE
                          lectura = {(lectura ? 1 : 0)}, escritura = {(escritura ? 1 : 0)}, 
                          eliminar = {(eliminar ? 1 : 0)}, actualizar = {(actualizar ? 1 : 0)}";

            string resultado = f.guardar(query);
            MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*string usuario = cboUsuario.SelectedValue.ToString();
            string formulario = cmbFormularios.SelectedValue.ToString();
            bool lectura = chkLectura.Checked;
            bool escritura = chkEscritura.Checked;
            bool eliminar = chkEliminacion.Checked;
            bool actualizar = chkActualizacion.Checked;

            string query = $@"INSERT INTO Permisos (id_usuario, id_formulario, lectura, escritura, eliminar, actualizar)
                          VALUES ((SELECT idu FROM Usuarios WHERE nickname = '{usuario}'),
                                  (SELECT id_formulario FROM Formularios WHERE nombre_formulario = '{formulario}'),
                                  {(lectura ? 1 : 0)}, {(escritura ? 1 : 0)}, {(eliminar ? 1 : 0)}, {(actualizar ? 1 : 0)})
                          ON DUPLICATE KEY UPDATE
                          lectura = {(lectura ? 1 : 0)}, escritura = {(escritura ? 1 : 0)}, 
                          eliminar = {(eliminar ? 1 : 0)}, actualizar = {(actualizar ? 1 : 0)}";

            string resultado = f.guardar(query);
            MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);*/

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
