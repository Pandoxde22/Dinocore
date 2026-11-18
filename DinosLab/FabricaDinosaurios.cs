namespace DinosLab
{
    public class FabricaDinosaurios
    {
        // Crea un objeto del tipo de dinosaurio correspondiente utilizando sus datos de la base de datos.
        public static Dinosaurio CrearDesdeBD(int idDinosaurio)
        {
            // Obtiene la información del dinosaurio registrado.
            Dinosaurio datos = new Dinosaurio();

            if (!datos.CargarDesdeBD(idDinosaurio))
                return null;

            Dinosaurio nuevoDino;

            // Identifica la especie para determinar qué clase debe instanciarse.
            string especie = datos.Especie.Trim().ToLower();

            // Crea el objeto de acuerdo con la especie del dinosaurio.
            switch (especie)
            {
                case "rex":
                case "tyrannosaurus rex":
                case "tyrannosaurusrex":
                    nuevoDino = new Rex();
                    break;

                case "velociraptor":
                    nuevoDino = new Velociraptor();
                    break;

                case "spinosaurus":
                    nuevoDino = new Spinosaurus();
                    break;

                case "triceratops":
                    nuevoDino = new Triceratops();
                    break;

                case "brachiosaurus":
                    nuevoDino = new Brachiosaurus();
                    break;

                case "stegosaurus":
                    nuevoDino = new Stegosaurus();
                    break;

                case "oviraptor":
                    nuevoDino = new Oviraptor();
                    break;

                case "ornithomimus":
                    nuevoDino = new Ornithomimus();
                    break;

                case "gallimimus":
                    nuevoDino = new Gallimimus();
                    break;

                // Si la especie no coincide con ninguna clase, crea un dinosaurio general.
                default:
                    nuevoDino = new Dinosaurio();
                    break;
            }

            // Transfiere los datos obtenidos de la base de datos al objeto creado.
            nuevoDino.IdDinosaurio = datos.IdDinosaurio;
            nuevoDino.IdJugador = datos.IdJugador;
            nuevoDino.Nombre = datos.Nombre;
            nuevoDino.Especie = datos.Especie;
            nuevoDino.Categoria = datos.Categoria;
            nuevoDino.Nivel = datos.Nivel;
            nuevoDino.Experiencia = datos.Experiencia;
            nuevoDino.Energia = datos.Energia;
            nuevoDino.Vida = datos.Vida;
            nuevoDino.Fuerza = datos.Fuerza;
            nuevoDino.Defensa = datos.Defensa;
            nuevoDino.Velocidad = datos.Velocidad;

            // Devuelve el objeto con su clase y características correspondientes.
            return nuevoDino;
        }
    }
}