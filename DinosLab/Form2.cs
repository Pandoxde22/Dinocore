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
    public partial class Form2 : Form
    {
        // Inicializa la ventana de registro.
        public Form2()
        {
            InitializeComponent();
        }

        // Eventos de los controles del formulario.
        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
        }

        private void lblCorreo_Click(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void lblContrasena_Click(object sender, EventArgs e)
        {
        }

        private void lblNombreVisible_Click(object sender, EventArgs e)
        {
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNombreVisible_TextChanged(object sender, EventArgs e)
        {
        }

        // Registra una cuenta nueva y prepara los datos iniciales del jugador.
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtiene los datos escritos en los campos de registro.
            string usuario = txtUsuario.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasena.Text;
            string nombreVisible = txtNombreVisible.Text.Trim();

            // Comprueba que ningún campo esté vacío.
            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contrasena) ||
                string.IsNullOrWhiteSpace(nombreVisible))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            Conexion acceso = new Conexion();

            using (MySqlConnection conexion = acceso.ObtenerConexion())
            {
                conexion.Open();

                // Inicia una transacción para guardar todos los datos juntos.
                MySqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    // Comprueba que el nombre de usuario y el correo no estén registrados.
                    string consulta = @"SELECT COUNT(*) FROM Jugador
                            WHERE NombreUsuario = @usuario
                            OR Correo = @correo";

                    using (MySqlCommand comando = new MySqlCommand(
                        consulta, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@correo", correo);

                        int existe = Convert.ToInt32(comando.ExecuteScalar());

                        if (existe > 0)
                        {
                            transaccion.Rollback();
                            MessageBox.Show("El usuario o correo ya está registrado.");
                            return;
                        }
                    }

                    // Protege la contraseña antes de guardarla en la base de datos.
                    string contrasenaProtegida =
                        EncriptarContrasena(contrasena);

                    // Registra al jugador con sus datos y 500 monedas iniciales.
                    string insertarJugador = @"
            INSERT INTO Jugador
            (NombreUsuario, Correo, Contrasena, NombreVisible, Monedas)
            VALUES
            (@usuario, @correo, @contrasena, @nombre, 500)";

                    using (MySqlCommand comando = new MySqlCommand(
                        insertarJugador, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@correo", correo);
                        comando.Parameters.AddWithValue("@contrasena", contrasenaProtegida);
                        comando.Parameters.AddWithValue("@nombre", nombreVisible);

                        comando.ExecuteNonQuery();
                    }

                    // Recupera el identificador del jugador recién registrado.
                    int idJugador;

                    using (MySqlCommand comando = new MySqlCommand(
                        "SELECT LAST_INSERT_ID()", conexion, transaccion))
                    {
                        idJugador = Convert.ToInt32(comando.ExecuteScalar());
                    }

                    // Crea un inventario vacío para el nuevo jugador.
                    string insertarInventario = @"
            INSERT INTO Inventario (IdJugador)
            VALUES (@idJugador)";

                    using (MySqlCommand comando = new MySqlCommand(
                        insertarInventario, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@idJugador", idJugador);
                        comando.ExecuteNonQuery();
                    }

                    // Obtiene el identificador del inventario creado.
                    int idInventario;

                    using (MySqlCommand comando = new MySqlCommand(
                        "SELECT LAST_INSERT_ID()", conexion, transaccion))
                    {
                        idInventario = Convert.ToInt32(comando.ExecuteScalar());
                    }

                    // Agrega los alimentos disponibles al inventario con cantidad inicial de cero.
                    string insertarAlimentos = @"
            INSERT INTO DetalleInventario
            (IdInventario, IdAlimento, Cantidad)
            SELECT @idInventario, IdAlimento, 0
            FROM Alimento";

                    using (MySqlCommand comando = new MySqlCommand(
                        insertarAlimentos, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@idInventario", idInventario);
                        comando.ExecuteNonQuery();
                    }

                    // Asigna todas las misiones activas al nuevo jugador.
                    string insertarMisiones = @"
            INSERT INTO JugadorMision
            (IdJugador, IdMision, ProgresoActual,
             Completada, RecompensaReclamada)
            SELECT @idJugador, IdMision, 0, 0, 0
            FROM Mision
            WHERE Activa = 1";

                    using (MySqlCommand comando = new MySqlCommand(
                        insertarMisiones, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@idJugador", idJugador);
                        comando.ExecuteNonQuery();
                    }

                    // Confirma y guarda todos los cambios realizados en la transacción.
                    transaccion.Commit();

                    MessageBox.Show(
                        "¡Cuenta creada correctamente!\n" +
                        "Recibiste 500 monedas iniciales.");

                    // Abre la selección inicial de dinosaurios.
                    this.Hide();

                    FormSeleccionDinosaurio seleccion =
                        new FormSeleccionDinosaurio(idJugador);

                    seleccion.ShowDialog();

                    this.Close();
                }
                catch (Exception ex)
                {
                    // Revierte los cambios si ocurre algún error durante el registro.
                    transaccion.Rollback();

                    MessageBox.Show("Error al registrar: " + ex.Message);
                }
            }
        }

        // Cierra el formulario y regresa a la ventana anterior.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Genera una contraseña protegida mediante PBKDF2, una sal aleatoria y SHA256.
        private string EncriptarContrasena(string contrasena)
        {
            // Genera una sal aleatoria para que cada contraseña tenga un valor diferente.
            byte[] salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Calcula el hash de la contraseña utilizando PBKDF2.
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                contrasena, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                // Devuelve el algoritmo, las iteraciones, la sal y el hash codificados.
                return "PBKDF2$100000$" +
                    Convert.ToBase64String(salt) + "$" +
                    Convert.ToBase64String(hash);
            }
        }
    }
}