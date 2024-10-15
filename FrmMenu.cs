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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProyectoAgencia
{
    public partial class FrmMenu : Form
    {
        private Dictionary<string, bool[]> userPermissions;
        ManejadorPermisos mp;
        public FrmMenu(string username)
        {
            InitializeComponent();
            LoadUserPermissions(username);
            ApplyPermissions();
        }
        private void LoadUserPermissions(string username)
        {
            ManejadorPermisos mp = new ManejadorPermisos();
            userPermissions = mp.ObtenerPermisos(username);
        }

        private void ApplyPermissions()
        {
            ApplyFormPermission("FrmUsuarios", tsFrmUsuarios);
            ApplyFormPermission("FrmProductos", tsFrmProductos);
            ApplyFormPermission("FrmHerramientas", tsFrmHerramientas);
        }

        private void ApplyFormPermission(string formName, ToolStripItem menuItem)
        {
            if (userPermissions.ContainsKey(formName))
            {
                bool[] permissions = userPermissions[formName];
                menuItem.Enabled = permissions[0]; // Read permission
            }
            else
            {
                menuItem.Enabled = false;
            }
        }

        private void tsFrmUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios(userPermissions["FrmUsuarios"]);
            frm.ShowDialog();
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsFrmProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frmp = new FrmProductos(userPermissions["FrmProductos"]);
            frmp.ShowDialog();
        }
    }
}
