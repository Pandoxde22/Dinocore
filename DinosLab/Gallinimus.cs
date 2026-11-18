namespace DinosLab
{
    public class Gallimimus : Omnivoros
    {
        public override int Atacar()
        {
            return Fuerza + Velocidad + 10;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Carrera incansable: aprovecha su velocidad para atacar";
        }

        public override int Defender()
        {
            return Defensa + Velocidad;
        }

        public override void Entrenar()
        {
            Velocidad += 8;
            Experiencia += 15;
        }

        public override void RecuperarEnergia()
        {
            Energia += 25;

            if (Energia > 100)
                Energia = 100;
        }
    }
}