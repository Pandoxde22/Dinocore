using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DinoCore;
using MySql.Data.MySqlClient;

namespace DinosLab
{
    public partial class Combate : Form
    {
        // Datos de los participantes de la batalla.
        private int idJugador;
        private Dinosaurio miDino;
        private Dinosaurio rival;

        private int vidaMaxMiDino;
        private int vidaMaxRival;

        // Prepara la pantalla y carga el combate del jugador.
        public Combate()
        {
            InitializeComponent();

            pictureMIDino.SizeMode = PictureBoxSizeMode.Zoom;
            pictureRival.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public Combate(int idJugador) : this()
        {
            this.idJugador = idJugador;
            CargarCombate();
        }

        // Obtiene los dinosaurios, muestra sus datos y prepara las barras de vida.
        private void CargarCombate()
        {
            try
            {
                int idActivo = ObtenerDinosaurioActivo();

                miDino = FabricaDinosaurios.CrearDesdeBD(idActivo);

                if (miDino == null)
                    throw new Exception("No se pudo cargar tu dinosaurio.");

                int idRival = ObtenerRivalAleatorio();

                rival = FabricaDinosaurios.CrearDesdeBD(idRival);

                if (rival == null)
                    throw new Exception("No se pudo cargar el rival.");

                vidaMaxMiDino = miDino.Vida;
                vidaMaxRival = rival.Vida;

                if (vidaMaxMiDino <= 0 || vidaMaxRival <= 0)
                    throw new Exception("Un dinosaurio no tiene vida disponible.");

                lblMiDino.Text = miDino.Nombre;
                lblNivelMiDino.Text = "Nivel: " + miDino.Nivel;

                lblRival.Text = rival.Nombre;
                lblNivelRival.Text = "Nivel: " + rival.Nivel;

                // Carga las fotografías de ambos participantes.
                CargarImagenDinosaurio(pictureMIDino, miDino.Especie);
                CargarImagenDinosaurio(pictureRival, rival.Especie);

                ActualizarBarras();

                listBatalla.Items.Clear();
                listBatalla.Items.Add("¡COMIENZA LA BATALLA!");
                listBatalla.Items.Add(miDino.Nombre + " VS " + rival.Nombre);

                btnAtacar.Enabled = true;
                btnHabilidad.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combate: " + ex.Message);
                btnAtacar.Enabled = false;
                btnHabilidad.Enabled = false;
            }
        }

        // Busca la imagen correspondiente a cada especie y la muestra en su PictureBox.
        private void CargarImagenDinosaurio(PictureBox cuadro, string especie)
        {
            string ruta = "";

            switch (especie.Trim().ToLower())
            {
                case "rex":
                case "tyrannosaurus rex":
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
                    ruta = @"C:\Users\angel\Downloads\stego.jpg";
                    break;

                case "triceratops":
                    ruta = @"C:\Users\angel\Downloads\trice.jpg";
                    break;

                case "brachiosaurus":
                case "braquiosaurio":
                    ruta = @"C:\Users\angel\Downloads\bronto.jpg";
                    break;

                case "oviraptor":
                    ruta = @"C:\Users\angel\Downloads\oviraptor.jpg";
                    break;

                case "ornithomimus":
                    ruta = @"C:\Users\angel\Downloads\maewing.jpg";
                    break;

                case "gallimimus":
                case "galliminus":
                    ruta = @"C:\Users\angel\Downloads\gallinimus.png";
                    break;
            }

            // Comprueba que el archivo exista antes de cargarlo.
            if (File.Exists(ruta))
            {
                try
                {
                    // Libera la imagen anterior para evitar ocupar memoria.
                    if (cuadro.Image != null)
                    {
                        cuadro.Image.Dispose();
                        cuadro.Image = null;
                    }

                    // Carga una copia de la imagen sin bloquear el archivo original.
                    using (FileStream archivo = new FileStream(
                        ruta, FileMode.Open, FileAccess.Read))
                    {
                        using (Image imagen = Image.FromStream(archivo))
                        {
                            cuadro.Image = new Bitmap(imagen);
                        }
                    }

                    cuadro.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar la fotografía de " +
                        especie + ": " + ex.Message);
                }
            }
            else
            {
                cuadro.Image = null;
            }
        }

        // Obtiene el identificador del dinosaurio que el jugador tiene activo.
        private int ObtenerDinosaurioActivo()
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"
                    SELECT IdDinosaurio
                    FROM Dinosaurio
                    WHERE IdJugador = @idJugador
                    AND Activo = 1
                    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@idJugador", idJugador);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null)
                        throw new Exception("No tienes un dinosaurio activo.");

