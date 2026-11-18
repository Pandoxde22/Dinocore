namespace DinosLab
{
    public class Oviraptor : Omnivoros
    {
        public override int Atacar()
        {
            return Fuerza + 15;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Adaptación rápida: se adapta a diferentes situaciones";
        }

        public override int Defender()
        {
            return Defensa + 10;
        }

        public override void Entrenar()
        {
            Fuerza += 3;
            Velocidad += 3;
            Experiencia += 15;
        }
    }
}