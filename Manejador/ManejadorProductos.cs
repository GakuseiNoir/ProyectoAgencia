using AccesoDatos;
using System;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorProductos
    {
        Funciones f = new Funciones();

        public void Guardar(TextBox codigo, TextBox nombre, TextBox descripcion, TextBox marca)
        {
            string query = $"INSERT INTO Productos (codigo, nombre, descripcion, marca) VALUES ({codigo.Text}, '{nombre.Text}', '{descripcion.Text}', '{marca.Text}')";
            MessageBox.Show(f.guardar(query),
                "¡Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Modificar(TextBox codigo, TextBox nombre, TextBox descripcion, TextBox marca)
        {
            string query = $@"UPDATE Productos 
                       SET nombre = '{nombre.Text}',
                           descripcion = '{descripcion.Text}',
                           marca = '{marca.Text}'
                       WHERE codigo = {codigo.Text}";
            MessageBox.Show(f.modificar(query),
                "¡Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Borrar(int codigo, string nombre)
        {
            DialogResult rs = MessageBox.Show($"¿Estás seguro de borrar el producto {nombre}?",
                                               "¡Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string resultado = f.borrar($"DELETE FROM Productos WHERE codigo = {codigo}");
                MessageBox.Show(resultado, "¡Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}