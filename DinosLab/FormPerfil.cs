using System;
using System.Windows.Forms;
using DinoCore;
using MySql.Data.MySqlClient;

namespace DinosLab
{
    public partial class FormPerfil : Form
    {
        private int idJugador;

        // Guarda el jugador y carga sus datos al abrir el perfil.
        public FormPerfil(int idJugador)
        {
            InitializeComponent();
            this.idJugador = idJugador;
            CargarPerfil();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void lblMonedas_Click(object sender, EventArgs e)
        {
        }

        private void lblVictorias_Click(object sender, EventArgs e)
        {
        }

        private void lblDerrotas_Click(object sender, EventArgs e)
        {
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
        }

        // Consulta los datos del jugador y sus resultados en combate.
        private void CargarPerfil()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    // Obtiene el nombre, las monedas y el total de victorias y derrotas.
                    string consulta = @"
                        SELECT
                            j.NombreUsuario,
                            j.Monedas,
                            (SELECT COUNT(*)
                             FROM Batalla b
                             WHERE b.IdJugador = j.IdJugador
                             AND b.Resultado = 'Victoria') AS Victorias,
                            (SELECT COUNT(*)
                             FROM Batalla b
                             WHERE b.IdJugador = j.IdJugador
                             AND b.Resultado = 'Derrota') AS Derrotas
                        FROM Jugador j
                        WHERE j.IdJugador = @idJugador";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Muestra la información del jugador.
                                lblNombre.Text = "Jugador: " + reader["NombreUsuario"].ToString();
                                lblMonedas.Text = "Monedas: " + reader["Monedas"].ToString();

                                // Muestra las estadísticas de combate.
                                lblVictorias.Text = "Victorias: " + reader["Victorias"].ToString();
                                lblDerrotas.Text = "Derrotas: " + reader["Derrotas"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar perfil: " + ex.Message);
            }
        }

        // Regresa al menú principal.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}