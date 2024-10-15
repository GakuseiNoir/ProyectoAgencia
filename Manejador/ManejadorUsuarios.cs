using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorUsuarios
    {
        Funciones f = new Funciones();
        public void Guardar(TextBox nombre, TextBox apellidop, TextBox apellidom, TextBox nic, TextBox password, DateTimePicker nacimiento, TextBox rfc)
        {

            MessageBox.Show(f.guardar($"call p_InsertarUsuarios ('{nombre.Text}','{apellidop.Text}','{apellidom.Text}','{nic.Text}','{sha1(password.Text)}','{nacimiento.Value.ToString("yyyy-MM-dd ")}','{rfc.Text}')"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static string sha1(string TEXTO)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textoOriginal = ASCIIEncoding.Default.GetBytes(TEXTO);
            Byte[] hash = sha1.ComputeHash(textoOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
        public void Modificar(TextBox nombre, TextBox apellidop, TextBox apellidom, TextBox nickname, TextBox password, DateTimePicker nacimiento, TextBox rfc, int id)
        {
            string query = $@"UPDATE usuarios 
                      SET nombre = '{nombre.Text}',
                          apellidop = '{apellidop.Text}',
                          apellidom = '{apellidom.Text}',
                          nickname = '{nickname.Text}',
                          password = '{sha1(password.Text)}',
                          nacimiento = '{nacimiento.Value.ToString("yyyy-MM-dd")}',
                          rfc = '{rfc.Text}'
                      WHERE idu = {id}";

            MessageBox.Show(f.modificar(query),
                "¡Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Borrar(int idu, string dato)
        {
            DialogResult rs = MessageBox.Show($"¿Estás seguro de borrar {dato}?",
                                               "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string resultado = f.borrar($"DELETE FROM usuarios WHERE idu = {idu}"); // Realiza el borrado
                MessageBox.Show(resultado, "!Atención", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra el resultado
            }
        }
    }
}
