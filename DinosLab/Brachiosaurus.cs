namespace DinosLab
{
    public class Brachiosaurus : Herbivoros
    {
        public override int Atacar()
        {
            return Fuerza + 15;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Recuperación natural: recupera energía adicional";
        }

        public override int Defender()
        {
            return Defensa + 15;
        }

        public override void RecuperarEnergia()
        {
            Energia += 40;

            if (Energia > 100)
                Energia = 100;
        }

        public override void Entrenar()
        {
            Defensa += 5;
            Experiencia += 10;
        }
    }
}