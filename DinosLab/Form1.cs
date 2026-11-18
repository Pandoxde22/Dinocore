using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DinoCore;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace DinosLab
{
    public partial class Form1 : Form
    {
        // Inicializa el formulario y comprueba la conexión con la base de datos.
        public Form1()
        {
            InitializeComponent();
            ProbarConexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Verifica que la aplicación pueda conectarse correctamente a MySQL.
        private void ProbarConexion()
        {
            Conexion conexion = new Conexion();

            if (conexion.ProbarConexion())
            {
                MessageBox.Show("¡Conexión exitosa con DinoCore!");
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblContrasena_Click(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNoCuenta_Click(object sender, EventArgs e)
        {

        }

        // Valida los datos ingresados, comprueba las credenciales y permite acceder al juego.
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            // Evita intentar iniciar sesión si faltan datos.
            if (usuario == "" || contrasena == "")
            {
                MessageBox.Show("Ingresa tu usuario y contraseña.");
                return;
            }

            Conexion conexion = new Conexion();

            try
            {
                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    int idJugador;
                    string contrasenaGuardada;

                    // Busca la cuenta correspondiente al nombre de usuario.
                    string consulta = @"
                SELECT IdJugador, Contrasena
                FROM Jugador
                WHERE NombreUsuario = @usuario
                LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("El usuario no existe.");
                                return;
                            }

                            idJugador = Convert.ToInt32(reader["IdJugador"]);
                            contrasenaGuardada = reader["Contrasena"].ToString();
                        }
                    }

                    // Comprueba que la contraseña ingresada coincida con la almacenada.
                    if (!VerificarContrasena(contrasena, contrasenaGuardada))
                    {
                        MessageBox.Show("La contraseña es incorrecta.");
                        return;
                    }

                    // Comprueba si el jugador ya tiene dinosaurios registrados.
                    string consultaDino = @"
                SELECT COUNT(*)
                FROM Dinosaurio
                WHERE IdJugador = @idJugador";

                    int cantidadDinosaurios;

                    using (MySqlCommand cmd = new MySqlCommand(consultaDino, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);
                        cantidadDinosaurios = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Dirige al jugador al menú principal o a la selección inicial de dinosaurio.
                    MessageBox.Show("¡Bienvenido a DinoCore!");

                    this.Hide();

                    if (cantidadDinosaurios > 0)
                    {
                        FormMenuPrincipal menu = new FormMenuPrincipal(idJugador);
                        menu.ShowDialog();
                    }
                    else
                    {
                        FormSeleccionDinosaurio seleccion =
                            new FormSeleccionDinosaurio(idJugador);

                        seleccion.ShowDialog();
                    }

                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
        }

        // Verifica la contraseña utilizando el algoritmo PBKDF2 y los datos almacenados.
        private bool VerificarContrasena(string contrasena, string guardada)
        {
            try
            {
                string[] partes = guardada.Split('$');

                if (partes.Length != 4 || partes[0] != "PBKDF2")
                    return false;

                int iteraciones = int.Parse(partes[1]);

                byte[] salt = Convert.FromBase64String(partes[2]);
                byte[] hashOriginal = Convert.FromBase64String(partes[3]);

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    contrasena, salt, iteraciones, HashAlgorithmName.SHA256))
                {
                    byte[] hashNuevo = pbkdf2.GetBytes(hashOriginal.Length);

                    return hashNuevo.SequenceEqual(hashOriginal);
                }
            }
            catch
            {
                return false;
            }
        }

        // Abre el formulario donde los nuevos jugadores pueden crear una cuenta.
        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Form2 registro = new Form2();
            registro.ShowDialog();
        }
    }
}