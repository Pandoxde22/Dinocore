namespace DinosLab
{
    public class Triceratops : Herbivoros
    {
        public override int Atacar()
        {
            return Fuerza + 20;
        }

        public override string ObtenerCaracteristicaUnica()
        {
            return "Embestida demoledora: aumenta considerablemente el daño";
        }

        public override int Defender()
        {
            return Defensa + 25;
        }

        public override void Entrenar()
        {
            Defensa += 5;
            Fuerza += 2;
            Experiencia += 10;
        }
    }
}