namespace DinosLab
{
    public class Ornithomimus : Omnivoros
    {
        public override int Atacar()
        {
            return Fuerza + Velocidad + 5;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Movimiento impredecible: aprovecha su agilidad";
        }

        public override int Defender()
        {
            return Defensa + Velocidad / 2;
        }

        public override void Entrenar()
        {
            Velocidad += 6;
            Experiencia += 15;
        }
    }
}