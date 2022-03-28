using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
using System.Data.SqlClient;
using System.Configuration;

namespace Dominio.Entidades
{
    public class ConexionBD
    {

        //2. Metodo publico que devolvera la coneccion
        public static SqlConnection ConectarBD()
        {
            //3. Creo el objeto SQLCONETION(con la variable CN) lo instancio y le agrego la cadena "conexionCadena" desde el webconfig  
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["tecflex"].ConnectionString);
            return cn;
        }
        //4. terminado esto paso a crear la estructura de datos del servidor
        //en la cartpeta ENTITY , serian 03 clases : ...



        //......una vez con las tres estructuras o clases o modelos o radiografia pasaremos




    }
}
