using System;
using DinoCore;
using MySql.Data.MySqlClient;

namespace DinosLab
{
    public class Dinosaurio
    {
        // Datos principales del dinosaurio.
        public int IdDinosaurio { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Categoria { get; set; }
        public int IdJugador { get; set; }

        // Datos de progreso del dinosaurio.
        public int Nivel { get; set; }
        public int Experiencia { get; set; }

        // Estado actual del dinosaurio.
        public int Energia { get; set; }
        public int Vida { get; set; }

        // Estadísticas que se utilizan en los combates.
        public int Fuerza { get; set; }
        public int Defensa { get; set; }
        public int Velocidad { get; set; }

        // Establece los valores iniciales de un dinosaurio nuevo.
        public Dinosaurio()
        {
            Nivel = 1;
            Experiencia = 0;
            Energia = 100;
            Vida = 100;
        }

        // Busca un dinosaurio en la base de datos y carga sus datos.
        public bool CargarDesdeBD(int idDinosaurio)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                string consulta = @"
                    SELECT IdDinosaurio, IdJugador, Nombre,
                           Especie, Categoria, Nivel, Experiencia,
                           Energia, Vida, Fuerza, Defensa, Velocidad
                    FROM Dinosaurio
                    WHERE IdDinosaurio = @idDinosaurio";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@idDinosaurio", idDinosaurio);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        IdDinosaurio = Convert.ToInt32(reader["IdDinosaurio"]);

                        // Algunos dinosaurios del catálogo todavía no tienen jugador.
                        IdJugador = reader["IdJugador"] == DBNull.Value
                            ? 0
                            : Convert.ToInt32(reader["IdJugador"]);

                        Nombre = reader["Nombre"].ToString();
                        Especie = reader["Especie"].ToString();
                        Categoria = reader["Categoria"].ToString();
                        Nivel = Convert.ToInt32(reader["Nivel"]);
                        Experiencia = Convert.ToInt32(reader["Experiencia"]);
                        Energia = Convert.ToInt32(reader["Energia"]);
                        Vida = Convert.ToInt32(reader["Vida"]);
                        Fuerza = Convert.ToInt32(reader["Fuerza"]);
                        Defensa = Convert.ToInt32(reader["Defensa"]);
                        Velocidad = Convert.ToInt32(reader["Velocidad"]);

