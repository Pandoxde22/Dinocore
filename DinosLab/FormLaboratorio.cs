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
using System.IO;

namespace DinosLab
{
    public partial class FormLaboratorio : Form
    {
        private int idJugador;
        private int idDinosaurio;

        // Inicia el laboratorio y carga los datos del dinosaurio activo.
        public FormLaboratorio(int idJugador)
        {
            InitializeComponent();

            this.idJugador = idJugador;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            btnAlimentarCarne.Click += btnAlimentarCarne_Click;
            btnAlimentarVegetales.Click += btnAlimentarVegetales_Click;

            CargarDinosaurio();
        }

        // Carga la información del dinosaurio que está activo.
        private void CargarDinosaurio()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT IdDinosaurio, Nombre, Especie, Nivel,
                               Vida, Energia, Experiencia
                        FROM Dinosaurio
                        WHERE IdJugador = @idJugador
                        AND Activo = 1
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idDinosaurio =
                                    Convert.ToInt32(reader["IdDinosaurio"]);

                                lblNombreDino.Text =
                                    "Dinosaurio: " + reader["Nombre"];

                                lblNivel.Text =
                                    "Nivel: " + reader["Nivel"];

                                int vida = Convert.ToInt32(reader["Vida"]);
                                int energia = Convert.ToInt32(reader["Energia"]);
                                int experiencia =
                                    Convert.ToInt32(reader["Experiencia"]);

                                lblVida.Text = "Vida: " + vida;
                                lblEnergia.Text = "Energía: " + energia;

                                lblExperiencia.Text =
                                    "Experiencia: " + experiencia + " / 100";

                                progressVida.Value =
                                    Math.Max(0, Math.Min(100, vida));

                                progressEnergia.Value =
                                    Math.Max(0, Math.Min(100, energia));

