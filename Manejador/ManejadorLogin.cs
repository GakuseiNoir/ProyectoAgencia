using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorLogin
    {
        Funciones f = new Funciones();


        public string[] validar(string nickname, string password)
        {
            string[] resultado = new string[2];
            DataSet r = f.mostrar($"call p_Validar('{nickname}','{sha1(password)}')", "usuarios");
            DataTable dt = r.Tables[0];
            resultado[0] = dt.Rows[0]["rs"].ToString();
            //  resultado[1] = dt.Rows[0]["nivel"].ToString();
            return resultado;
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
    }
}
