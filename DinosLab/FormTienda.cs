using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DinoCore;
using MySql.Data.MySqlClient;

namespace DinosLab
{
    public partial class FormTienda : Form
    {
        private int idJugador;

        // Guarda el jugador y carga sus monedas e imágenes.
        public FormTienda(int idJugador)
        {
            InitializeComponent();
            this.idJugador = idJugador;

            pictureBoxCarne.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxVegetales.SizeMode = PictureBoxSizeMode.Zoom;

            CargarImagenes();
            CargarMonedas();
        }

        // Carga las imágenes de los alimentos en la tienda.
        private void CargarImagenes()
        {
            CargarImagen(pictureBoxCarne, @"C:\Users\angel\Downloads\carne.jpg");
            CargarImagen(pictureBoxVegetales, @"C:\Users\angel\Downloads\vegetales.jpg");
        }

        // Abre la imagen y la muestra sin dejar bloqueado el archivo.
        private void CargarImagen(PictureBox cuadro, string ruta)
        {
            try
            {
                if (File.Exists(ruta))
                {
                    using (FileStream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                    {
                        using (Image imagen = Image.FromStream(archivo))
                        {
                            Image anterior = cuadro.Image;
                            cuadro.Image = new Bitmap(imagen);

                            if (anterior != null)
                            {
                                anterior.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la imagen: " + ruta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
        }

        // Consulta las monedas que tiene el jugador.
        private void CargarMonedas()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string consulta = @"
                        SELECT Monedas
                        FROM Jugador
                        WHERE IdJugador = @idJugador";

                    MySqlCommand cmd = new MySqlCommand(consulta, conn);
                    cmd.Parameters.AddWithValue("@idJugador", idJugador);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        lblMonedas.Text = "Monedas: " + resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar monedas: " + ex.Message);
            }
        }

        // Realiza la compra del alimento seleccionado.
        private void ComprarAlimento(string tipo)
        {
            int idAlimento;
            int precio;

            // Se establece el precio dependiendo del alimento.
            if (tipo == "Carne")
            {
                idAlimento = 1;
                precio = 50;
            }
            else
            {
                idAlimento = 2;
                precio = 35;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    // La transacción permite realizar todos los cambios juntos.
                    using (MySqlTransaction transaccion = conn.BeginTransaction())
                    {
                        try
                        {
                            // Consulta las monedas del jugador y bloquea el registro durante la compra.
                            string consultaMonedas = @"
                                SELECT Monedas
                                FROM Jugador
                                WHERE IdJugador = @idJugador
                                FOR UPDATE";

                            MySqlCommand cmdMonedas =
                                new MySqlCommand(consultaMonedas, conn, transaccion);

                            cmdMonedas.Parameters.AddWithValue("@idJugador", idJugador);

                            object resultado = cmdMonedas.ExecuteScalar();

                            if (resultado == null)
                            {
                                throw new Exception("No se encontró al jugador.");
                            }

                            int monedas = Convert.ToInt32(resultado);

                            // Comprueba que tenga suficientes monedas.
                            if (monedas < precio)
                            {
                                transaccion.Rollback();
                                MessageBox.Show("No tienes suficientes monedas.");
                                return;
                            }

                            // Busca el inventario del jugador o lo crea si no existe.
                            string consultaInventario = @"
                                INSERT INTO Inventario (IdJugador)
                                VALUES (@idJugador)
                                ON DUPLICATE KEY UPDATE IdJugador = IdJugador";

                            MySqlCommand cmdInventario =
                                new MySqlCommand(consultaInventario, conn, transaccion);

                            cmdInventario.Parameters.AddWithValue("@idJugador", idJugador);
                            cmdInventario.ExecuteNonQuery();

                            // Obtiene el identificador del inventario.
                            string consultaIdInventario = @"
                                SELECT IdInventario
                                FROM Inventario
                                WHERE IdJugador = @idJugador";

                            MySqlCommand cmdId =
                                new MySqlCommand(consultaIdInventario, conn, transaccion);

                            cmdId.Parameters.AddWithValue("@idJugador", idJugador);

                            int idInventario = Convert.ToInt32(cmdId.ExecuteScalar());

                            // Agrega una unidad del alimento comprado.
                            string consultaDetalle = @"
                                INSERT INTO DetalleInventario
                                (IdInventario, IdAlimento, Cantidad)
                                VALUES (@idInventario, @idAlimento, 1)
                                ON DUPLICATE KEY UPDATE Cantidad = Cantidad + 1";

                            MySqlCommand cmdDetalle =
                                new MySqlCommand(consultaDetalle, conn, transaccion);

                            cmdDetalle.Parameters.AddWithValue("@idInventario", idInventario);
                            cmdDetalle.Parameters.AddWithValue("@idAlimento", idAlimento);
                            cmdDetalle.ExecuteNonQuery();

                            // Resta el precio de las monedas del jugador.
                            string consultaDescuento = @"
                                UPDATE Jugador
                                SET Monedas = Monedas - @precio
                                WHERE IdJugador = @idJugador";

                            MySqlCommand cmdDescuento =
                                new MySqlCommand(consultaDescuento, conn, transaccion);

                            cmdDescuento.Parameters.AddWithValue("@precio", precio);
                            cmdDescuento.Parameters.AddWithValue("@idJugador", idJugador);
                            cmdDescuento.ExecuteNonQuery();

                            // Confirma la compra y actualiza las monedas.
                            transaccion.Commit();

                            MessageBox.Show("¡Compra realizada correctamente!");

                            CargarMonedas();
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
                MessageBox.Show("Error al comprar: " + ex.Message);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void lblMonedas_Click(object sender, EventArgs e)
        {
        }

        private void panelProductos_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblCarne_Click(object sender, EventArgs e)
        {
        }

        private void lblVegetales_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxCarne_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxVegetales_Click(object sender, EventArgs e)
        {
        }

        // Botón para comprar carne.
        private void btnComprarCarne_Click(object sender, EventArgs e)
        {
            ComprarAlimento("Carne");
        }

        // Botón para comprar vegetales.
        private void btnComprarVegetales_Click(object sender, EventArgs e)
        {
            ComprarAlimento("Vegetales");
        }

        // Regresa al menú principal.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}