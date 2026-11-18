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

namespace DinosLab
{
    public partial class FormMisiones : Form
    {
        private int idJugador;
        private int idMisionSeleccionada;

        public FormMisiones(int idJugador)
        {
            InitializeComponent();
            this.idJugador = idJugador;

            CargarMisiones();
        }

        private void CargarMisiones()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string asignarMisiones = @"
    INSERT INTO JugadorMision
    (IdJugador, IdMision, ProgresoActual, Completada,
     RecompensaReclamada, FechaInicio)
    SELECT @idJugador, m.IdMision, 0, 0, 0, NOW()
    FROM Mision m
    WHERE m.Activa = 1
    AND NOT EXISTS (
        SELECT 1
        FROM JugadorMision jm
        WHERE jm.IdJugador = @idJugador
        AND jm.IdMision = m.IdMision
    )";

                    using (MySqlCommand cmdAsignar =
                        new MySqlCommand(asignarMisiones, conn))
                    {
                        cmdAsignar.Parameters.AddWithValue("@idJugador", idJugador);
                        cmdAsignar.ExecuteNonQuery();
                    }

                    string consulta = @"
                        SELECT m.IdMision, m.Nombre
                        FROM Mision m
                        WHERE m.Activa = 1
                        ORDER BY m.IdMision";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        listMisiones.Items.Clear();

                        while (reader.Read())
                        {
                            listMisiones.Items.Add(
                                new KeyValuePair<int, string>(
                                    Convert.ToInt32(reader["IdMision"]),
                                    reader["Nombre"].ToString()
                                )
                            );
                        }

                        listMisiones.DisplayMember = "Value";
                    }
                }

                if (listMisiones.Items.Count > 0)
                {
                    listMisiones.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No hay misiones disponibles.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar misiones: " + ex.Message);
            }
        }

        private void CargarDetallesMision()
        {
            if (listMisiones.SelectedItem == null)
                return;

            try
            {
                KeyValuePair<int, string> seleccion =
                    (KeyValuePair<int, string>)listMisiones.SelectedItem;

                idMisionSeleccionada = seleccion.Key;

                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT m.Nombre, m.Descripcion, m.Objetivo,
                               m.CantidadObjetivo, m.RecompensaMonedas,
                               m.RecompensaExperiencia,
                               jm.ProgresoActual, jm.Completada,
                               jm.RecompensaReclamada
                        FROM Mision m
                        LEFT JOIN JugadorMision jm
                            ON m.IdMision = jm.IdMision
                            AND jm.IdJugador = @idJugador
                        WHERE m.IdMision = @idMision";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);
                        cmd.Parameters.AddWithValue("@idMision", idMisionSeleccionada);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblNombreMision.Text = reader["Nombre"].ToString();
                                lblDescripcion.Text = reader["Descripcion"].ToString();
                                lblObjetivo.Text = "Objetivo: " + reader["Objetivo"].ToString();

                                int progreso = reader["ProgresoActual"] == DBNull.Value
                                    ? 0 : Convert.ToInt32(reader["ProgresoActual"]);

                                int cantidad = Convert.ToInt32(reader["CantidadObjetivo"]);

                                lblProgreso.Text = "Progreso: " + progreso + " / " + cantidad;

                                lblRecompensa.Text =
                                    "Recompensa: " + reader["RecompensaMonedas"] +
                                    " monedas | " + reader["RecompensaExperiencia"] +
                                    " EXP";

                                btnReclamar.Enabled =
                                    reader["Completada"] != DBNull.Value &&
                                    Convert.ToBoolean(reader["Completada"]) &&
                                    !Convert.ToBoolean(reader["RecompensaReclamada"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles: " + ex.Message);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void lblSubtitulo_Click(object sender, EventArgs e)
        {
        }

        private void lblListaMisiones_Click(object sender, EventArgs e)
        {
        }

        private void panelMisiones_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listMisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDetallesMision();
        }

        private void lblTituloDetalle_Click(object sender, EventArgs e)
        {
        }

        private void panelDetalles_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {
        }

        private void lblProgreso_Click(object sender, EventArgs e)
        {
        }

        private void lblRecompensa_Click(object sender, EventArgs e)
        {
        }

        private void btnReclamar_Click(object sender, EventArgs e)
        {
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblObjetivo_Click(object sender, EventArgs e)
        {

        }

        private void lblNombreMision_Click(object sender, EventArgs e)
        {

        }

        private void btnReclamar_Click_1(object sender, EventArgs e)
        {
          
            if (idMisionSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una misión.");
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    using (MySqlTransaction transaccion = conn.BeginTransaction())
                    {
                        try
                        {
                            string consulta = @"
                        SELECT m.RecompensaMonedas,
                               m.RecompensaExperiencia
                        FROM JugadorMision jm
                        INNER JOIN Mision m
                            ON jm.IdMision = m.IdMision
                        WHERE jm.IdJugador = @idJugador
                        AND jm.IdMision = @idMision
                        AND jm.Completada = 1
                        AND jm.RecompensaReclamada = 0
                        FOR UPDATE";

                            int monedas;
                            int experiencia;

                            using (MySqlCommand cmd = new MySqlCommand(
                                consulta, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                                cmd.Parameters.AddWithValue("@idMision", idMisionSeleccionada);

                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        MessageBox.Show("La misión no está completada o ya reclamaste su recompensa.");
                                        transaccion.Rollback();
                                        return;
                                    }

                                    monedas = Convert.ToInt32(reader["RecompensaMonedas"]);
                                    experiencia = Convert.ToInt32(reader["RecompensaExperiencia"]);
                                }
                            }

                            string actualizarJugador = @"
                        UPDATE Jugador
                        SET Monedas = Monedas + @monedas
                        WHERE IdJugador = @idJugador";

                            using (MySqlCommand cmd = new MySqlCommand(
                                actualizarJugador, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@monedas", monedas);
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                                cmd.ExecuteNonQuery();
                            }

                            string actualizarDinosaurio = @"
                        UPDATE Dinosaurio
                        SET Experiencia = Experiencia + @experiencia
                        WHERE IdJugador = @idJugador
                        AND Activo = 1";

                            using (MySqlCommand cmd = new MySqlCommand(
                                actualizarDinosaurio, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@experiencia", experiencia);
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                                cmd.ExecuteNonQuery();
                            }

                            string marcarReclamada = @"
                        UPDATE JugadorMision
                        SET RecompensaReclamada = 1
                        WHERE IdJugador = @idJugador
                        AND IdMision = @idMision
                        AND Completada = 1
                        AND RecompensaReclamada = 0";

                            using (MySqlCommand cmd = new MySqlCommand(
                                marcarReclamada, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                                cmd.Parameters.AddWithValue("@idMision", idMisionSeleccionada);
                                cmd.ExecuteNonQuery();
                            }

                            transaccion.Commit();

                            MessageBox.Show(
                                "¡Recompensa recibida!\n\n" +
                                "Monedas: " + monedas +
                                "\nExperiencia: " + experiencia
                            );

                            CargarDetallesMision();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reclamar recompensa: " + ex.Message);
            }
        }
        

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}