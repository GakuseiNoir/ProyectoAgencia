using AccesoDatos;
using System;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorHerramientas
    {
        Funciones f = new Funciones();

        public void Guardar(TextBox codigo, TextBox nombre, TextBox medida, TextBox marca, TextBox descripcion)
        {
            string query = $"INSERT INTO Herramientas (codigo, nombre, medida, marca, descripcion) VALUES ({codigo.Text}, '{nombre.Text}', '{medida.Text}', '{marca.Text}', '{descripcion.Text}')";
            MessageBox.Show(f.guardar(query),
                "¡Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Modificar(TextBox codigo, TextBox nombre, TextBox medida, TextBox marca, TextBox descripcion)
        {
            string query = $@"UPDATE Herramientas 
                       SET nombre = '{nombre.Text}',
                           medida = '{medida.Text}',
                           marca = '{marca.Text}',
                           descripcion = '{descripcion.Text}'
                       WHERE codigo = {codigo.Text}";
            MessageBox.Show(f.modificar(query),
                "¡Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Borrar(int codigo, string nombre)
        {
            DialogResult rs = MessageBox.Show($"¿Estás seguro de borrar la herramienta {nombre}?",
                                               "¡Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string resultado = f.borrar($"DELETE FROM Herramientas WHERE codigo = {codigo}");
                MessageBox.Show(resultado, "¡Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}