                    return Convert.ToInt32(resultado);
                }
            }
        }

        // Selecciona un rival al azar del catálogo de dinosaurios.
        private int ObtenerRivalAleatorio()
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"
                    SELECT IdDinosaurio
                    FROM Dinosaurio
                    WHERE IdJugador IS NULL
                    ORDER BY RAND()
                    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null)
                        throw new Exception("No hay rivales disponibles.");

                    return Convert.ToInt32(resultado);
                }
            }
        }

        // Actualiza las barras y los números de vida después de cada ataque.
        private void ActualizarBarras()
        {
            progressVidaMiDino.Minimum = 0;
            progressVidaMiDino.Maximum = vidaMaxMiDino;
            progressVidaMiDino.Value = Math.Max(
                0, Math.Min(miDino.Vida, vidaMaxMiDino));

            progressVidaRival.Minimum = 0;
            progressVidaRival.Maximum = vidaMaxRival;
            progressVidaRival.Value = Math.Max(
                0, Math.Min(rival.Vida, vidaMaxRival));

            lblVidaMiDino.Text =
                "Vida: " + miDino.Vida + " / " + vidaMaxMiDino;

            lblVidaRival.Text =
                "Vida: " + rival.Vida + " / " + vidaMaxRival;
        }

        // Botón para realizar un ataque normal.
        private void btnAtacar_Click(object sender, EventArgs e)
        {
            EjecutarTurno(false);
        }

        // Botón para realizar un ataque con habilidad especial.
        private void btnHabilidad_Click(object sender, EventArgs e)
        {
            EjecutarTurno(true);
        }

        // Controla los ataques de ambos dinosaurios durante cada turno.
        private void EjecutarTurno(bool habilidad)
        {
            if (miDino == null || rival == null)
                return;

            if (miDino.Vida <= 0 || rival.Vida <= 0)
                return;

            int danoJugador = miDino.Atacar();

            if (habilidad)
            {
                danoJugador += 15;

                listBatalla.Items.Add(
                    "¡HABILIDAD ESPECIAL: " +
                    miDino.ObtenerCaracteristicaUnica() + "!");
            }

            int defensaRival = rival.Defender();

            int danoFinal = Math.Max(
                5, danoJugador - defensaRival / 2);

            rival.Vida -= danoFinal;

            if (rival.Vida < 0)
                rival.Vida = 0;

            listBatalla.Items.Add(
                miDino.Nombre + " hizo " +
                danoFinal + " de daño.");

            ActualizarBarras();

            if (rival.Vida <= 0)
            {
                FinalizarCombate(true);
                return;
            }

            // El rival responde al ataque del jugador.
            int ataqueRival = rival.Atacar();
            int defensaJugador = miDino.Defender();

            int danoRecibido = Math.Max(
                5, ataqueRival - defensaJugador / 2);

            miDino.Vida -= danoRecibido;

            if (miDino.Vida < 0)
                miDino.Vida = 0;

            listBatalla.Items.Add(
                rival.Nombre + " hizo " +
                danoRecibido + " de daño.");

            ActualizarBarras();

            if (miDino.Vida <= 0)
                FinalizarCombate(false);
        }

        // Termina la batalla y muestra si el jugador ganó o perdió.
        private void FinalizarCombate(bool victoria)
        {
            btnAtacar.Enabled = false;
            btnHabilidad.Enabled = false;

            if (victoria)
            {
                listBatalla.Items.Add("¡VICTORIA!");

                MessageBox.Show(
                    "¡Felicidades! Has ganado la batalla.");
            }
            else
            {
                listBatalla.Items.Add("DERROTA");

                MessageBox.Show(
                    "Tu dinosaurio ha sido derrotado.");
            }
        }

        // Cierra el combate y regresa al menú principal.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Eventos visuales del formulario.
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void lblMiDino_Click(object sender, EventArgs e) { }
        private void pictureMIDino_Click(object sender, EventArgs e) { }
        private void lblNivelMiDino_Click(object sender, EventArgs e) { }
        private void lblVidaMiDino_Click(object sender, EventArgs e) { }
        private void progressVidaMiDino_Click(object sender, EventArgs e) { }
        private void lblRegistro_Click(object sender, EventArgs e) { }
        private void listBatalla_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblRival_Click(object sender, EventArgs e) { }
        private void pictureRival_Click(object sender, EventArgs e) { }
        private void lblNivelRival_Click(object sender, EventArgs e) { }
        private void lblVidaRival_Click(object sender, EventArgs e) { }
        private void progressVidaRival_Click(object sender, EventArgs e) { }
    }
}