                        return true;
                    }
                }
            }
        }

        // Sube el nivel del dinosaurio y actualiza sus desbloqueos.
        public void SubirNivel()
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                conn.Open();

                // Se utiliza una transacción para guardar todos los cambios juntos.
                using (MySqlTransaction transaccion = conn.BeginTransaction())
                {
                    try
                    {
                        Nivel++;

                        string consulta = @"
                            UPDATE Dinosaurio
                            SET Nivel = @nivel
                            WHERE IdDinosaurio = @idDinosaurio";

                        using (MySqlCommand cmd = new MySqlCommand(
                            consulta, conn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@nivel", Nivel);
                            cmd.Parameters.AddWithValue("@idDinosaurio", IdDinosaurio);

                            int filas = cmd.ExecuteNonQuery();

                            if (filas == 0)
                                throw new Exception("No se encontró el dinosaurio.");
                        }

                        // Revisa las habilidades y los nuevos dinosaurios disponibles.
                        DesbloquearHabilidades(conn, transaccion);
                        DesbloquearSiguienteDinosaurio(conn, transaccion);

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        Nivel--;
                        throw;
                    }
                }
            }
        }

        // Desbloquea las habilidades que corresponden al nivel actual.
        private void DesbloquearHabilidades(
            MySqlConnection conn,
            MySqlTransaction transaccion)
        {
            string consulta = @"
                UPDATE DinosaurioHabilidad
                SET Desbloqueada = 1
                WHERE IdDinosaurio = @idDinosaurio
                AND NivelDesbloqueo <= @nivel
                AND Desbloqueada = 0";

            using (MySqlCommand cmd = new MySqlCommand(
                consulta, conn, transaccion))
            {
                cmd.Parameters.AddWithValue("@idDinosaurio", IdDinosaurio);
                cmd.Parameters.AddWithValue("@nivel", Nivel);

                cmd.ExecuteNonQuery();
            }
        }

        // Entrega un nuevo dinosaurio cuando se alcanzan ciertos niveles.
        private void DesbloquearSiguienteDinosaurio(
            MySqlConnection conn,
            MySqlTransaction transaccion)
        {
            int idNuevoDinosaurio = 0;

            // Selecciona el dinosaurio que corresponde a la categoría y nivel.
            if (Nivel == 5)
            {
                if (Categoria == "Carnivoro")
                    idNuevoDinosaurio = 11;
                else if (Categoria == "Herbivoro")
                    idNuevoDinosaurio = 14;
                else if (Categoria == "Omnivoro")
                    idNuevoDinosaurio = 17;
            }
            else if (Nivel == 10)
            {
                if (Categoria == "Carnivoro")
                    idNuevoDinosaurio = 12;
                else if (Categoria == "Herbivoro")
                    idNuevoDinosaurio = 15;
                else if (Categoria == "Omnivoro")
                    idNuevoDinosaurio = 18;
            }

            if (idNuevoDinosaurio == 0)
                return;

            // Comprueba que el jugador todavía no tenga ese dinosaurio.
            string verificar = @"
                SELECT COUNT(*)
                FROM Dinosaurio
                WHERE IdJugador = @idJugador
                AND Especie = (
                    SELECT Especie
                    FROM Dinosaurio
                    WHERE IdDinosaurio = @idCatalogo
                )";

            using (MySqlCommand cmd = new MySqlCommand(
                verificar, conn, transaccion))
            {
                cmd.Parameters.AddWithValue("@idJugador", IdJugador);
                cmd.Parameters.AddWithValue("@idCatalogo", idNuevoDinosaurio);

                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    return;
            }

            // Copia los datos del dinosaurio del catálogo al jugador.
            string consulta = @"
                INSERT INTO Dinosaurio
                (
                    IdJugador, Activo, Nombre, Especie, Categoria,
                    Nivel, Energia, Vida, Experiencia,
                    Fuerza, Defensa, Velocidad,
                    PotenciaMordida, Resistencia, Intimidacion,
                    Agilidad, Precision, Reflejos,
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
                    @idJugador, 0, Nombre, Especie, Categoria,
                    Nivel, Energia, Vida, Experiencia,
                    Fuerza, Defensa, Velocidad,
                    PotenciaMordida, Resistencia, Intimidacion,
                    Agilidad, Precision, Reflejos,
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
                AND IdJugador IS NULL";

            using (MySqlCommand cmd = new MySqlCommand(
                consulta, conn, transaccion))
            {
                cmd.Parameters.AddWithValue("@idJugador", IdJugador);
                cmd.Parameters.AddWithValue("@idCatalogo", idNuevoDinosaurio);

                int filas = cmd.ExecuteNonQuery();

                if (filas == 0)
                    throw new Exception("No se pudo desbloquear el nuevo dinosaurio.");
            }

            // Recupera el ID del nuevo dinosaurio creado.
            long nuevoId;

            using (MySqlCommand cmdId = new MySqlCommand(
                "SELECT LAST_INSERT_ID()", conn, transaccion))
            {
                nuevoId = Convert.ToInt64(cmdId.ExecuteScalar());
            }

            // Copia las habilidades del dinosaurio original al nuevo.
            string copiarHabilidades = @"
                INSERT INTO DinosaurioHabilidad
                (IdDinosaurio, IdHabilidad, Desbloqueada,
                 NivelDesbloqueo, TurnosRestantesRecarga)
                SELECT @nuevoId, IdHabilidad, Desbloqueada,
                       NivelDesbloqueo, 0
                FROM DinosaurioHabilidad
                WHERE IdDinosaurio = @idCatalogo";

            using (MySqlCommand cmd = new MySqlCommand(
                copiarHabilidades, conn, transaccion))
            {
                cmd.Parameters.AddWithValue("@nuevoId", nuevoId);
                cmd.Parameters.AddWithValue("@idCatalogo", idNuevoDinosaurio);
                cmd.ExecuteNonQuery();
            }
        }

        // Método virtual para alimentar al dinosaurio.
        public virtual void Alimentar()
        {
            Energia += 10;

            if (Energia > 100)
                Energia = 100;
        }

        // Agrega experiencia al entrenar.
        public virtual void Entrenar()
        {
            Experiencia += 10;
        }

        // Recupera toda la energía del dinosaurio.
        public virtual void RecuperarEnergia()
        {
            Energia = 100;
        }

        // Devuelve la fuerza de ataque del dinosaurio.
        public virtual int Atacar()
        {
            return Fuerza;
        }

        // Devuelve la defensa del dinosaurio.
        public virtual int Defender()
        {
            return Defensa;
        }

        // Método que pueden modificar las clases de cada especie.
        public virtual void MostrarEstado()
        {
        }

        // Devuelve una característica general del dinosaurio.
        public virtual string ObtenerCaracteristicaUnica()
        {
            return "Depredador";
        }
    }
}