                                // Muestra la imagen de la especie del dinosaurio activo.
                                CargarImagenDinosaurio(reader["Especie"].ToString());
                            }
                            else
                            {
                                idDinosaurio = 0;

                                lblNombreDino.Text = "Sin dinosaurio activo";
                                lblNivel.Text = "Nivel: 0";
                                lblVida.Text = "Vida: 0";
                                lblEnergia.Text = "Energía: 0";
                                lblExperiencia.Text = "Experiencia: 0 / 100";

                                progressVida.Value = 0;
                                progressEnergia.Value = 0;

                                if (pictureBox1.Image != null)
                                {
                                    pictureBox1.Image.Dispose();
                                    pictureBox1.Image = null;
                                }

                                MessageBox.Show(
                                    "No tienes un dinosaurio activo.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar dinosaurio: " + ex.Message);
            }
        }

        // Busca y carga la imagen correspondiente a la especie.
        private void CargarImagenDinosaurio(string especie)
        {
            string ruta = "";

            switch (especie.Trim().ToLower())
            {
                case "rex":
                case "tyrannosaurus rex":
                case "tyrannosaurusrex":
                    ruta = @"C:\Users\angel\Downloads\rex.jpg";
                    break;

                case "spinosaurus":
                case "spino":
                    ruta = @"C:\Users\angel\Downloads\spino.jpg";
                    break;

                case "velociraptor":
                    ruta = @"C:\Users\angel\Downloads\velociraptor.jpg";
                    break;

                case "stegosaurus":
                case "stego":
                    ruta = @"C:\Users\angel\Downloads\stego.jpg";
                    break;

                case "triceratops":
                case "trice":
                    ruta = @"C:\Users\angel\Downloads\trice.jpg";
                    break;

                case "brachiosaurus":
                case "brachiosaurio":
                    ruta = @"C:\Users\angel\Downloads\bronto.jpg";
                    break;

                case "oviraptor":
                    ruta = @"C:\Users\angel\Downloads\oviraptor.jpg";
                    break;

                case "ornithomimus":
                case "maewing":
                    ruta = @"C:\Users\angel\Downloads\maewing.jpg";
                    break;

                case "gallimimus":
                case "galliminus":
                    ruta = @"C:\Users\angel\Downloads\gallinimus.png";
                    break;
            }

            // Carga la imagen si el archivo existe.
            if (File.Exists(ruta))
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                using (FileStream archivo = new FileStream(
                    ruta, FileMode.Open, FileAccess.Read))
                {
                    using (Image imagen = Image.FromStream(archivo))
                    {
                        pictureBox1.Image = new Bitmap(imagen);
                    }
                }
            }
            else
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
        }

        // Alimenta al dinosaurio y recupera vida o energía según el alimento.
        private void AlimentarDinosaurio(int idAlimento)
        {
            if (idDinosaurio == 0)
            {
                MessageBox.Show("No tienes un dinosaurio activo.");
                return;
            }

            int recuperacion = idAlimento == 1 ? 30 : 25;

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    using (MySqlTransaction transaccion =
                        conn.BeginTransaction())
                    {
                        try
                        {
                            // Busca el inventario del jugador.
                            string consultaInventario = @"
                                SELECT IdInventario
                                FROM Inventario
                                WHERE IdJugador = @idJugador";

                            MySqlCommand cmdInventario =
                                new MySqlCommand(
                                    consultaInventario, conn, transaccion);

                            cmdInventario.Parameters.AddWithValue(
                                "@idJugador", idJugador);

                            object resultadoInventario =
                                cmdInventario.ExecuteScalar();

                            if (resultadoInventario == null)
                            {
                                transaccion.Rollback();
                                MessageBox.Show(
                                    "No tienes alimentos en tu inventario.");
                                return;
                            }

                            int idInventario =
                                Convert.ToInt32(resultadoInventario);

                            // Comprueba que el jugador tenga suficiente alimento.
                            string consultaCantidad = @"
                                SELECT Cantidad
                                FROM DetalleInventario
                                WHERE IdInventario = @idInventario
                                AND IdAlimento = @idAlimento
                                FOR UPDATE";

                            MySqlCommand cmdCantidad =
                                new MySqlCommand(
                                    consultaCantidad, conn, transaccion);

                            cmdCantidad.Parameters.AddWithValue(
                                "@idInventario", idInventario);

                            cmdCantidad.Parameters.AddWithValue(
                                "@idAlimento", idAlimento);

                            object resultadoCantidad =
                                cmdCantidad.ExecuteScalar();

                            if (resultadoCantidad == null ||
                                Convert.ToInt32(resultadoCantidad) <= 0)
                            {
                                transaccion.Rollback();
                                MessageBox.Show(
                                    "No tienes suficiente alimento.");
                                return;
                            }

                            // Consulta la vida y energía actuales del dinosaurio.
                            string consultaDino = @"
                                SELECT Vida, Energia
                                FROM Dinosaurio
                                WHERE IdDinosaurio = @idDinosaurio
                                AND IdJugador = @idJugador
                                FOR UPDATE";

                            MySqlCommand cmdDino =
                                new MySqlCommand(
                                    consultaDino, conn, transaccion);

                            cmdDino.Parameters.AddWithValue(
                                "@idDinosaurio", idDinosaurio);

                            cmdDino.Parameters.AddWithValue(
                                "@idJugador", idJugador);

                            int vida;
                            int energia;

                            using (MySqlDataReader reader =
                                cmdDino.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    transaccion.Rollback();
                                    MessageBox.Show(
                                        "No se encontró el dinosaurio.");
                                    return;
                                }

                                vida = Convert.ToInt32(reader["Vida"]);
                                energia = Convert.ToInt32(reader["Energia"]);
                            }

                            // Evita consumir alimento si ya tiene el indicador completo.
                            if (idAlimento == 1 && vida >= 100)
                            {
                                transaccion.Rollback();
                                MessageBox.Show(
                                    "¡Tu dinosaurio ya tiene la vida completa!");
                                return;
                            }

                            if (idAlimento == 2 && energia >= 100)
                            {
                                transaccion.Rollback();
                                MessageBox.Show(
                                    "¡Tu dinosaurio ya tiene la energía completa!");
                                return;
                            }

                            // Recupera vida con carne o energía con vegetales.
                            string consultaRecuperacion;

                            if (idAlimento == 1)
                            {
                                consultaRecuperacion = @"
                                    UPDATE Dinosaurio
                                    SET Vida = LEAST(100, Vida + @recuperacion)
                                    WHERE IdDinosaurio = @idDinosaurio
                                    AND IdJugador = @idJugador";
                            }
                            else
                            {
                                consultaRecuperacion = @"
                                    UPDATE Dinosaurio
                                    SET Energia = LEAST(100, Energia + @recuperacion)
                                    WHERE IdDinosaurio = @idDinosaurio
                                    AND IdJugador = @idJugador";
                            }

                            MySqlCommand cmdRecuperacion =
                                new MySqlCommand(
                                    consultaRecuperacion, conn, transaccion);

                            cmdRecuperacion.Parameters.AddWithValue(
                                "@recuperacion", recuperacion);

                            cmdRecuperacion.Parameters.AddWithValue(
                                "@idDinosaurio", idDinosaurio);

                            cmdRecuperacion.Parameters.AddWithValue(
                                "@idJugador", idJugador);

                            cmdRecuperacion.ExecuteNonQuery();

                            // Descuenta una unidad del alimento utilizado.
                            string consultaConsumo = @"
                                UPDATE DetalleInventario
                                SET Cantidad = Cantidad - 1
                                WHERE IdInventario = @idInventario
                                AND IdAlimento = @idAlimento
                                AND Cantidad > 0";

                            MySqlCommand cmdConsumo =
                                new MySqlCommand(
                                    consultaConsumo, conn, transaccion);

                            cmdConsumo.Parameters.AddWithValue(
                                "@idInventario", idInventario);

                            cmdConsumo.Parameters.AddWithValue(
                                "@idAlimento", idAlimento);

                            cmdConsumo.ExecuteNonQuery();

                            // Suma el progreso de las misiones de alimentación.
                            ActualizarProgresoAlimentacion(
                                conn, transaccion);

                            transaccion.Commit();

                            if (idAlimento == 1)
                            {
                                MessageBox.Show(
                                    "¡Carne consumida! Tu dinosaurio recuperó 30 puntos de vida.");
                            }
                            else
                            {
                                MessageBox.Show(
                                    "¡Vegetales consumidos! Tu dinosaurio recuperó 25 puntos de energía.");
                            }

                            CargarDinosaurio();
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
                MessageBox.Show(
                    "Error al alimentar: " + ex.Message);
            }
        }

        // Actualiza el progreso de las misiones relacionadas con alimentar dinosaurios.
        private void ActualizarProgresoAlimentacion(
            MySqlConnection conn,
            MySqlTransaction transaccion)
        {
            string consulta = @"
                UPDATE JugadorMision jm
                INNER JOIN Mision m
                    ON jm.IdMision = m.IdMision
                SET
                    jm.Completada =
                        CASE
                            WHEN jm.ProgresoActual + 1 >= m.CantidadObjetivo
                            THEN 1 ELSE 0
                        END,
                    jm.FechaFinalizacion =
                        CASE
                            WHEN jm.ProgresoActual + 1 >= m.CantidadObjetivo
                            THEN NOW()
                            ELSE jm.FechaFinalizacion
                        END,
                    jm.ProgresoActual =
                        LEAST(m.CantidadObjetivo, jm.ProgresoActual + 1)
                WHERE jm.IdJugador = @idJugador
                AND jm.Completada = 0
                AND m.Activa = 1
                AND m.Objetivo = 'Alimentar'";

            using (MySqlCommand cmd =
                new MySqlCommand(consulta, conn, transaccion))
            {
                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                cmd.ExecuteNonQuery();
            }
        }

        // Entrena al dinosaurio y le permite ganar experiencia y niveles.
        private void EntrenarDinosaurio()
        {
            if (idDinosaurio == 0)
            {
                MessageBox.Show("No tienes un dinosaurio activo.");
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    using (MySqlTransaction transaccion =
                        conn.BeginTransaction())
                    {
                        try
                        {
                            // Consulta el nivel y la experiencia actuales.
                            string consultaDino = @"
                                SELECT Nivel, Experiencia
                                FROM Dinosaurio
                                WHERE IdDinosaurio = @idDinosaurio
                                AND IdJugador = @idJugador
                                FOR UPDATE";

                            int nivel;
                            int experiencia;

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    consultaDino, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@idDinosaurio", idDinosaurio);

                                cmd.Parameters.AddWithValue(
                                    "@idJugador", idJugador);

                                using (MySqlDataReader reader =
                                    cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        transaccion.Rollback();
                                        MessageBox.Show(
                                            "No se encontró el dinosaurio.");
                                        return;
                                    }

                                    nivel = Convert.ToInt32(reader["Nivel"]);
                                    experiencia =
                                        Convert.ToInt32(reader["Experiencia"]);
                                }
                            }

                            // Agrega experiencia y calcula si subió de nivel.
                            experiencia += 10;

                            int nivelesGanados = experiencia / 100;

                            experiencia = experiencia % 100;

                            nivel += nivelesGanados;

                            // Guarda el nuevo nivel y la experiencia.
                            string actualizarDino = @"
                                UPDATE Dinosaurio
                                SET Nivel = @nivel,
                                    Experiencia = @experiencia
                                WHERE IdDinosaurio = @idDinosaurio
                                AND IdJugador = @idJugador";

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    actualizarDino, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@nivel", nivel);

                                cmd.Parameters.AddWithValue(
                                    "@experiencia", experiencia);

                                cmd.Parameters.AddWithValue(
                                    "@idDinosaurio", idDinosaurio);

                                cmd.Parameters.AddWithValue(
                                    "@idJugador", idJugador);

                                cmd.ExecuteNonQuery();
                            }

                            // Actualiza el progreso de las misiones de entrenamiento.
                            string actualizarEntrenamiento = @"
                                UPDATE JugadorMision jm
                                INNER JOIN Mision m
                                    ON jm.IdMision = m.IdMision
                                SET
                                    jm.Completada =
                                        CASE
                                            WHEN jm.ProgresoActual + 1 >= m.CantidadObjetivo
                                            THEN 1 ELSE 0
                                        END,
                                    jm.FechaFinalizacion =
                                        CASE
                                            WHEN jm.ProgresoActual + 1 >= m.CantidadObjetivo
                                            THEN NOW()
                                            ELSE jm.FechaFinalizacion
                                        END,
                                    jm.ProgresoActual =
                                        LEAST(m.CantidadObjetivo,
                                              jm.ProgresoActual + 1)
                                WHERE jm.IdJugador = @idJugador
                                AND jm.Completada = 0
                                AND m.Activa = 1
                                AND m.Objetivo = 'Entrenar'";

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    actualizarEntrenamiento,
                                    conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@idJugador", idJugador);

                                cmd.ExecuteNonQuery();
                            }

                            // Actualiza las misiones que piden subir de nivel.
                            if (nivelesGanados > 0)
                            {
                                string actualizarNivel = @"
                                    UPDATE JugadorMision jm
                                    INNER JOIN Mision m
                                        ON jm.IdMision = m.IdMision
                                    SET
                                        jm.Completada =
                                            CASE
                                                WHEN jm.ProgresoActual + @cantidad >= m.CantidadObjetivo
                                                THEN 1 ELSE 0
                                            END,
                                        jm.FechaFinalizacion =
                                            CASE
                                                WHEN jm.ProgresoActual + @cantidad >= m.CantidadObjetivo
                                                THEN NOW()
                                                ELSE jm.FechaFinalizacion
                                            END,
                                        jm.ProgresoActual =
                                            LEAST(m.CantidadObjetivo,
                                                  jm.ProgresoActual + @cantidad)
                                    WHERE jm.IdJugador = @idJugador
                                    AND jm.Completada = 0
                                    AND m.Activa = 1
                                    AND m.Objetivo = 'SubirNivel'";

                                using (MySqlCommand cmd =
                                    new MySqlCommand(
                                        actualizarNivel,
                                        conn, transaccion))
                                {
                                    cmd.Parameters.AddWithValue(
                                        "@cantidad", nivelesGanados);

                                    cmd.Parameters.AddWithValue(
                                        "@idJugador", idJugador);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaccion.Commit();

                            MessageBox.Show(
                                "¡Entrenamiento completado!\n" +
                                "Ganaste 10 puntos de experiencia.\n" +
                                "Nivel actual: " + nivel);

                            CargarDinosaurio();
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
                MessageBox.Show(
                    "Error al entrenar: " + ex.Message);
            }
        }

        // Eventos de los controles del formulario.
        private void lblTitulo_Click(object sender, EventArgs e) { }

        private void lblSubtitulo_Click(object sender, EventArgs e) { }

        private void panelDinosaurio_Paint(object sender, PaintEventArgs e) { }

        private void lblNombreDino_Click(object sender, EventArgs e) { }

        private void lblNivel_Click(object sender, EventArgs e) { }

        private void lblVida_Click(object sender, EventArgs e) { }

        private void progressVida_Click(object sender, EventArgs e) { }

        private void lblTextoVida_Click(object sender, EventArgs e) { }

        private void progressEnergia_Click(object sender, EventArgs e) { }

        private void lblEnergia_Click(object sender, EventArgs e) { }

        private void lblExperiencia_Click(object sender, EventArgs e) { }

        // Regresa al menú principal.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Recupera toda la energía del dinosaurio activo.
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (idDinosaurio == 0)
            {
                MessageBox.Show("No tienes un dinosaurio activo.");
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        UPDATE Dinosaurio
                        SET Energia = 100
                        WHERE IdDinosaurio = @idDinosaurio
                        AND IdJugador = @idJugador";

                    using (MySqlCommand cmd =
                        new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@idDinosaurio", idDinosaurio);

                        cmd.Parameters.AddWithValue(
                            "@idJugador", idJugador);

                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("¡Energía recuperada!");
                            CargarDinosaurio();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No se pudo recuperar la energía.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Botones para alimentar al dinosaurio con cada tipo de alimento.
        private void btnAlimentarCarne_Click(object sender, EventArgs e)
        {
            AlimentarDinosaurio(1);
        }

        private void btnAlimentarVegetales_Click(object sender, EventArgs e)
        {
            AlimentarDinosaurio(2);
        }

        // Ejecuta el entrenamiento del dinosaurio.
        private void btnEntrenar_Click(object sender, EventArgs e)
        {
            EntrenarDinosaurio();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}