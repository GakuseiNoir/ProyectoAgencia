using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador
{
    public class ManejadorPermisos
    {
        private Funciones f = new Funciones();

        public Dictionary<string, bool[]> ObtenerPermisos(string username)
        {
            string query = $@"SELECT f.nombre_formulario, p.lectura, p.escritura, p.eliminar, p.actualizar 
                          FROM Permisos p 
                          JOIN Formularios f ON p.id_formulario = f.id_formulario 
                          JOIN Usuarios u ON p.id_usuario = u.idu 
                          WHERE u.nickname = '{username}'";

            DataSet ds = f.mostrar(query, "permisos");
            Dictionary<string, bool[]> permisos = new Dictionary<string, bool[]>();

            foreach (DataRow row in ds.Tables["permisos"].Rows)
            {
                string formName = row["nombre_formulario"].ToString();
                bool[] formPermissions = new bool[]
                {
                Convert.ToBoolean(row["lectura"]),
                Convert.ToBoolean(row["escritura"]),
                Convert.ToBoolean(row["eliminar"]),
                Convert.ToBoolean(row["actualizar"])
                };
                permisos[formName] = formPermissions;
            }

            return permisos;
        }
    }
}
