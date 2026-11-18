using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DinoCore;

namespace DinosLab
{
    public partial class FormMenuPrincipal : Form
    {
        // Identificador del jugador que inició sesión.
        private int idJugador;

        // Controla el desgaste automático del dinosaurio.
        private System.Windows.Forms.Timer temporizadorVida;

        // Inicializa el menú y carga la información del jugador.
        public FormMenuPrincipal(int idJugador)
        {
            InitializeComponent();

            this.idJugador = idJugador;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            CargarDinosaurio();
            CargarUltimoCombate();
            CargarUltimaMision();
            CargarInventario();

            // Inicia el desgaste de vida y energía cada 10 segundos.
            temporizadorVida = new System.Windows.Forms.Timer();
            temporizadorVida.Interval = 10000;
            temporizadorVida.Tick += TemporizadorVida_Tick;
            temporizadorVida.Start();
        }

        // Reduce 5 puntos de vida y energía cada 10 segundos.
        private void TemporizadorVida_Tick(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        UPDATE Dinosaurio
                        SET Vida = GREATEST(Vida - 5, 0),
                            Energia = GREATEST(Energia - 5, 0)
                        WHERE IdJugador = @idJugador
                        AND Activo = 1";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Actualiza las barras y los valores en pantalla.
                CargarDinosaurio();
            }
            catch (Exception ex)
            {
                temporizadorVida.Stop();
                MessageBox.Show("Error al actualizar el estado: " + ex.Message);
            }
        }

        // Carga los datos del dinosaurio activo y actualiza su fotografía.
        private void CargarDinosaurio()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT Nombre, Especie, Nivel, Vida, Energia
                        FROM Dinosaurio
                        WHERE IdJugador = @idJugador AND Activo = 1
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblNombreDinosaurio.Text =
                                    reader["Nombre"].ToString();

                                lblEspecie.Text =
                                    "Especie: " + reader["Especie"].ToString();

                                lblNivel.Text =
                                    "Nivel: " + reader["Nivel"].ToString();

                                int vida = Convert.ToInt32(reader["Vida"]);
                                int energia = Convert.ToInt32(reader["Energia"]);

                                progressVida.Value = Math.Max(
                                    progressVida.Minimum,
                                    Math.Min(vida, progressVida.Maximum));

                                progressEnergia.Value = Math.Max(
                                    progressEnergia.Minimum,
                                    Math.Min(energia, progressEnergia.Maximum));

                                lblValorVida.Text = vida + "/100";
                                lblValorEnergia.Text = energia + "/100";

                                // Carga la imagen correspondiente a la especie activa.
                                CargarImagenDinosaurio(reader["Especie"].ToString());
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Este jugador todavía no tiene dinosaurios.");

