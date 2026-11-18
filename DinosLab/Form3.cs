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
    public partial class FormSeleccionDinosaurio : Form
    {
        private int idJugador;

        // Inicializa el formulario, guarda el identificador del jugador y carga los dinosaurios disponibles.
        public FormSeleccionDinosaurio(int idJugador)
        {
            InitializeComponent();

            this.idJugador = idJugador;

            // Configurar imagen
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            CargarDinosaurios();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void lblInstrucciones_Click(object sender, EventArgs e)
        {
        }

        // Muestra la información del dinosaurio seleccionado y actualiza su imagen.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is DataRowView fila)
            {
                string nombre = fila["Nombre"].ToString();
                string especie = fila["Especie"].ToString();
                string categoria = fila["Categoria"].ToString();

                lblDescripcion.Text =
                    "Nombre: " + nombre +
                    "\nEspecie: " + especie +
                    "\nCategoría: " + categoria;

                CargarImagen(especie);
            }
        }

        // Busca la imagen correspondiente a la especie y la muestra en el PictureBox.
        private void CargarImagen(string especie)
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

            // Comprueba que el archivo exista antes de cargarlo.
            if (System.IO.File.Exists(ruta))
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }

                pictureBox1.Image = Image.FromFile(ruta);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        // Asigna el dinosaurio elegido al jugador y copia sus habilidades dentro de una transacción.
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un dinosaurio.");
                return;
            }

            int idCatalogo = Convert.ToInt32(comboBox1.SelectedValue);

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
                            // Copia los datos del dinosaurio del catálogo y lo asigna al jugador.
                            string consulta = @"
                    INSERT INTO Dinosaurio
                    (
                        IdJugador, Activo, Nombre, Especie, Categoria,
                        Nivel, Energia, Vida, Experiencia,
                        Fuerza, Defensa, Velocidad,
                        PotenciaMordida, Resistencia, Intimidacion,
Agilidad, `Precision`, Reflejos,
AdaptacionAcuatica, PotenciaNadado, CazaAcuatica,
                        ResistenciaCuernos, ProteccionCorporal,
                        PotenciaEmbestida, FuerzaFisica, ResistenciaFisica,
                        RecuperacionEnergia, DefensaPlacas, ResistenciaEspecial,
                        ProteccionDorsal, Adaptabilidad, VelocidadReaccion,
                        AtaqueSorpresa, Movilidad, Evasion, Exploracion,
                        Aguante, Coordinacion, InstintoSupervivencia,
                        ConsumoCarne, ConsumoVegetal, PreferenciaAlimenticia,
                        MultiplicadorAprovechamiento
                    )
                    SELECT
                        @idJugador, 1, Nombre, Especie, Categoria,
                        Nivel, Energia, Vida, Experiencia,
                        Fuerza, Defensa, Velocidad,
                        PotenciaMordida, Resistencia, Intimidacion,
Agilidad, `Precision`, Reflejos,
AdaptacionAcuatica, PotenciaNadado, CazaAcuatica,
                        ResistenciaCuernos, ProteccionCorporal,
                        PotenciaEmbestida, FuerzaFisica, ResistenciaFisica,
                        RecuperacionEnergia, DefensaPlacas, ResistenciaEspecial,
                        ProteccionDorsal, Adaptabilidad, VelocidadReaccion,
                        AtaqueSorpresa, Movilidad, Evasion, Exploracion,
                        Aguante, Coordinacion, InstintoSupervivencia,
                        ConsumoCarne, ConsumoVegetal, PreferenciaAlimenticia,
                        MultiplicadorAprovechamiento
                    FROM Dinosaurio
                    WHERE IdDinosaurio = @idCatalogo
                    AND IdJugador IS NULL;";

                            using (MySqlCommand cmd = new MySqlCommand(consulta, conn, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@idJugador", idJugador);
                                cmd.Parameters.AddWithValue("@idCatalogo", idCatalogo);

                                int filas = cmd.ExecuteNonQuery();

                                if (filas == 0)
                                {
                                    throw new Exception("No se encontró el dinosaurio seleccionado.");
                                }
                            }

                            // Recupera el identificador del nuevo dinosaurio asignado.
                            long idNuevoDinosaurio;

                            using (MySqlCommand cmdId = new MySqlCommand(
                                "SELECT LAST_INSERT_ID();", conn, transaccion))
                            {
                                idNuevoDinosaurio = Convert.ToInt64(cmdId.ExecuteScalar());
                            }

                            // Copia las habilidades del dinosaurio original al nuevo registro.
                            string copiarHabilidades = @"
                    INSERT INTO DinosaurioHabilidad
                    (
                        IdDinosaurio, IdHabilidad, Desbloqueada,
                        NivelDesbloqueo, TurnosRestantesRecarga
                    )
                    SELECT
                        @idNuevo, IdHabilidad, Desbloqueada,
                        NivelDesbloqueo, TurnosRestantesRecarga
                    FROM DinosaurioHabilidad
                    WHERE IdDinosaurio = @idCatalogo;";

                            using (MySqlCommand cmdHab = new MySqlCommand(
                                copiarHabilidades, conn, transaccion))
                            {
                                cmdHab.Parameters.AddWithValue("@idNuevo", idNuevoDinosaurio);
                                cmdHab.Parameters.AddWithValue("@idCatalogo", idCatalogo);

                                cmdHab.ExecuteNonQuery();
                            }

                            // Confirma los cambios y abre el menú principal del jugador.
                            transaccion.Commit();

                            MessageBox.Show("¡Tu dinosaurio fue asignado correctamente!");

                            this.Hide();

                            FormMenuPrincipal menu = new FormMenuPrincipal(idJugador);

                            menu.ShowDialog();

                            this.Close();
                        }
                        catch
                        {
                            // Revierte los cambios si ocurre algún error durante la asignación.
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar el dinosaurio: " + ex.Message);
            }
        }

        // Consulta los dinosaurios disponibles en el catálogo y los carga en el ComboBox.
        private void CargarDinosaurios()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT IdDinosaurio, Nombre, Especie, Categoria
                        FROM Dinosaurio
                        WHERE IdJugador IS NULL
                        ORDER BY Nombre";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conn);

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    comboBox1.DataSource = tabla;
                    comboBox1.DisplayMember = "Nombre";
                    comboBox1.ValueMember = "IdDinosaurio";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los dinosaurios: " + ex.Message);
            }
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {
        }
    }
}