using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DinoCore
{
    public class Conexion
    {
        private string cadenaConexion =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=dinocore;" +
            "Uid=root;" +
            "Pwd=conalep990;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }

        public bool ProbarConexion()
        {
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
                return false;
            }
        }
    }
}
