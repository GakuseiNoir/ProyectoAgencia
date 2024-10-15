using Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Funciones
    {
        Base b = new Base("localhost", "root", "", "agencia");
        public string guardar(string q)
        {
            return b.Comando(q);
        }
        public DataSet mostrar(string q, string tabla)
        {
            return b.Mostrar(q, tabla);
        }
        public string borrar(string q)
        {
            return b.Comando(q);
        }
        public string modificar(string q)
        {
            return b.Comando(q);
        }
        public string obtenerdato(string q, string tabla, string campo)
        {
            return b.ObtenerDato(q, tabla, campo);
        }
        public DataSet obtenerPermisos(string q, string tabla)
        {
            return b.Mostrar(q, tabla);
        }
        public string guardarPermisos(string q)
        {
            return b.Comando(q);
        }
    }
}
