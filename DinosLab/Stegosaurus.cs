namespace DinosLab
{
    public class Stegosaurus : Herbivoros
    {
        public override int Atacar()
        {
            return Fuerza + 15;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Golpe de cola: ataque reforzado con placas";
        }

        public override int Defender()
        {
            return Defensa + 30;
        }

        public override void Entrenar()
        {
            Defensa += 8;
            Experiencia += 10;
        }
    }
}