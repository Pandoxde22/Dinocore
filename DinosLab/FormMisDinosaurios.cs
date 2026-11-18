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
    public partial class FormMisDinosaurios : Form
    {
        private int idJugador;

        // Inicializa el formulario y carga los dinosaurios pertenecientes al jugador.
        public FormMisDinosaurios(int idJugador)
        {
            InitializeComponent();

            this.idJugador = idJugador;

            CargarDinosaurios();
        }

        // Consulta los dinosaurios del jugador y crea una tarjeta visual para cada uno.
        private void CargarDinosaurios()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT IdDinosaurio, Nombre, Especie,
                               Categoria, Nivel, Vida, Energia, Activo
                        FROM Dinosaurio
                        WHERE IdJugador = @idJugador
                        ORDER BY IdDinosaurio";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJugador", idJugador);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            panelDinosaurios.Controls.Clear();
                            panelDinosaurios.AutoScroll = true;

                            int indice = 0;

                            while (reader.Read())
                            {
                                // Calcula la posición de cada tarjeta para organizarlas en tres columnas.
                                int columna = indice % 3;
                                int fila = indice / 3;

                                int x = 20 + (columna * 285);
                                int y = 20 + (fila * 480);

                                Panel tarjeta = new Panel();
                                tarjeta.Size = new Size(260, 450);
                                tarjeta.Location = new Point(x, y);
                                tarjeta.BackColor = Color.FromArgb(20, 25, 23);
                                tarjeta.BorderStyle = BorderStyle.FixedSingle;

                                string nombre = reader["Nombre"].ToString();
                                string especie = reader["Especie"].ToString();
                                string categoria = reader["Categoria"].ToString();

                                int nivel = Convert.ToInt32(reader["Nivel"]);
                                int vida = Convert.ToInt32(reader["Vida"]);
                                int energia = Convert.ToInt32(reader["Energia"]);
                                int idDinosaurio = Convert.ToInt32(reader["IdDinosaurio"]);
                                bool activo = Convert.ToBoolean(reader["Activo"]);

                                // Muestra el nombre del dinosaurio.
                                Label lblNombre = new Label();
                                lblNombre.Text = nombre;
                                lblNombre.Location = new Point(15, 10);
                                lblNombre.AutoSize = true;
                                lblNombre.ForeColor = Color.FromArgb(120, 255, 80);
                                lblNombre.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                // Identifica si el dinosaurio está seleccionado actualmente.
                                Label lblEstado = new Label();
                                lblEstado.Text = activo ? "★ DINOSAURIO ACTIVO" : "DISPONIBLE";
                                lblEstado.Location = new Point(15, 38);
                                lblEstado.AutoSize = true;
                                lblEstado.ForeColor = activo
                                    ? Color.LimeGreen
                                    : Color.LightGray;
                                lblEstado.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                                // Muestra la imagen correspondiente a la especie.
                                PictureBox imagenDino = new PictureBox();
                                imagenDino.Location = new Point(15, 65);
                                imagenDino.Size = new Size(220, 120);
                                imagenDino.SizeMode = PictureBoxSizeMode.Zoom;
                                CargarImagenDinosaurio(imagenDino, especie);

                                // Muestra la información general del dinosaurio.
                                Label lblEspecie = new Label();
                                lblEspecie.Text = "Especie: " + especie;
                                lblEspecie.Location = new Point(15, 195);
                                lblEspecie.AutoSize = true;
                                lblEspecie.ForeColor = Color.White;

                                Label lblCategoria = new Label();
                                lblCategoria.Text = "Categoría: " + categoria;
                                lblCategoria.Location = new Point(15, 220);
                                lblCategoria.AutoSize = true;
                                lblCategoria.ForeColor = Color.White;

                                Label lblNivel = new Label();
                                lblNivel.Text = "Nivel: " + nivel;
                                lblNivel.Location = new Point(15, 245);
                                lblNivel.AutoSize = true;
                                lblNivel.ForeColor = Color.White;

                                // Muestra la vida actual mediante una etiqueta y una barra de progreso.
                                Label lblVida = new Label();
                                lblVida.Text = "VIDA: " + vida + "/100";
                                lblVida.Location = new Point(15, 275);
                                lblVida.AutoSize = true;
                                lblVida.ForeColor = Color.White;

                                ProgressBar barraVida = new ProgressBar();
                                barraVida.Location = new Point(15, 298);
                                barraVida.Size = new Size(220, 18);
                                barraVida.Maximum = 100;
                                barraVida.Value = Math.Max(0, Math.Min(100, vida));

                                // Muestra la energía actual mediante otra barra de progreso.
                                Label lblEnergia = new Label();
                                lblEnergia.Text = "ENERGÍA: " + energia + "/100";
                                lblEnergia.Location = new Point(15, 330);
                                lblEnergia.AutoSize = true;
                                lblEnergia.ForeColor = Color.White;

                                ProgressBar barraEnergia = new ProgressBar();
                                barraEnergia.Location = new Point(15, 353);
                                barraEnergia.Size = new Size(220, 18);
                                barraEnergia.Maximum = 100;
                                barraEnergia.Value = Math.Max(0, Math.Min(100, energia));

                                // Agrega los elementos visuales a la tarjeta.
                                tarjeta.Controls.Add(lblNombre);
                                tarjeta.Controls.Add(lblEstado);
                                tarjeta.Controls.Add(imagenDino);
                                tarjeta.Controls.Add(lblEspecie);
                                tarjeta.Controls.Add(lblCategoria);
                                tarjeta.Controls.Add(lblNivel);
                                tarjeta.Controls.Add(lblVida);
                                tarjeta.Controls.Add(barraVida);
                                tarjeta.Controls.Add(lblEnergia);
                                tarjeta.Controls.Add(barraEnergia);

                                // Permite cambiar el dinosaurio activo desde su tarjeta.
                                Button btnSeleccionar = new Button();

                                btnSeleccionar.Text = activo ? "SELECCIONADO" : "SELECCIONAR";
                                btnSeleccionar.Location = new Point(15, 400);
                                btnSeleccionar.Size = new Size(220, 30);

                                btnSeleccionar.BackColor = activo
                                    ? Color.FromArgb(70, 100, 60)
                                    : Color.FromArgb(120, 255, 80);

                                btnSeleccionar.ForeColor = Color.Black;
                                btnSeleccionar.FlatStyle = FlatStyle.Flat;
                                btnSeleccionar.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                                btnSeleccionar.Enabled = !activo;

                                btnSeleccionar.Click += (s, e) =>
                                {
                                    CambiarDinosaurio(idDinosaurio);
                                };

                                tarjeta.Controls.Add(btnSeleccionar);
                                panelDinosaurios.Controls.Add(tarjeta);

                                indice++;
                            }

                            if (indice == 0)
                            {
                                MessageBox.Show("No tienes dinosaurios registrados.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tus dinosaurios: " + ex.Message);
            }
        }

        // Selecciona la ruta de la imagen según la especie y la carga en el PictureBox.
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

            // Carga la imagen si existe y libera el archivo después de copiarla.
            if (File.Exists(ruta))
            {
                using (FileStream archivo = new FileStream(
                    ruta, FileMode.Open, FileAccess.Read))
                {
                    using (Image imagen = Image.FromStream(archivo))
                    {
                        cuadro.Image = new Bitmap(imagen);
                    }
                }
            }
        }

        // Comprueba que el dinosaurio pertenezca al jugador y actualiza cuál está activo.
        private void CambiarDinosaurio(int idDinosaurio)
        {
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
                            // Verifica que el dinosaurio seleccionado pertenezca a la cuenta.
                            string validar = @"
                        SELECT COUNT(*)
                        FROM Dinosaurio
                        WHERE IdDinosaurio = @idDinosaurio
                        AND IdJugador = @idJugador";

                            using (MySqlCommand cmd = new MySqlCommand(validar, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@idDinosaurio", idDinosaurio);
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);

                                int existe = Convert.ToInt32(cmd.ExecuteScalar());

                                if (existe == 0)
                                {
                                    throw new Exception("Este dinosaurio no pertenece a tu cuenta.");
                                }
                            }

                            // Desactiva los dinosaurios anteriores del jugador.
                            string desactivar = @"
                        UPDATE Dinosaurio
                        SET Activo = 0
                        WHERE IdJugador = @idJugador";

                            using (MySqlCommand cmd = new MySqlCommand(desactivar, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                                cmd.ExecuteNonQuery();
                            }

                            // Activa únicamente el dinosaurio que el jugador seleccionó.
                            string activar = @"
                        UPDATE Dinosaurio
                        SET Activo = 1
                        WHERE IdDinosaurio = @idDinosaurio
                        AND IdJugador = @idJugador";

                            using (MySqlCommand cmd = new MySqlCommand(activar, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@idDinosaurio", idDinosaurio);
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                                cmd.ExecuteNonQuery();
                            }

                            // Confirma los cambios realizados en la base de datos.
                            transaccion.Commit();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("¡Dinosaurio activo cambiado correctamente!");

                // Actualiza las tarjetas para reflejar el nuevo dinosaurio activo.
                CargarDinosaurios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar dinosaurio: " + ex.Message);
            }
        }

        // Cierra el formulario y regresa al menú principal.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelDinosaurios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}