                                pictureBox1.Image = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el dinosaurio: " + ex.Message);
            }
        }

        // Selecciona la ruta de la fotografía según la especie.
        private void CargarImagenDinosaurio(string especie)
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

            // Comprueba que la imagen exista antes de mostrarla.
            if (File.Exists(ruta))
            {
                try
                {
                    // Libera la fotografía anterior.
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    // Carga la imagen sin mantener bloqueado el archivo.
                    using (FileStream archivo = new FileStream(
                        ruta, FileMode.Open, FileAccess.Read))
                    {
                        using (Image imagen = Image.FromStream(archivo))
                        {
                            pictureBox1.Image = new Bitmap(imagen);
                        }
                    }

                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo cargar la imagen: " + ex.Message);
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        // Eventos de los controles del formulario.
        private void lblLogo_Click(object sender, EventArgs e) { }

        // Abre el formulario para administrar los dinosaurios.
        private void btnDinosaurios_Click(object sender, EventArgs e)
        {
            FormMisDinosaurios formulario =
                new FormMisDinosaurios(idJugador);

            formulario.ShowDialog();

            CargarDinosaurio();
        }

        private void btnSubtitulo_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void lblBienvenida_Click(object sender, EventArgs e) { }
        private void panelDinosaurio_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void lblNombreDinosaurio_Click(object sender, EventArgs e) { }
        private void lblEspecie_Click(object sender, EventArgs e) { }
        private void lblNivel_Click(object sender, EventArgs e) { }
        private void lblVida_Click(object sender, EventArgs e) { }
        private void progressVida_Click(object sender, EventArgs e) { }
        private void lblEnergia_Click(object sender, EventArgs e) { }
        private void progressEnergia_Click(object sender, EventArgs e) { }
        private void lblEstado_Click(object sender, EventArgs e) { }
        private void panelActividad_Paint(object sender, PaintEventArgs e) { }
        private void lblTituloActividad_Click(object sender, EventArgs e) { }
        private void lblActividad1_Click(object sender, EventArgs e) { }

        // Actualiza la última misión completada.
        private void lblActividad2_Click(object sender, EventArgs e)
        {
            CargarUltimaMision();
        }

        // Consulta las cantidades de carne y vegetales disponibles.
        private void CargarInventario()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT
                            a.TipoAlimento,
                            SUM(d.Cantidad) AS Cantidad
                        FROM Inventario i
                        INNER JOIN DetalleInventario d
                            ON i.IdInventario = d.IdInventario
                        INNER JOIN Alimento a
                            ON d.IdAlimento = a.IdAlimento
                        WHERE i.IdJugador = @idJugador
                        GROUP BY a.TipoAlimento";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);

                        lblCantidadCarne.Text = "Carne: 0";
                        lblCantidadVegetales.Text = "Vegetales: 0";

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipo =
                                    reader["TipoAlimento"].ToString();

                                int cantidad =
                                    Convert.ToInt32(reader["Cantidad"]);

                                if (tipo == "Carne")
                                    lblCantidadCarne.Text = "Carne: " + cantidad;

                                else if (tipo == "Vegetales")
                                    lblCantidadVegetales.Text = "Vegetales: " + cantidad;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar inventario: " + ex.Message);
            }
        }

        // Consulta el último combate guardado.
        private void label3_Click(object sender, EventArgs e)
        {
            CargarUltimoCombate();
        }

        private void panelLateral_Paint(object sender, PaintEventArgs e) { }

        // Abre el perfil del jugador.
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            FormPerfil formulario = new FormPerfil(idJugador);
            formulario.ShowDialog();
        }

        // Abre el combate y actualiza la información al regresar.
        private void btnCombate_Click(object sender, EventArgs e)
        {
            Combate combate = new Combate(idJugador);
            combate.ShowDialog();

            CargarUltimoCombate();
            CargarDinosaurio();
        }

        // Abre el laboratorio y actualiza los datos del dinosaurio.
        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            FormLaboratorio formulario = new FormLaboratorio(idJugador);
            formulario.ShowDialog();

            CargarDinosaurio();
            CargarInventario();
        }

        // Abre las misiones y actualiza el progreso al regresar.
        private void btnMisiones_Click(object sender, EventArgs e)
        {
            FormMisiones formulario = new FormMisiones(idJugador);
            formulario.ShowDialog();

            CargarDinosaurio();
            CargarUltimaMision();
        }

        // Abre la tienda y actualiza las cantidades del inventario.
        private void btnTienda_Click(object sender, EventArgs e)
        {
            FormTienda formulario = new FormTienda(idJugador);
            formulario.ShowDialog();

            CargarInventario();
        }

        private void lblValorVida_Click(object sender, EventArgs e) { }
        private void lblValorEnergia_Click(object sender, EventArgs e) { }

        // Consulta el resultado del combate más reciente.
        private void CargarUltimoCombate()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT Resultado, NombreCPU, FechaBatalla,
                               RecompensaMonedas
                        FROM Batalla
                        WHERE IdJugador = @idJugador
                        ORDER BY FechaBatalla DESC
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label3.Text =
                                    "Último combate: " +
                                    reader["Resultado"] +
                                    " contra " + reader["NombreCPU"] +
                                    " | +" + reader["RecompensaMonedas"] + " monedas";
                            }
                            else
                            {
                                label3.Text =
                                    "Último combate: Sin combates todavía";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar último combate: " + ex.Message);
            }
        }

        // Consulta la última misión completada por el jugador.
        private void CargarUltimaMision()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT m.Nombre, jm.FechaFinalizacion
                        FROM JugadorMision jm
                        INNER JOIN Mision m
                            ON jm.IdMision = m.IdMision
                        WHERE jm.IdJugador = @idJugador
                        AND jm.Completada = 1
                        AND jm.FechaFinalizacion IS NOT NULL
                        ORDER BY jm.FechaFinalizacion DESC
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombre =
                                    reader["Nombre"].ToString();

                                DateTime fecha = Convert.ToDateTime(
                                    reader["FechaFinalizacion"]);

                                lblActividad2.Text =
                                    "Última misión: " + nombre +
                                    " (" + fecha.ToString("dd/MM/yyyy") + ")";
                            }
                            else
                            {
                                lblActividad2.Text =
                                    "Última misión: Ninguna completada";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar última misión: " + ex.Message);
            }
        }

        // Actualiza el inventario al hacer clic en sus etiquetas.
        private void lblCantidadCarne_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void lblCantidadVegetales_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }

        // Detiene el temporizador cuando se cierra el menú.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (temporizadorVida != null)
            {
                temporizadorVida.Stop();
                temporizadorVida.Dispose();
            }

            base.OnFormClosed(e);
        }
    }
}